// <copyright file="D2D1DrawingStateDescription.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the drawing state of a render target.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1DrawingStateDescription : IEquatable<D2D1DrawingStateDescription>
    {
        /// <summary>
        /// The antialiasing mode for subsequent nontext drawing operations.
        /// </summary>
        private D2D1AntialiasMode antialiasMode;

        /// <summary>
        /// The antialiasing mode for subsequent text and glyph drawing operations.
        /// </summary>
        private D2D1TextAntialiasMode textAntialiasMode;

        /// <summary>
        /// A label for subsequent drawing operations.
        /// </summary>
        private ulong tag1;

        /// <summary>
        /// A label for subsequent drawing operations.
        /// </summary>
        private ulong tag2;

        /// <summary>
        /// The transformation to apply to subsequent drawing operations.
        /// </summary>
        private D2D1Matrix3X2F transform;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1DrawingStateDescription"/> struct.
        /// </summary>
        /// <param name="antialiasMode">The antialiasing mode for subsequent nontext drawing operations.</param>
        /// <param name="textAntialiasMode">The antialiasing mode for subsequent text and glyph drawing operations.</param>
        public D2D1DrawingStateDescription(D2D1AntialiasMode antialiasMode, D2D1TextAntialiasMode textAntialiasMode)
        {
            this.antialiasMode = antialiasMode;
            this.textAntialiasMode = textAntialiasMode;
            this.tag1 = 0U;
            this.tag2 = 0U;
            this.transform = D2D1Matrix3X2F.Identity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1DrawingStateDescription"/> struct.
        /// </summary>
        /// <param name="antialiasMode">The antialiasing mode for subsequent nontext drawing operations.</param>
        /// <param name="textAntialiasMode">The antialiasing mode for subsequent text and glyph drawing operations.</param>
        /// <param name="tag1">The first label for subsequent drawing operations.</param>
        /// <param name="tag2">The second label for subsequent drawing operations.</param>
        /// <param name="transform">The transformation to apply to subsequent drawing operations.</param>
        public D2D1DrawingStateDescription(D2D1AntialiasMode antialiasMode, D2D1TextAntialiasMode textAntialiasMode, ulong tag1, ulong tag2, D2D1Matrix3X2F transform)
        {
            this.antialiasMode = antialiasMode;
            this.textAntialiasMode = textAntialiasMode;
            this.tag1 = tag1;
            this.tag2 = tag2;
            this.transform = transform;
        }

        /// <summary>
        /// Gets default description.
        /// </summary>
        public static D2D1DrawingStateDescription Default
        {
            get { return new D2D1DrawingStateDescription(D2D1AntialiasMode.PerPrimitive, D2D1TextAntialiasMode.Default, 0U, 0U, D2D1Matrix3X2F.Identity); }
        }

        /// <summary>
        /// Gets or sets the antialiasing mode for subsequent nontext drawing operations.
        /// </summary>
        public D2D1AntialiasMode AntialiasMode
        {
            get { return this.antialiasMode; }
            set { this.antialiasMode = value; }
        }

        /// <summary>
        /// Gets or sets the antialiasing mode for subsequent text and glyph drawing operations.
        /// </summary>
        public D2D1TextAntialiasMode TextAntialiasMode
        {
            get { return this.textAntialiasMode; }
            set { this.textAntialiasMode = value; }
        }

        /// <summary>
        /// Gets or sets a label for subsequent drawing operations.
        /// </summary>
        public ulong Tag1
        {
            get { return this.tag1; }
            set { this.tag1 = value; }
        }

        /// <summary>
        /// Gets or sets a label for subsequent drawing operations.
        /// </summary>
        public ulong Tag2
        {
            get { return this.tag2; }
            set { this.tag2 = value; }
        }

        /// <summary>
        /// Gets or sets the transformation to apply to subsequent drawing operations.
        /// </summary>
        public D2D1Matrix3X2F Transform
        {
            get { return this.transform; }
            set { this.transform = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1DrawingStateDescription"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1DrawingStateDescription"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1DrawingStateDescription"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1DrawingStateDescription left, D2D1DrawingStateDescription right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1DrawingStateDescription"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1DrawingStateDescription"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1DrawingStateDescription"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1DrawingStateDescription left, D2D1DrawingStateDescription right)
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
            if (!(obj is D2D1DrawingStateDescription))
            {
                return false;
            }

            return this.Equals((D2D1DrawingStateDescription)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1DrawingStateDescription other)
        {
            return this.antialiasMode == other.antialiasMode
                && this.textAntialiasMode == other.textAntialiasMode
                && this.tag1 == other.tag1
                && this.tag2 == other.tag2
                && this.transform == other.transform;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.antialiasMode,
                this.textAntialiasMode,
                this.tag1,
                this.tag2,
                this.transform
            }
            .GetHashCode();
        }
    }
}
