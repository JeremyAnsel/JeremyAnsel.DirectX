// <copyright file="D3D11RenderTargetViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources from a resource that are accessible using a render-target view.
/// </summary>
[SkipLocalsInit, StructLayout(LayoutKind.Explicit)]
public unsafe struct D3D11RenderTargetViewDesc : IEquatable<D3D11RenderTargetViewDesc>
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
        int rtv = 0;
        rtv = Math.Max(rtv, D3D11BufferRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture1DRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture1DArrayRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture2DRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture2DArrayRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture2DMsRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture2DMsArrayRtv.NativeRequiredSize());
        rtv = Math.Max(rtv, D3D11Texture3DRtv.NativeRequiredSize());
        size += rtv;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11RenderTargetViewDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11RenderTargetViewDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11RenderTargetViewDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.viewDimension);

            switch (obj.viewDimension)
            {
                case D3D11RtvDimension.Buffer:
                    D3D11BufferRtv.NativeWriteTo(buffer, obj.buffer);
                    buffer += D3D11BufferRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture1D:
                    D3D11Texture1DRtv.NativeWriteTo(buffer, obj.texture1D);
                    buffer += D3D11Texture1DRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture1DArray:
                    D3D11Texture1DArrayRtv.NativeWriteTo(buffer, obj.texture1DArray);
                    buffer += D3D11Texture1DArrayRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture2D:
                    D3D11Texture2DRtv.NativeWriteTo(buffer, obj.texture2D);
                    buffer += D3D11Texture2DRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture2DArray:
                    D3D11Texture2DArrayRtv.NativeWriteTo(buffer, obj.texture2DArray);
                    buffer += D3D11Texture2DArrayRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture2DMs:
                    D3D11Texture2DMsRtv.NativeWriteTo(buffer, obj.texture2DMs);
                    buffer += D3D11Texture2DMsRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture2DMsArray:
                    D3D11Texture2DMsArrayRtv.NativeWriteTo(buffer, obj.texture2DMsArray);
                    buffer += D3D11Texture2DMsArrayRtv.NativeRequiredSize();
                    break;

                case D3D11RtvDimension.Texture3D:
                    D3D11Texture3DRtv.NativeWriteTo(buffer, obj.texture3D);
                    buffer += D3D11Texture3DRtv.NativeRequiredSize();
                    break;

                default:
                    throw new IndexOutOfRangeException(nameof(obj.viewDimension));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11RenderTargetViewDesc NativeReadFrom(nint buffer)
    {
        D3D11RenderTargetViewDesc obj = default;
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.viewDimension = (D3D11RtvDimension)DXMarshal.ReadInt32(ref buffer);

        switch (obj.viewDimension)
        {
            case D3D11RtvDimension.Buffer:
                obj.buffer = D3D11BufferRtv.NativeReadFrom(buffer);
                buffer += D3D11BufferRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture1D:
                obj.texture1D = D3D11Texture1DRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture1DRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture1DArray:
                obj.texture1DArray = D3D11Texture1DArrayRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture1DArrayRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture2D:
                obj.texture2D = D3D11Texture2DRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture2DArray:
                obj.texture2DArray = D3D11Texture2DArrayRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DArrayRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture2DMs:
                obj.texture2DMs = D3D11Texture2DMsRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DMsRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture2DMsArray:
                obj.texture2DMsArray = D3D11Texture2DMsArrayRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DMsArrayRtv.NativeRequiredSize();
                break;

            case D3D11RtvDimension.Texture3D:
                obj.texture3D = D3D11Texture3DRtv.NativeReadFrom(buffer);
                buffer += D3D11Texture3DRtv.NativeRequiredSize();
                break;

            default:
                throw new IndexOutOfRangeException(nameof(obj.viewDimension));
        }

        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11RenderTargetViewDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The data format.
    /// </summary>
    [FieldOffset(0)]
    private DxgiFormat format;

    /// <summary>
    /// The resource type.
    /// </summary>
    [FieldOffset(4)]
    private D3D11RtvDimension viewDimension;

    /// <summary>
    /// Specifies which buffer elements can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11BufferRtv buffer;

    /// <summary>
    /// Specifies the subresources in a 1D texture that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture1DRtv texture1D;

    /// <summary>
    /// Specifies the subresources in a 1D texture array that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture1DArrayRtv texture1DArray;

    /// <summary>
    /// Specifies the subresources in a 2D texture that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DRtv texture2D;

    /// <summary>
    /// Specifies the subresources in a 2D texture array that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DArrayRtv texture2DArray;

    /// <summary>
    /// Specifies a single subresource because a multisampled 2D texture only contains one subresource.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DMsRtv texture2DMs;

    /// <summary>
    /// Specifies the subresources in a multisampled 2D texture array that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DMsArrayRtv texture2DMsArray;

    /// <summary>
    /// Specifies the subresources in a 3D texture that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture3DRtv texture3D;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11RenderTargetViewDesc(
        D3D11RtvDimension viewDimension)
        : this(viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11RenderTargetViewDesc(
        D3D11RtvDimension viewDimension,
        DxgiFormat format)
        : this(viewDimension, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11RenderTargetViewDesc(
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(viewDimension, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11RenderTargetViewDesc(
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firtArraySlice)
        : this(viewDimension, format, mipSlice, firtArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11RenderTargetViewDesc(
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firtArraySlice,
        uint arraySize)
    {
        this.format = format;
        this.viewDimension = viewDimension;

        switch (viewDimension)
        {
            case D3D11RtvDimension.Buffer:
                this.buffer = new D3D11BufferRtv(mipSlice, firtArraySlice);
                break;

            case D3D11RtvDimension.Texture1D:
                this.texture1D = new D3D11Texture1DRtv(mipSlice);
                break;

            case D3D11RtvDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArrayRtv(mipSlice, firtArraySlice, arraySize);
                break;

            case D3D11RtvDimension.Texture2D:
                this.texture2D = new D3D11Texture2DRtv(mipSlice);
                break;

            case D3D11RtvDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArrayRtv(mipSlice, firtArraySlice, arraySize);
                break;

            case D3D11RtvDimension.Texture2DMs:
                this.texture2DMs = new D3D11Texture2DMsRtv();
                break;

            case D3D11RtvDimension.Texture2DMsArray:
                this.texture2DMsArray = new D3D11Texture2DMsArrayRtv(firtArraySlice, arraySize);
                break;

            case D3D11RtvDimension.Texture3D:
                this.texture3D = new D3D11Texture3DRtv(mipSlice, firtArraySlice, arraySize);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="firstElement">The buffer and the first element to access.</param>
    /// <param name="numElements">The total number of elements in the view.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Buffer buffer,
        DxgiFormat format,
        uint firstElement,
        uint numElements)
    {
        if (buffer is null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        this.format = format;
        this.viewDimension = D3D11RtvDimension.Buffer;
        this.buffer = new D3D11BufferRtv
        {
            FirstElement = firstElement,
            NumElements = numElements
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture1D texture,
        D3D11RtvDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture1D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture1D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, viewDimension, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture1D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firtArraySlice)
        : this(texture, viewDimension, format, mipSlice, firtArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture1D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firtArraySlice,
        uint arraySize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;

        if (format == DxgiFormat.Unknown
            || (arraySize == uint.MaxValue && viewDimension == D3D11RtvDimension.Texture1DArray))
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (arraySize == uint.MaxValue)
            {
                arraySize = description.ArraySize - firtArraySlice;
            }
        }

        this.format = format;

        switch (viewDimension)
        {
            case D3D11RtvDimension.Texture1D:
                this.texture1D = new D3D11Texture1DRtv
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11RtvDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArrayRtv
                {
                    MipSlice = mipSlice,
                    FirstArraySlice = firtArraySlice,
                    ArraySize = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture2D texture,
        D3D11RtvDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture2D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture2D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, viewDimension, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture2D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firtArraySlice)
        : this(texture, viewDimension, format, mipSlice, firtArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture2D texture,
        D3D11RtvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firtArraySlice,
        uint arraySize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;

        if (format == DxgiFormat.Unknown
            || (arraySize == uint.MaxValue
                && (viewDimension == D3D11RtvDimension.Texture2DArray
                    || viewDimension == D3D11RtvDimension.Texture2DMsArray)))
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (arraySize == uint.MaxValue)
            {
                arraySize = description.ArraySize - firtArraySlice;
            }
        }

        this.format = format;

        switch (viewDimension)
        {
            case D3D11RtvDimension.Texture2D:
                this.texture2D = new D3D11Texture2DRtv
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11RtvDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArrayRtv
                {
                    MipSlice = mipSlice,
                    FirstArraySlice = firtArraySlice,
                    ArraySize = arraySize
                };
                break;

            case D3D11RtvDimension.Texture2DMs:
                this.texture2DMs = new D3D11Texture2DMsRtv
                {
                };
                break;

            case D3D11RtvDimension.Texture2DMsArray:
                this.texture2DMsArray = new D3D11Texture2DMsArrayRtv
                {
                    FirstArraySlice = firtArraySlice,
                    ArraySize = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture3D texture)
        : this(texture, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format)
        : this(texture, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtWSlice">The first depth level to use.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mipSlice,
        uint firtWSlice)
        : this(texture, format, mipSlice, firtWSlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firtWSlice">The first depth level to use.</param>
    /// <param name="wsize">The number of depth levels to use in the render-target view.</param>
    public D3D11RenderTargetViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mipSlice,
        uint firtWSlice,
        uint wsize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = D3D11RtvDimension.Texture3D;

        if (format == DxgiFormat.Unknown || wsize == uint.MaxValue)
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (wsize == uint.MaxValue)
            {
                wsize = description.Depth - firtWSlice;
            }
        }

        this.format = format;
        this.texture3D = new D3D11Texture3DRtv
        {
            MipSlice = mipSlice,
            FirstWSlice = firtWSlice,
            WSize = wsize
        };
    }

    /// <summary>
    /// Gets or sets the data format.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets the resource type.
    /// </summary>
    public D3D11RtvDimension ViewDimension
    {
        get { return this.viewDimension; }
        set { this.viewDimension = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating which buffer elements can be accessed.
    /// </summary>
    public D3D11BufferRtv Buffer
    {
        get { return this.buffer; }
        set { this.buffer = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 1D texture that can be accessed.
    /// </summary>
    public D3D11Texture1DRtv Texture1D
    {
        get { return this.texture1D; }
        set { this.texture1D = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 1D texture array that can be accessed.
    /// </summary>
    public D3D11Texture1DArrayRtv Texture1DArray
    {
        get { return this.texture1DArray; }
        set { this.texture1DArray = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 2D texture that can be accessed.
    /// </summary>
    public D3D11Texture2DRtv Texture2D
    {
        get { return this.texture2D; }
        set { this.texture2D = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 2D texture array that can be accessed.
    /// </summary>
    public D3D11Texture2DArrayRtv Texture2DArray
    {
        get { return this.texture2DArray; }
        set { this.texture2DArray = value; }
    }

    /// <summary>
    /// Gets or sets a single subresource because a multisampled 2D texture only contains one subresource.
    /// </summary>
    public D3D11Texture2DMsRtv Texture2DMs
    {
        get { return this.texture2DMs; }
        set { this.texture2DMs = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a multisampled 2D texture array that can be accessed.
    /// </summary>
    public D3D11Texture2DMsArrayRtv Texture2DMsArray
    {
        get { return this.texture2DMsArray; }
        set { this.texture2DMsArray = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 3D texture that can be accessed.
    /// </summary>
    public D3D11Texture3DRtv Texture3D
    {
        get { return this.texture3D; }
        set { this.texture3D = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11RenderTargetViewDesc left, D3D11RenderTargetViewDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11RenderTargetViewDesc left, D3D11RenderTargetViewDesc right)
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
        return obj is D3D11RenderTargetViewDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11RenderTargetViewDesc other)
    {
        return format == other.format &&
               viewDimension == other.viewDimension &&
               buffer.Equals(other.buffer) &&
               texture1D.Equals(other.texture1D) &&
               texture1DArray.Equals(other.texture1DArray) &&
               texture2D.Equals(other.texture2D) &&
               texture2DArray.Equals(other.texture2DArray) &&
               texture2DMs.Equals(other.texture2DMs) &&
               texture2DMsArray.Equals(other.texture2DMsArray) &&
               texture3D.Equals(other.texture3D);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 966489377;
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + viewDimension.GetHashCode();
        hashCode = hashCode * -1521134295 + buffer.GetHashCode();
        hashCode = hashCode * -1521134295 + texture1D.GetHashCode();
        hashCode = hashCode * -1521134295 + texture1DArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2D.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DMs.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DMsArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture3D.GetHashCode();
        return hashCode;
    }
}
