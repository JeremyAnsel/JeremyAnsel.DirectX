namespace JeremyAnsel.DirectX.WinCodec;

public enum WicBitmapChainType : uint
{
    None = 0,

    WICBitmapChainType_Alternate = 0x00000001,

    WICBitmapChainType_Layer = 0x00000002,

    WICBitmapChainType_Preview = 0x00000003,

    WICBitmapChainType_Thumbnail = 0x00000004,

    WICBitmapChainType_AlphaMap = 0x00000005,

    WICBitmapChainType_DepthMap = 0x00000006,

    WICBitmapChainType_GainMap = 0x00000007,
}
