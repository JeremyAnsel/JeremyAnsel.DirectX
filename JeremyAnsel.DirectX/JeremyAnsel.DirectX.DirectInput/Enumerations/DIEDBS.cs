namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEDBS(uint value) : IEquatable<DIEDBS>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEDBS e) => e._value;

    public static implicit operator DIEDBS(uint e) => new(e);

    public static DIEDBS operator |(DIEDBS left, DIEDBS right) => new(left._value | right._value);

    public static DIEDBS operator &(DIEDBS left, DIEDBS right) => new(left._value & right._value);

    public static bool operator ==(DIEDBS left, DIEDBS right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEDBS left, DIEDBS right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEDBS dIEDBS && Equals(dIEDBS);
    }

    public bool Equals(DIEDBS other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEDBS None = 0;

    public static readonly DIEDBS MAPPEDPRI1 = 0x00000001;

    public static readonly DIEDBS MAPPEDPRI2 = 0x00000002;

    public static readonly DIEDBS RECENTDEVICE = 0x00000010;

    public static readonly DIEDBS NEWDEVICE = 0x00000020;
}
