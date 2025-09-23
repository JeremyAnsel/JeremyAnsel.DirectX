namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DISCL(uint value) : IEquatable<DISCL>
{
    private readonly uint _value = value;

    public static implicit operator uint(DISCL e) => e._value;

    public static implicit operator DISCL(uint e) => new(e);


    public static DISCL operator |(DISCL left, DISCL right) => new(left._value | right._value);

    public static DISCL operator &(DISCL left, DISCL right) => new(left._value & right._value);

    public static bool operator ==(DISCL left, DISCL right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DISCL left, DISCL right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DISCL dISCL && Equals(dISCL);
    }

    public bool Equals(DISCL other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DISCL None = 0;

    public static readonly DISCL EXCLUSIVE = 0x00000001;

    public static readonly DISCL NONEXCLUSIVE = 0x00000002;

    public static readonly DISCL FOREGROUND = 0x00000004;

    public static readonly DISCL BACKGROUND = 0x00000008;

    public static readonly DISCL NOWINKEY = 0x00000010;
}
