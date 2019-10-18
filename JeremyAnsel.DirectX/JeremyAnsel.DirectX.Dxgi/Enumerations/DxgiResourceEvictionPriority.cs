// <copyright file="DxgiResourceEvictionPriority.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Determines when a resource can be evicted from memory.
    /// </summary>
    public enum DxgiResourceEvictionPriority
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.
        /// </summary>
        Minimum = 0x28000000,

        /// <summary>
        /// The eviction priority of the resource is low. The placement of the resource is not critical, and minimal work is performed to find a location for the resource.
        /// </summary>
        Low = 0x50000000,

        /// <summary>
        /// The eviction priority of the resource is normal. The placement of the resource is important, but not critical, for performance. The resource is placed in its preferred location instead of a low-priority resource.
        /// </summary>
        Normal = 0x78000000,

        /// <summary>
        /// The eviction priority of the resource is high. The resource is placed in its preferred location instead of a low-priority or normal-priority resource.
        /// </summary>
        High = unchecked((int)0xa0000000),

        /// <summary>
        /// The resource is evicted from memory only if there is no other way of resolving the memory requirement.
        /// </summary>
        Maximum = unchecked((int)0xc8000000)
    }
}
