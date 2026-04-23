// <copyright file="DirectInputEffectStartOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputEffectStartOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    Solo = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    NoDownload = 0x80000000
}
