// <copyright file="ID2D1RectangleGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Describes a two-dimensional rectangle.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Geometry"/></remarks>
[Guid("2cd906a2-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1RectangleGeometry
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;
    private readonly nint GetBounds;
    private readonly nint GetWidenedBounds;
    private readonly nint StrokeContainsPoint;
    private readonly nint FillContainsPoint;
    private readonly nint CompareWithGeometry;
    private readonly nint Simplify;
    private readonly nint Tessellate;
    private readonly nint CombineWithGeometry;
    private readonly nint Outline;
    private readonly nint ComputeArea;
    private readonly nint ComputeLength;
    private readonly nint ComputePointAtLength;
    private readonly nint Widen;

    /// <summary>
    /// Retrieves the rectangle that describes the rectangle geometry's dimensions.
    /// </summary>
    /// <param name="rect">A rectangle that describes the rectangle geometry's dimensions when this method returns.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetRect;
}
