// <copyright file="IDWriteTextLayout.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInteropInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteTextLayout interface represents a block of text after it has
    /// been fully analyzed and formatted.
    /// All coordinates are in device independent pixels (DIPs).
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("53737037-6d14-410b-9bfe-0b182bb70961")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextLayout
    {
    }
}
