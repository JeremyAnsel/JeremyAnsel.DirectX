// <copyright file="D3D11FeatureDataD3D9Options1.cs" company="Jérémy Ansel">
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
    public struct D3D11FeatureDataD3D9Options1 : IEquatable<D3D11FeatureDataD3D9Options1>
    {
        /// <summary>
        /// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isFullNonPow2TextureSupported;

        /// <summary>
        /// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isDepthAsTextureWithLessEqualComparisonFilterSupported;

        /// <summary>
        /// Specifies whether the hardware and driver support simple instancing.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isSimpleInstancingSupported;

        /// <summary>
        /// Specifies whether the hardware and driver support setting a single face of a <c>TextureCube</c> as a render target while the depth stencil surface that is bound alongside can be a <c>Texture2D</c> (as opposed to <c>TextureCube</c>).
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported;

        /// <summary>
        /// Gets a value indicating whether the driver supports the nonpowers-of-2-unconditionally feature.
        /// </summary>
        public bool IsFullNonPow2TextureSupported
        {
            get { return this.isFullNonPow2TextureSupported; }
        }

        /// <summary>
        /// Gets a value indicating whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
        /// </summary>
        public bool IsDepthAsTextureWithLessEqualComparisonFilterSupported
        {
            get { return this.isDepthAsTextureWithLessEqualComparisonFilterSupported; }
        }

        /// <summary>
        /// Gets a value indicating whether the hardware and driver support simple instancing.
        /// </summary>
        public bool IsSimpleInstancingSupported
        {
            get { return this.isSimpleInstancingSupported; }
        }

        /// <summary>
        /// Gets a value indicating whether the hardware and driver support setting a single face of a <c>TextureCube</c> as a render target while the depth stencil surface that is bound alongside can be a <c>Texture2D</c> (as opposed to <c>TextureCube</c>).
        /// </summary>
        public bool IsTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported
        {
            get { return this.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D9Options1"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D9Options1"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D9Options1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataD3D9Options1 left, D3D11FeatureDataD3D9Options1 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D9Options1"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D9Options1"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D9Options1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataD3D9Options1 left, D3D11FeatureDataD3D9Options1 right)
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
            if (!(obj is D3D11FeatureDataD3D9Options1))
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataD3D9Options1)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataD3D9Options1 other)
        {
            return this.isFullNonPow2TextureSupported == other.isFullNonPow2TextureSupported
                && this.isDepthAsTextureWithLessEqualComparisonFilterSupported == other.isDepthAsTextureWithLessEqualComparisonFilterSupported
                && this.isSimpleInstancingSupported == other.isSimpleInstancingSupported
                && this.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported == other.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isFullNonPow2TextureSupported,
                this.isDepthAsTextureWithLessEqualComparisonFilterSupported,
                this.isSimpleInstancingSupported,
                this.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported
            }
            .GetHashCode();
        }
    }
}
