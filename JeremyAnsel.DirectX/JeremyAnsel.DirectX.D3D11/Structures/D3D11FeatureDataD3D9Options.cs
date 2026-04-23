// <copyright file="D3D11FeatureDataD3D9Options.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes Direct3D 9 feature options in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataD3D9Options : IEquatable<D3D11FeatureDataD3D9Options>
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
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataD3D9Options obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataD3D9Options>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataD3D9Options> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isFullNonPow2TextureSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataD3D9Options NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataD3D9Options obj;
        obj.isFullNonPow2TextureSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataD3D9Options> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature.
    /// </summary>
    private bool isFullNonPow2TextureSupported;

    /// <summary>
    /// Gets a value indicating whether the driver supports the nonpowers-of-2-unconditionally feature.
    /// </summary>
    public bool IsFullNonPow2TextureSupported
    {
        get { return this.isFullNonPow2TextureSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataD3D9Options left, D3D11FeatureDataD3D9Options right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataD3D9Options left, D3D11FeatureDataD3D9Options right)
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
        return obj is D3D11FeatureDataD3D9Options options && Equals(options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataD3D9Options other)
    {
        return isFullNonPow2TextureSupported == other.isFullNonPow2TextureSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 375143992 + isFullNonPow2TextureSupported.GetHashCode();
    }
}
