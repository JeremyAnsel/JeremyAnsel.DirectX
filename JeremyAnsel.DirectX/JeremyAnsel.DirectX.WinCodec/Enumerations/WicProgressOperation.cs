namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicProgressOperation : uint
{
    None = 0,

    WICProgressOperationCopyPixels = 0x00000001,

    WICProgressOperationWritePixels = 0x00000002,

    WICProgressOperationAll = 0x0000FFFF,
}
