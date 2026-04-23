// <copyright file="ID2D1BitmapBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// A bitmap brush allows a bitmap to be used to fill a geometry.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
[Guid("2cd906aa-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1BitmapBrush
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;
    private readonly nint SetOpacity;
    private readonly nint SetTransform;
    private readonly nint GetOpacity;
    private readonly nint GetTransform;

    /// <summary>
    /// Sets how the bitmap is to be treated outside of its natural extent on the X
    /// axis.
    /// </summary>
    /// <param name="extendModeX">A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1ExtendMode, void> SetExtendModeX;

    /// <summary>
    /// Sets how the bitmap is to be treated outside of its natural extent on the X
    /// axis.
    /// </summary>
    /// <param name="extendModeY">A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1ExtendMode, void> SetExtendModeY;

    /// <summary>
    /// Sets the interpolation mode used when this brush is used.
    /// </summary>
    /// <param name="interpolationMode">The interpolation mode used when the brush bitmap is scaled or rotated.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1BitmapInterpolationMode, void> SetInterpolationMode;

    /// <summary>
    /// Sets the bitmap associated as the source of this brush.
    /// </summary>
    /// <param name="bitmap">The bitmap source used by the brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> SetBitmap;

    /// <summary>
    /// Gets the method by which the brush horizontally tiles those areas that extend past its bitmap.
    /// </summary>
    /// <returns>A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1ExtendMode> GetExtendModeX;

    /// <summary>
    /// Gets the method by which the brush vertically tiles those areas that extend past its bitmap.
    /// </summary>
    /// <returns>A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1ExtendMode> GetExtendModeY;

    /// <summary>
    /// Gets the interpolation method used when the brush bitmap is scaled or rotated.
    /// </summary>
    /// <returns>The interpolation method used when the brush bitmap is scaled or rotated.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1BitmapInterpolationMode> GetInterpolationMode;

    /// <summary>
    /// Gets the bitmap source that this brush uses to paint.
    /// </summary>
    /// <param name="bitmap">The bitmap with which this brush paints.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetBitmap;
}
