// <copyright file="DxgiResidency.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Indicates the memory location of a resource.
    /// </summary>
    public enum DxgiResidency
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The resource is located in video memory.
        /// </summary>
        FullyResident,

        /// <summary>
        /// At least some of the resource is located in CPU memory.
        /// </summary>
        ResidentInSharedMemory,

        /// <summary>
        /// At least some of the resource has been paged out to the hard drive.
        /// </summary>
        EvictedToDisk
    }
}
