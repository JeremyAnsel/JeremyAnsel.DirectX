// <copyright file="D3D11SubResourceData.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies data for initializing a subresource.
/// </summary>
public unsafe readonly struct D3D11SubResourceData : IEquatable<D3D11SubResourceData>
{
    /// <summary>
    /// The initialization data.
    /// </summary>
    private readonly Array data;

    /// <summary>
    /// The initialization index.
    /// </summary>
    private readonly int index;

    /// <summary>
    /// The distance (in bytes) from the beginning of one line of a texture to the next line.
    /// </summary>
    private readonly uint pitch;

    /// <summary>
    /// The distance (in bytes) from the beginning of one depth level to the next.
    /// </summary>
    private readonly uint slicePitch;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SubResourceData"/> struct.
    /// </summary>
    /// <param name="data">The initialization data.</param>
    /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
    public D3D11SubResourceData(Array data, uint pitch)
    {
        this.data = data;
        this.index = 0;
        this.pitch = pitch;
        this.slicePitch = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SubResourceData"/> struct.
    /// </summary>
    /// <param name="data">The initialization data.</param>
    /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
    /// <param name="slicePitch">The distance (in bytes) from the beginning of one depth level to the next.</param>
    public D3D11SubResourceData(Array data, uint pitch, uint slicePitch)
    {
        this.data = data;
        this.index = 0;
        this.pitch = pitch;
        this.slicePitch = slicePitch;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SubResourceData"/> struct.
    /// </summary>
    /// <param name="data">The initialization data.</param>
    /// <param name="index">The initialization index.</param>
    /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
    /// <param name="slicePitch">The distance (in bytes) from the beginning of one depth level to the next.</param>
    public D3D11SubResourceData(Array data, int index, uint pitch, uint slicePitch)
    {
        this.data = data;
        this.index = index;
        this.pitch = pitch;
        this.slicePitch = slicePitch;
    }

    /// <summary>
    /// Gets the initialization data.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Reviewed")]
    public Array Data
    {
        get { return this.data; }
    }

    /// <summary>
    /// Gets the initialization index.
    /// </summary>
    public int Index
    {
        get { return this.index; }
    }

    /// <summary>
    /// Gets the distance (in bytes) from the beginning of one line of a texture to the next line.
    /// </summary>
    public uint Pitch
    {
        get { return this.pitch; }
    }

    /// <summary>
    /// Gets the distance (in bytes) from the beginning of one depth level to the next.
    /// </summary>
    public uint SlicePitch
    {
        get { return this.slicePitch; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11SubResourceData left, D3D11SubResourceData right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11SubResourceData left, D3D11SubResourceData right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public nint GetDataAsPointer()
    {
        return Marshal.UnsafeAddrOfPinnedArrayElement(data, index);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is D3D11SubResourceData data && Equals(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11SubResourceData other)
    {
        return EqualityComparer<Array>.Default.Equals(data, other.data) &&
               index == other.index &&
               pitch == other.pitch &&
               slicePitch == other.slicePitch;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 581002206;
        hashCode = hashCode * -1521134295 + EqualityComparer<Array>.Default.GetHashCode(data);
        hashCode = hashCode * -1521134295 + index.GetHashCode();
        hashCode = hashCode * -1521134295 + pitch.GetHashCode();
        hashCode = hashCode * -1521134295 + slicePitch.GetHashCode();
        return hashCode;
    }
}
