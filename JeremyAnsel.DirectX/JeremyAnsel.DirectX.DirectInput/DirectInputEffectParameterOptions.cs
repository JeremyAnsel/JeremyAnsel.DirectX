namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputEffectParameterOptions : uint
{
    None = 0,

    Duration = 0x01,

    SamplePeriod = 0x02,

    Gain = 0x04,

    TriggerButton = 0x08,

    TriggerRepeatInterval = 0x10,

    Axes = 0x20,

    Direction = 0x40,

    Envelope = 0x80,

    TypeSpecificParams = 0x100,

    StartDelay = 0x200,

    AllParams = 0x3FF,

    Start = 0x20000000,

    NoRestart = 0x40000000,

    NoDownload = 0x80000000,

    NoTrigger = 0xFFFFFFFF
}
