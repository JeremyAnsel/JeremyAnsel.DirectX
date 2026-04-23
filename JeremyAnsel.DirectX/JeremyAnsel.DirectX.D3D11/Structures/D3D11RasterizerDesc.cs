// <copyright file="D3D11RasterizerDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes rasterizer state.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11RasterizerDesc : IEquatable<D3D11RasterizerDesc>
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
        size += sizeof(int) * 5;
        size += sizeof(int);
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11RasterizerDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11RasterizerDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11RasterizerDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.fillMode);
            DXMarshal.Write(ref buffer, (int)obj.cullMode);
            DXMarshal.Write(ref buffer, obj.isFrontCounterClockwise);
            DXMarshal.Write(ref buffer, obj.depthBias);
            DXMarshal.Write(ref buffer, obj.depthBiasClamp);
            DXMarshal.Write(ref buffer, obj.slopeScaledDepthBias);
            DXMarshal.Write(ref buffer, obj.isDepthClipEnabled);
            DXMarshal.Write(ref buffer, obj.isScissorEnabled);
            DXMarshal.Write(ref buffer, obj.isMultisampleEnabled);
            DXMarshal.Write(ref buffer, obj.isAntialiasedLineEnabled);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11RasterizerDesc NativeReadFrom(nint buffer)
    {
        D3D11RasterizerDesc obj;
        obj.fillMode = (D3D11FillMode)DXMarshal.ReadInt32(ref buffer);
        obj.cullMode = (D3D11CullMode)DXMarshal.ReadInt32(ref buffer);
        obj.isFrontCounterClockwise = DXMarshal.ReadBool(ref buffer);
        obj.depthBias = DXMarshal.ReadInt32(ref buffer);
        obj.depthBiasClamp = DXMarshal.ReadSingle(ref buffer);
        obj.slopeScaledDepthBias = DXMarshal.ReadSingle(ref buffer);
        obj.isDepthClipEnabled = DXMarshal.ReadBool(ref buffer);
        obj.isScissorEnabled = DXMarshal.ReadBool(ref buffer);
        obj.isMultisampleEnabled = DXMarshal.ReadBool(ref buffer);
        obj.isAntialiasedLineEnabled = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11RasterizerDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Determines the fill mode to use when rendering.
    /// </summary>
    private D3D11FillMode fillMode;

    /// <summary>
    /// Indicates whether triangles facing the specified direction are not drawn.
    /// </summary>
    private D3D11CullMode cullMode;

    /// <summary>
    /// Determines if a triangle is front- or back-facing.
    /// </summary>
    private bool isFrontCounterClockwise;

    /// <summary>
    /// The depth value added to a given pixel.
    /// </summary>
    private int depthBias;

    /// <summary>
    /// The maximum depth bias of a pixel.
    /// </summary>
    private float depthBiasClamp;

    /// <summary>
    /// The scalar on a given pixel's slope.
    /// </summary>
    private float slopeScaledDepthBias;

    /// <summary>
    /// Specifies whether clipping based on distance is enabled.
    /// </summary>
    private bool isDepthClipEnabled;

    /// <summary>
    /// Specifies whether scissor-rectangle culling is enabled.
    /// </summary>
    private bool isScissorEnabled;

    /// <summary>
    /// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.
    /// </summary>
    private bool isMultisampleEnabled;

    /// <summary>
    /// Specifies whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>false</c>.
    /// </summary>
    private bool isAntialiasedLineEnabled;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RasterizerDesc"/> struct.
    /// </summary>
    /// <param name="fillMode">Determines the fill mode to use when rendering.</param>
    /// <param name="cullMode">Indicates whether triangles facing the specified direction are not drawn.</param>
    /// <param name="isFrontCounterClockwise">Determines if a triangle is front- or back-facing.</param>
    /// <param name="depthBias">The depth value added to a given pixel.</param>
    /// <param name="depthBiasClamp">The maximum depth bias of a pixel.</param>
    /// <param name="slopeScaledDepthBias">The scalar on a given pixel's slope.</param>
    /// <param name="isDepthClipEnabled">Specifies whether clipping based on distance is enabled.</param>
    /// <param name="isScissorEnabled">Specifies whether scissor-rectangle culling is enabled.</param>
    /// <param name="isMultisampleEnabled">Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.</param>
    /// <param name="isAntialiasedLineEnabled">Specifies whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>false</c>.</param>
    public D3D11RasterizerDesc(
        D3D11FillMode fillMode,
        D3D11CullMode cullMode,
        bool isFrontCounterClockwise,
        int depthBias,
        float depthBiasClamp,
        float slopeScaledDepthBias,
        bool isDepthClipEnabled,
        bool isScissorEnabled,
        bool isMultisampleEnabled,
        bool isAntialiasedLineEnabled)
    {
        this.fillMode = fillMode;
        this.cullMode = cullMode;
        this.isFrontCounterClockwise = isFrontCounterClockwise;
        this.depthBias = depthBias;
        this.depthBiasClamp = depthBiasClamp;
        this.slopeScaledDepthBias = slopeScaledDepthBias;
        this.isDepthClipEnabled = isDepthClipEnabled;
        this.isScissorEnabled = isScissorEnabled;
        this.isMultisampleEnabled = isMultisampleEnabled;
        this.isAntialiasedLineEnabled = isAntialiasedLineEnabled;
    }

    /// <summary>
    /// Gets default rasterizer-state values.
    /// </summary>
    public static D3D11RasterizerDesc Default
    {
        get
        {
            return new D3D11RasterizerDesc(
                D3D11FillMode.Solid,
                D3D11CullMode.Back,
                false,
                0,
                0.0f,
                0.0f,
                true,
                false,
                false,
                false);
        }
    }

    /// <summary>
    /// Gets or sets the fill mode to use when rendering.
    /// </summary>
    public D3D11FillMode FillMode
    {
        get { return this.fillMode; }
        set { this.fillMode = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether triangles facing the specified direction are not drawn.
    /// </summary>
    public D3D11CullMode CullMode
    {
        get { return this.cullMode; }
        set { this.cullMode = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a triangle is front- or back-facing.
    /// </summary>
    public bool IsFrontCounterClockwise
    {
        get { return this.isFrontCounterClockwise; }
        set { this.isFrontCounterClockwise = value; }
    }

    /// <summary>
    /// Gets or sets the depth value added to a given pixel.
    /// </summary>
    public int DepthBias
    {
        get { return this.depthBias; }
        set { this.depthBias = value; }
    }

    /// <summary>
    /// Gets or sets the maximum depth bias of a pixel.
    /// </summary>
    public float DepthBiasClamp
    {
        get { return this.depthBiasClamp; }
        set { this.depthBiasClamp = value; }
    }

    /// <summary>
    /// Gets or sets the scalar on a given pixel's slope.
    /// </summary>
    public float SlopeScaledDepthBias
    {
        get { return this.slopeScaledDepthBias; }
        set { this.slopeScaledDepthBias = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether clipping based on distance is enabled.
    /// </summary>
    public bool IsDepthClipEnabled
    {
        get { return this.isDepthClipEnabled; }
        set { this.isDepthClipEnabled = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether scissor-rectangle culling is enabled.
    /// </summary>
    public bool IsScissorEnabled
    {
        get { return this.isScissorEnabled; }
        set { this.isScissorEnabled = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render targets.
    /// </summary>
    public bool IsMultisampleEnabled
    {
        get { return this.isMultisampleEnabled; }
        set { this.isMultisampleEnabled = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>false</c>.
    /// </summary>
    public bool IsAntialiasedLineEnabled
    {
        get { return this.isAntialiasedLineEnabled; }
        set { this.isAntialiasedLineEnabled = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11RasterizerDesc left, D3D11RasterizerDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11RasterizerDesc left, D3D11RasterizerDesc right)
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
        return obj is D3D11RasterizerDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11RasterizerDesc other)
    {
        return fillMode == other.fillMode &&
               cullMode == other.cullMode &&
               isFrontCounterClockwise == other.isFrontCounterClockwise &&
               depthBias == other.depthBias &&
               depthBiasClamp == other.depthBiasClamp &&
               slopeScaledDepthBias == other.slopeScaledDepthBias &&
               isDepthClipEnabled == other.isDepthClipEnabled &&
               isScissorEnabled == other.isScissorEnabled &&
               isMultisampleEnabled == other.isMultisampleEnabled &&
               isAntialiasedLineEnabled == other.isAntialiasedLineEnabled;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1359136547;
        hashCode = hashCode * -1521134295 + fillMode.GetHashCode();
        hashCode = hashCode * -1521134295 + cullMode.GetHashCode();
        hashCode = hashCode * -1521134295 + isFrontCounterClockwise.GetHashCode();
        hashCode = hashCode * -1521134295 + depthBias.GetHashCode();
        hashCode = hashCode * -1521134295 + depthBiasClamp.GetHashCode();
        hashCode = hashCode * -1521134295 + slopeScaledDepthBias.GetHashCode();
        hashCode = hashCode * -1521134295 + isDepthClipEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + isScissorEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + isMultisampleEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + isAntialiasedLineEnabled.GetHashCode();
        return hashCode;
    }
}
