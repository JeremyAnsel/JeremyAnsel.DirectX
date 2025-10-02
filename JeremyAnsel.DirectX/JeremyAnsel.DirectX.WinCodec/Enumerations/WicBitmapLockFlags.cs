namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicBitmapLockFlags : uint
{
    None = 0,

    WICBitmapLockRead = 0x00000001,

    WICBitmapLockWrite = 0x00000002,
}
