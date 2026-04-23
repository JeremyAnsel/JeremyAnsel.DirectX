// <copyright file="DxgiSwapChain1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGISwapChain</c> interface implements one or more surfaces for storing rendered data before presenting it to an output.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiSwapChain1 : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiSwapChain1Guid = typeof(IDxgiSwapChain).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiSwapChain* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSwapChain1"/> class.
    /// </summary>
    public DxgiSwapChain1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiSwapChain**)comPtr;
    }

    /// <summary>
    /// Gets a description of the swap chain.
    /// </summary>
    public DxgiSwapChainDesc Description
    {
        get
        {
            int size = DxgiSwapChainDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiSwapChainDesc.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets performance statistics about the last render frame.
    /// </summary>
    public DxgiFrameStatistics FrameStatistics
    {
        get
        {
            int size = DxgiFrameStatistics.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetFrameStatistics(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiFrameStatistics.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the number of times that <c>IDXGISwapChain::Present</c> or <c>IDXGISwapChain1::Present1</c> has been called.
    /// </summary>
    public uint LastPresentCount
    {
        get
        {
            uint value;
            int hr = _comImpl->GetLastPresentCount(_comPtr, &value);
            Marshal.ThrowExceptionForHR(hr);
            return value;
        }
    }

    /// <summary>
    /// Presents a rendered image to the user.
    /// </summary>
    public void Present()
    {
        Present(1, DxgiPresentOptions.None);
    }

    /// <summary>
    /// Presents a rendered image to the user.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    public void Present(uint syncInterval)
    {
        Present(syncInterval, DxgiPresentOptions.None);
    }

    /// <summary>
    /// Presents a rendered image to the user.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">The swap-chain presentation options.</param>
    public void Present(uint syncInterval, DxgiPresentOptions options)
    {
        int hr = _comImpl->Present(_comPtr, syncInterval, options);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Accesses one of the swap-chain's back buffers.
    /// </summary>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <param name="riid">The type of interface used to manipulate the buffer.</param>
    /// <returns>A pointer to a back-buffer interface.</returns>
    public nint GetBuffer(uint buffer, in Guid riid)
    {
        nint ptr;
        int hr = _comImpl->GetBuffer(_comPtr, buffer, riid, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }

    /// <summary>
    /// Accesses one of the swap-chain's back buffers.
    /// </summary>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <returns>A back-buffer surface.</returns>
    public DxgiSurface1 GetSurface(uint buffer)
    {
        nint ptr = GetBuffer(buffer, DxgiSurface1.DxgiSurface1Guid);
        return new DxgiSurface1(ptr);
    }

    /// <summary>
    /// Sets the display state to windowed or full screen.
    /// </summary>
    /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
    public void SetFullscreenState(bool fullscreen)
    {
        int hr = _comImpl->SetFullscreenState(_comPtr, fullscreen ? 1 : 0, 0);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Sets the display state to windowed or full screen.
    /// </summary>
    /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
    /// <param name="target">A pointer to an <c>DXGIOutput1</c> interface for the output target that contains the swap chain.</param>
    public void SetFullscreenState(bool fullscreen, DxgiOutput1? target)
    {
        int hr = _comImpl->SetFullscreenState(_comPtr, fullscreen ? 1 : 0, target is null ? 0 : target.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get the state associated with full-screen mode.
    /// </summary>
    /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
    public bool GetFullscreenState()
    {
        int fullscreen;
        nint ptr;
        int hr = _comImpl->GetFullscreenState(_comPtr, &fullscreen, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        if (ptr != 0)
        {
            DXUtils.Release(ptr);
        }
        return fullscreen != 0;
    }

    /// <summary>
    /// Get the state associated with full-screen mode.
    /// </summary>
    /// <param name="target">The output target when the mode is full screen.</param>
    /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
    public bool GetFullscreenState(out DxgiOutput1? target)
    {
        int fullscreen;
        nint ptr;
        int hr = _comImpl->GetFullscreenState(_comPtr, &fullscreen, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        if (ptr == 0)
        {
            target = null;
        }
        else
        {
            try
            {
                target = new DxgiOutput1(DXUtils.QueryInterface(ptr, DxgiOutput1.DxgiOutput1Guid));
            }
            finally
            {
                DXUtils.Release(ptr);
            }
        }

        return fullscreen != 0;
    }

    /// <summary>
    /// Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.
    /// </summary>
    /// <param name="bufferCount">The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of buffers with which you created the swap chain.</param>
    public void ResizeBuffers(uint bufferCount)
    {
        ResizeBuffers(bufferCount, 0, 0, DxgiFormat.Unknown, DxgiSwapChainOptions.None);
    }

    /// <summary>
    /// Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.
    /// </summary>
    /// <param name="bufferCount">The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of buffers with which you created the swap chain.</param>
    /// <param name="width">New width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window.</param>
    /// <param name="height">New height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window.</param>
    /// <param name="format">A <c>DXGI_FORMAT</c>-typed value for the new format of the back buffer. Set this value to <value>DXGI_FORMAT_UNKNOWN</value> to preserve the existing format of the back buffer.</param>
    /// <param name="options">The options for swap-chain behavior.</param>
    public void ResizeBuffers(uint bufferCount, uint width, uint height, DxgiFormat format, DxgiSwapChainOptions options)
    {
        int hr = _comImpl->ResizeBuffers(_comPtr, bufferCount, width, height, format, options);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Resizes the output target.
    /// </summary>
    /// <param name="targetParameters">A <c>DXGI_MODE_DESC</c> structure that describes the mode, which specifies the new width, height, format, and refresh rate of the target. If the format is <value>DXGI_FORMAT_UNKNOWN</value>, ResizeTarget uses the existing format.</param>
    public void ResizeTarget(in DxgiModeDesc targetParameters)
    {
        int size = DxgiModeDesc.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        DxgiModeDesc.NativeWriteTo((nint)ptr, targetParameters);
        int hr = _comImpl->ResizeTarget(_comPtr, ptr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get the output (the display monitor) that contains the majority of the client area of the target window.
    /// </summary>
    /// <returns>The output interface.</returns>
    public DxgiOutput1 GetContainingOutput()
    {
        nint ptr;
        int hr = _comImpl->GetContainingOutput(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiOutput1(DXUtils.QueryInterface(ptr, DxgiOutput1.DxgiOutput1Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }
}
