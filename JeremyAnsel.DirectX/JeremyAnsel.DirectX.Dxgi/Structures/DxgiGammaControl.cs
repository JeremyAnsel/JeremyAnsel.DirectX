// <copyright file="DxgiGammaControl.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Controls the settings of a gamma curve.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiGammaControl : IEquatable<DxgiGammaControl>
    {
        /// <summary>
        /// A <see cref="DxgiColorRgb"/> structure with scalar values that are applied to RGB values before being sent to the gamma look up table.
        /// </summary>
        private DxgiColorRgb scale;

        /// <summary>
        /// A <see cref="DxgiColorRgb"/> structure with offset values that are applied to the RGB values before being sent to the gamma look up table.
        /// </summary>
        private DxgiColorRgb offset;

        /// <summary>
        /// An array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
        private DxgiColorRgb[] gammaCurve;

        /// <summary>
        /// Gets or sets a <see cref="DxgiColorRgb"/> structure with scalar values that are applied to RGB values before being sent to the gamma look up table.
        /// </summary>
        public DxgiColorRgb Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="DxgiColorRgb"/> structure with offset values that are applied to the RGB values before being sent to the gamma look up table.
        /// </summary>
        public DxgiColorRgb Offset
        {
            get { return this.offset; }
            set { this.offset = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiGammaControl"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiGammaControl"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiGammaControl"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiGammaControl left, DxgiGammaControl right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiGammaControl"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiGammaControl"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiGammaControl"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiGammaControl left, DxgiGammaControl right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Gets an array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
        /// </summary>
        /// <returns>An array of <see cref="DxgiColorRgb"/> structures.</returns>
        public DxgiColorRgb[] GetGammaCurve()
        {
            return this.gammaCurve;
        }

        /// <summary>
        /// Sets an array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
        /// </summary>
        /// <param name="curve">An array of <see cref="DxgiColorRgb"/> structures.</param>
        public void SetGammaCurve(DxgiColorRgb[] curve)
        {
            if (curve == null)
            {
                throw new ArgumentNullException(nameof(curve));
            }

            if (curve.Length != 1025)
            {
                throw new ArgumentOutOfRangeException(nameof(curve));
            }

            if (this.gammaCurve == null)
            {
                this.gammaCurve = curve;
            }
            else
            {
                Array.Copy(curve, this.gammaCurve, 1025);
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DxgiGammaControl)
            {
                return false;
            }

            return this.Equals((DxgiGammaControl)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiGammaControl other)
        {
            return this.scale == other.scale
                && this.offset == other.offset
                && this.gammaCurve == other.gammaCurve;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.scale,
                this.offset,
                this.gammaCurve
            }
            .GetHashCode();
        }
    }
}
