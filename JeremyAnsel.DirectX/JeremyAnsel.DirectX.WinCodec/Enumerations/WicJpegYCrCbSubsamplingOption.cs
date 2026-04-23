// <copyright file="WicJpegYCrCbSubsamplingOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicJpegYCrCbSubsamplingOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICJpegYCrCbSubsamplingDefault = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICJpegYCrCbSubsampling420 = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICJpegYCrCbSubsampling422 = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICJpegYCrCbSubsampling444 = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICJpegYCrCbSubsampling440 = 0x00000004,
}
