// <copyright file="WicBitmapAlphaChannelOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapAlphaChannelOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapUseAlpha = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapUsePremultipliedAlpha = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapIgnoreAlpha = 0x00000002,
}
