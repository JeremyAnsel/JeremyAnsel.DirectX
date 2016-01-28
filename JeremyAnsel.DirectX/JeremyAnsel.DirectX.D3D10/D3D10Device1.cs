// <copyright file="D3D10Device1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D3D10.ComInterfaces;

    /// <summary>
    /// The device interface represents a virtual adapter for Direct3D 10.1; it is used to perform rendering and create Direct3D resources.
    /// </summary>
    public sealed class D3D10Device1 : IDisposable, ID3D10Releasable
    {
        /// <summary>
        /// The D3D10 device interface.
        /// </summary>
        private ID3D10Device1 device;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D10Device1"/> class.
        /// </summary>
        /// <param name="device">A D3D10 device interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D10Device1(ID3D10Device1 device)
        {
            this.device = device;
        }

        /// <summary>
        /// Gets an handle representing the D3D10 object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device; }
        }

        /// <summary>
        /// Gets the options used during the call to create the device.
        /// </summary>
        public D3D10CreateDeviceOptions CreationOptions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device.GetCreationFlags(); }
        }

        /// <summary>
        /// Gets the feature level of the hardware device.
        /// </summary>
        public D3D10FeatureLevel FeatureLevel
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device.GetFeatureLevel(); }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D3D10 device.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D3D10Device1 value)
        {
            return value != null && value.Handle != null;
        }

        /// <summary>
        /// Create a Direct3D 10.1 device that represents the display adapter.
        /// </summary>
        /// <param name="adapter">Pointer to the display adapter when creating a hardware device; otherwise set this parameter to NULL.</param>
        /// <param name="driverType">The device-driver type.</param>
        /// <param name="options">Device creation options.</param>
        /// <param name="featureLevel">The version of hardware that is available for acceleration.</param>
        /// <returns><see cref="D3D10Device1"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D3D10Device1 CreateDevice(
            object adapter,
            D3D10DriverType driverType,
            D3D10CreateDeviceOptions options,
            D3D10FeatureLevel featureLevel)
        {
            ID3D10Device1 device;
            NativeMethods.D3D10CreateDevice1(adapter, driverType, IntPtr.Zero, options, featureLevel, 0x20, out device);
            return new D3D10Device1(device);
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.Handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the D3D10 object.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM the interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Gets the reason why the device was removed.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetDeviceRemovedReason()
        {
            return this.device.GetDeviceRemovedReason();
        }

        /// <summary>
        /// Give a device access to a shared resource created on a different Direct3d device.
        /// </summary>
        /// <param name="resourceHandle">A resource handle.</param>
        /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
        /// <returns>The resource we are gaining access to.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object OpenSharedResource(IntPtr resourceHandle, Guid returnedInterface)
        {
            return this.device.OpenSharedResource(resourceHandle, ref returnedInterface);
        }
    }
}
