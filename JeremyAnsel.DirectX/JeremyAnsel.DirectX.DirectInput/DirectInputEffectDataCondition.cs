// <copyright file="DirectInputEffectDataCondition.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputEffectDataCondition : DirectInputEffectData
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectDataCondition()
    {
    }

    internal DirectInputEffectDataCondition(in DICONDITION di)
    {
        Offset = di.Offset;
        PositiveCoefficient = di.PositiveCoefficient;
        NegativeCoefficient = di.NegativeCoefficient;
        PositiveSaturation = di.PositiveSaturation;
        NegativeSaturation = di.NegativeSaturation;
        DeadBand = di.DeadBand;
    }

    internal DICONDITION ToDI()
    {
        DICONDITION di;
        di.Offset = Offset;
        di.PositiveCoefficient = PositiveCoefficient;
        di.NegativeCoefficient = NegativeCoefficient;
        di.PositiveSaturation = PositiveSaturation;
        di.NegativeSaturation = NegativeSaturation;
        di.DeadBand = DeadBand;
        return di;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int PositiveCoefficient { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int NegativeCoefficient { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int PositiveSaturation { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int NegativeSaturation { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int DeadBand { get; set; }
}
