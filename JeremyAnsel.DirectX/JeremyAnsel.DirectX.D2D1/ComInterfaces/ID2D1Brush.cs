// <copyright file="ID2D1Brush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// The root brush interface. All brushes can be used to fill or pen a geometry.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd906a8-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1Brush
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Sets the opacity for when the brush is drawn over the entire fill of the brush.
    /// </summary>
    /// <param name="opacity">A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multiplied together.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, void> SetOpacity;

    /// <summary>
    /// Sets the transform that applies to everything drawn by the brush.
    /// </summary>
    /// <param name="transform">The transformation to apply to this brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> SetTransform;

    /// <summary>
    /// Gets the degree of opacity of this brush.
    /// </summary>
    /// <returns>A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multiplied together.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetOpacity;

    /// <summary>
    /// Gets the transform applied to this brush.
    /// </summary>
    /// <param name="transform">The transform applied to this brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetTransform;
}
