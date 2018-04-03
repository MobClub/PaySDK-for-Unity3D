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

		[DllImport("__Internal")]
		private static extern void __iosPaySDKPayWithOrder (string order, int channel, string observer);
		[DllImport("__Internal")]
		private static extern void __iosPaySDKPayWithTicketId (string ticketId, string observer);
		[DllImport("__Internal")]
		private static extern string __iosPaySDKGetVersion ();
		[DllImport("__Internal")]
		private static extern void __iosPaySDKSetDebugMode (bool enable);

		private string _callbackObjectName = "Main Camera";

		public AndroidPaySDKImpl (GameObject go) 
		{
			try{
				_callbackObjectName = go.name;
			} catch(Exception e) {
				Console.WriteLine("{0} Exception caught.", e);
			}
		}

		public override void payWithOrder (PaySDKOrder order, PaySDKChannel channel)
		{	
			PayOrder aOrder = PayOrder.create ();
			aOrder.setAmount (order.amount);
			aOrder.setBody (order.body);
			aOrder.setDescription (order.des);
			aOrder.setMetadata (order.metadata);
			aOrder.setOrderNo (order.orderId);
			aOrder.setSubject (order.subject);

			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				AliPayApi api = AliPayApi.create ();
				OnPayListener<PayOrder, AliPayApi> l = OnPayListener<PayOrder, AliPayApi>.create ();
				api.pay (aOrder, l);
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				WxPayApi api = WxPayApi.create ();
				OnPayListener<PayOrder, WxPayApi> l = OnPayListener<PayOrder, WxPayApi>.create ();
				api.pay (aOrder, l);
			}
		}

		public override void payWithTicketId (string ticketId, PaySDKChannel channel)
		{
			TicketOrder aOrder = TicketOrder.create ();
			aOrder.setTicketId (ticketId);

			if (PaySDKChannel.PaySDKChannelAlipay == channel) {
				AliPayApi api = AliPayApi.create ();
				OnPayListener<TicketOrder, AliPayApi> l = OnPayListener<TicketOrder, AliPayApi>.create ();
				api.pay (aOrder, l);
			} else if (PaySDKChannel.PaySDKChannelWechat == channel) {
				WxPayApi api = WxPayApi.create ();
				OnPayListener<TicketOrder, WxPayApi> l = OnPayListener<TicketOrder, WxPayApi>.create ();
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

