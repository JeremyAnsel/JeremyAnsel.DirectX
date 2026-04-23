// <copyright file="WicSectionAccessLevel.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicSectionAccessLevel : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICSectionAccessLevelRead = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICSectionAccessLevelReadWrite = 0x00000003,
}
