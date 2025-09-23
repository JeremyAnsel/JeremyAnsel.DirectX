namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputDeviceCapabilitiesOptions : uint
{
    None = 0,

    Attached = 1,

    PolledDevice = 2,

    Emulated = 4,

    PolledDataFormat = 8,

    ForceFeedback = 16,

    FFAttack = 32,

    FFFade = 64,

    Saturation = 128,

    PosNegCoefficients = 256,

    PosNegSaturation = 512,

    DeadBand = 1024,

    StartDelay = 2048,

    Alias = 4096,

    Phantom = 8192,

    Hidden = 16384,
}
