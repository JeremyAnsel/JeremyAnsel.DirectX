// <copyright file="WicComponentEnumerateOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicComponentEnumerateOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICComponentEnumerateDefault = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICComponentEnumerateRefresh = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICComponentEnumerateDisabled = 0x80000000,

    /// <summary>
    /// 
    /// </summary>
    WICComponentEnumerateUnsigned = 0x40000000,

    /// <summary>
    /// 
    /// </summary>
    WICComponentEnumerateBuiltInOnly = 0x20000000,
}
