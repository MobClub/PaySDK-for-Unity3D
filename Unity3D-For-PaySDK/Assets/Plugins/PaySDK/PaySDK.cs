using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace cn.paysdk.unity
{
	public enum PaySDKChannel
	{
		PaySDKChannelWechat = 22,
		PaySDKChannelAlipay = 50,
		PaySDKChannelUnionPay = 53
	}

	public enum PaySDKStatus
	{
		PaySDKStatusSuccess = 0,
		PaySDKStatusFail = 1,
		PaySDKStatusCancel = 2,
		MPSPayStatusUnknown = 3
	}
	
	public class PaySDK : MonoBehaviour {

		#if UNITY_ANDROID
		static private AndroidPaySDKImpl paysdkImpl;
		#elif UNITY_IOS
		static private PaySDKInterface paysdkImpl;
		#endif

		static public PaySDKHandler resultHandler;

		void Awake ()
		{
			Debug.Log("[PaySDK]PaySDK  ===>>>  Awake" );
			#if UNITY_ANDROID
			paysdkImpl = new AndroidPaySDKImpl();
			#elif UNITY_IOS
			paysdkImpl = new iOSPaySDKImpl (gameObject);
			#endif
		}
														
		static public void payWithOrder (PaySDKOrder order, PaySDKChannel channel, PaySDKHandler handler)
		{
			#if UNITY_ANDROID
			paysdkImpl.payWithOrder (order, channel, handler);
			#elif UNITY_IOS
			PaySDK.resultHandler = handler;
			paysdkImpl.payWithOrder (order, channel);
			#endif
		}

		static public void payWithTicketId (string ticketId, PaySDKChannel channel, PaySDKHandler handler)
		{
			#if UNITY_ANDROID
			paysdkImpl.payWithTicketId (ticketId, channel, handler);
			#elif UNITY_IOS
			PaySDK.resultHandler = handler;
			paysdkImpl.payWithTicketId (ticketId, channel);
			#endif
		}

		#if UNITY_IOS
		static public string getVersion ()
		{
			return paysdkImpl.getVersion ();
		}

		static public void setDebugMode (bool enabled)
		{
			paysdkImpl.setDebugMode(enabled);
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
			string errorCode = res ["errorCode"];
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
		PaySDK.resultHandler.onPayEnd (status, ticketId, new string(errorCode), errorDes);
			}
		}
		#endif
	}
}
	
