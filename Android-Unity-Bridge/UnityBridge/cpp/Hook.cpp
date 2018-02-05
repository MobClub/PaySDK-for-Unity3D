#include "Hook.h"
#include "stdio.h"
#include "jni.h"

static JavaVM* javaVM;
static ComMobPaySDKUnityHookFunctionWillPay sComMobPaySDKUnityHookFunctionWillPay = NULL;
static ComMobPaySDKUnityHookFunctionPayEnd sComMobPaySDKUnityHookFunctionPayEnd = NULL;


int ComMobPaySDKUnityHookSetWillPayFunction(ComMobPaySDKUnityHookFunctionWillPay hook)
{
    sComMobPaySDKUnityHookFunctionWillPay = hook;
    return 0;
}

ComMobPaySDKUnityHookFunctionWillPay ComMobPaySDKUnityHookGetWillPayFunction()
{
    return sComMobPaySDKUnityHookFunctionWillPay;
}

int ComMobPaySDKUnityHookSetPayEndFunction(ComMobPaySDKUnityHookFunctionPayEnd hook)
{
    sComMobPaySDKUnityHookFunctionPayEnd = hook;
    return 0;
}



ComMobPaySDKUnityHookFunctionPayEnd ComMobPaySDKUnityHookGetPayEndFunction()
{
    return sComMobPaySDKUnityHookFunctionPayEnd;
}

JNIEXPORT jint JNICALL JNI_OnLoad(JavaVM* vm, void* reserved)
{
    javaVM =  vm;
    return JNI_VERSION_1_4;
}


JNIEXPORT void* JNICALL JNI_INTERNAL_CALL_NewObject(void* out) {
    JNIEnv* env;
    javaVM->AttachCurrentThread(&env, NULL);
    jclass jclazz = env->FindClass("com/mob/paysdk/PayOrder");
    jmethodID jMethod = env->GetMethodID(jclazz, "<init>", "()V");
    jobject jobject = env->NewObject(jclazz, jMethod);


    *(int*)out = 2;
    return jobject;

}
int swap(int* i, int* j)
{
    *i = 2;
    *j = 3;
    return *i + *j;
}