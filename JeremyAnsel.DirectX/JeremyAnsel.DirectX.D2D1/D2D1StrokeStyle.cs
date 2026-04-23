// <copyright file="D2D1StrokeStyle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the caps, miter limit, line join, and dash information for a stroke.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1StrokeStyle : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1StrokeStyleGuid = typeof(ID2D1StrokeStyle).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1StrokeStyle* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1StrokeStyle"/> class.
    /// </summary>
    public D2D1StrokeStyle(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1StrokeStyle**)comPtr;
    }

    /// <summary>
    /// Gets the type of shape used at the beginning of a stroke.
    /// </summary>
    public D2D1CapStyle StartCap
    {
        get { return _comImpl->GetStartCap(_comPtr); }
    }

    /// <summary>
    /// Gets the type of shape used at the end of a stroke.
    /// </summary>
    public D2D1CapStyle EndCap
    {
        get { return _comImpl->GetEndCap(_comPtr); }
    }

    /// <summary>
    /// Gets a value that specifies how the ends of each dash are drawn.
    /// </summary>
    public D2D1CapStyle DashCap
    {
        get { return _comImpl->GetDashCap(_comPtr); }
    }

    /// <summary>
    /// Gets the limit on the ratio of the miter length to half the stroke's thickness.
    /// </summary>
    public float MiterLimit
    {
        get { return _comImpl->GetMiterLimit(_comPtr); }
    }

    /// <summary>
    /// Gets the type of joint used at the vertices of a shape's outline.
    /// </summary>
    public D2D1LineJoin LineJoin
    {
        get { return _comImpl->GetLineJoin(_comPtr); }
    }

    /// <summary>
    /// Gets a value that specifies how far in the dash sequence the stroke will start.
    /// </summary>
    public float DashOffset
    {
        get { return _comImpl->GetDashOffset(_comPtr); }
    }

    /// <summary>
    /// Gets a value that describes the stroke's dash pattern.
    /// </summary>
    public D2D1DashStyle DashStyle
    {
        get { return _comImpl->GetDashStyle(_comPtr); }
    }

    /// <summary>
    /// Retrieves the number of entries in the dashes array.
    /// </summary>
    /// <returns>The number of entries in the dashes array if the stroke is dashed; otherwise, 0.</returns>
    public uint GetDashesCount()
    {
        return _comImpl->GetDashesCount(_comPtr);
    }

    /// <summary>
    /// Copies the dash pattern to the specified array.
    /// </summary>
    /// <returns>An array that will receive the dash pattern.</returns>
    public float[] GetDashes()
    {
        uint count = GetDashesCount();
        float[] dashes = new float[count];
        GetDashes(dashes.AsSpan());
        return dashes;
    }

    /// <summary>
    /// Copies the dash pattern to the specified array.
    /// </summary>
    /// <param name="dashes">An array that will receive the dash pattern.</param>
    public void GetDashes(Span<float> dashes)
    {
        fixed (float* ptr = dashes)
        {
            _comImpl->GetDashes(_comPtr, ptr, (uint)dashes.Length);
        }
    }
}
