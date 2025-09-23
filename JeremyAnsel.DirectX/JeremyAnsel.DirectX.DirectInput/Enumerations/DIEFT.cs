namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEFT(uint value) : IEquatable<DIEFT>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEFT e) => e._value;

    public static implicit operator DIEFT(uint e) => new(e);

    public static DIEFT operator |(DIEFT left, DIEFT right) => new(left._value | right._value);

    public static DIEFT operator &(DIEFT left, DIEFT right) => new(left._value & right._value);

    public static bool operator ==(DIEFT left, DIEFT right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEFT left, DIEFT right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEFT dIEFT && Equals(dIEFT);
    }

    public bool Equals(DIEFT other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEFT ALL = 0x00000000;

    public static readonly DIEFT CONSTANTFORCE = 0x00000001;

    public static readonly DIEFT RAMPFORCE = 0x00000002;

    public static readonly DIEFT PERIODIC = 0x00000003;

    public static readonly DIEFT CONDITION = 0x00000004;

    public static readonly DIEFT CUSTOMFORCE = 0x00000005;

    public static readonly DIEFT HARDWARE = 0x000000FF;

    public static readonly DIEFT FFATTACK = 0x00000200;

    public static readonly DIEFT FFFADE = 0x00000400;

    public static readonly DIEFT SATURATION = 0x00000800;

    public static readonly DIEFT POSNEGCOEFFICIENTS = 0x00001000;

    public static readonly DIEFT POSNEGSATURATION = 0x00002000;

    public static readonly DIEFT DEADBAND = 0x00004000;

    public static readonly DIEFT STARTDELAY = 0x00008000;

    public static DIEFT GetType(DIEFT value) => new(value._value & 0xff);
}
