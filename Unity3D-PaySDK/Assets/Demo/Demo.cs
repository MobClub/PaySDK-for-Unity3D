using UnityEngine;
using System;
using System.Collections;
using com.moblink.unity3d;
using UnityEngine.SceneManagement;

using System.Runtime.InteropServices;

public class Demo : MonoBehaviour {

	public GUISkin demoSkin;
	private float scale = 1.0f;

	// window rect(dialog)
	private Rect windowRect;

	protected void Start () {

	}

	void OnGUI ()
	{
		GUI.skin = demoSkin;

		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			scale = Screen.width / 320;
		} else if (Application.platform == RuntimePlatform.Android) {
			scale = Screen.width / 320;
		}

		float FONT_SIZE = (int)(18 * scale);
		float ITEM_HEIGHT = 30 * scale;
		float V_DIVIDER_HEIGHT = 20 * scale;
		float LEFT = 20 * scale;
		bool hit = false;

		GUI.skin.button.fontSize = (int)FONT_SIZE;
		GUI.skin.label.fontSize = (int)FONT_SIZE;
		GUI.skin.label.alignment = TextAnchor.MiddleLeft;
		GUI.skin.textField.fontSize = (int)FONT_SIZE;
		GUI.skin.box.fontSize = (int)FONT_SIZE;
		GUI.skin.window.fontSize = (int)FONT_SIZE;

		float x, y, w, h;
		w = Screen.width - 40 * scale; x = 20 * scale; y = 40 * scale; h = ITEM_HEIGHT;
		y += V_DIVIDER_HEIGHT + ITEM_HEIGHT;
		hit = GUI.Button (new Rect (x, y, w, ITEM_HEIGHT), "支付宝支付");
		if (hit)
			toAliPay ();

		y += V_DIVIDER_HEIGHT + ITEM_HEIGHT;
		hit = GUI.Button (new Rect (x, y, w, ITEM_HEIGHT), "微信支付");
		if (hit)
			toWxPay ();

		renderWindow ();
	}
		
	void toAliPay()
	{
		PayOrder order = PayOrder.create ();
		order.setOrderNo (getTimestamp(DateTime.Now).ToString());
		order.setAmount (1);
		order.setSubject("subject");
		order.setBody("body");
		AliPayApi api = PaySDK.createMobPayAPI<AliPayApi> ();
		api.pay (order, new PayListener<PayOrder, AliPayApi>());
	}

	void toWxPay()
	{
		/*
		PayOrder order = PayOrder.create ();
		order.setOrderNo (getTimestamp(DateTime.Now).ToString());
		order.setAmount (1);
		order.setSubject("subject");
		order.setBody("body");

		string aaaa = order.getBody ();

		Debug.Log ("aaaaaaaaaaaaaaaa:" + aaaa);

		WxPayApi api = PaySDK.createMobPayAPI<WxPayApi> ();
		api.pay (order, new PayListener<PayOrder, WxPayApi>());
		*/

		AndroidPayOrder order = new AndroidPayOrder();
		IntPtr value = new IntPtr (100);
		IntPtr jThiz = JavaCallback.JNI_INTERNAL_CALL_NewObject (ref value);

		order.setBody ("abdceed", jThiz);

		string aaaa = order.getBody (jThiz);

		Debug.Log ("aaaaaaaaaaaaaaaa:" + aaaa);

	}

	void renderWindow() 
	{
		{
			float width = Screen.width - 80 * scale;
			float height = width;
			float x = 40 * scale;
			float y = (Screen.height - height) / 2;
			windowRect = new Rect (x, y, width, width);
		}

		/*
		if (0 != boxId) {
			GUI.ModalWindow(0, windowRect, renderWindowCallback, "提示");
		} */
	}

	void renderWindowCallback(int windowID) {

	}



	public long getTimestamp(DateTime dateTime)
	{
		DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return (dateTime.Ticks - dt1970.Ticks) / 10000;
	}
}

public class PayListener<O, API> : OnPayListener<O, API>
{
	public bool onWillPay(string ticketId, O order, API api)
	{
		Debug.Log ("onWillPay(), ticketId:" + ticketId);
		return false;
	}
	public void onPayEnd(PayResult payResult, O order, API api) 
	{
		Debug.Log ("onPayEnd(), payResult:" + payResult);
	}
}
