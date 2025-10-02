namespace JeremyAnsel.DirectX.WinCodec;

public enum WicBitmapToneMappingMode : uint
{
    WICBitmapToneMappingMode_None = 0x00000000,

    WICBitmapToneMappingMode_Default = 0x00000001,

    WICBitmapToneMappingMode_D2D = 0x00000002,

    WICBitmapToneMappingMode_GainMap = 0x00000003,
}
