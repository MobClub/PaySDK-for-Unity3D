#include "com_mob_paysdk_unity_OnPayListener.h"
#include "jni.h"

JNIEXPORT jboolean JNICALL Java_com_mob_paysdk_unity_OnPayListener_nativeOnWillPay
  (JNIEnv *env, jobject jthiz, jstring jticket, jobject jOrder, jobject jApi, jlong callback)
{
    ComMobPaySDKUnityHookFunctionWillPay p = (ComMobPaySDKUnityHookFunctionWillPay)callback;
	return 0 != p(jthiz, jOrder, jApi, jticket);
}

JNIEXPORT void JNICALL Java_com_mob_paysdk_unity_OnPayListener_nativeOnPayEnd
  (JNIEnv *env, jobject jthiz, jobject jresult, jobject jOrder, jobject jApi, jlong  callback)
{
	ComMobPaySDKUnityHookFunctionPayEnd p = (ComMobPaySDKUnityHookFunctionPayEnd)callback;
	p(jthiz, jOrder, jApi, jresult);
}

