// <copyright file="D3D11Texture1DUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a unordered-access 1D texture resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Texture1DUav : IEquatable<D3D11Texture1DUav>
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        private uint mipSlice;

        /// <summary>
        /// Gets or sets the mipmap slice index.
        /// </summary>
        public uint MipSlice
        {
            get { return this.mipSlice; }
            set { this.mipSlice = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture1DUav"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture1DUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture1DUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Texture1DUav left, D3D11Texture1DUav right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture1DUav"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture1DUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture1DUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Texture1DUav left, D3D11Texture1DUav right)
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
            if (obj is not D3D11Texture1DUav)
            {
                return false;
            }

            return this.Equals((D3D11Texture1DUav)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Texture1DUav other)
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
