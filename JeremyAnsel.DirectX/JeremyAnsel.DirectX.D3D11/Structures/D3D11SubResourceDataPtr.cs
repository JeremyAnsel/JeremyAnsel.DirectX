// <copyright file="D3D11SubResourceDataPtr.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies a pointer to data for initializing a subresource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11SubResourceDataPtr : IEquatable<D3D11SubResourceDataPtr>
    {
        /// <summary>
        /// A pointer to the initialization data.
        /// </summary>
        private IntPtr sysMem;

        /// <summary>
        /// The distance (in bytes) from the beginning of one line of a texture to the next line.
        /// </summary>
        private uint sysMemPitch;

        /// <summary>
        /// The distance (in bytes) from the beginning of one depth level to the next.
        /// </summary>
        private uint sysMemSlicePitch;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11SubResourceData"/> struct.
        /// </summary>
        /// <param name="data">The initialization data.</param>
        /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
        public D3D11SubResourceDataPtr(IntPtr data, uint pitch)
        {
            this.sysMem = data;
            this.sysMemPitch = pitch;
            this.sysMemSlicePitch = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11SubResourceData"/> struct.
        /// </summary>
        /// <param name="data">The initialization data.</param>
        /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
        /// <param name="slicePitch">The distance (in bytes) from the beginning of one depth level to the next.</param>
        public D3D11SubResourceDataPtr(IntPtr data, uint pitch, uint slicePitch)
        {
            this.sysMem = data;
            this.sysMemPitch = pitch;
            this.sysMemSlicePitch = slicePitch;
        }

        /// <summary>
        /// Gets or sets a pointer to the initialization data.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
        public IntPtr SysMem
        {
            get { return this.sysMem; }
            set { this.sysMem = value; }
        }

        /// <summary>
        /// Gets or sets the distance (in bytes) from the beginning of one line of a texture to the next line.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
        public uint SysMemPitch
        {
            get { return this.sysMemPitch; }
            set { this.sysMemPitch = value; }
        }

        /// <summary>
        /// Gets or sets the distance (in bytes) from the beginning of one depth level to the next.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
        public uint SysMemSlicePitch
        {
            get { return this.sysMemSlicePitch; }
            set { this.sysMemSlicePitch = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11SubResourceDataPtr"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11SubResourceDataPtr"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11SubResourceDataPtr"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11SubResourceDataPtr left, D3D11SubResourceDataPtr right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11SubResourceDataPtr"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11SubResourceDataPtr"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11SubResourceDataPtr"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11SubResourceDataPtr left, D3D11SubResourceDataPtr right)
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
            if (obj is not D3D11SubResourceDataPtr)
            {
                return false;
            }

            return this.Equals((D3D11SubResourceDataPtr)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11SubResourceDataPtr other)
        {
            return this.sysMem == other.sysMem
                && this.sysMemPitch == other.sysMemPitch
                && this.sysMemSlicePitch == other.sysMemSlicePitch;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.sysMem,
                this.sysMemPitch,
                this.sysMemSlicePitch
            }
            .GetHashCode();
        }
    }
}
