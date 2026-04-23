// <copyright file="DirectInputDefaultEffectType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public enum DirectInputDefaultEffectType : uint
{
    /// <summary>
    /// 
    /// </summary>
    Unknown,

    /// <summary>
    /// 
    /// </summary>
    ConstantForce,

    /// <summary>
    /// 
    /// </summary>
    RampForce,

    /// <summary>
    /// 
    /// </summary>
    Square,

    /// <summary>
    /// 
    /// </summary>
    Sine,

    /// <summary>
    /// 
    /// </summary>
    Triangle,

    /// <summary>
    /// 
    /// </summary>
    SawtoothUp,

    /// <summary>
    /// 
    /// </summary>
    SawtoothDown,

    /// <summary>
    /// 
    /// </summary>
    Spring,

    /// <summary>
    /// 
    /// </summary>
    Damper,

    /// <summary>
    /// 
    /// </summary>
    Inertia,

    /// <summary>
    /// 
    /// </summary>
    Friction,

    /// <summary>
    /// 
    /// </summary>
    CustomForce
}
