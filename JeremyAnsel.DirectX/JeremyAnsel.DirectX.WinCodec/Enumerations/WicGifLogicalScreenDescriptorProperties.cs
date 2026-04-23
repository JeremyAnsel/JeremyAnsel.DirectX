// <copyright file="WicGifLogicalScreenDescriptorProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicGifLogicalScreenDescriptorProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenSignature = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorWidth = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorHeight = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorGlobalColorTableFlag = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorColorResolution = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorSortFlag = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorGlobalColorTableSize = 0x00000007,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorBackgroundColorIndex = 0x00000008,

    /// <summary>
    /// 
    /// </summary>
    WICGifLogicalScreenDescriptorPixelAspectRatio = 0x00000009,
}
