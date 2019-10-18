// <copyright file="IWICBitmap.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInteropInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// WIC Bitmap cache interface
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("00000121-a8f2-4877-ba0a-fd2b6645fb94")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IWICBitmap
    {
    }
}
