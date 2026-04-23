// <copyright file="WicBitmapChainType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapChainType : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_Alternate = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_Layer = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_Preview = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_Thumbnail = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_AlphaMap = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_DepthMap = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapChainType_GainMap = 0x00000007,
}
