namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DICD(uint value) : IEquatable<DICD>
{
    private readonly uint _value = value;

    public static implicit operator uint(DICD e) => e._value;

    public static implicit operator DICD(uint e) => new(e);

    public static DICD operator |(DICD left, DICD right) => new(left._value | right._value);

    public static DICD operator &(DICD left, DICD right) => new(left._value & right._value);

    public static bool operator ==(DICD left, DICD right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICD left, DICD right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DICD dICD && Equals(dICD);
    }

    public bool Equals(DICD other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DICD DEFAULT = 0x00000000;

    public static readonly DICD EDIT = 0x00000001;
}
