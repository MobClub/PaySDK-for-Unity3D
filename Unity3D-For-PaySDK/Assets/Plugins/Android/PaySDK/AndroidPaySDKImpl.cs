using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace cn.paysdk.unity
{
	#if UNITY_ANDROID
	public class AndroidPaySDKImpl : PaySDKInterface
	{

		public PaySDKHandler tempHandler;

		public AndroidPaySDKImpl () 
		{
		}

		public override void payWithOrder (PaySDKOrder order, PaySDKChannel channel)
		{	
			PayOrder aOrder = PayOrder.create ();
			aOrder.setAmount ((int)order.amount);
			aOrder.setBody (order.body);
			aOrder.setDescription (order.des);
			aOrder.setMetadata (order.metadata);
			aOrder.setOrderNo (order.orderId);
			aOrder.setSubject (order.subject);

			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				AliPayApi api = AliPayApi.create ();
				AndroidOnPayListener<PayOrder, AliPayApi> l = AndroidOnPayListener<PayOrder, AliPayApi>.create ();
				l.OnPayListener = tempHandler;
				tempHandler = null;
				api.pay (aOrder, l);
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				WxPayApi api = WxPayApi.create ();
				AndroidOnPayListener<PayOrder, WxPayApi> l = AndroidOnPayListener<PayOrder, WxPayApi>.create ();
				api.pay (aOrder, l);
			}
		}

		public override void payWithTicketId (string ticketId, PaySDKChannel channel)
		{
			TicketOrder aOrder = TicketOrder.create ();
			aOrder.setTicketId (ticketId);

			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				AliPayApi api = AliPayApi.create ();
				AndroidOnPayListener<TicketOrder, AliPayApi> l = AndroidOnPayListener<TicketOrder, AliPayApi>.create ();
				l.OnPayListener = tempHandler;
				tempHandler = null;
				api.pay (aOrder, l);
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				WxPayApi api = WxPayApi.create ();
				AndroidOnPayListener<TicketOrder, WxPayApi> l = AndroidOnPayListener<TicketOrder, WxPayApi>.create ();
				l.OnPayListener = tempHandler;
				tempHandler = null;
				api.pay (aOrder, l);
			}
		}

		public override string getVersion ()
		{
			return "";
		}

		public override void setDebugMode (bool enabled)
		{
		}
	}
	#endif
}

