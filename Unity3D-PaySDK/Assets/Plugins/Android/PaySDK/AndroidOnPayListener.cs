using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{

	#if UNITY_ANDROID
	public class AndroidOnPayListener<O, API>
	{
		private CxxJavaObject javaCore = new CxxJavaObject();
		private OnPayListener<O, API> onPayListener;
		private O payOrder;
		public O PayOrder
		{
			get { return payOrder; }
			set { payOrder = value; }
		}

		private API payApi;
		public API PayApi
		{
			get { return payApi; }
			set { payApi = value; }
		}

		private static AndroidOnPayListener<O, API> sInstance;

		public AndroidOnPayListener()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jclazz = AndroidJNI.FindClass ("com/mob/paysdk/unity/OnPayListener");
			IntPtr jConstructor = AndroidJNI.GetMethodID (jclazz, "<init>", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr jret = AndroidJNI.NewObject (jclazz, jConstructor, CxxJavaObject.createJavaParam ("PaySDK", "_AndroidOnWillPay", "_AndroidOnPayEnd"));
			javaCore.attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public void setOnPayListener(OnPayListener<O, API> callback)
		{
			onPayListener = callback;
		}

		public IntPtr getLocalJavaObject()
		{
			return javaCore.getLocalJavaObject ();
		}

		public void onWillPay(string param)
		{
			if (null != onPayListener) {
				onPayListener.onWillPay (param, payOrder, payApi);
			}
		}

		public void onPayEnd(string param)
		{
			int result = int.Parse (param);
			PayResult payResult = new PayResult ();
			payResult.setPayStatus (result);
			if (null != onPayListener) {
				onPayListener.onPayEnd (payResult, payOrder, payApi);
			}
		}


	}

	public class JavaCallback 
	{
		public static object sInstance;
		
		public static void onWillPay(string param)
		{
			if (null != (sInstance as AndroidOnPayListener<PayOrder, AliPayApi>)) {
				AndroidOnPayListener<PayOrder, AliPayApi> p = (AndroidOnPayListener<PayOrder, AliPayApi>)sInstance;
				p.onWillPay (param);
			} else if(null != (sInstance as AndroidOnPayListener<PayOrder, WxPayApi>)) {
				AndroidOnPayListener<PayOrder, WxPayApi> p = (AndroidOnPayListener<PayOrder, WxPayApi>)sInstance;
				p.onWillPay (param);
			} else if(null != (sInstance as AndroidOnPayListener<TicketOrder, AliPayApi>)) {
				AndroidOnPayListener<TicketOrder, AliPayApi> p = (AndroidOnPayListener<TicketOrder, AliPayApi>)sInstance;
				p.onWillPay (param);
			} else if(null != (sInstance as AndroidOnPayListener<AliPayApi, WxPayApi>)) {
				AndroidOnPayListener<AliPayApi, WxPayApi> p = (AndroidOnPayListener<AliPayApi, WxPayApi>)sInstance;
				p.onWillPay (param);
			}
		}

		public static void onPayEnd(string param)
		{
			if (null != (sInstance as AndroidOnPayListener<PayOrder, AliPayApi>)) {
				AndroidOnPayListener<PayOrder, AliPayApi> p = (AndroidOnPayListener<PayOrder, AliPayApi>)sInstance;
				p.onPayEnd (param);
			} else if(null != (sInstance as AndroidOnPayListener<PayOrder, WxPayApi>)) {
				AndroidOnPayListener<PayOrder, WxPayApi> p = (AndroidOnPayListener<PayOrder, WxPayApi>)sInstance;
				p.onPayEnd (param);
			} else if(null != (sInstance as AndroidOnPayListener<TicketOrder, AliPayApi>)) {
				AndroidOnPayListener<TicketOrder, AliPayApi> p = (AndroidOnPayListener<TicketOrder, AliPayApi>)sInstance;
				p.onPayEnd (param);
			} else if(null != (sInstance as AndroidOnPayListener<TicketOrder, WxPayApi>)) {
				AndroidOnPayListener<TicketOrder, WxPayApi> p = (AndroidOnPayListener<TicketOrder, WxPayApi>)sInstance;
				p.onPayEnd (param);
			}
			sInstance = null;
		}
	}
	#endif
}



