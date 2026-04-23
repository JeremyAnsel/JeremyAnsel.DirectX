// <copyright file="D3D11FeatureDataD3D10XHardwareOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes compute shader and raw and structured buffer support in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataD3D10XHardwareOptions : IEquatable<D3D11FeatureDataD3D10XHardwareOptions>
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
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataD3D10XHardwareOptions obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataD3D10XHardwareOptions>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataD3D10XHardwareOptions> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataD3D10XHardwareOptions NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataD3D10XHardwareOptions obj;
        obj.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataD3D10XHardwareOptions> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Indicates whether compute shaders and raw and structured buffers are supported.
    /// </summary>
    private bool isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported;

    /// <summary>
    /// Gets a value indicating whether compute shaders and raw and structured buffers are supported.
    /// </summary>
    public bool IsComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported
    {
        get { return this.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataD3D10XHardwareOptions left, D3D11FeatureDataD3D10XHardwareOptions right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataD3D10XHardwareOptions left, D3D11FeatureDataD3D10XHardwareOptions right)
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
        return obj is D3D11FeatureDataD3D10XHardwareOptions options && Equals(options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataD3D10XHardwareOptions other)
    {
        return isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported == other.isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 1656096862 + isComputeShadersPlusRawAndStructuredBuffersViaShader4XSupported.GetHashCode();
    }
}
