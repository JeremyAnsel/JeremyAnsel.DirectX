// <copyright file="WicTiffCompressionOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicTiffCompressionOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionDontCare = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionNone = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionCCITT3 = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionCCITT4 = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionLZW = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionRLE = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionZIP = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WICTiffCompressionLZWHDifferencing = 0x00000007,
}
