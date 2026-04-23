// <copyright file="D3D11CounterType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Options for performance counters.
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags", Justification = "Reviewed")]
public enum D3D11CounterType
{
    /// <summary>
    /// No option.
    /// </summary>
    None = 0,

    /// <summary>
    /// Define a performance counter that is dependent on the hardware device.
    /// </summary>
    DeviceDependent0 = 0x40000000,
}
