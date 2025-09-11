// <copyright file="D3D11Texture1DRtv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies the subresource from a 1D texture to use in a render-target view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Texture1DRtv : IEquatable<D3D11Texture1DRtv>
    {
        /// <summary>
        /// The index of the mipmap level to use mip slice.
        /// </summary>
        private uint mipSlice;

        /// <summary>
        /// Gets or sets the index of the mipmap level to use mip slice.
        /// </summary>
        public uint MipSlice
        {
            get { return this.mipSlice; }
            set { this.mipSlice = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture1DRtv"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture1DRtv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture1DRtv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Texture1DRtv left, D3D11Texture1DRtv right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture1DRtv"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture1DDsv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture1DDsv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Texture1DRtv left, D3D11Texture1DRtv right)
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
            if (obj is not D3D11Texture1DRtv)
            {
                return false;
            }

            return this.Equals((D3D11Texture1DRtv)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Texture1DRtv other)
        {
            return this.mipSlice == other.mipSlice;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.mipSlice
            }
            .GetHashCode();
        }
    }
}
