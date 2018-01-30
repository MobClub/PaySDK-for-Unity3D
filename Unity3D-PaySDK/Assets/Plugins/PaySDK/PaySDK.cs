using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{
	public class PaySDK : MonoBehaviour {

		public static API createMobPayAPI<API> () where API : MobPayApi
		{
			return (API)typeof(API).GetMethod("create").Invoke(typeof(API), null);
		}

		#if UNITY_ANDROID
		private void _AndroidOnWillPay(string param)
		{
			Debug.Log ("_AndroidOnWillPay" + param);
			JavaCallback.onWillPay (param);
		}

		private void _AndroidOnPayEnd(string param)
		{
			Debug.Log ("_AndroidOnPayEnd" + param);
			JavaCallback.onPayEnd (param);
		}
		#elif UNITY_IPHONE
		// handel ios
		#endif
	}

	public interface OnPayListener<O, API> {

		bool onWillPay(string ticketId, O order, API api);
		void onPayEnd(PayResult payResult, O order, API api);
	}
}


