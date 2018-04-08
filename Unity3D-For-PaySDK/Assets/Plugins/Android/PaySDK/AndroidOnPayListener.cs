using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID

	using ORDER_ALI = AndroidOnPayListener<AndroidPayOrder, AndroidAliPayApi>;
	using ORDER_WX = AndroidOnPayListener<AndroidPayOrder, AndroidWxPayApi>;
	using TICKET_ALI = AndroidOnPayListener<AndroidTicketOrder, AndroidAliPayApi>;
	using TICKET_WX = AndroidOnPayListener<AndroidTicketOrder, AndroidWxPayApi>;

	public class AndroidOnPayListener<O, API> : CxxJavaObject
	{
		public static AndroidOnPayListener<O, API> create()
		{
			return new AndroidOnPayListener<O, API>();
		}

		private O payOrder;
		public O PayOrder {
			get { return payOrder; }
			set { payOrder = value; }
		}

		private API payApi;
		public API PayApi {
			get { return payApi; }
			set { payApi = value; }
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

		protected bool onWillPay(string ticketId)
		{
			PaySDKHandler l = onPayListener;
			if (null != l) {
				return l.onWillPay (ticketId);
			}
			return false;
		}

		/**
		 * 下面定义委托, 用于java回调 
		 */
		private delegate int WillPayFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jTicket);
		private delegate void PayEndFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, int jResult);

		protected void onPayEnd(int payResult) {
			PaySDKHandler l = onPayListener;
			if (null != l) {
				l.onPayEnd ((PaySDKStatus)payResult, "", 0, "");
			}
		}

		/**
		 * java -> jni -> c# 的第一个函数
		 */
		private static int willPayFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jTicket)
		{
				
			object l = GCNativeKeeper.getInstance().find(jListener);
			string ticket = AndroidJNI.GetStringUTFChars (jTicket);
			if (null != (l as ORDER_ALI)) {
				ORDER_ALI p = (ORDER_ALI)l;
				return p.onWillPay (ticket) ? 1 : 0;
			} else if (null != (l as ORDER_WX)) {
				ORDER_WX p = (ORDER_WX)l;
				return p.onWillPay (ticket) ? 1 : 0;
			} else if (null != (l as TICKET_ALI)) {
				TICKET_ALI p = (TICKET_ALI)l;
				return p.onWillPay (ticket) ? 1 : 0;
			} else if (null != (l as TICKET_WX)) {
				TICKET_WX p = (TICKET_WX)l;
				return p.onWillPay (ticket) ? 1 : 0;
			}  else {
				// 非法case
				return 0;
			}
		}

		private static void payEndFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, int jResult)
		{
			object l = GCNativeKeeper.getInstance().unKeep(jListener);
			if (null != (l as ORDER_ALI)) {
				ORDER_ALI p = (ORDER_ALI)l;
				p.onPayEnd (jResult);
			} else if (null != (l as ORDER_WX)) {
				ORDER_WX p = (ORDER_WX)l;
				p.onPayEnd (jResult);
			} else if (null != (l as TICKET_ALI)) {
				TICKET_ALI p = (TICKET_ALI)l;
				p.onPayEnd (jResult);
			} else if (null != (l as TICKET_WX)) {
				TICKET_WX p = (TICKET_WX)l;
				p.onPayEnd (jResult);
			}  else {
				// 非法case
			}
		}

	}

	#endif
}



