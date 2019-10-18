// <copyright file="ID2D1Releasable.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Defines a method to release the managed reference to the COM interface.
    /// </summary>
    public interface ID2D1Releasable
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
