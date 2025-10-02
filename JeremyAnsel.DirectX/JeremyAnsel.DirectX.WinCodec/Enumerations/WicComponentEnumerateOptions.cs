namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicComponentEnumerateOptions : uint
{
    WICComponentEnumerateDefault = 0x00000000,

    WICComponentEnumerateRefresh = 0x00000001,

    WICComponentEnumerateDisabled = 0x80000000,

    WICComponentEnumerateUnsigned = 0x40000000,

    WICComponentEnumerateBuiltInOnly = 0x20000000,
}
