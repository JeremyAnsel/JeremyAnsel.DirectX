// <copyright file="DxgiOutput1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIOutput</c> interface represents an adapter output (such as a monitor).
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiOutput1 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiOutput1Guid = typeof(IDxgiOutput).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiOutput* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiOutput1"/> class.
    /// </summary>
    public DxgiOutput1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiOutput**)comPtr;
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
        int hr = _comImpl->GetDisplayModeList(_comPtr, format, modes, &numModes, null);
        Marshal.ThrowExceptionForHR(hr);
        return (int)numModes;
    }

    /// <summary>
    /// Gets the display modes that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <returns>An array of <see cref="DxgiModeDesc"/> structure.</returns>
    public DxgiModeDesc[] GetDisplayModeList(DxgiFormat format, DxgiEnumModes modes)
    {
        uint numModes = (uint)GetDisplayModeListCount(format, modes);
        if (numModes == 0)
        {
            return [];
        }
        int size = DxgiModeDesc.NativeRequiredSize((int)numModes);
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetDisplayModeList(_comPtr, format, modes, &numModes, ptr);
        Marshal.ThrowExceptionForHR(hr);
        DxgiModeDesc[] displayModes = new DxgiModeDesc[numModes];
        DxgiModeDesc.NativeReadFrom((nint)ptr, displayModes.AsSpan());
        return displayModes;
    }

    /// <summary>
    /// Gets the display modes that match the requested format and other input options.
    /// </summary>
    /// <param name="format">The color format.</param>
    /// <param name="modes">Options for modes to include.</param>
    /// <param name="displayModes">An span of <see cref="DxgiModeDesc"/> structure.</param>
    /// <returns>The count of structure.</returns>
    public int GetDisplayModeList(DxgiFormat format, DxgiEnumModes modes, Span<DxgiModeDesc> displayModes)
    {
        if (displayModes.IsEmpty)
        {
            return 0;
        }
        int size = DxgiModeDesc.NativeRequiredSize(displayModes.Length);
        byte* ptr = stackalloc byte[size];
        uint numModes = (uint)displayModes.Length;
        int hr = _comImpl->GetDisplayModeList(_comPtr, format, modes, &numModes, ptr);
        Marshal.ThrowExceptionForHR(hr);
        DxgiModeDesc.NativeReadFrom((nint)ptr, displayModes[..(int)numModes]);
        displayModes[(int)numModes..].Clear();
        return (int)numModes;
    }

    /// <summary>
    /// Finds the display mode that most closely matches the requested display mode.
    /// </summary>
    /// <param name="modeToMatch">The desired display mode.</param>
    /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
    /// <returns>The mode that most closely matches <c>modeToMatch</c>.</returns>
    public DxgiModeDesc FindClosestMatchingMode(in DxgiModeDesc modeToMatch, nint concernedDevice)
    {
        int size = DxgiModeDesc.NativeRequiredSize();
        byte* modeToMatchPtr = stackalloc byte[size];
        DxgiModeDesc.NativeWriteTo((nint)modeToMatchPtr, modeToMatch);
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->FindClosestMatchingMode(_comPtr, modeToMatchPtr, ptr, concernedDevice);
        Marshal.ThrowExceptionForHR(hr);
        return DxgiModeDesc.NativeReadFrom((nint)ptr);
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
    /// Gets a copy of the current display surface.
    /// </summary>
    /// <param name="destination">A destination surface.</param>
    public void GetDisplaySurfaceData(DxgiSurface1? destination)
    {
        if (destination is null)
        {
            throw new ArgumentNullException(nameof(destination));
        }

        int hr = _comImpl->GetDisplaySurfaceData(_comPtr, destination.Handle);
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
