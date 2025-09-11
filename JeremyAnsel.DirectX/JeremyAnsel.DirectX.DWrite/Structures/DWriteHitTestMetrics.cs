// <copyright file="DWriteHitTestMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Geometry enclosing of text positions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteHitTestMetrics : IEquatable<DWriteHitTestMetrics>
    {
        /// <summary>
        /// First text position within the geometry.
        /// </summary>
        private readonly uint textPosition;

        /// <summary>
        /// Number of text positions within the geometry.
        /// </summary>
        private readonly uint length;

        /// <summary>
        /// Left position of the top-left coordinate of the geometry.
        /// </summary>
        private readonly float left;

        /// <summary>
        /// Top position of the top-left coordinate of the geometry.
        /// </summary>
        private readonly float top;

        /// <summary>
        /// Geometry's width.
        /// </summary>
        private readonly float width;

        /// <summary>
        /// Geometry's height.
        /// </summary>
        private readonly float height;

        /// <summary>
        /// Bidi level of text positions enclosed within the geometry.
        /// </summary>
        private readonly uint bidiLevel;

        /// <summary>
        /// Geometry encloses text?
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isText;

        /// <summary>
        /// Range is trimmed.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isTrimmed;

        /// <summary>
        /// Gets the first text position within the geometry.
        /// </summary>
        public uint TextPosition
        {
            get { return this.textPosition; }
        }

        /// <summary>
        /// Gets the number of text positions within the geometry.
        /// </summary>
        public uint Length
        {
            get { return this.length; }
        }

        /// <summary>
        /// Gets the left position of the top-left coordinate of the geometry.
        /// </summary>
        public float Left
        {
            get { return this.left; }
        }

        /// <summary>
        /// Gets the top position of the top-left coordinate of the geometry.
        /// </summary>
        public float Top
        {
            get { return this.top; }
        }

        /// <summary>
        /// Gets the geometry's width.
        /// </summary>
        public float Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Gets the geometry's height.
        /// </summary>
        public float Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// Gets the bidi level of text positions enclosed within the geometry.
        /// </summary>
        public uint BidiLevel
        {
            get { return this.bidiLevel; }
        }

        /// <summary>
        /// Gets a value indicating whether the geometry encloses text.
        /// </summary>
        public bool IsText
        {
            get { return this.isText; }
        }

        /// <summary>
        /// Gets a value indicating whether the range is trimmed.
        /// </summary>
        public bool IsTrimmed
        {
            get { return this.isTrimmed; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteHitTestMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteHitTestMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteHitTestMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteHitTestMetrics left, DWriteHitTestMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteHitTestMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteHitTestMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteHitTestMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteHitTestMetrics left, DWriteHitTestMetrics right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DWriteHitTestMetrics)
            {
                return false;
            }

            return this.Equals((DWriteHitTestMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteHitTestMetrics other)
        {
            return this.textPosition == other.textPosition
                && this.length == other.length
                && this.left == other.left
                && this.top == other.top
                && this.width == other.width
                && this.height == other.height
                && this.bidiLevel == other.bidiLevel
                && this.isText == other.isText
                && this.isTrimmed == other.isTrimmed;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.textPosition,
                this.length,
                this.left,
                this.top,
                this.width,
                this.height,
                this.bidiLevel,
                this.isText,
                this.isTrimmed
            }
            .GetHashCode();
        }
    }
}
