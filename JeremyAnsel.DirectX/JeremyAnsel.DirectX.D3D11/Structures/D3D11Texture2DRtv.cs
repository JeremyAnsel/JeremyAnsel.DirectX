// <copyright file="D3D11Texture2DRtv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresource from a 2D texture to use in a render-target view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture2DRtv : IEquatable<D3D11Texture2DRtv>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int NativeRequiredSize()
    {
        return NativeRequiredSize(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int NativeRequiredSize(int count)
    {
        int size = 0;
        size += sizeof(uint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Texture2DRtv obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture2DRtv>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture2DRtv> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.mipSlice);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Texture2DRtv NativeReadFrom(nint buffer)
    {
        D3D11Texture2DRtv obj;
        obj.mipSlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture2DRtv> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The index of the mipmap level to use mip slice.
    /// </summary>
    private uint mipSlice;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mipSlice"></param>
    public D3D11Texture2DRtv(uint mipSlice)
    {
        this.mipSlice = mipSlice;
    }

    /// <summary>
    /// Gets or sets the index of the mipmap level to use mip slice.
    /// </summary>
    public uint MipSlice
    {
        get { return this.mipSlice; }
        set { this.mipSlice = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11Texture2DRtv left, D3D11Texture2DRtv right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture2DRtv left, D3D11Texture2DRtv right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is D3D11Texture2DRtv rtv && Equals(rtv);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture2DRtv other)
    {
        return mipSlice == other.mipSlice;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return -1989589131 + mipSlice.GetHashCode();
    }
}
