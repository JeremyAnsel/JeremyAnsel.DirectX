// <copyright file="D3D11DepthStencilOperationDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Stencil operations that can be performed based on the results of stencil test.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11DepthStencilOperationDesc : IEquatable<D3D11DepthStencilOperationDesc>
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
    public static void NativeWriteTo(nint buffer, in D3D11DepthStencilOperationDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11DepthStencilOperationDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11DepthStencilOperationDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.stencilFailOperation);
            DXMarshal.Write(ref buffer, (int)obj.stencilDepthFailOperation);
            DXMarshal.Write(ref buffer, (int)obj.stencilPassOperation);
            DXMarshal.Write(ref buffer, (int)obj.stencilFunction);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11DepthStencilOperationDesc NativeReadFrom(nint buffer)
    {
        D3D11DepthStencilOperationDesc obj;
        obj.stencilFailOperation = (D3D11StencilOperation)DXMarshal.ReadInt32(ref buffer);
        obj.stencilDepthFailOperation = (D3D11StencilOperation)DXMarshal.ReadInt32(ref buffer);
        obj.stencilPassOperation = (D3D11StencilOperation)DXMarshal.ReadInt32(ref buffer);
        obj.stencilFunction = (D3D11ComparisonFunction)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11DepthStencilOperationDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The stencil operation to perform when stencil testing fails.
    /// </summary>
    private D3D11StencilOperation stencilFailOperation;

    /// <summary>
    /// The stencil operation to perform when stencil testing passes and depth testing fails.
    /// </summary>
    private D3D11StencilOperation stencilDepthFailOperation;

    /// <summary>
    /// The stencil operation to perform when stencil testing and depth testing both pass.
    /// </summary>
    private D3D11StencilOperation stencilPassOperation;

    /// <summary>
    /// A function that compares stencil data against existing stencil data.
    /// </summary>
    private D3D11ComparisonFunction stencilFunction;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stencilFailOperation"></param>
    /// <param name="stencilDepthFailOperation"></param>
    /// <param name="stencilPassOperation"></param>
    /// <param name="stencilFunction"></param>
    public D3D11DepthStencilOperationDesc(
        D3D11StencilOperation stencilFailOperation,
        D3D11StencilOperation stencilDepthFailOperation,
        D3D11StencilOperation stencilPassOperation,
        D3D11ComparisonFunction stencilFunction)
    {
        this.stencilFailOperation = stencilFailOperation;
        this.stencilDepthFailOperation = stencilDepthFailOperation;
        this.stencilPassOperation = stencilPassOperation;
        this.stencilFunction = stencilFunction;
    }

    /// <summary>
    /// Gets or sets the stencil operation to perform when stencil testing fails.
    /// </summary>
    public D3D11StencilOperation StencilFailOperation
    {
        get { return this.stencilFailOperation; }
        set { this.stencilFailOperation = value; }
    }

    /// <summary>
    /// Gets or sets the stencil operation to perform when stencil testing passes and depth testing fails.
    /// </summary>
    public D3D11StencilOperation StencilDepthFailOperation
    {
        get { return this.stencilDepthFailOperation; }
        set { this.stencilDepthFailOperation = value; }
    }

    /// <summary>
    /// Gets or sets the stencil operation to perform when stencil testing and depth testing both pass.
    /// </summary>
    public D3D11StencilOperation StencilPassOperation
    {
        get { return this.stencilPassOperation; }
        set { this.stencilPassOperation = value; }
    }

    /// <summary>
    /// Gets or sets a function that compares stencil data against existing stencil data.
    /// </summary>
    public D3D11ComparisonFunction StencilFunction
    {
        get { return this.stencilFunction; }
        set { this.stencilFunction = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11DepthStencilOperationDesc left, D3D11DepthStencilOperationDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11DepthStencilOperationDesc left, D3D11DepthStencilOperationDesc right)
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
        return obj is D3D11DepthStencilOperationDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11DepthStencilOperationDesc other)
    {
        return stencilFailOperation == other.stencilFailOperation &&
               stencilDepthFailOperation == other.stencilDepthFailOperation &&
               stencilPassOperation == other.stencilPassOperation &&
               stencilFunction == other.stencilFunction;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1696205973;
        hashCode = hashCode * -1521134295 + stencilFailOperation.GetHashCode();
        hashCode = hashCode * -1521134295 + stencilDepthFailOperation.GetHashCode();
        hashCode = hashCode * -1521134295 + stencilPassOperation.GetHashCode();
        hashCode = hashCode * -1521134295 + stencilFunction.GetHashCode();
        return hashCode;
    }
}
