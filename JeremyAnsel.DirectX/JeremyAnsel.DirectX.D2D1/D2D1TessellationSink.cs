// <copyright file="D2D1TessellationSink.cs" company="Jérémy Ansel">
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
    /// Populates an <see cref="D2D1Mesh"/> object with triangles.
    /// </summary>
    public sealed class D2D1TessellationSink : IDisposable, ID2D1Releasable
    {
        /// <summary>
        /// The D2D1 tessellation sink interface.
        /// </summary>
        private readonly ID2D1TessellationSink tessellationSink;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1TessellationSink"/> class.
        /// </summary>
        /// <param name="tessellationSink">A D2D1 tessellation sink interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1TessellationSink(ID2D1TessellationSink tessellationSink)
        {
            this.tessellationSink = tessellationSink;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.tessellationSink; }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D2D1 object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D2D1TessellationSink value)
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
        /// Immediately releases the unmanaged resources used by the <see cref="D2D1TessellationSink"/> object.
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
        /// Copies the specified triangles to the sink.
        /// </summary>
        /// <param name="triangles">An array of <see cref="D2D1Triangle"/> structures that describe the triangles to add to the sink.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddTriangles(D2D1Triangle[] triangles)
        {
            if (triangles == null)
            {
                throw new ArgumentNullException(nameof(triangles));
            }

            this.tessellationSink.AddTriangles(triangles, (uint)triangles.Length);
        }

        /// <summary>
        /// Closes the sink and returns its error status.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Close()
        {
            this.tessellationSink.Close();
        }
    }
}
