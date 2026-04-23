// <copyright file="DxgiQueryVideoMemoryInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// 
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiQueryVideoMemoryInfo : IEquatable<DxgiQueryVideoMemoryInfo>
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
        size += sizeof(ulong) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiQueryVideoMemoryInfo obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiQueryVideoMemoryInfo>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiQueryVideoMemoryInfo> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.budget);
            DXMarshal.Write(ref buffer, obj.currentUsage);
            DXMarshal.Write(ref buffer, obj.availableForReservation);
            DXMarshal.Write(ref buffer, obj.currentReservation);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiQueryVideoMemoryInfo NativeReadFrom(nint buffer)
    {
        DxgiQueryVideoMemoryInfo obj;
        obj.budget = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.currentUsage = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.availableForReservation = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.currentReservation = DXMarshal.ReadUnsignedInt64(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiQueryVideoMemoryInfo> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }


    private ulong budget;

    private ulong currentUsage;

    private ulong availableForReservation;

    private ulong currentReservation;

    /// <summary>
    /// 
    /// </summary>
    public readonly ulong Budget => budget;

    /// <summary>
    /// 
    /// </summary>
    public readonly ulong CurrentUsage => currentUsage;

    /// <summary>
    /// 
    /// </summary>
    public readonly ulong AvailableForReservation => availableForReservation;

    /// <summary>
    /// 
    /// </summary>
    public readonly ulong CurrentReservation => currentReservation;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiQueryVideoMemoryInfo left, DxgiQueryVideoMemoryInfo right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiQueryVideoMemoryInfo left, DxgiQueryVideoMemoryInfo right)
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
        return obj is DxgiQueryVideoMemoryInfo info && Equals(info);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiQueryVideoMemoryInfo other)
    {
        return budget == other.budget &&
               currentUsage == other.currentUsage &&
               availableForReservation == other.availableForReservation &&
               currentReservation == other.currentReservation;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -617289216;
        hashCode = hashCode * -1521134295 + budget.GetHashCode();
        hashCode = hashCode * -1521134295 + currentUsage.GetHashCode();
        hashCode = hashCode * -1521134295 + availableForReservation.GetHashCode();
        hashCode = hashCode * -1521134295 + currentReservation.GetHashCode();
        return hashCode;
    }
}
