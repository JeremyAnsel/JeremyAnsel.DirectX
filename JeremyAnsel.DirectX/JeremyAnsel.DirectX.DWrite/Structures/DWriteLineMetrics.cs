// <copyright file="DWriteLineMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_LINE_METRICS structure contains information about a formatted
/// line of text.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteLineMetrics : IEquatable<DWriteLineMetrics>
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
        size += sizeof(uint) * 3;
        size += sizeof(float) * 2;
        size += sizeof(int); // bool
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteLineMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteLineMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteLineMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.length);
            DXMarshal.Write(ref buffer, obj.trailingWhitespaceLength);
            DXMarshal.Write(ref buffer, obj.newlineLength);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, obj.baseline);
            DXMarshal.Write(ref buffer, obj.isTrimmed);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteLineMetrics NativeReadFrom(nint buffer)
    {
        DWriteLineMetrics obj;
        obj.length = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.trailingWhitespaceLength = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.newlineLength = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.height = DXMarshal.ReadSingle(ref buffer);
        obj.baseline = DXMarshal.ReadSingle(ref buffer);
        obj.isTrimmed = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteLineMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of total text positions in the line.
    /// This includes any trailing whitespace and newline characters.
    /// </summary>
    private uint length;

    /// <summary>
    /// The number of whitespace positions at the end of the line.  Newline
    /// sequences are considered whitespace.
    /// </summary>
    private uint trailingWhitespaceLength;

    /// <summary>
    /// The number of characters in the newline sequence at the end of the line.
    /// If the count is zero, then the line was either wrapped or it is the
    /// end of the text.
    /// </summary>
    private uint newlineLength;

    /// <summary>
    /// Height of the line as measured from top to bottom.
    /// </summary>
    private float height;

    /// <summary>
    /// Distance from the top of the line to its baseline.
    /// </summary>
    private float baseline;

    /// <summary>
    /// The line is trimmed.
    /// </summary>
    private bool isTrimmed;

    /// <summary>
    /// Gets the number of total text positions in the line.
    /// This includes any trailing whitespace and newline characters.
    /// </summary>
    public uint Length
    {
        get { return this.length; }
    }

    /// <summary>
    /// Gets the number of whitespace positions at the end of the line.  Newline
    /// sequences are considered whitespace.
    /// </summary>
    public uint TrailingWhitespaceLength
    {
        get { return this.trailingWhitespaceLength; }
    }

    /// <summary>
    /// Gets the number of characters in the newline sequence at the end of the line.
    /// If the count is zero, then the line was either wrapped or it is the
    /// end of the text.
    /// </summary>
    public uint NewlineLength
    {
        get { return this.newlineLength; }
    }

    /// <summary>
    /// Gets the height of the line as measured from top to bottom.
    /// </summary>
    public float Height
    {
        get { return this.height; }
    }

    /// <summary>
    /// Gets the distance from the top of the line to its baseline.
    /// </summary>
    public float Baseline
    {
        get { return this.baseline; }
    }

    /// <summary>
    /// Gets a value indicating whether the line is trimmed.
    /// </summary>
    public bool IsTrimmed
    {
        get { return this.isTrimmed; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteLineMetrics left, DWriteLineMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteLineMetrics left, DWriteLineMetrics right)
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
        return obj is DWriteLineMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteLineMetrics other)
    {
        return length == other.length &&
               trailingWhitespaceLength == other.trailingWhitespaceLength &&
               newlineLength == other.newlineLength &&
               height == other.height &&
               baseline == other.baseline &&
               isTrimmed == other.isTrimmed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -729602923;
        hashCode = hashCode * -1521134295 + length.GetHashCode();
        hashCode = hashCode * -1521134295 + trailingWhitespaceLength.GetHashCode();
        hashCode = hashCode * -1521134295 + newlineLength.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + baseline.GetHashCode();
        hashCode = hashCode * -1521134295 + isTrimmed.GetHashCode();
        return hashCode;
    }
}
