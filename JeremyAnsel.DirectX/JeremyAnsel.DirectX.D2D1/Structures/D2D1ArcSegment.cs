// <copyright file="D2D1ArcSegment.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes an elliptical arc between two points.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1ArcSegment : IEquatable<D2D1ArcSegment>
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
        size += D2D1Point2F.NativeRequiredSize();
        size += D2D1SizeF.NativeRequiredSize();
        size += sizeof(float);
        size += sizeof(int) * 2; // enuum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1ArcSegment obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1ArcSegment>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1ArcSegment> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1Point2F.NativeWriteTo(buffer, obj.point);
            buffer += D2D1Point2F.NativeRequiredSize();
            D2D1SizeF.NativeWriteTo(buffer, obj.size);
            buffer += D2D1SizeF.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.rotationAngle);
            DXMarshal.Write(ref buffer, (int)obj.sweepDirection);
            DXMarshal.Write(ref buffer, (int)obj.arcSize);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1ArcSegment NativeReadFrom(nint buffer)
    {
        D2D1ArcSegment obj;
        obj.point = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.size = D2D1SizeF.NativeReadFrom(buffer);
        buffer += D2D1SizeF.NativeRequiredSize();
        obj.rotationAngle = DXMarshal.ReadSingle(ref buffer);
        obj.sweepDirection = (D2D1SweepDirection)DXMarshal.ReadInt32(ref buffer);
        obj.arcSize = (D2D1ArcSize)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1ArcSegment> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The end point of the arc.
    /// </summary>
    private D2D1Point2F point;

    /// <summary>
    /// The x-radius and y-radius of the arc.
    /// </summary>
    private D2D1SizeF size;

    /// <summary>
    /// A value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.
    /// </summary>
    private float rotationAngle;

    /// <summary>
    /// A value that specifies whether the arc sweep is clockwise or counterclockwise.
    /// </summary>
    private D2D1SweepDirection sweepDirection;

    /// <summary>
    /// A value that specifies whether the given arc is larger than 180 degrees.
    /// </summary>
    private D2D1ArcSize arcSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ArcSegment"/> struct.
    /// </summary>
    /// <param name="point">The end point of the arc.</param>
    /// <param name="size">The x-radius and y-radius of the arc.</param>
    /// <param name="rotationAngle">A value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.</param>
    /// <param name="sweepDirection">A value that specifies whether the arc sweep is clockwise or counterclockwise.</param>
    /// <param name="arcSize">A value that specifies whether the given arc is larger than 180 degrees.</param>
    public D2D1ArcSegment(D2D1Point2F point, D2D1SizeF size, float rotationAngle, D2D1SweepDirection sweepDirection, D2D1ArcSize arcSize)
    {
        this.point = point;
        this.size = size;
        this.rotationAngle = rotationAngle;
        this.sweepDirection = sweepDirection;
        this.arcSize = arcSize;
    }

    /// <summary>
    /// Gets or sets the end point of the arc.
    /// </summary>
    public D2D1Point2F Point
    {
        get { return this.point; }
        set { this.point = value; }
    }

    /// <summary>
    /// Gets or sets the x-radius and y-radius of the arc.
    /// </summary>
    public D2D1SizeF Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.
    /// </summary>
    public float RotationAngle
    {
        get { return this.rotationAngle; }
        set { this.rotationAngle = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the arc sweep is clockwise or counterclockwise.
    /// </summary>
    public D2D1SweepDirection SweepDirection
    {
        get { return this.sweepDirection; }
        set { this.sweepDirection = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the given arc is larger than 180 degrees.
    /// </summary>
    public D2D1ArcSize ArcSize
    {
        get { return this.arcSize; }
        set { this.arcSize = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1ArcSegment left, D2D1ArcSegment right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1ArcSegment left, D2D1ArcSegment right)
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
        return obj is D2D1ArcSegment segment && Equals(segment);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1ArcSegment other)
    {
        return point.Equals(other.point) &&
               size.Equals(other.size) &&
               rotationAngle == other.rotationAngle &&
               sweepDirection == other.sweepDirection &&
               arcSize == other.arcSize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 404779945;
        hashCode = hashCode * -1521134295 + point.GetHashCode();
        hashCode = hashCode * -1521134295 + size.GetHashCode();
        hashCode = hashCode * -1521134295 + rotationAngle.GetHashCode();
        hashCode = hashCode * -1521134295 + sweepDirection.GetHashCode();
        hashCode = hashCode * -1521134295 + arcSize.GetHashCode();
        return hashCode;
    }
}
