// <copyright file="DxgiPresentParameters.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes information about present that helps the operating system optimize presentation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DxgiPresentParameters : IEquatable<DxgiPresentParameters>
    {
        /// <summary>
        /// The number of updated rectangles that you update in the back buffer for the presented frame. The operating system uses this information to optimize presentation. You can set this member to 0 to indicate that you update the whole frame.
        /// </summary>
        private uint dirtyRectsCount;

        /// <summary>
        /// A list of updated rectangles that you update in the back buffer for the presented frame. An application must update every single pixel in each rectangle that it reports to the runtime; the application cannot assume that the pixels are saved from the previous frame.
        /// </summary>
        private IntPtr dirtyRects;

        /// <summary>
        /// A pointer to the scrolled rectangle. The scrolled rectangle is the rectangle of the previous frame from which the runtime bit-block transfers content. The runtime also uses the scrolled rectangle to optimize presentation in terminal server and indirect display scenarios.
        /// </summary>
        private IntPtr scrollRect;

        /// <summary>
        /// A pointer to the offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).
        /// </summary>
        private IntPtr scrollOffset;

        /// <summary>
        /// Sets the number of updated rectangles that you update in the back buffer for the presented frame. The operating system uses this information to optimize presentation. You can set this member to 0 to indicate that you update the whole frame.
        /// </summary>
        public uint DirtyRectsCount
        {
            set { this.dirtyRectsCount = value; }
        }

        /// <summary>
        /// Sets list of updated rectangles that you update in the back buffer for the presented frame. An application must update every single pixel in each rectangle that it reports to the runtime; the application cannot assume that the pixels are saved from the previous frame.
        /// </summary>
        public IntPtr DirtyRects
        {
            set { this.dirtyRects = value; }
        }

        /// <summary>
        /// Sets the scrolled rectangle. The scrolled rectangle is the rectangle of the previous frame from which the runtime bit-block transfers content. The runtime also uses the scrolled rectangle to optimize presentation in terminal server and indirect display scenarios.
        /// </summary>
        public IntPtr ScrollRect
        {
            set { this.scrollRect = value; }
        }

        /// <summary>
        /// Sets the offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).
        /// </summary>
        public IntPtr ScrollOffset
        {
            set { this.scrollOffset = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiPresentParameters"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiPresentParameters"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiPresentParameters"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiPresentParameters left, DxgiPresentParameters right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiPresentParameters"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiPresentParameters"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiPresentParameters"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiPresentParameters left, DxgiPresentParameters right)
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
            if (obj is not DxgiPresentParameters)
            {
                return false;
            }

            return this.Equals((DxgiPresentParameters)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiPresentParameters other)
        {
            return this.dirtyRectsCount == other.dirtyRectsCount
                && this.dirtyRects == other.dirtyRects
                && this.scrollRect == other.scrollRect
                && this.scrollOffset == other.scrollOffset;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.dirtyRectsCount,
                this.dirtyRects,
                this.scrollRect,
                this.scrollOffset
            }
            .GetHashCode();
        }
    }
}
