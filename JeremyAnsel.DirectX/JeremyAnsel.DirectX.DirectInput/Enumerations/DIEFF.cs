namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEFF(uint value) : IEquatable<DIEFF>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEFF e) => e._value;

    public static implicit operator DIEFF(uint e) => new(e);

    public static DIEFF operator |(DIEFF left, DIEFF right) => new(left._value | right._value);

    public static DIEFF operator &(DIEFF left, DIEFF right) => new(left._value & right._value);

    public static bool operator ==(DIEFF left, DIEFF right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEFF left, DIEFF right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEFF dIEFF && Equals(dIEFF);
    }

    public bool Equals(DIEFF other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEFF None = 0;

    public static readonly DIEFF OBJECTIDS = 0x00000001;

    public static readonly DIEFF OBJECTOFFSETS = 0x00000002;

    public static readonly DIEFF CARTESIAN = 0x00000010;

    public static readonly DIEFF POLAR = 0x00000020;

    public static readonly DIEFF SPHERICAL = 0x00000040;
}
