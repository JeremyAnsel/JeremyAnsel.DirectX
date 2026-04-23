// <copyright file="WicHeifHdrProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicHeifHdrProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICHeifHdrMaximumLuminanceLevel = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICHeifHdrMaximumFrameAverageLuminanceLevel = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICHeifHdrMinimumMasteringDisplayLuminanceLevel = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICHeifHdrMaximumMasteringDisplayLuminanceLevel = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICHeifHdrCustomVideoPrimaries = 0x00000005,
}
