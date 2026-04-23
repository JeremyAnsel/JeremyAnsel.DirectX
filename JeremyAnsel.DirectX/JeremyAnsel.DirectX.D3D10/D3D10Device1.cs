// <copyright file="D3D10Device1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D10.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D10;

/// <summary>
/// The device interface represents a virtual adapter for Direct3D 10.1; it is used to perform rendering and create Direct3D resources.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D10Device1 : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D10Device1Guid = typeof(ID3D10Device1).GUID;

    private readonly nint _comPtr;
    private readonly ID3D10Device1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D10Device1"/> class.
    /// </summary>
    public D3D10Device1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D10Device1**)comPtr;
    }

    /// <summary>
    /// Gets the options used during the call to create the device.
    /// </summary>
    public D3D10CreateDeviceOptions CreationOptions
    {
        get { return _comImpl->GetCreationFlags(_comPtr); }
    }

    /// <summary>
    /// Gets the feature level of the hardware device.
    /// </summary>
    public D3D10FeatureLevel FeatureLevel
    {
        get { return _comImpl->GetFeatureLevel(_comPtr); }
    }

    /// <summary>
    /// Create a Direct3D 10.1 device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">Pointer to the display adapter when creating a hardware device; otherwise set this parameter to NULL.</param>
    /// <param name="driverType">The device-driver type.</param>
    /// <param name="options">Device creation options.</param>
    /// <param name="featureLevel">The version of hardware that is available for acceleration.</param>
    /// <returns><see cref="D3D10Device1"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static D3D10Device1 CreateDevice(
        nint adapter,
        D3D10DriverType driverType,
        D3D10CreateDeviceOptions options,
        D3D10FeatureLevel featureLevel)
    {
        nint ptr;
        int hr = NativeMethods.D3D10CreateDevice1(adapter, driverType, 0, options, featureLevel, 0x20, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D10Device1(ptr);
    }

    /// <summary>
    /// Gets the reason why the device was removed.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetDeviceRemovedReason()
    {
        return _comImpl->GetDeviceRemovedReason(_comPtr);
    }

    /// <summary>
    /// Give a device access to a shared resource created on a different Direct3d device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
    /// <returns>The resource we are gaining access to.</returns>
    public nint OpenSharedResource(nint resourceHandle, in Guid returnedInterface)
    {
        nint ptr;
        int hr = _comImpl->OpenSharedResource(_comPtr, resourceHandle, returnedInterface, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }
}
