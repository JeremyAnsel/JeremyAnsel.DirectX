// <copyright file="DxgiSurface2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGISurface2</c> interface extends the <c>IDXGISurface1</c> interface by adding support for sub-resource surfaces and getting a handle to a shared resource.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiSurface2 : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiSurface2Guid = typeof(IDxgiSurface2).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiSurface2* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface2"/> class.
    /// </summary>
    public DxgiSurface2(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiSurface2**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface2"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>IDXGISurface2</c> interface.</param>
    public static DxgiSurface2 CreateSurfaceFromResource(DXComObject resource)
    {
        return CreateSurfaceFromResource(resource.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface2"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>IDXGISurface2</c> interface.</param>
    public static DxgiSurface2 CreateSurfaceFromResource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, DxgiSurface2Guid);
        return new DxgiSurface2(ptr);
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

    /// <summary>
    /// Returns a device context (DC) that allows you to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface using Windows Graphics Device Interface (GDI).
    /// </summary>
    /// <param name="discard">A value indicating whether to preserve Direct3D contents in the GDI DC.</param>
    /// <returns>An HDC handle that represents the current device context for GDI rendering.</returns>
    public nint GetDC(bool discard)
    {
        nint dc;
        int hr = _comImpl->GetDC(_comPtr, discard ? 1 : 0, &dc);
        Marshal.ThrowExceptionForHR(hr);
        return dc;
    }

    /// <summary>
    /// Releases the GDI device context (DC) that is associated with the current surface and allows you to use Direct3D to render.
    /// </summary>
    /// <param name="dirtyRect">A RECT structure that identifies the dirty region of the surface. A dirty region is any part of the surface that you used for GDI rendering and that you want to preserve. This area is used as a performance hint to graphics subsystem in certain scenarios. Do not use this parameter to restrict rendering to the specified rectangular region.</param>
    public void ReleaseDC(in DxgiRect? dirtyRect)
    {
        if (dirtyRect is null)
        {
            int hr = _comImpl->ReleaseDC(_comPtr, null);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            int size = DxgiRect.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            DxgiRect.NativeWriteTo((nint)ptr, dirtyRect.Value);
            int hr = _comImpl->ReleaseDC(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Gets the parent resource and subresource index that support a subresource surface.
    /// </summary>
    /// <param name="iid">The globally unique identifier (GUID) of the requested interface type.</param>
    /// <param name="subressourceIndex">A pointer to a variable that receives the index of the subresource surface.</param>
    /// <returns>A pointer to the parent resource object for the subresource surface.</returns>
    public nint GetResource(in Guid iid)
    {
        return GetResource(iid, out _);
    }

    /// <summary>
    /// Gets the parent resource and subresource index that support a subresource surface.
    /// </summary>
    /// <param name="iid">The globally unique identifier (GUID) of the requested interface type.</param>
    /// <param name="subressourceIndex">A pointer to a variable that receives the index of the subresource surface.</param>
    /// <returns>A pointer to the parent resource object for the subresource surface.</returns>
    public nint GetResource(in Guid iid, out uint subressourceIndex)
    {
        nint ptr;
        uint index;
        int hr = _comImpl->GetResource(_comPtr, iid, &ptr, &index);
        Marshal.ThrowExceptionForHR(hr);
        subressourceIndex = index;
        return ptr;
    }
}
