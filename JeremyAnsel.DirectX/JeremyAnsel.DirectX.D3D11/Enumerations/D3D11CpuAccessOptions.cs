// <copyright file="D3D11CpuAccessOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Specifies the types of CPU access allowed for a resource.
    /// </summary>
    [Flags]
    public enum D3D11CpuAccessOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// The resource is to be mappable so that the CPU can change its contents. Resources created with this flag cannot be set as outputs of the pipeline and must be created with either dynamic or staging usage.
        /// </summary>
        Write = 0x00010000,

        /// <summary>
        /// The resource is to be mappable so that the CPU can read its contents. Resources created with this flag cannot be set as either inputs or outputs to the pipeline and must be created with staging usage.
        /// </summary>
        Read = 0x00020000,
    }
}
