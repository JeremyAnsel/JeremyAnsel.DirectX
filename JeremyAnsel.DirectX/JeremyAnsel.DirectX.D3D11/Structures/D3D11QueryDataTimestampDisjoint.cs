// <copyright file="D3D11QueryDataTimestampDisjoint.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Query information about the reliability of a timestamp query.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11QueryDataTimestampDisjoint : IEquatable<D3D11QueryDataTimestampDisjoint>
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
        size += sizeof(ulong);
        size += sizeof(int);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11QueryDataTimestampDisjoint obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11QueryDataTimestampDisjoint>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11QueryDataTimestampDisjoint> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.frequency);
            DXMarshal.Write(ref buffer, obj.isDisjoint);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11QueryDataTimestampDisjoint NativeReadFrom(nint buffer)
    {
        D3D11QueryDataTimestampDisjoint obj;
        obj.frequency = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.isDisjoint = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11QueryDataTimestampDisjoint> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// How frequently the GPU counter increments in Hz.
    /// </summary>
    private ulong frequency;

    /// <summary>
    /// Indicates whether the timestamp counter is discontinuous or disjoint.
    /// </summary>
    private bool isDisjoint;

    /// <summary>
    /// Gets a value indicating how frequently the GPU counter increments in Hz.
    /// </summary>
    public ulong Frequency
    {
        get { return this.frequency; }
    }

    /// <summary>
    /// Gets a value indicating whether the timestamp counter is discontinuous or disjoint.
    /// </summary>
    public bool IsDisjoint
    {
        get { return this.isDisjoint; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11QueryDataTimestampDisjoint left, D3D11QueryDataTimestampDisjoint right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11QueryDataTimestampDisjoint left, D3D11QueryDataTimestampDisjoint right)
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
        return obj is D3D11QueryDataTimestampDisjoint disjoint && Equals(disjoint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11QueryDataTimestampDisjoint other)
    {
        return frequency == other.frequency &&
               isDisjoint == other.isDisjoint;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -38498046;
        hashCode = hashCode * -1521134295 + frequency.GetHashCode();
        hashCode = hashCode * -1521134295 + isDisjoint.GetHashCode();
        return hashCode;
    }
}
