using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityAndroidAsset
{
    /// <summary>
    /// asset stream
    /// </summary>
#if UNITY_ANDROID
    public class AssetStream : Stream
    {
        public override bool CanRead { get { return true; } }
        public override bool CanSeek { get { return true; } }
        public override long Length { get { return _length; } }

        // cannot write
        public override bool CanWrite { get { return false; } }

        public override long Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private long _length;
        private long _position;
        private IntPtr _nativeAsset;
        private bool _isStreamEnabled;
        private byte[] _readByteBuffer;

        public AssetStream(string path)
        {
            NativeLib.CheckLibInited();
            _nativeAsset = NativeLib.uaa_open(path, (int)NativeLib.AAssetMode.AASSET_MODE_STREAMING);
            _isStreamEnabled = (_nativeAsset.ToInt32() != 0);
            if (_isStreamEnabled)
                _length = NativeLib.uaa_get_length(_nativeAsset);
        }

        public override void Close()
        {
            if (_isStreamEnabled)
                NativeLib.uaa_close(_nativeAsset);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (!_isStreamEnabled)
                return 0;
            int readed = NativeLib.uaa_read(_nativeAsset, buffer, offset, count);
            _position += readed;
            return readed;
        }

        public override int ReadByte()
        {
            if (!_isStreamEnabled)
                return 0;
            if (_readByteBuffer == null)
                _readByteBuffer = new byte[1];
            int readed = Read(_readByteBuffer, 0, 1);
            _position += readed;
            return _readByteBuffer[0];
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (!_isStreamEnabled)
                return 0;
            _position = NativeLib.uaa_seek(_nativeAsset, (int)offset, (int)origin);
            return _position;
        }

    #region unimplemented methods
        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new System.NotImplementedException();
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            throw new System.NotImplementedException();
        }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            throw new System.NotImplementedException();
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    #endregion
    }
#else

    public class AssetStream : FileStream
    {
        public AssetStream(string path) : base(Path.Combine(Application.streamingAssetsPath, path), FileMode.Open)
        {
            
        }
    }
#endif
}