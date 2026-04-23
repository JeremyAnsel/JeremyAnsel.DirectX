// <copyright file="D2D1DCRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Issues drawing commands to a GDI device context.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1DCRenderTarget : D2D1RenderTarget
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1DCRenderTargetGuid = typeof(ID2D1DCRenderTarget).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1DCRenderTarget* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1DCRenderTarget"/> class.
    /// </summary>
    public D2D1DCRenderTarget(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1DCRenderTarget**)comPtr;
    }

    /// <summary>
    /// Binds the render target to the device context to which it issues drawing commands.
    /// </summary>
    /// <param name="hdc">The device context to which the render target issues drawing commands.</param>
    /// <param name="subRect">The dimensions of the handle to a device context (HDC) to which the render target is bound.</param>
    public void BindDC(nint hdc, in D2D1RectL subRect)
    {
        int size = D2D1RectL.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectL.NativeWriteTo((nint)ptr, subRect);
        int hr = _comImpl->BindDC(_comPtr, hdc, ptr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
