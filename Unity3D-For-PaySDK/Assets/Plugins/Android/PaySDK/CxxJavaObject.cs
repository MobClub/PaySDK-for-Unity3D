using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{

	#if UNITY_ANDROID
	public class CxxJavaObject
	{
		private static Hashtable cxxJavaMap = new Hashtable();

		/**
             * 附加javaObject对象到this对象
             * @param lRef javaObject的引用
             */
		public void attachJavaObject(IntPtr lRef)
		{
			IntPtr gRef = AndroidJNI.NewGlobalRef (lRef);
			cxxJavaMap.Add (this, gRef);
		}

		/**
             * 移除javaObject对象从this对象
             * @param lRef 与attachJavaObject保持一致, 并无含义
             */
		public void detachJavaObject(IntPtr lRef)
		{
			IntPtr gRef = (IntPtr)cxxJavaMap [this];
			cxxJavaMap.Remove (this);
			AndroidJNI.DeleteGlobalRef (gRef);
		}

		/**
             * 获取附加到this对象上的javaObject的全局引用
             * @return javaObject的全局引用
             */
		public IntPtr getJavaObject()
		{
			IntPtr gRef = (IntPtr)cxxJavaMap [this];
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
			AndroidJNI.AttachCurrentThread ();
			AndroidJNI.PushLocalFrame (16);
		}

		public static void callJavaEnd()
		{
			IntPtr p = new IntPtr();
			AndroidJNI.PopLocalFrame (p);
			// TODO why do not detach
			// AndroidJNI.DetachCurrentThread ();
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




			
	}
	#endif
}



