// <copyright file="WicPixelFormatNumericRepresentation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicPixelFormatNumericRepresentation : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatNumericRepresentationUnspecified = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatNumericRepresentationIndexed = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatNumericRepresentationUnsignedInteger = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatNumericRepresentationSignedInteger = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatNumericRepresentationFixed = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICPixelFormatNumericRepresentationFloat = 0x00000005,
}
