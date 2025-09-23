using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DICONSTANTFORCE : IEquatable<DICONSTANTFORCE>
{
    public int Magnitude;

    public override bool Equals(object? obj)
    {
        return obj is DICONSTANTFORCE dICONSTANTFORCE && Equals(dICONSTANTFORCE);
    }

    public bool Equals(DICONSTANTFORCE other)
    {
        return Magnitude == other.Magnitude;
    }

    public override int GetHashCode()
    {
        return 930583133 + Magnitude.GetHashCode();
    }

    public static bool operator ==(DICONSTANTFORCE left, DICONSTANTFORCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICONSTANTFORCE left, DICONSTANTFORCE right)
    {
        return !(left == right);
    }
}
