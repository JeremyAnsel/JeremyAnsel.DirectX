// <copyright file="DxgiCpuAccess.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// CPU data access patterns.
    /// </summary>
    public enum DxgiCpuAccess
    {
        /// <summary>
        /// Maps should be validated to fail on this access.
        /// </summary>
        None,

        /// <summary>
        /// Frequent CPU write-only access, high-performance GPU read-only access.
        /// </summary>
        Dynamic,

        /// <summary>
        /// Frequent CPU read/write access, non-optimal GPU read-only access.
        /// </summary>
        ReadWrite,

        /// <summary>
        /// Frequent CPU read/write access, no GPU access.
        /// </summary>
        Scratch
    }
}
