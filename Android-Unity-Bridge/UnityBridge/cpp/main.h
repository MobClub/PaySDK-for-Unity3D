//
// Created by litl on 2018/1/30.
//

#ifndef ANDROID_UNITY_BRIDGE_MAIN_H
#define ANDROID_UNITY_BRIDGE_MAIN_H



#ifdef __cplusplus
extern "C" {
#endif



int add(int a, int b);


typedef void (*LoopCallback)(void* pContext);


#ifdef __cplusplus
}
#endif


#endif //ANDROID_UNITY_BRIDGE_MAIN_H
