// <copyright file="D3D11ShaderResourceViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a shader resource view.
/// </summary>
[SkipLocalsInit, StructLayout(LayoutKind.Explicit)]
public unsafe struct D3D11ShaderResourceViewDesc : IEquatable<D3D11ShaderResourceViewDesc>
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
        int srv = 0;
        srv = Math.Max(srv, D3D11BufferSrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture1DSrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture1DArraySrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture2DSrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture2DArraySrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture2DMsSrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture2DMsArraySrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11Texture3DSrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11TextureCubeSrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11TextureCubeArraySrv.NativeRequiredSize());
        srv = Math.Max(srv, D3D11BufferExSrv.NativeRequiredSize());
        size += srv;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11ShaderResourceViewDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11ShaderResourceViewDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11ShaderResourceViewDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.viewDimension);

            switch (obj.viewDimension)
            {
                case D3D11SrvDimension.Buffer:
                    D3D11BufferSrv.NativeWriteTo(buffer, obj.buffer);
                    buffer += D3D11BufferSrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture1D:
                    D3D11Texture1DSrv.NativeWriteTo(buffer, obj.texture1D);
                    buffer += D3D11Texture1DSrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture1DArray:
                    D3D11Texture1DArraySrv.NativeWriteTo(buffer, obj.texture1DArray);
                    buffer += D3D11Texture1DArraySrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture2D:
                    D3D11Texture2DSrv.NativeWriteTo(buffer, obj.texture2D);
                    buffer += D3D11Texture2DSrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture2DArray:
                    D3D11Texture2DArraySrv.NativeWriteTo(buffer, obj.texture2DArray);
                    buffer += D3D11Texture2DArraySrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture2DMs:
                    D3D11Texture2DMsSrv.NativeWriteTo(buffer, obj.texture2DMs);
                    buffer += D3D11Texture2DMsSrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture2DMsArray:
                    D3D11Texture2DMsArraySrv.NativeWriteTo(buffer, obj.texture2DMsArray);
                    buffer += D3D11Texture2DMsArraySrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.Texture3D:
                    D3D11Texture3DSrv.NativeWriteTo(buffer, obj.texture3D);
                    buffer += D3D11Texture3DSrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.TextureCube:
                    D3D11TextureCubeSrv.NativeWriteTo(buffer, obj.textureCube);
                    buffer += D3D11TextureCubeSrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.TextureCubeArray:
                    D3D11TextureCubeArraySrv.NativeWriteTo(buffer, obj.textureCubeArray);
                    buffer += D3D11TextureCubeArraySrv.NativeRequiredSize();
                    break;

                case D3D11SrvDimension.BufferEx:
                    D3D11BufferExSrv.NativeWriteTo(buffer, obj.bufferEx);
                    buffer += D3D11BufferSrv.NativeRequiredSize();
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
    public static D3D11ShaderResourceViewDesc NativeReadFrom(nint buffer)
    {
        D3D11ShaderResourceViewDesc obj = default;
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.viewDimension = (D3D11SrvDimension)DXMarshal.ReadInt32(ref buffer);

        switch (obj.viewDimension)
        {
            case D3D11SrvDimension.Buffer:
                obj.buffer = D3D11BufferSrv.NativeReadFrom(buffer);
                buffer += D3D11BufferSrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture1D:
                obj.texture1D = D3D11Texture1DSrv.NativeReadFrom(buffer);
                buffer += D3D11Texture1DSrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture1DArray:
                obj.texture1DArray = D3D11Texture1DArraySrv.NativeReadFrom(buffer);
                buffer += D3D11Texture1DArraySrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture2D:
                obj.texture2D = D3D11Texture2DSrv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DSrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture2DArray:
                obj.texture2DArray = D3D11Texture2DArraySrv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DArraySrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture2DMs:
                obj.texture2DMs = D3D11Texture2DMsSrv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DMsSrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture2DMsArray:
                obj.texture2DMsArray = D3D11Texture2DMsArraySrv.NativeReadFrom(buffer);
                buffer += D3D11Texture2DMsArraySrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.Texture3D:
                obj.texture3D = D3D11Texture3DSrv.NativeReadFrom(buffer);
                buffer += D3D11Texture3DSrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.TextureCube:
                obj.textureCube = D3D11TextureCubeSrv.NativeReadFrom(buffer);
                buffer += D3D11TextureCubeSrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.TextureCubeArray:
                obj.textureCubeArray = D3D11TextureCubeArraySrv.NativeReadFrom(buffer);
                buffer += D3D11TextureCubeArraySrv.NativeRequiredSize();
                break;

            case D3D11SrvDimension.BufferEx:
                obj.bufferEx = D3D11BufferExSrv.NativeReadFrom(buffer);
                buffer += D3D11BufferSrv.NativeRequiredSize();
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
    public static void NativeReadFrom(nint buffer, Span<D3D11ShaderResourceViewDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The viewing format.
    /// </summary>
    [FieldOffset(0)]
    private DxgiFormat format;

    /// <summary>
    /// The resource type of the view.
    /// </summary>
    [FieldOffset(4)]
    private D3D11SrvDimension viewDimension;

    /// <summary>
    /// View the resource as a buffer using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11BufferSrv buffer;

    /// <summary>
    /// View the resource as a 1D texture using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture1DSrv texture1D;

    /// <summary>
    /// View the resource as a 1D-texture array using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture1DArraySrv texture1DArray;

    /// <summary>
    /// View the resource as a 2D-texture using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DSrv texture2D;

    /// <summary>
    /// View the resource as a 2D-texture array using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DArraySrv texture2DArray;

    /// <summary>
    /// View the resource as a 2D-multisampled texture using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DMsSrv texture2DMs;

    /// <summary>
    /// View the resource as a 2D-multisampled-texture array using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DMsArraySrv texture2DMsArray;

    /// <summary>
    /// View the resource as a 3D texture using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture3DSrv texture3D;

    /// <summary>
    /// View the resource as a 3D-cube texture using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11TextureCubeSrv textureCube;

    /// <summary>
    /// View the resource as a 3D-cube-texture array using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11TextureCubeArraySrv textureCubeArray;

    /// <summary>
    /// View the resource as a raw buffer using information from a shader resource view.
    /// </summary>
    [FieldOffset(8)]
    private D3D11BufferExSrv bufferEx;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension)
        : this(viewDimension, DxgiFormat.Unknown, 0, uint.MaxValue, 0, uint.MaxValue, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension,
        DxgiFormat format)
        : this(viewDimension, format, 0, uint.MaxValue, 0, uint.MaxValue, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">Index of the most detailed mipmap level to use.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip)
        : this(viewDimension, format, mostDetailedMip, uint.MaxValue, 0, uint.MaxValue, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">Index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels)
        : this(viewDimension, format, mostDetailedMip, mipLevels, 0, uint.MaxValue, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">Index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice)
        : this(viewDimension, format, mostDetailedMip, mipLevels, firstArraySlice, uint.MaxValue, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">Index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice,
        uint arraySize)
        : this(viewDimension, format, mostDetailedMip, mipLevels, firstArraySlice, arraySize, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">Index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    /// <param name="bufferExOptions">The view options for a buffer</param>
    public D3D11ShaderResourceViewDesc(
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice,
        uint arraySize,
        D3D11BufferExSrvOptions bufferExOptions)
    {
        this.format = format;
        this.viewDimension = viewDimension;

        switch (viewDimension)
        {
            case D3D11SrvDimension.Buffer:
                this.buffer = new D3D11BufferSrv(mostDetailedMip, mipLevels);
                break;

            case D3D11SrvDimension.Texture1D:
                this.texture1D = new D3D11Texture1DSrv(mostDetailedMip, mipLevels);
                break;

            case D3D11SrvDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArraySrv(mostDetailedMip, mipLevels, firstArraySlice, arraySize);
                break;

            case D3D11SrvDimension.Texture2D:
                this.texture2D = new D3D11Texture2DSrv(mostDetailedMip, mipLevels);
                break;

            case D3D11SrvDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArraySrv(mostDetailedMip, mipLevels, firstArraySlice, arraySize);
                break;

            case D3D11SrvDimension.Texture2DMs:
                this.texture2DMs = new D3D11Texture2DMsSrv();
                break;

            case D3D11SrvDimension.Texture2DMsArray:
                this.texture2DMsArray = new D3D11Texture2DMsArraySrv(firstArraySlice, arraySize);
                break;

            case D3D11SrvDimension.Texture3D:
                this.texture3D = new D3D11Texture3DSrv(mostDetailedMip, mipLevels);
                break;

            case D3D11SrvDimension.TextureCube:
                this.textureCube = new D3D11TextureCubeSrv(mostDetailedMip, mipLevels);
                break;

            case D3D11SrvDimension.TextureCubeArray:
                this.textureCubeArray = new D3D11TextureCubeArraySrv(mostDetailedMip, mipLevels, firstArraySlice, arraySize);
                break;

            case D3D11SrvDimension.BufferEx:
                this.bufferEx = new D3D11BufferExSrv(mostDetailedMip, mipLevels, bufferExOptions);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="firstElement">The number of bytes between the beginning of the buffer and the first element to access.</param>
    /// <param name="numElements">The total number of elements in the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Buffer buffer,
        DxgiFormat format,
        uint firstElement,
        uint numElements)
        : this(buffer, format, firstElement, numElements, D3D11BufferExSrvOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="firstElement">The number of bytes between the beginning of the buffer and the first element to access.</param>
    /// <param name="numElements">The total number of elements in the view.</param>
    /// <param name="options">The view options for a buffer.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Buffer buffer,
        DxgiFormat format,
        uint firstElement,
        uint numElements,
        D3D11BufferExSrvOptions options)
    {
        if (buffer is null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        this.format = format;
        this.viewDimension = D3D11SrvDimension.BufferEx;
        this.bufferEx = new D3D11BufferExSrv
        {
            FirstElement = firstElement,
            NumElements = numElements,
            Options = options
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture1D texture,
        D3D11SrvDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, uint.MaxValue, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture1D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, uint.MaxValue, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture1D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip)
        : this(texture, viewDimension, format, mostDetailedMip, uint.MaxValue, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture1D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels)
        : this(texture, viewDimension, format, mostDetailedMip, mipLevels, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture1D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice)
        : this(texture, viewDimension, format, mostDetailedMip, mipLevels, firstArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture1D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice,
        uint arraySize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;

        if (format == DxgiFormat.Unknown
            || mipLevels == uint.MaxValue
            || (arraySize == uint.MaxValue && viewDimension == D3D11SrvDimension.Texture1DArray))
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (mipLevels == uint.MaxValue)
            {
                mipLevels = description.MipLevels - mostDetailedMip;
            }

            if (arraySize == uint.MaxValue)
            {
                arraySize = description.ArraySize - firstArraySlice;
            }
        }

        this.format = format;

        switch (viewDimension)
        {
            case D3D11SrvDimension.Texture1D:
                this.texture1D = new D3D11Texture1DSrv
                {
                    MostDetailedMip = mostDetailedMip,
                    MipLevels = mipLevels
                };
                break;

            case D3D11SrvDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArraySrv
                {
                    MostDetailedMip = mostDetailedMip,
                    MipLevels = mipLevels,
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture2D texture,
        D3D11SrvDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, uint.MaxValue, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture2D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, uint.MaxValue, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture2D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip)
        : this(texture, viewDimension, format, mostDetailedMip, uint.MaxValue, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture2D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels)
        : this(texture, viewDimension, format, mostDetailedMip, mipLevels, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture2D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice)
        : this(texture, viewDimension, format, mostDetailedMip, mipLevels, firstArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture2D texture,
        D3D11SrvDimension viewDimension,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels,
        uint firstArraySlice,
        uint arraySize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;

        if (format == DxgiFormat.Unknown
            || (mipLevels == uint.MaxValue
                && viewDimension != D3D11SrvDimension.Texture2DMs
                && viewDimension != D3D11SrvDimension.Texture2DMsArray)
            || (arraySize == uint.MaxValue
                && viewDimension != D3D11SrvDimension.Texture2DArray
                && viewDimension != D3D11SrvDimension.Texture2DMsArray
                && viewDimension != D3D11SrvDimension.TextureCubeArray))
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (mipLevels == uint.MaxValue)
            {
                mipLevels = description.MipLevels - mostDetailedMip;
            }

            if (arraySize == uint.MaxValue)
            {
                arraySize = description.ArraySize - firstArraySlice;

                if (viewDimension == D3D11SrvDimension.TextureCubeArray)
                {
                    arraySize /= 6;
                }
            }
        }

        this.format = format;

        switch (viewDimension)
        {
            case D3D11SrvDimension.Texture2D:
                this.texture2D = new D3D11Texture2DSrv
                {
                    MostDetailedMip = mostDetailedMip,
                    MipLevels = mipLevels
                };
                break;

            case D3D11SrvDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArraySrv
                {
                    MostDetailedMip = mostDetailedMip,
                    MipLevels = mipLevels,
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            case D3D11SrvDimension.Texture2DMs:
                this.texture2DMs = new D3D11Texture2DMsSrv
                {
                };
                break;

            case D3D11SrvDimension.Texture2DMsArray:
                this.texture2DMsArray = new D3D11Texture2DMsArraySrv
                {
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            case D3D11SrvDimension.TextureCube:
                this.textureCube = new D3D11TextureCubeSrv
                {
                    MostDetailedMip = mostDetailedMip,
                    MipLevels = mipLevels
                };
                break;

            case D3D11SrvDimension.TextureCubeArray:
                this.textureCubeArray = new D3D11TextureCubeArraySrv
                {
                    MostDetailedMip = mostDetailedMip,
                    MipLevels = mipLevels,
                    First2DArrayFace = firstArraySlice,
                    NumCubes = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture3D texture)
        : this(texture, DxgiFormat.Unknown, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format)
        : this(texture, format, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mostDetailedMip)
        : this(texture, format, mostDetailedMip, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mostDetailedMip">The index of the most detailed mipmap level to use.</param>
    /// <param name="mipLevels">The maximum number of mipmap levels for the view.</param>
    public D3D11ShaderResourceViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mostDetailedMip,
        uint mipLevels)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = D3D11SrvDimension.Texture3D;

        if (format == DxgiFormat.Unknown || mipLevels == uint.MaxValue)
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (mipLevels == uint.MaxValue)
            {
                mipLevels = description.MipLevels - mostDetailedMip;
            }
        }

        this.format = format;

        this.texture3D = new D3D11Texture3DSrv
        {
            MostDetailedMip = mostDetailedMip,
            MipLevels = mipLevels
        };
    }

    /// <summary>
    /// Gets or sets the viewing format.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets the resource type of the view.
    /// </summary>
    public D3D11SrvDimension ViewDimension
    {
        get { return this.viewDimension; }
        set { this.viewDimension = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a buffer using information from a shader resource view.
    /// </summary>
    public D3D11BufferSrv Buffer
    {
        get { return this.buffer; }
        set { this.buffer = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 1D texture using information from a shader resource view.
    /// </summary>
    public D3D11Texture1DSrv Texture1D
    {
        get { return this.texture1D; }
        set { this.texture1D = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 1D-texture array using information from a shader resource view.
    /// </summary>
    public D3D11Texture1DArraySrv Texture1DArray
    {
        get { return this.texture1DArray; }
        set { this.texture1DArray = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 2D-texture using information from a shader resource view.
    /// </summary>
    public D3D11Texture2DSrv Texture2D
    {
        get { return this.texture2D; }
        set { this.texture2D = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 2D-texture array using information from a shader resource view.
    /// </summary>
    public D3D11Texture2DArraySrv Texture2DArray
    {
        get { return this.texture2DArray; }
        set { this.texture2DArray = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 2D-multisampled texture using information from a shader resource view.
    /// </summary>
    public D3D11Texture2DMsSrv Texture2DMs
    {
        get { return this.texture2DMs; }
        set { this.texture2DMs = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 2D-multisampled-texture array using information from a shader resource view.
    /// </summary>
    public D3D11Texture2DMsArraySrv Texture2DMsArray
    {
        get { return this.texture2DMsArray; }
        set { this.texture2DMsArray = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 3D texture using information from a shader resource view.
    /// </summary>
    public D3D11Texture3DSrv Texture3D
    {
        get { return this.texture3D; }
        set { this.texture3D = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 3D-cube texture using information from a shader resource view.
    /// </summary>
    public D3D11TextureCubeSrv TextureCube
    {
        get { return this.textureCube; }
        set { this.textureCube = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a 3D-cube-texture array using information from a shader resource view.
    /// </summary>
    public D3D11TextureCubeArraySrv TextureCubeArray
    {
        get { return this.textureCubeArray; }
        set { this.textureCubeArray = value; }
    }

    /// <summary>
    /// Gets or sets the resource as a raw buffer using information from a shader resource view.
    /// </summary>
    public D3D11BufferExSrv BufferEx
    {
        get { return this.bufferEx; }
        set { this.bufferEx = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11ShaderResourceViewDesc left, D3D11ShaderResourceViewDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11ShaderResourceViewDesc left, D3D11ShaderResourceViewDesc right)
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
        return obj is D3D11ShaderResourceViewDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11ShaderResourceViewDesc other)
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
               texture3D.Equals(other.texture3D) &&
               textureCube.Equals(other.textureCube) &&
               textureCubeArray.Equals(other.textureCubeArray) &&
               bufferEx.Equals(other.bufferEx);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 327694874;
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
        hashCode = hashCode * -1521134295 + textureCube.GetHashCode();
        hashCode = hashCode * -1521134295 + textureCubeArray.GetHashCode();
        hashCode = hashCode * -1521134295 + bufferEx.GetHashCode();
        return hashCode;
    }
}
