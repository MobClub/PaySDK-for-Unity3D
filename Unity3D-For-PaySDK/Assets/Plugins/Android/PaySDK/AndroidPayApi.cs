using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class AndroidAliPayApi : AliPayApi
	{
		public AndroidAliPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/AliPayAPI");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public override void pay(PayOrder order, OnPayListener<PayOrder, AliPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidPayOrder dOrder = (AndroidPayOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<PayOrder, AliPayApi> cxx = (AndroidOnPayListener<PayOrder, AliPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		public override void pay (TicketOrder order, OnPayListener<TicketOrder, AliPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidTicketOrder dOrder = (AndroidTicketOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<TicketOrder, AliPayApi> cxx = (AndroidOnPayListener<TicketOrder, AliPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		~AndroidAliPayApi()
		{
			
		}
	}

	public class AndroidWxPayApi : WxPayApi
	{
		private CxxJavaObject javaCore = new CxxJavaObject();

		public AndroidWxPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/WXPayAPI");
			javaCore.attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public override void pay(PayOrder order, OnPayListener<PayOrder, WxPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = javaCore.getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidPayOrder dOrder = (AndroidPayOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<PayOrder, WxPayApi> cxx = (AndroidOnPayListener<PayOrder, WxPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		public override void pay (TicketOrder order, OnPayListener<TicketOrder, WxPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = javaCore.getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidTicketOrder dOrder = (AndroidTicketOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<TicketOrder, WxPayApi> cxx = (AndroidOnPayListener<TicketOrder, WxPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}
	}
	#endif
}



