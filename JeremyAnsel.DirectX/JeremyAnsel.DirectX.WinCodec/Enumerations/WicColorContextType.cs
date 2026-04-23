// <copyright file="WicColorContextType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicColorContextType : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICColorContextUninitialized = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICColorContextProfile = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICColorContextExifColorSpace = 0x00000002,
}
