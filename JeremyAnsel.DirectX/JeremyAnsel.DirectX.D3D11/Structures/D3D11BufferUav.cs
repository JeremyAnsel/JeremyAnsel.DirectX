// <copyright file="D3D11BufferUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the elements in a buffer to use in a unordered-access view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11BufferUav : IEquatable<D3D11BufferUav>
    {
        /// <summary>
        /// The zero-based index of the first element to be accessed.
        /// </summary>
        private uint firstElement;

        /// <summary>
        /// The number of elements in the resource. For structured buffers, this is the number of structures in the buffer.
        /// </summary>
        private uint numElements;

        /// <summary>
        /// The view options for the resource.
        /// </summary>
        private D3D11BufferUavOptions options;

        /// <summary>
        /// Gets or sets the zero-based index of the first element to be accessed.
        /// </summary>
        public uint FirstElement
        {
            get { return this.firstElement; }
            set { this.firstElement = value; }
        }

        /// <summary>
        /// Gets or sets the number of elements in the resource. For structured buffers, this is the number of structures in the buffer.
        /// </summary>
        public uint NumElements
        {
            get { return this.numElements; }
            set { this.numElements = value; }
        }

        /// <summary>
        /// Gets or sets the view options for the resource.
        /// </summary>
        public D3D11BufferUavOptions Options
        {
            get { return this.options; }
            set { this.options = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferUav"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11BufferUav left, D3D11BufferUav right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferUav"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferUav"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferUav"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11BufferUav left, D3D11BufferUav right)
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
            if (!(obj is D3D11BufferUav))
            {
                return false;
            }

            return this.Equals((D3D11BufferUav)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11BufferUav other)
        {
            return this.firstElement == other.firstElement
                && this.numElements == other.numElements
                && this.options == other.options;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.firstElement,
                this.numElements,
                this.options
            }
            .GetHashCode();
        }
    }
}
