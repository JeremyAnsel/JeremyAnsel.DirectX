using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIRAMPFORCE : IEquatable<DIRAMPFORCE>
{
    public int Start;

    public int End;

    public override bool Equals(object? obj)
    {
        return obj is DIRAMPFORCE dIRAMPFORCE && Equals(dIRAMPFORCE);
    }

    public bool Equals(DIRAMPFORCE other)
    {
        return Start == other.Start &&
               End == other.End;
    }

    public override int GetHashCode()
    {
        int hashCode = -1676728671;
        hashCode = hashCode * -1521134295 + Start.GetHashCode();
        hashCode = hashCode * -1521134295 + End.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIRAMPFORCE left, DIRAMPFORCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIRAMPFORCE left, DIRAMPFORCE right)
    {
        return !(left == right);
    }
}
