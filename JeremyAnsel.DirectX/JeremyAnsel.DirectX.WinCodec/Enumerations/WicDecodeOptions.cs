// <copyright file="WicDecodeOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicDecodeOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICDecodeMetadataCacheOnDemand = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICDecodeMetadataCacheOnLoad = 0x00000001,
}
