// <copyright file="D3D11Usage.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Identifies expected resource use during rendering. The usage directly reflects whether a resource is accessible by the CPU and/or the graphics processing unit (GPU).
    /// </summary>
    public enum D3D11Usage
    {
        /// <summary>
        /// A resource that requires read and write access by the GPU.
        /// </summary>
        Default = 0,

        /// <summary>
        /// A resource that can only be read by the GPU. It cannot be written by the GPU, and cannot be accessed at all by the CPU.
        /// </summary>
        Immutable = 1,

        /// <summary>
        /// A resource that is accessible by both the GPU (read only) and the CPU (write only).
        /// </summary>
        Dynamic = 2,

        /// <summary>
        /// A resource that supports data transfer (copy) from the GPU to the CPU.
        /// </summary>
        Staging = 3,
    }
}
