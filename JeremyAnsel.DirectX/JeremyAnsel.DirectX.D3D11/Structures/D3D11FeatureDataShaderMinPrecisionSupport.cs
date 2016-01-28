// <copyright file="D3D11FeatureDataShaderMinPrecisionSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes precision support options for shaders in the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataShaderMinPrecisionSupport : IEquatable<D3D11FeatureDataShaderMinPrecisionSupport>
    {
        /// <summary>
        /// The minimum precision levels that the driver supports for the pixel shader.
        /// </summary>
        private D3D11ShaderMinPrecisionSupports pixelShaderMinPrecision;

        /// <summary>
        /// The minimum precision levels that the driver supports for all other shader stages.
        /// </summary>
        private D3D11ShaderMinPrecisionSupports allOtherShaderStagesMinPrecision;

        /// <summary>
        /// Gets the minimum precision levels that the driver supports for the pixel shader.
        /// </summary>
        public D3D11ShaderMinPrecisionSupports PixelShaderMinPrecision
        {
            get { return this.pixelShaderMinPrecision; }
        }

        /// <summary>
        /// Gets the minimum precision levels that the driver supports for all other shader stages.
        /// </summary>
        public D3D11ShaderMinPrecisionSupports AllOtherShaderStagesMinPrecision
        {
            get { return this.allOtherShaderStagesMinPrecision; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataShaderMinPrecisionSupport"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataShaderMinPrecisionSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataShaderMinPrecisionSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataShaderMinPrecisionSupport left, D3D11FeatureDataShaderMinPrecisionSupport right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataShaderMinPrecisionSupport"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataShaderMinPrecisionSupport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataShaderMinPrecisionSupport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataShaderMinPrecisionSupport left, D3D11FeatureDataShaderMinPrecisionSupport right)
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
            if (!(obj is D3D11FeatureDataShaderMinPrecisionSupport))
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataShaderMinPrecisionSupport)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataShaderMinPrecisionSupport other)
        {
            return this.pixelShaderMinPrecision == other.pixelShaderMinPrecision
                && this.allOtherShaderStagesMinPrecision == other.allOtherShaderStagesMinPrecision;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.pixelShaderMinPrecision,
                this.allOtherShaderStagesMinPrecision
            }
            .GetHashCode();
        }
    }
}
