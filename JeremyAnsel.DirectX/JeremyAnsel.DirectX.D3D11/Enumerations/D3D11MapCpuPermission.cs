// <copyright file="D3D11MapCpuPermission.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Identifies a resource to be accessed for reading and writing by the CPU.
    /// </summary>
    public enum D3D11MapCpuPermission
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Resource is mapped for reading. The resource must have been created with read access.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Resource is mapped for writing. The resource must have been created with write access.
        /// </summary>
        Write = 2,

        /// <summary>
        /// Resource is mapped for reading and writing. The resource must have been created with read and write access.
        /// </summary>
        ReadWrite = 3,

        /// <summary>
        /// Resource is mapped for writing; the previous contents of the resource will be undefined. The resource must have been created with write access and dynamic usage.
        /// </summary>
        WriteDiscard = 4,

        /// <summary>
        /// Resource is mapped for writing; the existing contents of the resource cannot be overwritten (see Remarks). This flag is only valid on vertex and index buffers. The resource must have been created with write access.
        /// </summary>
        WriteNoOverwrite = 5,
    }
}
