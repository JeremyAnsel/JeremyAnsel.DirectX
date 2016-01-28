// <copyright file="DxgiRational.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a rational number.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiRational : IEquatable<DxgiRational>
    {
        /// <summary>
        /// An unsigned integer value representing the top of the rational number.
        /// </summary>
        private uint numerator;

        /// <summary>
        /// An unsigned integer value representing the bottom of the rational number.
        /// </summary>
        private uint denominator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiRational"/> struct.
        /// </summary>
        /// <param name="numerator">An unsigned integer value representing the top of the rational number.</param>
        /// <param name="denominator">An unsigned integer value representing the bottom of the rational number.</param>
        public DxgiRational(uint numerator, uint denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        /// <summary>
        /// Gets an unsigned integer value representing the top of the rational number.
        /// </summary>
        public uint Numerator
        {
            get { return this.numerator; }
        }

        /// <summary>
        /// Gets an unsigned integer value representing the bottom of the rational number.
        /// </summary>
        public uint Denominator
        {
            get { return this.denominator; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiRational"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiRational"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiRational"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiRational left, DxgiRational right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiRational"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiRational"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiRational"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiRational left, DxgiRational right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (this.numerator == 0)
            {
                return "0";
            }

            if (this.denominator == 0 || this.denominator == 1)
            {
                return this.denominator.ToString(CultureInfo.InvariantCulture);
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", this.numerator, this.denominator);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiRational))
            {
                return false;
            }

            return this.Equals((DxgiRational)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiRational other)
        {
            return this.numerator == other.numerator
                && this.denominator == other.denominator;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.numerator,
                this.denominator
            }
            .GetHashCode();
        }
    }
}
