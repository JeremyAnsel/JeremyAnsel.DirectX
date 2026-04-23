// <copyright file="WicRawCapabilities.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicRawCapabilities : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICRawCapabilityNotSupported = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICRawCapabilityGetSupported = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICRawCapabilityFullySupported = 0x00000002,
}
