namespace JeremyAnsel.DirectX.WinCodec;

public enum WicHeifHdrProperties : uint
{
    None = 0,

    WICHeifHdrMaximumLuminanceLevel = 0x00000001,

    WICHeifHdrMaximumFrameAverageLuminanceLevel = 0x00000002,

    WICHeifHdrMinimumMasteringDisplayLuminanceLevel = 0x00000003,

    WICHeifHdrMaximumMasteringDisplayLuminanceLevel = 0x00000004,

    WICHeifHdrCustomVideoPrimaries = 0x00000005,
}
