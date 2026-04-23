// <copyright file="WicGifImageDescriptorProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicGifImageDescriptorProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorLeft = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorTop = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorWidth = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorHeight = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorLocalColorTableFlag = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorInterlaceFlag = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorSortFlag = 0x00000007,

    /// <summary>
    /// 
    /// </summary>
    WICGifImageDescriptorLocalColorTableSize = 0x00000008,
}
