using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{
	public class PaySDK {

		public static T createMobPayAPI<T>()
		{
			return T::create ();	
		}
	}

	public interface OnPayListener<O, API> {

		bool onWillPay(string ticketId, O order, API api);
		void onPayEnd(PayResult payResult, O order, API api);
	}
}


