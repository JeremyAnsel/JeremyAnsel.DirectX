// <copyright file="D3D11FeatureDataD3D9Options1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes Direct3D 9 feature options in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataD3D9Options1 : IEquatable<D3D11FeatureDataD3D9Options1>
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
        size += sizeof(int) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataD3D9Options1 obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataD3D9Options1>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataD3D9Options1> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isFullNonPow2TextureSupported);
            DXMarshal.Write(ref buffer, obj.isDepthAsTextureWithLessEqualComparisonFilterSupported);
            DXMarshal.Write(ref buffer, obj.isSimpleInstancingSupported);
            DXMarshal.Write(ref buffer, obj.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataD3D9Options1 NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataD3D9Options1 obj;
        obj.isFullNonPow2TextureSupported = DXMarshal.ReadBool(ref buffer);
        obj.isDepthAsTextureWithLessEqualComparisonFilterSupported = DXMarshal.ReadBool(ref buffer);
        obj.isSimpleInstancingSupported = DXMarshal.ReadBool(ref buffer);
        obj.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataD3D9Options1> objects)
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
    /// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
    /// </summary>
    private bool isDepthAsTextureWithLessEqualComparisonFilterSupported;

    /// <summary>
    /// Specifies whether the hardware and driver support simple instancing.
    /// </summary>
    private bool isSimpleInstancingSupported;

    /// <summary>
    /// Specifies whether the hardware and driver support setting a single face of a <c>TextureCube</c> as a render target while the depth stencil surface that is bound alongside can be a <c>Texture2D</c> (as opposed to <c>TextureCube</c>).
    /// </summary>
    private bool isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported;

    /// <summary>
    /// Gets a value indicating whether the driver supports the nonpowers-of-2-unconditionally feature.
    /// </summary>
    public bool IsFullNonPow2TextureSupported
    {
        get { return this.isFullNonPow2TextureSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
    /// </summary>
    public bool IsDepthAsTextureWithLessEqualComparisonFilterSupported
    {
        get { return this.isDepthAsTextureWithLessEqualComparisonFilterSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support simple instancing.
    /// </summary>
    public bool IsSimpleInstancingSupported
    {
        get { return this.isSimpleInstancingSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support setting a single face of a <c>TextureCube</c> as a render target while the depth stencil surface that is bound alongside can be a <c>Texture2D</c> (as opposed to <c>TextureCube</c>).
    /// </summary>
    public bool IsTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported
    {
        get { return this.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataD3D9Options1 left, D3D11FeatureDataD3D9Options1 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataD3D9Options1 left, D3D11FeatureDataD3D9Options1 right)
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
        return obj is D3D11FeatureDataD3D9Options1 options && Equals(options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataD3D9Options1 other)
    {
        return isFullNonPow2TextureSupported == other.isFullNonPow2TextureSupported &&
               isDepthAsTextureWithLessEqualComparisonFilterSupported == other.isDepthAsTextureWithLessEqualComparisonFilterSupported &&
               isSimpleInstancingSupported == other.isSimpleInstancingSupported &&
               isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported == other.isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 966212314;
        hashCode = hashCode * -1521134295 + isFullNonPow2TextureSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isDepthAsTextureWithLessEqualComparisonFilterSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isSimpleInstancingSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isTextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported.GetHashCode();
        return hashCode;
    }
}
