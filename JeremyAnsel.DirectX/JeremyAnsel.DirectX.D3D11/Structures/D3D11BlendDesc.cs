// <copyright file="D3D11BlendDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes the blend state that you use in a call to <see cref="D3D11Device.CreateBlendState"/> to create a blend-state object.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11BlendDesc : IEquatable<D3D11BlendDesc>
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
        size += D3D11RenderTargetBlendDesc8.TotalSize;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11BlendDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11BlendDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11BlendDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isAlphaToCoverageEnabled);
            DXMarshal.Write(ref buffer, obj.isIndependentBlendEnabled);

            fixed (byte* ptr = obj.renderTargets.Buffer)
            {
                DXMarshal.Write(ref buffer, new ReadOnlySpan<byte>(ptr, D3D11RenderTargetBlendDesc8.TotalSize));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11BlendDesc NativeReadFrom(nint buffer)
    {
        D3D11BlendDesc obj;
        obj.isAlphaToCoverageEnabled = DXMarshal.ReadBool(ref buffer);
        obj.isIndependentBlendEnabled = DXMarshal.ReadBool(ref buffer);
        DXMarshal.ReadSpanByte(ref buffer, new Span<byte>(obj.renderTargets.Buffer, D3D11RenderTargetBlendDesc8.TotalSize));
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11BlendDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    private struct D3D11RenderTargetBlendDesc8
    {
        public fixed byte Buffer[TotalSize];
        public const int Length = 8;
        public const int TotalSize = (sizeof(int) + sizeof(int) * 6 + sizeof(byte)) * Length;
    }

    /// <summary>
    /// Specifies whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target.
    /// </summary>
    private bool isAlphaToCoverageEnabled;

    /// <summary>
    /// Specifies whether to enable independent blending in simultaneous render targets.
    /// </summary>
    private bool isIndependentBlendEnabled;

    /// <summary>
    /// An array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
    /// </summary>
    private D3D11RenderTargetBlendDesc8 renderTargets;

    /// <summary>
    /// Gets default blend-state values.
    /// </summary>
    public static D3D11BlendDesc Default
    {
        get
        {
            D3D11RenderTargetBlendDesc defaultRenderTargetBlendDesc = new()
            {
                IsBlendEnabled = false,
                SourceBlend = D3D11BlendValue.One,
                DestinationBlend = D3D11BlendValue.Zero,
                BlendOperation = D3D11BlendOperation.Add,
                SourceBlendAlpha = D3D11BlendValue.One,
                DestinationBlendAlpha = D3D11BlendValue.Zero,
                BlendOperationAlpha = D3D11BlendOperation.Add,
                RenderTargetWriteMask = D3D11ColorWriteEnables.All
            };

            D3D11BlendDesc desc = new()
            {
                isAlphaToCoverageEnabled = false,
                isIndependentBlendEnabled = false,
            };

            desc.FillRenderTargets(defaultRenderTargetBlendDesc);

            return desc;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target.
    /// </summary>
    public bool IsAlphaToCoverageEnabled
    {
        get { return this.isAlphaToCoverageEnabled; }
        set { this.isAlphaToCoverageEnabled = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to enable independent blending in simultaneous render targets.
    /// </summary>
    public bool IsIndependentBlendEnabled
    {
        get { return this.isIndependentBlendEnabled; }
        set { this.isIndependentBlendEnabled = value; }
    }

    /// <summary>
    /// Gets the count of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
    /// </summary>
    public const int RenderTargetsLength = D3D11RenderTargetBlendDesc8.Length;

    /// <summary>
    /// Gets an array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
    /// </summary>
    /// <returns>An array of <see cref="D3D11RenderTargetBlendDesc"/> structures.</returns>
    public readonly D3D11RenderTargetBlendDesc[] GetRenderTargets()
    {
        var renderTargets = new D3D11RenderTargetBlendDesc[D3D11RenderTargetBlendDesc8.Length];
        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            new ReadOnlySpan<D3D11RenderTargetBlendDesc>(ptr, D3D11RenderTargetBlendDesc8.Length)
                .CopyTo(renderTargets.AsSpan());
        }

        return renderTargets;
    }

    /// <summary>
    /// Gets an array as span of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
    /// </summary>
    /// <returns>An array of <see cref="D3D11RenderTargetBlendDesc"/> structures.</returns>
    public readonly Span<D3D11RenderTargetBlendDesc> GetRenderTargetsAsSpan()
    {
        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            return new Span<D3D11RenderTargetBlendDesc>(ptr, D3D11RenderTargetBlendDesc8.Length);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public readonly D3D11RenderTargetBlendDesc GetRenderTarget(int index)
    {
        if (index < 0 || index >= D3D11RenderTargetBlendDesc8.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            return D3D11RenderTargetBlendDesc.NativeReadFrom((nint)ptr + D3D11RenderTargetBlendDesc.NativeRequiredSize(index));
        }
    }

    /// <summary>
    /// Sets an array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
    /// </summary>
    /// <param name="blendDescs">The blend states descriptions.</param>
    public void SetRenderTargets(D3D11RenderTargetBlendDesc[]? blendDescs)
    {
        if (blendDescs == null)
        {
            throw new ArgumentNullException(nameof(blendDescs));
        }

        if (blendDescs.Length != D3D11RenderTargetBlendDesc8.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(blendDescs));
        }

        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            blendDescs.AsSpan()
                .CopyTo(new Span<D3D11RenderTargetBlendDesc>(ptr, D3D11RenderTargetBlendDesc8.Length));
        }
    }

    /// <summary>
    /// Sets an array of <see cref="D3D11RenderTargetBlendDesc"/> structures that describe the blend states for render targets.
    /// </summary>
    /// <param name="blendDescs">The blend states descriptions.</param>
    public void SetRenderTargets(ReadOnlySpan<D3D11RenderTargetBlendDesc> blendDescs)
    {
        if (blendDescs.Length != D3D11RenderTargetBlendDesc8.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(blendDescs));
        }

        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            blendDescs.CopyTo(new Span<D3D11RenderTargetBlendDesc>(ptr, D3D11RenderTargetBlendDesc8.Length));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="blendDesc"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void SetRenderTarget(int index, in D3D11RenderTargetBlendDesc blendDesc)
    {
        if (index < 0 || index >= D3D11RenderTargetBlendDesc8.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            D3D11RenderTargetBlendDesc.NativeWriteTo((nint)ptr + D3D11RenderTargetBlendDesc.NativeRequiredSize(index), blendDesc);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="blendDesc"></param>
    public void FillRenderTargets(in D3D11RenderTargetBlendDesc blendDesc)
    {
        fixed (byte* ptr = this.renderTargets.Buffer)
        {
            int size = D3D11RenderTargetBlendDesc.NativeRequiredSize();
            nint buffer = (nint)ptr;

            for (int index = 0; index < D3D11RenderTargetBlendDesc8.Length; index++)
            {
                D3D11RenderTargetBlendDesc.NativeWriteTo(buffer, blendDesc);
                buffer += size;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11BlendDesc left, D3D11BlendDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11BlendDesc left, D3D11BlendDesc right)
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
        return obj is D3D11BlendDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11BlendDesc other)
    {
        fixed (byte* ptrThis = renderTargets.Buffer)
        {
            ReadOnlySpan<D3D11RenderTargetBlendDesc> spanThis = new(ptrThis, D3D11RenderTargetBlendDesc8.Length);
            ReadOnlySpan<D3D11RenderTargetBlendDesc> spanOther = new(other.renderTargets.Buffer, D3D11RenderTargetBlendDesc8.Length);

            return isAlphaToCoverageEnabled == other.isAlphaToCoverageEnabled &&
                   isIndependentBlendEnabled == other.isIndependentBlendEnabled &&
                   spanThis.SequenceEqual(spanOther);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 318118871;
        hashCode = hashCode * -1521134295 + isAlphaToCoverageEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + isIndependentBlendEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + renderTargets.GetHashCode();
        return hashCode;
    }
}
