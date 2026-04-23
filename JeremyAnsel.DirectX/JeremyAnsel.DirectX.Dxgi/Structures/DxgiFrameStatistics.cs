// <copyright file="DxgiFrameStatistics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes timing and presentation statistics for a frame.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiFrameStatistics : IEquatable<DxgiFrameStatistics>
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
        size += sizeof(ulong) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiFrameStatistics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiFrameStatistics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiFrameStatistics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.presentCount);
            DXMarshal.Write(ref buffer, obj.presentRefreshCount);
            DXMarshal.Write(ref buffer, obj.syncRefreshCount);
            DXMarshal.Write(ref buffer, obj.syncQpcTime);
            DXMarshal.Write(ref buffer, obj.syncGpuTime);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiFrameStatistics NativeReadFrom(nint buffer)
    {
        DxgiFrameStatistics obj;
        obj.presentCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.presentRefreshCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.syncRefreshCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.syncQpcTime = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.syncGpuTime = DXMarshal.ReadUnsignedInt64(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiFrameStatistics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that represents the running total count of times that an image was presented to the monitor since the computer booted.
    /// </summary>
    private uint presentCount;

    /// <summary>
    /// A value that represents the running total count of v-blanks at which the last image was presented to the monitor and that have happened since the computer booted (for windowed mode, since the swap chain was created).
    /// </summary>
    private uint presentRefreshCount;

    /// <summary>
    /// A value that represents the running total count of v-blanks when the scheduler last sampled the machine time by calling <c>QueryPerformanceCounter</c> and that have happened since the computer booted (for windowed mode, since the swap chain was created).
    /// </summary>
    private uint syncRefreshCount;

    /// <summary>
    /// A value that represents the high-resolution performance counter timer. This value is the same as the value returned by the <c>QueryPerformanceCounter</c> function.
    /// </summary>
    private ulong syncQpcTime;

    /// <summary>
    /// The GPU time. Reserved. Always returns 0.
    /// </summary>
    private ulong syncGpuTime;

    /// <summary>
    /// Gets a value that represents the running total count of times that an image was presented to the monitor since the computer booted.
    /// </summary>
    public uint PresentCount
    {
        get { return this.presentCount; }
    }

    /// <summary>
    /// Gets a value that represents the running total count of v-blanks at which the last image was presented to the monitor and that have happened since the computer booted (for windowed mode, since the swap chain was created).
    /// </summary>
    public uint PresentRefreshCount
    {
        get { return this.presentRefreshCount; }
    }

    /// <summary>
    /// Gets a value that represents the running total count of v-blanks when the scheduler last sampled the machine time by calling <c>QueryPerformanceCounter</c> and that have happened since the computer booted (for windowed mode, since the swap chain was created).
    /// </summary>
    public uint SyncRefreshCount
    {
        get { return this.syncRefreshCount; }
    }

    /// <summary>
    /// Gets a value that represents the high-resolution performance counter timer. This value is the same as the value returned by the <c>QueryPerformanceCounter</c> function.
    /// </summary>
    public ulong SyncQpcTime
    {
        get { return this.syncQpcTime; }
    }

    /// <summary>
    /// Gets the GPU time. Reserved. Always returns 0.
    /// </summary>
    public ulong SyncGpuTime
    {
        get { return this.syncGpuTime; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiFrameStatistics left, DxgiFrameStatistics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiFrameStatistics left, DxgiFrameStatistics right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "PresentCount: {0}; PresentRefreshCount: {1} SyncRefreshCount: {2}",
            this.presentCount,
            this.presentRefreshCount,
            this.syncRefreshCount);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiFrameStatistics statistics && Equals(statistics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiFrameStatistics other)
    {
        return presentCount == other.presentCount &&
               presentRefreshCount == other.presentRefreshCount &&
               syncRefreshCount == other.syncRefreshCount &&
               syncQpcTime == other.syncQpcTime &&
               syncGpuTime == other.syncGpuTime;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -2030364829;
        hashCode = hashCode * -1521134295 + presentCount.GetHashCode();
        hashCode = hashCode * -1521134295 + presentRefreshCount.GetHashCode();
        hashCode = hashCode * -1521134295 + syncRefreshCount.GetHashCode();
        hashCode = hashCode * -1521134295 + syncQpcTime.GetHashCode();
        hashCode = hashCode * -1521134295 + syncGpuTime.GetHashCode();
        return hashCode;
    }
}
