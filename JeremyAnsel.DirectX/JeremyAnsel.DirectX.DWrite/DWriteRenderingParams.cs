// <copyright file="DWriteRenderingParams.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// The interface that represents text rendering settings for glyph rasterization and filtering.
    /// </summary>
    public sealed class DWriteRenderingParams : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite rendering params interface.
        /// </summary>
        private IDWriteRenderingParams handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteRenderingParams"/> class.
        /// </summary>
        /// <param name="handle">A DWrite rendering params interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteRenderingParams(object handle)
        {
            this.handle = (IDWriteRenderingParams)handle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteRenderingParams"/> class.
        /// </summary>
        /// <param name="handle">A DWrite rendering params interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteRenderingParams(IDWriteRenderingParams handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets an handle representing the DWrite object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle; }
        }

        /// <summary>
        /// Gets the gamma value used for gamma correction. Valid values must be
        /// greater than zero and cannot exceed 256.
        /// </summary>
        public float Gamma
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetGamma(); }
        }

        /// <summary>
        /// Gets the amount of contrast enhancement. Valid values are greater than
        /// or equal to zero.
        /// </summary>
        public float EnhancedContrast
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetEnhancedContrast(); }
        }

        /// <summary>
        /// Gets the ClearType level. Valid values range from 0.0f (no ClearType) 
        /// to 1.0f (full ClearType).
        /// </summary>
        public float ClearTypeLevel
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetClearTypeLevel(); }
        }

        /// <summary>
        /// Gets the pixel geometry.
        /// </summary>
        public DWritePixelGeometry PixelGeometry
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetPixelGeometry(); }
        }

        /// <summary>
        /// Gets the rendering mode.
        /// </summary>
        public DWriteRenderingMode RenderingMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetRenderingMode(); }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteRenderingParams value)
        {
            return value != null && value.handle != null;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the DWrite object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM DWrite interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.handle);
        }
    }
}
