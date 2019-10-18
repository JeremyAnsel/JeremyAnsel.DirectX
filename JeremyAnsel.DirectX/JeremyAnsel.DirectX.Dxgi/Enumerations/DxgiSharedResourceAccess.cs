// <copyright file="DxgiSharedResourceAccess.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// The shared resource accesses options.
    /// </summary>
    public enum DxgiSharedResourceAccess
    {
        /// <summary>
        /// Unspecified access
        /// </summary>
        Unspecified,

        /// <summary>
        /// Read access to the resource.
        /// </summary>
        Read = unchecked((int)0x80000000),

        /// <summary>
        /// Write access to the resource.
        /// </summary>
        Write = 1
    }
}
