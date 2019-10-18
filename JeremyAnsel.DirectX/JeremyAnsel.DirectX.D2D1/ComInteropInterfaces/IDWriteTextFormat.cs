// <copyright file="IDWriteTextFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInteropInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The format of text used for text layout.
    /// </summary>
    /// <remarks>
    /// This object may not be thread-safe and it may carry the state of text format change.
    /// </remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("9c906818-31d7-4fd3-a151-7c5e225db55a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextFormat
    {
    }
}
