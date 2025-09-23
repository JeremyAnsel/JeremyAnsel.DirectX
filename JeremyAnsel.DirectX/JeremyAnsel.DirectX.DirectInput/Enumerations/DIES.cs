namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIES(uint value) : IEquatable<DIES>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIES e) => e._value;

    public static implicit operator DIES(uint e) => new(e);

    public static DIES operator |(DIES left, DIES right) => new(left._value | right._value);

    public static DIES operator &(DIES left, DIES right) => new(left._value & right._value);

    public static bool operator ==(DIES left, DIES right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIES left, DIES right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIES dIES && Equals(dIES);
    }

    public bool Equals(DIES other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIES None = 0;

    public static readonly DIES SOLO = 0x00000001;

    public static readonly DIES NODOWNLOAD = 0x80000000;
}
