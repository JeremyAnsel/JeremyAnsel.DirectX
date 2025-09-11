// <copyright file="D2D1FactoryOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the debugging level of an <see cref="D2D1Factory"/> object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1FactoryOptions : IEquatable<D2D1FactoryOptions>
    {
        /// <summary>
        /// Requests a certain level of debugging information from the debug layer. This
        /// parameter is ignored if the debug layer DLL is not present.
        /// </summary>
        private D2D1DebugLevel debugLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1FactoryOptions"/> struct.
        /// </summary>
        /// <param name="debugLevel">The level of debugging information.</param>
        public D2D1FactoryOptions(D2D1DebugLevel debugLevel)
        {
            this.debugLevel = debugLevel;
        }

        /// <summary>
        /// Gets or sets a certain level of debugging information from the debug layer. This
        /// parameter is ignored if the debug layer DLL is not present.
        /// </summary>
        public D2D1DebugLevel DebugLevel
        {
            get { return this.debugLevel; }
            set { this.debugLevel = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1FactoryOptions"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1FactoryOptions"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1FactoryOptions"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1FactoryOptions left, D2D1FactoryOptions right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1FactoryOptions"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1FactoryOptions"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1FactoryOptions"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1FactoryOptions left, D2D1FactoryOptions right)
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
            if (obj is not D2D1FactoryOptions)
            {
                return false;
            }

            return this.Equals((D2D1FactoryOptions)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1FactoryOptions other)
        {
            return this.debugLevel == other.debugLevel;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.debugLevel.GetHashCode();
        }
    }
}
