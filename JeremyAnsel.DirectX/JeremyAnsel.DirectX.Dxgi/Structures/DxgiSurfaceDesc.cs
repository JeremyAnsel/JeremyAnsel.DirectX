// <copyright file="DxgiSurfaceDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a surface.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiSurfaceDesc : IEquatable<DxgiSurfaceDesc>
    {
        /// <summary>
        /// A value describing the surface width.
        /// </summary>
        private uint width;

        /// <summary>
        /// A value describing the surface height.
        /// </summary>
        private uint height;

        /// <summary>
        /// A member of the <see cref="DxgiFormat"/> enumeration that describes the surface format.
        /// </summary>
        private DxgiFormat format;

        /// <summary>
        /// A <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters for the surface.
        /// </summary>
        private DxgiSampleDesc sampleDesc;

        /// <summary>
        /// Gets or sets a value describing the surface width.
        /// </summary>
        public uint Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets a value describing the surface height.
        /// </summary>
        public uint Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiFormat"/> enumeration that describes the surface format.
        /// </summary>
        public DxgiFormat Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters for the surface.
        /// </summary>
        public DxgiSampleDesc SampleDesc
        {
            get { return this.sampleDesc; }
            set { this.sampleDesc = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiSurfaceDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSurfaceDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSurfaceDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiSurfaceDesc left, DxgiSurfaceDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiSurfaceDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSurfaceDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSurfaceDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiSurfaceDesc left, DxgiSurfaceDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}x{1} {2} {3}",
                this.width,
                this.height,
                this.format,
                this.sampleDesc);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiSurfaceDesc))
            {
                return false;
            }

            return this.Equals((DxgiSurfaceDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiSurfaceDesc other)
        {
            return this.width == other.width
                && this.height == other.height
                && this.format == other.format
                && this.sampleDesc == other.sampleDesc;
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
                this.format,
                this.sampleDesc
            }
            .GetHashCode();
        }
    }
}
