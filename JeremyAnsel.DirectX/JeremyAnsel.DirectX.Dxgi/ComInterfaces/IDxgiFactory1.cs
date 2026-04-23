// <copyright file="IDxgiFactory1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGIFactory1</c> interface implements methods for generating DXGI objects.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiFactory"/></remarks>
[Guid("770aae78-f26f-4dba-a829-253c83d1b387")]
internal unsafe readonly struct IDxgiFactory1
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;

    /// <summary>
    /// Enumerates the adapters (video cards).
    /// </summary>
    /// <param name="index">The index of the adapter to enumerate.</param>
    /// <param name="adapter">The address of a pointer to an <c>IDXGIAdapter</c> interface at the position specified by the index parameter.</param>
    /// <returns><value>S_OK</value> if successful; otherwise, returns <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than or equal to the number of adapters in the local system.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> EnumAdapters;

    /// <summary>
    /// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch from windowed to full screen or vice versa).
    /// </summary>
    /// <param name="windowHandle">The handle of the window that is to be monitored. This parameter can be <value>Zero</value>; but only if the flags are also 0.</param>
    /// <param name="options">One or more options.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, DxgiWindowAssociationOptions, int> MakeWindowAssociation;

    /// <summary>
    /// Get the window through which the user controls the transition to and from full screen.
    /// </summary>
    /// <returns>A window handle.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetWindowAssociation;

    /// <summary>
    /// Creates a swap chain.
    /// </summary>
    /// <param name="device">A Direct3D device that will write 2D images to the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC</c> structure for the swap-chain description.</param>
    /// <returns>An <c>IDXGISwapChain</c> interface for the swap chain</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint*, int> CreateSwapChain;

    /// <summary>
    /// Create an adapter interface that represents a software adapter.
    /// </summary>
    /// <param name="module">Handle to the software adapter's dll.</param>
    /// <returns>An adapter.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, int> CreateSoftwareAdapter;

    /// <summary>
    /// Enumerates both adapters (video cards) with or without outputs.
    /// </summary>
    /// <param name="index">The index of the adapter to enumerate.</param>
    /// <param name="adapter">The address of a pointer to an <c>IDXGIAdapter1</c> interface at the position specified by the index parameter.</param>
    /// <returns><value>S_OK</value> if successful; otherwise, returns <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than or equal to the number of adapters in the local system.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> EnumAdapters1;

    /// <summary>
    /// Informs an application of the possible need to re-enumerate adapters.
    /// </summary>
    /// <returns><value>false</value>, if a new adapter is becoming available or the current adapter is going away. <value>true</value>, no adapter changes.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int> IsCurrent;
}
