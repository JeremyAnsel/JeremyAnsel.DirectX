// <copyright file="XMColorRgba.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 32-bit Alpha Red Green Blue (ARGB) color vector, where each color channel is specified as an unsigned 8 bit integer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMColorRgba : IEquatable<XMColorRgba>
    {
        /// <summary>
        /// The blue component.
        /// </summary>
        private byte b;

        /// <summary>
        /// The green component.
        /// </summary>
        private byte g;

        /// <summary>
        /// The red component.
        /// </summary>
        private byte r;

        /// <summary>
        /// The alpha component.
        /// </summary>
        private byte a;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMColorRgba"/> struct.
        /// </summary>
        /// <param name="color">A packed value representing the color.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMColorRgba(uint color)
        {
            fixed (XMColorRgba* c = &this)
            {
                *(uint*)c = color;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMColorRgba"/> struct.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "r", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMColorRgba(float r, float g, float b, float a)
        {
            this = new XMVector(r, g, b, a);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMColorRgba"/> struct.
        /// </summary>
        /// <param name="values">The components of the color.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMColorRgba(float[] values)
        {
            this = XMVector.LoadFloat4(new XMFloat4(values));
        }

        /// <summary>
        /// Gets or sets the blue component.
        /// </summary>
        public byte Blue
        {
            get { return this.b; }
            set { this.b = value; }
        }

        /// <summary>
        /// Gets or sets the green component.
        /// </summary>
        public byte Green
        {
            get { return this.g; }
            set { this.g = value; }
        }

        /// <summary>
        /// Gets or sets the red component.
        /// </summary>
        public byte Red
        {
            get { return this.r; }
            set { this.r = value; }
        }

        /// <summary>
        /// Gets or sets the alpha component.
        /// </summary>
        public byte Alpha
        {
            get { return this.a; }
            set { this.a = value; }
        }

        /// <summary>
        /// Converts a <see cref="XMColorRgba"/> to a packed value.
        /// </summary>
        /// <param name="color">A <see cref="XMColorRgba"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator uint(XMColorRgba color)
        {
            return *(uint*)&color;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMColorRgba"/>.
        /// </summary>
        /// <param name="color">A packed value.</param>
        /// <returns>A <see cref="XMColorRgba"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMColorRgba(uint color)
        {
            return *(XMColorRgba*)&color;
        }

        /// <summary>
        /// Converts a <see cref="XMColorRgba"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMColorRgba"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMColorRgba value)
        {
            //// int32_t -> Float conversions are done in one instruction.
            //// uint32_t -> Float calls a runtime function. Keep in int32_t

            int i_color = *(int*)&value;

            return new XMVector(
                (float)((i_color >> 16) & 0xFF) * (1.0f / 255.0f),
                (float)((i_color >> 8) & 0xFF) * (1.0f / 255.0f),
                (float)(i_color & 0xFF) * (1.0f / 255.0f),
                (float)((i_color >> 24) & 0xFF) * (1.0f / 255.0f));
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMColorRgba"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMColorRgba"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMColorRgba(XMVector value)
        {
            XMVector n = value.Saturate();
            n = XMVector.Multiply(n, XMGlobalConstants.UByteMax);
            n = n.Round();

            uint color = ((uint)n.W << 24) | ((uint)n.X << 16) | ((uint)n.Y << 8) | ((uint)n.Z);
            return new XMColorRgba(color);
        }

        /// <summary>
        /// Compares two <see cref="XMColorRgba"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMColorRgba"/> to compare.</param>
        /// <param name="right">The right <see cref="XMColorRgba"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMColorRgba left, XMColorRgba right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMColorRgba"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMColorRgba"/> to compare.</param>
        /// <param name="right">The right <see cref="XMColorRgba"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMColorRgba left, XMColorRgba right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMColorRgba"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMColorRgba"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMColorRgba FromArgb(uint value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMColorRgba"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMColorRgba"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMColorRgba FromVector(XMVector value)
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
            if (!(obj is XMColorRgba))
            {
                return false;
            }

            return this.Equals((XMColorRgba)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMColorRgba other)
        {
            return this.b == other.b
                && this.g == other.g
                && this.r == other.r
                && this.a == other.a;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.b,
                this.g,
                this.r,
                this.a
            }
            .GetHashCode();
        }

        /// <summary>
        /// Converts a <see cref="XMColorRgba"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint ToArgb()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMColorRgba"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
