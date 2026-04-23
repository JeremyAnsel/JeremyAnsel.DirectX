// <copyright file="WicBitmapInterpolationMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapInterpolationMode : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapInterpolationModeNearestNeighbor = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapInterpolationModeLinear = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapInterpolationModeCubic = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapInterpolationModeFant = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapInterpolationModeHighQualityCubic = 0x00000004,
}
