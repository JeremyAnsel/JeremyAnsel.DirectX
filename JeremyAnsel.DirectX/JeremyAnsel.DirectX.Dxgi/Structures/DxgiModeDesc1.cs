// <copyright file="DxgiModeDesc1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a display mode and whether the display mode supports stereo.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiModeDesc1 : IEquatable<DxgiModeDesc1>
    {
        /// <summary>
        /// A value that describes the resolution width.
        /// </summary>
        private uint width;

        /// <summary>
        /// A value describing the resolution height.
        /// </summary>
        private uint height;

        /// <summary>
        /// A <see cref="DxgiRational"/> structure describing the refresh rate in hertz.
        /// </summary>
        private DxgiRational refreshRate;

        /// <summary>
        /// A member of the <see cref="DxgiFormat"/> enumeration describing the display format.
        /// </summary>
        private DxgiFormat format;

        /// <summary>
        /// A member of the <see cref="DxgiModeScanlineOrder"/> enumeration describing the scanline drawing mode.
        /// </summary>
        private DxgiModeScanlineOrder scanlineOrdering;

        /// <summary>
        /// A member of the <see cref="DxgiModeScaling"/> enumeration describing the scaling mode.
        /// </summary>
        private DxgiModeScaling scaling;

        /// <summary>
        /// Specifies whether the full-screen display mode is stereo. TRUE if stereo; otherwise, FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool stereo;

        /// <summary>
        /// Gets or sets a value that describes the resolution width.
        /// </summary>
        public uint Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets a value describing the resolution height.
        /// </summary>
        public uint Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="DxgiRational"/> structure describing the refresh rate in hertz.
        /// </summary>
        public DxgiRational RefreshRate
        {
            get { return this.refreshRate; }
            set { this.refreshRate = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiFormat"/> enumeration describing the display format.
        /// </summary>
        public DxgiFormat Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiModeScanlineOrder"/> enumeration describing the scanline drawing mode.
        /// </summary>
        public DxgiModeScanlineOrder ScanlineOrdering
        {
            get { return this.scanlineOrdering; }
            set { this.scanlineOrdering = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiModeScaling"/> enumeration describing the scaling mode.
        /// </summary>
        public DxgiModeScaling Scaling
        {
            get { return this.scaling; }
            set { this.scaling = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the full-screen display mode is stereo.
        /// </summary>
        public bool Stereo
        {
            get { return this.stereo; }
            set { this.stereo = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiModeDesc1"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiModeDesc1"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiModeDesc1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiModeDesc1 left, DxgiModeDesc1 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiModeDesc1"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiModeDesc1"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiModeDesc1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiModeDesc1 left, DxgiModeDesc1 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}x{1} {2} Hz {3} {4}",
                this.width,
                this.height,
                this.refreshRate,
                this.format,
                this.stereo ? "Stereo" : "Mono");
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DxgiModeDesc1)
            {
                return false;
            }

            return this.Equals((DxgiModeDesc1)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiModeDesc1 other)
        {
            return this.width == other.width
                && this.height == other.height
                && this.refreshRate == other.refreshRate
                && this.format == other.format
                && this.scanlineOrdering == other.scanlineOrdering
                && this.scaling == other.scaling
                && this.stereo == other.stereo;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.width,
                this.height,
                this.refreshRate,
                this.format,
                this.scanlineOrdering,
                this.scaling,
                this.stereo
            }
            .GetHashCode();
        }
    }
}
