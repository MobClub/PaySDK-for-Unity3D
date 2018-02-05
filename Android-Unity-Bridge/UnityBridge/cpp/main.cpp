

#include <android/log.h>

#include "main.h"

#define  LOG_TAG    "main"
#define  LOGD(...)  __android_log_print(ANDROID_LOG_DEBUG,LOG_TAG,__VA_ARGS__)

int add(int a, int b)
{
    LOGD("add(), a:%d, b:%d", a , b);
    return  a + b;
}
