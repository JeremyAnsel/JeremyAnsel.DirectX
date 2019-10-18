// <copyright file="D2D1LayerParameters.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Contains the content bounds, mask information, opacity settings, and other options for a layer resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1LayerParameters : IEquatable<D2D1LayerParameters>
    {
        /// <summary>
        /// The content bounds of the layer. Content outside these bounds is not guaranteed to render.
        /// </summary>
        private D2D1RectF contentBounds;

        /// <summary>
        /// The geometric mask specifies the area of the layer that is composited into the render target.
        /// </summary>
        private ID2D1Geometry geometricMask;

        /// <summary>
        /// A value that specifies the antialiasing mode for the geometricMask.
        /// </summary>
        private D2D1AntialiasMode maskAntialiasMode;

        /// <summary>
        /// A value that specifies the transform that is applied to the geometric mask when composing the layer.
        /// </summary>
        private D2D1Matrix3X2F maskTransform;

        /// <summary>
        /// An opacity value that is applied uniformly to all resources in the layer when compositing to the target.
        /// </summary>
        private float opacity;

        /// <summary>
        /// A brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush pixel is multiplied against the corresponding layer pixel.
        /// </summary>
        private ID2D1Brush opacityBrush;

        /// <summary>
        /// A value that specifies whether the layer intends to render text with ClearType antialiasing.
        /// </summary>
        private D2D1LayerOptions layerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1LayerParameters"/> struct.
        /// </summary>
        /// <param name="contentBounds">The content bounds of the layer. Content outside these bounds is not guaranteed to render.</param>
        /// <param name="geometricMask">The geometric mask specifies the area of the layer that is composited into the render target.</param>
        /// <param name="maskAntialiasMode">A value that specifies the antialiasing mode for the geometricMask.</param>
        /// <param name="maskTransform">A value that specifies the transform that is applied to the geometric mask when composing the layer.</param>
        /// <param name="opacity">An opacity value that is applied uniformly to all resources in the layer when compositing to the target.</param>
        /// <param name="opacityBrush">A brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush pixel is multiplied against the corresponding layer pixel.</param>
        /// <param name="layerOptions">A value that specifies whether the layer intends to render text with ClearType antialiasing.</param>
        public D2D1LayerParameters(
            D2D1RectF contentBounds,
            D2D1Geometry geometricMask,
            D2D1AntialiasMode maskAntialiasMode,
            D2D1Matrix3X2F maskTransform,
            float opacity,
            D2D1Brush opacityBrush,
            D2D1LayerOptions layerOptions)
        {
            this.contentBounds = contentBounds;
            this.geometricMask = geometricMask?.GetHandle<ID2D1Geometry>();
            this.maskAntialiasMode = maskAntialiasMode;
            this.maskTransform = maskTransform;
            this.opacity = opacity;
            this.opacityBrush = opacityBrush?.GetHandle<ID2D1Brush>();
            this.layerOptions = layerOptions;
        }

        /// <summary>
        /// Gets default parameters.
        /// </summary>
        public static D2D1LayerParameters Default
        {
            get { return new D2D1LayerParameters(D2D1RectF.Infinite, null, D2D1AntialiasMode.PerPrimitive, D2D1Matrix3X2F.Identity, 1.0f, null, D2D1LayerOptions.None); }
        }

        /// <summary>
        /// Gets or sets the content bounds of the layer. Content outside these bounds is not guaranteed to render.
        /// </summary>
        public D2D1RectF ContentBounds
        {
            get { return this.contentBounds; }
            set { this.contentBounds = value; }
        }

        /// <summary>
        /// Gets or sets the geometric mask specifies the area of the layer that is composited into the render target.
        /// </summary>
        public D2D1Geometry GeometricMask
        {
            get
            {
                return this.geometricMask == null ? null : new D2D1GeometryBase(this.geometricMask);
            }

            set
            {
                this.geometricMask = value?.GetHandle<ID2D1Geometry>();
            }
        }

        /// <summary>
        /// Gets or sets a value that specifies the antialiasing mode for the geometricMask.
        /// </summary>
        public D2D1AntialiasMode MaskAntialiasMode
        {
            get { return this.maskAntialiasMode; }
            set { this.maskAntialiasMode = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies the transform that is applied to the geometric mask when composing the layer.
        /// </summary>
        public D2D1Matrix3X2F MaskTransform
        {
            get { return this.maskTransform; }
            set { this.maskTransform = value; }
        }

        /// <summary>
        /// Gets or sets an opacity value that is applied uniformly to all resources in the layer when compositing to the target.
        /// </summary>
        public float Opacity
        {
            get { return this.opacity; }
            set { this.opacity = value; }
        }

        /// <summary>
        /// Gets or sets a brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush pixel is multiplied against the corresponding layer pixel.
        /// </summary>
        public D2D1Brush OpacityBrush
        {
            get
            {
                return this.opacityBrush == null ? null : new D2D1BrushBase(this.opacityBrush);
            }

            set
            {
                this.opacityBrush = value?.GetHandle<ID2D1Brush>();
            }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the layer intends to render text with ClearType antialiasing.
        /// </summary>
        public D2D1LayerOptions LayerOptions
        {
            get { return this.layerOptions; }
            set { this.layerOptions = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1LayerParameters"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1LayerParameters"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1LayerParameters"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1LayerParameters left, D2D1LayerParameters right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1LayerParameters"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1LayerParameters"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1LayerParameters"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1LayerParameters left, D2D1LayerParameters right)
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
            if (!(obj is D2D1LayerParameters))
            {
                return false;
            }

            return this.Equals((D2D1LayerParameters)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1LayerParameters other)
        {
            return this.contentBounds == other.contentBounds
                && this.geometricMask == other.geometricMask
                && this.maskAntialiasMode == other.maskAntialiasMode
                && this.maskTransform == other.maskTransform
                && this.opacity == other.opacity
                && this.opacityBrush == other.opacityBrush
                && this.layerOptions == other.layerOptions;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.contentBounds,
                this.geometricMask,
                this.maskAntialiasMode,
                this.maskTransform,
                this.opacity,
                this.opacityBrush,
                this.layerOptions
            }
            .GetHashCode();
        }
    }
}
