// <copyright file="DIEFFECT.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

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

    public nint Axes; // int[]

    public nint Direction; // int[]

    public nint Envelope;

    public int TypeSpecificParamsSize;

    public nint TypeSpecificParams;

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
               Axes == other.Axes &&
               Direction == other.Direction &&
               Envelope == other.Envelope &&
               TypeSpecificParamsSize == other.TypeSpecificParamsSize &&
               TypeSpecificParams == other.TypeSpecificParams &&
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
        hashCode = hashCode * -1521134295 + Axes.GetHashCode();
        hashCode = hashCode * -1521134295 + Direction.GetHashCode();
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
