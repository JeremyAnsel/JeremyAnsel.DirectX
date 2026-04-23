// <copyright file="D3D11Utils.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Utility methods.
/// </summary>
public static class D3D11Utils
{
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
        return mipSlice + (arraySlice * mipLevels);
    }
}
