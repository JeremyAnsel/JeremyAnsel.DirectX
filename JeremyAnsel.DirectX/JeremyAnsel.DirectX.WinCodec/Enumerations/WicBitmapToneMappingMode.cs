// <copyright file="WicBitmapToneMappingMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapToneMappingMode : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapToneMappingMode_None = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapToneMappingMode_Default = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapToneMappingMode_D2D = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapToneMappingMode_GainMap = 0x00000003,
}
