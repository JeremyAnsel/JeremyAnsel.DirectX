// <copyright file="DxgiSharedResource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a handle to a shared resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiSharedResource : IEquatable<DxgiSharedResource>
    {
        /// <summary>
        /// A handle to a shared resource.
        /// </summary>
        private IntPtr handle;

        /// <summary>
        /// Gets a handle to a shared resource.
        /// </summary>
        public IntPtr Handle
        {
            get { return this.handle; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiSharedResource"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSharedResource"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSharedResource"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiSharedResource left, DxgiSharedResource right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiSharedResource"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSharedResource"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSharedResource"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiSharedResource left, DxgiSharedResource right)
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
            if (!(obj is DxgiSharedResource))
            {
                return false;
            }

            return this.Equals((DxgiSharedResource)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiSharedResource other)
        {
            return this.handle == other.handle;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.handle.GetHashCode();
        }
    }
}
