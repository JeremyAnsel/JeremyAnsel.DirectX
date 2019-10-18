// <copyright file="ID2D1DrawingStateBlock.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;

    /// <summary>
    /// Represents the drawing state of a render target: the antialiasing mode, transform, tags, and text-rendering options.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("28506e39-ebf6-46a1-bb47-fd85565ab957")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1DrawingStateBlock
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory factory);

        /// <summary>
        /// Retrieves the antialiasing mode, transform, and tags portion of the drawing state.
        /// </summary>
        /// <param name="stateDescription">When this method returns, contains the antialiasing mode, transform, and tags portion of the drawing state.</param>
        [PreserveSig]
        void GetDescription(
            [Out] out D2D1DrawingStateDescription stateDescription);

        /// <summary>
        /// Specifies the antialiasing mode, transform, and tags portion of the drawing state.
        /// </summary>
        /// <param name="stateDescription">The antialiasing mode, transform, and tags portion of the drawing state.</param>
        [PreserveSig]
        void SetDescription(
            [In] ref D2D1DrawingStateDescription stateDescription);

        /// <summary>
        /// Specifies the text-rendering configuration of the drawing state.
        /// </summary>
        /// <param name="textRenderingParams">The text-rendering configuration of the drawing state, or NULL to use default settings.</param>
        [PreserveSig]
        void SetTextRenderingParams(
            [In] IDWriteRenderingParams textRenderingParams);

        /// <summary>
        /// Retrieves the text-rendering configuration of the drawing state.
        /// </summary>
        /// <param name="textRenderingParams">An <see cref="IDWriteRenderingParams"/> object that describes the text-rendering configuration of the drawing state.</param>
        [PreserveSig]
        void GetTextRenderingParams(
            [Out] out IDWriteRenderingParams textRenderingParams);
    }
}
