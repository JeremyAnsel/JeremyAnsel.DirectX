// <copyright file="WicBitmapLockFlags.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicBitmapLockFlags : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapLockRead = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapLockWrite = 0x00000002,
}
