// <copyright file="D3D11DepthStencilOperationDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Stencil operations that can be performed based on the results of stencil test.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11DepthStencilOperationDesc : IEquatable<D3D11DepthStencilOperationDesc>
    {
        /// <summary>
        /// The stencil operation to perform when stencil testing fails.
        /// </summary>
        private D3D11StencilOperation stencilFailOperation;

        /// <summary>
        /// The stencil operation to perform when stencil testing passes and depth testing fails.
        /// </summary>
        private D3D11StencilOperation stencilDepthFailOperation;

        /// <summary>
        /// The stencil operation to perform when stencil testing and depth testing both pass.
        /// </summary>
        private D3D11StencilOperation stencilPassOperation;

        /// <summary>
        /// A function that compares stencil data against existing stencil data.
        /// </summary>
        private D3D11ComparisonFunction stencilFunction;

        /// <summary>
        /// Gets or sets the stencil operation to perform when stencil testing fails.
        /// </summary>
        public D3D11StencilOperation StencilFailOperation
        {
            get { return this.stencilFailOperation; }
            set { this.stencilFailOperation = value; }
        }

        /// <summary>
        /// Gets or sets the stencil operation to perform when stencil testing passes and depth testing fails.
        /// </summary>
        public D3D11StencilOperation StencilDepthFailOperation
        {
            get { return this.stencilDepthFailOperation; }
            set { this.stencilDepthFailOperation = value; }
        }

        /// <summary>
        /// Gets or sets the stencil operation to perform when stencil testing and depth testing both pass.
        /// </summary>
        public D3D11StencilOperation StencilPassOperation
        {
            get { return this.stencilPassOperation; }
            set { this.stencilPassOperation = value; }
        }

        /// <summary>
        /// Gets or sets a function that compares stencil data against existing stencil data.
        /// </summary>
        public D3D11ComparisonFunction StencilFunction
        {
            get { return this.stencilFunction; }
            set { this.stencilFunction = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11DepthStencilOperationDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11DepthStencilOperationDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11DepthStencilOperationDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11DepthStencilOperationDesc left, D3D11DepthStencilOperationDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11DepthStencilOperationDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11DepthStencilOperationDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11DepthStencilOperationDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11DepthStencilOperationDesc left, D3D11DepthStencilOperationDesc right)
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
            if (!(obj is D3D11DepthStencilOperationDesc))
            {
                return false;
            }

            return this.Equals((D3D11DepthStencilOperationDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11DepthStencilOperationDesc other)
        {
            return this.stencilFailOperation == other.stencilFailOperation
                && this.stencilDepthFailOperation == other.stencilDepthFailOperation
                && this.stencilPassOperation == other.stencilPassOperation
                && this.stencilFunction == other.stencilFunction;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.stencilFailOperation,
                this.stencilDepthFailOperation,
                this.stencilPassOperation,
                this.stencilFunction
            }
            .GetHashCode();
        }
    }
}
