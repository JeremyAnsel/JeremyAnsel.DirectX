// <copyright file="D2D1ColorF.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the red, green, blue, and alpha components of a color.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1ColorF : IEquatable<D2D1ColorF>
    {
        /// <summary>
        /// The red shift.
        /// </summary>
        private const int RedShift = 16;

        /// <summary>
        /// The green shift.
        /// </summary>
        private const int GreenShift = 8;

        /// <summary>
        /// The blue shift.
        /// </summary>
        private const int BlueShift = 0;

        /// <summary>
        /// The red mask.
        /// </summary>
        private const uint RedMask = 0xff << RedShift;

        /// <summary>
        /// The green mask.
        /// </summary>
        private const uint GreenMask = 0xff << GreenShift;

        /// <summary>
        /// The blue mask.
        /// </summary>
        private const uint BlueMask = 0xff << BlueShift;

        /// <summary>
        /// Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
        /// </summary>
        private float r;

        /// <summary>
        /// Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
        /// </summary>
        private float g;

        /// <summary>
        /// Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
        /// </summary>
        private float b;

        /// <summary>
        /// Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
        /// </summary>
        private float a;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
        /// </summary>
        /// <param name="rgb">The red, green, blue components.</param>
        public D2D1ColorF(uint rgb)
        {
            this.r = (float)((rgb & RedMask) >> RedShift) / 255.0f;
            this.g = (float)((rgb & GreenMask) >> GreenShift) / 255.0f;
            this.b = (float)((rgb & BlueMask) >> BlueShift) / 255.0f;
            this.a = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
        /// </summary>
        /// <param name="rgb">The red, green, blue components.</param>
        /// <param name="a">Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Reviewed")]
        public D2D1ColorF(uint rgb, float a)
        {
            this.r = (float)((rgb & RedMask) >> RedShift) / 255.0f;
            this.g = (float)((rgb & GreenMask) >> GreenShift) / 255.0f;
            this.b = (float)((rgb & BlueMask) >> BlueShift) / 255.0f;
            this.a = a;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
        /// </summary>
        /// <param name="knownColor">A known color.</param>
        public D2D1ColorF(D2D1KnownColor knownColor)
        {
            this.r = (float)(((uint)knownColor & RedMask) >> RedShift) / 255.0f;
            this.g = (float)(((uint)knownColor & GreenMask) >> GreenShift) / 255.0f;
            this.b = (float)(((uint)knownColor & BlueMask) >> BlueShift) / 255.0f;
            this.a = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
        /// </summary>
        /// <param name="knownColor">A known color.</param>
        /// <param name="a">Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Reviewed")]
        public D2D1ColorF(D2D1KnownColor knownColor, float a)
        {
            this.r = (float)(((uint)knownColor & RedMask) >> RedShift) / 255.0f;
            this.g = (float)(((uint)knownColor & GreenMask) >> GreenShift) / 255.0f;
            this.b = (float)(((uint)knownColor & BlueMask) >> BlueShift) / 255.0f;
            this.a = a;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
        /// </summary>
        /// <param name="r">Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.</param>
        /// <param name="g">Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.</param>
        /// <param name="b">Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "r", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b", Justification = "Reviewed")]
        public D2D1ColorF(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
        /// </summary>
        /// <param name="r">Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.</param>
        /// <param name="g">Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.</param>
        /// <param name="b">Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.</param>
        /// <param name="a">Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "r", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Reviewed")]
        public D2D1ColorF(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        /// Gets or sets a floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "R", Justification = "Reviewed")]
        public float R
        {
            get { return this.r; }
            set { this.r = value; }
        }

        /// <summary>
        /// Gets or sets a floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "G", Justification = "Reviewed")]
        public float G
        {
            get { return this.g; }
            set { this.g = value; }
        }

        /// <summary>
        /// Gets or sets a floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "B", Justification = "Reviewed")]
        public float B
        {
            get { return this.b; }
            set { this.b = value; }
        }

        /// <summary>
        /// Gets or sets a floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "A", Justification = "Reviewed")]
        public float A
        {
            get { return this.a; }
            set { this.a = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1ColorF"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1ColorF"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1ColorF"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1ColorF left, D2D1ColorF right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1ColorF"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1ColorF"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1ColorF"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1ColorF left, D2D1ColorF right)
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
            if (!(obj is D2D1ColorF))
            {
                return false;
            }

            return this.Equals((D2D1ColorF)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1ColorF other)
        {
            return this.r == other.r
                && this.g == other.g
                && this.b == other.b
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
                this.r,
                this.g,
                this.b,
                this.a
            }
            .GetHashCode();
        }
    }
}
