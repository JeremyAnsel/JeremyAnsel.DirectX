namespace JeremyAnsel.DirectX.DirectSound;

[Flags]
public enum DsBufferStatus
{
    None,

    Playing = 0x01,

    BufferLost = 0x02,

    Looping = 0x04,

    LocHardware = 0x08,

    LocSoftware = 0x10,

    Terminated = 0x20
}
