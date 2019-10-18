// <copyright file="DxgiOutputDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an output or physical connection between the adapter (video card) and a device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DxgiOutputDesc : IEquatable<DxgiOutputDesc>
    {
        /// <summary>
        /// A string that contains the name of the output device.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        private readonly string deviceName;

        /// <summary>
        /// A <see cref="DxgiRect"/> structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch (DPI) of the desktop.
        /// </summary>
        private DxgiRect desktopCoordinates;

        /// <summary>
        /// <value>true</value> if the output is attached to the desktop; otherwise, <value>false</value>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isAttachedToDesktop;

        /// <summary>
        /// A member of the <see cref="DxgiModeRotation"/> enumeration describing on how an image is rotated by the output.
        /// </summary>
        private readonly DxgiModeRotation rotation;

        /// <summary>
        /// An handle that represents the display monitor.
        /// </summary>
        private readonly IntPtr monitor;

        /// <summary>
        /// Gets a string that contains the name of the output device.
        /// </summary>
        public string DeviceName
        {
            get { return this.deviceName; }
        }

        /// <summary>
        /// Gets a <see cref="DxgiRect"/> structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch (DPI) of the desktop.
        /// </summary>
        public DxgiRect DesktopCoordinates
        {
            get { return this.desktopCoordinates; }
        }

        /// <summary>
        /// Gets a value indicating whether the output is attached to the desktop.
        /// </summary>
        public bool IsAttachedToDesktop
        {
            get { return this.isAttachedToDesktop; }
        }

        /// <summary>
        /// Gets a member of the <see cref="DxgiModeRotation"/> enumeration describing on how an image is rotated by the output.
        /// </summary>
        public DxgiModeRotation Rotation
        {
            get { return this.rotation; }
        }

        /// <summary>
        /// Gets an handle that represents the display monitor.
        /// </summary>
        public IntPtr Monitor
        {
            get { return this.monitor; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiOutputDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiOutputDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiOutputDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiOutputDesc left, DxgiOutputDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiOutputDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiOutputDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiOutputDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiOutputDesc left, DxgiOutputDesc right)
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
                "{0} {1} {2} {3}",
                this.deviceName,
                this.isAttachedToDesktop ? "AttachedToDesktop" : "NotAttachedToDesktop",
                this.desktopCoordinates,
                this.rotation);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiOutputDesc))
            {
                return false;
            }

            return this.Equals((DxgiOutputDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiOutputDesc other)
        {
            return this.deviceName == other.deviceName
                && this.desktopCoordinates == other.desktopCoordinates
                && this.isAttachedToDesktop == other.isAttachedToDesktop
                && this.rotation == other.rotation
                && this.monitor == other.monitor;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.deviceName,
                this.desktopCoordinates,
                this.isAttachedToDesktop,
                this.rotation,
                this.monitor
            }
            .GetHashCode();
        }
    }
}
