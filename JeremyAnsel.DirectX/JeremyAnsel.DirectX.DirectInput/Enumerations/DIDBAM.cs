namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIDBAM(uint value) : IEquatable<DIDBAM>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIDBAM e) => e._value;

    public static implicit operator DIDBAM(uint e) => new(e);

    public static DIDBAM operator |(DIDBAM left, DIDBAM right) => new(left._value | right._value);

    public static DIDBAM operator &(DIDBAM left, DIDBAM right) => new(left._value & right._value);

    public static bool operator ==(DIDBAM left, DIDBAM right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDBAM left, DIDBAM right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIDBAM dIDBAM && Equals(dIDBAM);
    }

    public bool Equals(DIDBAM other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIDBAM DEFAULT = 0x00000000;

    public static readonly DIDBAM PRESERVE = 0x00000001;

    public static readonly DIDBAM INITIALIZE = 0x00000002;

    public static readonly DIDBAM HWDEFAULTS = 0x00000004;
}
