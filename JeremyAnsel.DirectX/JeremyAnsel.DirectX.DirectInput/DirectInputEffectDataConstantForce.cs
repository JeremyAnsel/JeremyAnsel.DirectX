// <copyright file="DirectInputEffectDataConstantForce.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputEffectDataConstantForce : DirectInputEffectData
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectDataConstantForce()
    {
    }

    internal DirectInputEffectDataConstantForce(in DICONSTANTFORCE di)
    {
        Magnitude = di.Magnitude;
    }

    internal DICONSTANTFORCE ToDI()
    {
        DICONSTANTFORCE di;
        di.Magnitude = Magnitude;
        return di;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Magnitude { get; set; }
}
