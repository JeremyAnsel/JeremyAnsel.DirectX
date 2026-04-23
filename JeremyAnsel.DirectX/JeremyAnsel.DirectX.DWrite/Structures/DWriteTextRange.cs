// <copyright file="DWriteTextRange.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_TEXT_RANGE structure specifies a range of text positions where format is applied.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteTextRange : IEquatable<DWriteTextRange>
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
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteTextRange obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteTextRange>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteTextRange> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.startPosition);
            DXMarshal.Write(ref buffer, obj.length);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteTextRange NativeReadFrom(nint buffer)
    {
        DWriteTextRange obj;
        obj.startPosition = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.length = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteTextRange> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The start text position of the range.
    /// </summary>
    private uint startPosition;

    /// <summary>
    /// The number of text positions in the range.
    /// </summary>
    private uint length;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteTextRange"/> struct.
    /// </summary>
    /// <param name="startPosition">The start text position of the range.</param>
    /// <param name="length">The number of text positions in the range.</param>
    public DWriteTextRange(uint startPosition, uint length)
    {
        this.startPosition = startPosition;
        this.length = length;
    }

    /// <summary>
    /// Gets or sets the start text position of the range.
    /// </summary>
    public uint StartPosition
    {
        get { return this.startPosition; }
        set { this.startPosition = value; }
    }

    /// <summary>
    /// Gets or sets the number of text positions in the range.
    /// </summary>
    public uint Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteTextRange left, DWriteTextRange right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteTextRange left, DWriteTextRange right)
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
        return obj is DWriteTextRange range && Equals(range);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteTextRange other)
    {
        return startPosition == other.startPosition &&
               length == other.length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1871035633;
        hashCode = hashCode * -1521134295 + startPosition.GetHashCode();
        hashCode = hashCode * -1521134295 + length.GetHashCode();
        return hashCode;
    }
}
