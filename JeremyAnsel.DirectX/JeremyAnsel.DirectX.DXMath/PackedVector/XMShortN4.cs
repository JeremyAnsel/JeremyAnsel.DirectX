// <copyright file="XMShortN4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4D vector for storing signed, normalized values as signed 16-bit integers.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMShortN4 : IEquatable<XMShortN4>
    {
        /// <summary>
        /// The x-coordinate of the vector.
        /// </summary>
        private short x;

        /// <summary>
        /// The y-coordinate of the vector.
        /// </summary>
        private short y;

        /// <summary>
        /// The z-coordinate of the vector.
        /// </summary>
        private short z;

        /// <summary>
        /// The w-coordinate of the vector.
        /// </summary>
        private short w;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMShortN4"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMShortN4(ulong packed)
        {
            fixed (XMShortN4* v = &this)
            {
                *(ulong*)v = packed;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMShortN4"/> struct.
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
        public XMShortN4(short x, short y, short z, short w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMShortN4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMShortN4(short[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException("array");
            }

            this.x = array[0];
            this.y = array[1];
            this.z = array[2];
            this.w = array[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMShortN4"/> struct.
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
        public XMShortN4(float x, float y, float z, float w)
        {
            this = new XMVector(x, y, z, w);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMShortN4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMShortN4(float[] array)
        {
            this = XMVector.LoadFloat4(new XMFloat4(array));
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public short X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public short Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public short Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets the w-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public short W
        {
            get { return this.w; }
            set { this.w = value; }
        }

        /// <summary>
        /// Converts a <see cref="XMShortN4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMShortN4"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMVector(XMShortN4 value)
        {
            return new XMVector(
                (value.x == -32768) ? -1.0f : ((float)value.x * (1.0f / 32767.0f)),
                (value.y == -32768) ? -1.0f : ((float)value.y * (1.0f / 32767.0f)),
                (value.z == -32768) ? -1.0f : ((float)value.z * (1.0f / 32767.0f)),
                (value.w == -32768) ? -1.0f : ((float)value.w * (1.0f / 32767.0f)));
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMShortN4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMShortN4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMShortN4(XMVector value)
        {
            XMVector n = value.Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One);
            n = XMVector.Multiply(n, XMGlobalConstants.ShortMax);
            n = n.Round();

            return new XMShortN4(
                (short)n.X,
                (short)n.Y,
                (short)n.Z,
                (short)n.W);
        }

        /// <summary>
        /// Compares two <see cref="XMShortN4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMShortN4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMShortN4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMShortN4 left, XMShortN4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMShortN4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMShortN4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMShortN4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMShortN4 left, XMShortN4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMShortN4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMShortN4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMShortN4 FromVector(XMVector value)
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is XMShortN4))
            {
                return false;
            }

            return this.Equals((XMShortN4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMShortN4 other)
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
        /// Converts a <see cref="XMShortN4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
