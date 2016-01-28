// <copyright file="DWriteFontFeature.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_FONT_FEATURE structure specifies properties used to identify and execute typographic feature in the font.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteFontFeature : IEquatable<DWriteFontFeature>
    {
        /// <summary>
        /// The feature OpenType name identifier.
        /// </summary>
        private DWriteFontFeatureTag nameTag;

        /// <summary>
        /// Execution parameter of the feature.
        /// </summary>
        /// <remarks>
        /// The parameter should be non-zero to enable the feature.  Once enabled, a feature can't be disabled again within
        /// the same range.  Features requiring a selector use this value to indicate the selector index. 
        /// </remarks>
        private uint parameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFontFeature"/> struct.
        /// </summary>
        /// <param name="nameTag">The feature OpenType name identifier.</param>
        /// <param name="parameter">Execution parameter of the feature.</param>
        public DWriteFontFeature(DWriteFontFeatureTag nameTag, uint parameter)
        {
            this.nameTag = nameTag;
            this.parameter = parameter;
        }

        /// <summary>
        /// Gets or sets the feature OpenType name identifier.
        /// </summary>
        public DWriteFontFeatureTag NameTag
        {
            get { return this.nameTag; }
            set { this.nameTag = value; }
        }

        /// <summary>
        /// Gets or sets the execution parameter of the feature.
        /// </summary>
        /// <remarks>
        /// The parameter should be non-zero to enable the feature.  Once enabled, a feature can't be disabled again within
        /// the same range.  Features requiring a selector use this value to indicate the selector index. 
        /// </remarks>
        public uint Parameter
        {
            get { return this.parameter; }
            set { this.parameter = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteFontFeature"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteFontFeature"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteFontFeature"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteFontFeature left, DWriteFontFeature right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteFontFeature"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteFontFeature"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteFontFeature"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteFontFeature left, DWriteFontFeature right)
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
            if (!(obj is DWriteFontFeature))
            {
                return false;
            }

            return this.Equals((DWriteFontFeature)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteFontFeature other)
        {
            return this.nameTag == other.nameTag
                && this.parameter == other.parameter;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.nameTag,
                this.parameter
            }
            .GetHashCode();
        }
    }
}
