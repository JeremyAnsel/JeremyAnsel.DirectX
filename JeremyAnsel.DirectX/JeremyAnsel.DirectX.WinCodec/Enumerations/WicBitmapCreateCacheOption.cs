// <copyright file="WicBitmapCreateCacheOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapCreateCacheOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapNoCache = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapCacheOnDemand = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapCacheOnLoad = 0x00000002,
}
