// <copyright file="WicBitmapTransformOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicBitmapTransformOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapTransformRotate0 = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapTransformRotate90 = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapTransformRotate180 = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapTransformRotate270 = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapTransformFlipHorizontal = 0x00000008,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapTransformFlipVertical = 0x00000010,
}
