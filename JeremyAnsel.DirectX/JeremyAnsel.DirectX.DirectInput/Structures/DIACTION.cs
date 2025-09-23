using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIACTION : IEquatable<DIACTION>
{
    public IntPtr AppData;

    public int Semantic;

    public DIA Flags;

    [MarshalAs(UnmanagedType.LPWStr)]
    public string ActionName;

    public Guid Instance;

    public int ObjID;

    public DIAH dwHow;

    public override bool Equals(object? obj)
    {
        return obj is DIACTION dIACTION && Equals(dIACTION);
    }

    public bool Equals(DIACTION other)
    {
        return EqualityComparer<IntPtr>.Default.Equals(AppData, other.AppData) &&
               Semantic == other.Semantic &&
               Flags.Equals(other.Flags) &&
               ActionName == other.ActionName &&
               Instance.Equals(other.Instance) &&
               ObjID == other.ObjID &&
               dwHow.Equals(other.dwHow);
    }

    public override int GetHashCode()
    {
        int hashCode = 1043408259;
        hashCode = hashCode * -1521134295 + AppData.GetHashCode();
        hashCode = hashCode * -1521134295 + Semantic.GetHashCode();
        hashCode = hashCode * -1521134295 + Flags.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ActionName);
        hashCode = hashCode * -1521134295 + Instance.GetHashCode();
        hashCode = hashCode * -1521134295 + ObjID.GetHashCode();
        hashCode = hashCode * -1521134295 + dwHow.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIACTION left, DIACTION right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIACTION left, DIACTION right)
    {
        return !(left == right);
    }
}
