namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicWin32GenericAccessRights : uint
{
    None = 0,

    GenericAll = 0x10000000,

    GenericExecute = 0x20000000,

    GenericWrite = 0x40000000,

    GenericRead = 0x80000000,
}
