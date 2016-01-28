// <copyright file="DxgiKeyedMutex.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// Represents a keyed mutex, which allows exclusive access to a shared resource that is used by multiple devices.
    /// </summary>
    public sealed class DxgiKeyedMutex : DxgiDeviceSubObject
    {
        /// <summary>
        /// The DXGI keyed mutex interface.
        /// </summary>
        private IDxgiKeyedMutex keyedMutex;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiKeyedMutex"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>IDXGIKeyedMutex</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiKeyedMutex(object resource)
        {
            this.keyedMutex = (IDxgiKeyedMutex)resource;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.keyedMutex; }
        }

        /// <summary>
        /// Using a key, acquires exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="key">A value that indicates which device to give access to.</param>
        /// <param name="milliseconds">The time-out interval, in milliseconds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AcquireSync(ulong key, uint milliseconds)
        {
            this.keyedMutex.AcquireSync(key, milliseconds);
        }

        /// <summary>
        /// Using a key, releases exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="key">A value that indicates which device to give access to.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseSync(ulong key)
        {
            this.keyedMutex.ReleaseSync(key);
        }
    }
}
