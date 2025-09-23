using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIDEVCAPS : IEquatable<DIDEVCAPS>
{
    public int Size;

    public DIDC Flags;

    public int DevType;

    public int Axes;

    public int Buttons;

    public int POVs;

    public int FFSamplePeriod;

    public int FFMinTimeResolution;

    public int FirmwareRevision;

    public int HardwareRevision;

    public int FFDriverVersion;

    public override bool Equals(object? obj)
    {
        return obj is DIDEVCAPS dIDEVCAPS && Equals(dIDEVCAPS);
    }

    public bool Equals(DIDEVCAPS other)
    {
        return Size == other.Size &&
               Flags.Equals(other.Flags) &&
               DevType == other.DevType &&
               Axes == other.Axes &&
               Buttons == other.Buttons &&
               POVs == other.POVs &&
               FFSamplePeriod == other.FFSamplePeriod &&
               FFMinTimeResolution == other.FFMinTimeResolution &&
               FirmwareRevision == other.FirmwareRevision &&
               HardwareRevision == other.HardwareRevision &&
               FFDriverVersion == other.FFDriverVersion;
    }

    public override int GetHashCode()
    {
        int hashCode = -591285200;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + Flags.GetHashCode();
        hashCode = hashCode * -1521134295 + DevType.GetHashCode();
        hashCode = hashCode * -1521134295 + Axes.GetHashCode();
        hashCode = hashCode * -1521134295 + Buttons.GetHashCode();
        hashCode = hashCode * -1521134295 + POVs.GetHashCode();
        hashCode = hashCode * -1521134295 + FFSamplePeriod.GetHashCode();
        hashCode = hashCode * -1521134295 + FFMinTimeResolution.GetHashCode();
        hashCode = hashCode * -1521134295 + FirmwareRevision.GetHashCode();
        hashCode = hashCode * -1521134295 + HardwareRevision.GetHashCode();
        hashCode = hashCode * -1521134295 + FFDriverVersion.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIDEVCAPS left, DIDEVCAPS right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDEVCAPS left, DIDEVCAPS right)
    {
        return !(left == right);
    }
}
