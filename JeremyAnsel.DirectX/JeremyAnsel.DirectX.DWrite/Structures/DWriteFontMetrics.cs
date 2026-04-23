// <copyright file="DWriteFontMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_FONT_METRICS structure specifies the metrics of a font face that
/// are applicable to all glyphs within the font face.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteFontMetrics : IEquatable<DWriteFontMetrics>
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
        size += sizeof(ushort) * 7;
        size += sizeof(short) * 3;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteFontMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteFontMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteFontMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.designUnitsPerEM);
            DXMarshal.Write(ref buffer, obj.ascent);
            DXMarshal.Write(ref buffer, obj.descent);
            DXMarshal.Write(ref buffer, obj.lineGap);
            DXMarshal.Write(ref buffer, obj.capitalHeight);
            DXMarshal.Write(ref buffer, obj.letterXHeight);
            DXMarshal.Write(ref buffer, obj.underlinePosition);
            DXMarshal.Write(ref buffer, obj.underlineThickness);
            DXMarshal.Write(ref buffer, obj.strikethroughPosition);
            DXMarshal.Write(ref buffer, obj.strikethroughThickness);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteFontMetrics NativeReadFrom(nint buffer)
    {
        DWriteFontMetrics obj;
        obj.designUnitsPerEM = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.ascent = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.descent = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.lineGap = DXMarshal.ReadInt16(ref buffer);
        obj.capitalHeight = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.letterXHeight = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.underlinePosition = DXMarshal.ReadInt16(ref buffer);
        obj.underlineThickness = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.strikethroughPosition = DXMarshal.ReadInt16(ref buffer);
        obj.strikethroughThickness = DXMarshal.ReadUnsignedInt16(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteFontMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of font design units per em unit.
    /// Font files use their own coordinate system of font design units.
    /// A font design unit is the smallest measurable unit in the em square,
    /// an imaginary square that is used to size and align glyphs.
    /// The concept of em square is used as a reference scale factor when defining font size and device transformation semantics.
    /// The size of one em square is also commonly used to compute the paragraph indentation value.
    /// </summary>
    private ushort designUnitsPerEM;

    /// <summary>
    /// Ascent value of the font face in font design units.
    /// Ascent is the distance from the top of font character alignment box to English baseline.
    /// </summary>
    private ushort ascent;

    /// <summary>
    /// Descent value of the font face in font design units.
    /// Descent is the distance from the bottom of font character alignment box to English baseline.
    /// </summary>
    private ushort descent;

    /// <summary>
    /// Line gap in font design units.
    /// Recommended additional white space to add between lines to improve legibility. The recommended line spacing 
    /// (baseline-to-baseline distance) is thus the sum of ascent, descent, and lineGap. The line gap is usually 
    /// positive or zero but can be negative, in which case the recommended line spacing is less than the height
    /// of the character alignment box.
    /// </summary>
    private short lineGap;

    /// <summary>
    /// Cap height value of the font face in font design units.
    /// Cap height is the distance from English baseline to the top of a typical English capital.
    /// Capital "H" is often used as a reference character for the purpose of calculating the cap height value.
    /// </summary>
    private ushort capitalHeight;

    /// <summary>
    /// x-height value of the font face in font design units.
    /// x-height is the distance from English baseline to the top of lowercase letter "x", or a similar lowercase character.
    /// </summary>
    private ushort letterXHeight;

    /// <summary>
    /// The underline position value of the font face in font design units.
    /// Underline position is the position of underline relative to the English baseline.
    /// The value is usually made negative in order to place the underline below the baseline.
    /// </summary>
    private short underlinePosition;

    /// <summary>
    /// The suggested underline thickness value of the font face in font design units.
    /// </summary>
    private ushort underlineThickness;

    /// <summary>
    /// The strikethrough position value of the font face in font design units.
    /// Strikethrough position is the position of strikethrough relative to the English baseline.
    /// The value is usually made positive in order to place the strikethrough above the baseline.
    /// </summary>
    private short strikethroughPosition;

    /// <summary>
    /// The suggested strikethrough thickness value of the font face in font design units.
    /// </summary>
    private ushort strikethroughThickness;

    /// <summary>
    /// Gets the number of font design units per em unit.
    /// Font files use their own coordinate system of font design units.
    /// A font design unit is the smallest measurable unit in the em square,
    /// an imaginary square that is used to size and align glyphs.
    /// The concept of em square is used as a reference scale factor when defining font size and device transformation semantics.
    /// The size of one em square is also commonly used to compute the paragraph indentation value.
    /// </summary>
    public ushort DesignUnitsPerEM
    {
        get { return this.designUnitsPerEM; }
    }

    /// <summary>
    /// Gets the ascent value of the font face in font design units.
    /// Ascent is the distance from the top of font character alignment box to English baseline.
    /// </summary>
    public ushort Ascent
    {
        get { return this.ascent; }
    }

    /// <summary>
    /// Gets the descent value of the font face in font design units.
    /// Descent is the distance from the bottom of font character alignment box to English baseline.
    /// </summary>
    public ushort Descent
    {
        get { return this.descent; }
    }

    /// <summary>
    /// Gets the line gap in font design units.
    /// Recommended additional white space to add between lines to improve legibility. The recommended line spacing 
    /// (baseline-to-baseline distance) is thus the sum of ascent, descent, and lineGap. The line gap is usually 
    /// positive or zero but can be negative, in which case the recommended line spacing is less than the height
    /// of the character alignment box.
    /// </summary>
    public short LineGap
    {
        get { return this.lineGap; }
    }

    /// <summary>
    /// Gets the cap height value of the font face in font design units.
    /// Cap height is the distance from English baseline to the top of a typical English capital.
    /// Capital "H" is often used as a reference character for the purpose of calculating the cap height value.
    /// </summary>
    public ushort CapitalHeight
    {
        get { return this.capitalHeight; }
    }

    /// <summary>
    /// Gets the x-height value of the font face in font design units.
    /// x-height is the distance from English baseline to the top of lowercase letter "x", or a similar lowercase character.
    /// </summary>
    public ushort LetterXHeight
    {
        get { return this.letterXHeight; }
    }

    /// <summary>
    /// Gets the underline position value of the font face in font design units.
    /// Underline position is the position of underline relative to the English baseline.
    /// The value is usually made negative in order to place the underline below the baseline.
    /// </summary>
    public short UnderlinePosition
    {
        get { return this.underlinePosition; }
    }

    /// <summary>
    /// Gets the suggested underline thickness value of the font face in font design units.
    /// </summary>
    public ushort UnderlineThickness
    {
        get { return this.underlineThickness; }
    }

    /// <summary>
    /// Gets the strikethrough position value of the font face in font design units.
    /// Strikethrough position is the position of strikethrough relative to the English baseline.
    /// The value is usually made positive in order to place the strikethrough above the baseline.
    /// </summary>
    public short StrikethroughPosition
    {
        get { return this.strikethroughPosition; }
    }

    /// <summary>
    /// Gets the suggested strikethrough thickness value of the font face in font design units.
    /// </summary>
    public ushort StrikethroughThickness
    {
        get { return this.strikethroughThickness; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteFontMetrics left, DWriteFontMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteFontMetrics left, DWriteFontMetrics right)
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
        return obj is DWriteFontMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteFontMetrics other)
    {
        return designUnitsPerEM == other.designUnitsPerEM &&
               ascent == other.ascent &&
               descent == other.descent &&
               lineGap == other.lineGap &&
               capitalHeight == other.capitalHeight &&
               letterXHeight == other.letterXHeight &&
               underlinePosition == other.underlinePosition &&
               underlineThickness == other.underlineThickness &&
               strikethroughPosition == other.strikethroughPosition &&
               strikethroughThickness == other.strikethroughThickness;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -379770132;
        hashCode = hashCode * -1521134295 + designUnitsPerEM.GetHashCode();
        hashCode = hashCode * -1521134295 + ascent.GetHashCode();
        hashCode = hashCode * -1521134295 + descent.GetHashCode();
        hashCode = hashCode * -1521134295 + lineGap.GetHashCode();
        hashCode = hashCode * -1521134295 + capitalHeight.GetHashCode();
        hashCode = hashCode * -1521134295 + letterXHeight.GetHashCode();
        hashCode = hashCode * -1521134295 + underlinePosition.GetHashCode();
        hashCode = hashCode * -1521134295 + underlineThickness.GetHashCode();
        hashCode = hashCode * -1521134295 + strikethroughPosition.GetHashCode();
        hashCode = hashCode * -1521134295 + strikethroughThickness.GetHashCode();
        return hashCode;
    }
}
