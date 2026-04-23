// <copyright file="D3D11Texture3DUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a unordered-access 3D texture resource.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture3DUav : IEquatable<D3D11Texture3DUav>
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
    public static void NativeWriteTo(nint buffer, in D3D11Texture3DUav obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture3DUav>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture3DUav> objects)
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
    public static D3D11Texture3DUav NativeReadFrom(nint buffer)
    {
        D3D11Texture3DUav obj;
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
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture3DUav> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The mipmap slice index.
    /// </summary>
    private uint mipSlice;

    /// <summary>
    /// The zero-based index of the first depth slice to be accessed.
    /// </summary>
    private uint firstWSlice;

    /// <summary>
    /// The number of depth slices.
    /// </summary>
    private uint wsize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mipSlice"></param>
    /// <param name="firstWSlice"></param>
    /// <param name="wsize"></param>
    public D3D11Texture3DUav(uint mipSlice, uint firstWSlice, uint wsize)
    {
        this.mipSlice = mipSlice;
        this.firstWSlice = firstWSlice;
        this.wsize = wsize;
    }

    /// <summary>
    /// Gets or sets the mipmap slice index.
    /// </summary>
    public uint MipSlice
    {
        get { return this.mipSlice; }
        set { this.mipSlice = value; }
    }

    /// <summary>
    /// Gets or sets the zero-based index of the first depth slice to be accessed.
    /// </summary>
    public uint FirstWSlice
    {
        get { return this.firstWSlice; }
        set { this.firstWSlice = value; }
    }

    /// <summary>
    /// Gets or sets the number of depth slices.
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
    public static bool operator ==(D3D11Texture3DUav left, D3D11Texture3DUav right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture3DUav left, D3D11Texture3DUav right)
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
        return obj is D3D11Texture3DUav uav && Equals(uav);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture3DUav other)
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
