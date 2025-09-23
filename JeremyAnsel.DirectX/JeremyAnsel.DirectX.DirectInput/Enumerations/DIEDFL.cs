namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEDFL(uint value) : IEquatable<DIEDFL>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEDFL e) => e._value;

    public static implicit operator DIEDFL(uint e) => new(e);

    public static DIEDFL operator |(DIEDFL left, DIEDFL right) => new(left._value | right._value);

    public static DIEDFL operator &(DIEDFL left, DIEDFL right) => new(left._value & right._value);

    public static bool operator ==(DIEDFL left, DIEDFL right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEDFL left, DIEDFL right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEDFL dIEDFL && Equals(dIEDFL);
    }

    public bool Equals(DIEDFL other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEDFL ALLDEVICES = 0x00000000;

    public static readonly DIEDFL ATTACHEDONLY = 0x00000001;

    public static readonly DIEDFL FORCEFEEDBACK = 0x00000100;

    public static readonly DIEDFL INCLUDEALIASES = 0x00010000;

    public static readonly DIEDFL INCLUDEPHANTOMS = 0x00020000;

    public static readonly DIEDFL INCLUDEHIDDEN = 0x00040000;
}
