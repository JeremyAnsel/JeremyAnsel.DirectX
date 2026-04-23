// <copyright file="WicJpegIndexingOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicJpegIndexingOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICJpegIndexingOptionsGenerateOnDemand = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICJpegIndexingOptionsGenerateOnLoad = 0x00000001,
}
