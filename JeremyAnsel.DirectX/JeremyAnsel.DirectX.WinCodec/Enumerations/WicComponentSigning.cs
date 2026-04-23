// <copyright file="WicComponentSigning.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicComponentSigning : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICComponentSigned = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICComponentUnsigned = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICComponentSafe = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICComponentDisabled = 0x80000000,
}
