using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DICONDITION : IEquatable<DICONDITION>
{
    public int Offset;

    public int PositiveCoefficient;

    public int NegativeCoefficient;

    public int PositiveSaturation;

    public int NegativeSaturation;

    public int DeadBand;

    public override bool Equals(object? obj)
    {
        return obj is DICONDITION dICONDITION && Equals(dICONDITION);
    }

    public bool Equals(DICONDITION other)
    {
        return Offset == other.Offset &&
               PositiveCoefficient == other.PositiveCoefficient &&
               NegativeCoefficient == other.NegativeCoefficient &&
               PositiveSaturation == other.PositiveSaturation &&
               NegativeSaturation == other.NegativeSaturation &&
               DeadBand == other.DeadBand;
    }

    public override int GetHashCode()
    {
        int hashCode = -1324512340;
        hashCode = hashCode * -1521134295 + Offset.GetHashCode();
        hashCode = hashCode * -1521134295 + PositiveCoefficient.GetHashCode();
        hashCode = hashCode * -1521134295 + NegativeCoefficient.GetHashCode();
        hashCode = hashCode * -1521134295 + PositiveSaturation.GetHashCode();
        hashCode = hashCode * -1521134295 + NegativeSaturation.GetHashCode();
        hashCode = hashCode * -1521134295 + DeadBand.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DICONDITION left, DICONDITION right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICONDITION left, DICONDITION right)
    {
        return !(left == right);
    }
}
