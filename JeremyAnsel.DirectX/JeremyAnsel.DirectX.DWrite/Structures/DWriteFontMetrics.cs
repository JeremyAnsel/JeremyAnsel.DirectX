// <copyright file="DWriteFontMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_FONT_METRICS structure specifies the metrics of a font face that
    /// are applicable to all glyphs within the font face.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteFontMetrics : IEquatable<DWriteFontMetrics>
    {
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
        /// Compares two <see cref="DWriteFontMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteFontMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteFontMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteFontMetrics left, DWriteFontMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteFontMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteFontMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteFontMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteFontMetrics left, DWriteFontMetrics right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DWriteFontMetrics))
            {
                return false;
            }

            return this.Equals((DWriteFontMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteFontMetrics other)
        {
            return this.designUnitsPerEM == other.designUnitsPerEM
                && this.ascent == other.ascent
                && this.descent == other.descent
                && this.lineGap == other.lineGap
                && this.capitalHeight == other.capitalHeight
                && this.letterXHeight == other.letterXHeight
                && this.underlinePosition == other.underlinePosition
                && this.underlineThickness == other.underlineThickness
                && this.strikethroughPosition == other.strikethroughPosition
                && this.strikethroughThickness == other.strikethroughThickness;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.designUnitsPerEM,
                this.ascent,
                this.descent,
                this.lineGap,
                capHeight = this.capitalHeight,
                xHeight = this.letterXHeight,
                this.underlinePosition,
                this.underlineThickness,
                this.strikethroughPosition,
                this.strikethroughThickness
            }
            .GetHashCode();
        }
    }
}
