// <copyright file="D3D11MappedSubResource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Provides access to subresource data.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11MappedSubResource : IEquatable<D3D11MappedSubResource>
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
        size += sizeof(nint);
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11MappedSubResource obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11MappedSubResource>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11MappedSubResource> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.data);
            DXMarshal.Write(ref buffer, obj.rowPitch);
            DXMarshal.Write(ref buffer, obj.depthPitch);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11MappedSubResource NativeReadFrom(nint buffer)
    {
        D3D11MappedSubResource obj;
        obj.data = DXMarshal.ReadIntPtr(ref buffer);
        obj.rowPitch = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.depthPitch = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11MappedSubResource> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Pointer to the data.
    /// </summary>
    private nint data;

    /// <summary>
    /// The row pitch, or width, or physical size (in bytes) of the data.
    /// </summary>
    private uint rowPitch;

    /// <summary>
    /// The depth pitch, or width, or physical size (in bytes)of the data.
    /// </summary>
    private uint depthPitch;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="rowPitch"></param>
    /// <param name="depthPitch"></param>
    public D3D11MappedSubResource(nint data, uint rowPitch, uint depthPitch)
    {
        this.data = data;
        this.rowPitch = rowPitch;
        this.depthPitch = depthPitch;
    }

    /// <summary>
    /// Gets or sets the pointer to the data.
    /// </summary>
    public nint Data
    {
        get { return this.data; }
        set { this.data = value; }
    }

    /// <summary>
    /// Gets or sets the row pitch, or width, or physical size (in bytes) of the data.
    /// </summary>
    public uint RowPitch
    {
        get { return this.rowPitch; }
        set { this.rowPitch = value; }
    }

    /// <summary>
    /// Gets or sets the depth pitch, or width, or physical size (in bytes)of the data.
    /// </summary>
    public uint DepthPitch
    {
        get { return this.depthPitch; }
        set { this.depthPitch = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11MappedSubResource left, D3D11MappedSubResource right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11MappedSubResource left, D3D11MappedSubResource right)
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
        return obj is D3D11MappedSubResource resource && Equals(resource);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11MappedSubResource other)
    {
        return EqualityComparer<nint>.Default.Equals(data, other.data) &&
               rowPitch == other.rowPitch &&
               depthPitch == other.depthPitch;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1510870860;
        hashCode = hashCode * -1521134295 + data.GetHashCode();
        hashCode = hashCode * -1521134295 + rowPitch.GetHashCode();
        hashCode = hashCode * -1521134295 + depthPitch.GetHashCode();
        return hashCode;
    }
}
