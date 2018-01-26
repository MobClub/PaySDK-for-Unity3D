using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{
	public class PaySDK {

		public static API createMobPayAPI<API> () where API : MobPayApi
		{
			return (API)typeof(API).GetMethod("create").Invoke(typeof(API), null);
			//return API.create ();	
		}
	}

	public interface OnPayListener<O, API> {

		bool onWillPay(string ticketId, O order, API api);
		void onPayEnd(PayResult payResult, O order, API api);
	}
}


