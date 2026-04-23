// <copyright file="D2D1BitmapRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Renders to an intermediate texture created by the <see cref="D2D1RenderTarget.CreateCompatibleRenderTarget()"/> method.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1BitmapRenderTarget : D2D1RenderTarget
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1BitmapRenderTargetGuid = typeof(ID2D1BitmapRenderTarget).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1BitmapRenderTarget* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1BitmapRenderTarget"/> class.
    /// </summary>
    public D2D1BitmapRenderTarget(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1BitmapRenderTarget**)comPtr;
    }

    /// <summary>
    /// Gets the bitmap for this render target. The returned bitmap can be used for drawing operations.
    /// </summary>
    public D2D1Bitmap Bitmap
    {
        get
        {
            nint ptr;
            int hr = _comImpl->GetBitmap(_comPtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1Bitmap(ptr);
        }
    }
}
