// <copyright file="DirectInputEffectParameterOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputEffectParameterOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Duration = 0x01,

    /// <summary>
    /// 
    /// </summary>
    SamplePeriod = 0x02,

    /// <summary>
    /// 
    /// </summary>
    Gain = 0x04,

    /// <summary>
    /// 
    /// </summary>
    TriggerButton = 0x08,

    /// <summary>
    /// 
    /// </summary>
    TriggerRepeatInterval = 0x10,

    /// <summary>
    /// 
    /// </summary>
    Axes = 0x20,

    /// <summary>
    /// 
    /// </summary>
    Direction = 0x40,

    /// <summary>
    /// 
    /// </summary>
    Envelope = 0x80,

    /// <summary>
    /// 
    /// </summary>
    TypeSpecificParams = 0x100,

    /// <summary>
    /// 
    /// </summary>
    StartDelay = 0x200,

    /// <summary>
    /// 
    /// </summary>
    AllParams = 0x3FF,

    /// <summary>
    /// 
    /// </summary>
    Start = 0x20000000,

    /// <summary>
    /// 
    /// </summary>
    NoRestart = 0x40000000,

    /// <summary>
    /// 
    /// </summary>
    NoDownload = 0x80000000,

    /// <summary>
    /// 
    /// </summary>
    NoTrigger = 0xFFFFFFFF
}
