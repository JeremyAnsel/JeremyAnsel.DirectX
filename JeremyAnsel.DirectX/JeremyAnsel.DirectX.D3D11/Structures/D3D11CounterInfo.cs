// <copyright file="D3D11CounterInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Information about the video card's performance counter capabilities.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11CounterInfo : IEquatable<D3D11CounterInfo>
    {
        /// <summary>
        /// The largest device-dependent counter ID that the device supports. If none are supported, this value will be 0.
        /// </summary>
        private D3D11CounterType lastDeviceDependentCounter;

        /// <summary>
        /// The number of counters that can be simultaneously supported.
        /// </summary>
        private uint numSimultaneousCounters;

        /// <summary>
        /// The number of detectable parallel units that the counter is able to discern. Values are 1 ~ 4.
        /// </summary>
        private byte numDetectableParallelUnits;

        /// <summary>
        /// Gets the largest device-dependent counter ID that the device supports. If none are supported, this value will be 0.
        /// </summary>
        public D3D11CounterType LastDeviceDependantCounter
        {
            get { return this.lastDeviceDependentCounter; }
        }

        /// <summary>
        /// Gets the number of counters that can be simultaneously supported.
        /// </summary>
        public uint NumSimultaneousCounters
        {
            get { return this.numSimultaneousCounters; }
        }

        /// <summary>
        /// Gets the number of detectable parallel units that the counter is able to discern. Values are 1 ~ 4.
        /// </summary>
        public byte NumDetectableParallelUnits
        {
            get { return this.numDetectableParallelUnits; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11CounterInfo"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11CounterInfo"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11CounterInfo"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11CounterInfo left, D3D11CounterInfo right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11CounterInfo"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11CounterInfo"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11CounterInfo"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11CounterInfo left, D3D11CounterInfo right)
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
            if (!(obj is D3D11CounterInfo))
            {
                return false;
            }

            return this.Equals((D3D11CounterInfo)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11CounterInfo other)
        {
            return this.lastDeviceDependentCounter == other.lastDeviceDependentCounter
                && this.numSimultaneousCounters == other.numSimultaneousCounters
                && this.numDetectableParallelUnits == other.numDetectableParallelUnits;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.lastDeviceDependentCounter,
                this.numSimultaneousCounters,
                this.numDetectableParallelUnits
            }
            .GetHashCode();
        }
    }
}
