namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIGFFS(uint value) : IEquatable<DIGFFS>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIGFFS e) => e._value;

    public static implicit operator DIGFFS(uint e) => new(e);

    public static DIGFFS operator |(DIGFFS left, DIGFFS right) => new(left._value | right._value);

    public static DIGFFS operator &(DIGFFS left, DIGFFS right) => new(left._value & right._value);

    public static bool operator ==(DIGFFS left, DIGFFS right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIGFFS left, DIGFFS right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIGFFS dIGFFS && Equals(dIGFFS);
    }

    public bool Equals(DIGFFS other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIGFFS None = 0;

    public static readonly DIGFFS EMPTY = 0x00000001;

    public static readonly DIGFFS STOPPED = 0x00000002;

    public static readonly DIGFFS PAUSED = 0x00000004;

    public static readonly DIGFFS ACTUATORSON = 0x00000010;

    public static readonly DIGFFS ACTUATORSOFF = 0x00000020;

    public static readonly DIGFFS POWERON = 0x00000040;

    public static readonly DIGFFS POWEROFF = 0x00000080;

    public static readonly DIGFFS SAFETYSWITCHON = 0x00000100;

    public static readonly DIGFFS SAFETYSWITCHOFF = 0x00000200;

    public static readonly DIGFFS USERFFSWITCHON = 0x00000400;

    public static readonly DIGFFS USERFFSWITCHOFF = 0x00000800;

    public static readonly DIGFFS DEVICELOST = 0x80000000;
}
