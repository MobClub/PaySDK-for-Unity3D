using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{

	#if UNITY_ANDROID
	public class AndroidAliPayApi : AliPayApi 
	{
		private CxxJavaObject javaCore = new CxxJavaObject();

		public AndroidAliPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/AliPayAPI");
			javaCore.attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public override void pay(PayOrder order, OnPayListener<PayOrder, AliPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = javaCore.getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidPayOrder dOrder = (AndroidPayOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<PayOrder, AliPayApi> cxx = new  AndroidOnPayListener<PayOrder, AliPayApi>();
			cxx.setOnPayListener(callback);
			IntPtr jListener = cxx.getLocalJavaObject();

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		public override void pay (TicketOrder order, OnPayListener<TicketOrder, AliPayApi> callback)
		{
			
		}

		~AndroidAliPayApi()
		{
			
		}
	}

	public class AndroidWxPayApi : WxPayApi {

		public override void pay(PayOrder order, OnPayListener<PayOrder, WxPayApi> callback)
		{
			
		}

		public override void pay (TicketOrder order, OnPayListener<TicketOrder, WxPayApi> callback)
		{

		}
	}
	#endif
}



