// <copyright file="WicJpegXLAnimProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicJpegXLAnimProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICJpegXLAnimLoopCount = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICJpegXLAnimFrameTicksPerSecondNumerator = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICJpegXLAnimFrameTicksPerSecondDenominator = 0x00000003,
}
