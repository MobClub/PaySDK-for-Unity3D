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
			AndroidPayApi api = createPayApi (channel);
			AndroidOnPayListener listener = AndroidOnPayListener.create(api, aOrder, handler);
			api.pay (aOrder, listener);
		}

		public void payWithTicketId (string ticketId, PaySDKChannel channel, PaySDKHandler handler)
		{
			AndroidTicketOrder aOrder = new AndroidTicketOrder ();
			aOrder.setTicketId (ticketId);
			AndroidPayApi api = createPayApi (channel);
			AndroidOnPayListener listener = AndroidOnPayListener.create (api, aOrder, handler);
			api.pay (aOrder, listener);
		}

		private AndroidPayApi createPayApi(PaySDKChannel channel)
		{
			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				return new AndroidAliPayApi();
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				return new AndroidWxPayApi();
			} else if (PaySDKChannel.PaySDKChannelUnionPay == channel) {
				return new AndroidUnionPayApi();
			} else {
				return null;
			}
		}
	}
	#endif
}

