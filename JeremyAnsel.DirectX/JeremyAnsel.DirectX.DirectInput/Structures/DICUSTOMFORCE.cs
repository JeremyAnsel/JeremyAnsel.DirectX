using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DICUSTOMFORCE : IEquatable<DICUSTOMFORCE>
{
    public int Channels;

    public int SamplePeriod;

    public int Samples;

    [MarshalAs(UnmanagedType.LPArray)]
    public int[] ForceData;

    public override bool Equals(object? obj)
    {
        return obj is DICUSTOMFORCE dICUSTOMFORCE && Equals(dICUSTOMFORCE);
    }

    public bool Equals(DICUSTOMFORCE other)
    {
        return Channels == other.Channels &&
               SamplePeriod == other.SamplePeriod &&
               Samples == other.Samples &&
               EqualityComparer<int[]>.Default.Equals(ForceData, other.ForceData);
    }

    public override int GetHashCode()
    {
        int hashCode = -1755654060;
        hashCode = hashCode * -1521134295 + Channels.GetHashCode();
        hashCode = hashCode * -1521134295 + SamplePeriod.GetHashCode();
        hashCode = hashCode * -1521134295 + Samples.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(ForceData);
        return hashCode;
    }

    public static bool operator ==(DICUSTOMFORCE left, DICUSTOMFORCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICUSTOMFORCE left, DICUSTOMFORCE right)
    {
        return !(left == right);
    }
}
