namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIDF(uint value) : IEquatable<DIDF>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIDF e) => e._value;

    public static implicit operator DIDF(uint e) => new(e);

    public static DIDF operator |(DIDF left, DIDF right) => new(left._value | right._value);

    public static DIDF operator &(DIDF left, DIDF right) => new(left._value & right._value);

    public static bool operator ==(DIDF left, DIDF right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDF left, DIDF right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIDF dIDF && Equals(dIDF);
    }

    public bool Equals(DIDF other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIDF None = 0;

    public static readonly DIDF ABSAXIS = 0x00000001;

    public static readonly DIDF RELAXIS = 0x00000002;
}
