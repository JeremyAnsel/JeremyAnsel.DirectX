namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DISFFC(uint value) : IEquatable<DISFFC>
{
    private readonly uint _value = value;

    public static implicit operator uint(DISFFC e) => e._value;

    public static implicit operator DISFFC(uint e) => new(e);

    public static DISFFC operator |(DISFFC left, DISFFC right) => new(left._value | right._value);

    public static DISFFC operator &(DISFFC left, DISFFC right) => new(left._value & right._value);

    public static bool operator ==(DISFFC left, DISFFC right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DISFFC left, DISFFC right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DISFFC dISFFC && Equals(dISFFC);
    }

    public bool Equals(DISFFC other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DISFFC None = 0;

    public static readonly DISFFC RESET = 0x00000001;

    public static readonly DISFFC STOPALL = 0x00000002;

    public static readonly DISFFC PAUSE = 0x00000004;

    public static readonly DISFFC CONTINUE = 0x00000008;

    public static readonly DISFFC SETACTUATORSON = 0x00000010;

    public static readonly DISFFC SETACTUATORSOFF = 0x00000020;
}
