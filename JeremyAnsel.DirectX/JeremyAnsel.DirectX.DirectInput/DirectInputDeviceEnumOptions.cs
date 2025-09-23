namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputDeviceEnumOptions : uint
{
    AllDevices = 0,

    AttachedOnly = 1,

    ForceFeedback = 2,

    IncludeAliases = 4,

    IncludePhantoms = 8,

    IncludeHidden = 16
}
