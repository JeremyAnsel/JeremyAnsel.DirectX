// <copyright file="DirectInputDeviceCapabilitiesOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputDeviceCapabilitiesOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Attached = 1,

    /// <summary>
    /// 
    /// </summary>
    PolledDevice = 2,

    /// <summary>
    /// 
    /// </summary>
    Emulated = 4,

    /// <summary>
    /// 
    /// </summary>
    PolledDataFormat = 8,

    /// <summary>
    /// 
    /// </summary>
    ForceFeedback = 16,

    /// <summary>
    /// 
    /// </summary>
    FFAttack = 32,

    /// <summary>
    /// 
    /// </summary>
    FFFade = 64,

    /// <summary>
    /// 
    /// </summary>
    Saturation = 128,

    /// <summary>
    /// 
    /// </summary>
    PosNegCoefficients = 256,

    /// <summary>
    /// 
    /// </summary>
    PosNegSaturation = 512,

    /// <summary>
    /// 
    /// </summary>
    DeadBand = 1024,

    /// <summary>
    /// 
    /// </summary>
    StartDelay = 2048,

    /// <summary>
    /// 
    /// </summary>
    Alias = 4096,

    /// <summary>
    /// 
    /// </summary>
    Phantom = 8192,

    /// <summary>
    /// 
    /// </summary>
    Hidden = 16384,
}
