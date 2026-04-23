// <copyright file="Wic8BIMResolutionInfoProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum Wic8BIMResolutionInfoProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoPString = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoHResolution = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoHResolutionUnit = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoWidthUnit = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoVResolution = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoVResolutionUnit = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WIC8BIMResolutionInfoHeightUnit = 0x00000007,
}
