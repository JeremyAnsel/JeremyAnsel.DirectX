// <copyright file="D3D11MappedSubResource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides access to subresource data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11MappedSubResource : IEquatable<D3D11MappedSubResource>
    {
        /// <summary>
        /// Pointer to the data.
        /// </summary>
        private IntPtr data;

        /// <summary>
        /// The row pitch, or width, or physical size (in bytes) of the data.
        /// </summary>
        private uint rowPitch;

        /// <summary>
        /// The depth pitch, or width, or physical size (in bytes)of the data.
        /// </summary>
        private uint depthPitch;

        /// <summary>
        /// Gets or sets the pointer to the data.
        /// </summary>
        public IntPtr Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        /// <summary>
        /// Gets or sets the row pitch, or width, or physical size (in bytes) of the data.
        /// </summary>
        public uint RowPitch
        {
            get { return this.rowPitch; }
            set { this.rowPitch = value; }
        }

        /// <summary>
        /// Gets or sets the depth pitch, or width, or physical size (in bytes)of the data.
        /// </summary>
        public uint DepthPitch
        {
            get { return this.depthPitch; }
            set { this.depthPitch = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11MappedSubResource"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11MappedSubResource"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11MappedSubResource"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11MappedSubResource left, D3D11MappedSubResource right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11MappedSubResource"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11MappedSubResource"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11MappedSubResource"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11MappedSubResource left, D3D11MappedSubResource right)
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
            if (!(obj is D3D11MappedSubResource))
            {
                return false;
            }

            return this.Equals((D3D11MappedSubResource)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11MappedSubResource other)
        {
            return this.data == other.data
                && this.rowPitch == other.rowPitch
                && this.depthPitch == other.depthPitch;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.data,
                this.rowPitch,
                this.depthPitch
            }
            .GetHashCode();
        }
    }
}
