namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIPH(uint value) : IEquatable<DIPH>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIPH e) => e._value;

    public static implicit operator DIPH(uint e) => new(e);

    public static DIPH operator |(DIPH left, DIPH right) => new(left._value | right._value);

    public static DIPH operator &(DIPH left, DIPH right) => new(left._value & right._value);

    public static bool operator ==(DIPH left, DIPH right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIPH left, DIPH right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIPH dIPH && Equals(dIPH);
    }

    public bool Equals(DIPH other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIPH DEVICE = 0;

    public static readonly DIPH BYOFFSET = 1;

    public static readonly DIPH BYID = 2;

    public static readonly DIPH BYUSAGE = 3;
}
