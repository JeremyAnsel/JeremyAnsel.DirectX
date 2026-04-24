// <copyright file="D3D11CounterInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Information about the video card's performance counter capabilities.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11CounterInfo : IEquatable<D3D11CounterInfo>
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
        size += sizeof(int);
        size += sizeof(uint);
        size += sizeof(byte);
        size += 3; // padding
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11CounterInfo obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11CounterInfo>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11CounterInfo> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.lastDeviceDependentCounter);
            DXMarshal.Write(ref buffer, obj.numSimultaneousCounters);
            DXMarshal.Write(ref buffer, obj.numDetectableParallelUnits);
            DXMarshal.Write(ref buffer, (byte)0); // padding
            DXMarshal.Write(ref buffer, (byte)0); // padding
            DXMarshal.Write(ref buffer, (byte)0); // padding
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11CounterInfo NativeReadFrom(nint buffer)
    {
        D3D11CounterInfo obj;
        obj.lastDeviceDependentCounter = (D3D11CounterType)DXMarshal.ReadInt32(ref buffer);
        obj.numSimultaneousCounters = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.numDetectableParallelUnits = DXMarshal.ReadByte(ref buffer);
        buffer += 3; // padding
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11CounterInfo> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The largest device-dependent counter ID that the device supports. If none are supported, this value will be 0.
    /// </summary>
    private D3D11CounterType lastDeviceDependentCounter;

    /// <summary>
    /// The number of counters that can be simultaneously supported.
    /// </summary>
    private uint numSimultaneousCounters;

    /// <summary>
    /// The number of detectable parallel units that the counter is able to discern. Values are 1 ~ 4.
    /// </summary>
    private byte numDetectableParallelUnits;

    /// <summary>
    /// Gets the largest device-dependent counter ID that the device supports. If none are supported, this value will be 0.
    /// </summary>
    public D3D11CounterType LastDeviceDependantCounter
    {
        get { return this.lastDeviceDependentCounter; }
    }

    /// <summary>
    /// Gets the number of counters that can be simultaneously supported.
    /// </summary>
    public uint NumSimultaneousCounters
    {
        get { return this.numSimultaneousCounters; }
    }

    /// <summary>
    /// Gets the number of detectable parallel units that the counter is able to discern. Values are 1 ~ 4.
    /// </summary>
    public byte NumDetectableParallelUnits
    {
        get { return this.numDetectableParallelUnits; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11CounterInfo left, D3D11CounterInfo right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11CounterInfo left, D3D11CounterInfo right)
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
        return obj is D3D11CounterInfo info && Equals(info);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11CounterInfo other)
    {
        return lastDeviceDependentCounter == other.lastDeviceDependentCounter &&
               numSimultaneousCounters == other.numSimultaneousCounters &&
               numDetectableParallelUnits == other.numDetectableParallelUnits;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -36046049;
        hashCode = hashCode * -1521134295 + lastDeviceDependentCounter.GetHashCode();
        hashCode = hashCode * -1521134295 + numSimultaneousCounters.GetHashCode();
        hashCode = hashCode * -1521134295 + numDetectableParallelUnits.GetHashCode();
        return hashCode;
    }
}
