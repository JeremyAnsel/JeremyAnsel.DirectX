// <copyright file="D3D11FeatureDataThreading.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the multi-threading features that are supported by the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataThreading : IEquatable<D3D11FeatureDataThreading>
    {
        /// <summary>
        /// Indicates whether resources can be created concurrently on multiple threads while drawing.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isDriverConcurrentCreatesSupported;

        /// <summary>
        /// Indicates whether command lists are supported by the current driver.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isDriverCommandListsSupported;

        /// <summary>
        /// Gets a value indicating whether resources can be created concurrently on multiple threads while drawing.
        /// </summary>
        public bool IsDriverConcurrentCreatesSupported
        {
            get { return this.isDriverConcurrentCreatesSupported; }
        }

        /// <summary>
        /// Gets a value indicating whether command lists are supported by the current driver.
        /// </summary>
        public bool IsDriverCommandListsSupported
        {
            get { return this.isDriverCommandListsSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataThreading"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataThreading"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataThreading"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataThreading left, D3D11FeatureDataThreading right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataThreading"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataThreading"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataThreading"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataThreading left, D3D11FeatureDataThreading right)
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
            if (obj is not D3D11FeatureDataThreading)
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataThreading)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataThreading other)
        {
            return this.isDriverConcurrentCreatesSupported == other.isDriverConcurrentCreatesSupported
                && this.isDriverCommandListsSupported == other.isDriverCommandListsSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isDriverConcurrentCreatesSupported,
                this.isDriverCommandListsSupported
            }
            .GetHashCode();
        }
    }
}
