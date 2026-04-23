// <copyright file="WicWin32GenericAccessRights.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicWin32GenericAccessRights : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    GenericAll = 0x10000000,

    /// <summary>
    /// 
    /// </summary>
    GenericExecute = 0x20000000,

    /// <summary>
    /// 
    /// </summary>
    GenericWrite = 0x40000000,

    /// <summary>
    /// 
    /// </summary>
    GenericRead = 0x80000000,
}
