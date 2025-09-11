// <copyright file="D3D11FeatureDataD3D10XHardwareOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes compute shader and raw and structured buffer support in the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataD3D10XHardwareOptions : IEquatable<D3D11FeatureDataD3D10XHardwareOptions>
    {
        /// <summary>
        /// Indicates whether compute shaders and raw and structured buffers are supported.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported;

        /// <summary>
        /// Gets a value indicating whether compute shaders and raw and structured buffers are supported.
        /// </summary>
        public bool IsComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported
        {
            get { return this.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D10XHardwareOptions"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D10XHardwareOptions"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D10XHardwareOptions"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataD3D10XHardwareOptions left, D3D11FeatureDataD3D10XHardwareOptions right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D10XHardwareOptions"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D10XHardwareOptions"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D10XHardwareOptions"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataD3D10XHardwareOptions left, D3D11FeatureDataD3D10XHardwareOptions right)
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
            if (obj is not D3D11FeatureDataD3D10XHardwareOptions)
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataD3D10XHardwareOptions)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataD3D10XHardwareOptions other)
        {
            return this.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported == other.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported
            }
            .GetHashCode();
        }
    }
}
