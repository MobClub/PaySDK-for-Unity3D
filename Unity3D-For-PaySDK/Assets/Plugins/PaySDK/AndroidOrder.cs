using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class AndroidOrder : CxxJavaObject {
		public AndroidOrder()
		{
		}

		public string getTicketId()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getTicketId", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}
	}

	public class AndroidPayOrder : AndroidOrder {

		public AndroidPayOrder()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/PayOrder");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public string getOrderNo()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getOrderNo", "()Ljava/lang/String;");
			IntPtr jret = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jret);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public void setOrderNo(string orderNo)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setOrderNo", "(Ljava/lang/String;)V");
			AndroidJNI.CallVoidMethod (jthiz, jmethod, CxxJavaObject.createJavaParam (orderNo));
			CxxJavaObject.callJavaEnd ();
		}

		public int getAmount()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getAmount", "()I");
			int ret = AndroidJNI.CallIntMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public void setAmount(int amount)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setAmount", "(I)V");
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(amount));
			CxxJavaObject.callJavaEnd ();
		}

		public string getSubject()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getSubject", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public void setSubject(string subject)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setSubject", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF (subject);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public string getBody()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getBody", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public string getBody(IntPtr lRef)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = lRef;
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getBody", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public void setBody(string body)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setBody", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(body);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public void setBody(string body, IntPtr lRef)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = lRef;
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setBody", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(body);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public string getDescription()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getDescription", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public void setDescription(string description)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setDescription", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(description);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		public string getMetadata()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "getMetadata", "()Ljava/lang/String;");
			IntPtr jvalue = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jvalue);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public void setMetadata(string metadata)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setMetadata", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(metadata);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		~AndroidPayOrder()
		{
		}
	}

	public class AndroidTicketOrder : AndroidOrder {

		public AndroidTicketOrder()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jret = CxxJavaObject.newJavaInstance("com/mob/paysdk/TicketOrder");
			attachJavaObject (jret);
			CxxJavaObject.callJavaEnd ();
		}

		public void setTicketId(string tId)
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID(jclazz, "setTicketId", "(Ljava/lang/String;)V");
			IntPtr jvalue = AndroidJNI.NewStringUTF(tId);
			AndroidJNI.CallVoidMethod(jthiz, jmethod, CxxJavaObject.createJavaParam(jvalue));
			CxxJavaObject.callJavaEnd ();
		}

		~AndroidTicketOrder()
		{
		}

	}
	#endif
}



