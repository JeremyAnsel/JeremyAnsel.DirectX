// <copyright file="IDxgiAdapter2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGIAdapter2</c> interface represents a display sub-system, which includes one or more GPUs, DACs, and video memory.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiAdapter1"/></remarks>
[Guid("0AA1AE0A-FA0E-4B84-8644-E05FF8E5ACB5")]
internal unsafe readonly struct IDxgiAdapter2
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

    /// <summary>
    /// Gets a Microsoft DirectX Graphics Infrastructure (DXGI) 1.2 description of an adapter or video card. This description includes information about the granularity at which the graphics processing unit (GPU) can be preempted from performing its current task.
    /// </summary>
    /// <returns>A <c>DXGI_ADAPTER_DESC2</c> structure that describes the adapter.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc2;
}
