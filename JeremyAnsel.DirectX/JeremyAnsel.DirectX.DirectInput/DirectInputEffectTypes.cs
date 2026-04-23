// <copyright file="DirectInputEffectTypes.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputEffectTypes : uint
{
    /// <summary>
    /// 
    /// </summary>
    All = 0,

    /// <summary>
    /// 
    /// </summary>
    ConstantForce = 1,

    /// <summary>
    /// 
    /// </summary>
    RampForce = 2,

    /// <summary>
    /// 
    /// </summary>
    Periodic = 3,

    /// <summary>
    /// 
    /// </summary>
    Condition = 4,

    /// <summary>
    /// 
    /// </summary>
    CustomForce = 5,

    /// <summary>
    /// 
    /// </summary>
    Hardware = 0xFF,

    /// <summary>
    /// 
    /// </summary>
    FFAttack = 0x200,

    /// <summary>
    /// 
    /// </summary>
    FFFade = 0x400,

    /// <summary>
    /// 
    /// </summary>
    Saturation = 0x800,

    /// <summary>
    /// 
    /// </summary>
    PosNegCoefficients = 0x1000,

    /// <summary>
    /// 
    /// </summary>
    PosNegSaturation = 0x2000,

    /// <summary>
    /// 
    /// </summary>
    DeadBand = 0x4000,

    /// <summary>
    /// 
    /// </summary>
    StartDelay = 0x8000
}
