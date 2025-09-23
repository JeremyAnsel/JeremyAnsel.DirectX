namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIEP(uint value) : IEquatable<DIEP>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIEP e) => e._value;

    public static implicit operator DIEP(uint e) => new(e);

    public static DIEP operator |(DIEP left, DIEP right) => new(left._value | right._value);

    public static DIEP operator &(DIEP left, DIEP right) => new(left._value & right._value);

    public static bool operator ==(DIEP left, DIEP right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEP left, DIEP right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIEP dIEP && Equals(dIEP);
    }

    public bool Equals(DIEP other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIEP None = 0;

    public static readonly DIEP DURATION = 0x00000001;

    public static readonly DIEP SAMPLEPERIOD = 0x00000002;

    public static readonly DIEP GAIN = 0x00000004;

    public static readonly DIEP TRIGGERBUTTON = 0x00000008;

    public static readonly DIEP TRIGGERREPEATINTERVAL = 0x00000010;

    public static readonly DIEP AXES = 0x00000020;

    public static readonly DIEP DIRECTION = 0x00000040;

    public static readonly DIEP ENVELOPE = 0x00000080;

    public static readonly DIEP TYPESPECIFICPARAMS = 0x00000100;

    public static readonly DIEP STARTDELAY = 0x00000200;

    public static readonly DIEP ALLPARAMS_DX5 = 0x000001FF;

    public static readonly DIEP ALLPARAMS = 0x000003FF;

    public static readonly DIEP START = 0x20000000;

    public static readonly DIEP NORESTART = 0x40000000;

    public static readonly DIEP NODOWNLOAD = 0x80000000;

    public static readonly DIEP NOTRIGGER = 0xFFFFFFFF;
}
