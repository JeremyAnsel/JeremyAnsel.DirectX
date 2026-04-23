// <copyright file="WicJpegScanType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicJpegScanType : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICJpegScanTypeInterleaved = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICJpegScanTypePlanarComponents = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICJpegScanTypeProgressive = 0x00000002,
}
