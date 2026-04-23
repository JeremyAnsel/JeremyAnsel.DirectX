// <copyright file="IDxgiDeviceSubObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// Inherited from objects that are tied to the device so that they can retrieve a pointer to it.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiObject"/></remarks>
[Guid("3d3e0379-f9de-4d58-bb6c-18d62992f1a6")]
internal unsafe readonly struct IDxgiDeviceSubObject
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;

    /// <summary>
    /// Retrieves the device.
    /// </summary>
    /// <param name="riid">The reference id for the device.</param>
    /// <returns>The address of a pointer to the device.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint*, int> GetDevice;
}
