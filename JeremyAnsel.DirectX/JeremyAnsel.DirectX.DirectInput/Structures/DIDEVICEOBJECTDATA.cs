using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIDEVICEOBJECTDATA : IEquatable<DIDEVICEOBJECTDATA>
{
    public int Ofs;

    public int Data;

    public int TimeStamp;

    public int Sequence;

    public IntPtr uAppData;

    public override bool Equals(object? obj)
    {
        return obj is DIDEVICEOBJECTDATA dIDEVICEOBJECTDATA && Equals(dIDEVICEOBJECTDATA);
    }

    public bool Equals(DIDEVICEOBJECTDATA other)
    {
        return Ofs == other.Ofs &&
               Data == other.Data &&
               TimeStamp == other.TimeStamp &&
               Sequence == other.Sequence &&
               EqualityComparer<IntPtr>.Default.Equals(uAppData, other.uAppData);
    }

    public override int GetHashCode()
    {
        int hashCode = -2039944132;
        hashCode = hashCode * -1521134295 + Ofs.GetHashCode();
        hashCode = hashCode * -1521134295 + Data.GetHashCode();
        hashCode = hashCode * -1521134295 + TimeStamp.GetHashCode();
        hashCode = hashCode * -1521134295 + Sequence.GetHashCode();
        hashCode = hashCode * -1521134295 + uAppData.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIDEVICEOBJECTDATA left, DIDEVICEOBJECTDATA right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDEVICEOBJECTDATA left, DIDEVICEOBJECTDATA right)
    {
        return !(left == right);
    }
}
