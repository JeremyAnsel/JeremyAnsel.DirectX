// <copyright file="D3D11Texture3DRtv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources from a 3D texture to use in a render-target view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture3DRtv : IEquatable<D3D11Texture3DRtv>
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
        size += sizeof(uint) * 3;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Texture3DRtv obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture3DRtv>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture3DRtv> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.mipSlice);
            DXMarshal.Write(ref buffer, obj.firstWSlice);
            DXMarshal.Write(ref buffer, obj.wsize);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Texture3DRtv NativeReadFrom(nint buffer)
    {
        D3D11Texture3DRtv obj;
        obj.mipSlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.firstWSlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.wsize = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture3DRtv> objects)
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
    /// The first depth level to use.
    /// </summary>
    private uint firstWSlice;

    /// <summary>
    /// The number of depth levels to use in the render-target view.
    /// </summary>
    private uint wsize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mipSlice"></param>
    /// <param name="firstWSlice"></param>
    /// <param name="wsize"></param>
    public D3D11Texture3DRtv(uint mipSlice, uint firstWSlice, uint wsize)
    {
        this.mipSlice = mipSlice;
        this.firstWSlice = firstWSlice;
        this.wsize = wsize;
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
    /// Gets or sets the first depth level to use.
    /// </summary>
    public uint FirstWSlice
    {
        get { return this.firstWSlice; }
        set { this.firstWSlice = value; }
    }

    /// <summary>
    /// Gets or sets the number of depth levels to use in the render-target view.
    /// </summary>
    public uint WSize
    {
        get { return this.wsize; }
        set { this.wsize = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11Texture3DRtv left, D3D11Texture3DRtv right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture3DRtv left, D3D11Texture3DRtv right)
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
        return obj is D3D11Texture3DRtv rtv && Equals(rtv);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture3DRtv other)
    {
        return mipSlice == other.mipSlice &&
               firstWSlice == other.firstWSlice &&
               wsize == other.wsize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1834057420;
        hashCode = hashCode * -1521134295 + mipSlice.GetHashCode();
        hashCode = hashCode * -1521134295 + firstWSlice.GetHashCode();
        hashCode = hashCode * -1521134295 + wsize.GetHashCode();
        return hashCode;
    }
}
