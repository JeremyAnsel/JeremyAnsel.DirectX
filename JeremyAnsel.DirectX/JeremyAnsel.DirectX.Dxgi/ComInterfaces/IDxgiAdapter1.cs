// <copyright file="IDxgiAdapter1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGIAdapter1</c> interface represents a display sub-system (including one or more GPU's, DACs and video memory).
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiAdapter"/></remarks>
[Guid("29038f61-3839-4626-91fd-086879011a05")]
internal unsafe readonly struct IDxgiAdapter1
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;

    /// <summary>
    /// Enumerate adapter (video card) outputs.
    /// </summary>
    /// <param name="uindex">The index of the output.</param>
    /// <param name="output">The address of a pointer to an <c>IDXGIOutput</c> interface at the position specified by the Output parameter.</param>
    /// <returns>A code that indicates success or failure. Will return <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than the number of outputs.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> EnumOutputs;

    /// <summary>
    /// Gets a DXGI 1.0 description of an adapter (or video card).
    /// </summary>
    /// <returns>A <c>DXGI_ADAPTER_DESC</c> structure that describes the adapter.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc;

    /// <summary>
    /// Checks whether the system supports a device interface for a graphics component.
    /// </summary>
    /// <param name="name">The GUID of the interface of the device version for which support is being checked.</param>
    /// <param name="umdVersion">The user mode driver version of interface's name.</param>
    /// <returns><value>S_OK</value> indicates that the interface is supported, otherwise <value>DXGI_ERROR_UNSUPPORTED</value>.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, long*, int> CheckInterfaceSupport;

    /// <summary>
    /// Gets a DXGI 1.1 description of an adapter (or video card).
    /// </summary>
    /// <returns>A <c>DXGI_ADAPTER_DESC1</c> structure that describes the adapter.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc1;
}
