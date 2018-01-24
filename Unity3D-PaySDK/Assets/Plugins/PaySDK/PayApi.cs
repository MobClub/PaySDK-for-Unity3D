using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{
	public class AliPayApi {

		public static WxPayApi create()
		{
			#if UNITY_ANDROID
			moblinkUtils = new AndroidMobLinkImpl();
			#elif UNITY_IPHONE
			moblinkUtils = new iOSMobLinkImpl();
			#endif
		}


		public void pay(PayOrder order, OnPayListener<PayOrder, AliPayApi> callback)
		{
			
		}

		public void pay(TicketOrder order, OnPayListener<TicketOrder, AliPayApi> callback)
		{
			
		}
	}


	public class WxPayApi {
		public static WxPayApi create()
		{
		}



		public void pay(PayOrder order, OnPayListener<PayOrder, WxPayApi> callback)
		{

		}

		public void pay(TicketOrder order, OnPayListener<TicketOrder, WxPayApi> callback)
		{

		}


	}

}


