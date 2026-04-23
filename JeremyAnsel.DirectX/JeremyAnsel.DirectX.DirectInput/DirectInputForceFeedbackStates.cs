// <copyright file="DirectInputForceFeedbackStates.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputForceFeedbackStates : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Empty = 1,

    /// <summary>
    /// 
    /// </summary>
    Stopped = 2,

    /// <summary>
    /// 
    /// </summary>
    Paused = 4,

    /// <summary>
    /// 
    /// </summary>
    ActuatorsOn = 16,

    /// <summary>
    /// 
    /// </summary>
    ActuatorsOff = 32,

    /// <summary>
    /// 
    /// </summary>
    PowerOn = 64,

    /// <summary>
    /// 
    /// </summary>
    PowerOff = 128,

    /// <summary>
    /// 
    /// </summary>
    SafetySwitchOn = 256,

    /// <summary>
    /// 
    /// </summary>
    SafetySwitch = 512,

    /// <summary>
    /// 
    /// </summary>
    UserFFSwitchOn = 1024,

    /// <summary>
    /// 
    /// </summary>
    UserFFSwitchOff = 2048,

    /// <summary>
    /// 
    /// </summary>
    DeviceLost = 0x80000000
}
