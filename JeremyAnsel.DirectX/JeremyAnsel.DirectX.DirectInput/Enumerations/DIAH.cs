namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIAH(uint value) : IEquatable<DIAH>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIAH e) => e._value;

    public static implicit operator DIAH(uint e) => new(e);

    public static DIAH operator |(DIAH left, DIAH right) => new(left._value | right._value);

    public static DIAH operator &(DIAH left, DIAH right) => new(left._value & right._value);

    public static bool operator ==(DIAH left, DIAH right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIAH left, DIAH right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIAH dIAH && Equals(dIAH);
    }

    public bool Equals(DIAH other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIAH UNMAPPED = 0x00000000;

    public static readonly DIAH USERCONFIG = 0x00000001;

    public static readonly DIAH APPREQUESTED = 0x00000002;

    public static readonly DIAH HWAPP = 0x00000004;

    public static readonly DIAH HWDEFAULT = 0x00000008;

    public static readonly DIAH DEFAULT = 0x00000020;

    public static readonly DIAH ERROR = 0x80000000;
}
