// <copyright file="D2D1HwndRenderTargetProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the HWND, pixel size, and presentation options for an <see cref="D2D1HwndRenderTarget"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1HwndRenderTargetProperties : IEquatable<D2D1HwndRenderTargetProperties>
    {
        /// <summary>
        /// The HWND to which the render target issues the output from its drawing commands.
        /// </summary>
        private IntPtr hwnd;

        /// <summary>
        /// The size of the render target, in pixels.
        /// </summary>
        private D2D1SizeU pixelSize;

        /// <summary>
        /// A value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the device to refresh before presenting.
        /// </summary>
        private D2D1PresentOptions presentOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1HwndRenderTargetProperties"/> struct.
        /// </summary>
        /// <param name="hwnd">The HWND to which the render target issues the output from its drawing commands.</param>
        public D2D1HwndRenderTargetProperties(IntPtr hwnd)
        {
            this.hwnd = hwnd;
            this.pixelSize = new D2D1SizeU(0U, 0U);
            this.presentOptions = D2D1PresentOptions.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1HwndRenderTargetProperties"/> struct.
        /// </summary>
        /// <param name="hwnd">The HWND to which the render target issues the output from its drawing commands.</param>
        /// <param name="pixelSize">The size of the render target, in pixels.</param>
        /// <param name="presentOptions">A value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the device to refresh before presenting.</param>
        public D2D1HwndRenderTargetProperties(IntPtr hwnd, D2D1SizeU pixelSize, D2D1PresentOptions presentOptions)
        {
            this.hwnd = hwnd;
            this.pixelSize = pixelSize;
            this.presentOptions = presentOptions;
        }

        /// <summary>
        /// Gets or sets the HWND to which the render target issues the output from its drawing commands.
        /// </summary>
        public IntPtr Hwnd
        {
            get { return this.hwnd; }
            set { this.hwnd = value; }
        }

        /// <summary>
        /// Gets or sets the size of the render target, in pixels.
        /// </summary>
        public D2D1SizeU PixelSize
        {
            get { return this.pixelSize; }
            set { this.pixelSize = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the device to refresh before presenting.
        /// </summary>
        public D2D1PresentOptions PresentOptions
        {
            get { return this.presentOptions; }
            set { this.presentOptions = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1HwndRenderTargetProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1HwndRenderTargetProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1HwndRenderTargetProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1HwndRenderTargetProperties left, D2D1HwndRenderTargetProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1HwndRenderTargetProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1HwndRenderTargetProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1HwndRenderTargetProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1HwndRenderTargetProperties left, D2D1HwndRenderTargetProperties right)
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
            if (obj is not D2D1HwndRenderTargetProperties)
            {
                return false;
            }

            return this.Equals((D2D1HwndRenderTargetProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1HwndRenderTargetProperties other)
        {
            return this.hwnd == other.hwnd
                && this.pixelSize == other.pixelSize
                && this.presentOptions == other.presentOptions;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.hwnd,
                this.pixelSize,
                this.presentOptions
            }
            .GetHashCode();
        }
    }
}
