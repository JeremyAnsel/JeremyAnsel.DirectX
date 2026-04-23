// <copyright file="D3D11RenderTargetBlendDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes the blend state for a render target.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11RenderTargetBlendDesc : IEquatable<D3D11RenderTargetBlendDesc>
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
        size += sizeof(int) * 6;
        size += sizeof(byte);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11RenderTargetBlendDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11RenderTargetBlendDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11RenderTargetBlendDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isBlendEnabled);
            DXMarshal.Write(ref buffer, (int)obj.sourceBlend);
            DXMarshal.Write(ref buffer, (int)obj.destinationBlend);
            DXMarshal.Write(ref buffer, (int)obj.blendOperation);
            DXMarshal.Write(ref buffer, (int)obj.sourceBlendAlpha);
            DXMarshal.Write(ref buffer, (int)obj.destinationBlendAlpha);
            DXMarshal.Write(ref buffer, (int)obj.blendOperationAlpha);
            DXMarshal.Write(ref buffer, (byte)obj.renderTargetWriteMask);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11RenderTargetBlendDesc NativeReadFrom(nint buffer)
    {
        D3D11RenderTargetBlendDesc obj;
        obj.isBlendEnabled = DXMarshal.ReadBool(ref buffer);
        obj.sourceBlend = (D3D11BlendValue)DXMarshal.ReadInt32(ref buffer);
        obj.destinationBlend = (D3D11BlendValue)DXMarshal.ReadInt32(ref buffer);
        obj.blendOperation = (D3D11BlendOperation)DXMarshal.ReadInt32(ref buffer);
        obj.sourceBlendAlpha = (D3D11BlendValue)DXMarshal.ReadInt32(ref buffer);
        obj.destinationBlendAlpha = (D3D11BlendValue)DXMarshal.ReadInt32(ref buffer);
        obj.blendOperationAlpha = (D3D11BlendOperation)DXMarshal.ReadInt32(ref buffer);
        obj.renderTargetWriteMask = (D3D11ColorWriteEnables)DXMarshal.ReadByte(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11RenderTargetBlendDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Specifies whether blending is enabled.
    /// </summary>
    private bool isBlendEnabled;

    /// <summary>
    /// The operation to perform on the RGB value that the pixel shader outputs.
    /// </summary>
    private D3D11BlendValue sourceBlend;

    /// <summary>
    /// The operation to perform on the current RGB value in the render target.
    /// </summary>
    private D3D11BlendValue destinationBlend;

    /// <summary>
    /// Defines how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.
    /// </summary>
    private D3D11BlendOperation blendOperation;

    /// <summary>
    /// The operation to perform on the alpha value that the pixel shader outputs. Blend options that end in <c>_COLOR</c> are not allowed.
    /// </summary>
    private D3D11BlendValue sourceBlendAlpha;

    /// <summary>
    /// The operation to perform on the current alpha value in the render target. Blend options that end in <c>_COLOR</c> are not allowed.
    /// </summary>
    private D3D11BlendValue destinationBlendAlpha;

    /// <summary>
    /// Defines how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.
    /// </summary>
    private D3D11BlendOperation blendOperationAlpha;

    /// <summary>
    /// A write mask.
    /// </summary>
    private D3D11ColorWriteEnables renderTargetWriteMask;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isBlendEnabled"></param>
    /// <param name="sourceBlend"></param>
    /// <param name="destinationBlend"></param>
    /// <param name="blendOperation"></param>
    /// <param name="sourceBlendAlpha"></param>
    /// <param name="destinationBlendAlpha"></param>
    /// <param name="blendOperationAlpha"></param>
    /// <param name="renderTargetWriteMask"></param>
    public D3D11RenderTargetBlendDesc(
        bool isBlendEnabled,
        D3D11BlendValue sourceBlend,
        D3D11BlendValue destinationBlend,
        D3D11BlendOperation blendOperation,
        D3D11BlendValue sourceBlendAlpha,
        D3D11BlendValue destinationBlendAlpha,
        D3D11BlendOperation blendOperationAlpha,
        D3D11ColorWriteEnables renderTargetWriteMask)
    {
        this.isBlendEnabled = isBlendEnabled;
        this.sourceBlend = sourceBlend;
        this.destinationBlend = destinationBlend;
        this.blendOperation = blendOperation;
        this.sourceBlendAlpha = sourceBlendAlpha;
        this.destinationBlendAlpha = destinationBlendAlpha;
        this.blendOperationAlpha = blendOperationAlpha;
        this.renderTargetWriteMask = renderTargetWriteMask;
    }

    /// <summary>
    /// Gets or sets a value indicating whether blending is enabled.
    /// </summary>
    public bool IsBlendEnabled
    {
        get { return this.isBlendEnabled; }
        set { this.isBlendEnabled = value; }
    }

    /// <summary>
    /// Gets or sets the operation to perform on the RGB value that the pixel shader outputs.
    /// </summary>
    public D3D11BlendValue SourceBlend
    {
        get { return this.sourceBlend; }
        set { this.sourceBlend = value; }
    }

    /// <summary>
    /// Gets or sets the operation to perform on the current RGB value in the render target.
    /// </summary>
    public D3D11BlendValue DestinationBlend
    {
        get { return this.destinationBlend; }
        set { this.destinationBlend = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.
    /// </summary>
    public D3D11BlendOperation BlendOperation
    {
        get { return this.blendOperation; }
        set { this.blendOperation = value; }
    }

    /// <summary>
    /// Gets or sets the operation to perform on the alpha value that the pixel shader outputs. Blend options that end in <c>_COLOR</c> are not allowed.
    /// </summary>
    public D3D11BlendValue SourceBlendAlpha
    {
        get { return this.sourceBlendAlpha; }
        set { this.sourceBlendAlpha = value; }
    }

    /// <summary>
    /// Gets or sets the operation to perform on the current alpha value in the render target. Blend options that end in <c>_COLOR</c> are not allowed.
    /// </summary>
    public D3D11BlendValue DestinationBlendAlpha
    {
        get { return this.destinationBlendAlpha; }
        set { this.destinationBlendAlpha = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.
    /// </summary>
    public D3D11BlendOperation BlendOperationAlpha
    {
        get { return this.blendOperationAlpha; }
        set { this.blendOperationAlpha = value; }
    }

    /// <summary>
    /// Gets or sets a write mask.
    /// </summary>
    public D3D11ColorWriteEnables RenderTargetWriteMask
    {
        get { return this.renderTargetWriteMask; }
        set { this.renderTargetWriteMask = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11RenderTargetBlendDesc left, D3D11RenderTargetBlendDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11RenderTargetBlendDesc left, D3D11RenderTargetBlendDesc right)
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
        return obj is D3D11RenderTargetBlendDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11RenderTargetBlendDesc other)
    {
        return isBlendEnabled == other.isBlendEnabled &&
               sourceBlend == other.sourceBlend &&
               destinationBlend == other.destinationBlend &&
               blendOperation == other.blendOperation &&
               sourceBlendAlpha == other.sourceBlendAlpha &&
               destinationBlendAlpha == other.destinationBlendAlpha &&
               blendOperationAlpha == other.blendOperationAlpha &&
               renderTargetWriteMask == other.renderTargetWriteMask;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1158357840;
        hashCode = hashCode * -1521134295 + isBlendEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + sourceBlend.GetHashCode();
        hashCode = hashCode * -1521134295 + destinationBlend.GetHashCode();
        hashCode = hashCode * -1521134295 + blendOperation.GetHashCode();
        hashCode = hashCode * -1521134295 + sourceBlendAlpha.GetHashCode();
        hashCode = hashCode * -1521134295 + destinationBlendAlpha.GetHashCode();
        hashCode = hashCode * -1521134295 + blendOperationAlpha.GetHashCode();
        hashCode = hashCode * -1521134295 + renderTargetWriteMask.GetHashCode();
        return hashCode;
    }
}
