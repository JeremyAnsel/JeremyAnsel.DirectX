// <copyright file="DxgiResource3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// An <c>IDXGIResource1</c> interface extends the <c>IDXGIResource</c> interface by adding support for creating a sub-resource surface object and for creating a handle to a shared resource.
    /// </summary>
    public sealed class DxgiResource3 : DxgiDeviceSubObject
    {
        /// <summary>
        /// The DXGI resource interface.
        /// </summary>
        private readonly IDxgiResource1 resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiResource3"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>IDxgiResource1</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiResource3(object resource)
        {
            this.resource = (IDxgiResource1)resource;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.resource; }
        }

        /// <summary>
        /// Gets the expected resource usage.
        /// </summary>
        public DxgiUsages Usage
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.resource.GetUsage();
            }
        }

        /// <summary>
        /// Gets or sets the eviction priority.
        /// </summary>
        public DxgiResourceEvictionPriority EvictionPriority
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.resource.GetEvictionPriority();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.resource.SetEvictionPriority(value);
            }
        }

        /// <summary>
        /// Gets the handle to a shared resource.
        /// </summary>
        /// <returns>A handle.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IntPtr GetSharedHandle()
        {
            return this.resource.GetSharedHandle();
        }

        /// <summary>
        /// Creates a sub-resource surface object.
        /// </summary>
        /// <param name="index">The index of the sub-resource surface object to enumerate.</param>
        /// <returns>A <c>IDXGISurface2</c> interface that represents the created sub-resource surface object at the position specified.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurface3 CreateSubresourceSurface(uint index)
        {
            IDxgiSurface2 surface = this.resource.CreateSubresourceSurface(index);

            if (surface == null)
            {
                return null;
            }

            return new DxgiSurface3(surface);
        }
    }
}
