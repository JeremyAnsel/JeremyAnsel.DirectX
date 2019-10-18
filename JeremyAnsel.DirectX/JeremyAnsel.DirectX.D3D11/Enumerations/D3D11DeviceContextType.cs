// <copyright file="D3D11DeviceContextType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Device context options.
    /// </summary>
    public enum D3D11DeviceContextType
    {
        /// <summary>
        /// The device context is an immediate context.
        /// </summary>
        Immediate,

        /// <summary>
        /// The device context is a deferred context.
        /// </summary>
        Deferred,
    }
}
