// <copyright file="WicGifGraphicControlExtensionProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicGifGraphicControlExtensionProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICGifGraphicControlExtensionDisposal = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICGifGraphicControlExtensionUserInputFlag = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICGifGraphicControlExtensionTransparencyFlag = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICGifGraphicControlExtensionDelay = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICGifGraphicControlExtensionTransparentColorIndex = 0x00000005,
}
