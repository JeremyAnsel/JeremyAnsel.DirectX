// <copyright file="DICUSTOMFORCE.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal struct DICUSTOMFORCE : IEquatable<DICUSTOMFORCE>
{
    public int Channels;

    public int SamplePeriod;

    public int Samples;

    public nint ForceData; // int[]

    public override bool Equals(object? obj)
    {
        return obj is DICUSTOMFORCE dICUSTOMFORCE && Equals(dICUSTOMFORCE);
    }

    public bool Equals(DICUSTOMFORCE other)
    {
        return Channels == other.Channels &&
               SamplePeriod == other.SamplePeriod &&
               Samples == other.Samples &&
               ForceData == other.ForceData;
    }

    public override int GetHashCode()
    {
        int hashCode = -1755654060;
        hashCode = hashCode * -1521134295 + Channels.GetHashCode();
        hashCode = hashCode * -1521134295 + SamplePeriod.GetHashCode();
        hashCode = hashCode * -1521134295 + Samples.GetHashCode();
        hashCode = hashCode * -1521134295 + ForceData.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DICUSTOMFORCE left, DICUSTOMFORCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DICUSTOMFORCE left, DICUSTOMFORCE right)
    {
        return !(left == right);
    }
}
