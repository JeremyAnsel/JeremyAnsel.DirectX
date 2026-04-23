// <copyright file="WicNamedWhitePoint.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicNamedWhitePoint : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointDefault = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointDaylight = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointCloudy = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointShade = 0x00000008,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointTungsten = 0x00000010,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointFluorescent = 0x00000020,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointFlash = 0x00000040,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointUnderwater = 0x00000080,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointCustom = 0x00000100,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointAutoWhiteBalance = 0x00000200,

    /// <summary>
    /// 
    /// </summary>
    WICWhitePointAsShot = WICWhitePointDefault,
}
