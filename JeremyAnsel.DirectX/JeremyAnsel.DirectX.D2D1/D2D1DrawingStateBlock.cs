// <copyright file="D2D1DrawingStateBlock.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.DWrite;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents the drawing state of a render target: the antialiasing mode, transform, tags, and text-rendering options.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1DrawingStateBlock : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1DrawingStateBlockGuid = typeof(ID2D1DrawingStateBlock).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1DrawingStateBlock* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1DrawingStateBlock"/> class.
    /// </summary>
    public D2D1DrawingStateBlock(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1DrawingStateBlock**)comPtr;
    }

    /// <summary>
    /// Gets or sets the antialiasing mode, transform, and tags portion of the drawing state.
    /// </summary>
    public D2D1DrawingStateDescription Description
    {
        get
        {
            int size = D2D1DrawingStateDescription.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDescription(_comPtr, ptr);
            return D2D1DrawingStateDescription.NativeReadFrom((nint)ptr);
        }

        set
        {
            int size = D2D1DrawingStateDescription.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D2D1DrawingStateDescription.NativeWriteTo((nint)ptr, value);
            _comImpl->SetDescription(_comPtr, ptr);
        }
    }

    /// <summary>
    /// Gets or sets the text-rendering configuration of the drawing state.
    /// </summary>
    public DWriteRenderingParams? TextRenderingParams
    {
        get
        {
            nint ptr;
            _comImpl->GetTextRenderingParams(_comPtr, &ptr);
            return ptr == 0 ? null : new DWriteRenderingParams(ptr);
        }

        set
        {
            nint ptr = value is null ? 0 : value.Handle;
            _comImpl->SetTextRenderingParams(_comPtr, ptr);
        }
    }
}
