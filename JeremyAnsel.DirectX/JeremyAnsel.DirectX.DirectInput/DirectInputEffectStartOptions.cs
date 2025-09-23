namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputEffectStartOptions : uint
{
    None = 0,

    Solo = 0x00000001,

    NoDownload = 0x80000000
}
