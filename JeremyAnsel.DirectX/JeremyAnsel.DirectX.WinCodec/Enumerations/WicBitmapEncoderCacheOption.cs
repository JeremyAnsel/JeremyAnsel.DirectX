// <copyright file="WicBitmapEncoderCacheOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapEncoderCacheOption : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapEncoderCacheInMemory = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapEncoderCacheTempFile = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapEncoderNoCache = 0x00000002,
}
