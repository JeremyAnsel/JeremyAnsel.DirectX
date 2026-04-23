// <copyright file="D3D11DepthStencilViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources of a texture that are accessible from a depth-stencil view.
/// </summary>
[SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable", MessageId = "texture2DMsArray", Justification = "Reviewed")]
[SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable", MessageId = "texture2DArray", Justification = "Reviewed")]
[SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable", MessageId = "texture1DArray", Justification = "Reviewed")]
[SkipLocalsInit, StructLayout(LayoutKind.Explicit)]
public unsafe struct D3D11DepthStencilViewDesc : IEquatable<D3D11DepthStencilViewDesc>
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
        size += sizeof(int) * 3;
        int dsv = 0;
        dsv = Math.Max(dsv, D3D11Texture1DDsv.NativeRequiredSize());
        dsv = Math.Max(dsv, D3D11Texture1DArrayDsv.NativeRequiredSize());
        dsv = Math.Max(dsv, D3D11Texture2DDsv.NativeRequiredSize());
        dsv = Math.Max(dsv, D3D11Texture2DArrayDsv.NativeRequiredSize());
        dsv = Math.Max(dsv, D3D11Texture2DMsDsv.NativeRequiredSize());
        dsv = Math.Max(dsv, D3D11Texture2DMsArrayDsv.NativeRequiredSize());
        size += dsv;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11DepthStencilViewDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11DepthStencilViewDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11DepthStencilViewDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.viewDimension);
            DXMarshal.Write(ref buffer, (int)obj.options);

            switch (obj.viewDimension)
            {
                case D3D11DsvDimension.Texture1D:
                    D3D11Texture1DDsv.NativeWriteTo(buffer, obj.texture1D);
                    buffer += D3D11Texture1DDsv.NativeRequiredSize();
                    break;

                case D3D11DsvDimension.Texture1DArray:
                    D3D11Texture1DArrayDsv.NativeWriteTo(buffer, obj.texture1DArray);
                    buffer += D3D11Texture1DArrayDsv.NativeRequiredSize();
                    break;

                case D3D11DsvDimension.Texture2D:
                    D3D11Texture2DDsv.NativeWriteTo(buffer, obj.texture2D);
                    buffer += D3D11Texture2DDsv.NativeRequiredSize();
                    break;

                case D3D11DsvDimension.Texture2DArray:
                    D3D11Texture2DArrayDsv.NativeWriteTo(buffer, obj.texture2DArray);
                    buffer += D3D11Texture2DArrayDsv.NativeRequiredSize();
                    break;

                case D3D11DsvDimension.Texture2DMs:
                    D3D11Texture2DMsDsv.NativeWriteTo(buffer, obj.texture2DMs);
                    buffer += D3D11Texture2DMsDsv.NativeRequiredSize();
                    break;

                case D3D11DsvDimension.Texture2DMsArray:
                    D3D11Texture2DMsArrayDsv.NativeWriteTo(buffer, obj.texture2DMsArray);
                    buffer += D3D11Texture2DMsArrayDsv.NativeRequiredSize();
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
    public static D3D11DepthStencilViewDesc NativeReadFrom(nint buffer)
    {
        D3D11DepthStencilViewDesc obj = default;
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.viewDimension = (D3D11DsvDimension)DXMarshal.ReadInt32(ref buffer);
        obj.options = (D3D11DepthStencilViewOptions)DXMarshal.ReadInt32(ref buffer);

        switch (obj.viewDimension)
        {
            case D3D11DsvDimension.Texture1D:
                obj.texture1D = D3D11Texture1DDsv.NativeReadFrom(buffer);
                buffer += D3D11Texture1DDsv.NativeRequiredSize();
                break;

            case D3D11DsvDimension.Texture1DArray:
                obj.texture1DArray = D3D11Texture1DArrayDsv.NativeReadFrom(buffer);
                buffer += D3D11Texture1DArrayDsv.NativeRequiredSize();
                break;

            case D3D11DsvDimension.Texture2D:
                obj.texture2D = D3D11Texture2DDsv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DDsv.NativeRequiredSize();
                break;

            case D3D11DsvDimension.Texture2DArray:
                obj.texture2DArray = D3D11Texture2DArrayDsv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DArrayDsv.NativeRequiredSize();
                break;

            case D3D11DsvDimension.Texture2DMs:
                obj.texture2DMs = D3D11Texture2DMsDsv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DMsDsv.NativeRequiredSize();
                break;

            case D3D11DsvDimension.Texture2DMsArray:
                obj.texture2DMsArray = D3D11Texture2DMsArrayDsv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DMsArrayDsv.NativeRequiredSize();
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
    public static void NativeReadFrom(nint buffer, Span<D3D11DepthStencilViewDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The resource data format.
    /// </summary>
    [FieldOffset(0)]
    private DxgiFormat format;

    /// <summary>
    /// The type of resource. Specifies how a depth-stencil resource will be accessed; the value is stored in the union in this structure.
    /// </summary>
    [FieldOffset(4)]
    private D3D11DsvDimension viewDimension;

    /// <summary>
    /// A value that describes whether the texture is read only.
    /// </summary>
    [FieldOffset(8)]
    private D3D11DepthStencilViewOptions options;

    /// <summary>
    /// Specifies a 1D texture subresource.
    /// </summary>
    [FieldOffset(12)]
    private D3D11Texture1DDsv texture1D;

    /// <summary>
    /// Specifies an array of 1D texture subresources.
    /// </summary>
    [FieldOffset(12)]
    private D3D11Texture1DArrayDsv texture1DArray;

    /// <summary>
    /// Specifies a 2D texture subresource.
    /// </summary>
    [FieldOffset(12)]
    private D3D11Texture2DDsv texture2D;

    /// <summary>
    /// Specifies an array of 2D texture subresources.
    /// </summary>
    [FieldOffset(12)]
    private D3D11Texture2DArrayDsv texture2DArray;

    /// <summary>
    /// Specifies a multisampled 2D texture.
    /// </summary>
    [FieldOffset(12)]
    private D3D11Texture2DMsDsv texture2DMs;

    /// <summary>
    /// Specifies an array of multisampled 2D textures.
    /// </summary>
    [FieldOffset(12)]
    private D3D11Texture2DMsArrayDsv texture2DMsArray;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    public D3D11DepthStencilViewDesc(
        D3D11DsvDimension viewDimension)
        : this(viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11DepthStencilViewDesc(
        D3D11DsvDimension viewDimension,
        DxgiFormat format)
        : this(viewDimension, format, 0, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11DepthStencilViewDesc(
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(viewDimension, format, mipSlice, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11DepthStencilViewDesc(
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice)
        : this(viewDimension, format, mipSlice, firstArraySlice, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11DepthStencilViewDesc(
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize)
        : this(viewDimension, format, mipSlice, firstArraySlice, arraySize, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    /// <param name="options">A value that describes whether the texture is read only.</param>
    public D3D11DepthStencilViewDesc(
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize,
        D3D11DepthStencilViewOptions options)
    {
        this.format = format;
        this.viewDimension = viewDimension;
        this.options = options;

        switch (viewDimension)
        {
            case D3D11DsvDimension.Texture1D:
                this.texture1D = new D3D11Texture1DDsv(mipSlice);
                break;

            case D3D11DsvDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArrayDsv(mipSlice, firstArraySlice, arraySize);
                break;

            case D3D11DsvDimension.Texture2D:
                this.texture2D = new D3D11Texture2DDsv(mipSlice);
                break;

            case D3D11DsvDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArrayDsv(mipSlice, firstArraySlice, arraySize);
                break;

            case D3D11DsvDimension.Texture2DMs:
                this.texture2DMs = new D3D11Texture2DMsDsv();
                break;

            case D3D11DsvDimension.Texture2DMsArray:
                this.texture2DMsArray = new D3D11Texture2DMsArrayDsv(firstArraySlice, arraySize);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture1D texture,
        D3D11DsvDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture1D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture1D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, viewDimension, format, mipSlice, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture1D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice)
        : this(texture, viewDimension, format, mipSlice, firstArraySlice, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture1D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize)
        : this(texture, viewDimension, format, mipSlice, firstArraySlice, arraySize, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    /// <param name="options">A value that describes whether the texture is read only.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture1D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize,
        D3D11DepthStencilViewOptions options)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;
        this.options = options;

        if (format == DxgiFormat.Unknown
            || (arraySize == uint.MaxValue && viewDimension == D3D11DsvDimension.Texture1DArray))
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (arraySize == uint.MaxValue)
            {
                arraySize = description.ArraySize - firstArraySlice;
            }
        }

        this.format = format;

        switch (viewDimension)
        {
            case D3D11DsvDimension.Texture1D:
                this.texture1D = new D3D11Texture1DDsv
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11DsvDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArrayDsv
                {
                    MipSlice = mipSlice,
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture2D texture,
        D3D11DsvDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture2D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture2D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, viewDimension, format, mipSlice, 0, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture2D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice)
        : this(texture, viewDimension, format, mipSlice, firstArraySlice, uint.MaxValue, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture2D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize)
        : this(texture, viewDimension, format, mipSlice, firstArraySlice, arraySize, D3D11DepthStencilViewOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The depth-stencil type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    /// <param name="options">A value that describes whether the texture is read only.</param>
    public D3D11DepthStencilViewDesc(
        D3D11Texture2D texture,
        D3D11DsvDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize,
        D3D11DepthStencilViewOptions options)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;
        this.options = options;

        if (format == DxgiFormat.Unknown
            || (arraySize == uint.MaxValue
                && (viewDimension == D3D11DsvDimension.Texture2DArray
                    || viewDimension == D3D11DsvDimension.Texture2DMsArray)))
        {
            var desciption = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = desciption.Format;
            }

            if (arraySize == uint.MaxValue)
            {
                arraySize = desciption.ArraySize - firstArraySlice;
            }
        }

        this.format = format;

        switch (viewDimension)
        {
            case D3D11DsvDimension.Texture2D:
                this.texture2D = new D3D11Texture2DDsv
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11DsvDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArrayDsv
                {
                    MipSlice = mipSlice,
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            case D3D11DsvDimension.Texture2DMs:
                this.texture2DMs = new D3D11Texture2DMsDsv
                {
                };
                break;

            case D3D11DsvDimension.Texture2DMsArray:
                this.texture2DMsArray = new D3D11Texture2DMsArrayDsv
                {
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Gets or sets the resource data format.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets the type of resource. Specifies how a depth-stencil resource will be accessed; the value is stored in the union in this structure.
    /// </summary>
    public D3D11DsvDimension ViewDimension
    {
        get { return this.viewDimension; }
        set { this.viewDimension = value; }
    }

    /// <summary>
    /// Gets or sets a value that describes whether the texture is read only.
    /// </summary>
    public D3D11DepthStencilViewOptions Options
    {
        get { return this.options; }
        set { this.options = value; }
    }

    /// <summary>
    /// Gets or sets a 1D texture subresource.
    /// </summary>
    public D3D11Texture1DDsv Texture1D
    {
        get { return this.texture1D; }
        set { this.texture1D = value; }
    }

    /// <summary>
    /// Gets or sets an array of 1D texture subresources.
    /// </summary>
    public D3D11Texture1DArrayDsv Texture1DArray
    {
        get { return this.texture1DArray; }
        set { this.texture1DArray = value; }
    }

    /// <summary>
    /// Gets or sets a 2D texture subresource.
    /// </summary>
    public D3D11Texture2DDsv Texture2D
    {
        get { return this.texture2D; }
        set { this.texture2D = value; }
    }

    /// <summary>
    /// Gets or sets an array of 2D texture subresources.
    /// </summary>
    public D3D11Texture2DArrayDsv Texture2DArray
    {
        get { return this.texture2DArray; }
        set { this.texture2DArray = value; }
    }

    /// <summary>
    /// Gets or sets a multisampled 2D texture.
    /// </summary>
    public D3D11Texture2DMsDsv Texture2DMs
    {
        get { return this.texture2DMs; }
        set { this.texture2DMs = value; }
    }

    /// <summary>
    /// Gets or sets an array of multisampled 2D textures.
    /// </summary>
    public D3D11Texture2DMsArrayDsv Texture2DMsArray
    {
        get { return this.texture2DMsArray; }
        set { this.texture2DMsArray = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11DepthStencilViewDesc left, D3D11DepthStencilViewDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11DepthStencilViewDesc left, D3D11DepthStencilViewDesc right)
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
        return obj is D3D11DepthStencilViewDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11DepthStencilViewDesc other)
    {
        return format == other.format &&
               viewDimension == other.viewDimension &&
               options == other.options &&
               texture1D.Equals(other.texture1D) &&
               texture1DArray.Equals(other.texture1DArray) &&
               texture2D.Equals(other.texture2D) &&
               texture2DArray.Equals(other.texture2DArray) &&
               texture2DMs.Equals(other.texture2DMs) &&
               texture2DMsArray.Equals(other.texture2DMsArray);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -219417368;
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + viewDimension.GetHashCode();
        hashCode = hashCode * -1521134295 + options.GetHashCode();
        hashCode = hashCode * -1521134295 + texture1D.GetHashCode();
        hashCode = hashCode * -1521134295 + texture1DArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2D.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DMs.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DMsArray.GetHashCode();
        return hashCode;
    }
}
