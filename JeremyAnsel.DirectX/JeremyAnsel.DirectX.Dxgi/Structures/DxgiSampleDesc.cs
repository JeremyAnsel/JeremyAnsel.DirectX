// <copyright file="DxgiSampleDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes multi-sampling parameters for a resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiSampleDesc : IEquatable<DxgiSampleDesc>
    {
        /// <summary>
        /// The number of multi-samples per pixel.
        /// </summary>
        private uint count;

        /// <summary>
        /// The image quality level. The higher the quality, the lower the performance.
        /// </summary>
        private uint quality;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSampleDesc"/> struct.
        /// </summary>
        /// <param name="count">The number of multi-samples per pixel.</param>
        /// <param name="quality">The image quality level. The higher the quality, the lower the performance.</param>
        public DxgiSampleDesc(uint count, uint quality)
        {
            this.count = count;
            this.quality = quality;
        }

        /// <summary>
        /// Gets or sets the number of multi-samples per pixel.
        /// </summary>
        public uint Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        /// <summary>
        /// Gets or sets the image quality level. The higher the quality, the lower the performance.
        /// </summary>
        public uint Quality
        {
            get { return this.quality; }
            set { this.quality = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiSampleDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSampleDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSampleDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiSampleDesc left, DxgiSampleDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiSampleDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSampleDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSampleDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiSampleDesc left, DxgiSampleDesc right)
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
                "Count: {0}; Quality: {1}",
                this.count,
                this.quality);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiSampleDesc))
            {
                return false;
            }

            return this.Equals((DxgiSampleDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiSampleDesc other)
        {
            return this.count == other.count
                && this.quality == other.quality;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.count,
                this.quality
            }
            .GetHashCode();
        }
    }
}
