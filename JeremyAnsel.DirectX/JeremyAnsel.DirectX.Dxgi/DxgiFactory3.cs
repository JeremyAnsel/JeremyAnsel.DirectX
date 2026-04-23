// <copyright file="DxgiFactory3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Enables creating Microsoft DirectX Graphics Infrastructure (DXGI) objects.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiFactory3 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiFactory3Guid = typeof(IDxgiFactory3).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiFactory3* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiFactory3"/> class.
    /// </summary>
    public DxgiFactory3(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiFactory3**)comPtr;
    }

    /// <summary>
    /// Gets the window through which the user controls the transition to and from full screen.
    /// </summary>
    public IntPtr WindowAssociation
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
    /// Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.
    /// </summary>
    public DxgiCreateFactoryOptions CreationOptions
    {
        get
        {
            return _comImpl->GetCreationOptions(_comPtr);
        }
    }

    /// <summary>
    /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <returns>A <see cref="DxgiFactory3"/> object.</returns>
    public static DxgiFactory3 Create()
    {
        return Create(DxgiCreateFactoryOptions.None);
    }

    /// <summary>
    /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <param name="options">The creation options.</param>
    /// <returns>A <see cref="DxgiFactory3"/> object.</returns>
    public static DxgiFactory3 Create(DxgiCreateFactoryOptions options)
    {
        nint ptr;
        int hr = NativeMethods.CreateDxgiFactory2(options, typeof(IDxgiFactory3).GUID, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiFactory3(ptr);
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
    /// <returns>An IEnumerable of <see cref="DxgiAdapter3"/>.</returns>
    public IEnumerable<DxgiAdapter3> EnumAdapters()
    {
        DxgiAdapter3? adapter;
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
    public DxgiAdapter3? EnumAdapters(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumAdapters1(_comPtr, i, &ptr);

        if (hr != 0)
        {
            return null;
        }

        try
        {
            return new DxgiAdapter3(DXUtils.QueryInterface(ptr, DxgiAdapter3.DxgiAdapter3Guid));
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
    public DxgiAdapter3 GetAdapter(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumAdapters1(_comPtr, i, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiAdapter3(DXUtils.QueryInterface(ptr, DxgiAdapter3.DxgiAdapter3Guid));
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
    public void MakeWindowAssociation(IntPtr windowHandle, DxgiWindowAssociationOptions options)
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
    /// <returns>The <c>IDXGISwapChain2</c> interface for the swap chain.</returns>
    public DxgiSwapChain3 CreateSwapChainForWindowHandle(DXComObject device, nint hwnd, in DxgiSwapChainDesc1 desc)
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
    /// <returns>The <c>IDXGISwapChain2</c> interface for the swap chain.</returns>
    public DxgiSwapChain3 CreateSwapChainForWindowHandle(DXComObject device, nint hwnd, in DxgiSwapChainDesc1 desc, in DxgiSwapChainFullscreenDesc? fullscreenDesc, DxgiOutput3? restrictToOutput)
    {
        return CreateSwapChainForWindowHandle(device.Handle, hwnd, desc, fullscreenDesc, restrictToOutput);
    }

    /// <summary>
    /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <returns>The <c>IDXGISwapChain2</c> interface for the swap chain.</returns>
    public DxgiSwapChain3 CreateSwapChainForWindowHandle(nint device, nint hwnd, in DxgiSwapChainDesc1 desc)
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
    /// <returns>The <c>IDXGISwapChain2</c> interface for the swap chain.</returns>
    public DxgiSwapChain3 CreateSwapChainForWindowHandle(nint device, nint hwnd, in DxgiSwapChainDesc1 desc, in DxgiSwapChainFullscreenDesc? fullscreenDesc, DxgiOutput3? restrictToOutput)
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

        try
        {
            return new DxgiSwapChain3(DXUtils.QueryInterface(ptr, DxgiSwapChain3.DxgiSwapChain3Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Create an adapter interface that represents a software adapter.
    /// </summary>
    /// <param name="module">Handle to the software adapter's dll.</param>
    /// <returns>An adapter.</returns>
    public DxgiAdapter3 CreateSoftwareAdapter(nint module)
    {
        nint ptr;
        int hr = _comImpl->CreateSoftwareAdapter(_comPtr, module, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiAdapter3(DXUtils.QueryInterface(ptr, DxgiAdapter3.DxgiAdapter3Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }
}
