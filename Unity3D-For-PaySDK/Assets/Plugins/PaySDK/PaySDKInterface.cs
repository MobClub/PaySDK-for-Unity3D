using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cn.paysdk.unity
{
	public abstract class PaySDKInterface {

		public abstract void payWithOrder (PaySDKOrder order, PaySDKChannel channel);

		public abstract void payWithTicketId (string ticketId, PaySDKChannel channel);

		#if UNITY_IOS
		public abstract string getVersion ();

		public abstract void setDebugMode (bool enabled);
		#endif
	}
}