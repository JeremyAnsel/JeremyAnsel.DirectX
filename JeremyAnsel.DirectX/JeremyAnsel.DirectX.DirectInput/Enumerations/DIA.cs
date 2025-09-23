namespace JeremyAnsel.DirectX.DirectInput;

internal readonly struct DIA(uint value) : IEquatable<DIA>
{
    private readonly uint _value = value;

    public static implicit operator uint(DIA e) => e._value;

    public static implicit operator DIA(uint e) => new(e);

    public static DIA operator |(DIA left, DIA right) => new(left._value | right._value);

    public static DIA operator &(DIA left, DIA right) => new(left._value & right._value);

    public static bool operator ==(DIA left, DIA right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIA left, DIA right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DIA dIA && Equals(dIA);
    }

    public bool Equals(DIA other)
    {
        return _value == other._value;
    }

    public override int GetHashCode()
    {
        return -1939223833 + _value.GetHashCode();
    }

    public static readonly DIA None = 0;

    public static readonly DIA FORCEFEEDBACK = 0x00000001;

    public static readonly DIA APPMAPPED = 0x00000002;

    public static readonly DIA APPNOMAP = 0x00000004;

    public static readonly DIA NORANGE = 0x00000008;

    public static readonly DIA APPFIXED = 0x00000010;
}
