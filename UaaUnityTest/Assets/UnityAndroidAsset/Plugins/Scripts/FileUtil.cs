using System;
using System.IO;
using UnityEngine;

namespace UnityAndroidAsset
{
    /// <summary>
    /// for asset file load
    /// </summary>
    public class FileUtil
    {
        // load hole file
#if UNITY_ANDROID
        public static byte[] LoadStreamingAsset(string path)
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
#else
        public static byte[] LoadStreamingAsset(string path)
        {
            path = Path.Combine(Application.streamingAssetsPath, path);
            if (!File.Exists(path))
                return null;
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            return data;
        }
#endif
    }
}