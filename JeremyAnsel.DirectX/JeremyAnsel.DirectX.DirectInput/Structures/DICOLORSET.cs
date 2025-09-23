using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DICOLORSET : IEquatable<DICOLORSET>
{
    public int Size;

    public uint TextFore;

    public uint TextHighlight;

    public uint CalloutLine;

    public uint CalloutHighlight;

    public uint Border;

    public uint ControlFill;

    public uint HighlightFill;

    public uint AreaFill;

    public override bool Equals(object? obj)
    {
        return obj is DICOLORSET dICOLORSET && Equals(dICOLORSET);
    }

    public bool Equals(DICOLORSET other)
    {
        return Size == other.Size &&
               TextFore == other.TextFore &&
               TextHighlight == other.TextHighlight &&
               CalloutLine == other.CalloutLine &&
               CalloutHighlight == other.CalloutHighlight &&
               Border == other.Border &&
               ControlFill == other.ControlFill &&
               HighlightFill == other.HighlightFill &&
               AreaFill == other.AreaFill;
    }

    public override int GetHashCode()
    {
        int hashCode = -421660555;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + TextFore.GetHashCode();
        hashCode = hashCode * -1521134295 + TextHighlight.GetHashCode();
        hashCode = hashCode * -1521134295 + CalloutLine.GetHashCode();
        hashCode = hashCode * -1521134295 + CalloutHighlight.GetHashCode();
        hashCode = hashCode * -1521134295 + Border.GetHashCode();
        hashCode = hashCode * -1521134295 + ControlFill.GetHashCode();
        hashCode = hashCode * -1521134295 + HighlightFill.GetHashCode();
        hashCode = hashCode * -1521134295 + AreaFill.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DICOLORSET left, DICOLORSET right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICOLORSET left, DICOLORSET right)
    {
        return !(left == right);
    }
}
