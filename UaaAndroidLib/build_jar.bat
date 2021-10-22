cd uaa
javac UnityAndroidAsset.java
jar -cvf UnityAndroidAsset.jar UnityAndroidAsset.class
move UnityAndroidAsset.jar ../UnityAndroidAsset.jar
del UnityAndroidAsset.class
pause