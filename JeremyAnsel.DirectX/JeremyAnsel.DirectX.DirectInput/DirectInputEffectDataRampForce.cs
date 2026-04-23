// <copyright file="DirectInputEffectDataRampForce.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputEffectDataRampForce : DirectInputEffectData
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectDataRampForce()
    {
    }

    internal DirectInputEffectDataRampForce(in DIRAMPFORCE di)
    {
        Start = di.Start;
        End = di.End;
    }

    internal DIRAMPFORCE ToDI()
    {
        DIRAMPFORCE di;
        di.Start = Start;
        di.End = End;
        return di;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Start { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int End { get; set; }
}
