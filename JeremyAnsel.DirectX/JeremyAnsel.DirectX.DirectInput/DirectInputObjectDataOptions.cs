namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputObjectDataOptions : uint
{
    None = 0,

    FFActuator = 1,

    FFEffectTrigger = 2,

    Polled = 4,

    AspectPosition = 8,

    AspectVelocity = 16,

    AspectAccel = 32,

    AspectForce = 64,

    AspectMask = 128,

    GuidUsage = 256
}
