// <copyright file="D3D11BufferUavOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Identifies unordered-access view options for a buffer resource.
    /// </summary>
    [Flags]
    public enum D3D11BufferUavOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Resource contains raw, unstructured data. Requires the UAV format to be <see cref="JeremyAnsel.DirectX.Dxgi.DxgiFormat"/>.
        /// </summary>
        Raw = 0x00000001,

        /// <summary>
        /// Allow data to be appended to the end of the buffer.
        /// </summary>
        Append = 0x00000002,

        /// <summary>
        /// Allow data to be appended to the end of the buffer.
        /// </summary>
        Counter = 0x00000004,
    }
}
