// <copyright file="DWriteGlyphMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_GLYPH_METRICS structure specifies the metrics of an individual glyph.
/// The units depend on how the metrics are obtained.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteGlyphMetrics : IEquatable<DWriteGlyphMetrics>
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
        size += sizeof(int) * 5;
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteGlyphMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteGlyphMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteGlyphMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.leftSideBearing);
            DXMarshal.Write(ref buffer, obj.advanceWidth);
            DXMarshal.Write(ref buffer, obj.rightSideBearing);
            DXMarshal.Write(ref buffer, obj.topSideBearing);
            DXMarshal.Write(ref buffer, obj.advanceHeight);
            DXMarshal.Write(ref buffer, obj.bottomSideBearing);
            DXMarshal.Write(ref buffer, obj.verticalOriginY);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteGlyphMetrics NativeReadFrom(nint buffer)
    {
        DWriteGlyphMetrics obj;
        obj.leftSideBearing = DXMarshal.ReadInt32(ref buffer);
        obj.advanceWidth = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.rightSideBearing = DXMarshal.ReadInt32(ref buffer);
        obj.topSideBearing = DXMarshal.ReadInt32(ref buffer);
        obj.advanceHeight = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.bottomSideBearing = DXMarshal.ReadInt32(ref buffer);
        obj.verticalOriginY = DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteGlyphMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Specifies the X offset from the glyph origin to the left edge of the black box.
    /// The glyph origin is the current horizontal writing position.
    /// A negative value means the black box extends to the left of the origin (often true for lowercase italic 'f').
    /// </summary>
    private int leftSideBearing;

    /// <summary>
    /// Specifies the X offset from the origin of the current glyph to the origin of the next glyph when writing horizontally.
    /// </summary>
    private uint advanceWidth;

    /// <summary>
    /// Specifies the X offset from the right edge of the black box to the origin of the next glyph when writing horizontally.
    /// The value is negative when the right edge of the black box overhangs the layout box.
    /// </summary>
    private int rightSideBearing;

    /// <summary>
    /// Specifies the vertical offset from the vertical origin to the top of the black box.
    /// Thus, a positive value adds whitespace whereas a negative value means the glyph overhangs the top of the layout box.
    /// </summary>
    private int topSideBearing;

    /// <summary>
    /// Specifies the Y offset from the vertical origin of the current glyph to the vertical origin of the next glyph when writing vertically.
    /// (Note that the term "origin" by itself denotes the horizontal origin. The vertical origin is different.
    /// Its Y coordinate is specified by verticalOriginY value,
    /// and its X coordinate is half the advanceWidth to the right of the horizontal origin).
    /// </summary>
    private uint advanceHeight;

    /// <summary>
    /// Specifies the vertical distance from the black box's bottom edge to the advance height.
    /// Positive when the bottom edge of the black box is within the layout box.
    /// Negative when the bottom edge of black box overhangs the layout box.
    /// </summary>
    private int bottomSideBearing;

    /// <summary>
    /// Specifies the Y coordinate of a glyph's vertical origin, in the font's design coordinate system.
    /// The y coordinate of a glyph's vertical origin is the sum of the glyph's top side bearing
    /// and the top (i.e. yMax) of the glyph's bounding box.
    /// </summary>
    private int verticalOriginY;

    /// <summary>
    /// Gets the X offset from the glyph origin to the left edge of the black box.
    /// The glyph origin is the current horizontal writing position.
    /// A negative value means the black box extends to the left of the origin (often true for lowercase italic 'f').
    /// </summary>
    public int LeftSideBearing
    {
        get { return this.leftSideBearing; }
    }

    /// <summary>
    /// Gets the X offset from the origin of the current glyph to the origin of the next glyph when writing horizontally.
    /// </summary>
    public uint AdvanceWidth
    {
        get { return this.advanceWidth; }
    }

    /// <summary>
    /// Gets the X offset from the right edge of the black box to the origin of the next glyph when writing horizontally.
    /// The value is negative when the right edge of the black box overhangs the layout box.
    /// </summary>
    public int RightSideBearing
    {
        get { return this.rightSideBearing; }
    }

    /// <summary>
    /// Gets the vertical offset from the vertical origin to the top of the black box.
    /// Thus, a positive value adds whitespace whereas a negative value means the glyph overhangs the top of the layout box.
    /// </summary>
    public int TopSideBearing
    {
        get { return this.topSideBearing; }
    }

    /// <summary>
    /// Gets the Y offset from the vertical origin of the current glyph to the vertical origin of the next glyph when writing vertically.
    /// (Note that the term "origin" by itself denotes the horizontal origin. The vertical origin is different.
    /// Its Y coordinate is specified by verticalOriginY value,
    /// and its X coordinate is half the advanceWidth to the right of the horizontal origin).
    /// </summary>
    public uint AdvanceHeight
    {
        get { return this.advanceHeight; }
    }

    /// <summary>
    /// Gets the vertical distance from the black box's bottom edge to the advance height.
    /// Positive when the bottom edge of the black box is within the layout box.
    /// Negative when the bottom edge of black box overhangs the layout box.
    /// </summary>
    public int BottomSideBearing
    {
        get { return this.bottomSideBearing; }
    }

    /// <summary>
    /// Gets the Y coordinate of a glyph's vertical origin, in the font's design coordinate system.
    /// The y coordinate of a glyph's vertical origin is the sum of the glyph's top side bearing
    /// and the top (i.e. yMax) of the glyph's bounding box.
    /// </summary>
    public int VerticalOriginY
    {
        get { return this.verticalOriginY; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteGlyphMetrics left, DWriteGlyphMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteGlyphMetrics left, DWriteGlyphMetrics right)
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
        return obj is DWriteGlyphMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteGlyphMetrics other)
    {
        return leftSideBearing == other.leftSideBearing &&
               advanceWidth == other.advanceWidth &&
               rightSideBearing == other.rightSideBearing &&
               topSideBearing == other.topSideBearing &&
               advanceHeight == other.advanceHeight &&
               bottomSideBearing == other.bottomSideBearing &&
               verticalOriginY == other.verticalOriginY;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1769155220;
        hashCode = hashCode * -1521134295 + leftSideBearing.GetHashCode();
        hashCode = hashCode * -1521134295 + advanceWidth.GetHashCode();
        hashCode = hashCode * -1521134295 + rightSideBearing.GetHashCode();
        hashCode = hashCode * -1521134295 + topSideBearing.GetHashCode();
        hashCode = hashCode * -1521134295 + advanceHeight.GetHashCode();
        hashCode = hashCode * -1521134295 + bottomSideBearing.GetHashCode();
        hashCode = hashCode * -1521134295 + verticalOriginY.GetHashCode();
        return hashCode;
    }
}
