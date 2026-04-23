// <copyright file="DirectInputEffectEnvelope.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputEffectEnvelope
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectEnvelope()
    {
    }

    internal DirectInputEffectEnvelope(in DIENVELOPE di)
    {
        AttackLevel = di.AttackLevel;
        AttackTime = di.AttackTime;
        FadeLevel = di.FadeLevel;
        FadeTime = di.FadeTime;
    }

    internal DIENVELOPE ToDI()
    {
        DIENVELOPE di;
        di.Size = Marshal.SizeOf<DIENVELOPE>();
        di.AttackLevel = AttackLevel;
        di.AttackTime = AttackTime;
        di.FadeLevel = FadeLevel;
        di.FadeTime = FadeTime;
        return di;
    }

    /// <summary>
    /// 
    /// </summary>
    public int AttackLevel { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int AttackTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int FadeLevel { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int FadeTime { get; set; }
}
