using System.Collections;

namespace cn.paysdk.unity
{
	public interface PaySDKHandler 
	{
		 bool onWillPay (string ticketId);
		 void onPayEnd (PaySDKStatus status, string ticketId, long errorCode, string errorDes);
	}
}
