// <copyright file="DWriteStrikethrough.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_STRIKETHROUGH structure contains information about the size and
    /// placement of strikethroughs. All coordinates are in device independent
    /// pixels (DIPs).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteStrikethrough : IEquatable<DWriteStrikethrough>
    {
        /// <summary>
        /// Width of the strikethrough, measured parallel to the baseline.
        /// </summary>
        private float width;

        /// <summary>
        /// Thickness of the strikethrough, measured perpendicular to the
        /// baseline.
        /// </summary>
        private float thickness;

        /// <summary>
        /// Offset of the strikethrough from the baseline.
        /// A positive offset represents a position below the baseline and
        /// a negative offset is above.
        /// </summary>
        private float offset;

        /// <summary>
        /// Reading direction of the text associated with the strikethrough.  This
        /// value is used to interpret whether the width value runs horizontally 
        /// or vertically.
        /// </summary>
        private DWriteReadingDirection readingDirection;

        /// <summary>
        /// Flow direction of the text associated with the strikethrough.  This 
        /// value is used to interpret whether the thickness value advances top to
        /// bottom, left to right, or right to left.
        /// </summary>
        private DWriteFlowDirection flowDirection;

        /// <summary>
        /// Locale of the range. Can be pertinent where the locale affects the style.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        private string localeName;

        /// <summary>
        /// The measuring mode can be useful to the renderer to determine how
        /// underlines are rendered, e.g. rounding the thickness to a whole pixel
        /// in GDI-compatible modes.
        /// </summary>
        private DWriteMeasuringMode measuringMode;

        /// <summary>
        /// Gets or sets the width of the strikethrough, measured parallel to the baseline.
        /// </summary>
        public float Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the thickness of the strikethrough, measured perpendicular to the
        /// baseline.
        /// </summary>
        public float Thickness
        {
            get { return this.thickness; }
            set { this.thickness = value; }
        }

        /// <summary>
        /// Gets or sets the offset of the strikethrough from the baseline.
        /// A positive offset represents a position below the baseline and
        /// a negative offset is above.
        /// </summary>
        public float Offset
        {
            get { return this.offset; }
            set { this.offset = value; }
        }

        /// <summary>
        /// Gets or sets the reading direction of the text associated with the strikethrough.  This
        /// value is used to interpret whether the width value runs horizontally 
        /// or vertically.
        /// </summary>
        public DWriteReadingDirection ReadingDirection
        {
            get { return this.readingDirection; }
            set { this.readingDirection = value; }
        }

        /// <summary>
        /// Gets or sets the flow direction of the text associated with the strikethrough.  This 
        /// value is used to interpret whether the thickness value advances top to
        /// bottom, left to right, or right to left.
        /// </summary>
        public DWriteFlowDirection FlowDirection
        {
            get { return this.flowDirection; }
            set { this.flowDirection = value; }
        }

        /// <summary>
        /// Gets or sets the locale of the range. Can be pertinent where the locale affects the style.
        /// </summary>
        public string LocaleName
        {
            get { return this.localeName; }
            set { this.localeName = value; }
        }

        /// <summary>
        /// Gets or sets the measuring mode can be useful to the renderer to determine how
        /// underlines are rendered, e.g. rounding the thickness to a whole pixel
        /// in GDI-compatible modes.
        /// </summary>
        public DWriteMeasuringMode MeasuringMode
        {
            get { return this.measuringMode; }
            set { this.measuringMode = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteStrikethrough"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteStrikethrough"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteStrikethrough"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteStrikethrough left, DWriteStrikethrough right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteStrikethrough"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteStrikethrough"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteStrikethrough"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteStrikethrough left, DWriteStrikethrough right)
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
            if (!(obj is DWriteStrikethrough))
            {
                return false;
            }

            return this.Equals((DWriteStrikethrough)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteStrikethrough other)
        {
            return this.width == other.width
                && this.thickness == other.thickness
                && this.offset == other.offset
                && this.readingDirection == other.readingDirection
                && this.flowDirection == other.flowDirection
                && this.localeName == other.localeName
                && this.measuringMode == other.measuringMode;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.width,
                this.thickness,
                this.offset,
                this.readingDirection,
                this.flowDirection,
                this.localeName,
                this.measuringMode
            }
            .GetHashCode();
        }
    }
}
