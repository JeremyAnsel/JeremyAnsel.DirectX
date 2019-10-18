// <copyright file="D2D1RenderTargetProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains rendering options (hardware or software), pixel format, DPI information, remoting options, and Direct3D support requirements for a render target.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1RenderTargetProperties : IEquatable<D2D1RenderTargetProperties>
    {
        /// <summary>
        /// A value that specifies whether the render target should force hardware or software rendering.
        /// </summary>
        private D2D1RenderTargetType renderTargetType;

        /// <summary>
        /// The pixel format and alpha mode of the render target.
        /// </summary>
        private D2D1PixelFormat pixelFormat;

        /// <summary>
        /// The horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
        /// </summary>
        private float dpiX;

        /// <summary>
        /// The vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
        /// </summary>
        private float dpiY;

        /// <summary>
        /// A value that specifies how the render target is remoted and whether it should be GDI-compatible.
        /// </summary>
        private D2D1RenderTargetUsages usage;

        /// <summary>
        /// A value that specifies the minimum Direct3D feature level required for hardware rendering.
        /// </summary>
        private D2D1FeatureLevel minLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RenderTargetProperties"/> struct.
        /// </summary>
        /// <param name="renderTargetType">A value that specifies whether the render target should force hardware or software rendering.</param>
        /// <param name="pixelFormat">The pixel format and alpha mode of the render target.</param>
        /// <param name="dpiX">The horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.</param>
        /// <param name="dpiY">The vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.</param>
        /// <param name="usage">A value that specifies how the render target is remoted and whether it should be GDI-compatible.</param>
        /// <param name="minLevel">A value that specifies the minimum Direct3D feature level required for hardware rendering.</param>
        public D2D1RenderTargetProperties(D2D1RenderTargetType renderTargetType, D2D1PixelFormat pixelFormat, float dpiX, float dpiY, D2D1RenderTargetUsages usage, D2D1FeatureLevel minLevel)
        {
            this.renderTargetType = renderTargetType;
            this.pixelFormat = pixelFormat;
            this.dpiX = dpiX;
            this.dpiY = dpiY;
            this.usage = usage;
            this.minLevel = minLevel;
        }

        /// <summary>
        /// Gets default properties.
        /// </summary>
        public static D2D1RenderTargetProperties Default
        {
            get { return new D2D1RenderTargetProperties(D2D1RenderTargetType.Default, D2D1PixelFormat.Default, 0.0f, 0.0f, D2D1RenderTargetUsages.None, D2D1FeatureLevel.Default); }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the render target should force hardware or software rendering.
        /// </summary>
        public D2D1RenderTargetType RenderTargetType
        {
            get { return this.renderTargetType; }
            set { this.renderTargetType = value; }
        }

        /// <summary>
        /// Gets or sets the pixel format and alpha mode of the render target.
        /// </summary>
        public D2D1PixelFormat PixelFormat
        {
            get { return this.pixelFormat; }
            set { this.pixelFormat = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
        /// </summary>
        public float DpiX
        {
            get { return this.dpiX; }
            set { this.dpiX = value; }
        }

        /// <summary>
        /// Gets or sets the vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
        /// </summary>
        public float DpiY
        {
            get { return this.dpiY; }
            set { this.dpiY = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies how the render target is remoted and whether it should be GDI-compatible.
        /// </summary>
        public D2D1RenderTargetUsages Usage
        {
            get { return this.usage; }
            set { this.usage = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies the minimum Direct3D feature level required for hardware rendering.
        /// </summary>
        public D2D1FeatureLevel MinLevel
        {
            get { return this.minLevel; }
            set { this.minLevel = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1RenderTargetProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RenderTargetProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RenderTargetProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1RenderTargetProperties left, D2D1RenderTargetProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1RenderTargetProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RenderTargetProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RenderTargetProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1RenderTargetProperties left, D2D1RenderTargetProperties right)
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
            if (!(obj is D2D1RenderTargetProperties))
            {
                return false;
            }

            return this.Equals((D2D1RenderTargetProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1RenderTargetProperties other)
        {
            return this.renderTargetType == other.renderTargetType
                && this.pixelFormat == other.pixelFormat
                && this.dpiX == other.dpiX
                && this.dpiY == other.dpiY
                && this.usage == other.usage
                && this.minLevel == other.minLevel;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.renderTargetType,
                this.pixelFormat,
                this.dpiX,
                this.dpiY,
                this.usage,
                this.minLevel
            }
            .GetHashCode();
        }
    }
}
