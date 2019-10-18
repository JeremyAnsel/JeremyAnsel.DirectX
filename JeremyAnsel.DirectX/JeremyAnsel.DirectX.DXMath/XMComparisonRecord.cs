// <copyright file="XMComparisonRecord.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A comparison value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XMComparisonRecord : IEquatable<XMComparisonRecord>
    {
        /// <summary>
        /// Mask to get a comparison result.
        /// </summary>
        public const uint Mask = 0x000000F0;

        /// <summary>
        /// Mask to get a comparison result, and verify if it is a logical true.
        /// </summary>
        public const uint MaskTrue = 0x00000080;

        /// <summary>
        /// Mask to get a comparison result, and verify if it is a logical false.
        /// </summary>
        public const uint MaskFalse = 0x00000020;

        /// <summary>
        /// Mask to get a comparison result, and verify if the result indicates that some of the inputs were out of bounds.
        /// </summary>
        public const uint MaskBounds = MaskFalse;

        /// <summary>
        /// The comparison record.
        /// </summary>
        private readonly uint record;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMComparisonRecord"/> struct.
        /// </summary>
        /// <param name="record">A comparison record.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMComparisonRecord(uint record)
        {
            this.record = record;
        }

        /// <summary>
        /// Gets a value indicating whether all of the compared components are true.
        /// </summary>
        public bool IsAllTrue
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & MaskTrue) == MaskTrue; }
        }

        /// <summary>
        /// Gets a value indicating whether any of the compared components are true
        /// </summary>
        public bool IsAnyTrue
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & MaskFalse) != MaskFalse; }
        }

        /// <summary>
        /// Gets a value indicating whether all of the compared components are false.
        /// </summary>
        public bool IsAllFalse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & MaskFalse) == MaskFalse; }
        }

        /// <summary>
        /// Gets a value indicating whether any of the compared components are false.
        /// </summary>
        public bool IsAnyFalse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & MaskTrue) != MaskTrue; }
        }

        /// <summary>
        /// Gets a value indicating whether the compared components had mixed results: some true and some false.
        /// </summary>
        public bool IsMixed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & Mask) == 0; }
        }

        /// <summary>
        /// Gets a value indicating whether all of the compared components are within set bounds.
        /// </summary>
        public bool IsAllInBounds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & MaskBounds) == MaskBounds; }
        }

        /// <summary>
        /// Gets a value indicating whether any of the compared components are outside the set bounds.
        /// </summary>
        public bool IsAnyOutOfBounds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (this.record & MaskBounds) != MaskBounds; }
        }

        /// <summary>
        /// Compares two <see cref="XMComparisonRecord"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMComparisonRecord"/> to compare.</param>
        /// <param name="right">The right <see cref="XMComparisonRecord"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMComparisonRecord left, XMComparisonRecord right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMComparisonRecord"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMComparisonRecord"/> to compare.</param>
        /// <param name="right">The right <see cref="XMComparisonRecord"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMComparisonRecord left, XMComparisonRecord right)
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
            if (!(obj is XMComparisonRecord))
            {
                return false;
            }

            return this.Equals((XMComparisonRecord)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMComparisonRecord other)
        {
            return this.record == other.record;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.record
            }
            .GetHashCode();
        }
    }
}
