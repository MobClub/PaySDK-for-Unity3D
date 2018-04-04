package com.mob.paysdk.unity;

import com.mob.paysdk.MobPayAPI;
import com.mob.paysdk.PayResult;

/**
 * OnPayListener for Unity3d.<br/>
 */
public class OnPayListener<T> extends Object implements com.mob.paysdk.OnPayListener<T> {

	private long willPayMethod;
	private long payEndMethod;

	static {
		System.loadLibrary("paysdk_bridge");
	}

	/**
	 * 构造函数
	 * @param wm 成功回调函数.
	 * @param em 失败回调函数.
	 */
	public OnPayListener(long wm, long em) {
		super();
		willPayMethod = wm;
		payEndMethod = em;
	}

	@Override
	public boolean onWillPay(String ticketId, T order, MobPayAPI api) {
		return nativeOnWillPay(ticketId, order, api, willPayMethod);
	}

	@Override
	public void onPayEnd(PayResult payResult, T order, MobPayAPI api) {
		nativeOnPayEnd(payResult.ordinal(), order, api, payEndMethod);
	}


	private native boolean nativeOnWillPay(String tId, T order, MobPayAPI api, long callback);
	private native void nativeOnPayEnd(int result, T order, MobPayAPI api, long callback);
}
