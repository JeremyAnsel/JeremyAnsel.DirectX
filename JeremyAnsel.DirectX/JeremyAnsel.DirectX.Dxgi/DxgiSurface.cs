// <copyright file="DxgiSurface.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGISurface</c> interface implements methods for image-data objects.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiSurface : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiSurfaceGuid = typeof(IDxgiSurface).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiSurface* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface"/> class.
    /// </summary>
    public DxgiSurface(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiSurface**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>IDXGISurface</c> interface.</param>
    public static DxgiSurface CreateSurfaceFromResource(DXComObject resource)
    {
        return CreateSurfaceFromResource(resource.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>IDXGISurface</c> interface.</param>
    public static DxgiSurface CreateSurfaceFromResource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, DxgiSurfaceGuid);
        return new DxgiSurface(ptr);
    }

    /// <summary>
    /// Gets a description of the surface.
    /// </summary>
    public DxgiSurfaceDesc Description
    {
        get
        {
            int size = DxgiSurfaceDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiSurfaceDesc.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Get a pointer to the data contained in the surface, and deny GPU access to the surface.
    /// </summary>
    /// <param name="options">CPU read-write flags. These flags can be combined with a logical OR.</param>
    /// <returns>The surface data.</returns>
    public DxgiMappedRect Map(DxgiMapOptions options)
    {
        int size = DxgiMappedRect.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->Map(_comPtr, ptr, options);
        Marshal.ThrowExceptionForHR(hr);
        return DxgiMappedRect.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Invalidate the pointer to the surface retrieved by <c>IDXGISurface::Map</c> and re-enable GPU access to the resource.
    /// </summary>
    public void Unmap()
    {
        int hr = _comImpl->Unmap(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
