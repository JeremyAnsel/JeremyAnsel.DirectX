// <copyright file="DxgiSwapChainExtensions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Swap chain extensions.
    /// </summary>
    public static class DxgiSwapChainExtensions
    {
        /// <summary>
        /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
        /// </summary>
        /// <param name="swapChain">The swap chain.</param>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <returns>A 2D texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D3D11Texture2D GetTexture2D(this DxgiSwapChain swapChain, uint buffer)
        {
            if (swapChain == null)
            {
                throw new ArgumentNullException(nameof(swapChain));
            }

            object texture = swapChain.GetBuffer(buffer, typeof(ID3D11Texture2D).GUID);

            if (texture == null)
            {
                return null;
            }

            return new D3D11Texture2D((ID3D11Texture2D)texture);
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
        /// </summary>
        /// <param name="swapChain">The swap chain.</param>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <returns>A 2D texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D3D11Texture2D GetTexture2D(this DxgiSwapChain1 swapChain, uint buffer)
        {
            if (swapChain == null)
            {
                throw new ArgumentNullException(nameof(swapChain));
            }

            object texture = swapChain.GetBuffer(buffer, typeof(ID3D11Texture2D).GUID);

            if (texture == null)
            {
                return null;
            }

            return new D3D11Texture2D((ID3D11Texture2D)texture);
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
        /// </summary>
        /// <param name="swapChain">The swap chain.</param>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <returns>A 2D texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D3D11Texture2D GetTexture2D(this DxgiSwapChain2 swapChain, uint buffer)
        {
            if (swapChain == null)
            {
                throw new ArgumentNullException(nameof(swapChain));
            }

            object texture = swapChain.GetBuffer(buffer, typeof(ID3D11Texture2D).GUID);

            if (texture == null)
            {
                return null;
            }

            return new D3D11Texture2D((ID3D11Texture2D)texture);
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers, viewed as a 2D texture.
        /// </summary>
        /// <param name="swapChain">The swap chain.</param>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <returns>A 2D texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D3D11Texture2D GetTexture2D(this DxgiSwapChain3 swapChain, uint buffer)
        {
            if (swapChain == null)
            {
                throw new ArgumentNullException(nameof(swapChain));
            }

            object texture = swapChain.GetBuffer(buffer, typeof(ID3D11Texture2D).GUID);

            if (texture == null)
            {
                return null;
            }

            return new D3D11Texture2D((ID3D11Texture2D)texture);
        }
    }
}
