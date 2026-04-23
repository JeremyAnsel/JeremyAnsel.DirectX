// <copyright file="D3D11FeatureDataD3D11Options1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes Direct3D 11.2 feature options in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataD3D11Options1 : IEquatable<D3D11FeatureDataD3D11Options1>
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
        size += sizeof(int) * 3;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataD3D11Options1 obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataD3D11Options1>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataD3D11Options1> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.tiledResourcesTier);
            DXMarshal.Write(ref buffer, obj.isMinMaxFilteringSupported);
            DXMarshal.Write(ref buffer, obj.isClearViewDepthInlyFormatsSupported);
            DXMarshal.Write(ref buffer, obj.isMapOnDefaultBuffersSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataD3D11Options1 NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataD3D11Options1 obj;
        obj.tiledResourcesTier = (D3D11TiledResourcesTier)DXMarshal.ReadInt32(ref buffer);
        obj.isMinMaxFilteringSupported = DXMarshal.ReadBool(ref buffer);
        obj.isClearViewDepthInlyFormatsSupported = DXMarshal.ReadBool(ref buffer);
        obj.isMapOnDefaultBuffersSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataD3D11Options1> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Specifies whether the hardware and driver support tiled resources.
    /// </summary>
    private D3D11TiledResourcesTier tiledResourcesTier;

    /// <summary>
    /// Specifies whether the hardware and driver support the filtering options of comparing the result to the minimum or maximum value during texture sampling.
    /// </summary>
    private bool isMinMaxFilteringSupported;

    /// <summary>
    /// Specifies whether the hardware and driver also support the <c>ID3D11DeviceContext1.ClearView</c> method on depth formats.
    /// </summary>
    private bool isClearViewDepthInlyFormatsSupported;

    /// <summary>
    /// Specifies support for creating <see cref="D3D11Buffer"/> resources that can be passed to the <c>ID3D11DeviceContext.Map</c> and <c>ID3D11DeviceContext.Unmap</c> methods.
    /// </summary>
    private bool isMapOnDefaultBuffersSupported;

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support tiled resources.
    /// </summary>
    public D3D11TiledResourcesTier TiledResourcesTier
    {
        get { return this.tiledResourcesTier; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support the filtering options of comparing the result to the minimum or maximum value during texture sampling.
    /// </summary>
    public bool IsMinMaxFilteringSupported
    {
        get { return this.isMinMaxFilteringSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver also support the <c>ID3D11DeviceContext1.ClearView</c> method on depth formats.
    /// </summary>
    public bool IsClearViewDepthInlyFormatsSupported
    {
        get { return this.isClearViewDepthInlyFormatsSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether creating <see cref="D3D11Buffer"/> resources that can be passed to the <c>ID3D11DeviceContext.Map</c> and <c>ID3D11DeviceContext.Unmap</c> methods is supported.
    /// </summary>
    public bool IsMapOnDefaultBuffersSupported
    {
        get { return this.isMapOnDefaultBuffersSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataD3D11Options1 left, D3D11FeatureDataD3D11Options1 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataD3D11Options1 left, D3D11FeatureDataD3D11Options1 right)
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
        return obj is D3D11FeatureDataD3D11Options1 options && Equals(options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataD3D11Options1 other)
    {
        return tiledResourcesTier == other.tiledResourcesTier &&
               isMinMaxFilteringSupported == other.isMinMaxFilteringSupported &&
               isClearViewDepthInlyFormatsSupported == other.isClearViewDepthInlyFormatsSupported &&
               isMapOnDefaultBuffersSupported == other.isMapOnDefaultBuffersSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1319414757;
        hashCode = hashCode * -1521134295 + tiledResourcesTier.GetHashCode();
        hashCode = hashCode * -1521134295 + isMinMaxFilteringSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isClearViewDepthInlyFormatsSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isMapOnDefaultBuffersSupported.GetHashCode();
        return hashCode;
    }
}
