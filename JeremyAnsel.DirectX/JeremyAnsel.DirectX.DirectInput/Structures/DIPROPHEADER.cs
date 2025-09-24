using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIPROPHEADER : IEquatable<DIPROPHEADER>
{
    public int Size;

    public int HeaderSize;

    public int Obj;

    public DIPH How;

    public override bool Equals(object? obj)
    {
        return obj is DIPROPHEADER dIPROPHEADER && Equals(dIPROPHEADER);
    }

    public bool Equals(DIPROPHEADER other)
    {
        return Size == other.Size &&
               HeaderSize == other.HeaderSize &&
               Obj == other.Obj &&
               How.Equals(other.How);
    }

    public override int GetHashCode()
    {
        int hashCode = -1567757132;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + HeaderSize.GetHashCode();
        hashCode = hashCode * -1521134295 + Obj.GetHashCode();
        hashCode = hashCode * -1521134295 + How.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIPROPHEADER left, DIPROPHEADER right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIPROPHEADER left, DIPROPHEADER right)
    {
        return !(left == right);
    }
}
