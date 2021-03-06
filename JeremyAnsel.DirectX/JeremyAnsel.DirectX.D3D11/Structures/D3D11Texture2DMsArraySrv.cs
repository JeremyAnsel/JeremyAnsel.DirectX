﻿// <copyright file="D3D11Texture2DMsArraySrv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies the subresources from an array of multisampled 2D textures to use in a shader resource view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Texture2DMsArraySrv : IEquatable<D3D11Texture2DMsArraySrv>
    {
        /// <summary>
        /// The index of the first texture to use in an array of textures.
        /// </summary>
        private uint firstArraySlice;

        /// <summary>
        /// The number of textures to use.
        /// </summary>
        private uint arraySize;

        /// <summary>
        /// Gets or sets the index of the first texture to use in an array of textures.
        /// </summary>
        public uint FirstArraySlice
        {
            get { return this.firstArraySlice; }
            set { this.firstArraySlice = value; }
        }

        /// <summary>
        /// Gets or sets the number of textures to use.
        /// </summary>
        public uint ArraySize
        {
            get { return this.arraySize; }
            set { this.arraySize = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture2DMsArraySrv"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture2DMsArraySrv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture2DMsArraySrv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Texture2DMsArraySrv left, D3D11Texture2DMsArraySrv right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture2DMsArraySrv"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture2DMsArraySrv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture2DMsArraySrv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Texture2DMsArraySrv left, D3D11Texture2DMsArraySrv right)
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
            if (!(obj is D3D11Texture2DMsArraySrv))
            {
                return false;
            }

            return this.Equals((D3D11Texture2DMsArraySrv)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Texture2DMsArraySrv other)
        {
            return this.firstArraySlice == other.firstArraySlice
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
                this.firstArraySlice,
                this.arraySize
            }
            .GetHashCode();
        }
    }
}
