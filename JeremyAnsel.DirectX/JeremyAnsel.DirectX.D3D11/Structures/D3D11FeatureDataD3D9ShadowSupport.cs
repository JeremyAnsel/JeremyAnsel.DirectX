// <copyright file="D3D11FeatureDataD3D9ShadowSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes Direct3D 9 shadow support in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataD3D9ShadowSupport : IEquatable<D3D11FeatureDataD3D9ShadowSupport>
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
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataD3D9ShadowSupport obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataD3D9ShadowSupport>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataD3D9ShadowSupport> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isDepthAsTextureWithLessEqualComparisonFilterSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataD3D9ShadowSupport NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataD3D9ShadowSupport obj;
        obj.isDepthAsTextureWithLessEqualComparisonFilterSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataD3D9ShadowSupport> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
    /// </summary>
    private bool isDepthAsTextureWithLessEqualComparisonFilterSupported;

    /// <summary>
    /// Gets a value indicating whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to.
    /// </summary>
    public bool IsDepthAsTextureWithLessEqualComparisonFilterSupported
    {
        get { return this.isDepthAsTextureWithLessEqualComparisonFilterSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataD3D9ShadowSupport left, D3D11FeatureDataD3D9ShadowSupport right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataD3D9ShadowSupport left, D3D11FeatureDataD3D9ShadowSupport right)
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
        return obj is D3D11FeatureDataD3D9ShadowSupport support && Equals(support);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataD3D9ShadowSupport other)
    {
        return isDepthAsTextureWithLessEqualComparisonFilterSupported == other.isDepthAsTextureWithLessEqualComparisonFilterSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 779988943 + isDepthAsTextureWithLessEqualComparisonFilterSupported.GetHashCode();
    }
}
