using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class AndroidPayApi : CxxJavaObject {
		public void pay(AndroidPayOrder order, AndroidOnPayListener callback)
		{
			payInner (order, callback);
		}

		public void pay(AndroidTicketOrder order, AndroidOnPayListener callback)
		{
			payInner (order, callback);
		}

		private void payInner(AndroidOrder order, AndroidOnPayListener callback)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jApi = getLocalJavaObject();
			IntPtr jApiClazz = CxxJavaObject.getJavaClass(jApi);
			IntPtr jApiPayMethod = CxxJavaObject.getJavaMethodID(jApiClazz, "pay",
				"(Lcom/mob/paysdk/Order;Lcom/mob/paysdk/OnPayListener;)V");

			IntPtr jorder = order.getLocalJavaObject();

			AndroidOnPayListener cxx = callback;
			IntPtr jListener = cxx.getLocalJavaObject();
			IntPtr gRef = cxx.getJavaObject ();
			GCNativeKeeper.getInstance ().keep (gRef, cxx);

			AndroidJNI.CallVoidMethod(jApi, jApiPayMethod, CxxJavaObject.createJavaParam(jorder, jListener));
			CxxJavaObject.callJavaEnd ();
		}
	}

	public class AndroidAliPayApi : AndroidPayApi
	{
		public AndroidAliPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/AliPayAPI");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		~AndroidAliPayApi()
		{
			
		}
	}

	public class AndroidWxPayApi : AndroidPayApi
	{
		public AndroidWxPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/WXPayAPI");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}
	}

	public class AndroidUnionPayApi : AndroidPayApi
	{
		public AndroidUnionPayApi()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/UnionPayAPI");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}
	}
	#endif
}