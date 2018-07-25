using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace cn.paysdk.unity
{
	public class iOSPaySDKImpl : PaySDKInterface
	{

		[DllImport("__Internal")]
		private static extern void __iosPaySDKPayWithOrder (string order, int channel, string observer);
		[DllImport("__Internal")]
		private static extern void __iosPaySDKPayWithTicketId (string ticketId, string observer);
		[DllImport("__Internal")]
		private static extern string __iosPaySDKGetVersion ();
		[DllImport("__Internal")]
		private static extern void __iosPaySDKSetDebugMode (bool enable);

		private string _callbackObjectName = "Main Camera";

		public iOSPaySDKImpl (GameObject go) 
		{
			try{
				_callbackObjectName = go.name;
			} catch(Exception e) {
				Console.WriteLine("{0} Exception caught.", e);
			}
		}

		public override void payWithOrder (PaySDKOrder order, PaySDKChannel channel)
		{
			Hashtable orderHash = new Hashtable ();

			orderHash.Add ("orderId", order.orderId);
			orderHash.Add ("amount", order.amount);
			orderHash.Add ("subject", order.subject);
			orderHash.Add ("appUserId", order.userId);
			orderHash.Add ("appUserNickname", order.nickName);
			orderHash.Add ("body", order.body);
			orderHash.Add ("desc", order.des);
			orderHash.Add ("metadata", order.metadata);

			string orderJson = MiniJSON.jsonEncode (orderHash);

			__iosPaySDKPayWithOrder (orderJson, (int)channel, _callbackObjectName);
		}

		public override void payWithTicketId (string ticketId, PaySDKChannel channel)
		{
			__iosPaySDKPayWithTicketId (ticketId, _callbackObjectName);
		}

		public override string getVersion ()
		{
			return __iosPaySDKGetVersion ();
		}

		public override void setDebugMode (bool enabled)
		{
			__iosPaySDKSetDebugMode (enabled);
		}
	}
}

