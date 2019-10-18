// <copyright file="DxgiMapOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// CPU read-write options.
    /// </summary>
    [Flags]
    public enum DxgiMapOptions
    {
        /// <summary>
        ///  No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Allow CPU read access.
        /// </summary>
        Read = 1 << 0,

        /// <summary>
        /// Allow CPU write access.
        /// </summary>
        Write = 1 << 1,
        
        /// <summary>
        /// Discard the previous contents of a resource when it is mapped.
        /// </summary>
        Discard = 1 << 2
    }
}
