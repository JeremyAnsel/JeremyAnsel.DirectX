// <copyright file="D3D11BufferExSrv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the elements in a raw buffer resource to use in a shader resource view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11BufferExSrv : IEquatable<D3D11BufferExSrv>
    {
        /// <summary>
        /// The index of the first element to be accessed by the view.
        /// </summary>
        private uint firstElement;

        /// <summary>
        /// The number of elements in the resource.
        /// </summary>
        private uint numElements;

        /// <summary>
        /// The view options for the buffer.
        /// </summary>
        private D3D11BufferExSrvOptions options;

        /// <summary>
        /// Gets or sets the index of the first element to be accessed by the view.
        /// </summary>
        public uint FirstElement
        {
            get { return this.firstElement; }
            set { this.firstElement = value; }
        }

        /// <summary>
        /// Gets or sets the number of elements in the resource.
        /// </summary>
        public uint NumElements
        {
            get { return this.numElements; }
            set { this.numElements = value; }
        }

        /// <summary>
        /// Gets or sets the view options for the buffer.
        /// </summary>
        public D3D11BufferExSrvOptions Options
        {
            get { return this.options; }
            set { this.options = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferExSrv"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferExSrv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferExSrv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11BufferExSrv left, D3D11BufferExSrv right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferExSrv"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferExSrv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferExSrv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11BufferExSrv left, D3D11BufferExSrv right)
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
            if (!(obj is D3D11BufferExSrv))
            {
                return false;
            }

            return this.Equals((D3D11BufferExSrv)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11BufferExSrv other)
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
