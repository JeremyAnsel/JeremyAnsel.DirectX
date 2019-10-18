// <copyright file="D3D11RenderTargetBlendDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the blend state for a render target.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11RenderTargetBlendDesc : IEquatable<D3D11RenderTargetBlendDesc>
    {
        /// <summary>
        /// Specifies whether blending is enabled.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isBlendEnabled;

        /// <summary>
        /// The operation to perform on the RGB value that the pixel shader outputs.
        /// </summary>
        private D3D11BlendValue sourceBlend;

        /// <summary>
        /// The operation to perform on the current RGB value in the render target.
        /// </summary>
        private D3D11BlendValue destinationBlend;

        /// <summary>
        /// Defines how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.
        /// </summary>
        private D3D11BlendOperation blendOperation;

        /// <summary>
        /// The operation to perform on the alpha value that the pixel shader outputs. Blend options that end in <c>_COLOR</c> are not allowed.
        /// </summary>
        private D3D11BlendValue sourceBlendAlpha;

        /// <summary>
        /// The operation to perform on the current alpha value in the render target. Blend options that end in <c>_COLOR</c> are not allowed.
        /// </summary>
        private D3D11BlendValue destinationBlendAlpha;

        /// <summary>
        /// Defines how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.
        /// </summary>
        private D3D11BlendOperation blendOperationAlpha;

        /// <summary>
        /// A write mask.
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        private D3D11ColorWriteEnables renderTargetWriteMask;

        /// <summary>
        /// Gets or sets a value indicating whether blending is enabled.
        /// </summary>
        public bool IsBlendEnabled
        {
            get { return this.isBlendEnabled; }
            set { this.isBlendEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the operation to perform on the RGB value that the pixel shader outputs.
        /// </summary>
        public D3D11BlendValue SourceBlend
        {
            get { return this.sourceBlend; }
            set { this.sourceBlend = value; }
        }

        /// <summary>
        /// Gets or sets the operation to perform on the current RGB value in the render target.
        /// </summary>
        public D3D11BlendValue DestinationBlend
        {
            get { return this.destinationBlend; }
            set { this.destinationBlend = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.
        /// </summary>
        public D3D11BlendOperation BlendOperation
        {
            get { return this.blendOperation; }
            set { this.blendOperation = value; }
        }

        /// <summary>
        /// Gets or sets the operation to perform on the alpha value that the pixel shader outputs. Blend options that end in <c>_COLOR</c> are not allowed.
        /// </summary>
        public D3D11BlendValue SourceBlendAlpha
        {
            get { return this.sourceBlendAlpha; }
            set { this.sourceBlendAlpha = value; }
        }

        /// <summary>
        /// Gets or sets the operation to perform on the current alpha value in the render target. Blend options that end in <c>_COLOR</c> are not allowed.
        /// </summary>
        public D3D11BlendValue DestinationBlendAlpha
        {
            get { return this.destinationBlendAlpha; }
            set { this.destinationBlendAlpha = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.
        /// </summary>
        public D3D11BlendOperation BlendOperationAlpha
        {
            get { return this.blendOperationAlpha; }
            set { this.blendOperationAlpha = value; }
        }

        /// <summary>
        /// Gets or sets a write mask.
        /// </summary>
        public D3D11ColorWriteEnables RenderTargetWriteMask
        {
            get { return this.renderTargetWriteMask; }
            set { this.renderTargetWriteMask = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11RenderTargetBlendDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11RenderTargetBlendDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11RenderTargetBlendDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11RenderTargetBlendDesc left, D3D11RenderTargetBlendDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11RenderTargetBlendDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11RenderTargetBlendDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11RenderTargetBlendDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11RenderTargetBlendDesc left, D3D11RenderTargetBlendDesc right)
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
            if (!(obj is D3D11RenderTargetBlendDesc))
            {
                return false;
            }

            return this.Equals((D3D11RenderTargetBlendDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11RenderTargetBlendDesc other)
        {
            return this.isBlendEnabled == other.isBlendEnabled
                && this.sourceBlend == other.sourceBlend
                && this.destinationBlend == other.destinationBlend
                && this.blendOperation == other.blendOperation
                && this.sourceBlendAlpha == other.sourceBlendAlpha
                && this.destinationBlendAlpha == other.destinationBlendAlpha
                && this.blendOperationAlpha == other.blendOperationAlpha
                && this.renderTargetWriteMask == other.renderTargetWriteMask;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isBlendEnabled,
                this.sourceBlend,
                this.destinationBlend,
                this.blendOperation,
                this.sourceBlendAlpha,
                this.destinationBlendAlpha,
                this.blendOperationAlpha,
                this.renderTargetWriteMask
            }
            .GetHashCode();
        }
    }
}
