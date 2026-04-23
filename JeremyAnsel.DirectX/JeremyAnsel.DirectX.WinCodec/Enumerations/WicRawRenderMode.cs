// <copyright file="WicRawRenderMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicRawRenderMode : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICRawRenderModeDraft = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICRawRenderModeNormal = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICRawRenderModeBestQuality = 0x00000003,
}
