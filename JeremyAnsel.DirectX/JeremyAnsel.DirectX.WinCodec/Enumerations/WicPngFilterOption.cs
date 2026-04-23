// <copyright file="WicPngFilterOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicPngFilterOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICPngFilterUnspecified = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICPngFilterNone = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICPngFilterSub = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICPngFilterUp = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICPngFilterAverage = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICPngFilterPaeth = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICPngFilterAdaptive = 0x00000006,
}
