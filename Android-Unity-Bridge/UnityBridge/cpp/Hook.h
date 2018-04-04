#ifndef ANDROID_UNITY_BRIDGE_HOOK_H
#define ANDROID_UNITY_BRIDGE_HOOK_H

#include "jni.h"

typedef int (* ComMobPaySDKUnityHookFunctionWillPay)(void* jListener, void* jOrder, void* jApi, void* jTicket);
typedef void (* ComMobPaySDKUnityHookFunctionPayEnd)(void* jListener, void* jOrder, void* jApi, int result);


#endif //ANDROID_UNITY_BRIDGE_HOOK_H
