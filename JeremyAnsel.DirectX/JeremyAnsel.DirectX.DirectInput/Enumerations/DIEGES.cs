namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEGES(uint value) : IEquatable<DIEGES>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEGES e) => e._value;

    public static implicit operator DIEGES(uint e) => new(e);

    public static DIEGES operator |(DIEGES left, DIEGES right) => new(left._value | right._value);

    public static DIEGES operator &(DIEGES left, DIEGES right) => new(left._value & right._value);

    public static bool operator ==(DIEGES left, DIEGES right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEGES left, DIEGES right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEGES dIEGES && Equals(dIEGES);
    }

    public bool Equals(DIEGES other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEGES None = 0;

    public static readonly DIEGES PLAYING = 0x00000001;

    public static readonly DIEGES EMULATED = 0x00000002;
}
