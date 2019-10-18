// <copyright file="IDxgiOutput2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Represents an adapter output (such as a monitor). The <c>IDXGIOutput2</c> interface exposes a method to check for multi-plane overlay support on the primary output adapter.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiOutput1"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("595e39d1-2724-4663-99b1-da969de28364")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiOutput2
    {
        /// <summary>
        /// Sets application-defined data to the object and associates that data with a GUID.
        /// </summary>
        /// <param name="name">A GUID that identifies the data.</param>
        /// <param name="dataSize">The size of the object's data.</param>
        /// <param name="data">A pointer to the object's data.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Set an interface in the object's private data.
        /// </summary>
        /// <param name="name">A GUID identifying the interface.</param>
        /// <param name="unknown">The interface to set.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object unknown);

        /// <summary>
        /// Get a pointer to the object's data.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">Pointer to the data.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <param name="riid">The ID of the requested interface.</param>
        /// <returns>The address of a pointer to the parent object.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetParent(
            [In] ref Guid riid);

        /// <summary>
        /// Get a description of the output.
        /// </summary>
        /// <returns>The output description.</returns>
        DxgiOutputDesc GetDesc();

        /// <summary>
        /// Gets the display modes that match the requested format and other input options.
        /// </summary>
        /// <param name="format">The color format.</param>
        /// <param name="modes">Options for modes to include.</param>
        /// <param name="numModes">Set <c>desc</c> to <value>null</value> so that <c>numModes</c> returns the number of display modes that match the format and the options. Otherwise, <c>numModes</c> returns the number of display modes returned in <c>desc</c>.</param>
        /// <param name="desc">A list of display modes. Set to <value>null</value> to get the number of display modes.</param>
        void GetDisplayModeList(
            [In] DxgiFormat format,
            [In] DxgiEnumModes modes,
            [In, Out] ref uint numModes,
            [Out, MarshalAs(UnmanagedType.LPArray)] DxgiModeDesc[] desc);

        /// <summary>
        /// Finds the display mode that most closely matches the requested display mode.
        /// </summary>
        /// <param name="modeToMatch">The desired display mode.</param>
        /// <param name="closestMatch">The mode that most closely matches <c>modeToMatch</c>.</param>
        /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
        void FindClosestMatchingMode(
            [In] ref DxgiModeDesc modeToMatch,
            [Out] out DxgiModeDesc closestMatch,
            [In, MarshalAs(UnmanagedType.IUnknown)] object concernedDevice);

        /// <summary>
        /// Halt a thread until the next vertical blank occurs.
        /// </summary>
        void WaitForVBlank();

        /// <summary>
        /// Takes ownership of an output.
        /// </summary>
        /// <param name="device">The <c>IUnknown</c> interface of a device.</param>
        /// <param name="exclusive">Set to <value>true</value> to enable other threads or applications to take ownership of the device; otherwise, set to <value>false</value>.</param>
        void TakeOwnership(
            [In, MarshalAs(UnmanagedType.IUnknown)] object device,
            [In, MarshalAs(UnmanagedType.Bool)] bool exclusive);

        /// <summary>
        /// Releases ownership of the output.
        /// </summary>
        [PreserveSig]
        void ReleaseOwnership();

        /// <summary>
        /// Gets a description of the gamma-control capabilities.
        /// </summary>
        /// <returns>A description of the gamma-control capabilities.</returns>
        DxgiGammaControlCapabilities GetGammaControlCapabilities();

        /// <summary>
        /// Sets the gamma controls.
        /// </summary>
        /// <param name="gammaControl">A <c>DXGI_GAMMA_CONTROL</c> structure that describes the gamma curve to set.</param>
        void SetGammaControl(
            [In] ref DxgiGammaControl gammaControl);

        /// <summary>
        /// Gets the gamma control settings.
        /// </summary>
        /// <returns>An array of gamma control settings.</returns>
        DxgiGammaControl GetGammaControl();

        /// <summary>
        /// Changes the display mode.
        /// </summary>
        /// <param name="scanoutSurface">A surface used for rendering an image to the screen. The surface must have been created as a back buffer.</param>
        void SetDisplaySurface(
            [In] IDxgiSurface scanoutSurface);

        /// <summary>
        /// Gets a copy of the current display surface.
        /// </summary>
        /// <param name="destination">A destination surface.</param>
        void GetDisplaySurfaceData(
            [In] IDxgiSurface destination);

        /// <summary>
        /// Gets statistics about recently rendered frames.
        /// </summary>
        /// <returns>The frame statistics.</returns>
        DxgiFrameStatistics GetFrameStatistics();

        /// <summary>
        /// Gets the display modes that match the requested format and other input options.
        /// </summary>
        /// <param name="format">The color format.</param>
        /// <param name="modes">Options for modes to include.</param>
        /// <param name="numModes">Set <c>desc</c> to <value>null</value> so that <c>numModes</c> returns the number of display modes that match the format and the options. Otherwise, <c>numModes</c> returns the number of display modes returned in <c>desc</c>.</param>
        /// <param name="desc">A list of display modes. Set to <value>null</value> to get the number of display modes.</param>
        void GetDisplayModeList1(
            [In] DxgiFormat format,
            [In] DxgiEnumModes modes,
            [In, Out] ref uint numModes,
            [Out, MarshalAs(UnmanagedType.LPArray)] DxgiModeDesc1[] desc);

        /// <summary>
        /// Finds the display mode that most closely matches the requested display mode.
        /// </summary>
        /// <param name="modeToMatch">The desired display mode.</param>
        /// <param name="closestMatch">The mode that most closely matches <c>modeToMatch</c>.</param>
        /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
        void FindClosestMatchingMode1(
            [In] ref DxgiModeDesc1 modeToMatch,
            [Out] out DxgiModeDesc1 closestMatch,
            [In, MarshalAs(UnmanagedType.IUnknown)] object concernedDevice);

        /// <summary>
        /// Copies the display surface (front buffer) to a user-provided resource.
        /// </summary>
        /// <param name="destination">A resource interface that represents the resource to which copies the display surface.</param>
        void GetDisplaySurfaceData1(
            [In] IDxgiResource destination);

        /// <summary>
        /// Creates a desktop duplication interface from the <c>IDXGIOutput1</c> interface that represents an adapter output.
        /// </summary>
        /// <param name="device">The Direct3D device interface that you can use to process the desktop image. This device must be created from the adapter to which the output is connected.</param>
        /// <returns>The new <c>IDXGIOutputDuplication</c> interface.</returns>
        IntPtr DuplicateOutput(
            [In, MarshalAs(UnmanagedType.IUnknown)] object device);

        /// <summary>
        /// Queries an adapter output for multi-plane overlay support.
        /// </summary>
        /// <returns><value>true</value> if the output adapter is the primary adapter and it supports multi-plane overlays, otherwise returns <value>false</value>.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SupportsOverlays();
    }
}
