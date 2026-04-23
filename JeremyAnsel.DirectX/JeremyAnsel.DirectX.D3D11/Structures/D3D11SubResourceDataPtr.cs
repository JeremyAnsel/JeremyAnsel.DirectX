// <copyright file="D3D11SubResourceDataPtr.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies a pointer to data for initializing a subresource.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11SubResourceDataPtr : IEquatable<D3D11SubResourceDataPtr>
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
    public static void NativeWriteTo(nint buffer, in D3D11SubResourceDataPtr obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11SubResourceDataPtr>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11SubResourceDataPtr> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.sysMem);
            DXMarshal.Write(ref buffer, obj.sysMemPitch);
            DXMarshal.Write(ref buffer, obj.sysMemSlicePitch);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11SubResourceDataPtr NativeReadFrom(nint buffer)
    {
        D3D11SubResourceDataPtr obj;
        obj.sysMem = DXMarshal.ReadIntPtr(ref buffer);
        obj.sysMemPitch = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.sysMemSlicePitch = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11SubResourceDataPtr> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A pointer to the initialization data.
    /// </summary>
    private nint sysMem;

    /// <summary>
    /// The distance (in bytes) from the beginning of one line of a texture to the next line.
    /// </summary>
    private uint sysMemPitch;

    /// <summary>
    /// The distance (in bytes) from the beginning of one depth level to the next.
    /// </summary>
    private uint sysMemSlicePitch;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SubResourceDataPtr"/> struct.
    /// </summary>
    /// <param name="data">The initialization data.</param>
    /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
    public D3D11SubResourceDataPtr(nint data, uint pitch)
    {
        this.sysMem = data;
        this.sysMemPitch = pitch;
        this.sysMemSlicePitch = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SubResourceDataPtr"/> struct.
    /// </summary>
    /// <param name="data">The initialization data.</param>
    /// <param name="pitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
    /// <param name="slicePitch">The distance (in bytes) from the beginning of one depth level to the next.</param>
    public D3D11SubResourceDataPtr(nint data, uint pitch, uint slicePitch)
    {
        this.sysMem = data;
        this.sysMemPitch = pitch;
        this.sysMemSlicePitch = slicePitch;
    }

    /// <summary>
    /// Gets or sets a pointer to the initialization data.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
    public nint SysMem
    {
        get { return this.sysMem; }
        set { this.sysMem = value; }
    }

    /// <summary>
    /// Gets or sets the distance (in bytes) from the beginning of one line of a texture to the next line.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
    public uint SysMemPitch
    {
        get { return this.sysMemPitch; }
        set { this.sysMemPitch = value; }
    }

    /// <summary>
    /// Gets or sets the distance (in bytes) from the beginning of one depth level to the next.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
    public uint SysMemSlicePitch
    {
        get { return this.sysMemSlicePitch; }
        set { this.sysMemSlicePitch = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11SubResourceDataPtr left, D3D11SubResourceDataPtr right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11SubResourceDataPtr left, D3D11SubResourceDataPtr right)
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
        return obj is D3D11SubResourceDataPtr ptr && Equals(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11SubResourceDataPtr other)
    {
        return EqualityComparer<nint>.Default.Equals(sysMem, other.sysMem) &&
               sysMemPitch == other.sysMemPitch &&
               sysMemSlicePitch == other.sysMemSlicePitch;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1802953583;
        hashCode = hashCode * -1521134295 + sysMem.GetHashCode();
        hashCode = hashCode * -1521134295 + sysMemPitch.GetHashCode();
        hashCode = hashCode * -1521134295 + sysMemSlicePitch.GetHashCode();
        return hashCode;
    }
}
