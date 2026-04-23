// <copyright file="DWriteGlyphRun.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_GLYPH_RUN structure contains the information needed by renderers
/// to draw glyph runs. All coordinates are in device independent pixels (DIPs).
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteGlyphRun : IEquatable<DWriteGlyphRun>
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
        size += sizeof(nint) * 4;
        size += sizeof(float);
        size += sizeof(uint) * 2;
        size += sizeof(int); // bool
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteGlyphRun obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteGlyphRun>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteGlyphRun> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.fontFace);
            DXMarshal.Write(ref buffer, obj.fontEMSize);
            DXMarshal.Write(ref buffer, obj.glyphCount);
            DXMarshal.Write(ref buffer, obj.glyphIndices);
            DXMarshal.Write(ref buffer, obj.glyphAdvances);
            DXMarshal.Write(ref buffer, obj.glyphOffsets);
            DXMarshal.Write(ref buffer, obj.isSideways);
            DXMarshal.Write(ref buffer, obj.bidiLevel);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteGlyphRun NativeReadFrom(nint buffer)
    {
        DWriteGlyphRun obj;
        obj.fontFace = DXMarshal.ReadIntPtr(ref buffer);
        obj.fontEMSize = DXMarshal.ReadSingle(ref buffer);
        obj.glyphCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.glyphIndices = DXMarshal.ReadIntPtr(ref buffer);
        obj.glyphAdvances = DXMarshal.ReadIntPtr(ref buffer);
        obj.glyphOffsets = DXMarshal.ReadIntPtr(ref buffer);
        obj.isSideways = DXMarshal.ReadBool(ref buffer);
        obj.bidiLevel = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteGlyphRun> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The physical font face to draw with.
    /// </summary>
    private nint fontFace;

    /// <summary>
    /// Logical size of the font in DIPs, not points (equals 1/96 inch).
    /// </summary>
    private float fontEMSize;

    /// <summary>
    /// The number of glyphs.
    /// </summary>
    private uint glyphCount;

    /// <summary>
    /// The indices to render.
    /// </summary>
    private nint glyphIndices;

    /// <summary>
    /// Glyph advance widths.
    /// </summary>
    private nint glyphAdvances;

    /// <summary>
    /// Glyph offsets.
    /// </summary>
    private nint glyphOffsets;

    /// <summary>
    /// If true, specifies that glyphs are rotated 90 degrees to the left and
    /// vertical metrics are used. Vertical writing is achieved by specifying
    /// isSideways = true and rotating the entire run 90 degrees to the right
    /// via a rotate transform.
    /// </summary>
    private bool isSideways;

    /// <summary>
    /// The implicit resolved bidi level of the run. Odd levels indicate
    /// right-to-left languages like Hebrew and Arabic, while even levels
    /// indicate left-to-right languages like English and Japanese (when
    /// written horizontally). For right-to-left languages, the text origin
    /// is on the right, and text should be drawn to the left.
    /// </summary>
    private uint bidiLevel;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fontFace"></param>
    /// <param name="fontEMSize"></param>
    /// <param name="indices"></param>
    /// <param name="advances"></param>
    /// <param name="offsets"></param>
    /// <param name="isSideways"></param>
    /// <param name="bidiLevel"></param>
    public DWriteGlyphRun(nint fontFace, float fontEMSize, ushort[] indices, float[] advances, DWriteGlyphOffset[] offsets, bool isSideways, uint bidiLevel)
    {
        this.fontFace = fontFace;
        this.fontEMSize = fontEMSize;
        SetGlyphIndicesAdvancesOffsets(indices, advances, offsets);
        this.isSideways = isSideways;
        this.bidiLevel = bidiLevel;
    }

    /// <summary>
    /// Gets or sets the physical font face to draw with.
    /// </summary>
    public nint FontFace
    {
        get { return this.fontFace; }
        set { this.fontFace = value; }
    }

    /// <summary>
    /// Gets or sets the logical size of the font in DIPs, not points (equals 1/96 inch).
    /// </summary>
    public float FontEMSize
    {
        get { return this.fontEMSize; }
        set { this.fontEMSize = value; }
    }

    /// <summary>
    /// Gets the number of glyphs.
    /// </summary>
    public uint GlyphCount
    {
        get { return this.glyphCount; }
    }

    /// <summary>
    /// Gets the indices to render.
    /// </summary>
    public nint GlyphIndices
    {
        get { return this.glyphIndices; }
    }

    /// <summary>
    /// Gets the glyph advance widths.
    /// </summary>
    public nint GlyphAdvances
    {
        get { return this.glyphAdvances; }
    }

    /// <summary>
    /// Gets the glyph offsets.
    /// </summary>
    public nint GlyphOffsets
    {
        get { return this.glyphOffsets; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether glyphs are rotated 90 degrees to the left and
    /// vertical metrics are used. Vertical writing is achieved by specifying
    /// isSideways = true and rotating the entire run 90 degrees to the right
    /// via a rotate transform.
    /// </summary>
    public bool IsSideways
    {
        get { return this.isSideways; }
        set { this.isSideways = value; }
    }

    /// <summary>
    /// Gets or sets the implicit resolved bidi level of the run. Odd levels indicate
    /// right-to-left languages like Hebrew and Arabic, while even levels
    /// indicate left-to-right languages like English and Japanese (when
    /// written horizontally). For right-to-left languages, the text origin
    /// is on the right, and text should be drawn to the left.
    /// </summary>
    public uint BidiLevel
    {
        get { return this.bidiLevel; }
        set { this.bidiLevel = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteGlyphRun left, DWriteGlyphRun right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteGlyphRun left, DWriteGlyphRun right)
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
        return obj is DWriteGlyphRun run && Equals(run);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteGlyphRun other)
    {
        return fontFace == other.fontFace &&
               fontEMSize == other.fontEMSize &&
               glyphCount == other.glyphCount &&
               glyphIndices == other.glyphIndices &&
               glyphAdvances == other.glyphAdvances &&
               glyphOffsets == other.glyphOffsets &&
               isSideways == other.isSideways &&
               bidiLevel == other.bidiLevel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 660977048;
        hashCode = hashCode * -1521134295 + fontFace.GetHashCode();
        hashCode = hashCode * -1521134295 + fontEMSize.GetHashCode();
        hashCode = hashCode * -1521134295 + glyphCount.GetHashCode();
        hashCode = hashCode * -1521134295 + glyphIndices.GetHashCode();
        hashCode = hashCode * -1521134295 + glyphAdvances.GetHashCode();
        hashCode = hashCode * -1521134295 + glyphOffsets.GetHashCode();
        hashCode = hashCode * -1521134295 + isSideways.GetHashCode();
        hashCode = hashCode * -1521134295 + bidiLevel.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// Sets the glyph indices, advance widths, and offsets.
    /// </summary>
    /// <param name="indices">The indices to render.</param>
    /// <param name="advances">Glyph advance widths.</param>
    /// <param name="offsets">Glyph offsets.</param>
    public void SetGlyphIndicesAdvancesOffsets(ushort[] indices, float[] advances, DWriteGlyphOffset[] offsets)
    {
        if (indices is null || indices.Length == 0)
        {
            throw new ArgumentNullException(nameof(indices));
        }

        if (advances is null || advances.Length == 0)
        {
            throw new ArgumentNullException(nameof(advances));
        }

        if (offsets is null || offsets.Length == 0)
        {
            throw new ArgumentNullException(nameof(offsets));
        }

        if (advances.Length != indices.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(advances));
        }

        if (offsets.Length != indices.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offsets));
        }

        this.glyphCount = (uint)indices.Length;
        this.glyphIndices = Marshal.UnsafeAddrOfPinnedArrayElement(indices, 0);
        this.glyphAdvances = Marshal.UnsafeAddrOfPinnedArrayElement(advances, 0);
        this.glyphOffsets = Marshal.UnsafeAddrOfPinnedArrayElement(offsets, 0);
    }
}
