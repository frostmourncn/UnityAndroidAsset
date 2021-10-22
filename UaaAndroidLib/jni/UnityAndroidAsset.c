#include <jni.h>
#include <android/asset_manager.h>
#include <android/asset_manager_jni.h>
#include <stdlib.h>

static AAssetManager* _assetManager;

// link to java class, call init from unity
int Java_uaa_UnityAndroidAsset_nativeInit(JNIEnv * env, jclass clazz, jobject assetManager)
{
	_assetManager = AAssetManager_fromJava(env, assetManager);
	if (_assetManager)
		return 1;
	return 0;
}

// open an asset
AAsset* uaa_open(char* path, int mode)
{
	AAsset* asset = AAssetManager_open(_assetManager, path, mode);
	return asset;
}

// get asset length
int uaa_get_length(void* asset)
{
	return AAsset_getLength((AAsset*)asset);
}

// close an asset
void uaa_close(void* asset)
{
	AAsset_close((AAsset*)asset);
}

// read data to buffer
int uaa_read(void* asset, unsigned char* buf, int offset, int count)
{
	return AAsset_read((AAsset*)asset, buf + offset, count);
}

// jump stream pointer
long uaa_seek(void* asset, int offset, int where)
{
	return AAsset_seek((AAsset*)asset, offset, where);
}