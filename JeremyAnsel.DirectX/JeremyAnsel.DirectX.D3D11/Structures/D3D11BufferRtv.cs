// <copyright file="D3D11BufferRtv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies the elements in a buffer resource to use in a render-target view.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11BufferRtv : IEquatable<D3D11BufferRtv>
    {
        /// <summary>
        /// The number of bytes between the beginning of the buffer and the first element to access.
        /// </summary>
        [FieldOffset(0)]
        private uint firstElement;

        /// <summary>
        /// The offset of the first element in the view to access, relative to element 0.
        /// </summary>
        [FieldOffset(0)]
        private uint elementOffset;

        /// <summary>
        /// The total number of elements in the view.
        /// </summary>
        [FieldOffset(4)]
        private uint numElements;

        /// <summary>
        /// The width of each element (in bytes). This can be determined from the format stored in the render-target-view description.
        /// </summary>
        [FieldOffset(4)]
        private uint elementWidth;

        /// <summary>
        /// Gets or sets the number of bytes between the beginning of the buffer and the first element to access.
        /// </summary>
        public uint FirstElement
        {
            get { return this.firstElement; }
            set { this.firstElement = value; }
        }

        /// <summary>
        /// Gets or sets the offset of the first element in the view to access, relative to element 0.
        /// </summary>
        public uint ElementOffset
        {
            get { return this.elementOffset; }
            set { this.elementOffset = value; }
        }

        /// <summary>
        /// Gets or sets the total number of elements in the view.
        /// </summary>
        public uint NumElements
        {
            get { return this.numElements; }
            set { this.numElements = value; }
        }

        /// <summary>
        /// Gets or sets the width of each element (in bytes). This can be determined from the format stored in the render-target-view description.
        /// </summary>
        public uint ElementWidth
        {
            get { return this.elementWidth; }
            set { this.elementWidth = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferRtv"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferRtv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferRtv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11BufferRtv left, D3D11BufferRtv right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferRtv"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferRtv"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferRtv"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11BufferRtv left, D3D11BufferRtv right)
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
            if (!(obj is D3D11BufferRtv))
            {
                return false;
            }

            return this.Equals((D3D11BufferRtv)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11BufferRtv other)
        {
            return this.firstElement == other.firstElement
                && this.elementOffset == other.elementOffset
                && this.numElements == other.numElements
                && this.elementWidth == other.elementWidth;
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
                this.elementOffset,
                this.numElements,
                this.elementWidth
            }
            .GetHashCode();
        }
    }
}
