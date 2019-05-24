// <copyright file="D3D11Utils.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class D3D11Utils
    {
        /// <summary>
        /// Immediately releases the unmanaged resources.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="obj">The object.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Reviewed")]
        public static void DisposeAndNull<T>(ref T obj) where T : class, ID3D11Releasable
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }

        /// <summary>
        /// Releases the managed reference to the COM interface.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="obj">The COM interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Reviewed")]
        public static void ReleaseAndNull<T>(ref T obj) where T : class, ID3D11Releasable
        {
            if (obj != null)
            {
                obj.Release();
                obj = null;
            }
        }

        /// <summary>
        /// Calculates a subresource index for a texture.
        /// </summary>
        /// <param name="mipSlice">A zero-based index for the mipmap level to address; 0 indicates the first, most detailed mipmap level</param>
        /// <param name="arraySlice">The zero-based index for the array level to address; always use 0 for volume (3D) textures.</param>
        /// <param name="mipLevels">Number of mipmap levels in the resource.</param>
        /// <returns>The index which equals <c>MipSlice + (ArraySlice * MipLevels)</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CalcSubresource(uint mipSlice, uint arraySlice, uint mipLevels)
        {
            return mipSlice + arraySlice * mipLevels;
        }
    }
}
