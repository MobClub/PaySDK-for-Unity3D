using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{

	#if UNITY_ANDROID
	public class CxxJavaObject
	{
		private IntPtr javaObjec;

		// public static IntPtr 



		/**
             * 附加javaObject对象到this对象
             * @param lRef javaObject的引用
             */
		public void attachJavaObject(IntPtr lRef)
		{
			
		}

		/**
             * 移除javaObject对象从this对象
             * @param lRef 与attachJavaObject保持一致, 并无含义
             */
		public void detachJavaObject(IntPtr lRef)
		{
		}

		/**
             * 获取附加到this对象上的javaObject的全局引用
             * @return javaObject的全局引用
             */
		public IntPtr getJavaObject()
		{
		}

		/**
             * 获取附加到this对象上的javaObject的本地引用
             * @return javaObject的本地引用
             */
		public IntPtr getLocalJavaObject()
		{
			
		}
		public static IntPtr newJavaInstance(string clazz) 
		{
			IntPtr jclazz = AndroidJNI.FindClass (clazz);
			IntPtr jConstructor = AndroidJNI.GetMethodID (jclazz, "<init>", "()V");
			IntPtr jret = AndroidJNI.NewObject (jclazz, jConstructor);
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
	}
	#endif
}



