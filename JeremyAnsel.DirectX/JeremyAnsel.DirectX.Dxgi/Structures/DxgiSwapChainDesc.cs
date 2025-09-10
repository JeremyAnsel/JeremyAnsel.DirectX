// <copyright file="DxgiSwapChainDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a swap chain.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiSwapChainDesc : IEquatable<DxgiSwapChainDesc>
    {
        /// <summary>
        /// A <see cref="DxgiModeDesc"/> structure that describes the back buffer display mode.
        /// </summary>
        private DxgiModeDesc bufferDescription;

        /// <summary>
        /// A <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters.
        /// </summary>
        private DxgiSampleDesc sampleDescription;

        /// <summary>
        /// A member of the <see cref="DxgiUsages"/> enumeration that describes the surface usage and CPU access options for the back buffer. The back buffer can be used for shader input or render-target output.
        /// </summary>
        private DxgiUsages bufferUsage;

        /// <summary>
        /// A value that describes the number of buffers in the swap chain.
        /// </summary>
        private uint bufferCount;

        /// <summary>
        /// An handle to the output window. This member must not be <value>Zero</value>.
        /// </summary>
        private IntPtr outputWindowHandle;

        /// <summary>
        /// A value indicating whether the output is in windowed mode.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isWindowed;

        /// <summary>
        /// A member of the <see cref="DxgiSwapEffect"/> enumeration that describes options for handling the contents of the presentation buffer after presenting a surface.
        /// </summary>
        private DxgiSwapEffect swapEffect;

        /// <summary>
        /// A member of the <see cref="DxgiSwapChainOptions"/> enumeration that describes options for swap-chain behavior.
        /// </summary>
        private DxgiSwapChainOptions options;

        /// <summary>
        /// Gets or sets a <see cref="DxgiModeDesc"/> structure that describes the back buffer display mode.
        /// </summary>
        public DxgiModeDesc BufferDescription
        {
            get { return this.bufferDescription; }
            set { this.bufferDescription = value; }
        }

        /// <summary>
        /// Gets or sets a <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters.
        /// </summary>
        public DxgiSampleDesc SampleDescription
        {
            get { return this.sampleDescription; }
            set { this.sampleDescription = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiUsages"/> enumeration that describes the surface usage and CPU access options for the back buffer. The back buffer can be used for shader input or render-target output.
        /// </summary>
        public DxgiUsages BufferUsage
        {
            get { return this.bufferUsage; }
            set { this.bufferUsage = value; }
        }

        /// <summary>
        /// Gets or sets a value that describes the number of buffers in the swap chain.
        /// </summary>
        public uint BufferCount
        {
            get { return this.bufferCount; }
            set { this.bufferCount = value; }
        }

        /// <summary>
        /// Gets or sets an handle to the output window. This member must not be <value>Zero</value>.
        /// </summary>
        public IntPtr OutputWindowHandle
        {
            get { return this.outputWindowHandle; }
            set { this.outputWindowHandle = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the output is in windowed mode.
        /// </summary>
        public bool IsWindowed
        {
            get { return this.isWindowed; }
            set { this.isWindowed = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiSwapEffect"/> enumeration that describes options for handling the contents of the presentation buffer after presenting a surface.
        /// </summary>
        public DxgiSwapEffect SwapEffect
        {
            get { return this.swapEffect; }
            set { this.swapEffect = value; }
        }

        /// <summary>
        /// Gets or sets a member of the <see cref="DxgiSwapChainOptions"/> enumeration that describes options for swap-chain behavior.
        /// </summary>
        public DxgiSwapChainOptions Options
        {
            get { return this.options; }
            set { this.options = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiSwapChainDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSwapChainDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSwapChainDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiSwapChainDesc left, DxgiSwapChainDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiSwapChainDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSwapChainDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSwapChainDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiSwapChainDesc left, DxgiSwapChainDesc right)
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
            if (obj is not DxgiSwapChainDesc)
            {
                return false;
            }

            return this.Equals((DxgiSwapChainDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiSwapChainDesc other)
        {
            return this.bufferDescription == other.bufferDescription
                && this.sampleDescription == other.sampleDescription
                && this.bufferUsage == other.bufferUsage
                && this.bufferCount == other.bufferCount
                && this.outputWindowHandle == other.outputWindowHandle
                && this.isWindowed == other.isWindowed
                && this.swapEffect == other.swapEffect
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
                this.bufferDescription,
                this.sampleDescription,
                this.bufferUsage,
                this.bufferCount,
                this.outputWindowHandle,
                this.isWindowed,
                this.swapEffect,
                this.options
            }
            .GetHashCode();
        }
    }
}
