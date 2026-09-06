namespace JeremyAnsel.DirectX.DirectSound;

[Flags]
public enum DsBufferPlayOptions
{
    None,

    Looping = 0x01,

    LocHardware = 0x02,

    LocSoftware = 0x04,

    TerminatedByTime = 0x08,

    TerminatedByDistance = 0x10,

    TerminatedByPriority = 0x20,
}
