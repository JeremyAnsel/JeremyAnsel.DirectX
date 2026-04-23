// <copyright file="D2D1SolidColorBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Paints an area with a solid color.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1SolidColorBrush : D2D1Brush
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1SolidColorBrushGuid = typeof(ID2D1SolidColorBrush).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1SolidColorBrush* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1SolidColorBrush"/> class.
    /// </summary>
    public D2D1SolidColorBrush(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1SolidColorBrush**)comPtr;
    }

    /// <summary>
    /// Gets or sets the color of the solid color brush.
    /// </summary>
    public D2D1ColorF Color
    {
        get
        {
            int size = D2D1ColorF.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetColor(_comPtr, ptr);
            return D2D1ColorF.NativeReadFrom((nint)ptr);
        }

        set
        {
            int size = D2D1ColorF.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D2D1ColorF.NativeWriteTo((nint)ptr, value);
            _comImpl->SetColor(_comPtr, ptr);
        }
    }
}
