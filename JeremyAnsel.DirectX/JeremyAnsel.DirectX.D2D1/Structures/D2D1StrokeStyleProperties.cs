// <copyright file="D2D1StrokeStyleProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the stroke that outlines a shape.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1StrokeStyleProperties : IEquatable<D2D1StrokeStyleProperties>
    {
        /// <summary>
        /// The cap applied to the start of all the open figures in a stroked geometry.
        /// </summary>
        private D2D1CapStyle startCap;

        /// <summary>
        /// The cap applied to the end of all the open figures in a stroked geometry.
        /// </summary>
        private D2D1CapStyle endCap;

        /// <summary>
        /// The shape at either end of each dash segment.
        /// </summary>
        private D2D1CapStyle dashCap;

        /// <summary>
        /// A value that describes how segments are joined.
        /// </summary>
        private D2D1LineJoin lineJoin;

        /// <summary>
        /// The limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.
        /// </summary>
        private float miterLimit;

        /// <summary>
        /// A value that specifies whether the stroke has a dash pattern and, if so, the dash style.
        /// </summary>
        private D2D1DashStyle dashStyle;

        /// <summary>
        /// A value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of stroke width, toward the end of the stroked geometry.
        /// </summary>
        private float dashOffset;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1StrokeStyleProperties"/> struct.
        /// </summary>
        /// <param name="startCap">The cap applied to the start of all the open figures in a stroked geometry.</param>
        /// <param name="endCap">The cap applied to the end of all the open figures in a stroked geometry.</param>
        /// <param name="dashCap">The shape at either end of each dash segment.</param>
        /// <param name="lineJoin">A value that describes how segments are joined.</param>
        /// <param name="miterLimit">The limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.</param>
        /// <param name="dashStyle">A value that specifies whether the stroke has a dash pattern and, if so, the dash style.</param>
        /// <param name="dashOffset">A value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of stroke width, toward the end of the stroked geometry.</param>
        public D2D1StrokeStyleProperties(D2D1CapStyle startCap, D2D1CapStyle endCap, D2D1CapStyle dashCap, D2D1LineJoin lineJoin, float miterLimit, D2D1DashStyle dashStyle, float dashOffset)
        {
            this.startCap = startCap;
            this.endCap = endCap;
            this.dashCap = dashCap;
            this.lineJoin = lineJoin;
            this.miterLimit = miterLimit;
            this.dashStyle = dashStyle;
            this.dashOffset = dashOffset;
        }

        /// <summary>
        /// Gets default properties (Flat, Flat, Flat, Miter, 10, Solid, 0).
        /// </summary>
        public static D2D1StrokeStyleProperties Default
        {
            get { return new D2D1StrokeStyleProperties(D2D1CapStyle.Flat, D2D1CapStyle.Flat, D2D1CapStyle.Flat, D2D1LineJoin.Miter, 10.0f, D2D1DashStyle.Solid, 0.0f); }
        }

        /// <summary>
        /// Gets or sets the cap applied to the start of all the open figures in a stroked geometry.
        /// </summary>
        public D2D1CapStyle StartCap
        {
            get { return this.startCap; }
            set { this.startCap = value; }
        }

        /// <summary>
        /// Gets or sets the cap applied to the end of all the open figures in a stroked geometry.
        /// </summary>
        public D2D1CapStyle EndCap
        {
            get { return this.endCap; }
            set { this.endCap = value; }
        }

        /// <summary>
        /// Gets or sets the shape at either end of each dash segment.
        /// </summary>
        public D2D1CapStyle DashCap
        {
            get { return this.dashCap; }
            set { this.dashCap = value; }
        }

        /// <summary>
        /// Gets or sets a value that describes how segments are joined.
        /// </summary>
        public D2D1LineJoin LineJoin
        {
            get { return this.lineJoin; }
            set { this.lineJoin = value; }
        }

        /// <summary>
        /// Gets or sets the limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.
        /// </summary>
        public float MiterLimit
        {
            get { return this.miterLimit; }
            set { this.miterLimit = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the stroke has a dash pattern and, if so, the dash style.
        /// </summary>
        public D2D1DashStyle DashStyle
        {
            get { return this.dashStyle; }
            set { this.dashStyle = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of stroke width, toward the end of the stroked geometry.
        /// </summary>
        public float DashOffset
        {
            get { return this.dashOffset; }
            set { this.dashOffset = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1StrokeStyleProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1StrokeStyleProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1StrokeStyleProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1StrokeStyleProperties left, D2D1StrokeStyleProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1StrokeStyleProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1StrokeStyleProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1StrokeStyleProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1StrokeStyleProperties left, D2D1StrokeStyleProperties right)
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
            if (!(obj is D2D1StrokeStyleProperties))
            {
                return false;
            }

            return this.Equals((D2D1StrokeStyleProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1StrokeStyleProperties other)
        {
            return this.startCap == other.startCap
                && this.endCap == other.endCap
                && this.dashCap == other.dashCap
                && this.lineJoin == other.lineJoin
                && this.miterLimit == other.miterLimit
                && this.dashStyle == other.dashStyle
                && this.dashOffset == other.dashOffset;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.startCap,
                this.endCap,
                this.dashCap,
                this.lineJoin,
                this.miterLimit,
                this.dashStyle,
                this.dashOffset
            }
            .GetHashCode();
        }
    }
}
