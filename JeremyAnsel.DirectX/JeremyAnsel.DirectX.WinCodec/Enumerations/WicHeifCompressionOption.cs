namespace JeremyAnsel.DirectX.WinCodec;

public enum WicHeifCompressionOption : uint
{
    WICHeifCompressionDontCare = 0x00000000,

    WICHeifCompressionNone = 0x00000001,

    WICHeifCompressionHEVC = 0x00000002,

    WICHeifCompressionAV1 = 0x00000003,

    WICHeifCompressionJpegXL = 0x00000004,

    WICHeifCompressionBrotli = 0x00000005,

    WICHeifCompressionDeflate = 0x00000006,
}
