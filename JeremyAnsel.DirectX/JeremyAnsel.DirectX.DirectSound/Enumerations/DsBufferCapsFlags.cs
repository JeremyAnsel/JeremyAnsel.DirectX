namespace JeremyAnsel.DirectX.DirectSound;

[Flags]
public enum DsBufferCapsFlags
{
    None = 0x00000000,

    PrimaryBuffer = 0x00000001,

    Static = 0x00000002,

    LocHardware = 0x00000004,

    LocSoftware = 0x00000008,

    Ctrl3D = 0x00000010,

    CtrlFrequency = 0x00000020,

    CtrlPan = 0x00000040,

    CtrlVolume = 0x00000080,

    CtrlPositionNotify = 0x00000100,

    StickyFocus = 0x00004000,

    GlobalFocus = 0x00008000,

    GetCurrentPosition2 = 0x00010000,

    Mute3dAtMaxDistance = 0x00020000,

    LocDefer = 0x00040000,
}
