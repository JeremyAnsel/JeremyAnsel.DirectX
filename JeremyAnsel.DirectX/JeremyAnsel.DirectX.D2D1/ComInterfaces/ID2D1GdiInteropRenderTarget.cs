// <copyright file="ID2D1GdiInteropRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Provides access to an device context that can accept GDI drawing commands.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("e0db51c3-6f77-4bae-b3d5-e47509b35838")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1GdiInteropRenderTarget
    {
        /// <summary>
        /// Retrieves the device context associated with this render target.
        /// </summary>
        /// <param name="mode">A value that specifies whether the device context should be cleared.</param>
        /// <param name="hdc">The device context associated with this render target.</param>
        void GetDC(
            [In] D2D1DCInitializeMode mode,
            [Out] out IntPtr hdc);

        /// <summary>
        /// Indicates that drawing with the device context retrieved using the <see cref="GetDC"/> method is finished.
        /// </summary>
        /// <param name="update">The modified region of the device context.</param>
        void ReleaseDC(
            [In] IntPtr update);
    }
}
