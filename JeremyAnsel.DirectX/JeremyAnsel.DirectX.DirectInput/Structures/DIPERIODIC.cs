using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIPERIODIC : IEquatable<DIPERIODIC>
{
    public int Magnitude;

    public int Offset;

    public int Phase;

    public int Period;

    public override bool Equals(object? obj)
    {
        return obj is DIPERIODIC dIPERIODIC && Equals(dIPERIODIC);
    }

    public bool Equals(DIPERIODIC other)
    {
        return Magnitude == other.Magnitude &&
               Offset == other.Offset &&
               Phase == other.Phase &&
               Period == other.Period;
    }

    public override int GetHashCode()
    {
        int hashCode = -1456104525;
        hashCode = hashCode * -1521134295 + Magnitude.GetHashCode();
        hashCode = hashCode * -1521134295 + Offset.GetHashCode();
        hashCode = hashCode * -1521134295 + Phase.GetHashCode();
        hashCode = hashCode * -1521134295 + Period.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIPERIODIC left, DIPERIODIC right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIPERIODIC left, DIPERIODIC right)
    {
        return !(left == right);
    }
}
