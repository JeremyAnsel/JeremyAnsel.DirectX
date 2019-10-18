// <copyright file="D3D11MapOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Specifies how the CPU should respond when an application calls the <see cref="D3D11DeviceContext.Map"/> method on a resource that is being used by the GPU.
    /// </summary>
    [Flags]
    public enum D3D11MapOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that <see cref="D3D11DeviceContext.Map"/> should return <see cref="JeremyAnsel.DirectX.Dxgi.DxgiError.WasStillDrawing"/> when the GPU blocks the CPU from accessing a resource. 
        /// </summary>
        DoNotWait = 0x00100000,
    }
}
