namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputForceFeedbackStates : uint
{
    None = 0,

    Empty = 1,

    Stopped = 2,

    Paused = 4,

    ActuatorsOn = 16,

    ActuatorsOff = 32,

    PowerOn = 64,

    PowerOff = 128,

    SafetySwitchOn = 256,

    SafetySwitch = 512,

    UserFFSwitchOn = 1024,

    UserFFSwitchOff = 2048,

    DeviceLost = 0x80000000
}
