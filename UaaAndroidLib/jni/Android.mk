LOCAL_PATH:= $(call my-dir)

include $(CLEAR_VARS)

LOCAL_MODULE:= unity_android_asset
LOCAL_SRC_FILES:= UnityAndroidAsset.c
LOCAL_LDLIBS    := -landroid

LOCAL_EXPORT_C_INCLUDES := $(LOCAL_PATH)
#LOCAL_EXPORT_LDLIBS    := -llog -landroid

include $(BUILD_SHARED_LIBRARY)

#$(call import-module,android/native_app_glue)
#$(call import-module,android/cpufeatures)
