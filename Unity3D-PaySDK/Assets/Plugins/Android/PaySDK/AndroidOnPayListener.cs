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

		public AndroidOnPayListener()
		{
			CxxJavaObject.callJavaStart ();
			IntPtr jclazz = AndroidJNI.FindClass ("com/mob/paysdk/unity/OnPayListener");
			IntPtr jConstructor = AndroidJNI.GetMethodID (jclazz, "<init>", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr jret = AndroidJNI.NewObject (jclazz, jConstructor, CxxJavaObject.createJavaParam ("MobLink", "_AndroidOnWillPay", "_AndroidOnPayEnd"));
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


		//public static bool onWillPay(pa
	}
	#endif
}



