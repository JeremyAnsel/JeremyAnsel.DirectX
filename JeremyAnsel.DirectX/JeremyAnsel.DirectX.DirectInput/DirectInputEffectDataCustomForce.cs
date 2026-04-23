// <copyright file="DirectInputEffectDataCustomForce.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputEffectDataCustomForce : DirectInputEffectData
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectDataCustomForce()
    {
    }

    internal DirectInputEffectDataCustomForce(in DICUSTOMFORCE di)
    {
        Channels = di.Channels;
        SamplePeriod = di.SamplePeriod;

        ForceData = new int[di.Samples];
        nint buffer = di.ForceData;
        for (int i = 0; i < di.ForceData; i++)
        {
            ForceData[i] = DXMarshal.ReadInt32(ref buffer);
        }
    }

    internal DICUSTOMFORCE ToDI()
    {
        DICUSTOMFORCE di;
        di.Channels = Channels;
        di.SamplePeriod = SamplePeriod;
        di.Samples = ForceData.Length;
        di.ForceData = Marshal.UnsafeAddrOfPinnedArrayElement(ForceData, 0);
        return di;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Channels { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int SamplePeriod { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int[] ForceData { get; set; } = Array.Empty<int>();
}
