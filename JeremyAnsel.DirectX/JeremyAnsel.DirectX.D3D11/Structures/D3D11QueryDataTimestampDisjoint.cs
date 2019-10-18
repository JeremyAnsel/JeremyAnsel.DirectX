// <copyright file="D3D11QueryDataTimestampDisjoint.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Query information about the reliability of a timestamp query.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11QueryDataTimestampDisjoint : IEquatable<D3D11QueryDataTimestampDisjoint>
    {
        /// <summary>
        /// How frequently the GPU counter increments in Hz.
        /// </summary>
        private ulong frequency;

        /// <summary>
        /// Indicates whether the timestamp counter is discontinuous or disjoint.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isDisjoint;

        /// <summary>
        /// Gets a value indicating how frequently the GPU counter increments in Hz.
        /// </summary>
        public ulong Frequency
        {
            get { return this.frequency; }
        }

        /// <summary>
        /// Gets a value indicating whether the timestamp counter is discontinuous or disjoint.
        /// </summary>
        public bool IsDisjoint
        {
            get { return this.isDisjoint; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDataTimestampDisjoint"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDataTimestampDisjoint"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDataTimestampDisjoint"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11QueryDataTimestampDisjoint left, D3D11QueryDataTimestampDisjoint right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDataTimestampDisjoint"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDataTimestampDisjoint"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDataTimestampDisjoint"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11QueryDataTimestampDisjoint left, D3D11QueryDataTimestampDisjoint right)
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
            if (!(obj is D3D11QueryDataTimestampDisjoint))
            {
                return false;
            }

            return this.Equals((D3D11QueryDataTimestampDisjoint)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11QueryDataTimestampDisjoint other)
        {
            return this.frequency == other.frequency
                && this.isDisjoint == other.isDisjoint;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.frequency,
                this.isDisjoint
            }
            .GetHashCode();
        }
    }
}
