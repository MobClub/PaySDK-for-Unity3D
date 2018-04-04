using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{
	#if UNITY_ANDROID
	public abstract class MobPayApi : CxxJavaObject
	{
	}
	public abstract class AliPayApi : MobPayApi
	{
		public static AliPayApi create()
		{
			return new AndroidAliPayApi();
		}


		public abstract void pay(PayOrder order, OnPayListener<PayOrder, AliPayApi> callback);

		public abstract void pay (TicketOrder order, OnPayListener<TicketOrder, AliPayApi> callback);
	}


	public abstract class WxPayApi : MobPayApi
	{
		
		public static WxPayApi create()
		{
			return new AndroidWxPayApi();
		}

		public abstract void pay (PayOrder order, OnPayListener<PayOrder, WxPayApi> callback);

		public abstract void pay (TicketOrder order, OnPayListener<TicketOrder, WxPayApi> callback);
	}
	#endif
}


