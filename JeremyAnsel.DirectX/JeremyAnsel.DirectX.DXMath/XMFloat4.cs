// <copyright file="XMFloat4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4D vector consisting of four single-precision floating-point values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMFloat4 : IEquatable<XMFloat4>, IFormattable
    {
        /// <summary>
        /// The x-coordinate of the vector.
        /// </summary>
        private float x;

        /// <summary>
        /// The y-coordinate of the vector.
        /// </summary>
        private float y;

        /// <summary>
        /// The z-coordinate of the vector.
        /// </summary>
        private float z;

        /// <summary>
        /// The w-coordinate of the vector.
        /// </summary>
        private float w;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat4"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the vector.</param>
        /// <param name="y">The y-coordinate of the vector.</param>
        /// <param name="z">The z-coordinate of the vector.</param>
        /// <param name="w">The w-coordinate of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat4(float[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.x = array[0];
            this.y = array[1];
            this.z = array[2];
            this.w = array[3];
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public float Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets the w-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public float W
        {
            get { return this.w; }
            set { this.w = value; }
        }

        /// <summary>
        /// Converts a <see cref="XMFloat4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat4"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMFloat4 value)
        {
            return XMVector.LoadFloat4(value);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMFloat4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMFloat4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMFloat4(XMVector value)
        {
            value.StoreFloat4(out XMFloat4 ret);
            return ret;
        }

        /// <summary>
        /// Compares two <see cref="XMFloat4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMFloat4 left, XMFloat4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMFloat4 left, XMFloat4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMFloat4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMFloat4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat4 FromVector(XMVector value)
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is XMFloat4))
            {
                return false;
            }

            return this.Equals((XMFloat4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMFloat4 other)
        {
            return this.x == other.x
                && this.y == other.y
                && this.z == other.z
                && this.w == other.w;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.x,
                this.y,
                this.z,
                this.w
            }
            .GetHashCode();
        }

        /// <summary>
        /// Converts a <see cref="XMFloat4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return ToString("F2", CultureInfo.InvariantCulture);
        }

        /// <inheritdoc/>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return string.Concat(
                "(",
                x.ToString(format, formatProvider),
                ";",
                y.ToString(format, formatProvider),
                ";",
                z.ToString(format, formatProvider),
                ";",
                w.ToString(format, formatProvider),
                ")"
                );
        }
    }
}
