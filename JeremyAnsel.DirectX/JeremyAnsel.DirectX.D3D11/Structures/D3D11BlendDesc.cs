// <copyright file="D3D11BlendDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the blend state that you use in a call to <see cref="D3D11Device.CreateBlendState"/> to create a blend-state object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11BlendDesc : IEquatable<D3D11BlendDesc>
    {
        /// <summary>
        /// Specifies whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isAlphaToCoverageEnabled;

        /// <summary>
        /// Specifies whether to enable independent blending in simultaneous render targets.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isIndependentBlendEnabled;

        /// <summary>
        /// An array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private D3D11RenderTargetBlendDesc[] renderTargets;

        /// <summary>
        /// Gets default blend-state values.
        /// </summary>
        public static D3D11BlendDesc Default
        {
            get
            {
                D3D11RenderTargetBlendDesc defaultRenderTargetBlendDesc = new D3D11RenderTargetBlendDesc
                {
                    IsBlendEnabled = false,
                    SourceBlend = D3D11BlendValue.One,
                    DestinationBlend = D3D11BlendValue.Zero,
                    BlendOperation = D3D11BlendOperation.Add,
                    SourceBlendAlpha = D3D11BlendValue.One,
                    DestinationBlendAlpha = D3D11BlendValue.Zero,
                    BlendOperationAlpha = D3D11BlendOperation.Add,
                    RenderTargetWriteMask = D3D11ColorWriteEnables.All
                };

                return new D3D11BlendDesc
                {
                    isAlphaToCoverageEnabled = false,
                    isIndependentBlendEnabled = false,
                    renderTargets = Enumerable.Repeat(defaultRenderTargetBlendDesc, 8).ToArray()
                };
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target.
        /// </summary>
        public bool IsAlphaToCoverageEnabled
        {
            get { return this.isAlphaToCoverageEnabled; }
            set { this.isAlphaToCoverageEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable independent blending in simultaneous render targets.
        /// </summary>
        public bool IsIndependentBlendEnabled
        {
            get { return this.isIndependentBlendEnabled; }
            set { this.isIndependentBlendEnabled = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11BlendDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BlendDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BlendDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11BlendDesc left, D3D11BlendDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11BlendDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BlendDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BlendDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11BlendDesc left, D3D11BlendDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Gets an array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
        /// </summary>
        /// <returns>An array of <see cref="D3D11RenderTargetBlendDesc"/> structures.</returns>
        public D3D11RenderTargetBlendDesc[] GetRenderTargets()
        {
            return (D3D11RenderTargetBlendDesc[])this.renderTargets.Clone();
        }

        /// <summary>
        /// Sets an array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
        /// </summary>
        /// <param name="blendDescs">The blend states descriptions.</param>
        public void SetRenderTargets(D3D11RenderTargetBlendDesc[] blendDescs)
        {
            if (blendDescs == null)
            {
                throw new ArgumentNullException(nameof(blendDescs));
            }

            if (blendDescs.Length != 8)
            {
                throw new ArgumentOutOfRangeException(nameof(blendDescs));
            }

            this.renderTargets = (D3D11RenderTargetBlendDesc[])blendDescs.Clone();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is D3D11BlendDesc))
            {
                return false;
            }

            return this.Equals((D3D11BlendDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11BlendDesc other)
        {
            return this.isAlphaToCoverageEnabled == other.isAlphaToCoverageEnabled
                && this.isIndependentBlendEnabled == other.isIndependentBlendEnabled
                && this.renderTargets == other.renderTargets;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isAlphaToCoverageEnabled,
                this.isIndependentBlendEnabled,
                this.renderTargets
            }
            .GetHashCode();
        }
    }
}
