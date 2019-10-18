// <copyright file="D3D11FeatureDataFormatSupport2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Describes which unordered resource options are supported by the current graphics driver for a given format.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataFormatSupport2 : IEquatable<D3D11FeatureDataFormatSupport2>
    {
        /// <summary>
        /// The <see cref="DxgiFormat"/> to return information on.
        /// </summary>
        private DxgiFormat inFormat;

        /// <summary>
        /// Combination of <see cref="D3D11FormatSupport2"/> flags indicating which unordered resource options are supported.
        /// </summary>
        private D3D11FormatSupport2 outFormatSupport2;

        /// <summary>
        /// Gets the <see cref="DxgiFormat"/> to return information on.
        /// </summary>
        public DxgiFormat InFormat
        {
            get { return this.inFormat; }
        }

        /// <summary>
        /// Gets a combination of <see cref="D3D11FormatSupport2"/> flags indicating which unordered resource options are supported.
        /// </summary>
        public D3D11FormatSupport2 OutFormatSupport2
        {
            get { return this.outFormatSupport2; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataFormatSupport2"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataFormatSupport2"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataFormatSupport2"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataFormatSupport2 left, D3D11FeatureDataFormatSupport2 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataFormatSupport2"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataFormatSupport2"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataFormatSupport2"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataFormatSupport2 left, D3D11FeatureDataFormatSupport2 right)
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
            if (!(obj is D3D11FeatureDataFormatSupport2))
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataFormatSupport2)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataFormatSupport2 other)
        {
            return this.inFormat == other.inFormat
                && this.outFormatSupport2 == other.outFormatSupport2;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.inFormat,
                this.outFormatSupport2
            }
            .GetHashCode();
        }
    }
}
