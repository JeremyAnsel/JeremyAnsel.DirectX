// <copyright file="D3D11TextureCubeArraySrv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources from an array of cube textures to use in a shader resource view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11TextureCubeArraySrv : IEquatable<D3D11TextureCubeArraySrv>
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
    public static void NativeWriteTo(nint buffer, in D3D11TextureCubeArraySrv obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11TextureCubeArraySrv>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11TextureCubeArraySrv> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.mostDetailedMip);
            DXMarshal.Write(ref buffer, obj.mipLevels);
            DXMarshal.Write(ref buffer, obj.first2DArrayFace);
            DXMarshal.Write(ref buffer, obj.numCubes);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11TextureCubeArraySrv NativeReadFrom(nint buffer)
    {
        D3D11TextureCubeArraySrv obj;
        obj.mostDetailedMip = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.mipLevels = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.first2DArrayFace = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.numCubes = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11TextureCubeArraySrv> objects)
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
    /// The index of the first 2D texture to use.
    /// </summary>
    private uint first2DArrayFace;

    /// <summary>
    /// The number of cube textures in the array.
    /// </summary>
    private uint numCubes;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mostDetailedMip"></param>
    /// <param name="mipLevels"></param>
    /// <param name="first2DArrayFace"></param>
    /// <param name="numCubes"></param>
    public D3D11TextureCubeArraySrv(uint mostDetailedMip, uint mipLevels, uint first2DArrayFace, uint numCubes)
    {
        this.mostDetailedMip = mostDetailedMip;
        this.mipLevels = mipLevels;
        this.first2DArrayFace = first2DArrayFace;
        this.numCubes = numCubes;
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
    /// Gets or sets the index of the first 2D texture to use.
    /// </summary>
    public uint First2DArrayFace
    {
        get { return this.first2DArrayFace; }
        set { this.first2DArrayFace = value; }
    }

    /// <summary>
    /// Gets or sets the number of cube textures in the array.
    /// </summary>
    public uint NumCubes
    {
        get { return this.numCubes; }
        set { this.numCubes = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11TextureCubeArraySrv left, D3D11TextureCubeArraySrv right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11TextureCubeArraySrv left, D3D11TextureCubeArraySrv right)
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
        return obj is D3D11TextureCubeArraySrv srv && Equals(srv);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11TextureCubeArraySrv other)
    {
        return mostDetailedMip == other.mostDetailedMip &&
               mipLevels == other.mipLevels &&
               first2DArrayFace == other.first2DArrayFace &&
               numCubes == other.numCubes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1375197258;
        hashCode = hashCode * -1521134295 + mostDetailedMip.GetHashCode();
        hashCode = hashCode * -1521134295 + mipLevels.GetHashCode();
        hashCode = hashCode * -1521134295 + first2DArrayFace.GetHashCode();
        hashCode = hashCode * -1521134295 + numCubes.GetHashCode();
        return hashCode;
    }
}
