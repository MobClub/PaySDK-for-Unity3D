using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class AndroidOnPayListener : CxxJavaObject
	{
		public static AndroidOnPayListener create(AndroidPayApi api, AndroidOrder order, PaySDKHandler handler)
		{
			AndroidOnPayListener l = new AndroidOnPayListener();
			l.PayOrder = order;
			l.PayApi = api;
			l.OnPayListener = handler;
			return l;
		}

		private AndroidOrder payOrder;
		public AndroidOrder PayOrder {
			get { return payOrder; }
			set { payOrder = value; }
		}

		private AndroidPayApi payApi;
		public AndroidPayApi PayApi {
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

		/**
		 * 下面定义委托, 用于java回调 
		 */
		private delegate int WillPayFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jTicket);
		private delegate void PayEndFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jResult);

		protected bool onWillPay(string ticketId)
		{
			PaySDKHandler l = onPayListener;
			if (null != l) {
				return l.onWillPay (ticketId);
			}
			return false;
		}

		protected void onPayEnd(PaySDKStatus status, string ticketId, int channelErrorCode, string channelErrorDes) {
			PaySDKHandler l = onPayListener;
			if (null != l) {
				l.onPayEnd (status, ticketId, channelErrorCode, channelErrorDes);
			}
		}

		/**
		 * java -> jni -> c# 的第一个函数
		 */
		private static int willPayFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jTicket)
		{
			object l = GCNativeKeeper.getInstance().find(jListener);
			AndroidOnPayListener callback = (AndroidOnPayListener)l;
			string ticket = AndroidJNI.GetStringUTFChars (jTicket);
			return callback.onWillPay (ticket) ? 1 : 0;
		}

		private static void payEndFunction(IntPtr jListener, IntPtr jOrder, IntPtr jApi, IntPtr jResult)
		{
			object l = GCNativeKeeper.getInstance().unKeep(jListener);
			AndroidOnPayListener callback = (AndroidOnPayListener)l;
			AndroidPayResult result = new AndroidPayResult (jResult);
			AndroidOrder order = callback.PayOrder;
			AndroidPayApi api = callback.PayApi;
			PaySDKStatus status = toPayStatus(result.getPayCode ());
			string ticketId = order.getTicketId ();
			int channelErrorCode = toInt(result.getPayChannelCode ());
			string channelErrorDes = result.getPayChannelMessage ();
			callback.onPayEnd (status, ticketId, channelErrorCode, channelErrorDes);
		}

		private static PaySDKStatus toPayStatus(int status)
		{
			if (0000 == status) {
				return PaySDKStatus.PaySDKStatusSuccess;
			} else if (1200 == status) {
				return PaySDKStatus.PaySDKStatusCancel;
			} else if (1300 == status) {
				return PaySDKStatus.MPSPayStatusUnknown;
			} else {
				return PaySDKStatus.PaySDKStatusFail;
			}
		}

		private static int toInt(string value)
		{
			int ret;
			int.TryParse (value, out ret);
			return ret;
		}
	}
	#endif
}



