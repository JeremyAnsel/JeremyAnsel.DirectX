using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIEFFECT : IEquatable<DIEFFECT>
{
    public int Size;

    public DIEFF Flags;

    public int Duration;

    public int SamplePeriod;

    public int Gain;

    public int TriggerButton;

    public int TriggerRepeatInterval;

    public int AxesCount;

    [MarshalAs(UnmanagedType.LPArray)]
    public int[] Axes;

    [MarshalAs(UnmanagedType.LPArray)]
    public int[] Direction;

    public IntPtr Envelope;

    public int TypeSpecificParamsSize;

    public IntPtr TypeSpecificParams;

    public int StartDelay;

    public override bool Equals(object? obj)
    {
        return obj is DIEFFECT dIEFFECT && Equals(dIEFFECT);
    }

    public bool Equals(DIEFFECT other)
    {
        return Size == other.Size &&
               Flags.Equals(other.Flags) &&
               Duration == other.Duration &&
               SamplePeriod == other.SamplePeriod &&
               Gain == other.Gain &&
               TriggerButton == other.TriggerButton &&
               TriggerRepeatInterval == other.TriggerRepeatInterval &&
               AxesCount == other.AxesCount &&
               EqualityComparer<int[]>.Default.Equals(Axes, other.Axes) &&
               EqualityComparer<int[]>.Default.Equals(Direction, other.Direction) &&
               EqualityComparer<IntPtr>.Default.Equals(Envelope, other.Envelope) &&
               TypeSpecificParamsSize == other.TypeSpecificParamsSize &&
               EqualityComparer<IntPtr>.Default.Equals(TypeSpecificParams, other.TypeSpecificParams) &&
               StartDelay == other.StartDelay;
    }

    public override int GetHashCode()
    {
        int hashCode = -1355435142;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + Flags.GetHashCode();
        hashCode = hashCode * -1521134295 + Duration.GetHashCode();
        hashCode = hashCode * -1521134295 + SamplePeriod.GetHashCode();
        hashCode = hashCode * -1521134295 + Gain.GetHashCode();
        hashCode = hashCode * -1521134295 + TriggerButton.GetHashCode();
        hashCode = hashCode * -1521134295 + TriggerRepeatInterval.GetHashCode();
        hashCode = hashCode * -1521134295 + AxesCount.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(Axes);
        hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(Direction);
        hashCode = hashCode * -1521134295 + Envelope.GetHashCode();
        hashCode = hashCode * -1521134295 + TypeSpecificParamsSize.GetHashCode();
        hashCode = hashCode * -1521134295 + TypeSpecificParams.GetHashCode();
        hashCode = hashCode * -1521134295 + StartDelay.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIEFFECT left, DIEFFECT right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEFFECT left, DIEFFECT right)
    {
        return !(left == right);
    }
}
