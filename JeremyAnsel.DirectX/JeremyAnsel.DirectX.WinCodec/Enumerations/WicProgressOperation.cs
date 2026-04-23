// <copyright file="WicProgressOperation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicProgressOperation : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICProgressOperationCopyPixels = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICProgressOperationWritePixels = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICProgressOperationAll = 0x0000FFFF,
}
