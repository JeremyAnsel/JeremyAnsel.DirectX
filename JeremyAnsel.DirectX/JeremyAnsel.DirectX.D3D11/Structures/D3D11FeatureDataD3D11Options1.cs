// <copyright file="D3D11FeatureDataD3D11Options1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes Direct3D 11.2 feature options in the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataD3D11Options1 : IEquatable<D3D11FeatureDataD3D11Options1>
    {
        /// <summary>
        /// Specifies whether the hardware and driver support tiled resources.
        /// </summary>
        private readonly D3D11TiledResourcesTier tiledResourcesTier;

        /// <summary>
        /// Specifies whether the hardware and driver support the filtering options of comparing the result to the minimum or maximum value during texture sampling.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isMinMaxFilteringSupported;

        /// <summary>
        /// Specifies whether the hardware and driver also support the <c>ID3D11DeviceContext1.ClearView</c> method on depth formats.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isClearViewDepthInlyFormatsSupported;

        /// <summary>
        /// Specifies support for creating <see cref="D3D11Buffer"/> resources that can be passed to the <c>ID3D11DeviceContext.Map</c> and <c>ID3D11DeviceContext.Unmap</c> methods.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isMapOnDefaultBuffersSupported;

        /// <summary>
        /// Gets a value indicating whether the hardware and driver support tiled resources.
        /// </summary>
        public D3D11TiledResourcesTier TiledResourcesTier
        {
            get { return this.tiledResourcesTier; }
        }

        /// <summary>
        /// Gets a value indicating whether the hardware and driver support the filtering options of comparing the result to the minimum or maximum value during texture sampling.
        /// </summary>
        public bool IsMinMaxFilteringSupported
        {
            get { return this.isMinMaxFilteringSupported; }
        }

        /// <summary>
        /// Gets a value indicating whether the hardware and driver also support the <c>ID3D11DeviceContext1.ClearView</c> method on depth formats.
        /// </summary>
        public bool IsClearViewDepthInlyFormatsSupported
        {
            get { return this.isClearViewDepthInlyFormatsSupported; }
        }

        /// <summary>
        /// Gets a value indicating whether creating <see cref="D3D11Buffer"/> resources that can be passed to the <c>ID3D11DeviceContext.Map</c> and <c>ID3D11DeviceContext.Unmap</c> methods is supported.
        /// </summary>
        public bool IsMapOnDefaultBuffersSupported
        {
            get { return this.isMapOnDefaultBuffersSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D11Options1"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D11Options1"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D11Options1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataD3D11Options1 left, D3D11FeatureDataD3D11Options1 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D11Options1"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D11Options1"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D11Options1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataD3D11Options1 left, D3D11FeatureDataD3D11Options1 right)
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
            if (!(obj is D3D11FeatureDataD3D11Options1))
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataD3D11Options1)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataD3D11Options1 other)
        {
            return this.tiledResourcesTier == other.tiledResourcesTier
                && this.isMinMaxFilteringSupported == other.isMinMaxFilteringSupported
                && this.isClearViewDepthInlyFormatsSupported == other.isClearViewDepthInlyFormatsSupported
                && this.isMapOnDefaultBuffersSupported == other.isMapOnDefaultBuffersSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.tiledResourcesTier,
                this.isMinMaxFilteringSupported,
                this.isClearViewDepthInlyFormatsSupported,
                this.isMapOnDefaultBuffersSupported
            }
            .GetHashCode();
        }
    }
}
