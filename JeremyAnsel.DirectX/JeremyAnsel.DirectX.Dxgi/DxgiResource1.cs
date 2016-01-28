// <copyright file="DxgiResource1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// An <c>IDXGIResource</c> interface allows resource sharing and identifies the memory that a resource resides in.
    /// </summary>
    public sealed class DxgiResource1 : DxgiDeviceSubObject
    {
        /// <summary>
        /// The DXGI resource interface.
        /// </summary>
        private IDxgiResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiResource1"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>IDxgiResource</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiResource1(object resource)
        {
            this.resource = (IDxgiResource)resource;
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
    }
}
