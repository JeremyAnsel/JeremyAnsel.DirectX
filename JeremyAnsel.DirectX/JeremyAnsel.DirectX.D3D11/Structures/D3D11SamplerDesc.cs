// <copyright file="D3D11SamplerDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a sampler state.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11SamplerDesc : IEquatable<D3D11SamplerDesc>
    {
        /// <summary>
        /// The filtering method to use when sampling a texture.
        /// </summary>
        private D3D11Filter filter;

        /// <summary>
        /// The method to use for resolving a u texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        private D3D11TextureAddressMode addressU;

        /// <summary>
        /// The method to use for resolving a v texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        private D3D11TextureAddressMode addressV;

        /// <summary>
        /// The method to use for resolving a w texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        private D3D11TextureAddressMode addressW;

        /// <summary>
        /// The offset from the calculated mipmap level.
        /// </summary>
        private float mipLodBias;

        /// <summary>
        /// The clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.
        /// </summary>
        private uint maxAnisotropy;

        /// <summary>
        /// A function that compares sampled data against existing sampled data.
        /// </summary>
        private D3D11ComparisonFunction comparisonFunction;

        /// <summary>
        /// The border color red component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        private float borderColorR;

        /// <summary>
        /// The border color green component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        private float borderColorG;

        /// <summary>
        /// The border color blue component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        private float borderColorB;

        /// <summary>
        /// The border color alpha component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        private float borderColorA;

        /// <summary>
        /// The lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// </summary>
        private float minLod;

        /// <summary>
        /// The upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// </summary>
        private float maxLod;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11SamplerDesc"/> struct.
        /// </summary>
        /// <param name="filter">The filtering method to use when sampling a texture.</param>
        /// <param name="addressU">The method to use for resolving a u texture coordinate that is outside the 0 to 1 range.</param>
        /// <param name="addressV">The method to use for resolving a v texture coordinate that is outside the 0 to 1 range.</param>
        /// <param name="addressW">The method to use for resolving a w texture coordinate that is outside the 0 to 1 range.</param>
        /// <param name="mipLodBias">The offset from the calculated mipmap level.</param>
        /// <param name="maxAnisotropy">The clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.</param>
        /// <param name="comparisonFunction">A function that compares sampled data against existing sampled data.</param>
        /// <param name="borderColor">The border color to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
        /// <param name="minLod">The lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
        /// <param name="maxLod">The upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
        public D3D11SamplerDesc(
            D3D11Filter filter,
            D3D11TextureAddressMode addressU,
            D3D11TextureAddressMode addressV,
            D3D11TextureAddressMode addressW,
            float mipLodBias,
            uint maxAnisotropy,
            D3D11ComparisonFunction comparisonFunction,
            float[] borderColor,
            float minLod,
            float maxLod)
        {
            if (borderColor != null && borderColor.Length != 4)
            {
                throw new ArgumentOutOfRangeException("borderColor");
            }

            this.filter = filter;
            this.addressU = addressU;
            this.addressV = addressV;
            this.addressW = addressW;
            this.mipLodBias = mipLodBias;
            this.maxAnisotropy = maxAnisotropy;
            this.comparisonFunction = comparisonFunction;

            if (borderColor == null)
            {
                borderColor = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            }

            this.borderColorR = borderColor[0];
            this.borderColorG = borderColor[1];
            this.borderColorB = borderColor[2];
            this.borderColorA = borderColor[3];

            this.minLod = minLod;
            this.maxLod = maxLod;
        }

        /// <summary>
        /// Gets default sampler-state values.
        /// </summary>
        public static D3D11SamplerDesc Default
        {
            get
            {
                return new D3D11SamplerDesc(
                    D3D11Filter.MinMagMipLinear,
                    D3D11TextureAddressMode.Clamp,
                    D3D11TextureAddressMode.Clamp,
                    D3D11TextureAddressMode.Clamp,
                    0.0f,
                    1,
                    D3D11ComparisonFunction.Never,
                    new float[] { 1.0f, 1.0f, 1.0f, 1.0f },
                    float.MinValue,
                    float.MaxValue);
            }
        }

        /// <summary>
        /// Gets or sets the filtering method to use when sampling a texture.
        /// </summary>
        public D3D11Filter Filter
        {
            get { return this.filter; }
            set { this.filter = value; }
        }

        /// <summary>
        /// Gets or sets the method to use for resolving a u texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D11TextureAddressMode AddressU
        {
            get { return this.addressU; }
            set { this.addressU = value; }
        }

        /// <summary>
        /// Gets or sets the method to use for resolving a v texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D11TextureAddressMode AddressV
        {
            get { return this.addressV; }
            set { this.addressV = value; }
        }

        /// <summary>
        /// Gets or sets the method to use for resolving a w texture coordinate that is outside the 0 to 1 range.
        /// </summary>
        public D3D11TextureAddressMode AddressW
        {
            get { return this.addressW; }
            set { this.addressW = value; }
        }

        /// <summary>
        /// Gets or sets the offset from the calculated mipmap level.
        /// </summary>
        public float MipLoadBias
        {
            get { return this.mipLodBias; }
            set { this.mipLodBias = value; }
        }

        /// <summary>
        /// Gets or sets the clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.
        /// </summary>
        public uint MaxAnisotropy
        {
            get { return this.maxAnisotropy; }
            set { this.maxAnisotropy = value; }
        }

        /// <summary>
        /// Gets or sets a function that compares sampled data against existing sampled data.
        /// </summary>
        public D3D11ComparisonFunction ComparisonFunction
        {
            get { return this.comparisonFunction; }
            set { this.comparisonFunction = value; }
        }

        /// <summary>
        /// Gets or sets the border color red component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        public float BorderColorR
        {
            get { return this.borderColorR; }
            set { this.borderColorR = value; }
        }

        /// <summary>
        /// Gets or sets the border color green component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        public float BorderColorG
        {
            get { return this.borderColorG; }
            set { this.borderColorG = value; }
        }

        /// <summary>
        /// Gets or sets the border color blue component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        public float BorderColorB
        {
            get { return this.borderColorB; }
            set { this.borderColorB = value; }
        }

        /// <summary>
        /// Gets or sets the border color alpha component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
        /// </summary>
        public float BorderColorA
        {
            get { return this.borderColorA; }
            set { this.borderColorA = value; }
        }

        /// <summary>
        /// Gets or sets the lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// </summary>
        public float MinLod
        {
            get { return this.minLod; }
            set { this.minLod = value; }
        }

        /// <summary>
        /// Gets or sets the upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
        /// </summary>
        public float MaxLod
        {
            get { return this.maxLod; }
            set { this.maxLod = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11SamplerDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11SamplerDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11SamplerDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11SamplerDesc left, D3D11SamplerDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11SamplerDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11SamplerDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11SamplerDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11SamplerDesc left, D3D11SamplerDesc right)
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
            if (!(obj is D3D11SamplerDesc))
            {
                return false;
            }

            return this.Equals((D3D11SamplerDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11SamplerDesc other)
        {
            return this.filter == other.filter
                && this.addressU == other.addressU
                && this.addressV == other.addressV
                && this.addressW == other.addressW
                && this.mipLodBias == other.mipLodBias
                && this.maxAnisotropy == other.maxAnisotropy
                && this.comparisonFunction == other.comparisonFunction
                && this.borderColorR == other.borderColorR
                && this.borderColorG == other.borderColorG
                && this.borderColorB == other.borderColorB
                && this.borderColorA == other.borderColorA
                && this.minLod == other.minLod
                && this.maxLod == other.maxLod;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.filter,
                this.addressU,
                this.addressV,
                this.addressW,
                this.mipLodBias,
                this.maxAnisotropy,
                this.comparisonFunction,
                this.borderColorR,
                this.borderColorG,
                this.borderColorB,
                this.borderColorA,
                this.minLod,
                this.maxLod
            }
            .GetHashCode();
        }
    }
}
