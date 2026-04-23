// <copyright file="WicHeifCompressionOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicHeifCompressionOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionDontCare = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionNone = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionHEVC = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionAV1 = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionJpegXL = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionBrotli = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICHeifCompressionDeflate = 0x00000006,
}
