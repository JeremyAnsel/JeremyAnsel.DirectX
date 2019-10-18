// <copyright file="D2D1Resource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// The root interface for all resources in D2D.
    /// </summary>
    public abstract class D2D1Resource : IDisposable, ID2D1Releasable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Resource"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Resource()
        {
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public abstract object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D2D1 object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D2D1Resource value)
        {
            return value != null && value.Handle != null;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.Handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the <see cref="D2D1Resource"/> object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM D2D1 interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <returns>The factory that created this resource.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Factory GetFactory()
        {
            ID2D1Factory factory;
            this.GetHandle<ID2D1Resource>().GetFactory(out factory);
            return new D2D1Factory(factory);
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        /// <typeparam name="T">A D2D1 interface type.</typeparam>
        /// <returns>The D2D1 interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T GetHandle<T>()
        {
            return (T)this.Handle;
        }
    }
}
