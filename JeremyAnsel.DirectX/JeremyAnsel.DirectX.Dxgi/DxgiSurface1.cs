// <copyright file="DxgiSurface1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGISurface1</c> interface extends the <c>IDXGISurface</c> by adding support for using Windows Graphics Device Interface (GDI) to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiSurface1 : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiSurface1Guid = typeof(IDxgiSurface1).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiSurface1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface1"/> class.
    /// </summary>
    public DxgiSurface1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiSurface1**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface1"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>IDXGISurface1</c> interface.</param>
    public static DxgiSurface1 CreateSurfaceFromResource(DXComObject resource)
    {
        return CreateSurfaceFromResource(resource.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSurface1"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>IDXGISurface1</c> interface.</param>
    public static DxgiSurface1 CreateSurfaceFromResource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, DxgiSurface1Guid);
        return new DxgiSurface1(ptr);
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
}
