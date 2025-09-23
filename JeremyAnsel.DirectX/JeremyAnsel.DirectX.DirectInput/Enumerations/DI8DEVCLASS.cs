namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DI8DEVCLASS(uint value) : IEquatable<DI8DEVCLASS>
{
    private readonly uint _value = value;

    public static implicit operator uint(DI8DEVCLASS e) => e._value;

    public static implicit operator DI8DEVCLASS(uint e) => new(e);

    public static DI8DEVCLASS operator |(DI8DEVCLASS left, DI8DEVCLASS right) => new(left._value | right._value);

    public static DI8DEVCLASS operator &(DI8DEVCLASS left, DI8DEVCLASS right) => new(left._value & right._value);

    public static bool operator ==(DI8DEVCLASS left, DI8DEVCLASS right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DI8DEVCLASS left, DI8DEVCLASS right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DI8DEVCLASS dEVCLASS && Equals(dEVCLASS);
    }

    public bool Equals(DI8DEVCLASS other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DI8DEVCLASS ALL = 0;

    public static readonly DI8DEVCLASS DEVICE = 1;

    public static readonly DI8DEVCLASS POINTER = 2;

    public static readonly DI8DEVCLASS KEYBOARD = 3;

    public static readonly DI8DEVCLASS GAMECTRL = 4;
}
