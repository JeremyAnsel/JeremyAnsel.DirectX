// <copyright file="DirectInputObjectDataFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputObjectDataOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    FFActuator = 1,

    /// <summary>
    /// 
    /// </summary>
    FFEffectTrigger = 2,

    /// <summary>
    /// 
    /// </summary>
    Polled = 4,

    /// <summary>
    /// 
    /// </summary>
    AspectPosition = 8,

    /// <summary>
    /// 
    /// </summary>
    AspectVelocity = 16,

    /// <summary>
    /// 
    /// </summary>
    AspectAccel = 32,

    /// <summary>
    /// 
    /// </summary>
    AspectForce = 64,

    /// <summary>
    /// 
    /// </summary>
    AspectMask = 128,

    /// <summary>
    /// 
    /// </summary>
    GuidUsage = 256
}
