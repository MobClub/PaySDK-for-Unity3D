using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace cn.paysdk.unity
{
	public enum PaySDKChannel
	{
		PaySDKChannelWechat = 22,
		PaySDKChannelAlipay = 50
	}

	public enum PaySDKStatus
	{
		PaySDKStatusSuccess = 0,
		PaySDKStatusFail,
		PaySDKStatusCancel,
		MPSPayStatusUnknown
	}
	
	public class PaySDK : MonoBehaviour {

		static private PaySDKInterface paysdkImpl;
		static public PaySDKHandler resultHandler;

		void Awake ()
		{
			Debug.Log("[PaySDK]PaySDK  ===>>>  Awake" );
			#if UNITY_ANDROID

			#elif UNITY_IOS
			paysdkImpl = new iOSPaySDKImpl (gameObject);
			#endif
		}
														
		static public void payWithOrder (PaySDKOrder order, PaySDKChannel channel, PaySDKHandler handler)
		{
			PaySDK.resultHandler = handler;
			paysdkImpl.payWithOrder (order, channel);
		}

		static public void payWithTicketId (string ticketId, PaySDKChannel channel, PaySDKHandler handler)
		{
			PaySDK.resultHandler = handler;
			paysdkImpl.payWithTicketId (ticketId, channel);
		}

		static public string getVersion ()
		{
			return paysdkImpl.getVersion ();
		}

		static public void setDebugMode (bool enabled)
		{
			#if UNITY_ANDROID
			// 无
			#elif UNITY_IOS
			paysdkImpl.setDebugMode(enabled);
			#endif
		}

		private void _iOSPaysdkCallBack (string result)
		{
			Debug.Log ("Data:"+result);
			Hashtable res = (Hashtable)MiniJSON.jsonDecode (result);
			if (res == null || res.Count <= 0) {
				return;
			}

			int code = Convert.ToInt32 (res ["status"]);
			string ticketId = res ["ticketId"].ToString();
			long errorCode = Convert.ToInt64(res ["errorCode"]);
			string errorDes = res ["errorDes"].ToString();

			PaySDKStatus status;

			if (code == 1) {
				status = PaySDKStatus.PaySDKStatusSuccess;
			} else if (code == 2) {
				status = PaySDKStatus.PaySDKStatusFail;
			} else if (code == 3) {
				status = PaySDKStatus.PaySDKStatusCancel;
			} else {
				status = PaySDKStatus.MPSPayStatusUnknown;
			}
								 
			if (code == 0) {
				PaySDK.resultHandler.onWillPay (ticketId);
			} else {
				PaySDK.resultHandler.onPayEnd (status, ticketId, errorCode, errorDes);
			}
		}
	}
}
	
