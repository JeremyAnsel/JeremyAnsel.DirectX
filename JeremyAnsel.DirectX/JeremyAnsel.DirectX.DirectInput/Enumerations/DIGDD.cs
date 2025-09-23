namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIGDD(uint value) : IEquatable<DIGDD>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIGDD e) => e._value;

    public static implicit operator DIGDD(uint e) => new(e);

    public static DIGDD operator |(DIGDD left, DIGDD right) => new(left._value | right._value);

    public static DIGDD operator &(DIGDD left, DIGDD right) => new(left._value & right._value);

    public static bool operator ==(DIGDD left, DIGDD right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIGDD left, DIGDD right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIGDD dIGDD && Equals(dIGDD);
    }

    public bool Equals(DIGDD other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIGDD None = 0;

    public static readonly DIGDD PEEK = 0x00000001;
}
