// <copyright file="WicPngTimeProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicPngTimeProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICPngTimeYear = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICPngTimeMonth = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICPngTimeDay = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICPngTimeHour = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICPngTimeMinute = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICPngTimeSecond = 0x00000006,
}
