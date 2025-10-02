namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicComponentType : uint
{
    Unknown = 0,

    WICDecoder = 0x00000001,

    WICEncoder = 0x00000002,

    WICPixelFormatConverter = 0x00000004,

    WICMetadataReader = 0x00000008,

    WICMetadataWriter = 0x00000010,

    WICPixelFormat = 0x00000020,

    WICAllComponents = 0x0000003F,
}
