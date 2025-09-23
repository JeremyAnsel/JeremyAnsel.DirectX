namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputEffectParametersDataOptions : uint
{
    None = 0,

    ObjectIDs = 1,

    ObjectOffsets = 2,

    Cartesian = 16,

    Polar = 32,

    Spherical = 64
}
