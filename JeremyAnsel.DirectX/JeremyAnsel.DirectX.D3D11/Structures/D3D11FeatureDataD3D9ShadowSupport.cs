// <copyright file="D3D11FeatureDataD3D9ShadowSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes Direct3D 9 shadow support in the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataD3D9ShadowSupport : IEquatable<D3D11FeatureDataD3D9ShadowSupport>
    {
        /// <summary>
        /// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isDepthAsTextureWithLessEqualComparisonFilterSupported;

        /// <summary>
        /// Gets a value indicating whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
        /// </summary>
        public bool IsDepthAsTextureWithLessEqualComparisonFilterSupported
        {
            get { return this.isDepthAsTextureWithLessEqualComparisonFilterSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D9ShadowSupport"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D9ShadowSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D9ShadowSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataD3D9ShadowSupport left, D3D11FeatureDataD3D9ShadowSupport right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D9ShadowSupport"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D9ShadowSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D9ShadowSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataD3D9ShadowSupport left, D3D11FeatureDataD3D9ShadowSupport right)
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
            if (obj is not D3D11FeatureDataD3D9ShadowSupport)
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataD3D9ShadowSupport)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataD3D9ShadowSupport other)
        {
            return this.isDepthAsTextureWithLessEqualComparisonFilterSupported == other.isDepthAsTextureWithLessEqualComparisonFilterSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isDepthAsTextureWithLessEqualComparisonFilterSupported
            }
            .GetHashCode();
        }
    }
}
