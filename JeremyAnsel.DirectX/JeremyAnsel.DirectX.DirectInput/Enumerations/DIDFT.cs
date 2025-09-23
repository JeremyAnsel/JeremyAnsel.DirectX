namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIDFT(uint value) : IEquatable<DIDFT>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIDFT e) => e._value;

    public static implicit operator DIDFT(uint e) => new(e);

    public static DIDFT operator |(DIDFT left, DIDFT right) => new(left._value | right._value);

    public static DIDFT operator &(DIDFT left, DIDFT right) => new(left._value & right._value);

    public static bool operator ==(DIDFT left, DIDFT right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDFT left, DIDFT right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIDFT dIDFT && Equals(dIDFT);
    }

    public bool Equals(DIDFT other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIDFT ALL = 0x00000000;

    public static readonly DIDFT RELAXIS = 0x00000001;

    public static readonly DIDFT ABSAXIS = 0x00000002;

    public static readonly DIDFT AXIS = 0x00000003;

    public static readonly DIDFT PSHBUTTON = 0x00000004;

    public static readonly DIDFT TGLBUTTON = 0x00000008;

    public static readonly DIDFT BUTTON = 0x0000000C;

    public static readonly DIDFT POV = 0x00000010;

    public static readonly DIDFT COLLECTION = 0x00000040;

    public static readonly DIDFT NODATA = 0x00000080;

    public static readonly DIDFT ANYINSTANCE = 0x00FFFF00;

    public static readonly DIDFT INSTANCEMASK = ANYINSTANCE;

    public static DIDFT MAKEINSTANCE(int n) => (uint)((ushort)n << 8);

    public static byte GETTYPE(DIDFT n) => (byte)n;

    public static int DIDFT_GETINSTANCE(DIDFT n) => (ushort)((uint)n >> 8);

    public static readonly DIDFT FFACTUATOR = 0x01000000;

    public static readonly DIDFT FFEFFECTTRIGGER = 0x02000000;

    public static readonly DIDFT OUTPUT = 0x10000000;

    public static readonly DIDFT VENDORDEFINED = 0x04000000;

    public static readonly DIDFT ALIAS = 0x08000000;

    public static DIDFT ENUMCOLLECTION(int n) => (uint)((ushort)n << 8);

    public static readonly DIDFT NOCOLLECTION = 0x00FFFF00;
}
