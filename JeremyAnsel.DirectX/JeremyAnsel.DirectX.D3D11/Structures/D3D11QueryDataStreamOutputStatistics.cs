// <copyright file="D3D11QueryDataStreamOutputStatistics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Query information about the amount of data streamed out to the stream-output buffers in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11QueryDataStreamOutputStatistics : IEquatable<D3D11QueryDataStreamOutputStatistics>
    {
        /// <summary>
        /// The number of primitives (that is, points, lines, and triangles) written to the stream-output buffers.
        /// </summary>
        private ulong numPrimitivesWritten;

        /// <summary>
        /// The number of primitives that would have been written to the stream-output buffers if there had been enough space for them all.
        /// </summary>
        private ulong primitivesStorageNeeded;

        /// <summary>
        /// Gets the number of primitives (that is, points, lines, and triangles) written to the stream-output buffers.
        /// </summary>
        public ulong NumPrimitivesWritten
        {
            get { return this.numPrimitivesWritten; }
        }

        /// <summary>
        /// Gets the number of primitives that would have been written to the stream-output buffers if there had been enough space for them all.
        /// </summary>
        public ulong PrimitivesStorageNeeded
        {
            get { return this.primitivesStorageNeeded; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDataStreamOutputStatistics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDataStreamOutputStatistics"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDataStreamOutputStatistics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11QueryDataStreamOutputStatistics left, D3D11QueryDataStreamOutputStatistics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDataStreamOutputStatistics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDataStreamOutputStatistics"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDataStreamOutputStatistics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11QueryDataStreamOutputStatistics left, D3D11QueryDataStreamOutputStatistics right)
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
            if (!(obj is D3D11QueryDataStreamOutputStatistics))
            {
                return false;
            }

            return this.Equals((D3D11QueryDataStreamOutputStatistics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11QueryDataStreamOutputStatistics other)
        {
            return this.numPrimitivesWritten == other.numPrimitivesWritten
                && this.primitivesStorageNeeded == other.primitivesStorageNeeded;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.numPrimitivesWritten,
                this.primitivesStorageNeeded
            }
            .GetHashCode();
        }
    }
}
