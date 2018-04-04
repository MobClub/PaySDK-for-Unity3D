using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class AndroidOnPayListener<O, API> : CxxJavaObject, OnPayListener<O, API>
	{
		public static AndroidOnPayListener<O, API> create()
		{
			return new AndroidOnPayListener<O, API>();
		}

		private PaySDKHandler onPayListener;

		public PaySDKHandler OnPayListener
		{
			get { return onPayListener; }
			set { onPayListener = value; }
		}

		public AndroidOnPayListener()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jclazz = AndroidJNI.FindClass ("com/mob/paysdk/unity/OnPayListener");
			IntPtr jConstructor = AndroidJNI.GetMethodID (jclazz, "<init>", "(JJ)V");
			IntPtr willMethod = Marshal.GetFunctionPointerForDelegate (new WillPayFunction (willPayFunction));
			IntPtr endMethod = Marshal.GetFunctionPointerForDelegate (new PayEndFunction (payEndFunction));
			IntPtr jret = AndroidJNI.NewObject (jclazz, jConstructor, CxxJavaObject.createJavaParam (willMethod, endMethod));
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();

		}
		/*
		public void onWillPay(string param)
		{

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
		*/

		/**
		 * 下面定义委托, 用于java回调 
		 */
		private delegate int WillPayFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jTicket);
		private delegate void PayEndFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, int jResult);

		protected bool onWillPay( O order, API api, string ticketId) {
			PaySDKHandler l = onPayListener;
			if (null != l) {
				return l.onWillPay (ticketId);
			}
			return false;
		}

		protected void onPayEnd(O order, API api, int payResult) {
			PaySDKHandler l = onPayListener;
			if (null != l) {
				// callback
				//return l.onPayEnd (payResult, "", 0, "");
			}
		}

		/**
		 * java -> jni -> c# 的第一个函数
		 */
		private static int willPayFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jTicket)
		{
			CxxJavaObject l = findCxxJavaObject (jListener);

			if (null != (l as AndroidOnPayListener<PayOrder, AliPayApi>)) {
				AndroidOnPayListener<PayOrder, AliPayApi> p = (AndroidOnPayListener<PayOrder, AliPayApi>)l;
				AndroidPayOrder order = (AndroidPayOrder)findCxxJavaObject (jOrder);
				AndroidAliPayApi api = (AndroidAliPayApi)findCxxJavaObject (jApi);
				string ticket = AndroidJNI.GetStringUTFChars (jTicket);
				return p.onWillPay (order, api, ticket) ? 1 : 0;
			} else if (null != (l as AndroidOnPayListener<PayOrder, WxPayApi>)) {
				AndroidOnPayListener<PayOrder, WxPayApi> p = (AndroidOnPayListener<PayOrder, WxPayApi>)l;
				AndroidPayOrder order = (AndroidPayOrder)findCxxJavaObject (jOrder);
				AndroidWxPayApi api = (AndroidWxPayApi)findCxxJavaObject (jApi);
				string ticket = AndroidJNI.GetStringUTFChars (jTicket);
				return p.onWillPay (order, api, ticket) ? 1 : 0;
			} else if (null != (l as AndroidOnPayListener<TicketOrder, AliPayApi>)) {
				AndroidOnPayListener<TicketOrder, AliPayApi> p = (AndroidOnPayListener<TicketOrder, AliPayApi>)l;
				AndroidTicketOrder order = (AndroidTicketOrder)findCxxJavaObject (jOrder);
				AndroidAliPayApi api = (AndroidAliPayApi)findCxxJavaObject (jApi);
				string ticket = AndroidJNI.GetStringUTFChars (jTicket);
				return p.onWillPay (order, api, ticket) ? 1 : 0;
			} else if (null != (l as AndroidOnPayListener<TicketOrder, WxPayApi>)) {
				AndroidOnPayListener<TicketOrder, WxPayApi> p = (AndroidOnPayListener<TicketOrder, WxPayApi>)l;
				AndroidTicketOrder order = (AndroidTicketOrder)findCxxJavaObject (jOrder);
				AndroidWxPayApi api = (AndroidWxPayApi)findCxxJavaObject (jApi);
				string ticket = AndroidJNI.GetStringUTFChars (jTicket);
				return p.onWillPay (order, api, ticket) ? 1 : 0;
			} else {
				// 非法case
				return 0;
			}
		}

		private static void payEndFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, int jResult)
		{
			CxxJavaObject l = findCxxJavaObject (jListener);
			if (null != (l as AndroidOnPayListener<PayOrder, AliPayApi>)) {
				AndroidOnPayListener<PayOrder, AliPayApi> p = (AndroidOnPayListener<PayOrder, AliPayApi>)l;
				AndroidPayOrder order = (AndroidPayOrder)findCxxJavaObject (jOrder);
				AndroidAliPayApi api = (AndroidAliPayApi)findCxxJavaObject (jApi);
				p.onPayEnd (order, api, jResult);
			} else if (null != (l as AndroidOnPayListener<PayOrder, WxPayApi>)) {
				AndroidOnPayListener<PayOrder, WxPayApi> p = (AndroidOnPayListener<PayOrder, WxPayApi>)l;
				AndroidPayOrder order = (AndroidPayOrder)findCxxJavaObject (jOrder);
				AndroidWxPayApi api = (AndroidWxPayApi)findCxxJavaObject (jApi);
				p.onPayEnd (order, api, jResult);
			} else if (null != (l as AndroidOnPayListener<TicketOrder, AliPayApi>)) {
				AndroidOnPayListener<TicketOrder, AliPayApi> p = (AndroidOnPayListener<TicketOrder, AliPayApi>)l;
				AndroidTicketOrder order = (AndroidTicketOrder)findCxxJavaObject (jOrder);
				AndroidAliPayApi api = (AndroidAliPayApi)findCxxJavaObject (jApi);
				p.onPayEnd (order, api, jResult);
			} else if (null != (l as AndroidOnPayListener<TicketOrder, WxPayApi>)) {
				AndroidOnPayListener<TicketOrder, WxPayApi> p = (AndroidOnPayListener<TicketOrder, WxPayApi>)l;
				AndroidTicketOrder order = (AndroidTicketOrder)findCxxJavaObject (jOrder);
				AndroidWxPayApi api = (AndroidWxPayApi)findCxxJavaObject (jApi);
				p.onPayEnd (order, api, jResult);
			} else {
				// 非法case
			}
		}

	}
	#endif
}



