namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputObjectDataTypes : uint
{
    All = 0,

    RelativeAxis = 0x01,

    AbsoluteAxis = 0x02,

    Axis = 0x03,

    PushButton = 0x04,

    ToggleButton = 0x08,

    Button = 0x0C,

    POV = 0x10,

    Collection = 0x40,

    NoData = 0x80,

    FFActuator = 0x01000000,

    FFEffectTrigger = 0x02000000,

    Output = 0x10000000,

    VendorDefined = 0x04000000,

    Alias = 0x08000000
}
