// <copyright file="D3D11AsyncGetDataOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Optional flags that control the behavior of <see cref="D3D11DeviceContext.GetData"/>.
    /// </summary>
    [Flags]
    public enum D3D11AsyncGetDataOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Do not flush the command buffer. This can potentially cause an infinite loop.
        /// </summary>
        DoNotFlush = 0x1,
    }
}
