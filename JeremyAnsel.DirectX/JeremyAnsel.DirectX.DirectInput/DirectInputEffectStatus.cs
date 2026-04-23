// <copyright file="DirectInputEffectStatus.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputEffectStatus : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Playing = 1,

    /// <summary>
    /// 
    /// </summary>
    Enumated = 2
}
