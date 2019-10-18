// <copyright file="D3D11QueryDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a query.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11QueryDesc : IEquatable<D3D11QueryDesc>
    {
        /// <summary>
        /// The type of query.
        /// </summary>
        private D3D11QueryType query;

        /// <summary>
        /// Miscellaneous options.
        /// </summary>
        private D3D11QueryMiscOptions miscOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11QueryDesc"/> struct.
        /// </summary>
        /// <param name="query">The type of query.</param>
        public D3D11QueryDesc(D3D11QueryType query)
        {
            this.query = query;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11QueryDesc"/> struct.
        /// </summary>
        /// <param name="query">The type of query.</param>
        /// <param name="miscOptions">Miscellaneous options.</param>
        public D3D11QueryDesc(D3D11QueryType query, D3D11QueryMiscOptions miscOptions)
        {
            this.query = query;
            this.miscOptions = miscOptions;
        }

        /// <summary>
        /// Gets or sets the type of query.
        /// </summary>
        public D3D11QueryType Query
        {
            get { return this.query; }
            set { this.query = value; }
        }

        /// <summary>
        /// Gets or sets miscellaneous options.
        /// </summary>
        public D3D11QueryMiscOptions MiscOptions
        {
            get { return this.miscOptions; }
            set { this.miscOptions = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11QueryDesc left, D3D11QueryDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11QueryDesc left, D3D11QueryDesc right)
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
            if (!(obj is D3D11QueryDesc))
            {
                return false;
            }

            return this.Equals((D3D11QueryDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11QueryDesc other)
        {
            return this.query == other.query
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
                this.query,
                this.miscOptions
            }
            .GetHashCode();
        }
    }
}
