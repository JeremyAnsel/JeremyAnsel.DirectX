namespace JeremyAnsel.DirectX.WinCodec;

public enum WicSectionAccessLevel : uint
{
    None = 0,

    WICSectionAccessLevelRead = 0x00000001,

    WICSectionAccessLevelReadWrite = 0x00000003,
}
