// <copyright file="DirectInputForceFeedbackCommands.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputForceFeedbackCommands : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Reset = 1,

    /// <summary>
    /// 
    /// </summary>
    StopAll = 2,

    /// <summary>
    /// 
    /// </summary>
    Pause = 4,

    /// <summary>
    /// 
    /// </summary>
    Continue = 8,

    /// <summary>
    /// 
    /// </summary>
    SetActuatorsOn = 16,

    /// <summary>
    /// 
    /// </summary>
    SetActuatorsOff = 32
}
