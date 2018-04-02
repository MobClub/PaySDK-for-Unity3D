#ifndef ANDROID_UNITY_BRIDGE_HOOK_H
#define ANDROID_UNITY_BRIDGE_HOOK_H

#include "jni.h"
#ifdef __cplusplus
extern "C" {
#endif

typedef int (* ComMobPaySDKUnityHookFunctionWillPay)(int, void *);
typedef int (* ComMobPaySDKUnityHookFunctionPayEnd)(void* index);

int ComMobPaySDKUnityHookSetWillPayFunction(ComMobPaySDKUnityHookFunctionWillPay hook);
ComMobPaySDKUnityHookFunctionWillPay ComMobPaySDKUnityHookGetWillPayFunction();

int ComMobPaySDKUnityHookSetPayEndFunction(ComMobPaySDKUnityHookFunctionPayEnd hook);
ComMobPaySDKUnityHookFunctionPayEnd ComMobPaySDKUnityHookGetPayEndFunction();

JNIEXPORT void* JNICALL JNI_INTERNAL_CALL_NewObject(void*);

int swap(int i, int j);

#ifdef __cplusplus
}
#endif


#endif //ANDROID_UNITY_BRIDGE_HOOK_H
