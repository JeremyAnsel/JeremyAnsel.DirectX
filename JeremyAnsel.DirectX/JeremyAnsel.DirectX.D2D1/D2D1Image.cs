// <copyright file="D2D1Image.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a producer of pixels that can fill an arbitrary 2D plane.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Image : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1ImageGuid = typeof(ID2D1Image).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Image* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Image"/> class.
    /// </summary>
    public D2D1Image(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Image**)comPtr;
    }
}
