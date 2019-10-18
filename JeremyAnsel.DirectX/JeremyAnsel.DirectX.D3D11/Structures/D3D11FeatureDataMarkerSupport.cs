// <copyright file="D3D11FeatureDataMarkerSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes whether a GPU profiling technique is supported.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataMarkerSupport : IEquatable<D3D11FeatureDataMarkerSupport>
    {
        /// <summary>
        /// Specifies whether the hardware and driver support a GPU profiling technique that can be used with development tools.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isProfileSupported;

        /// <summary>
        /// Gets a value indicating whether the hardware and driver support a GPU profiling technique that can be used with development tools.
        /// </summary>
        public bool IsProfileSupported
        {
            get { return this.isProfileSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataMarkerSupport"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataMarkerSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataMarkerSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataMarkerSupport left, D3D11FeatureDataMarkerSupport right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataMarkerSupport"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataMarkerSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataMarkerSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataMarkerSupport left, D3D11FeatureDataMarkerSupport right)
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
            if (!(obj is D3D11FeatureDataMarkerSupport))
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataMarkerSupport)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataMarkerSupport other)
        {
            return this.isProfileSupported == other.isProfileSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isProfileSupported
            }
            .GetHashCode();
        }
    }
}
