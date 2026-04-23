// <copyright file="WicBitmapPaletteType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapPaletteType : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeCustom = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeMedianCut = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedBW = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone8 = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone27 = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone64 = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone125 = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone216 = 0x00000007,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedWebPalette = WICBitmapPaletteTypeFixedHalftone216,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone252 = 0x00000008,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedHalftone256 = 0x00000009,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedGray4 = 0x0000000A,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedGray16 = 0x0000000B,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapPaletteTypeFixedGray256 = 0x0000000C,
}
