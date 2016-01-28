// <copyright file="D3D11CounterDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a counter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11CounterDesc : IEquatable<D3D11CounterDesc>
    {
        /// <summary>
        /// The type of the counter.
        /// </summary>
        private D3D11CounterType counter;

        /// <summary>
        /// Reserved value.
        /// </summary>
        private uint miscOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11CounterDesc"/> struct.
        /// </summary>
        /// <param name="counter">The type of the counter.</param>
        public D3D11CounterDesc(D3D11CounterType counter)
        {
            this.counter = counter;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Gets or sets the type of the counter.
        /// </summary>
        public D3D11CounterType Counter
        {
            get { return this.counter; }
            set { this.counter = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11CounterDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11CounterDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11CounterDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11CounterDesc left, D3D11CounterDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11CounterDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11CounterDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11CounterDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11CounterDesc left, D3D11CounterDesc right)
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
            if (!(obj is D3D11CounterDesc))
            {
                return false;
            }

            return this.Equals((D3D11CounterDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11CounterDesc other)
        {
            return this.counter == other.counter
                && this.miscOptions == other.miscOptions;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.counter,
                this.miscOptions
            }
            .GetHashCode();
        }
    }
}
