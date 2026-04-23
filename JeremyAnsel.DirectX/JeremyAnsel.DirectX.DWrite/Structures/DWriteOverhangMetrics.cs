// <copyright file="DWriteOverhangMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_OVERHANG_METRICS structure holds how much any visible pixels
/// (in DIPs) overshoot each side of the layout or inline objects.
/// </summary>
/// <remarks>
/// Positive overhangs indicate that the visible area extends outside the layout
/// box or inline object, while negative values mean there is whitespace inside.
/// The returned values are unaffected by rendering transforms or pixel snapping.
/// Additionally, they may not exactly match final target's pixel bounds after
/// applying grid fitting and hinting.
/// </remarks>
[SkipLocalsInit]
public unsafe struct DWriteOverhangMetrics : IEquatable<DWriteOverhangMetrics>
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
        size += sizeof(float) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteOverhangMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteOverhangMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteOverhangMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.left);
            DXMarshal.Write(ref buffer, obj.top);
            DXMarshal.Write(ref buffer, obj.right);
            DXMarshal.Write(ref buffer, obj.bottom);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteOverhangMetrics NativeReadFrom(nint buffer)
    {
        DWriteOverhangMetrics obj;
        obj.left = DXMarshal.ReadSingle(ref buffer);
        obj.right = DXMarshal.ReadSingle(ref buffer);
        obj.top = DXMarshal.ReadSingle(ref buffer);
        obj.bottom = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteOverhangMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The distance from the left-most visible DIP to its left alignment edge.
    /// </summary>
    private float left;

    /// <summary>
    /// The distance from the top-most visible DIP to its top alignment edge.
    /// </summary>
    private float top;

    /// <summary>
    /// The distance from the right-most visible DIP to its right alignment edge.
    /// </summary>
    private float right;

    /// <summary>
    /// The distance from the bottom-most visible DIP to its bottom alignment edge.
    /// </summary>
    private float bottom;

    /// <summary>
    /// Gets the distance from the left-most visible DIP to its left alignment edge.
    /// </summary>
    public float Left
    {
        get { return this.left; }
    }

    /// <summary>
    /// Gets the distance from the top-most visible DIP to its top alignment edge.
    /// </summary>
    public float Top
    {
        get { return this.top; }
    }

    /// <summary>
    /// Gets the distance from the right-most visible DIP to its right alignment edge.
    /// </summary>
    public float Right
    {
        get { return this.right; }
    }

    /// <summary>
    /// Gets the distance from the bottom-most visible DIP to its bottom alignment edge.
    /// </summary>
    public float Bottom
    {
        get { return this.bottom; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteOverhangMetrics left, DWriteOverhangMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteOverhangMetrics left, DWriteOverhangMetrics right)
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
        return obj is DWriteOverhangMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteOverhangMetrics other)
    {
        return left == other.left &&
               top == other.top &&
               right == other.right &&
               bottom == other.bottom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -971476797;
        hashCode = hashCode * -1521134295 + left.GetHashCode();
        hashCode = hashCode * -1521134295 + top.GetHashCode();
        hashCode = hashCode * -1521134295 + right.GetHashCode();
        hashCode = hashCode * -1521134295 + bottom.GetHashCode();
        return hashCode;
    }
}
