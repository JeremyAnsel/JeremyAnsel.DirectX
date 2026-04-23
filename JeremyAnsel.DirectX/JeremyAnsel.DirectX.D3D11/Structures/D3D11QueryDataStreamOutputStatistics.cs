// <copyright file="D3D11QueryDataStreamOutputStatistics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Query information about the amount of data streamed out to the stream-output buffers in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11QueryDataStreamOutputStatistics : IEquatable<D3D11QueryDataStreamOutputStatistics>
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
        size += sizeof(ulong) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11QueryDataStreamOutputStatistics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11QueryDataStreamOutputStatistics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11QueryDataStreamOutputStatistics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.numPrimitivesWritten);
            DXMarshal.Write(ref buffer, obj.primitivesStorageNeeded);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11QueryDataStreamOutputStatistics NativeReadFrom(nint buffer)
    {
        D3D11QueryDataStreamOutputStatistics obj;
        obj.numPrimitivesWritten = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.primitivesStorageNeeded = DXMarshal.ReadUnsignedInt64(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11QueryDataStreamOutputStatistics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of primitives (that is, points, lines, and triangles) written to the stream-output buffers.
    /// </summary>
    private ulong numPrimitivesWritten;

    /// <summary>
    /// The number of primitives that would have been written to the stream-output buffers if there had been enough space for them all.
    /// </summary>
    private ulong primitivesStorageNeeded;

    /// <summary>
    /// Gets the number of primitives (that is, points, lines, and triangles) written to the stream-output buffers.
    /// </summary>
    public ulong NumPrimitivesWritten
    {
        get { return this.numPrimitivesWritten; }
    }

    /// <summary>
    /// Gets the number of primitives that would have been written to the stream-output buffers if there had been enough space for them all.
    /// </summary>
    public ulong PrimitivesStorageNeeded
    {
        get { return this.primitivesStorageNeeded; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11QueryDataStreamOutputStatistics left, D3D11QueryDataStreamOutputStatistics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11QueryDataStreamOutputStatistics left, D3D11QueryDataStreamOutputStatistics right)
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
        return obj is D3D11QueryDataStreamOutputStatistics statistics && Equals(statistics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11QueryDataStreamOutputStatistics other)
    {
        return numPrimitivesWritten == other.numPrimitivesWritten &&
               primitivesStorageNeeded == other.primitivesStorageNeeded;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -696511795;
        hashCode = hashCode * -1521134295 + numPrimitivesWritten.GetHashCode();
        hashCode = hashCode * -1521134295 + primitivesStorageNeeded.GetHashCode();
        return hashCode;
    }
}
