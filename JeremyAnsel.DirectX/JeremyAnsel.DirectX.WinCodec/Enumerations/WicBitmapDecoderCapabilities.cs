// <copyright file="WicBitmapDecoderCapabilities.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicBitmapDecoderCapabilities : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapDecoderCapabilitySameEncoder = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDecoderCapabilityCanDecodeAllImages = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDecoderCapabilityCanDecodeSomeImages = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDecoderCapabilityCanEnumerateMetadata = 0x00000008,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDecoderCapabilityCanDecodeThumbnail = 0x00000010,
}
