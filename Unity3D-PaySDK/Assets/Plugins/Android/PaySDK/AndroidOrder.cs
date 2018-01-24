using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{

	#if UNITY_ANDROID
	public class AndroidPayOrder : PayOrder {

		private CxxJavaObject javaCore = new CxxJavaObject();
		private IntPtr javaObjec;

		public AndroidPayOrder()
		{
			int t = AndroidJNI.PushLocalFrame (16);
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/PayOrder");
			javaCore.attachJavaObject (jret);

			IntPtr aa = t;
			AndroidJNI.PopLocalFrame (aa);
		}

		public override string getOrderNo()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getOrderNo", "()Ljava/lang/String;");
			IntPtr jret = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jret);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}

		public override void setOrderNo(string orderNo)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = javaCore.getLocalJavaObject(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setOrderNo", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.GetStringUTFChars (orderNo);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, jvalue);
			AndroidJNI.PopLocalFrame ();
		}

		public override int getAmount()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return 0;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getAmount", "()I");
			int ret = AndroidJNI.CallIntMethod(jthiz, jmethod);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}

		public override void setAmount(int amount)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setAmount", "(I)V");
			AndroidJNI.CallVoidMethod(jthiz, jmethod, amount);
			AndroidJNI.PopLocalFrame ();
		}

		public override string getSubject()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getSubject", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jvalue, NULL);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}

		public override void setSubject(string subject)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setSubject", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF (subject);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, jvalue);
			AndroidJNI.PopLocalFrame ();
		}

		public override string getBody()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getBody", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jvalue, NULL);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}

		public override void setBody(string body)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setBody", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(body);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, jvalue);
			AndroidJNI.PopLocalFrame ();
		}

		public override string getDescription()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getDescription", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jvalue, NULL);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}

		public override void setDescription(string description)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setDescription", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(description);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, jvalue);
			AndroidJNI.PopLocalFrame ();
		}

		public override string getMetadata()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getMetadata", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jvalue, NULL);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}

		public override void setMetadata(string metadata)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setMetadata", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(metadata);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, jvalue);
			AndroidJNI.PopLocalFrame ();
		}

		public override string getTicketId()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getTicketId", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jvalue, NULL);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}
	}

	public class AndroidTicketOrder : TicketOrder {

		private CxxJavaObject javaCore = new CxxJavaObject();

		public override void setTicketId(string tId)
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return;
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setTicketId", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(tId);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, jvalue);
			AndroidJNI.PopLocalFrame ();
		}

		public override string getTicketId()
		{
			AndroidJNI.PushLocalFrame (16);
			IntPtr jthiz = javaCore.getLocalJavaObject();
			if (NULL == jthiz) {
				return "";
			}
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getTicketId", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod);
			string ret = AndroidJNI.GetStringUTFChars(jvalue, NULL);
			AndroidJNI.PopLocalFrame ();
			return ret;
		}
	}
	#endif
}



