// <copyright file="D3D11TextureCubeArraySrv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies the subresources from an array of cube textures to use in a shader resource view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11TextureCubeArraySrv : IEquatable<D3D11TextureCubeArraySrv>
    {
        /// <summary>
        /// The index of the most detailed mipmap level to use.
        /// </summary>
        private uint mostDetailedMip;

        /// <summary>
        /// The maximum number of mipmap levels for the view of the texture.
        /// </summary>
        private uint mipLevels;

        /// <summary>
        /// The index of the first 2D texture to use.
        /// </summary>
        private uint first2DArrayFace;

        /// <summary>
        /// The number of cube textures in the array.
        /// </summary>
        private uint numCubes;

        /// <summary>
        /// Gets or sets the index of the most detailed mipmap level to use.
        /// </summary>
        public uint MostDetailedMip
        {
            get { return this.mostDetailedMip; }
            set { this.mostDetailedMip = value; }
        }

        /// <summary>
        /// Gets or sets the maximum number of mipmap levels for the view of the texture.
        /// </summary>
        public uint MipLevels
        {
            get { return this.mipLevels; }
            set { this.mipLevels = value; }
        }

        /// <summary>
        /// Gets or sets the index of the first 2D texture to use.
        /// </summary>
        public uint First2DArrayFace
        {
            get { return this.first2DArrayFace; }
            set { this.first2DArrayFace = value; }
        }

        /// <summary>
        /// Gets or sets the number of cube textures in the array.
        /// </summary>
        public uint NumCubes
        {
            get { return this.numCubes; }
            set { this.numCubes = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11TextureCubeArraySrv"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11TextureCubeArraySrv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11TextureCubeArraySrv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11TextureCubeArraySrv left, D3D11TextureCubeArraySrv right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11TextureCubeArraySrv"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11TextureCubeArraySrv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11TextureCubeArraySrv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11TextureCubeArraySrv left, D3D11TextureCubeArraySrv right)
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
            if (!(obj is D3D11TextureCubeArraySrv))
            {
                return false;
            }

            return this.Equals((D3D11TextureCubeArraySrv)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11TextureCubeArraySrv other)
        {
            return this.mostDetailedMip == other.mostDetailedMip
                && this.mipLevels == other.mipLevels
                && this.first2DArrayFace == other.first2DArrayFace
                && this.numCubes == other.numCubes;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.mostDetailedMip,
                this.mipLevels,
                this.first2DArrayFace,
                this.numCubes
            }
            .GetHashCode();
        }
    }
}
