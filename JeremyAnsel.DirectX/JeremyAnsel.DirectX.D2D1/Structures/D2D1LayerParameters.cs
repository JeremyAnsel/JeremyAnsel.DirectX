// <copyright file="D2D1LayerParameters.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the content bounds, mask information, opacity settings, and other options for a layer resource.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1LayerParameters : IEquatable<D2D1LayerParameters>
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
        size += D2D1RectF.NativeRequiredSize();
        size += sizeof(nint) * 2;
        size += sizeof(int) * 2; // enum
        size += D2D1Matrix3X2F.NativeRequiredSize();
        size += sizeof(float);
        size += DXMarshal.PaddingSize();
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1LayerParameters obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1LayerParameters>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1LayerParameters> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1RectF.NativeWriteTo(buffer, obj.contentBounds);
            buffer += D2D1RectF.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.geometricMask);
            DXMarshal.Write(ref buffer, (int)obj.maskAntialiasMode);
            D2D1Matrix3X2F.NativeWriteTo(buffer, obj.maskTransform);
            buffer += D2D1Matrix3X2F.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.opacity);
            DXMarshal.Write(ref buffer, obj.opacityBrush);
            DXMarshal.Write(ref buffer, (int)obj.layerOptions);
            DXMarshal.WritePadding(ref buffer);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1LayerParameters NativeReadFrom(nint buffer)
    {
        D2D1LayerParameters obj;
        obj.contentBounds = D2D1RectF.NativeReadFrom(buffer);
        buffer += D2D1RectF.NativeRequiredSize();
        obj.geometricMask = DXMarshal.ReadIntPtr(ref buffer);
        obj.maskAntialiasMode = (D2D1AntialiasMode)DXMarshal.ReadInt32(ref buffer);
        obj.maskTransform = D2D1Matrix3X2F.NativeReadFrom(buffer);
        buffer += D2D1Matrix3X2F.NativeRequiredSize();
        obj.opacity = DXMarshal.ReadSingle(ref buffer);
        obj.opacityBrush = DXMarshal.ReadIntPtr(ref buffer);
        obj.layerOptions = (D2D1LayerOptions)DXMarshal.ReadInt32(ref buffer);
        buffer += DXMarshal.PaddingSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1LayerParameters> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The content bounds of the layer. Content outside these bounds is not guaranteed to render.
    /// </summary>
    private D2D1RectF contentBounds;

    /// <summary>
    /// The geometric mask specifies the area of the layer that is composited into the render target.
    /// </summary>
    private nint geometricMask;

    /// <summary>
    /// A value that specifies the antialiasing mode for the geometricMask.
    /// </summary>
    private D2D1AntialiasMode maskAntialiasMode;

    /// <summary>
    /// A value that specifies the transform that is applied to the geometric mask when composing the layer.
    /// </summary>
    private D2D1Matrix3X2F maskTransform;

    /// <summary>
    /// An opacity value that is applied uniformly to all resources in the layer when compositing to the target.
    /// </summary>
    private float opacity;

    /// <summary>
    /// A brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush pixel is multiplied against the corresponding layer pixel.
    /// </summary>
    private nint opacityBrush;

    /// <summary>
    /// A value that specifies whether the layer intends to render text with ClearType antialiasing.
    /// </summary>
    private D2D1LayerOptions layerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1LayerParameters"/> struct.
    /// </summary>
    /// <param name="contentBounds">The content bounds of the layer. Content outside these bounds is not guaranteed to render.</param>
    /// <param name="geometricMask">The geometric mask specifies the area of the layer that is composited into the render target.</param>
    /// <param name="maskAntialiasMode">A value that specifies the antialiasing mode for the geometricMask.</param>
    /// <param name="maskTransform">A value that specifies the transform that is applied to the geometric mask when composing the layer.</param>
    /// <param name="opacity">An opacity value that is applied uniformly to all resources in the layer when compositing to the target.</param>
    /// <param name="opacityBrush">A brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush pixel is multiplied against the corresponding layer pixel.</param>
    /// <param name="layerOptions">A value that specifies whether the layer intends to render text with ClearType antialiasing.</param>
    public D2D1LayerParameters(
        in D2D1RectF contentBounds,
        D2D1Geometry? geometricMask,
        D2D1AntialiasMode maskAntialiasMode,
        in D2D1Matrix3X2F maskTransform,
        float opacity,
        D2D1Brush? opacityBrush,
        D2D1LayerOptions layerOptions)
    {
        this.contentBounds = contentBounds;
        this.geometricMask = geometricMask is null ? 0 : geometricMask.Handle;
        this.maskAntialiasMode = maskAntialiasMode;
        this.maskTransform = maskTransform;
        this.opacity = opacity;
        this.opacityBrush = opacityBrush is null ? 0 : opacityBrush.Handle;
        this.layerOptions = layerOptions;
    }

    /// <summary>
    /// Gets default parameters.
    /// </summary>
    public static D2D1LayerParameters Default
    {
        get { return new D2D1LayerParameters(D2D1RectF.Infinite, null, D2D1AntialiasMode.PerPrimitive, D2D1Matrix3X2F.Identity, 1.0f, null, D2D1LayerOptions.None); }
    }

    /// <summary>
    /// Gets or sets the content bounds of the layer. Content outside these bounds is not guaranteed to render.
    /// </summary>
    public D2D1RectF ContentBounds
    {
        get { return this.contentBounds; }
        set { this.contentBounds = value; }
    }

    /// <summary>
    /// Gets or sets the geometric mask specifies the area of the layer that is composited into the render target.
    /// </summary>
    public D2D1Geometry? GeometricMask
    {
        get
        {
            return this.geometricMask == 0 ? null : new D2D1Geometry(this.geometricMask);
        }

        set
        {
            this.geometricMask = value is null ? 0 : value.Handle;
        }
    }

    /// <summary>
    /// Gets or sets a value that specifies the antialiasing mode for the geometricMask.
    /// </summary>
    public D2D1AntialiasMode MaskAntialiasMode
    {
        get { return this.maskAntialiasMode; }
        set { this.maskAntialiasMode = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies the transform that is applied to the geometric mask when composing the layer.
    /// </summary>
    public D2D1Matrix3X2F MaskTransform
    {
        get { return this.maskTransform; }
        set { this.maskTransform = value; }
    }

    /// <summary>
    /// Gets or sets an opacity value that is applied uniformly to all resources in the layer when compositing to the target.
    /// </summary>
    public float Opacity
    {
        get { return this.opacity; }
        set { this.opacity = value; }
    }

    /// <summary>
    /// Gets or sets a brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush pixel is multiplied against the corresponding layer pixel.
    /// </summary>
    public D2D1Brush? OpacityBrush
    {
        get
        {
            return this.opacityBrush == 0 ? null : new D2D1Brush(this.opacityBrush);
        }

        set
        {
            this.opacityBrush = value is null ? 0 : value.Handle;
        }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the layer intends to render text with ClearType antialiasing.
    /// </summary>
    public D2D1LayerOptions LayerOptions
    {
        get { return this.layerOptions; }
        set { this.layerOptions = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1LayerParameters left, D2D1LayerParameters right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1LayerParameters left, D2D1LayerParameters right)
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
        return obj is D2D1LayerParameters parameters && Equals(parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1LayerParameters other)
    {
        return contentBounds.Equals(other.contentBounds) &&
               EqualityComparer<nint>.Default.Equals(geometricMask, other.geometricMask) &&
               maskAntialiasMode == other.maskAntialiasMode &&
               maskTransform.Equals(other.maskTransform) &&
               opacity == other.opacity &&
               EqualityComparer<nint>.Default.Equals(opacityBrush, other.opacityBrush) &&
               layerOptions == other.layerOptions;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1551779696;
        hashCode = hashCode * -1521134295 + contentBounds.GetHashCode();
        hashCode = hashCode * -1521134295 + geometricMask.GetHashCode();
        hashCode = hashCode * -1521134295 + maskAntialiasMode.GetHashCode();
        hashCode = hashCode * -1521134295 + maskTransform.GetHashCode();
        hashCode = hashCode * -1521134295 + opacity.GetHashCode();
        hashCode = hashCode * -1521134295 + opacityBrush.GetHashCode();
        hashCode = hashCode * -1521134295 + layerOptions.GetHashCode();
        return hashCode;
    }
}
