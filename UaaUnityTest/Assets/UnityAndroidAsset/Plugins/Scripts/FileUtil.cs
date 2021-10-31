#if UNITY_ANDROID
using System;

namespace UnityAndroidAsset
{
    /// <summary>
    /// for asset file load
    /// </summary>
    public class FileUtil
    {
        // load hole file
        public static byte[] LoadAndroidAsset(string path)
        {
            NativeLib.CheckLibInited();
            IntPtr asset = NativeLib.uaa_open(path, (int)NativeLib.AAssetMode.AASSET_MODE_STREAMING);
            if (asset.ToInt32() == 0)
                return null;
            int length = NativeLib.uaa_get_length(asset);
            byte[] data = new byte[length];
            NativeLib.uaa_read(asset, data, 0, length);
            NativeLib.uaa_close(asset);
            return data;
        }
    }
}
#endif