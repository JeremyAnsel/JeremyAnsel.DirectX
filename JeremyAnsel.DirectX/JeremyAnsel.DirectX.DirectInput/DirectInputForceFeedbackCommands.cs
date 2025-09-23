namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputForceFeedbackCommands : uint
{
    None = 0,

    Reset = 1,

    StopAll = 2,

    Pause = 4,

    Continue = 8,

    SetActuatorsOn = 16,

    SetActuatorsOff = 32
}
