// <copyright file="DxgiFrameStatistics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes timing and presentation statistics for a frame.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiFrameStatistics : IEquatable<DxgiFrameStatistics>
    {
        /// <summary>
        /// A value that represents the running total count of times that an image was presented to the monitor since the computer booted.
        /// </summary>
        private uint presentCount;

        /// <summary>
        /// A value that represents the running total count of v-blanks at which the last image was presented to the monitor and that have happened since the computer booted (for windowed mode, since the swap chain was created).
        /// </summary>
        private uint presentRefreshCount;

        /// <summary>
        /// A value that represents the running total count of v-blanks when the scheduler last sampled the machine time by calling <c>QueryPerformanceCounter</c> and that have happened since the computer booted (for windowed mode, since the swap chain was created).
        /// </summary>
        private uint syncRefreshCount;

        /// <summary>
        /// A value that represents the high-resolution performance counter timer. This value is the same as the value returned by the <c>QueryPerformanceCounter</c> function.
        /// </summary>
        private ulong syncQpcTime;

        /// <summary>
        /// The GPU time. Reserved. Always returns 0.
        /// </summary>
        private ulong syncGpuTime;

        /// <summary>
        /// Gets a value that represents the running total count of times that an image was presented to the monitor since the computer booted.
        /// </summary>
        public uint PresentCount
        {
            get { return this.presentCount; }
        }

        /// <summary>
        /// Gets a value that represents the running total count of v-blanks at which the last image was presented to the monitor and that have happened since the computer booted (for windowed mode, since the swap chain was created).
        /// </summary>
        public uint PresentRefreshCount
        {
            get { return this.presentRefreshCount; }
        }

        /// <summary>
        /// Gets a value that represents the running total count of v-blanks when the scheduler last sampled the machine time by calling <c>QueryPerformanceCounter</c> and that have happened since the computer booted (for windowed mode, since the swap chain was created).
        /// </summary>
        public uint SyncRefreshCount
        {
            get { return this.syncRefreshCount; }
        }

        /// <summary>
        /// Gets a value that represents the high-resolution performance counter timer. This value is the same as the value returned by the <c>QueryPerformanceCounter</c> function.
        /// </summary>
        public ulong SyncQpcTime
        {
            get { return this.syncQpcTime; }
        }

        /// <summary>
        /// Gets the GPU time. Reserved. Always returns 0.
        /// </summary>
        public ulong SyncGpuTime
        {
            get { return this.syncGpuTime; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiFrameStatistics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiFrameStatistics"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiFrameStatistics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiFrameStatistics left, DxgiFrameStatistics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiFrameStatistics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiFrameStatistics"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiFrameStatistics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiFrameStatistics left, DxgiFrameStatistics right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "PresentCount: {0}; PresentRefreshCount: {1}",
                this.presentCount,
                this.presentRefreshCount);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiFrameStatistics))
            {
                return false;
            }

            return this.Equals((DxgiFrameStatistics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiFrameStatistics other)
        {
            return this.presentCount == other.presentCount
                && this.presentRefreshCount == other.presentRefreshCount
                && this.syncRefreshCount == other.syncRefreshCount
                && this.syncQpcTime == other.syncQpcTime
                && this.syncGpuTime == other.syncGpuTime;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.presentCount,
                this.presentRefreshCount,
                this.syncRefreshCount,
                this.syncQpcTime,
                this.syncGpuTime
            }
            .GetHashCode();
        }
    }
}
