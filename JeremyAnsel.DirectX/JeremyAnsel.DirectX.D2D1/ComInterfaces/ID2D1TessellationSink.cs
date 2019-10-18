// <copyright file="ID2D1TessellationSink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Populates an <see cref="ID2D1Mesh"/> object with triangles.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906c1-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1TessellationSink
    {
        /// <summary>
        /// Copies the specified triangles to the sink.
        /// </summary>
        /// <param name="triangles">An array of <see cref="D2D1Triangle"/> structures that describe the triangles to add to the sink.</param>
        /// <param name="trianglesCount">The number of triangles to copy from the triangles array.</param>
        [PreserveSig]
        void AddTriangles(
            [In, MarshalAs(UnmanagedType.LPArray)] D2D1Triangle[] triangles,
            [In] uint trianglesCount);

        /// <summary>
        /// Closes the sink and returns its error status.
        /// </summary>
        void Close();
    }
}
