using UnityEngine;
using System;
using System.Collections;

namespace cn.paysdk.unity
{
	public abstract class OnPayListener<O, API> {

		public static OnPayListener<O, API> create()
		{
			return new AndroidOnPayListener<O, API>();
		}


		public abstract bool onWillPay(string ticketId, O order, API api);
		public abstract void onPayEnd(int payResult, O order, API api);
	}
}


