namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputEffectTypes : uint
{
    All = 0,

    ConstantForce = 1,

    RampForce = 2,

    Periodic = 3,

    Condition = 4,

    CustomForce = 5,

    Hardware = 0xFF,

    FFAttack = 0x200,

    FFFade = 0x400,

    Saturation = 0x800,

    PosNegCoefficients = 0x1000,

    PosNegSaturation = 0x2000,

    DeadBand = 0x4000,

    StartDelay = 0x8000
}
