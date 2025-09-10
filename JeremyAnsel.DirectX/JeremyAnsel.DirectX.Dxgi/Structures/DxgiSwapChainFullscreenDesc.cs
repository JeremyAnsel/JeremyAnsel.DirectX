// <copyright file="DxgiSwapChainFullscreenDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes full-screen mode for a swap chain.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiSwapChainFullscreenDesc : IEquatable<DxgiSwapChainFullscreenDesc>
    {
        /// <summary>
        /// A <see cref="DxgiRational"/> structure that describes the refresh rate in hertz.
        /// </summary>
        private DxgiRational refreshRate;

        /// <summary>
        /// A member of the <see cref="DxgiModeScanlineOrder"/> enumeration that describes the scan-line drawing mode.
        /// </summary>
        private DxgiModeScanlineOrder scanlineOrdering;
        
        /// <summary>
        /// A member of the <see cref="DxgiModeScaling"/> enumeration that describes the scaling mode.
        /// </summary>
        private DxgiModeScaling scaling;

        /// <summary>
        /// A value that specifies whether the swap chain is in windowed mode. <value>true</value> if the swap chain is in windowed mode; otherwise, <value>false</value>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isWindowed;

        /// <summary>
        /// Gets or sets a <see cref="DxgiRational"/> structure that describes the refresh rate in hertz.
        /// </summary>
        public DxgiRational RefreshRate
        {
            get { return this.refreshRate; }
            set { this.refreshRate = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiModeScanlineOrder"/> enumeration that describes the scan-line drawing mode.
        /// </summary>
        public DxgiModeScanlineOrder ScanlineOrdering
        {
            get { return this.scanlineOrdering; }
            set { this.scanlineOrdering = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiModeScaling"/> enumeration that describes the scaling mode.
        /// </summary>
        public DxgiModeScaling Scaling
        {
            get { return this.scaling; }
            set { this.scaling = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the swap chain is in windowed mode.
        /// </summary>
        public bool IsWindowed
        {
            get { return this.isWindowed; }
            set { this.isWindowed = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiSwapChainFullscreenDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSwapChainFullscreenDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSwapChainFullscreenDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiSwapChainFullscreenDesc left, DxgiSwapChainFullscreenDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiSwapChainFullscreenDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSwapChainFullscreenDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSwapChainFullscreenDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiSwapChainFullscreenDesc left, DxgiSwapChainFullscreenDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DxgiSwapChainFullscreenDesc)
            {
                return false;
            }

            return this.Equals((DxgiSwapChainFullscreenDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiSwapChainFullscreenDesc other)
        {
            return this.refreshRate == other.refreshRate
                && this.scanlineOrdering == other.scanlineOrdering
                && this.scaling == other.scaling
                && this.isWindowed == other.isWindowed;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.refreshRate,
                this.scanlineOrdering,
                this.scaling,
                this.isWindowed
            }
            .GetHashCode();
        }
    }
}
