namespace JeremyAnsel.DirectX.WinCodec;

public enum WicRawRotationCapabilities : uint
{
    WICRawRotationCapabilityNotSupported = 0x00000000,

    WICRawRotationCapabilityGetSupported = 0x00000001,

    WICRawRotationCapabilityNinetyDegreesSupported = 0x00000002,

    WICRawRotationCapabilityFullySupported = 0x00000003,
}
