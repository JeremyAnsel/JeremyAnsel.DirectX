// <copyright file="D3D11RaiseOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Option(s) for raising an error to a non-continuable exception.
/// </summary>
[Flags]
public enum D3D11RaiseOptions
{
    /// <summary>
    /// No option.
    /// </summary>
    None = 0,

    /// <summary>
    /// Raise an internal driver error to a non-continuable exception.
    /// </summary>
    DriverInternalError = 0x1,
}
