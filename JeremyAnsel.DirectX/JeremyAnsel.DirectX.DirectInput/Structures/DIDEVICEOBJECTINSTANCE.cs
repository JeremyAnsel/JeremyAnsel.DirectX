using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIDEVICEOBJECTINSTANCE : IEquatable<DIDEVICEOBJECTINSTANCE>
{
    public int Size;

    public Guid GuidType;

    public int Ofs;

    public int Type;

    public DIDOI Flags;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string Name;

    public int FFMaxForce;

    public int FFForceResolution;

    public short CollectionNumber;

    public short DesignatorIndex;

    public short UsagePage;

    public short Usage;

    public int Dimension;

    public short Exponent;

    public short ReportId;

    public override bool Equals(object? obj)
    {
        return obj is DIDEVICEOBJECTINSTANCE dIDEVICEOBJECTINSTANCE && Equals(dIDEVICEOBJECTINSTANCE);
    }

    public bool Equals(DIDEVICEOBJECTINSTANCE other)
    {
        return Size == other.Size &&
               GuidType.Equals(other.GuidType) &&
               Ofs == other.Ofs &&
               Type == other.Type &&
               Flags == other.Flags &&
               Name == other.Name &&
               FFMaxForce == other.FFMaxForce &&
               FFForceResolution == other.FFForceResolution &&
               CollectionNumber == other.CollectionNumber &&
               DesignatorIndex == other.DesignatorIndex &&
               UsagePage == other.UsagePage &&
               Usage == other.Usage &&
               Dimension == other.Dimension &&
               Exponent == other.Exponent &&
               ReportId == other.ReportId;
    }

    public override int GetHashCode()
    {
        int hashCode = 626647449;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + GuidType.GetHashCode();
        hashCode = hashCode * -1521134295 + Ofs.GetHashCode();
        hashCode = hashCode * -1521134295 + Type.GetHashCode();
        hashCode = hashCode * -1521134295 + Flags.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        hashCode = hashCode * -1521134295 + FFMaxForce.GetHashCode();
        hashCode = hashCode * -1521134295 + FFForceResolution.GetHashCode();
        hashCode = hashCode * -1521134295 + CollectionNumber.GetHashCode();
        hashCode = hashCode * -1521134295 + DesignatorIndex.GetHashCode();
        hashCode = hashCode * -1521134295 + UsagePage.GetHashCode();
        hashCode = hashCode * -1521134295 + Usage.GetHashCode();
        hashCode = hashCode * -1521134295 + Dimension.GetHashCode();
        hashCode = hashCode * -1521134295 + Exponent.GetHashCode();
        hashCode = hashCode * -1521134295 + ReportId.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIDEVICEOBJECTINSTANCE left, DIDEVICEOBJECTINSTANCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDEVICEOBJECTINSTANCE left, DIDEVICEOBJECTINSTANCE right)
    {
        return !(left == right);
    }
}
