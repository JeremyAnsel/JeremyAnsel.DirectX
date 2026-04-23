// <copyright file="DWriteTextMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Overall metrics associated with text after layout.
/// All coordinates are in device independent pixels (DIPs).
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteTextMetrics : IEquatable<DWriteTextMetrics>
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
        size += sizeof(float) * 7;
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteTextMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteTextMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteTextMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.left);
            DXMarshal.Write(ref buffer, obj.top);
            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.widthIncludingTrailingWhitespace);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, obj.layoutWidth);
            DXMarshal.Write(ref buffer, obj.layoutHeight);
            DXMarshal.Write(ref buffer, obj.maxBidiReorderingDepth);
            DXMarshal.Write(ref buffer, obj.lineCount);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteTextMetrics NativeReadFrom(nint buffer)
    {
        DWriteTextMetrics obj;
        obj.left = DXMarshal.ReadSingle(ref buffer);
        obj.top = DXMarshal.ReadSingle(ref buffer);
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.widthIncludingTrailingWhitespace = DXMarshal.ReadSingle(ref buffer);
        obj.height = DXMarshal.ReadSingle(ref buffer);
        obj.layoutWidth = DXMarshal.ReadSingle(ref buffer);
        obj.layoutHeight = DXMarshal.ReadSingle(ref buffer);
        obj.maxBidiReorderingDepth = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.lineCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteTextMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Left-most point of formatted text relative to layout box
    /// (excluding any glyph overhang).
    /// </summary>
    private float left;

    /// <summary>
    /// Top-most point of formatted text relative to layout box
    /// (excluding any glyph overhang).
    /// </summary>
    private float top;

    /// <summary>
    /// The width of the formatted text ignoring trailing whitespace
    /// at the end of each line.
    /// </summary>
    private float width;

    /// <summary>
    /// The width of the formatted text taking into account the
    /// trailing whitespace at the end of each line.
    /// </summary>
    private float widthIncludingTrailingWhitespace;

    /// <summary>
    /// The height of the formatted text. The height of an empty string
    /// is determined by the size of the default font's line height.
    /// </summary>
    private float height;

    /// <summary>
    /// Initial width given to the layout. Depending on whether the text
    /// was wrapped or not, it can be either larger or smaller than the
    /// text content width.
    /// </summary>
    private float layoutWidth;

    /// <summary>
    /// Initial height given to the layout. Depending on the length of the
    /// text, it may be larger or smaller than the text content height.
    /// </summary>
    private float layoutHeight;

    /// <summary>
    /// The maximum reordering count of any line of text, used
    /// to calculate the most number of hit-testing boxes needed.
    /// If the layout has no bidirectional text or no text at all,
    /// the minimum level is 1.
    /// </summary>
    private uint maxBidiReorderingDepth;

    /// <summary>
    /// Total number of lines.
    /// </summary>
    private uint lineCount;

    /// <summary>
    /// Gets the left-most point of formatted text relative to layout box
    /// (excluding any glyph overhang).
    /// </summary>
    public float Left
    {
        get { return this.left; }
    }

    /// <summary>
    /// Gets the top-most point of formatted text relative to layout box
    /// (excluding any glyph overhang).
    /// </summary>
    public float Top
    {
        get { return this.top; }
    }

    /// <summary>
    /// Gets the width of the formatted text ignoring trailing whitespace
    /// at the end of each line.
    /// </summary>
    public float Width
    {
        get { return this.width; }
    }

    /// <summary>
    /// Gets the width of the formatted text taking into account the
    /// trailing whitespace at the end of each line.
    /// </summary>
    public float WidthIncludingTrailingWhitespace
    {
        get { return this.widthIncludingTrailingWhitespace; }
    }

    /// <summary>
    /// Gets the height of the formatted text. The height of an empty string
    /// is determined by the size of the default font's line height.
    /// </summary>
    public float Height
    {
        get { return this.height; }
    }

    /// <summary>
    /// Gets the initial width given to the layout. Depending on whether the text
    /// was wrapped or not, it can be either larger or smaller than the
    /// text content width.
    /// </summary>
    public float LayoutWidth
    {
        get { return this.layoutWidth; }
    }

    /// <summary>
    /// Gets the initial height given to the layout. Depending on the length of the
    /// text, it may be larger or smaller than the text content height.
    /// </summary>
    public float LayoutHeight
    {
        get { return this.layoutHeight; }
    }

    /// <summary>
    /// Gets the maximum reordering count of any line of text, used
    /// to calculate the most number of hit-testing boxes needed.
    /// If the layout has no bidirectional text or no text at all,
    /// the minimum level is 1.
    /// </summary>
    public uint MaxBidiReorderingDepth
    {
        get { return this.maxBidiReorderingDepth; }
    }

    /// <summary>
    /// Gets the total number of lines.
    /// </summary>
    public uint LineCount
    {
        get { return this.lineCount; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteTextMetrics left, DWriteTextMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteTextMetrics left, DWriteTextMetrics right)
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
        return obj is DWriteTextMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteTextMetrics other)
    {
        return left == other.left &&
               top == other.top &&
               width == other.width &&
               widthIncludingTrailingWhitespace == other.widthIncludingTrailingWhitespace &&
               height == other.height &&
               layoutWidth == other.layoutWidth &&
               layoutHeight == other.layoutHeight &&
               maxBidiReorderingDepth == other.maxBidiReorderingDepth &&
               lineCount == other.lineCount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 614588462;
        hashCode = hashCode * -1521134295 + left.GetHashCode();
        hashCode = hashCode * -1521134295 + top.GetHashCode();
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + widthIncludingTrailingWhitespace.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + layoutWidth.GetHashCode();
        hashCode = hashCode * -1521134295 + layoutHeight.GetHashCode();
        hashCode = hashCode * -1521134295 + maxBidiReorderingDepth.GetHashCode();
        hashCode = hashCode * -1521134295 + lineCount.GetHashCode();
        return hashCode;
    }
}
