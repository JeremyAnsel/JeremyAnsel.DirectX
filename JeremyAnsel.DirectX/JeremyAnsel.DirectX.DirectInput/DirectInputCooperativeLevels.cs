// <copyright file="DirectInputCooperativeLevels.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputCooperativeLevels : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Exclusive = 1,

    /// <summary>
    /// 
    /// </summary>
    NonExclusive = 2,

    /// <summary>
    /// 
    /// </summary>
    Foreground = 4,

    /// <summary>
    /// 
    /// </summary>
    Background = 8,

    /// <summary>
    /// 
    /// </summary>
    NoWinKey = 16
}
