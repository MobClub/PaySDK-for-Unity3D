using System;

namespace cn.paysdk.unity
{
	public class PaySDKOrder {

		//订单号 必要
		public string orderId;

		//价格 单位（分）必要
		public Int64 amount;

		//标题 必要
		public string subject;

		//用户id 可选
		public string userId;

		//用户昵称 可选
		public string nickName;

		//交易描述 可选
		public string body;

		//订单附加说明 可选
		public string des;

		//元数据：JSON格式的字符串，每一个对象的 metadata 最多可以拥有 10 个键值对，数据总长度在 1000 个 Unicode 字符以内  可选
		public string metadata;
	}
}

