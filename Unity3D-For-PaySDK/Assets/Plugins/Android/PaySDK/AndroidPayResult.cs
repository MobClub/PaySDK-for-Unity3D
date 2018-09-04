using System;
using UnityEngine;

namespace cn.paysdk.unity
{
	#if UNITY_ANDROID
	public class AndroidPayResult : CxxJavaObject
	{
		public AndroidPayResult (IntPtr jRef)
		{
			CxxJavaObject.callJavaStart ();
			attachJavaObject (jRef);
			CxxJavaObject.callJavaEnd ();
		}

		public int getPayCode()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getPayCode", "()I;");
			int jret = AndroidJNI.CallIntMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			CxxJavaObject.callJavaEnd ();
			return jret;
		}

		public String getPayMessage()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getPayMessage", "()Ljava/lang/String;");
			IntPtr jret = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jret);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public String getPayChannelCode()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getPayChannelCode", "()Ljava/lang/String;");
			IntPtr jret = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jret);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}

		public String getPayChannelMessage()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jthiz = getLocalJavaObject();
			IntPtr jclazz = CxxJavaObject.getJavaClass(jthiz);
			IntPtr jmethod = CxxJavaObject.getJavaMethodID (jclazz, "getPayChannelMessage", "()Ljava/lang/String;");
			IntPtr jret = AndroidJNI.CallObjectMethod(jthiz, jmethod, CxxJavaObject.createJavaParam((object)null));
			string ret = AndroidJNI.GetStringUTFChars(jret);
			CxxJavaObject.callJavaEnd ();
			return ret;
		}
	}
	#endif
}

