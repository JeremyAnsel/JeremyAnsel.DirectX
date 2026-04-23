// <copyright file="WicComponentType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicComponentType : uint
{
    /// <summary>
    /// 
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// 
    /// </summary>
    WICDecoder = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICEncoder = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatConverter = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICMetadataReader = 0x00000008,

    /// <summary>
    /// 
    /// </summary>
    WICMetadataWriter = 0x00000010,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormat = 0x00000020,

    /// <summary>
    /// 
    /// </summary>
    WICAllComponents = 0x0000003F,
}
