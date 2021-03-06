﻿// <copyright file="ID3D10Releasable.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    /// <summary>
    /// Defines a method to release the managed reference to the COM interface.
    /// </summary>
    public interface ID3D10Releasable
    {
        /// <summary>
        /// Immediately releases the unmanaged resources.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Releases the managed reference to the COM interface.
        /// </summary>
        void Release();
    }
}
