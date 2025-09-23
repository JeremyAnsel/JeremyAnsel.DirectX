using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIENVELOPE : IEquatable<DIENVELOPE>
{
    public int Size;

    public int AttackLevel;

    public int AttackTime;

    public int FadeLevel;

    public int FadeTime;

    public override bool Equals(object? obj)
    {
        return obj is DIENVELOPE dIENVELOPE && Equals(dIENVELOPE);
    }

    public bool Equals(DIENVELOPE other)
    {
        return Size == other.Size &&
               AttackLevel == other.AttackLevel &&
               AttackTime == other.AttackTime &&
               FadeLevel == other.FadeLevel &&
               FadeTime == other.FadeTime;
    }

    public override int GetHashCode()
    {
        int hashCode = 1378668122;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + AttackLevel.GetHashCode();
        hashCode = hashCode * -1521134295 + AttackTime.GetHashCode();
        hashCode = hashCode * -1521134295 + FadeLevel.GetHashCode();
        hashCode = hashCode * -1521134295 + FadeTime.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIENVELOPE left, DIENVELOPE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIENVELOPE left, DIENVELOPE right)
    {
        return !(left == right);
    }
}
