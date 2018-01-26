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
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/PayOrder");
			javaCore.attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public override string getOrderNo()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getOrderNo", "()Ljava/lang/String;");
			IntPtr jret = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jret);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public override void setOrderNo(string orderNo)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setOrderNo", "(Ljava/lang/String;)V");
			// IntPtr jvalue = AndroidJNI.NewStringUTF (orderNo);
			AndroidJNI.CallVoidMethod (jthiz, jmethod, CxxJavaObject.createJavaParam (orderNo));
			CxxJavaObject.callJavaEnd ();
		}

		public override int getAmount()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getAmount", "()I");
			int ret = AndroidJNI.CallIntMethod(jthiz, jmethod, null);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public override void setAmount(int amount)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setAmount", "(I)V");
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(amount));
			CxxJavaObject.callJavaEnd ();
		}

		public override string getSubject()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getSubject", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public override void setSubject(string subject)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setSubject", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF (subject);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public override string getBody()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getBody", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public override void setBody(string body)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setBody", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(body);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public override string getDescription()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getDescription", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public override void setDescription(string description)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setDescription", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(description);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public override string getMetadata()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getMetadata", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public override void setMetadata(string metadata)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setMetadata", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(metadata);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public override string getTicketId()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getTicketId", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public IntPtr getLocalJavaObject()
		{
			return javaCore.getLocalJavaObject ();
		}

		~AndroidPayOrder()
		{
			IntPtr temp = new IntPtr();
			CxxJavaObject.callJavaStart ();
			javaCore.detachJavaObject (temp);
			CxxJavaObject.callJavaEnd ();
		}
	}

	public class AndroidTicketOrder : TicketOrder {

		private CxxJavaObject javaCore = new CxxJavaObject();

		public AndroidTicketOrder()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/TicketOrder");
			javaCore.attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public override void setTicketId(string tId)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setTicketId", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(tId);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public override string getTicketId()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = javaCore.getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getTicketId", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, null);
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public IntPtr getLocalJavaObject()
		{
			return javaCore.getLocalJavaObject ();
		}

		~AndroidTicketOrder()
		{
			IntPtr temp = new IntPtr();
			CxxJavaObject.callJavaStart ();
			javaCore.detachJavaObject (temp);
			CxxJavaObject.callJavaEnd ();
		}

	}
	#endif
}



