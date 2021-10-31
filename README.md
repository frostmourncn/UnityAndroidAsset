If you are reading file in StreamingAssets on android platform, you can only use WebRequest api, but other platform you can use File or FileStream etc. This toolkit may help you read files in StreamingAssets synchronously or by stream.

The limitation doc link:
https://docs.unity3d.com/Manual/StreamingAssets.html

There is another solution, using zip file unpack:
https://github.com/gwiazdorrr/BetterStreamingAssets

But BetterStreamingAssets is not so capable when using in project by some reasons. This is a more simple way to achive by using AAssetManager of android NDK.

AAssetManager api reference:
https://developer.android.com/ndk/reference/group/asset

I encapsulation these api and make them easier to use in Unity.

One more thing, android java api of AssetManager is not capable, because random access stream in java will cause large amount of memory use.