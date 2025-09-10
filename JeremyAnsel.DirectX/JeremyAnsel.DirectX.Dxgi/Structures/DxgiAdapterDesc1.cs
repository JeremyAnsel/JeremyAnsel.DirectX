// <copyright file="DxgiAdapterDesc1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an adapter (or video card) using DXGI 1.1.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DxgiAdapterDesc1 : IEquatable<DxgiAdapterDesc1>
    {
        /// <summary>
        /// A string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private readonly string adapterDescription;

        /// <summary>
        /// The PCI ID of the hardware vendor. On feature level 9 graphics hardware, 0.
        /// </summary>
        private readonly uint vendorId;

        /// <summary>
        /// The PCI ID of the hardware device. On feature level 9 graphics hardware, 0.
        /// </summary>
        private readonly uint deviceId;

        /// <summary>
        /// The PCI ID of the sub system. On feature level 9 graphics hardware, 0.
        /// </summary>
        private readonly uint subSysId;

        /// <summary>
        /// The PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, 0.
        /// </summary>
        private readonly uint revision;

        /// <summary>
        /// The number of bytes of dedicated video memory that are not shared with the CPU.
        /// </summary>
        private readonly UIntPtr dedicatedVideoMemory;

        /// <summary>
        /// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system memory at boot time.
        /// </summary>
        private readonly UIntPtr dedicatedSystemMemory;

        /// <summary>
        /// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
        /// </summary>
        private readonly UIntPtr sharedSystemMemory;

        /// <summary>
        /// A unique value that identifies the adapter.
        /// </summary>
        private readonly ulong adapterLuid;

        /// <summary>
        /// A value of the <see cref="DxgiAdapterType"/> enumeration that describes the adapter type.
        /// </summary>
        private readonly DxgiAdapterType adapterType;

        /// <summary>
        /// Gets a string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
        /// </summary>
        public string AdapterDescription
        {
            get { return this.adapterDescription; }
        }

        /// <summary>
        /// Gets the PCI ID of the hardware vendor. On feature level 9 graphics hardware, 0.
        /// </summary>
        public uint VendorId
        {
            get { return this.vendorId; }
        }

        /// <summary>
        /// Gets the PCI ID of the hardware device. On feature level 9 graphics hardware, 0.
        /// </summary>
        public uint DeviceId
        {
            get { return this.deviceId; }
        }

        /// <summary>
        /// Gets the PCI ID of the sub system. On feature level 9 graphics hardware, 0.
        /// </summary>
        public uint SubSysId
        {
            get { return this.subSysId; }
        }

        /// <summary>
        /// Gets the PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, 0.
        /// </summary>
        public uint Revision
        {
            get { return this.revision; }
        }

        /// <summary>
        /// Gets the number of bytes of dedicated video memory that are not shared with the CPU.
        /// </summary>
        public ulong DedicatedVideoMemory
        {
            get { return this.dedicatedVideoMemory.ToUInt64(); }
        }

        /// <summary>
        /// Gets the number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system memory at boot time.
        /// </summary>
        public ulong DedicatedSystemMemory
        {
            get { return this.dedicatedSystemMemory.ToUInt64(); }
        }

        /// <summary>
        /// Gets the number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
        /// </summary>
        public ulong SharedSystemMemory
        {
            get { return this.sharedSystemMemory.ToUInt64(); }
        }

        /// <summary>
        /// Gets a unique value that identifies the adapter.
        /// </summary>
        public ulong AdapterLuid
        {
            get { return this.adapterLuid; }
        }

        /// <summary>
        /// Gets a value of the <see cref="DxgiAdapterType"/> enumeration that describes the adapter type.
        /// </summary>
        public DxgiAdapterType AdapterType
        {
            get { return this.adapterType; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiAdapterDesc1"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiAdapterDesc1"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiAdapterDesc1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiAdapterDesc1 left, DxgiAdapterDesc1 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiAdapterDesc1"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiAdapterDesc1"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiAdapterDesc1"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiAdapterDesc1 left, DxgiAdapterDesc1 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.adapterDescription;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DxgiAdapterDesc1)
            {
                return false;
            }

            return this.Equals((DxgiAdapterDesc1)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiAdapterDesc1 other)
        {
            return this.adapterDescription == other.adapterDescription
                && this.vendorId == other.vendorId
                && this.deviceId == other.deviceId
                && this.subSysId == other.subSysId
                && this.revision == other.revision
                && this.dedicatedVideoMemory == other.dedicatedVideoMemory
                && this.dedicatedSystemMemory == other.dedicatedSystemMemory
                && this.sharedSystemMemory == other.sharedSystemMemory
                && this.adapterLuid == other.adapterLuid
                && this.adapterType == other.adapterType;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.adapterDescription,
                this.vendorId,
                this.deviceId,
                this.subSysId,
                this.revision,
                this.dedicatedVideoMemory,
                this.dedicatedSystemMemory,
                this.sharedSystemMemory,
                this.adapterLuid,
                this.adapterType
            }
            .GetHashCode();
        }
    }
}
