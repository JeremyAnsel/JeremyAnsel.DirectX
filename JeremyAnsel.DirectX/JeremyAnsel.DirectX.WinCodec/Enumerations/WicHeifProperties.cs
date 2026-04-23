// <copyright file="WicHeifProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicHeifProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICHeifOrientation = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICHeifLayeredImageCanvasColor = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICHeifLayeredImageLayerPositions = 0x00000003,
}
