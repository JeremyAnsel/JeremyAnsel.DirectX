// <copyright file="DWriteClusterMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_CLUSTER_METRICS structure contains information about a glyph cluster.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteClusterMetrics : IEquatable<DWriteClusterMetrics>
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
        size += sizeof(ushort) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteClusterMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteClusterMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteClusterMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.length);
            DXMarshal.Write(ref buffer, obj.data);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteClusterMetrics NativeReadFrom(nint buffer)
    {
        DWriteClusterMetrics obj;
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.length = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.data = DXMarshal.ReadUnsignedInt16(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteClusterMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The total advance width of all glyphs in the cluster.
    /// </summary>
    private float width;

    /// <summary>
    /// The number of text positions in the cluster.
    /// </summary>
    private ushort length;

    /// <summary>
    /// Packed data.
    /// </summary>
    private ushort data;

    /// <summary>
    /// Gets the total advance width of all glyphs in the cluster.
    /// </summary>
    public float Width
    {
        get { return this.width; }
    }

    /// <summary>
    /// Gets the number of text positions in the cluster.
    /// </summary>
    public ushort Length
    {
        get { return this.length; }
    }

    /// <summary>
    /// Gets a value indicating whether the line can be broken right after the cluster.
    /// </summary>
    public bool CanWrapLineAfter
    {
        get { return (this.data & 1U) != 0; }
    }

    /// <summary>
    /// Gets a value indicating whether the cluster corresponds to whitespace character.
    /// </summary>
    public bool IsWhitespace
    {
        get { return (this.data & (1U << 1)) != 0; }
    }

    /// <summary>
    /// Gets a value indicating whether the cluster corresponds to a newline character.
    /// </summary>
    public bool IsNewline
    {
        get { return (this.data & (1U << 2)) != 0; }
    }

    /// <summary>
    /// Gets a value indicating whether the cluster corresponds to soft hyphen character.
    /// </summary>
    public bool IsSoftHyphen
    {
        get { return (this.data & (1U << 3)) != 0; }
    }

    /// <summary>
    /// Gets a value indicating whether the cluster is read from right to left.
    /// </summary>
    public bool IsRightToLeft
    {
        get { return (this.data & (1U << 4)) != 0; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteClusterMetrics left, DWriteClusterMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteClusterMetrics left, DWriteClusterMetrics right)
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
        return obj is DWriteClusterMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteClusterMetrics other)
    {
        return width == other.width &&
               length == other.length &&
               data == other.data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 338207889;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + length.GetHashCode();
        hashCode = hashCode * -1521134295 + data.GetHashCode();
        return hashCode;
    }
}
