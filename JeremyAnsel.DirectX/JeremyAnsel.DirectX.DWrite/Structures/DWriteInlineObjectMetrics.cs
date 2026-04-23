// <copyright file="DWriteInlineObjectMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Properties describing the geometric measurement of an
/// application-defined inline object.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteInlineObjectMetrics : IEquatable<DWriteInlineObjectMetrics>
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
        size += sizeof(float) * 3;
        size += sizeof(int); // bool
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteInlineObjectMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteInlineObjectMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteInlineObjectMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, obj.baseline);
            DXMarshal.Write(ref buffer, obj.supportsSideways);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteInlineObjectMetrics NativeReadFrom(nint buffer)
    {
        DWriteInlineObjectMetrics obj;
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.height = DXMarshal.ReadSingle(ref buffer);
        obj.baseline = DXMarshal.ReadSingle(ref buffer);
        obj.supportsSideways = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteInlineObjectMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Width of the inline object.
    /// </summary>
    private float width;

    /// <summary>
    /// Height of the inline object as measured from top to bottom.
    /// </summary>
    private float height;

    /// <summary>
    /// Distance from the top of the object to the baseline where it is lined up with the adjacent text.
    /// If the baseline is at the bottom, baseline simply equals height.
    /// </summary>
    private float baseline;

    /// <summary>
    /// Flag indicating whether the object is to be placed upright or alongside the text baseline
    /// for vertical text.
    /// </summary>
    private bool supportsSideways;

    /// <summary>
    /// Gets the width of the inline object.
    /// </summary>
    public float Width
    {
        get { return this.width; }
    }

    /// <summary>
    /// Gets the height of the inline object as measured from top to bottom.
    /// </summary>
    public float Height
    {
        get { return this.height; }
    }

    /// <summary>
    /// Gets the distance from the top of the object to the baseline where it is lined up with the adjacent text.
    /// If the baseline is at the bottom, baseline simply equals height.
    /// </summary>
    public float Baseline
    {
        get { return this.baseline; }
    }

    /// <summary>
    /// Gets a value indicating whether the object is to be placed upright or alongside the text baseline
    /// for vertical text.
    /// </summary>
    public bool SupportsSideways
    {
        get { return this.supportsSideways; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteInlineObjectMetrics left, DWriteInlineObjectMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteInlineObjectMetrics left, DWriteInlineObjectMetrics right)
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
        return obj is DWriteInlineObjectMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteInlineObjectMetrics other)
    {
        return width == other.width &&
               height == other.height &&
               baseline == other.baseline &&
               supportsSideways == other.supportsSideways;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1988729473;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + baseline.GetHashCode();
        hashCode = hashCode * -1521134295 + supportsSideways.GetHashCode();
        return hashCode;
    }
}
