// <copyright file="D3D11FeatureDataThreading.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes the multi-threading features that are supported by the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataThreading : IEquatable<D3D11FeatureDataThreading>
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
        size += sizeof(int) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataThreading obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataThreading>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataThreading> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isDriverConcurrentCreatesSupported);
            DXMarshal.Write(ref buffer, obj.isDriverCommandListsSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataThreading NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataThreading obj;
        obj.isDriverConcurrentCreatesSupported = DXMarshal.ReadBool(ref buffer);
        obj.isDriverCommandListsSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataThreading> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Indicates whether resources can be created concurrently on multiple threads while drawing.
    /// </summary>
    private bool isDriverConcurrentCreatesSupported;

    /// <summary>
    /// Indicates whether command lists are supported by the current driver.
    /// </summary>
    private bool isDriverCommandListsSupported;

    /// <summary>
    /// Gets a value indicating whether resources can be created concurrently on multiple threads while drawing.
    /// </summary>
    public bool IsDriverConcurrentCreatesSupported
    {
        get { return this.isDriverConcurrentCreatesSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether command lists are supported by the current driver.
    /// </summary>
    public bool IsDriverCommandListsSupported
    {
        get { return this.isDriverCommandListsSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataThreading left, D3D11FeatureDataThreading right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataThreading left, D3D11FeatureDataThreading right)
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
        return obj is D3D11FeatureDataThreading threading && Equals(threading);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataThreading other)
    {
        return isDriverConcurrentCreatesSupported == other.isDriverConcurrentCreatesSupported &&
               isDriverCommandListsSupported == other.isDriverCommandListsSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -700546900;
        hashCode = hashCode * -1521134295 + isDriverConcurrentCreatesSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isDriverCommandListsSupported.GetHashCode();
        return hashCode;
    }
}
