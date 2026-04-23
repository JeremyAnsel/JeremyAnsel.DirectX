// <copyright file="D2D1StrokeStyleProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the stroke that outlines a shape.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1StrokeStyleProperties : IEquatable<D2D1StrokeStyleProperties>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int NativeRequiredSize()
    {
        return NativeRequiredSize(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int NativeRequiredSize(int count)
    {
        int size = 0;
        size += sizeof(int) * 5; // enum
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1StrokeStyleProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1StrokeStyleProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1StrokeStyleProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.startCap);
            DXMarshal.Write(ref buffer, (int)obj.endCap);
            DXMarshal.Write(ref buffer, (int)obj.dashCap);
            DXMarshal.Write(ref buffer, (int)obj.lineJoin);
            DXMarshal.Write(ref buffer, obj.miterLimit);
            DXMarshal.Write(ref buffer, (int)obj.dashStyle);
            DXMarshal.Write(ref buffer, obj.dashOffset);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1StrokeStyleProperties NativeReadFrom(nint buffer)
    {
        D2D1StrokeStyleProperties obj;
        obj.startCap = (D2D1CapStyle)DXMarshal.ReadInt32(ref buffer);
        obj.endCap = (D2D1CapStyle)DXMarshal.ReadInt32(ref buffer);
        obj.dashCap = (D2D1CapStyle)DXMarshal.ReadInt32(ref buffer);
        obj.lineJoin = (D2D1LineJoin)DXMarshal.ReadInt32(ref buffer);
        obj.miterLimit = DXMarshal.ReadSingle(ref buffer);
        obj.dashStyle = (D2D1DashStyle)DXMarshal.ReadInt32(ref buffer);
        obj.dashOffset = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1StrokeStyleProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The cap applied to the start of all the open figures in a stroked geometry.
    /// </summary>
    private D2D1CapStyle startCap;

    /// <summary>
    /// The cap applied to the end of all the open figures in a stroked geometry.
    /// </summary>
    private D2D1CapStyle endCap;

    /// <summary>
    /// The shape at either end of each dash segment.
    /// </summary>
    private D2D1CapStyle dashCap;

    /// <summary>
    /// A value that describes how segments are joined.
    /// </summary>
    private D2D1LineJoin lineJoin;

    /// <summary>
    /// The limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.
    /// </summary>
    private float miterLimit;

    /// <summary>
    /// A value that specifies whether the stroke has a dash pattern and, if so, the dash style.
    /// </summary>
    private D2D1DashStyle dashStyle;

    /// <summary>
    /// A value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of stroke width, toward the end of the stroked geometry.
    /// </summary>
    private float dashOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1StrokeStyleProperties"/> struct.
    /// </summary>
    /// <param name="startCap">The cap applied to the start of all the open figures in a stroked geometry.</param>
    /// <param name="endCap">The cap applied to the end of all the open figures in a stroked geometry.</param>
    /// <param name="dashCap">The shape at either end of each dash segment.</param>
    /// <param name="lineJoin">A value that describes how segments are joined.</param>
    /// <param name="miterLimit">The limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.</param>
    /// <param name="dashStyle">A value that specifies whether the stroke has a dash pattern and, if so, the dash style.</param>
    /// <param name="dashOffset">A value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of stroke width, toward the end of the stroked geometry.</param>
    public D2D1StrokeStyleProperties(D2D1CapStyle startCap, D2D1CapStyle endCap, D2D1CapStyle dashCap, D2D1LineJoin lineJoin, float miterLimit, D2D1DashStyle dashStyle, float dashOffset)
    {
        this.startCap = startCap;
        this.endCap = endCap;
        this.dashCap = dashCap;
        this.lineJoin = lineJoin;
        this.miterLimit = miterLimit;
        this.dashStyle = dashStyle;
        this.dashOffset = dashOffset;
    }

    /// <summary>
    /// Gets default properties (Flat, Flat, Flat, Miter, 10, Solid, 0).
    /// </summary>
    public static D2D1StrokeStyleProperties Default
    {
        get { return new D2D1StrokeStyleProperties(D2D1CapStyle.Flat, D2D1CapStyle.Flat, D2D1CapStyle.Flat, D2D1LineJoin.Miter, 10.0f, D2D1DashStyle.Solid, 0.0f); }
    }

    /// <summary>
    /// Gets or sets the cap applied to the start of all the open figures in a stroked geometry.
    /// </summary>
    public D2D1CapStyle StartCap
    {
        get { return this.startCap; }
        set { this.startCap = value; }
    }

    /// <summary>
    /// Gets or sets the cap applied to the end of all the open figures in a stroked geometry.
    /// </summary>
    public D2D1CapStyle EndCap
    {
        get { return this.endCap; }
        set { this.endCap = value; }
    }

    /// <summary>
    /// Gets or sets the shape at either end of each dash segment.
    /// </summary>
    public D2D1CapStyle DashCap
    {
        get { return this.dashCap; }
        set { this.dashCap = value; }
    }

    /// <summary>
    /// Gets or sets a value that describes how segments are joined.
    /// </summary>
    public D2D1LineJoin LineJoin
    {
        get { return this.lineJoin; }
        set { this.lineJoin = value; }
    }

    /// <summary>
    /// Gets or sets the limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.
    /// </summary>
    public float MiterLimit
    {
        get { return this.miterLimit; }
        set { this.miterLimit = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the stroke has a dash pattern and, if so, the dash style.
    /// </summary>
    public D2D1DashStyle DashStyle
    {
        get { return this.dashStyle; }
        set { this.dashStyle = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of stroke width, toward the end of the stroked geometry.
    /// </summary>
    public float DashOffset
    {
        get { return this.dashOffset; }
        set { this.dashOffset = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1StrokeStyleProperties left, D2D1StrokeStyleProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1StrokeStyleProperties left, D2D1StrokeStyleProperties right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is D2D1StrokeStyleProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1StrokeStyleProperties other)
    {
        return startCap == other.startCap &&
               endCap == other.endCap &&
               dashCap == other.dashCap &&
               lineJoin == other.lineJoin &&
               miterLimit == other.miterLimit &&
               dashStyle == other.dashStyle &&
               dashOffset == other.dashOffset;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1654414538;
        hashCode = hashCode * -1521134295 + startCap.GetHashCode();
        hashCode = hashCode * -1521134295 + endCap.GetHashCode();
        hashCode = hashCode * -1521134295 + dashCap.GetHashCode();
        hashCode = hashCode * -1521134295 + lineJoin.GetHashCode();
        hashCode = hashCode * -1521134295 + miterLimit.GetHashCode();
        hashCode = hashCode * -1521134295 + dashStyle.GetHashCode();
        hashCode = hashCode * -1521134295 + dashOffset.GetHashCode();
        return hashCode;
    }
}
