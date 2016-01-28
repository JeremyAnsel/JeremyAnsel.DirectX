// <copyright file="DxgiGammaControlCapabilities.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Controls the gamma capabilities of an adapter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiGammaControlCapabilities : IEquatable<DxgiGammaControlCapabilities>
    {
        /// <summary>
        /// <value>true</value> if scaling and offset operations are supported during gamma correction; otherwise, <value>false</value>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isScaleAndOffsetSupported;

        /// <summary>
        /// A value describing the maximum range of the control-point positions.
        /// </summary>
        private float maximumConvertedValue;

        /// <summary>
        /// A value describing the minimum range of the control-point positions.
        /// </summary>
        private float minimumConvertedValue;

        /// <summary>
        /// A value describing the number of control points in the array.
        /// </summary>
        private uint gammaControlPointsCount;

        /// <summary>
        /// An array of values describing control points; the maximum length of control points is 1025.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
        private float[] gammaControlPointPositions;

        /// <summary>
        /// Gets a value indicating whether scaling and offset operations are supported during gamma correction.
        /// </summary>
        public bool IsScaleAndOffsetSupported
        {
            get { return this.isScaleAndOffsetSupported; }
        }

        /// <summary>
        /// Gets a value describing the maximum range of the control-point positions.
        /// </summary>
        public float MaximumConvertedValue
        {
            get { return this.maximumConvertedValue; }
        }

        /// <summary>
        /// Gets a value describing the minimum range of the control-point positions.
        /// </summary>
        public float MinimumConvertedValue
        {
            get { return this.minimumConvertedValue; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiGammaControlCapabilities"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiGammaControlCapabilities"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiGammaControlCapabilities"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiGammaControlCapabilities left, DxgiGammaControlCapabilities right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiGammaControlCapabilities"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiGammaControlCapabilities"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiGammaControlCapabilities"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiGammaControlCapabilities left, DxgiGammaControlCapabilities right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Gets an array of values describing control points; the maximum length of control points is 1025.
        /// </summary>
        /// <returns>An array of values describing control points.</returns>
        public float[] GetGammaControlPointPositions()
        {
            if (this.gammaControlPointPositions == null)
            {
                return null;
            }

            float[] array = new float[this.gammaControlPointPositions.Length];
            Array.Copy(this.gammaControlPointPositions, array, this.gammaControlPointPositions.Length);

            return array;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiGammaControlCapabilities))
            {
                return false;
            }

            return this.Equals((DxgiGammaControlCapabilities)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiGammaControlCapabilities other)
        {
            return this.isScaleAndOffsetSupported == other.isScaleAndOffsetSupported
                && this.maximumConvertedValue == other.maximumConvertedValue
                && this.minimumConvertedValue == other.minimumConvertedValue
                && this.gammaControlPointsCount == other.gammaControlPointsCount
                && this.gammaControlPointPositions == other.gammaControlPointPositions;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isScaleAndOffsetSupported,
                this.maximumConvertedValue,
                this.minimumConvertedValue,
                this.gammaControlPointsCount,
                this.gammaControlPointPositions
            }
            .GetHashCode();
        }
    }
}
