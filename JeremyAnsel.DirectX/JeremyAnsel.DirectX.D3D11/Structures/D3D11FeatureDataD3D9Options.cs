// <copyright file="D3D11FeatureDataD3D9Options.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes Direct3D 9 feature options in the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataD3D9Options : IEquatable<D3D11FeatureDataD3D9Options>
    {
        /// <summary>
        /// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isFullNonPow2TextureSupported;

        /// <summary>
        /// Gets a value indicating whether the driver supports the nonpowers-of-2-unconditionally feature.
        /// </summary>
        public bool IsFullNonPow2TextureSupported
        {
            get { return this.isFullNonPow2TextureSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D9Options"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D9Options"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D9Options"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataD3D9Options left, D3D11FeatureDataD3D9Options right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D9Options"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D9Options"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D9Options"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataD3D9Options left, D3D11FeatureDataD3D9Options right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not D3D11FeatureDataD3D9Options)
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataD3D9Options)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataD3D9Options other)
        {
            return this.isFullNonPow2TextureSupported == other.isFullNonPow2TextureSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isFullNonPow2TextureSupported
            }
            .GetHashCode();
        }
    }
}
