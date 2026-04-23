// <copyright file="D3D11QueryDataPipelineStatistics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Query information about graphics-pipeline activity in between calls to <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11QueryDataPipelineStatistics : IEquatable<D3D11QueryDataPipelineStatistics>
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
        size += sizeof(ulong) * 11;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11QueryDataPipelineStatistics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11QueryDataPipelineStatistics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11QueryDataPipelineStatistics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.inputAssemblerVertices);
            DXMarshal.Write(ref buffer, obj.inputAssemblerPrimitives);
            DXMarshal.Write(ref buffer, obj.vertexShaderInvocations);
            DXMarshal.Write(ref buffer, obj.geometryShaderInvocations);
            DXMarshal.Write(ref buffer, obj.geometryShaderPrimitives);
            DXMarshal.Write(ref buffer, obj.rasterizerInvocations);
            DXMarshal.Write(ref buffer, obj.rasterizerPrimitives);
            DXMarshal.Write(ref buffer, obj.pixelShaderInvocations);
            DXMarshal.Write(ref buffer, obj.hullShaderInvocations);
            DXMarshal.Write(ref buffer, obj.domainShaderInvocations);
            DXMarshal.Write(ref buffer, obj.computeShaderInvocations);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11QueryDataPipelineStatistics NativeReadFrom(nint buffer)
    {
        D3D11QueryDataPipelineStatistics obj;
        obj.inputAssemblerVertices = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.inputAssemblerPrimitives = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.vertexShaderInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.geometryShaderInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.geometryShaderPrimitives = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.rasterizerInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.rasterizerPrimitives = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.pixelShaderInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.hullShaderInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.domainShaderInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.computeShaderInvocations = DXMarshal.ReadUnsignedInt64(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11QueryDataPipelineStatistics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of vertices read by input assembler.
    /// </summary>
    private ulong inputAssemblerVertices;

    /// <summary>
    /// The number of primitives read by the input assembler.
    /// </summary>
    private ulong inputAssemblerPrimitives;

    /// <summary>
    /// The number of times a vertex shader was invoked.
    /// </summary>
    private ulong vertexShaderInvocations;

    /// <summary>
    /// The number of times a geometry shader was invoked.
    /// </summary>
    private ulong geometryShaderInvocations;

    /// <summary>
    /// The number of primitives output by a geometry shader.
    /// </summary>
    private ulong geometryShaderPrimitives;

    /// <summary>
    /// The number of primitives that were sent to the rasterizer.
    /// </summary>
    private ulong rasterizerInvocations;

    /// <summary>
    /// The number of primitives that were rendered.
    /// </summary>
    private ulong rasterizerPrimitives;

    /// <summary>
    /// The number of times a pixel shader was invoked.
    /// </summary>
    private ulong pixelShaderInvocations;

    /// <summary>
    /// The number of times a hull shader was invoked.
    /// </summary>
    private ulong hullShaderInvocations;

    /// <summary>
    /// The number of times a domain shader was invoked.
    /// </summary>
    private ulong domainShaderInvocations;

    /// <summary>
    /// The number of times a compute shader was invoked.
    /// </summary>
    private ulong computeShaderInvocations;

    /// <summary>
    /// Gets the number of vertices read by input assembler.
    /// </summary>
    public ulong InputAssemblerVertices
    {
        get { return this.inputAssemblerVertices; }
    }

    /// <summary>
    /// Gets the number of primitives read by the input assembler.
    /// </summary>
    public ulong InputAssemblerPrimitives
    {
        get { return this.inputAssemblerPrimitives; }
    }

    /// <summary>
    /// Gets the number of times a vertex shader was invoked.
    /// </summary>
    public ulong VertexShaderInvocations
    {
        get { return this.vertexShaderInvocations; }
    }

    /// <summary>
    /// Gets the number of times a geometry shader was invoked.
    /// </summary>
    public ulong GeometryShaderInvocations
    {
        get { return this.vertexShaderInvocations; }
    }

    /// <summary>
    /// Gets the number of primitives output by a geometry shader.
    /// </summary>
    public ulong GeometryShaderPrimitives
    {
        get { return this.geometryShaderPrimitives; }
    }

    /// <summary>
    /// Gets the number of primitives that were sent to the rasterizer.
    /// </summary>
    public ulong RasterizerInvocations
    {
        get { return this.rasterizerInvocations; }
    }

    /// <summary>
    /// Gets the number of primitives that were rendered.
    /// </summary>
    public ulong RasterizerPrimitives
    {
        get { return this.rasterizerPrimitives; }
    }

    /// <summary>
    /// Gets the number of times a pixel shader was invoked.
    /// </summary>
    public ulong PixelShaderInvocations
    {
        get { return this.pixelShaderInvocations; }
    }

    /// <summary>
    /// Gets the number of times a hull shader was invoked.
    /// </summary>
    public ulong HullShaderInvocations
    {
        get { return this.hullShaderInvocations; }
    }

    /// <summary>
    /// Gets the number of times a domain shader was invoked.
    /// </summary>
    public ulong DomainShaderInvocations
    {
        get { return this.domainShaderInvocations; }
    }

    /// <summary>
    /// Gets the number of times a compute shader was invoked.
    /// </summary>
    public ulong ComputeShaderInvocations
    {
        get { return this.computeShaderInvocations; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11QueryDataPipelineStatistics left, D3D11QueryDataPipelineStatistics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11QueryDataPipelineStatistics left, D3D11QueryDataPipelineStatistics right)
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
        return obj is D3D11QueryDataPipelineStatistics statistics && Equals(statistics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11QueryDataPipelineStatistics other)
    {
        return inputAssemblerVertices == other.inputAssemblerVertices &&
               inputAssemblerPrimitives == other.inputAssemblerPrimitives &&
               vertexShaderInvocations == other.vertexShaderInvocations &&
               geometryShaderInvocations == other.geometryShaderInvocations &&
               geometryShaderPrimitives == other.geometryShaderPrimitives &&
               rasterizerInvocations == other.rasterizerInvocations &&
               rasterizerPrimitives == other.rasterizerPrimitives &&
               pixelShaderInvocations == other.pixelShaderInvocations &&
               hullShaderInvocations == other.hullShaderInvocations &&
               domainShaderInvocations == other.domainShaderInvocations &&
               computeShaderInvocations == other.computeShaderInvocations;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 273822372;
        hashCode = hashCode * -1521134295 + inputAssemblerVertices.GetHashCode();
        hashCode = hashCode * -1521134295 + inputAssemblerPrimitives.GetHashCode();
        hashCode = hashCode * -1521134295 + vertexShaderInvocations.GetHashCode();
        hashCode = hashCode * -1521134295 + geometryShaderInvocations.GetHashCode();
        hashCode = hashCode * -1521134295 + geometryShaderPrimitives.GetHashCode();
        hashCode = hashCode * -1521134295 + rasterizerInvocations.GetHashCode();
        hashCode = hashCode * -1521134295 + rasterizerPrimitives.GetHashCode();
        hashCode = hashCode * -1521134295 + pixelShaderInvocations.GetHashCode();
        hashCode = hashCode * -1521134295 + hullShaderInvocations.GetHashCode();
        hashCode = hashCode * -1521134295 + domainShaderInvocations.GetHashCode();
        hashCode = hashCode * -1521134295 + computeShaderInvocations.GetHashCode();
        return hashCode;
    }
}
