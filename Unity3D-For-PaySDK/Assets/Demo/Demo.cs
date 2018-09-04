using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using cn.paysdk.unity;

public class Demo : MonoBehaviour,PaySDKHandler {

	// Use this for initialization
	public GUISkin demoSkin;
	private string result = "支付结果：";
	private string amount = "1";

	// Use this for initialization
	void Start () {
		Debug.Log("[PaySDK]Demo  ===>>>  Start" );
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
		
	void OnGUI() {
		GUI.skin = demoSkin;

		float scale = 1.0f;
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			scale = Screen.width / 320;
		} else if (Application.platform == RuntimePlatform.Android) {
			if (Screen.orientation == ScreenOrientation.Portrait) {
				scale = Screen.width / 320;
			} else {
				scale = Screen.height / 320;
			}
		}

		float btnWidth = 200 * scale;
		float btnHeight = 30 * scale;
		float btnTop = 150 * scale;
		GUI.skin.button.fontSize = Convert.ToInt32(14 * scale);
		GUI.skin.label.fontSize = Convert.ToInt32 (14 * scale);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.textField.fontSize = Convert.ToInt32 (14 * scale);
		GUI.skin.textField.alignment = TextAnchor.MiddleCenter;

		float labelWidth = 120 * scale;
		GUI.Label (new Rect ((Screen.width - btnWidth) / 2, btnTop, labelWidth, btnHeight), "金额 (单位：分)：");

		amount = GUI.TextField(new Rect((Screen.width - btnWidth) / 2 + labelWidth, btnTop, btnWidth - labelWidth, btnHeight), amount);

		btnTop += btnHeight + 10 * scale;

		//iOS only
		#if UNITY_IOS
		PaySDK.setDebugMode (true);
		#endif

		//创建微信支付按钮  x , y, w, h

		if (GUI.Button(new Rect((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight), "微信支付"))
		{
			PaySDKOrder order = new PaySDKOrder ();

			order.orderId = DateTime.Now.ToFileTime().ToString();
			order.amount = Convert.ToInt64(amount);
			order.subject = "支付测试";
			order.userId = "1234567890";
			order.nickName = "nickName";
			order.body = "body";
			order.des = "des";
			order.metadata = "{\n\t\"meta\": \"meta\"\n}";

			PaySDK.payWithOrder (order, PaySDKChannel.PaySDKChannelWechat, this);
		}

		btnTop += btnHeight + 10 * scale;
		if (GUI.Button(new Rect((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight), "支付宝支付"))
		{
			PaySDKOrder order = new PaySDKOrder ();

			order.orderId = DateTime.Now.ToFileTime().ToString();
			order.amount = Convert.ToInt64(amount);
			order.subject = "支付测试";
			order.userId = "1234567890";
			order.nickName = "nickName";
			order.body = "body";
			order.des = "des";
			order.metadata = "{\n\t\"meta\": \"meta\"\n}";

			PaySDK.payWithOrder (order, PaySDKChannel.PaySDKChannelAlipay, this);
		}
			
		btnTop += btnHeight + 44 * scale;

		//----
		//创建银联支付的按钮
		if (GUI.Button(new Rect((Screen.width - btnWidth) / 2, btnTop-45, btnWidth, btnHeight), "银联支付"))
		{
			PaySDKOrder order = new PaySDKOrder ();

			order.orderId = DateTime.Now.ToFileTime().ToString();
			order.amount = Convert.ToInt64(amount);
			order.subject = "支付测试";
			order.userId = "1234567890";
			order.nickName = "nickName";
			order.body = "body";
			order.des = "des";
			order.metadata = "{\n\t\"meta\": \"meta\"\n}";

			PaySDK.payWithOrder (order, PaySDKChannel.PaySDKChannelUnionPay, this);
		}
			
		
		//btnTop += btnHeight + 44 * scale ;
		btnTop += btnHeight + 22 * scale ;
		btnTop = btnTop - 25;

		GUIStyle style=new GUIStyle();
		style.normal.textColor=new Color(1,0,0);   //字体颜色
		// style.fontSize = 30;
		style.fontSize = (int)(15 * scale);       //字体大小
		GUI.Label(new Rect(20, btnTop, Screen.width - 20 - 20, Screen.height - btnTop), result, style);
	}

	public bool onWillPay (string ticketId) {
		Debug.Log ("-----------> WillPay:" + ticketId);
		return false;
	}

	//支付结束 回调结果
	public void onPayEnd (PaySDKStatus status, string ticketId, long errorCode, string errorDes) {

		Debug.Log ("Status:" + status + "  ticketId:" + ticketId + "  errorCode:" + errorCode + "errorDes:" + errorDes);
		if (status == PaySDKStatus.PaySDKStatusCancel) {
			result = "Pay Cancel";
		} else if (status == PaySDKStatus.PaySDKStatusSuccess) {
			result = "Pay Success";
		} else if (status == PaySDKStatus.PaySDKStatusFail) {
			result = "Pay Fail Error:" + errorCode + "  Des:" + errorDes;
		} else {
			result = "Pay Result Unknown  Error:" + errorCode + "  Des:" + errorDes;
		}
	} 
}
