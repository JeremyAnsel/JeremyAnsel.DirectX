// <copyright file="ID2D1StrokeStyle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Describes the caps, miter limit, line join, and dash information for a stroke.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd9069d-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1StrokeStyle
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Retrieves the type of shape used at the beginning of a stroke.
    /// </summary>
    /// <returns>The type of shape used at the beginning of a stroke.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1CapStyle> GetStartCap;

    /// <summary>
    /// Retrieves the type of shape used at the end of a stroke.
    /// </summary>
    /// <returns>The type of shape used at the end of a stroke.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1CapStyle> GetEndCap;

    /// <summary>
    /// Gets a value that specifies how the ends of each dash are drawn.
    /// </summary>
    /// <returns>A value that specifies how the ends of each dash are drawn.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1CapStyle> GetDashCap;

    /// <summary>
    /// Retrieves the limit on the ratio of the miter length to half the stroke's thickness.
    /// </summary>
    /// <returns>A positive number greater than or equal to 1.0f that describes the limit on the ratio of the miter length to half the stroke's thickness.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetMiterLimit;

    /// <summary>
    /// Retrieves the type of joint used at the vertices of a shape's outline.
    /// </summary>
    /// <returns>A value that specifies the type of joint used at the vertices of a shape's outline.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1LineJoin> GetLineJoin;

    /// <summary>
    /// Retrieves a value that specifies how far in the dash sequence the stroke will start.
    /// </summary>
    /// <returns>A value that specifies how far in the dash sequence the stroke will start.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetDashOffset;

    /// <summary>
    /// Gets a value that describes the stroke's dash pattern.
    /// </summary>
    /// <returns>A value that describes the predefined dash pattern used.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1DashStyle> GetDashStyle;

    /// <summary>
    /// Retrieves the number of entries in the dashes array.
    /// </summary>
    /// <returns>The number of entries in the dashes array if the stroke is dashed; otherwise, 0.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetDashesCount;

    /// <summary>
    /// Copies the dash pattern to the specified array.
    /// </summary>
    /// <param name="dashes">An array that will receive the dash pattern.</param>
    /// <param name="dahsesCount">The number of dashes to copy.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float*, uint, void> GetDashes;
}
