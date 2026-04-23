// <copyright file="D3D11Texture2DMsArrayRtv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources from a an array of multisampled 2D textures to use in a render-target view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture2DMsArrayRtv : IEquatable<D3D11Texture2DMsArrayRtv>
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
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Texture2DMsArrayRtv obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture2DMsArrayRtv>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture2DMsArrayRtv> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.firstArraySlice);
            DXMarshal.Write(ref buffer, obj.arraySize);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Texture2DMsArrayRtv NativeReadFrom(nint buffer)
    {
        D3D11Texture2DMsArrayRtv obj;
        obj.firstArraySlice = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.arraySize = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture2DMsArrayRtv> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The index of the first texture to use in an array of textures.
    /// </summary>
    private uint firstArraySlice;

    /// <summary>
    /// The number of textures to use.
    /// </summary>
    private uint arraySize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstArraySlice"></param>
    /// <param name="arraySize"></param>
    public D3D11Texture2DMsArrayRtv(uint firstArraySlice, uint arraySize)
    {
        this.firstArraySlice = firstArraySlice;
        this.arraySize = arraySize;
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
    /// Gets or sets the number of textures to use.
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
    public static bool operator ==(D3D11Texture2DMsArrayRtv left, D3D11Texture2DMsArrayRtv right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture2DMsArrayRtv left, D3D11Texture2DMsArrayRtv right)
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
        return obj is D3D11Texture2DMsArrayRtv rtv && Equals(rtv);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture2DMsArrayRtv other)
    {
        return firstArraySlice == other.firstArraySlice &&
               arraySize == other.arraySize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 650317719;
        hashCode = hashCode * -1521134295 + firstArraySlice.GetHashCode();
        hashCode = hashCode * -1521134295 + arraySize.GetHashCode();
        return hashCode;
    }
}
