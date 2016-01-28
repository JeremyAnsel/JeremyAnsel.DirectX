﻿// <copyright file="D3D11Texture1DArrayUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an array of unordered-access 1D texture resources.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Texture1DArrayUav : IEquatable<D3D11Texture1DArrayUav>
    {
        /// <summary>
        /// The mipmap slice index.
        /// </summary>
        private uint mipSlice;

        /// <summary>
        /// The zero-based index of the first array slice to be accessed.
        /// </summary>
        private uint firstArraySlice;

        /// <summary>
        /// The number of slices in the array.
        /// </summary>
        private uint arraySize;

        /// <summary>
        /// Gets or sets the mipmap slice index.
        /// </summary>
        public uint MipSlice
        {
            get { return this.mipSlice; }
            set { this.mipSlice = value; }
        }

        /// <summary>
        /// Gets or sets the zero-based index of the first array slice to be accessed.
        /// </summary>
        public uint FirstArraySlice
        {
            get { return this.firstArraySlice; }
            set { this.firstArraySlice = value; }
        }

        /// <summary>
        /// Gets or sets the number of slices in the array.
        /// </summary>
        public uint ArraySize
        {
            get { return this.arraySize; }
            set { this.arraySize = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture1DArrayUav"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture1DArrayUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture1DArrayUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Texture1DArrayUav left, D3D11Texture1DArrayUav right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture1DArrayUav"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture1DArrayUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture1DArrayUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Texture1DArrayUav left, D3D11Texture1DArrayUav right)
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
            if (!(obj is D3D11Texture1DArrayUav))
            {
                return false;
            }

            return this.Equals((D3D11Texture1DArrayUav)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Texture1DArrayUav other)
        {
            return this.mipSlice == other.mipSlice
                && this.firstArraySlice == other.firstArraySlice
                && this.arraySize == other.arraySize;
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
                this.firstArraySlice,
                this.arraySize
            }
            .GetHashCode();
        }
    }
}
