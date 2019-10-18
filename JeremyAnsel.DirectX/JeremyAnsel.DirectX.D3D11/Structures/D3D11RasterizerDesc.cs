// <copyright file="D3D11RasterizerDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes rasterizer state.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11RasterizerDesc : IEquatable<D3D11RasterizerDesc>
    {
        /// <summary>
        /// Determines the fill mode to use when rendering.
        /// </summary>
        private D3D11FillMode fillMode;

        /// <summary>
        /// Indicates whether triangles facing the specified direction are not drawn.
        /// </summary>
        private D3D11CullMode cullMode;

        /// <summary>
        /// Determines if a triangle is front- or back-facing.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isFrontCounterClockwise;

        /// <summary>
        /// The depth value added to a given pixel.
        /// </summary>
        private int depthBias;

        /// <summary>
        /// The maximum depth bias of a pixel.
        /// </summary>
        private float depthBiasClamp;

        /// <summary>
        /// The scalar on a given pixel's slope.
        /// </summary>
        private float slopeScaledDepthBias;

        /// <summary>
        /// Specifies whether clipping based on distance is enabled.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isDepthClipEnabled;

        /// <summary>
        /// Specifies whether scissor-rectangle culling is enabled.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isScissorEnabled;

        /// <summary>
        /// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isMultisampleEnabled;

        /// <summary>
        /// Specifies whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>false</c>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isAntialiasedLineEnabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11RasterizerDesc"/> struct.
        /// </summary>
        /// <param name="fillMode">Determines the fill mode to use when rendering.</param>
        /// <param name="cullMode">Indicates whether triangles facing the specified direction are not drawn.</param>
        /// <param name="isFrontCounterClockwise">Determines if a triangle is front- or back-facing.</param>
        /// <param name="depthBias">The depth value added to a given pixel.</param>
        /// <param name="depthBiasClamp">The maximum depth bias of a pixel.</param>
        /// <param name="slopeScaledDepthBias">The scalar on a given pixel's slope.</param>
        /// <param name="isDepthClipEnabled">Specifies whether clipping based on distance is enabled.</param>
        /// <param name="isScissorEnabled">Specifies whether scissor-rectangle culling is enabled.</param>
        /// <param name="isMultisampleEnabled">Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.</param>
        /// <param name="isAntialiasedLineEnabled">Specifies whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>false</c>.</param>
        public D3D11RasterizerDesc(
            D3D11FillMode fillMode,
            D3D11CullMode cullMode,
            bool isFrontCounterClockwise,
            int depthBias,
            float depthBiasClamp,
            float slopeScaledDepthBias,
            bool isDepthClipEnabled,
            bool isScissorEnabled,
            bool isMultisampleEnabled,
            bool isAntialiasedLineEnabled)
        {
            this.fillMode = fillMode;
            this.cullMode = cullMode;
            this.isFrontCounterClockwise = isFrontCounterClockwise;
            this.depthBias = depthBias;
            this.depthBiasClamp = depthBiasClamp;
            this.slopeScaledDepthBias = slopeScaledDepthBias;
            this.isDepthClipEnabled = isDepthClipEnabled;
            this.isScissorEnabled = isScissorEnabled;
            this.isMultisampleEnabled = isMultisampleEnabled;
            this.isAntialiasedLineEnabled = isAntialiasedLineEnabled;
        }

        /// <summary>
        /// Gets default rasterizer-state values.
        /// </summary>
        public static D3D11RasterizerDesc Default
        {
            get
            {
                return new D3D11RasterizerDesc(
                    D3D11FillMode.Solid,
                    D3D11CullMode.Back,
                    false,
                    0,
                    0.0f,
                    0.0f,
                    true,
                    false,
                    false,
                    false);
            }
        }

        /// <summary>
        /// Gets or sets the fill mode to use when rendering.
        /// </summary>
        public D3D11FillMode FillMode
        {
            get { return this.fillMode; }
            set { this.fillMode = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether triangles facing the specified direction are not drawn.
        /// </summary>
        public D3D11CullMode CullMode
        {
            get { return this.cullMode; }
            set { this.cullMode = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a triangle is front- or back-facing.
        /// </summary>
        public bool IsFrontCounterClockwise
        {
            get { return this.isFrontCounterClockwise; }
            set { this.isFrontCounterClockwise = value; }
        }

        /// <summary>
        /// Gets or sets the depth value added to a given pixel.
        /// </summary>
        public int DepthBias
        {
            get { return this.depthBias; }
            set { this.depthBias = value; }
        }

        /// <summary>
        /// Gets or sets the maximum depth bias of a pixel.
        /// </summary>
        public float DepthBiasClamp
        {
            get { return this.depthBiasClamp; }
            set { this.depthBiasClamp = value; }
        }

        /// <summary>
        /// Gets or sets the scalar on a given pixel's slope.
        /// </summary>
        public float SlopeScaledDepthBias
        {
            get { return this.slopeScaledDepthBias; }
            set { this.slopeScaledDepthBias = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether clipping based on distance is enabled.
        /// </summary>
        public bool IsDepthClipEnabled
        {
            get { return this.isDepthClipEnabled; }
            set { this.isDepthClipEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether scissor-rectangle culling is enabled.
        /// </summary>
        public bool IsScissorEnabled
        {
            get { return this.isScissorEnabled; }
            set { this.isScissorEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.
        /// </summary>
        public bool IsMultisampleEnabled
        {
            get { return this.isMultisampleEnabled; }
            set { this.isMultisampleEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>false</c>.
        /// </summary>
        public bool IsAntialiasedLineEnabled
        {
            get { return this.isAntialiasedLineEnabled; }
            set { this.isAntialiasedLineEnabled = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11RasterizerDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11RasterizerDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11RasterizerDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11RasterizerDesc left, D3D11RasterizerDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11RasterizerDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11RasterizerDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11RasterizerDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11RasterizerDesc left, D3D11RasterizerDesc right)
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
            if (!(obj is D3D11RasterizerDesc))
            {
                return false;
            }

            return this.Equals((D3D11RasterizerDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11RasterizerDesc other)
        {
            return this.fillMode == other.fillMode
                && this.cullMode == other.cullMode
                && this.isFrontCounterClockwise == other.isFrontCounterClockwise
                && this.depthBias == other.depthBias
                && this.depthBiasClamp == other.depthBiasClamp
                && this.slopeScaledDepthBias == other.slopeScaledDepthBias
                && this.isDepthClipEnabled == other.isDepthClipEnabled
                && this.isScissorEnabled == other.isScissorEnabled
                && this.isMultisampleEnabled == other.isMultisampleEnabled
                && this.isAntialiasedLineEnabled == other.isAntialiasedLineEnabled;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.fillMode,
                this.cullMode,
                this.isFrontCounterClockwise,
                this.depthBias,
                this.depthBiasClamp,
                this.slopeScaledDepthBias,
                this.isDepthClipEnabled,
                this.isScissorEnabled,
                this.isMultisampleEnabled,
                this.isAntialiasedLineEnabled
            }
            .GetHashCode();
        }
    }
}
