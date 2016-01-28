// <copyright file="D3D11FeatureDataFormatSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Describes which resources are supported by the current graphics driver for a given format.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataFormatSupport : IEquatable<D3D11FeatureDataFormatSupport>
    {
        /// <summary>
        /// The <see cref="DxgiFormat"/> to return information on.
        /// </summary>
        private DxgiFormat inFormat;

        /// <summary>
        /// Combination of <see cref="D3D11FormatSupport"/> flags indicating which resources are supported.
        /// </summary>
        private D3D11FormatSupport outFormatSupport;

        /// <summary>
        /// Gets the <see cref="DxgiFormat"/> to return information on.
        /// </summary>
        public DxgiFormat InFormat
        {
            get { return this.inFormat; }
        }

        /// <summary>
        /// Gets a combination of <see cref="D3D11FormatSupport"/> flags indicating which resources are supported.
        /// </summary>
        public D3D11FormatSupport OutFormatSupport
        {
            get { return this.outFormatSupport; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataFormatSupport"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataFormatSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataFormatSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataFormatSupport left, D3D11FeatureDataFormatSupport right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataFormatSupport"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataFormatSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataFormatSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataFormatSupport left, D3D11FeatureDataFormatSupport right)
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
            if (!(obj is D3D11FeatureDataFormatSupport))
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataFormatSupport)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataFormatSupport other)
        {
            return this.inFormat == other.inFormat
                && this.outFormatSupport == other.outFormatSupport;
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
                this.outFormatSupport
            }
            .GetHashCode();
        }
    }
}
