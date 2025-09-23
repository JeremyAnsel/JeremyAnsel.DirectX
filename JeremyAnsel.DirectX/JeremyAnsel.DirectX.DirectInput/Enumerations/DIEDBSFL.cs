namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEDBSFL(uint value) : IEquatable<DIEDBSFL>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEDBSFL e) => e._value;

    public static implicit operator DIEDBSFL(uint e) => new(e);

    public static DIEDBSFL operator |(DIEDBSFL left, DIEDBSFL right) => new(left._value | right._value);

    public static DIEDBSFL operator &(DIEDBSFL left, DIEDBSFL right) => new(left._value & right._value);

    public static bool operator ==(DIEDBSFL left, DIEDBSFL right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEDBSFL left, DIEDBSFL right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEDBSFL dIEDBSFL && Equals(dIEDBSFL);
    }

    public bool Equals(DIEDBSFL other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEDBSFL ATTACHEDONLY = 0x00000000;

    public static readonly DIEDBSFL THISUSER = 0x00000010;

    public static readonly DIEDBSFL FORCEFEEDBACK = 0x00000100;

    public static readonly DIEDBSFL AVAILABLEDEVICES = 0x00001000;

    public static readonly DIEDBSFL MULTIMICEKEYBOARDS = 0x00002000;

    public static readonly DIEDBSFL NONGAMINGDEVICES = 0x00004000;

    public static readonly DIEDBSFL VALID = 0x00007110;
}
