// <copyright file="DxgiSwapChain2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Provides presentation capabilities that are enhanced from <c>IDXGISwapChain1</c>. These presentation capabilities consist of specifying dirty rectangles and scroll rectangle to optimize the presentation.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiSwapChain2 : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiSwapChain2Guid = typeof(IDxgiSwapChain1).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiSwapChain1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSwapChain2"/> class.
    /// </summary>
    public DxgiSwapChain2(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiSwapChain1**)comPtr;
    }

    /// <summary>
    /// Gets a description of the swap chain.
    /// </summary>
    public DxgiSwapChainDesc1 Description
    {
        get
        {
            int size = DxgiSwapChainDesc1.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc1(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiSwapChainDesc1.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets a description of a full-screen swap chain.
    /// </summary>
    public DxgiSwapChainFullscreenDesc FullscreenDescription
    {
        get
        {
            int size = DxgiSwapChainFullscreenDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetFullscreenDesc(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiSwapChainFullscreenDesc.NativeReadFrom((nint)ptr);
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
    /// Gets the underlying <c>HWND</c> for this swap-chain object.
    /// </summary>
    public nint WindowHandle
    {
        get
        {
            nint hwnd;
            int hr = _comImpl->GetWindowHandle(_comPtr, &hwnd);
            Marshal.ThrowExceptionForHR(hr);
            return hwnd;
        }
    }

    /// <summary>
    /// Gets a value indicating whether a swap chain supports “temporary mono.”
    /// </summary>
    public bool IsTemporaryMonoSupported
    {
        get
        {
            return _comImpl->IsTemporaryMonoSupported(_comPtr) != 0;
        }
    }

    /// <summary>
    /// Gets or sets the background color of the swap chain.
    /// </summary>
    public DxgiColorRgba BackgroundColor
    {
        get
        {
            int size = DxgiColorRgba.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetBackgroundColor(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiColorRgba.NativeReadFrom((nint)ptr);
        }

        set
        {
            int size = DxgiColorRgba.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            DxgiColorRgba.NativeWriteTo((nint)ptr, value);
            int hr = _comImpl->SetBackgroundColor(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Gets or sets the rotation of the back buffers for the swap chain.
    /// </summary>
    public DxgiModeRotation Rotation
    {
        get
        {
            DxgiModeRotation value;
            int hr = _comImpl->GetRotation(_comPtr, &value);
            Marshal.ThrowExceptionForHR(hr);
            return value;
        }

        set
        {
            int hr = _comImpl->SetRotation(_comPtr, value);
            Marshal.ThrowExceptionForHR(hr);
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
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    public void Present(uint syncInterval)
    {
        Present(syncInterval, DxgiPresentOptions.None);
    }

    /// <summary>
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">An integer value that contains swap-chain presentation options.</param>
    public void Present(uint syncInterval, DxgiPresentOptions options)
    {
        DxgiPresentParameters parameters = default;
        int size = DxgiPresentParameters.NativeRequiredSize();
        byte* parametersPtr = stackalloc byte[size];
        DxgiPresentParameters.NativeWriteTo((nint)parametersPtr, parameters);
        int hr = _comImpl->Present1(_comPtr, syncInterval, options, parametersPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">An integer value that contains swap-chain presentation options.</param>
    /// <param name="parameters">A structure that describes updated rectangles and scroll information of the frame to present.</param>
    public void Present(uint syncInterval, DxgiPresentOptions options, in DxgiPresentParameters parameters)
    {
        int size = DxgiPresentParameters.NativeRequiredSize();
        byte* parametersPtr = stackalloc byte[size];
        DxgiPresentParameters.NativeWriteTo((nint)parametersPtr, parameters);
        int hr = _comImpl->Present1(_comPtr, syncInterval, options, parametersPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">An integer value that contains swap-chain presentation options.</param>
    /// <param name="dirtyRect">An updated rectangle that you update in the back buffer for the presented frame.</param>
    /// <param name="scrollRect">The rectangle of the previous frame from which the runtime bit-block transfers content.</param>
    /// <param name="scrollOffset">The offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).</param>
    public void Present(uint syncInterval, DxgiPresentOptions options, in DxgiRect dirtyRect, in DxgiRect? scrollRect, in DxgiPoint? scrollOffset)
    {
        fixed (void* dirtyRectPtr = &dirtyRect)
        {
            var dirtyRectSpan = new ReadOnlySpan<DxgiRect>(dirtyRectPtr, 1);
            Present(syncInterval, options, dirtyRectSpan, scrollRect, scrollOffset);
        }
    }

    /// <summary>
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">An integer value that contains swap-chain presentation options.</param>
    /// <param name="dirtyRects">A list of updated rectangles that you update in the back buffer for the presented frame.</param>
    /// <param name="scrollRect">The rectangle of the previous frame from which the runtime bit-block transfers content.</param>
    /// <param name="scrollOffset">The offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).</param>
    public void Present(uint syncInterval, DxgiPresentOptions options, DxgiRect[]? dirtyRects, in DxgiRect? scrollRect, in DxgiPoint? scrollOffset)
    {
        Present(syncInterval, options, dirtyRects.AsSpan(), scrollRect, scrollOffset);
    }

    /// <summary>
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">An integer value that contains swap-chain presentation options.</param>
    /// <param name="dirtyRects">A list of updated rectangles that you update in the back buffer for the presented frame.</param>
    /// <param name="scrollRect">The rectangle of the previous frame from which the runtime bit-block transfers content.</param>
    /// <param name="scrollOffset">The offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).</param>
    public void Present(uint syncInterval, DxgiPresentOptions options, ReadOnlySpan<DxgiRect> dirtyRects, in DxgiRect? scrollRect, in DxgiPoint? scrollOffset)
    {
        DxgiPresentParameters parameters = default;

        parameters.DirtyRectsCount = (uint)dirtyRects.Length;
        int dirtyRectsSize = dirtyRects.Length == 0 ? 0 : DxgiRect.NativeRequiredSize(dirtyRects.Length);
        byte* dirtyRectsPtr = stackalloc byte[dirtyRectsSize];
        if (dirtyRects.Length != 0)
        {
            DxgiRect.NativeWriteTo((nint)dirtyRectsPtr, dirtyRects);
        }
        parameters.DirtyRects = (nint)dirtyRectsPtr;

        int scrollRectSize = scrollRect is null ? 0 : DxgiRect.NativeRequiredSize();
        byte* scrollRectPtr = stackalloc byte[scrollRectSize];
        if (scrollRect is not null)
        {
            DxgiRect.NativeWriteTo((nint)scrollRectPtr, scrollRect.Value);
        }
        parameters.ScrollRect = (nint)scrollRectPtr;

        int scrollOffsetSize = scrollOffset is null ? 0 : DxgiPoint.NativeRequiredSize();
        byte* scrollOffsetPtr = stackalloc byte[scrollOffsetSize];
        if (scrollOffset is not null)
        {
            DxgiPoint.NativeWriteTo((nint)scrollOffsetPtr, scrollOffset.Value);
        }
        parameters.ScrollOffset = (nint)scrollOffsetPtr;

        int size = DxgiPresentParameters.NativeRequiredSize();
        byte* parametersPtr = stackalloc byte[size];
        DxgiPresentParameters.NativeWriteTo((nint)parametersPtr, parameters);
        int hr = _comImpl->Present1(_comPtr, syncInterval, options, parametersPtr);
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
    public DxgiSurface2 GetSurface(uint buffer)
    {
        nint ptr = GetBuffer(buffer, DxgiSurface2.DxgiSurface2Guid);
        return new DxgiSurface2(ptr);
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
    /// <param name="target">A pointer to an <c>DXGIOutput2</c> interface for the output target that contains the swap chain.</param>
    public void SetFullscreenState(bool fullscreen, DxgiOutput2? target)
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
    public bool GetFullscreenState(out DxgiOutput2? target)
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
                target = new DxgiOutput2(DXUtils.QueryInterface(ptr, DxgiOutput2.DxgiOutput2Guid));
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
    public DxgiOutput2 GetContainingOutput()
    {
        nint ptr;
        int hr = _comImpl->GetContainingOutput(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiOutput2(DXUtils.QueryInterface(ptr, DxgiOutput2.DxgiOutput2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Gets the output (the display monitor) to which you can restrict the contents of a present operation.
    /// </summary>
    /// <returns>The <c>DXGIOutput2</c> interface for the restrict-to output.</returns>
    public DxgiOutput2 GetRestrictToOutput()
    {
        nint ptr;
        int hr = _comImpl->GetRestrictToOutput(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiOutput2(ptr);
    }
}
