// <copyright file="DxgiOutput2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIOutput1</c> interface represents an adapter output (such as a monitor).
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiOutput2 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiOutput2Guid = typeof(IDxgiOutput1).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiOutput1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiOutput2"/> class.
    /// </summary>
    public DxgiOutput2(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiOutput1**)comPtr;
    }

    /// <summary>
    /// Gets a description of the output.
    /// </summary>
    public DxgiOutputDesc Description
    {
        get
        {
            int size = DxgiOutputDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiOutputDesc.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the display modes count that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <returns>The count.</returns>
    public int GetDisplayModeListCount(DxgiFormat format, DxgiEnumModes modes)
    {
        uint numModes;
        int hr = _comImpl->GetDisplayModeList1(_comPtr, format, modes, &numModes, null);
        Marshal.ThrowExceptionForHR(hr);
        return (int)numModes;
    }

    /// <summary>
    /// Gets the display modes that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <returns>An array of <see cref="DxgiModeDesc1"/> structure.</returns>
    public DxgiModeDesc1[] GetDisplayModeList(DxgiFormat format, DxgiEnumModes modes)
    {
        uint numModes = (uint)GetDisplayModeListCount(format, modes);
        if (numModes == 0)
        {
            return [];
        }
        int size = DxgiModeDesc1.NativeRequiredSize((int)numModes);
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetDisplayModeList1(_comPtr, format, modes, &numModes, ptr);
        Marshal.ThrowExceptionForHR(hr);
        DxgiModeDesc1[] displayModes = new DxgiModeDesc1[numModes];
        DxgiModeDesc1.NativeReadFrom((nint)ptr, displayModes.AsSpan());
        return displayModes;
    }

    /// <summary>
    /// Gets the display modes that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <param name="displayModes">An span of <see cref="DxgiModeDesc1"/> structure.</param>
    /// <returns>The count of structure.</returns>
    public int GetDisplayModeList(DxgiFormat format, DxgiEnumModes modes, Span<DxgiModeDesc1> displayModes)
    {
        if (displayModes.IsEmpty)
        {
            return 0;
        }
        int size = DxgiModeDesc1.NativeRequiredSize(displayModes.Length);
        byte* ptr = stackalloc byte[size];
        uint numModes = (uint)displayModes.Length;
        int hr = _comImpl->GetDisplayModeList1(_comPtr, format, modes, &numModes, ptr);
        Marshal.ThrowExceptionForHR(hr);
        DxgiModeDesc1.NativeReadFrom((nint)ptr, displayModes[..(int)numModes]);
        displayModes[(int)numModes..].Clear();
        return (int)numModes;
    }

    /// <summary>
    /// Finds the display mode that most closely matches the requested display mode.
    /// </summary>
    /// <param name="modeToMatch">The desired display mode.</param>
    /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
    /// <returns>The mode that most closely matches <c>modeToMatch</c>.</returns>
    public DxgiModeDesc1 FindClosestMatchingMode(in DxgiModeDesc1 modeToMatch, nint concernedDevice)
    {
        int size = DxgiModeDesc1.NativeRequiredSize();
        byte* modeToMatchPtr = stackalloc byte[size];
        DxgiModeDesc1.NativeWriteTo((nint)modeToMatchPtr, modeToMatch);
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->FindClosestMatchingMode1(_comPtr, modeToMatchPtr, ptr, concernedDevice);
        Marshal.ThrowExceptionForHR(hr);
        return DxgiModeDesc1.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Halt a thread until the next vertical blank occurs.
    /// </summary>
    public void WaitForVBlank()
    {
        int hr = _comImpl->WaitForVBlank(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the display surface (front buffer) to a user-provided resource.
    /// </summary>
    /// <param name="destination">A resource interface that represents the resource to which copies the display surface.</param>
    public void GetDisplaySurfaceData(DxgiResource2? destination)
    {
        if (destination == null)
        {
            throw new ArgumentNullException(nameof(destination));
        }

        int hr = _comImpl->GetDisplaySurfaceData1(_comPtr, destination.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Gets statistics about recently rendered frames.
    /// </summary>
    /// <returns>The frame statistics.</returns>
    public DxgiFrameStatistics GetFrameStatistics()
    {
        int size = DxgiFrameStatistics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetFrameStatistics(_comPtr, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return DxgiFrameStatistics.NativeReadFrom((nint)ptr);
    }
}
