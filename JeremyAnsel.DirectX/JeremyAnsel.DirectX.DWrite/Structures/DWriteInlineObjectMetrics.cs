// <copyright file="DWriteInlineObjectMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Properties describing the geometric measurement of an
    /// application-defined inline object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteInlineObjectMetrics : IEquatable<DWriteInlineObjectMetrics>
    {
        /// <summary>
        /// Width of the inline object.
        /// </summary>
        private readonly float width;

        /// <summary>
        /// Height of the inline object as measured from top to bottom.
        /// </summary>
        private readonly float height;

        /// <summary>
        /// Distance from the top of the object to the baseline where it is lined up with the adjacent text.
        /// If the baseline is at the bottom, baseline simply equals height.
        /// </summary>
        private readonly float baseline;

        /// <summary>
        /// Flag indicating whether the object is to be placed upright or alongside the text baseline
        /// for vertical text.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool supportsSideways;

        /// <summary>
        /// Gets the width of the inline object.
        /// </summary>
        public float Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Gets the height of the inline object as measured from top to bottom.
        /// </summary>
        public float Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// Gets the distance from the top of the object to the baseline where it is lined up with the adjacent text.
        /// If the baseline is at the bottom, baseline simply equals height.
        /// </summary>
        public float Baseline
        {
            get { return this.baseline; }
        }

        /// <summary>
        /// Gets a value indicating whether the object is to be placed upright or alongside the text baseline
        /// for vertical text.
        /// </summary>
        public bool SupportsSideways
        {
            get { return this.supportsSideways; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteInlineObjectMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteInlineObjectMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteInlineObjectMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteInlineObjectMetrics left, DWriteInlineObjectMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteInlineObjectMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteInlineObjectMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteInlineObjectMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteInlineObjectMetrics left, DWriteInlineObjectMetrics right)
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
            if (!(obj is DWriteInlineObjectMetrics))
            {
                return false;
            }

            return this.Equals((DWriteInlineObjectMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteInlineObjectMetrics other)
        {
            return this.width == other.width
                && this.height == other.height
                && this.baseline == other.baseline
                && this.supportsSideways == other.supportsSideways;
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
                this.height,
                this.baseline,
                this.supportsSideways
            }
            .GetHashCode();
        }
    }
}
