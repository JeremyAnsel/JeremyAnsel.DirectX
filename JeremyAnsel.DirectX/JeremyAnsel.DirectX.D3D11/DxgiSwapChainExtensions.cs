// <copyright file="DxgiSwapChainExtensions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Swap chain extensions.
/// </summary>
[SkipLocalsInit]
public static class DxgiSwapChainExtensions
{
    /// <summary>
    /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
    /// </summary>
    /// <param name="swapChain">The swap chain.</param>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <returns>A 2D texture.</returns>
    public static D3D11Texture2D GetTexture2D(this DxgiSwapChain? swapChain, uint buffer)
    {
        if (swapChain is null)
        {
            throw new ArgumentNullException(nameof(swapChain));
        }

        nint texture = swapChain.GetBuffer(buffer, D3D11Texture2D.D3D11Texture2DGuid);
        return new D3D11Texture2D(texture);
    }

    /// <summary>
    /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
    /// </summary>
    /// <param name="swapChain">The swap chain.</param>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <returns>A 2D texture.</returns>
    public static D3D11Texture2D GetTexture2D(this DxgiSwapChain1? swapChain, uint buffer)
    {
        if (swapChain is null)
        {
            throw new ArgumentNullException(nameof(swapChain));
        }

        nint texture = swapChain.GetBuffer(buffer, D3D11Texture2D.D3D11Texture2DGuid);
        return new D3D11Texture2D(texture);
    }

    /// <summary>
    /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
    /// </summary>
    /// <param name="swapChain">The swap chain.</param>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <returns>A 2D texture.</returns>
    public static D3D11Texture2D GetTexture2D(this DxgiSwapChain2? swapChain, uint buffer)
    {
        if (swapChain is null)
        {
            throw new ArgumentNullException(nameof(swapChain));
        }

        nint texture = swapChain.GetBuffer(buffer, D3D11Texture2D.D3D11Texture2DGuid);
        return new D3D11Texture2D(texture);
    }

    /// <summary>
    /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
    /// </summary>
    /// <param name="swapChain">The swap chain.</param>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <returns>A 2D texture.</returns>
    public static D3D11Texture2D GetTexture2D(this DxgiSwapChain3? swapChain, uint buffer)
    {
        if (swapChain is null)
        {
            throw new ArgumentNullException(nameof(swapChain));
        }

        nint texture = swapChain.GetBuffer(buffer, D3D11Texture2D.D3D11Texture2DGuid);
        return new D3D11Texture2D(texture);
    }
}
