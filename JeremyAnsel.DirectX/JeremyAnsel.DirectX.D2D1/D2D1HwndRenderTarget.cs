// <copyright file="D2D1HwndRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Renders drawing instructions to a window.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1HwndRenderTarget : D2D1RenderTarget
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1HwndRenderTargetGuid = typeof(ID2D1HwndRenderTarget).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1HwndRenderTarget* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1HwndRenderTarget"/> class.
    /// </summary>
    public D2D1HwndRenderTarget(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1HwndRenderTarget**)comPtr;
    }

    /// <summary>
    /// Gets the HWND associated with this render target.
    /// </summary>
    public nint Hwnd
    {
        get { return _comImpl->GetHwnd(_comPtr); }
    }

    /// <summary>
    /// Indicates whether the HWND associated with this render target is occluded.
    /// </summary>
    /// <returns>A value that indicates whether the HWND associated with this render target is occluded.</returns>
    public D2D1WindowStates CheckWindowState()
    {
        return _comImpl->CheckWindowState(_comPtr);
    }

    /// <summary>
    /// Changes the size of the render target to the specified pixel size.
    /// </summary>
    /// <param name="pixelSize">The new size of the render target in device pixels.</param>
    public void Resize(in D2D1SizeU pixelSize)
    {
        int size = D2D1SizeU.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1SizeU.NativeWriteTo((nint)ptr, pixelSize);
        int hr = _comImpl->Resize(_comPtr, ptr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
