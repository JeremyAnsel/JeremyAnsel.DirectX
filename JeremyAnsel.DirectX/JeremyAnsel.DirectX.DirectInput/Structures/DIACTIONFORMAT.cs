using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIACTIONFORMAT : IEquatable<DIACTIONFORMAT>
{
    public int Size;

    public int ActionSize;

    public int DataSize;

    public int NumActions;

    [MarshalAs(UnmanagedType.LPArray)]
    public DIACTION[] Action;

    public Guid ActionMap;

    public int Genre;

    public int BufferSize;

    public int AxisMin;

    public int AxisMax;

    public IntPtr InstString;

    public long TimeStamp;

    public int CRC;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string ActionMapName;

    public override bool Equals(object? obj)
    {
        return obj is DIACTIONFORMAT dIACTIONFORMAT && Equals(dIACTIONFORMAT);
    }

    public bool Equals(DIACTIONFORMAT other)
    {
        return Size == other.Size &&
               ActionSize == other.ActionSize &&
               DataSize == other.DataSize &&
               NumActions == other.NumActions &&
               EqualityComparer<DIACTION[]>.Default.Equals(Action, other.Action) &&
               ActionMap.Equals(other.ActionMap) &&
               Genre == other.Genre &&
               BufferSize == other.BufferSize &&
               AxisMin == other.AxisMin &&
               AxisMax == other.AxisMax &&
               EqualityComparer<IntPtr>.Default.Equals(InstString, other.InstString) &&
               TimeStamp == other.TimeStamp &&
               CRC == other.CRC &&
               ActionMapName == other.ActionMapName;
    }

    public override int GetHashCode()
    {
        int hashCode = -580415518;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + ActionSize.GetHashCode();
        hashCode = hashCode * -1521134295 + DataSize.GetHashCode();
        hashCode = hashCode * -1521134295 + NumActions.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<DIACTION[]>.Default.GetHashCode(Action);
        hashCode = hashCode * -1521134295 + ActionMap.GetHashCode();
        hashCode = hashCode * -1521134295 + Genre.GetHashCode();
        hashCode = hashCode * -1521134295 + BufferSize.GetHashCode();
        hashCode = hashCode * -1521134295 + AxisMin.GetHashCode();
        hashCode = hashCode * -1521134295 + AxisMax.GetHashCode();
        hashCode = hashCode * -1521134295 + InstString.GetHashCode();
        hashCode = hashCode * -1521134295 + TimeStamp.GetHashCode();
        hashCode = hashCode * -1521134295 + CRC.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ActionMapName);
        return hashCode;
    }

    public static bool operator ==(DIACTIONFORMAT left, DIACTIONFORMAT right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIACTIONFORMAT left, DIACTIONFORMAT right)
    {
        return !(left == right);
    }
}
