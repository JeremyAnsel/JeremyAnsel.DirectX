using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIPROPRANGE : IEquatable<DIPROPRANGE>
{
    public DIPROPHEADER Header;

    public int Min;

    public int Max;

    public override bool Equals(object? obj)
    {
        return obj is DIPROPRANGE dIPROPRANGE && Equals(dIPROPRANGE);
    }

    public bool Equals(DIPROPRANGE other)
    {
        return Header.Equals(other.Header) &&
               Min == other.Min &&
               Max == other.Max;
    }

    public override int GetHashCode()
    {
        int hashCode = -1256518456;
        hashCode = hashCode * -1521134295 + Header.GetHashCode();
        hashCode = hashCode * -1521134295 + Min.GetHashCode();
        hashCode = hashCode * -1521134295 + Max.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIPROPRANGE left, DIPROPRANGE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIPROPRANGE left, DIPROPRANGE right)
    {
        return !(left == right);
    }
}
