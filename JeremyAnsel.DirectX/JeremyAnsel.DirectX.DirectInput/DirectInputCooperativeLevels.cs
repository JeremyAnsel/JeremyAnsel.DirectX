namespace JeremyAnsel.DirectX.DirectInput;

[Flags]
public enum DirectInputCooperativeLevels : uint
{
    None = 0,

    Exclusive = 1,

    NonExclusive = 2,

    Foreground = 4,

    Background = 8,

    NoWinKey = 16
}
