// <copyright file="ID2D1SolidColorBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Paints an area with a solid color.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
[Guid("2cd906a9-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1SolidColorBrush
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
    /// Specifies the color of this solid-color brush.
    /// </summary>
    /// <param name="color">The color of this solid-color brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> SetColor;

    /// <summary>
    /// Retrieves the color of the solid color brush.
    /// </summary>
    /// <param name="color">The color of this solid color brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetColor;
}
