using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DICONFIGUREDEVICESPARAMS : IEquatable<DICONFIGUREDEVICESPARAMS>
{
    public int Size;

    public int Users;

    public IntPtr UserNames;

    public int FormatsCount;

    [MarshalAs(UnmanagedType.LPArray)]
    public DIACTIONFORMAT[] Formats;

    public IntPtr hWnd;

    public DICOLORSET Dics;

    public IntPtr UnkDDSTarget;

    public override bool Equals(object? obj)
    {
        return obj is DICONFIGUREDEVICESPARAMS dICONFIGUREDEVICESPARAMS && Equals(dICONFIGUREDEVICESPARAMS);
    }

    public bool Equals(DICONFIGUREDEVICESPARAMS other)
    {
        return Size == other.Size &&
               Users == other.Users &&
               EqualityComparer<IntPtr>.Default.Equals(UserNames, other.UserNames) &&
               FormatsCount == other.FormatsCount &&
               EqualityComparer<DIACTIONFORMAT[]>.Default.Equals(Formats, other.Formats) &&
               EqualityComparer<IntPtr>.Default.Equals(hWnd, other.hWnd) &&
               Dics.Equals(other.Dics) &&
               EqualityComparer<IntPtr>.Default.Equals(UnkDDSTarget, other.UnkDDSTarget);
    }

    public override int GetHashCode()
    {
        int hashCode = -2077979303;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + Users.GetHashCode();
        hashCode = hashCode * -1521134295 + UserNames.GetHashCode();
        hashCode = hashCode * -1521134295 + FormatsCount.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<DIACTIONFORMAT[]>.Default.GetHashCode(Formats);
        hashCode = hashCode * -1521134295 + hWnd.GetHashCode();
        hashCode = hashCode * -1521134295 + Dics.GetHashCode();
        hashCode = hashCode * -1521134295 + UnkDDSTarget.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DICONFIGUREDEVICESPARAMS left, DICONFIGUREDEVICESPARAMS right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICONFIGUREDEVICESPARAMS left, DICONFIGUREDEVICESPARAMS right)
    {
        return !(left == right);
    }
}
