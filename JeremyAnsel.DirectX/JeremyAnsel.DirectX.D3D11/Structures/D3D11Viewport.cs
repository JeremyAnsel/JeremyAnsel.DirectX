// <copyright file="D3D11Viewport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the dimensions of a viewport.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Viewport : IEquatable<D3D11Viewport>
    {
        /// <summary>
        /// The X position of the left hand side of the viewport.
        /// </summary>
        private float topLeftX;

        /// <summary>
        /// The Y position of the top of the viewport.
        /// </summary>
        private float topLeftY;

        /// <summary>
        /// The width of the viewport.
        /// </summary>
        private float width;

        /// <summary>
        /// The height of the viewport.
        /// </summary>
        private float height;

        /// <summary>
        /// The minimum depth of the viewport.
        /// </summary>
        private float minDepth;

        /// <summary>
        /// The maximum depth of the viewport.
        /// </summary>
        private float maxDepth;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="topLeftY">The Y position of the top of the viewport.</param>
        /// <param name="width">The width of the viewport.</param>
        /// <param name="height">The height of the viewport.</param>
        public D3D11Viewport(float topLeftX, float topLeftY, float width, float height)
        {
            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.width = width;
            this.height = height;
            this.minDepth = 0.0f;
            this.maxDepth = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="topLeftY">The Y position of the top of the viewport.</param>
        /// <param name="width">The width of the viewport.</param>
        /// <param name="height">The height of the viewport.</param>
        /// <param name="minDepth">The minimum depth of the viewport.</param>
        /// <param name="maxDepth">The maximum depth of the viewport.</param>
        public D3D11Viewport(float topLeftX, float topLeftY, float width, float height, float minDepth, float maxDepth)
        {
            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.width = width;
            this.height = height;
            this.minDepth = minDepth;
            this.maxDepth = maxDepth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="buffer">A buffer.</param>
        /// <param name="view">The render-target view.</param>
        public D3D11Viewport(D3D11Buffer buffer, D3D11RenderTargetView view)
            : this(buffer, view, 0.0f, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="buffer">A buffer.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        public D3D11Viewport(D3D11Buffer buffer, D3D11RenderTargetView view, float topLeftX)
            : this(buffer, view, topLeftX, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="buffer">A buffer.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="minDepth">The minimum depth of the viewport.</param>
        /// <param name="maxDepth">The maximum depth of the viewport.</param>
        public D3D11Viewport(D3D11Buffer buffer, D3D11RenderTargetView view, float topLeftX, float minDepth, float maxDepth)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var description = view.Description;

            uint numElements;

            switch (description.ViewDimension)
            {
                case D3D11RtvDimension.Buffer:
                    numElements = description.Buffer.NumElements;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            this.topLeftX = topLeftX;
            this.topLeftY = 0.0f;
            this.width = numElements - topLeftX;
            this.height = 1.0f;
            this.minDepth = minDepth;
            this.maxDepth = maxDepth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 1D texture.</param>
        /// <param name="view">The render-target view.</param>
        public D3D11Viewport(D3D11Texture1D texture, D3D11RenderTargetView view)
            : this(texture, view, 0.0f, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 1D texture.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        public D3D11Viewport(D3D11Texture1D texture, D3D11RenderTargetView view, float topLeftX)
            : this(texture, view, topLeftX, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 1D texture.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="minDepth">The minimum depth of the viewport.</param>
        /// <param name="maxDepth">The maximum depth of the viewport.</param>
        public D3D11Viewport(D3D11Texture1D texture, D3D11RenderTargetView view, float topLeftX, float minDepth, float maxDepth)
        {
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var textureDescription = texture.Description;
            var viewDescription = view.Description;

            uint mipSlice;

            switch (viewDescription.ViewDimension)
            {
                case D3D11RtvDimension.Texture1D:
                    mipSlice = viewDescription.Texture1D.MipSlice;
                    break;

                case D3D11RtvDimension.Texture1DArray:
                    mipSlice = viewDescription.Texture1DArray.MipSlice;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            uint subResourceWidth = textureDescription.Width / (uint)(1 << (int)mipSlice);

            this.topLeftX = topLeftX;
            this.topLeftY = 0.0f;
            this.width = (subResourceWidth != 0 ? subResourceWidth : 1) - topLeftX;
            this.height = 1.0f;
            this.minDepth = minDepth;
            this.maxDepth = maxDepth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 2D texture.</param>
        /// <param name="view">The render-target view.</param>
        public D3D11Viewport(D3D11Texture2D texture, D3D11RenderTargetView view)
            : this(texture, view, 0.0f, 0.0f, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 2D texture.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="topLeftY">The Y position of the top of the viewport.</param>
        public D3D11Viewport(D3D11Texture2D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY)
            : this(texture, view, topLeftX, topLeftY, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 2D texture.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="topLeftY">The Y position of the top of the viewport.</param>
        /// <param name="minDepth">The minimum depth of the viewport.</param>
        /// <param name="maxDepth">The maximum depth of the viewport.</param>
        public D3D11Viewport(D3D11Texture2D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY, float minDepth, float maxDepth)
        {
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var textureDescription = texture.Description;
            var viewDescription = view.Description;

            uint mipSlice;

            switch (viewDescription.ViewDimension)
            {
                case D3D11RtvDimension.Texture2D:
                    mipSlice = viewDescription.Texture2D.MipSlice;
                    break;

                case D3D11RtvDimension.Texture2DArray:
                    mipSlice = viewDescription.Texture2DArray.MipSlice;
                    break;

                case D3D11RtvDimension.Texture2DMs:
                case D3D11RtvDimension.Texture2DMsArray:
                    mipSlice = 0;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            uint subResourceWidth = textureDescription.Width / (uint)(1 << (int)mipSlice);
            uint subResourceHeight = textureDescription.Height / (uint)(1 << (int)mipSlice);

            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.width = (subResourceWidth != 0 ? subResourceWidth : 1) - topLeftX;
            this.height = (subResourceHeight != 0 ? subResourceHeight : 1) - topLeftY;
            this.minDepth = minDepth;
            this.maxDepth = maxDepth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 3D texture.</param>
        /// <param name="view">The render-target view.</param>
        public D3D11Viewport(D3D11Texture3D texture, D3D11RenderTargetView view)
            : this(texture, view, 0.0f, 0.0f, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 3D texture.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="topLeftY">The Y position of the top of the viewport.</param>
        public D3D11Viewport(D3D11Texture3D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY)
            : this(texture, view, topLeftX, topLeftY, 0.0f, 1.0f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
        /// </summary>
        /// <param name="texture">A 3D texture.</param>
        /// <param name="view">The render-target view.</param>
        /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
        /// <param name="topLeftY">The Y position of the top of the viewport.</param>
        /// <param name="minDepth">The minimum depth of the viewport.</param>
        /// <param name="maxDepth">The maximum depth of the viewport.</param>
        public D3D11Viewport(D3D11Texture3D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY, float minDepth, float maxDepth)
        {
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var textureDescription = texture.Description;
            var viewDescription = view.Description;

            uint mipSlice;

            switch (viewDescription.ViewDimension)
            {
                case D3D11RtvDimension.Texture3D:
                    mipSlice = viewDescription.Texture3D.MipSlice;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(view));
            }

            uint subResourceWidth = textureDescription.Width / (uint)(1 << (int)mipSlice);
            uint subResourceHeight = textureDescription.Height / (uint)(1 << (int)mipSlice);

            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.width = (subResourceWidth != 0 ? subResourceWidth : 1) - topLeftX;
            this.height = (subResourceHeight != 0 ? subResourceHeight : 1) - topLeftY;
            this.minDepth = minDepth;
            this.maxDepth = maxDepth;
        }

        /// <summary>
        /// Gets or sets the X position of the left hand side of the viewport.
        /// </summary>
        public float TopLeftX
        {
            get { return this.topLeftX; }
            set { this.topLeftX = value; }
        }

        /// <summary>
        /// Gets or sets the Y position of the top of the viewport.
        /// </summary>
        public float TopLeftY
        {
            get { return this.topLeftY; }
            set { this.topLeftY = value; }
        }

        /// <summary>
        /// Gets or sets the width of the viewport.
        /// </summary>
        public float Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the height of the viewport.
        /// </summary>
        public float Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Gets or sets the minimum depth of the viewport.
        /// </summary>
        public float MinDepth
        {
            get { return this.minDepth; }
            set { this.minDepth = value; }
        }

        /// <summary>
        /// Gets or sets the maximum depth of the viewport.
        /// </summary>
        public float MaxDepth
        {
            get { return this.maxDepth; }
            set { this.maxDepth = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Viewport"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Viewport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Viewport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Viewport left, D3D11Viewport right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Viewport"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Viewport"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Viewport"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Viewport left, D3D11Viewport right)
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
            if (obj is not D3D11Viewport)
            {
                return false;
            }

            return this.Equals((D3D11Viewport)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Viewport other)
        {
            return this.topLeftX == other.topLeftX
                && this.topLeftY == other.topLeftY
                && this.width == other.width
                && this.height == other.height
                && this.minDepth == other.minDepth
                && this.maxDepth == other.maxDepth;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.topLeftX,
                this.topLeftY,
                this.width,
                this.height,
                this.minDepth,
                this.maxDepth
            }
            .GetHashCode();
        }
    }
}
