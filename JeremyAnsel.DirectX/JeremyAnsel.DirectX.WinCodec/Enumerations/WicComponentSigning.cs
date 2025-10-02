namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicComponentSigning : uint
{
    None = 0,

    WICComponentSigned = 0x00000001,

    WICComponentUnsigned = 0x00000002,

    WICComponentSafe = 0x00000004,

    WICComponentDisabled = 0x80000000,
}
