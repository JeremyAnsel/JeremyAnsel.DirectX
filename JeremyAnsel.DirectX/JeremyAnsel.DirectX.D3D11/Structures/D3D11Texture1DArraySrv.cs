// <copyright file="D3D11Texture1DArraySrv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources from an array of 1D textures to use in a shader resource view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture1DArraySrv : IEquatable<D3D11Texture1DArraySrv>
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
        size += sizeof(uint) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Texture1DArraySrv obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture1DArraySrv>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture1DArraySrv> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.mostDetailedMip);
            DXMarshal.Write(ref buffer, obj.mipLevels);
            DXMarshal.Write(ref buffer, obj.firstArraySlice);
            DXMarshal.Write(ref buffer, obj.arraySize);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Texture1DArraySrv NativeReadFrom(nint buffer)
    {
        D3D11Texture1DArraySrv obj;
        obj.mostDetailedMip = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.mipLevels = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.firstArraySlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.arraySize = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture1DArraySrv> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The index of the most detailed mipmap level to use.
    /// </summary>
    private uint mostDetailedMip;

    /// <summary>
    /// The maximum number of mipmap levels for the view of the texture.
    /// </summary>
    private uint mipLevels;

    /// <summary>
    /// The index of the first texture to use in an array of textures.
    /// </summary>
    private uint firstArraySlice;

    /// <summary>
    /// The number of textures in the array.
    /// </summary>
    private uint arraySize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mostDetailedMip"></param>
    /// <param name="mipLevels"></param>
    /// <param name="firstArraySlice"></param>
    /// <param name="arraySize"></param>
    public D3D11Texture1DArraySrv(uint mostDetailedMip, uint mipLevels, uint firstArraySlice, uint arraySize)
    {
        this.mostDetailedMip = mostDetailedMip;
        this.mipLevels = mipLevels;
        this.firstArraySlice = firstArraySlice;
        this.arraySize = arraySize;
    }

    /// <summary>
    /// Gets or sets the index of the most detailed mipmap level to use.
    /// </summary>
    public uint MostDetailedMip
    {
        get { return this.mostDetailedMip; }
        set { this.mostDetailedMip = value; }
    }

    /// <summary>
    /// Gets or sets the maximum number of mipmap levels for the view of the texture.
    /// </summary>
    public uint MipLevels
    {
        get { return this.mipLevels; }
        set { this.mipLevels = value; }
    }

    /// <summary>
    /// Gets or sets the index of the first texture to use in an array of textures.
    /// </summary>
    public uint FirstArraySlice
    {
        get { return this.firstArraySlice; }
        set { this.firstArraySlice = value; }
    }

    /// <summary>
    /// Gets or sets the number of textures in the array.
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
    public static bool operator ==(D3D11Texture1DArraySrv left, D3D11Texture1DArraySrv right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture1DArraySrv left, D3D11Texture1DArraySrv right)
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
        return obj is D3D11Texture1DArraySrv srv && Equals(srv);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture1DArraySrv other)
    {
        return mostDetailedMip == other.mostDetailedMip &&
               mipLevels == other.mipLevels &&
               firstArraySlice == other.firstArraySlice &&
               arraySize == other.arraySize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 323155217;
        hashCode = hashCode * -1521134295 + mostDetailedMip.GetHashCode();
        hashCode = hashCode * -1521134295 + mipLevels.GetHashCode();
        hashCode = hashCode * -1521134295 + firstArraySlice.GetHashCode();
        hashCode = hashCode * -1521134295 + arraySize.GetHashCode();
        return hashCode;
    }
}
