To read streaming Assets on platforms like Android and WebGL
, where you cannot access streaming Asset files directly, use UnityWebRequest.

To avoid this limitation, we can use AAssetManager of Android NDK to access Assets files.  
AssetManager of Android java api is not capable, because random access stream will use a large amount of memory.  
Another feature is AAssetManager can streaming read Assets files.

Codes function:  
AssestStream: Cross-platform streaming access of StreamingAssets file
FileUtil: Cross-platform directly load StreamingAssets file

Test Enviroment:  
Unity 2019.4  
NDK R19


Unity's limitation doc link:
https://docs.unity3d.com/Manual/StreamingAssets.html

AAssetManager api reference:
https://developer.android.com/ndk/reference/group/asset
