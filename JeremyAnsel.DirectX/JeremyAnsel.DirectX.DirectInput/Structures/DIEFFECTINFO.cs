using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIEFFECTINFO : IEquatable<DIEFFECTINFO>
{
    public int Size;

    public Guid guid;

    public DIEFT EffType;

    public DIEP StaticParams;

    public DIEP DynamicParams;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string Name;

    public override bool Equals(object? obj)
    {
        return obj is DIEFFECTINFO dIEFFECTINFO && Equals(dIEFFECTINFO);
    }

    public bool Equals(DIEFFECTINFO other)
    {
        return Size == other.Size &&
               guid.Equals(other.guid) &&
               EffType.Equals(other.EffType) &&
               StaticParams.Equals(other.StaticParams) &&
               DynamicParams.Equals(other.DynamicParams) &&
               Name == other.Name;
    }

    public override int GetHashCode()
    {
        int hashCode = 330398071;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + guid.GetHashCode();
        hashCode = hashCode * -1521134295 + EffType.GetHashCode();
        hashCode = hashCode * -1521134295 + StaticParams.GetHashCode();
        hashCode = hashCode * -1521134295 + DynamicParams.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        return hashCode;
    }

    public static bool operator ==(DIEFFECTINFO left, DIEFFECTINFO right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEFFECTINFO left, DIEFFECTINFO right)
    {
        return !(left == right);
    }
}
