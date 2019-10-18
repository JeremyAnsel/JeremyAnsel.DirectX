// <copyright file="D3D11ClassInstanceDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an HLSL class instance.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11ClassInstanceDesc : IEquatable<D3D11ClassInstanceDesc>
    {
        /// <summary>
        /// The instance ID of an HLSL class; the default value is 0.
        /// </summary>
        private uint instanceId;

        /// <summary>
        /// The instance index of an HLSL class; the default value is 0.
        /// </summary>
        private uint instanceIndex;

        /// <summary>
        /// The type ID of an HLSL class; the default value is 0.
        /// </summary>
        private uint typeId;

        /// <summary>
        /// Describes the constant buffer associated with an HLSL class; the default value is 0.
        /// </summary>
        private uint constantBuffer;

        /// <summary>
        /// The base constant buffer offset associated with an HLSL class; the default value is 0.
        /// </summary>
        private uint baseConstantBufferOffset;

        /// <summary>
        /// The base texture associated with an HLSL class; the default value is 127.
        /// </summary>
        private uint baseTexture;

        /// <summary>
        /// The base sampler associated with an HLSL class; the default value is 15.
        /// </summary>
        private uint baseSampler;

        /// <summary>
        /// Indicates whether the class was created; the default value is false.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isCreated;

        /// <summary>
        /// Gets the instance ID of an HLSL class; the default value is 0.
        /// </summary>
        public uint InstanceId
        {
            get { return this.instanceId; }
        }

        /// <summary>
        /// Gets the instance index of an HLSL class; the default value is 0.
        /// </summary>
        public uint InstanceIndex
        {
            get { return this.instanceIndex; }
        }

        /// <summary>
        /// Gets the type ID of an HLSL class; the default value is 0.
        /// </summary>
        public uint TypeId
        {
            get { return this.typeId; }
        }

        /// <summary>
        /// Gets a value indicating the constant buffer associated with an HLSL class; the default value is 0.
        /// </summary>
        public uint ConstanceBuffer
        {
            get { return this.constantBuffer; }
        }

        /// <summary>
        /// Gets the base constant buffer offset associated with an HLSL class; the default value is 0.
        /// </summary>
        public uint BaseConstantBufferOffset
        {
            get { return this.baseConstantBufferOffset; }
        }

        /// <summary>
        /// Gets the base texture associated with an HLSL class; the default value is 127.
        /// </summary>
        public uint BaseTexture
        {
            get { return this.baseTexture; }
        }

        /// <summary>
        /// Gets the base sampler associated with an HLSL class; the default value is 15.
        /// </summary>
        public uint BaseSampler
        {
            get { return this.baseSampler; }
        }

        /// <summary>
        /// Gets a value indicating whether the class was created; the default value is false.
        /// </summary>
        public bool IsCreated
        {
            get { return this.isCreated; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11ClassInstanceDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11ClassInstanceDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11ClassInstanceDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11ClassInstanceDesc left, D3D11ClassInstanceDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11ClassInstanceDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11ClassInstanceDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11ClassInstanceDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11ClassInstanceDesc left, D3D11ClassInstanceDesc right)
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
            if (!(obj is D3D11ClassInstanceDesc))
            {
                return false;
            }

            return this.Equals((D3D11ClassInstanceDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11ClassInstanceDesc other)
        {
            return this.instanceId == other.instanceId
                && this.instanceIndex == other.instanceIndex
                && this.typeId == other.typeId
                && this.constantBuffer == other.constantBuffer
                && this.baseConstantBufferOffset == other.baseConstantBufferOffset
                && this.baseTexture == other.baseTexture
                && this.baseSampler == other.baseSampler
                && this.isCreated == other.isCreated;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.instanceId,
                this.instanceIndex,
                this.typeId,
                this.constantBuffer,
                baseConstanceBufferOffset = this.baseConstantBufferOffset,
                this.baseTexture,
                this.baseSampler,
                this.isCreated
            }
            .GetHashCode();
        }
    }
}
