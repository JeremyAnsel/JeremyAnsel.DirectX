// <copyright file="WicDdsAlphaMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicDdsAlphaMode : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICDdsAlphaModeUnknown = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICDdsAlphaModeStraight = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICDdsAlphaModePremultiplied = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICDdsAlphaModeOpaque = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICDdsAlphaModeCustom = 0x00000004,
}
