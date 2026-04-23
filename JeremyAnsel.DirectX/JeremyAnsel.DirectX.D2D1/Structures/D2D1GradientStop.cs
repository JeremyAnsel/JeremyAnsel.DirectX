// <copyright file="D2D1GradientStop.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the position and color of a gradient stop.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1GradientStop : IEquatable<D2D1GradientStop>
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
        size += sizeof(float);
        size += D2D1ColorF.NativeRequiredSize();
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1GradientStop obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1GradientStop>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1GradientStop> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.position);
            D2D1ColorF.NativeWriteTo(buffer, obj.color);
            buffer += D2D1ColorF.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1GradientStop NativeReadFrom(nint buffer)
    {
        D2D1GradientStop obj;
        obj.position = DXMarshal.ReadSingle(ref buffer);
        obj.color = D2D1ColorF.NativeReadFrom(buffer);
        buffer += D2D1ColorF.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1GradientStop> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.
    /// </summary>
    private float position;

    /// <summary>
    /// The color of the gradient stop.
    /// </summary>
    private D2D1ColorF color;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1GradientStop"/> struct.
    /// </summary>
    /// <param name="position">A value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.</param>
    /// <param name="color">The color of the gradient stop.</param>
    public D2D1GradientStop(float position, D2D1ColorF color)
    {
        this.position = position;
        this.color = color;
    }

    /// <summary>
    /// Gets or sets a value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.
    /// </summary>
    public float Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    /// <summary>
    /// Gets or sets the color of the gradient stop.
    /// </summary>
    public D2D1ColorF Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1GradientStop left, D2D1GradientStop right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1GradientStop left, D2D1GradientStop right)
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
        return obj is D2D1GradientStop stop && Equals(stop);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1GradientStop other)
    {
        return position == other.position &&
               color.Equals(other.color);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -2056440846;
        hashCode = hashCode * -1521134295 + position.GetHashCode();
        hashCode = hashCode * -1521134295 + color.GetHashCode();
        return hashCode;
    }
}
