// <copyright file="IDxgiOutput1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// An <c>IDXGIOutput1</c> interface represents an adapter output (such as a monitor).
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiOutput"/></remarks>
[Guid("00cddea8-939b-4b83-a340-a685226666cc")]
internal unsafe readonly struct IDxgiOutput1
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;

    /// <summary>
    /// Get a description of the output.
    /// </summary>
    /// <returns>The output description.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc;

    /// <summary>
    /// Gets the display modes that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <param name="numModes">Set <c>desc</c> to <value>null</value> so that <c>numModes</c> returns the number of display modes that match the format and the options. Otherwise, <c>numModes</c> returns the number of display modes returned in <c>desc</c>.</param>
    /// <param name="desc">A list of display modes. Set to <value>null</value> to get the number of display modes.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiFormat, DxgiEnumModes, uint*, void*, int> GetDisplayModeList;

    /// <summary>
    /// Finds the display mode that most closely matches the requested display mode.
    /// </summary>
    /// <param name="modeToMatch">The desired display mode.</param>
    /// <param name="closestMatch">The mode that most closely matches <c>modeToMatch</c>.</param>
    /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, nint, int> FindClosestMatchingMode;

    /// <summary>
    /// Halt a thread until the next vertical blank occurs.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, int> WaitForVBlank;

    /// <summary>
    /// Takes ownership of an output.
    /// </summary>
    /// <param name="device">The <c>IUnknown</c> interface of a device.</param>
    /// <param name="exclusive">Set to <value>true</value> to enable other threads or applications to take ownership of the device; otherwise, set to <value>false</value>.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, int> TakeOwnership;

    /// <summary>
    /// Releases ownership of the output.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> ReleaseOwnership;

    /// <summary>
    /// Gets a description of the gamma-control capabilities.
    /// </summary>
    /// <returns>A description of the gamma-control capabilities.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetGammaControlCapabilities;

    /// <summary>
    /// Sets the gamma controls.
    /// </summary>
    /// <param name="gammaControl">A <c>DXGI_GAMMA_CONTROL</c> structure that describes the gamma curve to set.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> SetGammaControl;

    /// <summary>
    /// Gets the gamma control settings.
    /// </summary>
    /// <returns>An array of gamma control settings.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetGammaControl;

    /// <summary>
    /// Changes the display mode.
    /// </summary>
    /// <param name="scanoutSurface">A surface used for rendering an image to the screen. The surface must have been created as a back buffer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetDisplaySurface;

    /// <summary>
    /// Gets a copy of the current display surface.
    /// </summary>
    /// <param name="destination">A destination surface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> GetDisplaySurfaceData;

    /// <summary>
    /// Gets statistics about recently rendered frames.
    /// </summary>
    /// <returns>The frame statistics.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetFrameStatistics;

    /// <summary>
    /// Gets the display modes that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <param name="numModes">Set <c>desc</c> to <value>null</value> so that <c>numModes</c> returns the number of display modes that match the format and the options. Otherwise, <c>numModes</c> returns the number of display modes returned in <c>desc</c>.</param>
    /// <param name="desc">A list of display modes. Set to <value>null</value> to get the number of display modes.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiFormat, DxgiEnumModes, uint*, void*, int> GetDisplayModeList1;

    /// <summary>
    /// Finds the display mode that most closely matches the requested display mode.
    /// </summary>
    /// <param name="modeToMatch">The desired display mode.</param>
    /// <param name="closestMatch">The mode that most closely matches <c>modeToMatch</c>.</param>
    /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, nint, int> FindClosestMatchingMode1;

    /// <summary>
    /// Copies the display surface (front buffer) to a user-provided resource.
    /// </summary>
    /// <param name="destination">A resource interface that represents the resource to which copies the display surface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> GetDisplaySurfaceData1;

    /// <summary>
    /// Creates a desktop duplication interface from the <c>IDXGIOutput1</c> interface that represents an adapter output.
    /// </summary>
    /// <param name="device">The Direct3D device interface that you can use to process the desktop image. This device must be created from the adapter to which the output is connected.</param>
    /// <returns>The new <c>IDXGIOutputDuplication</c> interface.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, int> DuplicateOutput;
}
