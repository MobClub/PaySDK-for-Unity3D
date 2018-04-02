package com.mob.paysdk.unity;

import com.mob.paysdk.MobPayAPI;
import com.mob.paysdk.PayResult;
import com.unity3d.player.UnityPlayer;

/**
 * OnPayListener for Unity3d.<br/>
 */
public class OnPayListener<T> extends Object implements com.mob.paysdk.OnPayListener<T> {
	private String gameObjectName;
	private String callbackWillPayMethod;
	private String callbackPayEndMethod;

	static {
		System.loadLibrary("paysdk_bridge");
	}

	/**
	 * 构造函数
	 * @param goName Name of GameObject.
	 * @param willPayMethod 成功回调函数.
	 * @param payEndMethod 失败回调函数.
	 */
	public OnPayListener(String goName, String willPayMethod, String payEndMethod) {
		super();
		gameObjectName = goName;
		callbackWillPayMethod = willPayMethod;
		callbackPayEndMethod = payEndMethod;
	}

	/**
	 * 使用反射的方式调用UnityPlayer.UnitySendMessage函数.<br/>
	 * 此函数不该放置此处, 稍后处理
	 * @param goName gameObject.name
	 * @param method 函数
	 * @param params 参数
	 */
	protected static void UnitySendMessage(String goName, String method, String params) {
		UnityPlayer.UnitySendMessage(goName, method, params);
	}

	@Override
	public boolean onWillPay(String ticketId, T order, MobPayAPI api) {
		return nativeOnWillPay(ticketId, order);
//		UnitySendMessage(gameObjectName, callbackWillPayMethod, ticketId);
//		return false;
	}

	@Override
	public void onPayEnd(PayResult payResult, T order, MobPayAPI api) {
//		UnitySendMessage(gameObjectName, callbackPayEndMethod, String.valueOf(payResult.ordinal()));
		nativeOnPayEnd(payResult.ordinal(), "cccceddds");
	}


	private native boolean nativeOnWillPay(String tId, T index);
	private native void nativeOnPayEnd(int result, String index);
}
