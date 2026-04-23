// <copyright file="DxgiFactory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIFactory</c> interface implements methods for generating DXGI objects (which handle full screen transitions).
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiFactory : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiFactoryGuid = typeof(IDxgiFactory).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiFactory* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiFactory"/> class.
    /// </summary>
    public DxgiFactory(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiFactory**)comPtr;
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
    /// Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <returns>A <see cref="DxgiFactory"/> object.</returns>
    public static DxgiFactory Create()
    {
        nint ptr;
        int hr = NativeMethods.CreateDxgiFactory(typeof(IDxgiFactory).GUID, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiFactory(ptr);
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
            int hr = _comImpl->EnumAdapters(_comPtr, index, &ptr);

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
    /// <returns>An IEnumerable of <see cref="DxgiAdapter"/>.</returns>
    public IEnumerable<DxgiAdapter> EnumAdapters()
    {
        DxgiAdapter? adapter;
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
    public DxgiAdapter? EnumAdapters(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumAdapters(_comPtr, i, &ptr);
        return hr != 0 ? null : new DxgiAdapter(ptr);
    }

    /// <summary>
    /// Enumerates the adapters (video cards).
    /// </summary>
    /// <param name="i"></param>
    /// <returns>An adapter</returns>
    public DxgiAdapter GetAdapter(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumAdapters(_comPtr, i, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiAdapter(ptr);
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
    /// Creates a swap chain.
    /// </summary>
    /// <param name="device">A Direct3D device that will write 2D images to the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC</c> structure for the swap-chain description.</param>
    /// <returns>An <c>IDXGISwapChain</c> interface for the swap chain</returns>
    public DxgiSwapChain CreateSwapChain(DXComObject device, in DxgiSwapChainDesc desc)
    {
        return CreateSwapChain(device.Handle, desc);
    }

    /// <summary>
    /// Creates a swap chain.
    /// </summary>
    /// <param name="device">A Direct3D device that will write 2D images to the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC</c> structure for the swap-chain description.</param>
    /// <returns>An <c>IDXGISwapChain</c> interface for the swap chain</returns>
    public DxgiSwapChain CreateSwapChain(nint device, in DxgiSwapChainDesc desc)
    {
        int size = DxgiSwapChainDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        DxgiSwapChainDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateSwapChain(_comPtr, device, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiSwapChain(ptr);
    }

    /// <summary>
    /// Create an adapter interface that represents a software adapter.
    /// </summary>
    /// <param name="module">Handle to the software adapter's dll.</param>
    /// <returns>An adapter.</returns>
    public DxgiAdapter CreateSoftwareAdapter(nint module)
    {
        nint ptr;
        int hr = _comImpl->CreateSoftwareAdapter(_comPtr, module, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiAdapter(ptr);
    }
}
