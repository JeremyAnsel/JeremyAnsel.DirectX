// <copyright file="IDWriteGlyphRunAnalysis.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// Interface that encapsulates information used to render a glyph run.
/// </summary>
[Guid("7d97dbf7-e085-42d4-81e3-6a883bded118")]
internal unsafe readonly struct IDWriteGlyphRunAnalysis
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Gets the bounding rectangle of the physical pixels affected by the glyph run.
    /// </summary>
    /// <param name="textureType">Specifies the type of texture requested. If a bi-level texture is requested, the
    /// bounding rectangle includes only bi-level glyphs. Otherwise, the bounding rectangle includes only anti-aliased
    /// glyphs.</param>
    /// <param name="textureBounds">Receives the bounding rectangle, or an empty rectangle if there are no glyphs
    /// if the specified type.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteTextureType, void*, int> GetAlphaTextureBounds;

    /// <summary>
    /// Creates an alpha texture of the specified type.
    /// </summary>
    /// <param name="textureType">Specifies the type of texture requested. If a bi-level texture is requested, the
    /// texture contains only bi-level glyphs. Otherwise, the texture contains only anti-aliased glyphs.</param>
    /// <param name="textureBounds">Specifies the bounding rectangle of the texture, which can be different than
    /// the bounding rectangle returned by GetAlphaTextureBounds.</param>
    /// <param name="alphaValues">Receives the array of alpha values.</param>
    /// <param name="bufferSize">Size of the alphaValues array. The minimum size depends on the dimensions of the
    /// rectangle and the type of texture requested.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteTextureType, void*, void*, uint, int> CreateAlphaTexture;

    /// <summary>
    /// Gets properties required for ClearType blending.
    /// </summary>
    /// <param name="renderingParams">Rendering parameters object. In most cases, the values returned in the output
    /// parameters are based on the properties of this object. The exception is if a GDI-compatible rendering mode
    /// is specified.</param>
    /// <param name="blendGamma">Receives the gamma value to use for gamma correction.</param>
    /// <param name="blendEnhancedContrast">Receives the enhanced contrast value.</param>
    /// <param name="blendClearTypeLevel">Receives the ClearType level.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float*, float*, float*, int> GetAlphaBlendParams;
}
