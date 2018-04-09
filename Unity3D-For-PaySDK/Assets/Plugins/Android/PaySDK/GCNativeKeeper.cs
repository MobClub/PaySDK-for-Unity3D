using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cn.paysdk.unity
{
	#if UNITY_ANDROID
	public class GCNativeKeeper
	{
		private static object locker = new object();
		private static GCNativeKeeper sInstance;

		private Hashtable coreMap = new Hashtable();

		private GCNativeKeeper () {
		}

		public static GCNativeKeeper getInstance() {
			if (null == sInstance) {
				lock (locker) {
					if (null == sInstance) {
						sInstance = new GCNativeKeeper ();
					}
				}
			}
			return sInstance;
		}

		public void keep(IntPtr gRef, object value) {
			lock (locker) {
				coreMap.Add (gRef, value);
			}
		}

		public object find(IntPtr lRef) {
			lock (locker) {
				IntPtr gRef = (IntPtr)0;
				foreach(DictionaryEntry de in coreMap) {
					IntPtr inRef = (IntPtr)de.Key;
					if (AndroidJNI.IsSameObject (inRef, lRef)) {
						gRef = inRef;
						break;
					}
				}

				object ret = null;
				if (0 != (int)gRef) {
					ret = coreMap [gRef];
				}
				return ret;
			}
		}

		public object unKeep(IntPtr lRef) {
			lock (locker) {
				IntPtr gRef = (IntPtr)0;
				foreach(DictionaryEntry de in coreMap) {
					IntPtr inRef = (IntPtr)de.Key;
					if (AndroidJNI.IsSameObject (inRef, lRef)) {
						gRef = inRef;
						break;
					}
				}

				object ret = null;
				if (0 != (int)gRef) {
					ret = coreMap [gRef];
					coreMap.Remove (gRef);
				}
				return ret;
			}
		}
	}
	#endif
}

