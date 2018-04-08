using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class AndroidAliPayApi : CxxJavaObject
	{
		public AndroidAliPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/AliPayAPI");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public void pay(AndroidPayOrder order, AndroidOnPayListener<AndroidPayOrder, AndroidAliPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidPayOrder dOrder = (AndroidPayOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<AndroidPayOrder, AndroidAliPayApi> cxx = (AndroidOnPayListener<AndroidPayOrder, AndroidAliPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();
			IntPtr gRef = cxx.getJavaObject ();
			GCNativeKeeper.getInstance ().keep (gRef, cxx);

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		public void pay (AndroidTicketOrder order, AndroidOnPayListener<AndroidTicketOrder, AndroidAliPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidTicketOrder dOrder = (AndroidTicketOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<AndroidTicketOrder, AndroidAliPayApi> cxx = (AndroidOnPayListener<AndroidTicketOrder, AndroidAliPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();
			IntPtr gRef = cxx.getJavaObject ();
			GCNativeKeeper.getInstance ().keep (gRef, cxx);

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		~AndroidAliPayApi()
		{
			
		}
	}

	public class AndroidWxPayApi : CxxJavaObject
	{
		private CxxJavaObject javaCore = new CxxJavaObject();

		public AndroidWxPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/WXPayAPI");
			javaCore.attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public void pay(AndroidPayOrder order, AndroidOnPayListener<AndroidPayOrder, AndroidWxPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = javaCore.getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidPayOrder dOrder = (AndroidPayOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<AndroidPayOrder, AndroidWxPayApi> cxx = (AndroidOnPayListener<AndroidPayOrder, AndroidWxPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();
			IntPtr gRef = cxx.getJavaObject ();
			GCNativeKeeper.getInstance ().keep (gRef, cxx);

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}

		public void pay (AndroidTicketOrder order, AndroidOnPayListener<AndroidTicketOrder, AndroidWxPayApi> callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = javaCore.getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			AndroidTicketOrder dOrder = (AndroidTicketOrder) order;
			IntPtr jorder = dOrder.getLocalJavaObject();

			AndroidOnPayListener<AndroidTicketOrder, AndroidWxPayApi> cxx = (AndroidOnPayListener<AndroidTicketOrder, AndroidWxPayApi>)callback;
			IntPtr jListener = cxx.getLocalJavaObject();
			IntPtr gRef = cxx.getJavaObject ();
			GCNativeKeeper.getInstance ().keep (gRef, cxx);

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}
	}
	#endif
}



