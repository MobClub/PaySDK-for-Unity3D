using UnityEngine;
using System;
using System.Collections;

namespace com.moblink.unity3d
{
	public abstract class PayOrder {

		public static PayOrder create()
		{
			#if UNITY_ANDROID
			return new AndroidPayOrder();
			#elif UNITY_IPHONE
			// TODO handle ios
			#endif
		}

		/**
         * 获取之前配置的支付订单号
         * @return 订单号
         */
		public abstract string getOrderNo();

		/**
         * 设置支付订单号
         * @param orderNo 订单号
         */
		public abstract void setOrderNo(string orderNo);

		/**
             * 获取之前配置的支付金额, 单位：分.
             * @return 支付金额
             */
		public abstract int getAmount();

		/**
         * 设置支付金额, 单位：分.
         * @param amount 支付金额
         */
		public abstract void setAmount(int amount);

		/**
         * 获取之前配置的支付标题, 支付时展示
         * @return 支付标题
         */
		public abstract string getSubject();

		/**
         * 设置支付标题, 支付时展示
         * @param subject 支付标题
         */
		public abstract void setSubject(string subject);

		/**
         * 获取之前配置的支付主体, 支付时展示
         * @return 支付主体
         */
		public abstract string getBody();

		/**
         * 设置支付主体, 支付时展示
         * @return 支付主体
         */
		public abstract void setBody(string body);

		public abstract string getDescription();

		public abstract void setDescription(string description);

		public abstract string getMetadata();

		public abstract void setMetadata(string metadata);

		/**
         * 获取ticketId
         * @return ticketId
         */
		public abstract string getTicketId();
	}

	public abstract class TicketOrder {

		public static TicketOrder create()
		{
			#if UNITY_ANDROID
			return new AndroidTicketOrder();
			#elif UNITY_IPHONE
			// TODO handle ios
			#endif
		}

		/**
         * 设置ticketId
         * @param tId ticketId
         */
		public abstract void setTicketId(string tId);

		/**
         * 获取ticketId
         * @return ticketId
         */
		public abstract string getTicketId();
	}

}


