#include "com_mob_paysdk_unity_OnPayListener.h"
#include "Hook.h"
#include "malloc.h"
#include "jni.h"
/*
 * Class:     com_mob_paysdk_unity_OnPayListener
 * Method:    nativeOnWillPay
 * Signature: (Ljava/lang/String;Ljava/lang/String;)Z
 */
JNIEXPORT jboolean JNICALL Java_com_mob_paysdk_unity_OnPayListener_nativeOnWillPay
  (JNIEnv *env, jobject jthiz, jstring jticket, jobject jindex)
{
    int intp = 100;
    ComMobPaySDKUnityHookFunctionWillPay p = ComMobPaySDKUnityHookGetWillPayFunction();
    if (NULL != p) {
        p(intp, jindex);
    }
}

/*
 * Class:     com_mob_paysdk_unity_OnPayListener
 * Method:    nativeOnPayEnd
 * Signature: (ILjava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_com_mob_paysdk_unity_OnPayListener_nativeOnPayEnd
  (JNIEnv *env, jobject jthiz, jint jresult, jstring jindex)
{

}

