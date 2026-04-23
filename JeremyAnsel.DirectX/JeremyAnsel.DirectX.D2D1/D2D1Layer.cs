// <copyright file="D2D1Layer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents the backing store required to render a layer.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Layer : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1LayerGuid = typeof(ID2D1Layer).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Layer* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Layer"/> class.
    /// </summary>
    public D2D1Layer(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Layer**)comPtr;
    }

    /// <summary>
    /// Gets the size of the layer in device-independent pixels.
    /// </summary>
    public D2D1SizeF Size
    {
        get
        {
            int size = D2D1SizeF.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetSize(_comPtr, ptr);
            return D2D1SizeF.NativeReadFrom((nint)ptr);
        }
    }
}
