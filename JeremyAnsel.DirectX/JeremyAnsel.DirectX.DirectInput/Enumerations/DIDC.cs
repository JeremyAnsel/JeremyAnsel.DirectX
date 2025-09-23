namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIDC(uint value) : IEquatable<DIDC>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIDC e) => e._value;

    public static implicit operator DIDC(uint e) => new(e);

    public static DIDC operator |(DIDC left, DIDC right) => new(left._value | right._value);

    public static DIDC operator &(DIDC left, DIDC right) => new(left._value & right._value);

    public bool HasFlag(DIDC f)
    {
        return (_value & f._value) == f._value;
    }

    public static bool operator ==(DIDC left, DIDC right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDC left, DIDC right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIDC dIDC && Equals(dIDC);
    }

    public bool Equals(DIDC other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIDC None = 0;

    public static readonly DIDC ATTACHED = 0x00000001;

    public static readonly DIDC POLLEDDEVICE = 0x00000002;

    public static readonly DIDC EMULATED = 0x00000004;

    public static readonly DIDC POLLEDDATAFORMAT = 0x00000008;

    public static readonly DIDC FORCEFEEDBACK = 0x00000100;

    public static readonly DIDC FFATTACK = 0x00000200;

    public static readonly DIDC FFFADE = 0x00000400;

    public static readonly DIDC SATURATION = 0x00000800;

    public static readonly DIDC POSNEGCOEFFICIENTS = 0x00001000;

    public static readonly DIDC POSNEGSATURATION = 0x00002000;

    public static readonly DIDC DEADBAND = 0x00004000;

    public static readonly DIDC STARTDELAY = 0x00008000;

    public static readonly DIDC ALIAS = 0x00010000;

    public static readonly DIDC PHANTOM = 0x00020000;

    public static readonly DIDC HIDDEN = 0x00040000;
}
