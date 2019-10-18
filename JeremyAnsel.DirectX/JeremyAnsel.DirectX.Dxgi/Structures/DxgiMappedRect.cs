// <copyright file="DxgiMappedRect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a mapped rectangle that is used to access a surface.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiMappedRect : IEquatable<DxgiMappedRect>
    {
        /// <summary>
        /// A value that describes the width, in bytes, of the surface.
        /// </summary>
        private readonly int pitch;

        /// <summary>
        /// A pointer to the image buffer of the surface.
        /// </summary>
        private readonly IntPtr bitsPointer;

        /// <summary>
        /// Gets a value that describes the width, in bytes, of the surface.
        /// </summary>
        public int Pitch
        {
            get { return this.pitch; }
        }

        /// <summary>
        /// Gets a pointer to the image buffer of the surface.
        /// </summary>
        public IntPtr BitsPointer
        {
            get { return this.bitsPointer; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiMappedRect"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiMappedRect"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiMappedRect"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiMappedRect left, DxgiMappedRect right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiMappedRect"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiMappedRect"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiMappedRect"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiMappedRect left, DxgiMappedRect right)
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
            if (!(obj is DxgiMappedRect))
            {
                return false;
            }

            return this.Equals((DxgiMappedRect)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiMappedRect other)
        {
            return this.pitch == other.pitch
                && this.bitsPointer == other.bitsPointer;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.pitch,
                this.bitsPointer
            }
            .GetHashCode();
        }
    }
}
