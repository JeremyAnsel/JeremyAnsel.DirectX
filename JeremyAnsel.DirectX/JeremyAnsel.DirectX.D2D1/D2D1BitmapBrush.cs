// <copyright file="D2D1BitmapBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// A bitmap brush allows a bitmap to be used to fill a geometry.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1BitmapBrush : D2D1Brush
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1BitmapBrushGuid = typeof(ID2D1BitmapBrush).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1BitmapBrush* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1BitmapBrush"/> class.
    /// </summary>
    public D2D1BitmapBrush(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1BitmapBrush**)comPtr;
    }

    /// <summary>
    /// Gets or sets the method by which the brush horizontally tiles those areas that extend past its bitmap.
    /// </summary>
    public D2D1ExtendMode ExtendModeX
    {
        get { return _comImpl->GetExtendModeX(_comPtr); }
        set { _comImpl->SetExtendModeX(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the method by which the brush vertically tiles those areas that extend past its bitmap.
    /// </summary>
    public D2D1ExtendMode ExtendModeY
    {
        get { return _comImpl->GetExtendModeY(_comPtr); }
        set { _comImpl->SetExtendModeY(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the interpolation method used when the brush bitmap is scaled or rotated.
    /// </summary>
    public D2D1BitmapInterpolationMode InterpolationMode
    {
        get { return _comImpl->GetInterpolationMode(_comPtr); }
        set { _comImpl->SetInterpolationMode(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the bitmap source that this brush uses to paint.
    /// </summary>
    public D2D1Bitmap Bitmap
    {
        get
        {
            nint ptr;
            _comImpl->GetBitmap(_comPtr, &ptr);
            return new D2D1Bitmap(ptr);
        }

        set
        {
            _comImpl->SetBitmap(_comPtr, value.Handle);
        }
    }
}
