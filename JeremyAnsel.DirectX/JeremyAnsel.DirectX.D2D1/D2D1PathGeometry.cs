// <copyright file="D2D1PathGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a complex shape that may be composed of arcs, curves, and lines.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1PathGeometry : D2D1Geometry
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1PathGeometryGuid = typeof(ID2D1PathGeometry).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1PathGeometry* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1PathGeometry"/> class.
    /// </summary>
    public D2D1PathGeometry(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1PathGeometry**)comPtr;
    }

    /// <summary>
    /// Gets the number of segments in the path geometry.
    /// </summary>
    public uint SegmentCount
    {
        get
        {
            uint count;
            int hr = _comImpl->GetSegmentCount(_comPtr, &count);
            Marshal.ThrowExceptionForHR(hr);
            return count;
        }
    }

    /// <summary>
    /// Gets the number of figures in the path geometry.
    /// </summary>
    public uint FigureCount
    {
        get
        {
            uint count;
            int hr = _comImpl->GetFigureCount(_comPtr, &count);
            Marshal.ThrowExceptionForHR(hr);
            return count;
        }
    }

    /// <summary>
    /// Retrieves the geometry sink that is used to populate the path geometry with figures and segments.
    /// </summary>
    /// <returns>The geometry sink that is used to populate the path geometry with figures and segments.</returns>
    public D2D1GeometrySink Open()
    {
        nint ptr;
        int hr = _comImpl->Open(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1GeometrySink(ptr);
    }

    /// <summary>
    /// Copies the contents of the path geometry to the specified <see cref="D2D1GeometrySink"/>.
    /// </summary>
    /// <param name="geometrySink">The sink to which the path geometry's contents are copied. Modifying this sink does not change the contents of this path geometry.</param>
    public void Stream(D2D1GeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->Stream(_comPtr, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }
}
