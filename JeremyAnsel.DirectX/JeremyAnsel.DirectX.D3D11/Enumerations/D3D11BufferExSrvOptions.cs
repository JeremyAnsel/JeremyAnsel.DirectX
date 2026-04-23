// <copyright file="D3D11BufferExSrvOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Identifies how to view a buffer resource.
/// </summary>
[Flags]
public enum D3D11BufferExSrvOptions
{
    /// <summary>
    /// No option.
    /// </summary>
    None = 0,

    /// <summary>
    /// View the buffer as raw.
    /// </summary>
    Raw = 0x00000001,
}
