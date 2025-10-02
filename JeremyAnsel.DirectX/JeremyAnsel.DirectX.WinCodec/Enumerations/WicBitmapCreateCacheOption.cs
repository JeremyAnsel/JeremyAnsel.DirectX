namespace JeremyAnsel.DirectX.WinCodec;

public enum WicBitmapCreateCacheOption : uint
{
    WICBitmapNoCache = 0x00000000,

    WICBitmapCacheOnDemand = 0x00000001,

    WICBitmapCacheOnLoad = 0x00000002,
}
