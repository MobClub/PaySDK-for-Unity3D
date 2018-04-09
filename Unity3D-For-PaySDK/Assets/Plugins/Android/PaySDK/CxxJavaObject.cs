using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class CxxJavaObject
	{
		private IntPtr javaObject;

		/**
             * 附加javaObject对象到this对象
             * @param lRef javaObject的引用
             */
		public void attachJavaObject(IntPtr lRef)
		{
			IntPtr gRef = AndroidJNI.NewGlobalRef (lRef);
			javaObject = gRef;
		}

		/**
             * 移除javaObject对象从this对象
             * @param lRef 与attachJavaObject保持一致, 并无含义
             */
		public void detachJavaObject(IntPtr lRef)
		{
			IntPtr gRef = (IntPtr)javaObject;
			if (0 != (long)gRef) {
				AndroidJNI.DeleteGlobalRef (gRef);
				javaObject = (IntPtr)0;
			}
		}

		/**
             * 获取附加到this对象上的javaObject的全局引用
             * @return javaObject的全局引用
             */
		public IntPtr getJavaObject()
		{
			IntPtr gRef = (IntPtr)javaObject;
			return gRef;
		}

		/**
             * 获取附加到this对象上的javaObject的本地引用
             * @return javaObject的本地引用
             */
		public IntPtr getLocalJavaObject()
		{
			IntPtr gRef = getJavaObject ();
			return AndroidJNI.NewLocalRef (gRef);
		}
		public static IntPtr newJavaInstance(string clazz) 
		{
			IntPtr jclazz = AndroidJNI.FindClass (clazz);
			IntPtr jConstructor = AndroidJNI.GetMethodID (jclazz, "<init>", "()V");
			IntPtr jret = AndroidJNI.NewObject (jclazz, jConstructor, new jvalue[0]);
			return jret;
		}
		public static IntPtr getJavaClass(IntPtr jo)
		{
			IntPtr jclazz = AndroidJNI.GetObjectClass (jo);
			return jclazz;
		}
		public static IntPtr getJavaMethodID(IntPtr jclazz, string jmethod, string jsign)
		{
			IntPtr jret = AndroidJNI.GetMethodID(jclazz, jmethod, jsign);
			return jret;
		}

		public static void callJavaStart()
		{
			// 这里防止未attach的线程, 调用产生错误, 比如C#的gc线程
			AndroidJNI.AttachCurrentThread ();
			AndroidJNI.PushLocalFrame (16);
		}

		public static void callJavaEnd()
		{
			AndroidJNI.PopLocalFrame ((IntPtr)0);
		}


		public static jvalue[] createJavaParam(params object[] jparams)
		{
			object[] temp = new object[jparams.Length];
			for (int i = 0; i < jparams.Length; i++) {
				temp [i] = jparams [i];
			}
			return AndroidJNIHelper.CreateJNIArgArray (temp);
		}

		public static jvalue[] createJavaParam(params IntPtr[] jparams)
		{
			jvalue[] jret = new jvalue[jparams.Length];
			for (int i = 0; i < jparams.Length; i++) {
				jret [i].l = jparams [i];
			}
			return jret;
		}

		~CxxJavaObject() {
			CxxJavaObject.callJavaStart ();
			detachJavaObject ((IntPtr)0);
			CxxJavaObject.callJavaEnd ();
		}

			
	}
	#endif
}



