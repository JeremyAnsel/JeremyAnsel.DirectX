// <copyright file="D3D11Texture3DUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a unordered-access 3D texture resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Texture3DUav : IEquatable<D3D11Texture3DUav>
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        private uint mipSlice;

        /// <summary>
        /// The zero-based index of the first depth slice to be accessed.
        /// </summary>
        private uint firstWSlice;

        /// <summary>
        /// The number of depth slices.
        /// </summary>
        private uint wsize;

        /// <summary>
        /// Gets or sets the mipmap slice index.
        /// </summary>
        public uint MipSlice
        {
            get { return this.mipSlice; }
            set { this.mipSlice = value; }
        }

        /// <summary>
        /// Gets or sets the zero-based index of the first depth slice to be accessed.
        /// </summary>
        public uint FirstWSlice
        {
            get { return this.firstWSlice; }
            set { this.firstWSlice = value; }
        }

        /// <summary>
        /// Gets or sets the number of depth slices.
        /// </summary>
        public uint WSize
        {
            get { return this.wsize; }
            set { this.wsize = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture3DUav"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture3DUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture3DUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Texture3DUav left, D3D11Texture3DUav right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture3DUav"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture3DUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture3DUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Texture3DUav left, D3D11Texture3DUav right)
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
            if (!(obj is D3D11Texture3DUav))
            {
                return false;
            }

            return this.Equals((D3D11Texture3DUav)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Texture3DUav other)
        {
            return this.mipSlice == other.mipSlice
                && this.firstWSlice == other.firstWSlice
                && this.wsize == other.wsize;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.mipSlice,
                this.firstWSlice,
                wSize = this.wsize
            }
            .GetHashCode();
        }
    }
}
