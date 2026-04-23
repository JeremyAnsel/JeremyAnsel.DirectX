// <copyright file="ID2D1DrawingStateBlock.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents the drawing state of a render target: the antialiasing mode, transform, tags, and text-rendering options.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("28506e39-ebf6-46a1-bb47-fd85565ab957")]
internal unsafe readonly struct ID2D1DrawingStateBlock
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Retrieves the antialiasing mode, transform, and tags portion of the drawing state.
    /// </summary>
    /// <param name="stateDescription">When this method returns, contains the antialiasing mode, transform, and tags portion of the drawing state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDescription;

    /// <summary>
    /// Specifies the antialiasing mode, transform, and tags portion of the drawing state.
    /// </summary>
    /// <param name="stateDescription">The antialiasing mode, transform, and tags portion of the drawing state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> SetDescription;

    /// <summary>
    /// Specifies the text-rendering configuration of the drawing state.
    /// </summary>
    /// <param name="textRenderingParams">The text-rendering configuration of the drawing state, or NULL to use default settings.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> SetTextRenderingParams;

    /// <summary>
    /// Retrieves the text-rendering configuration of the drawing state.
    /// </summary>
    /// <param name="textRenderingParams">An <see cref="DWriteRenderingParams"/> object that describes the text-rendering configuration of the drawing state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetTextRenderingParams;
}
