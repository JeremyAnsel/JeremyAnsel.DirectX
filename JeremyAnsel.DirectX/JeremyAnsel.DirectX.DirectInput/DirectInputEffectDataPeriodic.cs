// <copyright file="DirectInputEffectDataPeriodic.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputEffectDataPeriodic : DirectInputEffectData
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectDataPeriodic()
    {
    }

    internal DirectInputEffectDataPeriodic(in DIPERIODIC di)
    {
        Magnitude = di.Magnitude;
        Offset = di.Offset;
        Phase = di.Phase;
        Period = di.Period;
    }

    internal DIPERIODIC ToDI()
    {
        DIPERIODIC di;
        di.Magnitude = Magnitude;
        di.Offset = Offset;
        di.Phase = Phase;
        di.Period = Period;
        return di;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Magnitude { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Phase { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Period { get; set; }
}
