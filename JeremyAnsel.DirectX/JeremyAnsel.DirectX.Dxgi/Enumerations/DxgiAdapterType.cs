// <copyright file="DxgiAdapterType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Identifies the type of DXGI adapter.
    /// </summary>
    public enum DxgiAdapterType
    {
        /// <summary>
        /// Specifies no flags.
        /// </summary>
        None,

        /// <summary>
        /// Specifies a remote adapter.
        /// </summary>
        Remote,
        
        /// <summary>
        /// Specifies a software adapter.
        /// </summary>
        Software
    }
}
