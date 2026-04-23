// <copyright file="D3D11FeatureDataShaderMinPrecisionSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes precision support options for shaders in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataShaderMinPrecisionSupport : IEquatable<D3D11FeatureDataShaderMinPrecisionSupport>
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
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataShaderMinPrecisionSupport obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataShaderMinPrecisionSupport>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataShaderMinPrecisionSupport> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.pixelShaderMinPrecision);
            DXMarshal.Write(ref buffer, (int)obj.allOtherShaderStagesMinPrecision);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataShaderMinPrecisionSupport NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataShaderMinPrecisionSupport obj;
        obj.pixelShaderMinPrecision = (D3D11ShaderMinPrecisionSupports)DXMarshal.ReadInt32(ref buffer);
        obj.allOtherShaderStagesMinPrecision = (D3D11ShaderMinPrecisionSupports)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataShaderMinPrecisionSupport> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The minimum precision levels that the driver supports for the pixel shader.
    /// </summary>
    private D3D11ShaderMinPrecisionSupports pixelShaderMinPrecision;

    /// <summary>
    /// The minimum precision levels that the driver supports for all other shader stages.
    /// </summary>
    private D3D11ShaderMinPrecisionSupports allOtherShaderStagesMinPrecision;

    /// <summary>
    /// Gets the minimum precision levels that the driver supports for the pixel shader.
    /// </summary>
    public D3D11ShaderMinPrecisionSupports PixelShaderMinPrecision
    {
        get { return this.pixelShaderMinPrecision; }
    }

    /// <summary>
    /// Gets the minimum precision levels that the driver supports for all other shader stages.
    /// </summary>
    public D3D11ShaderMinPrecisionSupports AllOtherShaderStagesMinPrecision
    {
        get { return this.allOtherShaderStagesMinPrecision; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataShaderMinPrecisionSupport left, D3D11FeatureDataShaderMinPrecisionSupport right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataShaderMinPrecisionSupport left, D3D11FeatureDataShaderMinPrecisionSupport right)
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
        return obj is D3D11FeatureDataShaderMinPrecisionSupport support && Equals(support);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataShaderMinPrecisionSupport other)
    {
        return pixelShaderMinPrecision == other.pixelShaderMinPrecision &&
               allOtherShaderStagesMinPrecision == other.allOtherShaderStagesMinPrecision;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1567539558;
        hashCode = hashCode * -1521134295 + pixelShaderMinPrecision.GetHashCode();
        hashCode = hashCode * -1521134295 + allOtherShaderStagesMinPrecision.GetHashCode();
        return hashCode;
    }
}
