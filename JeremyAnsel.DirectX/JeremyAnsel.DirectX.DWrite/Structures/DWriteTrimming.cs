// <copyright file="DWriteTrimming.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_TRIMMING structure specifies the trimming option for text overflowing the layout box.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteTrimming : IEquatable<DWriteTrimming>
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
        size += sizeof(int); // enum
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteTrimming obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteTrimming>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteTrimming> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.granularity);
            DXMarshal.Write(ref buffer, obj.delimiter);
            DXMarshal.Write(ref buffer, obj.delimiterCount);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteTrimming NativeReadFrom(nint buffer)
    {
        DWriteTrimming obj;
        obj.granularity = (DWriteTrimmingGranularity)DXMarshal.ReadInt32(ref buffer);
        obj.delimiter = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.delimiterCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteTrimming> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Text granularity of which trimming applies.
    /// </summary>
    private DWriteTrimmingGranularity granularity;

    /// <summary>
    /// Character code used as the delimiter signaling the beginning of the portion of text to be preserved,
    /// most useful for path ellipsis, where the delimiter would be a slash.
    /// </summary>
    private uint delimiter;

    /// <summary>
    /// How many occurrences of the delimiter to step back.
    /// </summary>
    private uint delimiterCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteTrimming"/> struct.
    /// </summary>
    /// <param name="granularity">Text granularity of which trimming applies.</param>
    /// <param name="delimiter">Character code used as the delimiter signaling the beginning of the portion of text to be preserved.</param>
    /// <param name="delimiterCount">How many occurrences of the delimiter to step back.</param>
    public DWriteTrimming(DWriteTrimmingGranularity granularity, uint delimiter, uint delimiterCount)
    {
        this.granularity = granularity;
        this.delimiter = delimiter;
        this.delimiterCount = delimiterCount;
    }

    /// <summary>
    /// Gets or sets the text granularity of which trimming applies.
    /// </summary>
    public DWriteTrimmingGranularity Granularity
    {
        get { return this.granularity; }
        set { this.granularity = value; }
    }

    /// <summary>
    /// Gets or sets the character code used as the delimiter signaling the beginning of the portion of text to be preserved,
    /// most useful for path ellipsis, where the delimiter would be a slash.
    /// </summary>
    public uint Delimiter
    {
        get { return this.delimiter; }
        set { this.delimiter = value; }
    }

    /// <summary>
    /// Gets or sets how many occurrences of the delimiter to step back.
    /// </summary>
    public uint DelimiterCount
    {
        get { return this.delimiterCount; }
        set { this.delimiterCount = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteTrimming left, DWriteTrimming right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteTrimming left, DWriteTrimming right)
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
        return obj is DWriteTrimming trimming && Equals(trimming);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteTrimming other)
    {
        return granularity == other.granularity &&
               delimiter == other.delimiter &&
               delimiterCount == other.delimiterCount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -2019168286;
        hashCode = hashCode * -1521134295 + granularity.GetHashCode();
        hashCode = hashCode * -1521134295 + delimiter.GetHashCode();
        hashCode = hashCode * -1521134295 + delimiterCount.GetHashCode();
        return hashCode;
    }
}
