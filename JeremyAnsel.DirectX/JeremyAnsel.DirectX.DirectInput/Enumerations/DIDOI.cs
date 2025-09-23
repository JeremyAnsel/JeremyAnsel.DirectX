namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIDOI(uint value) : IEquatable<DIDOI>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIDOI e) => e._value;

    public static implicit operator DIDOI(uint e) => new(e);

    public static DIDOI operator |(DIDOI left, DIDOI right) => new(left._value | right._value);

    public static DIDOI operator &(DIDOI left, DIDOI right) => new(left._value & right._value);

    public static bool operator ==(DIDOI left, DIDOI right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDOI left, DIDOI right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIDOI dIDOI && Equals(dIDOI);
    }

    public bool Equals(DIDOI other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIDOI None = 0;

    public static readonly DIDOI FFACTUATOR = 0x00000001;

    public static readonly DIDOI FFEFFECTTRIGGER = 0x00000002;

    public static readonly DIDOI POLLED = 0x00008000;

    public static readonly DIDOI ASPECTPOSITION = 0x00000100;

    public static readonly DIDOI ASPECTVELOCITY = 0x00000200;

    public static readonly DIDOI ASPECTACCEL = 0x00000300;

    public static readonly DIDOI ASPECTFORCE = 0x00000400;

    public static readonly DIDOI ASPECTMASK = 0x00000F00;

    public static readonly DIDOI GUIDISUSAGE = 0x00010000;
}
