/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class com_mob_paysdk_unity_OnPayListener */
#include "stdio.h"
#ifndef _Included_com_mob_paysdk_unity_OnPayListener
#define _Included_com_mob_paysdk_unity_OnPayListener
#ifdef __cplusplus
extern "C" {
#endif
/*
 * Class:     com_mob_paysdk_unity_OnPayListener
 * Method:    nativeOnWillPay
 * Signature: (Ljava/lang/String;Ljava/lang/String;)Z
 */
JNIEXPORT jboolean JNICALL Java_com_mob_paysdk_unity_OnPayListener_nativeOnWillPay
  (JNIEnv *, jobject, jstring, jobject);

/*
 * Class:     com_mob_paysdk_unity_OnPayListener
 * Method:    nativeOnPayEnd
 * Signature: (ILjava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_com_mob_paysdk_unity_OnPayListener_nativeOnPayEnd
  (JNIEnv *, jobject, jint, jstring);

#ifdef __cplusplus
}
#endif
#endif
