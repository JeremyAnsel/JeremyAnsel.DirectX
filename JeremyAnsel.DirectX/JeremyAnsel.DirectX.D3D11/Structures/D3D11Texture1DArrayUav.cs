// <copyright file="D3D11Texture1DArrayUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes an array of unordered-access 1D texture resources.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture1DArrayUav : IEquatable<D3D11Texture1DArrayUav>
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
    public static void NativeWriteTo(nint buffer, in D3D11Texture1DArrayUav obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture1DArrayUav>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture1DArrayUav> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.mipSlice);
            DXMarshal.Write(ref buffer, obj.firstArraySlice);
            DXMarshal.Write(ref buffer, obj.arraySize);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Texture1DArrayUav NativeReadFrom(nint buffer)
    {
        D3D11Texture1DArrayUav obj;
        obj.mipSlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.firstArraySlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.arraySize = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture1DArrayUav> objects)
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
    /// The zero-based index of the first array slice to be accessed.
    /// </summary>
    private uint firstArraySlice;

    /// <summary>
    /// The number of slices in the array.
    /// </summary>
    private uint arraySize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mipSlice"></param>
    /// <param name="firstArraySlice"></param>
    /// <param name="arraySize"></param>
    public D3D11Texture1DArrayUav(uint mipSlice, uint firstArraySlice, uint arraySize)
    {
        this.mipSlice = mipSlice;
        this.firstArraySlice = firstArraySlice;
        this.arraySize = arraySize;
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
    /// Gets or sets the zero-based index of the first array slice to be accessed.
    /// </summary>
    public uint FirstArraySlice
    {
        get { return this.firstArraySlice; }
        set { this.firstArraySlice = value; }
    }

    /// <summary>
    /// Gets or sets the number of slices in the array.
    /// </summary>
    public uint ArraySize
    {
        get { return this.arraySize; }
        set { this.arraySize = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11Texture1DArrayUav left, D3D11Texture1DArrayUav right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture1DArrayUav left, D3D11Texture1DArrayUav right)
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
        return obj is D3D11Texture1DArrayUav uav && Equals(uav);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture1DArrayUav other)
    {
        return mipSlice == other.mipSlice &&
               firstArraySlice == other.firstArraySlice &&
               arraySize == other.arraySize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1077041748;
        hashCode = hashCode * -1521134295 + mipSlice.GetHashCode();
        hashCode = hashCode * -1521134295 + firstArraySlice.GetHashCode();
        hashCode = hashCode * -1521134295 + arraySize.GetHashCode();
        return hashCode;
    }
}
