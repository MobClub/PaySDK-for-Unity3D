using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace cn.paysdk.unity
{
	#if UNITY_ANDROID
	public class AndroidPaySDKImpl
	{
		public AndroidPaySDKImpl () 
		{
		}

		public void payWithOrder (PaySDKOrder order, PaySDKChannel channel, PaySDKHandler handler)
		{	
			AndroidPayOrder aOrder = new AndroidPayOrder();
			aOrder.setAmount ((int)order.amount);
			aOrder.setBody (order.body);
			aOrder.setDescription (order.des);
			aOrder.setMetadata (order.metadata);
			aOrder.setOrderNo (order.orderId);
			aOrder.setSubject (order.subject);

			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				AndroidAliPayApi api = new AndroidAliPayApi();
				AndroidOnPayListener<AndroidPayOrder, AndroidAliPayApi> l = AndroidOnPayListener<AndroidPayOrder, AndroidAliPayApi>.create ();
				l.PayOrder = aOrder; l.PayApi = api; l.OnPayListener = handler;
				api.pay (aOrder, l);
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				AndroidWxPayApi api = new AndroidWxPayApi();
				AndroidOnPayListener<AndroidPayOrder, AndroidWxPayApi> l = AndroidOnPayListener<AndroidPayOrder, AndroidWxPayApi>.create ();
				l.PayOrder = aOrder; l.PayApi = api; l.OnPayListener = handler;
				api.pay (aOrder, l);
			}
		}

		public void payWithTicketId (string ticketId, PaySDKChannel channel, PaySDKHandler handler)
		{
			AndroidTicketOrder aOrder = new AndroidTicketOrder ();
			aOrder.setTicketId (ticketId);

			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				AndroidAliPayApi api = new AndroidAliPayApi ();
				AndroidOnPayListener<AndroidTicketOrder, AndroidAliPayApi> l = AndroidOnPayListener<AndroidTicketOrder, AndroidAliPayApi>.create ();
				l.PayOrder = aOrder; l.PayApi = api; l.OnPayListener = handler;
				api.pay (aOrder, l);
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				AndroidWxPayApi api = new AndroidWxPayApi ();
				AndroidOnPayListener<AndroidTicketOrder, AndroidWxPayApi> l = AndroidOnPayListener<AndroidTicketOrder, AndroidWxPayApi>.create ();
				l.PayOrder = aOrder; l.PayApi = api; l.OnPayListener = handler;

				api.pay (aOrder, l);
			}
		}

		public string getVersion ()
		{
			return "";
		}

		public void setDebugMode (bool enabled)
		{
		}
	}
	#endif
}

