// <copyright file="DxgiFactory2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGIFactory2</c> interface includes methods to create a newer version swap chain with more features than <c>IDXGISwapChain</c> and to monitor stereoscopic 3D capabilities.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiFactory2 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiFactory2Guid = typeof(IDxgiFactory2).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiFactory2* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiFactory2"/> class.
    /// </summary>
    public DxgiFactory2(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiFactory2**)comPtr;
    }

    /// <summary>
    /// Gets the window through which the user controls the transition to and from full screen.
    /// </summary>
    public nint WindowAssociation
    {
        get
        {
            nint hwnd;
            int hr = _comImpl->GetWindowAssociation(_comPtr, &hwnd);
            Marshal.ThrowExceptionForHR(hr);
            return hwnd;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the adapter has not changed.
    /// </summary>
    public bool IsCurrent
    {
        get
        {
            return _comImpl->IsCurrent(_comPtr) != 0;
        }
    }

    /// <summary>
    /// Gets a value indicating whether to use stereo mode.
    /// </summary>
    public bool IsWindowedStereoEnabled
    {
        get
        {
            return _comImpl->IsWindowedStereoEnabled(_comPtr) != 0;
        }
    }

    /// <summary>
    /// Creates a DXGI 1.2 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <returns>A <see cref="DxgiFactory2"/> object.</returns>
    public static DxgiFactory2 Create()
    {
        nint ptr;
        int hr = NativeMethods.CreateDxgiFactory1(typeof(IDxgiFactory1).GUID, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiFactory2(DXUtils.QueryInterface(ptr, DxgiFactory2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Get the adapter count (video cards).
    /// </summary>
    /// <returns></returns>
    public int GetAdapterCount()
    {
        uint index = 0;

        while (true)
        {
            nint ptr;
            int hr = _comImpl->EnumAdapters1(_comPtr, index, &ptr);

            if (hr != 0)
            {
                break;
            }

            DXUtils.Release(ptr);
            index++;
        }

        return (int)index;
    }

    /// <summary>
    /// Enumerates the adapters (video cards).
    /// </summary>
    /// <returns>An IEnumerable of <see cref="DxgiAdapter2"/>.</returns>
    public IEnumerable<DxgiAdapter2> EnumAdapters()
    {
        DxgiAdapter2? adapter;
        for (uint i = 0; (adapter = EnumAdapters(i)) is not null; i++)
        {
            yield return adapter;
        }
    }

    /// <summary>
    /// Enumerates the adapters (video cards).
    /// </summary>
    /// <param name="i"></param>
    /// <returns>An adapter or null</returns>
    public DxgiAdapter2? EnumAdapters(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumAdapters1(_comPtr, i, &ptr);

        if (hr != 0)
        {
            return null;
        }

        try
        {
            return new DxgiAdapter2(DXUtils.QueryInterface(ptr, DxgiAdapter2.DxgiAdapter2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Enumerates the adapters (video cards).
    /// </summary>
    /// <param name="i"></param>
    /// <returns>An adapter.</returns>
    public DxgiAdapter2 GetAdapter(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumAdapters1(_comPtr, i, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiAdapter2(DXUtils.QueryInterface(ptr, DxgiAdapter2.DxgiAdapter2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch from windowed to full screen or vice versa).
    /// </summary>
    /// <param name="windowHandle">The handle of the window that is to be monitored. This parameter can be <value>Zero</value>; but only if the flags are also 0.</param>
    /// <param name="options">One or more options.</param>
    public void MakeWindowAssociation(nint windowHandle, DxgiWindowAssociationOptions options)
    {
        int hr = _comImpl->MakeWindowAssociation(_comPtr, windowHandle, options);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public DxgiSwapChain2 CreateSwapChainForWindowHandle(DXComObject device, nint hwnd, in DxgiSwapChainDesc1 desc)
    {
        return CreateSwapChainForWindowHandle(device.Handle, hwnd, desc, null, null);
    }

    /// <summary>
    /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <param name="fullscreenDesc">A <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain.</param>
    /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public DxgiSwapChain2 CreateSwapChainForWindowHandle(DXComObject device, nint hwnd, in DxgiSwapChainDesc1 desc, in DxgiSwapChainFullscreenDesc? fullscreenDesc, DxgiOutput2? restrictToOutput)
    {
        return CreateSwapChainForWindowHandle(device.Handle, hwnd, desc, fullscreenDesc, restrictToOutput);
    }

    /// <summary>
    /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public DxgiSwapChain2 CreateSwapChainForWindowHandle(nint device, nint hwnd, in DxgiSwapChainDesc1 desc)
    {
        return CreateSwapChainForWindowHandle(device, hwnd, desc, null, null);
    }

    /// <summary>
    /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <param name="fullscreenDesc">A <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain.</param>
    /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public DxgiSwapChain2 CreateSwapChainForWindowHandle(nint device, nint hwnd, in DxgiSwapChainDesc1 desc, in DxgiSwapChainFullscreenDesc? fullscreenDesc, DxgiOutput2? restrictToOutput)
    {
        nint ptr;
        int descSize = DxgiSwapChainDesc1.NativeRequiredSize();
        byte* descPtr = stackalloc byte[descSize];
        DxgiSwapChainDesc1.NativeWriteTo((nint)descPtr, desc);
        nint restrictToOutputHandle = restrictToOutput is null ? 0 : restrictToOutput.Handle;

        if (fullscreenDesc is null)
        {
            int hr = _comImpl->CreateSwapChainForWindowHandle(_comPtr, device, hwnd, descPtr, null, restrictToOutputHandle, &ptr);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            int fullscreenDescSize = DxgiSwapChainFullscreenDesc.NativeRequiredSize();
            byte* fullscreenDescPtr = stackalloc byte[fullscreenDescSize];
            DxgiSwapChainFullscreenDesc.NativeWriteTo((nint)fullscreenDescPtr, fullscreenDesc.Value);
            int hr = _comImpl->CreateSwapChainForWindowHandle(_comPtr, device, hwnd, descPtr, fullscreenDescPtr, restrictToOutputHandle, &ptr);
            Marshal.ThrowExceptionForHR(hr);
        }

        return new DxgiSwapChain2(ptr);
    }

    /// <summary>
    /// Create an adapter interface that represents a software adapter.
    /// </summary>
    /// <param name="module">Handle to the software adapter's dll.</param>
    /// <returns>An adapter.</returns>
    public DxgiAdapter2 CreateSoftwareAdapter(nint module)
    {
        nint ptr;
        int hr = _comImpl->CreateSoftwareAdapter(_comPtr, module, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiAdapter2(DXUtils.QueryInterface(ptr, DxgiAdapter2.DxgiAdapter2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }
}
