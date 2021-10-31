using System;
using System.Collections;
using System.Collections.Generic;
using UnityAndroidAsset;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text result;
    private AssetStream _stream;
    private const string TEST_FILE = "test_file.txt";

    void Start()
    {
    }

    public void OnButtonLoadFile()
    {
        byte[] data = FileUtil.LoadAndroidAsset(TEST_FILE);
        result.text = System.Text.Encoding.ASCII.GetString(data);
    }

    public void OnButtonStreamLoadFile()
    {
        AssetStream stream = new AssetStream(TEST_FILE);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        result.text = System.Text.Encoding.ASCII.GetString(data);
    }

    public void OnButtonStreamRead1()
    {
        if (_stream == null)
            _stream = new AssetStream(TEST_FILE);
        char data = (char)_stream.ReadByte();
        result.text += data;
    }

    public void OnButtonStreamRead5()
    {
        if (_stream == null)
            _stream = new AssetStream(TEST_FILE);
        byte[] data = new byte[5];
        _stream.Read(data, 0, data.Length);
        result.text += System.Text.Encoding.ASCII.GetString(data);
    }

    public void OnButtonStreamReset()
    {
        result.text = "";
        _stream.Seek(0, System.IO.SeekOrigin.Begin);
    }
}
