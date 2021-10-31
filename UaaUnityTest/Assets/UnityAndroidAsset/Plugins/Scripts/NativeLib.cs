using System;
using System.Runtime.InteropServices;
using UnityEngine;

#if UNITY_ANDROID
namespace UnityAndroidAsset
{
    /// <summary>
    /// internal lib, link to native code
    /// </summary>
    class NativeLib
    {
        // android asset mode enum from ndk
        public enum AAssetMode{
            /** No specific information about how data will be accessed. **/
            AASSET_MODE_UNKNOWN = 0,
            /** Read chunks, and seek forward and backward. */
            AASSET_MODE_RANDOM = 1,
            /** Read sequentially, with an occasional forward seek. */
            AASSET_MODE_STREAMING = 2,
            /** Caller plans to ask for a read-only buffer with all data. */
            AASSET_MODE_BUFFER = 3
        };

        // open an asset
        [DllImport("unity_android_asset")]
        public static extern IntPtr uaa_open(string path, int mode);

        // close an asset
        [DllImport("unity_android_asset")]
        public static extern void uaa_close(IntPtr asset);

        // get asset length
        [DllImport("unity_android_asset")]
        public static extern int uaa_get_length(IntPtr asset);

        // jump stream pointer
        [DllImport("unity_android_asset")]
        public static extern long uaa_seek(IntPtr asset, int offset, int where);

        // read data to buffer
        [DllImport("unity_android_asset")]
        public static extern int uaa_read(IntPtr asset, byte[] buf, int offset, int count);

        private static bool isNativeInit;

        // init native AAssetManager
        public static void CheckLibInited()
        {
            if (!isNativeInit)
            {
                Debug.Log("init uaa native lib...");
                AndroidJavaClass androidJavaClass = new AndroidJavaClass("uaa.UnityAndroidAsset");
                AndroidJavaObject unityPlayerContext = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject androidAssetManager = unityPlayerContext.Call<AndroidJavaObject>("getAssets");
                int result = androidJavaClass.CallStatic<int>("nativeInit", androidAssetManager);
                Debug.Log("init uaa native lib result = " + result);
                isNativeInit = true;
            }
        }
    }
}
#endif
