namespace JeremyAnsel.DirectX.DirectSound;

[Flags]
public enum DsCapsFlags
{
    None = 0,

    PrimaryMono = 0x0001,

    PrimaryStereo = 0x0002,

    Primary8Bit = 0x0004,

    Primary16Bit = 0x0008,

    ContinuousRate = 0x0010,

    EmumDriver = 0x0020,

    Certified = 0x0040,

    SecondaryMono = 0x0100,

    SecondaryStereo = 0x0200,

    Secondary8Bit = 0x0400,

    Secondary16Bit = 0x0800,
}
