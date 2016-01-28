// <copyright file="IDxgiReleasable.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Defines a method to release the managed reference to the COM interface.
    /// </summary>
    public interface IDxgiReleasable
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
