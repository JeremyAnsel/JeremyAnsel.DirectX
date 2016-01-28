// <copyright file="DxgiSwapChainDesc1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a swap chain.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiSwapChainDesc1 : IEquatable<DxgiSwapChainDesc1>
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
        /// A member of the <see cref="DxgiFormat"/> enumeration describing the display format.
        /// </summary>
        private DxgiFormat format;

        /// <summary>
        /// Specifies whether the full-screen display mode is stereo. TRUE if stereo; otherwise, FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool stereo;

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
        /// A member of the <see cref="DxgiScaling"/> enumeration describing the scaling mode.
        /// </summary>
        private DxgiScaling scaling;

        /// <summary>
        /// A member of the <see cref="DxgiSwapEffect"/> enumeration that describes options for handling the contents of the presentation buffer after presenting a surface.
        /// </summary>
        private DxgiSwapEffect swapEffect;

        /// <summary>
        /// A member of the <see cref="DxgiAlphaMode"/> enumeration that identifies the transparency behavior of the swap-chain back buffer.
        /// </summary>
        private DxgiAlphaMode alphaMode;

        /// <summary>
        /// A member of the <see cref="DxgiSwapChainOptions"/> enumeration that describes options for swap-chain behavior.
        /// </summary>
        private DxgiSwapChainOptions options;

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
        /// Gets or sets a member of the <see cref="DxgiFormat"/> enumeration describing the display format.
        /// </summary>
        public DxgiFormat Format
        {
            get { return this.format; }
            set { this.format = value; }
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
        /// Gets or sets a member of the <see cref="DxgiScaling"/> enumeration describing the scaling mode.
        /// </summary>
        public DxgiScaling Scaling
        {
            get { return this.scaling; }
            set { this.scaling = value; }
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
        /// Gets or sets a member of the <see cref="DxgiAlphaMode"/> enumeration that identifies the transparency behavior of the swap-chain back buffer.
        /// </summary>
        public DxgiAlphaMode AlphaMode
        {
            get { return this.alphaMode; }
            set { this.alphaMode = value; }
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
        /// Compares two <see cref="DxgiSwapChainDesc1"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSwapChainDesc1"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSwapChainDesc1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiSwapChainDesc1 left, DxgiSwapChainDesc1 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiSwapChainDesc1"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiSwapChainDesc1"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiSwapChainDesc1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiSwapChainDesc1 left, DxgiSwapChainDesc1 right)
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
            if (!(obj is DxgiSwapChainDesc1))
            {
                return false;
            }

            return this.Equals((DxgiSwapChainDesc1)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiSwapChainDesc1 other)
        {
            return this.width == other.width
                && this.height == other.height
                && this.format == other.format
                && this.stereo == other.stereo
                && this.sampleDescription == other.sampleDescription
                && this.bufferUsage == other.bufferUsage
                && this.bufferCount == other.bufferCount
                && this.scaling == other.scaling
                && this.swapEffect == other.swapEffect
                && this.alphaMode == other.alphaMode
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
                this.width,
                this.height,
                this.format,
                this.stereo,
                this.sampleDescription,
                this.bufferUsage,
                this.bufferCount,
                this.scaling,
                this.swapEffect,
                this.alphaMode,
                this.options
            }
            .GetHashCode();
        }
    }
}
