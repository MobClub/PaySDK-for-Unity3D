using System;
using System.Collections;
using UnityEngine;

namespace com.moblink.unity3d
{
	public class PayResult
	{
		private int payStatus;
		public PayResult()
		{
		}

		public void setPayStatus(int status) {
			payStatus = status;
		}

		public int getPayStatus() {
			return payStatus;
		}
	}		

}
