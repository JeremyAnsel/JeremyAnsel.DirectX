// <copyright file="WicD2D1AlphaMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// Qualifies how alpha is to be treated in a bitmap or render target containing alpha.
/// </summary>
public enum WicD2D1AlphaMode
{
    /// <summary>
    /// Alpha mode should be determined implicitly. Some target surfaces do not supply
    /// or imply this information in which case alpha must be specified.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Treat the alpha as pre multipled.
    /// </summary>
    Premultiplied = 1,

    /// <summary>
    /// Opacity is in the 'A' component only.
    /// </summary>
    Straight = 2,

    /// <summary>
    /// Ignore any alpha channel information.
    /// </summary>
    Ignore = 3,
}
