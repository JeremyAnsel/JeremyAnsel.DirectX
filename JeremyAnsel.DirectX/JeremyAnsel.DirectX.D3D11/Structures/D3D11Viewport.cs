// <copyright file="D3D11Viewport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Defines the dimensions of a viewport.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Viewport : IEquatable<D3D11Viewport>
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
        size += sizeof(float) * 6;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Viewport obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Viewport>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Viewport> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.topLeftX);
            DXMarshal.Write(ref buffer, obj.topLeftY);
            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, obj.minDepth);
            DXMarshal.Write(ref buffer, obj.maxDepth);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Viewport NativeReadFrom(nint buffer)
    {
        D3D11Viewport obj;
        obj.topLeftX = DXMarshal.ReadSingle(ref buffer);
        obj.topLeftY = DXMarshal.ReadSingle(ref buffer);
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.height = DXMarshal.ReadSingle(ref buffer);
        obj.minDepth = DXMarshal.ReadSingle(ref buffer);
        obj.maxDepth = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Viewport> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The X position of the left hand side of the viewport.
    /// </summary>
    private float topLeftX;

    /// <summary>
    /// The Y position of the top of the viewport.
    /// </summary>
    private float topLeftY;

    /// <summary>
    /// The width of the viewport.
    /// </summary>
    private float width;

    /// <summary>
    /// The height of the viewport.
    /// </summary>
    private float height;

    /// <summary>
    /// The minimum depth of the viewport.
    /// </summary>
    private float minDepth;

    /// <summary>
    /// The maximum depth of the viewport.
    /// </summary>
    private float maxDepth;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="topLeftY">The Y position of the top of the viewport.</param>
    /// <param name="width">The width of the viewport.</param>
    /// <param name="height">The height of the viewport.</param>
    public D3D11Viewport(float topLeftX, float topLeftY, float width, float height)
    {
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
        this.width = width;
        this.height = height;
        this.minDepth = 0.0f;
        this.maxDepth = 1.0f;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="topLeftY">The Y position of the top of the viewport.</param>
    /// <param name="width">The width of the viewport.</param>
    /// <param name="height">The height of the viewport.</param>
    /// <param name="minDepth">The minimum depth of the viewport.</param>
    /// <param name="maxDepth">The maximum depth of the viewport.</param>
    public D3D11Viewport(float topLeftX, float topLeftY, float width, float height, float minDepth, float maxDepth)
    {
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
        this.width = width;
        this.height = height;
        this.minDepth = minDepth;
        this.maxDepth = maxDepth;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="view">The render-target view.</param>
    public D3D11Viewport(D3D11Buffer buffer, D3D11RenderTargetView view)
        : this(buffer, view, 0.0f, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    public D3D11Viewport(D3D11Buffer buffer, D3D11RenderTargetView view, float topLeftX)
        : this(buffer, view, topLeftX, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="minDepth">The minimum depth of the viewport.</param>
    /// <param name="maxDepth">The maximum depth of the viewport.</param>
    public D3D11Viewport(D3D11Buffer buffer, D3D11RenderTargetView view, float topLeftX, float minDepth, float maxDepth)
    {
        if (buffer is null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        if (view is null)
        {
            throw new ArgumentNullException(nameof(view));
        }

        var description = view.Description;
        var numElements = description.ViewDimension switch
        {
            D3D11RtvDimension.Buffer => description.Buffer.NumElements,
            _ => throw new ArgumentOutOfRangeException(nameof(view)),
        };
        this.topLeftX = topLeftX;
        this.topLeftY = 0.0f;
        this.width = numElements - topLeftX;
        this.height = 1.0f;
        this.minDepth = minDepth;
        this.maxDepth = maxDepth;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="view">The render-target view.</param>
    public D3D11Viewport(D3D11Texture1D texture, D3D11RenderTargetView view)
        : this(texture, view, 0.0f, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    public D3D11Viewport(D3D11Texture1D texture, D3D11RenderTargetView view, float topLeftX)
        : this(texture, view, topLeftX, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="minDepth">The minimum depth of the viewport.</param>
    /// <param name="maxDepth">The maximum depth of the viewport.</param>
    public D3D11Viewport(D3D11Texture1D texture, D3D11RenderTargetView view, float topLeftX, float minDepth, float maxDepth)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        if (view is null)
        {
            throw new ArgumentNullException(nameof(view));
        }

        var textureDescription = texture.Description;
        var viewDescription = view.Description;
        var mipSlice = viewDescription.ViewDimension switch
        {
            D3D11RtvDimension.Texture1D => viewDescription.Texture1D.MipSlice,
            D3D11RtvDimension.Texture1DArray => viewDescription.Texture1DArray.MipSlice,
            _ => throw new ArgumentOutOfRangeException(nameof(view)),
        };
        uint subResourceWidth = textureDescription.Width / (uint)(1 << (int)mipSlice);

        this.topLeftX = topLeftX;
        this.topLeftY = 0.0f;
        this.width = (subResourceWidth != 0 ? subResourceWidth : 1) - topLeftX;
        this.height = 1.0f;
        this.minDepth = minDepth;
        this.maxDepth = maxDepth;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="view">The render-target view.</param>
    public D3D11Viewport(D3D11Texture2D texture, D3D11RenderTargetView view)
        : this(texture, view, 0.0f, 0.0f, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="topLeftY">The Y position of the top of the viewport.</param>
    public D3D11Viewport(D3D11Texture2D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY)
        : this(texture, view, topLeftX, topLeftY, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="topLeftY">The Y position of the top of the viewport.</param>
    /// <param name="minDepth">The minimum depth of the viewport.</param>
    /// <param name="maxDepth">The maximum depth of the viewport.</param>
    public D3D11Viewport(D3D11Texture2D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY, float minDepth, float maxDepth)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        if (view is null)
        {
            throw new ArgumentNullException(nameof(view));
        }

        var textureDescription = texture.Description;
        var viewDescription = view.Description;
        var mipSlice = viewDescription.ViewDimension switch
        {
            D3D11RtvDimension.Texture2D => viewDescription.Texture2D.MipSlice,
            D3D11RtvDimension.Texture2DArray => viewDescription.Texture2DArray.MipSlice,
            D3D11RtvDimension.Texture2DMs or D3D11RtvDimension.Texture2DMsArray => (uint)0,
            _ => throw new ArgumentOutOfRangeException(nameof(view)),
        };
        uint subResourceWidth = textureDescription.Width / (uint)(1 << (int)mipSlice);
        uint subResourceHeight = textureDescription.Height / (uint)(1 << (int)mipSlice);

        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
        this.width = (subResourceWidth != 0 ? subResourceWidth : 1) - topLeftX;
        this.height = (subResourceHeight != 0 ? subResourceHeight : 1) - topLeftY;
        this.minDepth = minDepth;
        this.maxDepth = maxDepth;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="view">The render-target view.</param>
    public D3D11Viewport(D3D11Texture3D texture, D3D11RenderTargetView view)
        : this(texture, view, 0.0f, 0.0f, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="topLeftY">The Y position of the top of the viewport.</param>
    public D3D11Viewport(D3D11Texture3D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY)
        : this(texture, view, topLeftX, topLeftY, 0.0f, 1.0f)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Viewport"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="view">The render-target view.</param>
    /// <param name="topLeftX">The X position of the left hand side of the viewport.</param>
    /// <param name="topLeftY">The Y position of the top of the viewport.</param>
    /// <param name="minDepth">The minimum depth of the viewport.</param>
    /// <param name="maxDepth">The maximum depth of the viewport.</param>
    public D3D11Viewport(D3D11Texture3D texture, D3D11RenderTargetView view, float topLeftX, float topLeftY, float minDepth, float maxDepth)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        if (view is null)
        {
            throw new ArgumentNullException(nameof(view));
        }

        var textureDescription = texture.Description;
        var viewDescription = view.Description;
        var mipSlice = viewDescription.ViewDimension switch
        {
            D3D11RtvDimension.Texture3D => viewDescription.Texture3D.MipSlice,
            _ => throw new ArgumentOutOfRangeException(nameof(view)),
        };
        uint subResourceWidth = textureDescription.Width / (uint)(1 << (int)mipSlice);
        uint subResourceHeight = textureDescription.Height / (uint)(1 << (int)mipSlice);

        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
        this.width = (subResourceWidth != 0 ? subResourceWidth : 1) - topLeftX;
        this.height = (subResourceHeight != 0 ? subResourceHeight : 1) - topLeftY;
        this.minDepth = minDepth;
        this.maxDepth = maxDepth;
    }

    /// <summary>
    /// Gets or sets the X position of the left hand side of the viewport.
    /// </summary>
    public float TopLeftX
    {
        get { return this.topLeftX; }
        set { this.topLeftX = value; }
    }

    /// <summary>
    /// Gets or sets the Y position of the top of the viewport.
    /// </summary>
    public float TopLeftY
    {
        get { return this.topLeftY; }
        set { this.topLeftY = value; }
    }

    /// <summary>
    /// Gets or sets the width of the viewport.
    /// </summary>
    public float Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    /// <summary>
    /// Gets or sets the height of the viewport.
    /// </summary>
    public float Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    /// <summary>
    /// Gets or sets the minimum depth of the viewport.
    /// </summary>
    public float MinDepth
    {
        get { return this.minDepth; }
        set { this.minDepth = value; }
    }

    /// <summary>
    /// Gets or sets the maximum depth of the viewport.
    /// </summary>
    public float MaxDepth
    {
        get { return this.maxDepth; }
        set { this.maxDepth = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11Viewport left, D3D11Viewport right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Viewport left, D3D11Viewport right)
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
        return obj is D3D11Viewport viewport && Equals(viewport);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Viewport other)
    {
        return topLeftX == other.topLeftX &&
               topLeftY == other.topLeftY &&
               width == other.width &&
               height == other.height &&
               minDepth == other.minDepth &&
               maxDepth == other.maxDepth;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -721477542;
        hashCode = hashCode * -1521134295 + topLeftX.GetHashCode();
        hashCode = hashCode * -1521134295 + topLeftY.GetHashCode();
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + minDepth.GetHashCode();
        hashCode = hashCode * -1521134295 + maxDepth.GetHashCode();
        return hashCode;
    }
}
