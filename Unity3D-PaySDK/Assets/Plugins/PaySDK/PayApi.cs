using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{
	public abstract class MobPayApi
	{
	}
	public abstract class AliPayApi : MobPayApi
	{
		public static AliPayApi create()
		{
			#if UNITY_ANDROID
			return new AndroidAliPayApi();
			#elif UNITY_IPHONE
			// TODO handle ios
			#endif
		}


		public abstract void pay(PayOrder order, OnPayListener<PayOrder, AliPayApi> callback);

		public abstract void pay (TicketOrder order, OnPayListener<TicketOrder, AliPayApi> callback);
	}


	public abstract class WxPayApi : MobPayApi
	{
		
		public static WxPayApi create()
		{
			#if UNITY_ANDROID
			return new AndroidWxPayApi();
			#elif UNITY_IPHONE
			// TODO handle ios
			#endif
		}

		public abstract void pay (PayOrder order, OnPayListener<PayOrder, WxPayApi> callback);

		public abstract void pay (TicketOrder order, OnPayListener<TicketOrder, WxPayApi> callback);
	}

}


