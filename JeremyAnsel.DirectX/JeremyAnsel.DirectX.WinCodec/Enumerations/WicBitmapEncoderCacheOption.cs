namespace JeremyAnsel.DirectX.WinCodec;

public enum WicBitmapEncoderCacheOption : uint
{
    WICBitmapEncoderCacheInMemory = 0x00000000,

    WICBitmapEncoderCacheTempFile = 0x00000001,

    WICBitmapEncoderNoCache = 0x00000002,
}
