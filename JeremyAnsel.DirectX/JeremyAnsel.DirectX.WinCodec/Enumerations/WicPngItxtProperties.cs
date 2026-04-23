// <copyright file="WicPngItxtProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicPngItxtProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICPngItxtKeyword = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICPngItxtCompressionFlag = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICPngItxtLanguageTag = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICPngItxtTranslatedKeyword = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICPngItxtText = 0x00000005,
}
