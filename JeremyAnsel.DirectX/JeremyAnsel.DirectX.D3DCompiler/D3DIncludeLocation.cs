// <copyright file="D3DIncludeLocation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler;

/// <summary>
/// Values that indicate the location of a shader #include file.
/// </summary>
internal enum D3DIncludeLocation
{
    /// <summary>
    /// The local directory.
    /// </summary>
    Local,

    /// <summary>
    /// The system directory.
    /// </summary>
    System
}
