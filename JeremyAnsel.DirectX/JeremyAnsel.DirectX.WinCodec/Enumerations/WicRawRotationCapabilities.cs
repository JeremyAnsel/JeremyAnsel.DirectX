// <copyright file="WicRawRotationCapabilities.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicRawRotationCapabilities : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICRawRotationCapabilityNotSupported = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICRawRotationCapabilityGetSupported = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICRawRotationCapabilityNinetyDegreesSupported = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICRawRotationCapabilityFullySupported = 0x00000003,
}
