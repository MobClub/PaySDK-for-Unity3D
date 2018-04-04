LOCAL_PATH := $(call my-dir)
include $(CLEAR_VARS)

LOCAL_MODULE := paysdk_bridge

ifeq ($(USE_ARM_MODE),1)
LOCAL_ARM_MODE := arm
endif

LOCAL_SRC_FILES := 	../cpp/com_mob_paysdk_unity_OnPayListener.cpp


LOCAL_C_INCLUDES := $(LOCAL_PATH)/../cpp \

					
LOCAL_EXPORT_C_INCLUDES := $(LOCAL_PATH)/../cpp \


LOCAL_LDLIBS := -llog -lm
					

include $(BUILD_SHARED_LIBRARY)

