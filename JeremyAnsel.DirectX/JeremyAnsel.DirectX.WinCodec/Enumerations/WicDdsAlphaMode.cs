namespace JeremyAnsel.DirectX.WinCodec;

public enum WicDdsAlphaMode : uint
{
    WICDdsAlphaModeUnknown = 0x00000000,

    WICDdsAlphaModeStraight = 0x00000001,

    WICDdsAlphaModePremultiplied = 0x00000002,

    WICDdsAlphaModeOpaque = 0x00000003,

    WICDdsAlphaModeCustom = 0x00000004,
}
