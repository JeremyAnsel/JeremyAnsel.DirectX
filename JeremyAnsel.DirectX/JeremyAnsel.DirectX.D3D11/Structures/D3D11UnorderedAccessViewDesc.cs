// <copyright file="D3D11UnorderedAccessViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the subresources from a resource that are accessible using an unordered-access view.
/// </summary>
[SkipLocalsInit, StructLayout(LayoutKind.Explicit)]
public unsafe struct D3D11UnorderedAccessViewDesc : IEquatable<D3D11UnorderedAccessViewDesc>
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
        int uav = 0;
        uav = Math.Max(uav, D3D11BufferUav.NativeRequiredSize());
        uav = Math.Max(uav, D3D11Texture1DUav.NativeRequiredSize());
        uav = Math.Max(uav, D3D11Texture1DArrayUav.NativeRequiredSize());
        uav = Math.Max(uav, D3D11Texture2DUav.NativeRequiredSize());
        uav = Math.Max(uav, D3D11Texture2DArrayUav.NativeRequiredSize());
        uav = Math.Max(uav, D3D11Texture3DUav.NativeRequiredSize());
        size += uav;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11UnorderedAccessViewDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11UnorderedAccessViewDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11UnorderedAccessViewDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.viewDimension);

            switch (obj.viewDimension)
            {
                case D3D11UavDimension.Buffer:
                    D3D11BufferUav.NativeWriteTo(buffer, obj.buffer);
                    buffer += D3D11BufferUav.NativeRequiredSize();
                    break;

                case D3D11UavDimension.Texture1D:
                    D3D11Texture1DUav.NativeWriteTo(buffer, obj.texture1D);
                    buffer += D3D11Texture1DUav.NativeRequiredSize();
                    break;

                case D3D11UavDimension.Texture1DArray:
                    D3D11Texture1DArrayUav.NativeWriteTo(buffer, obj.texture1DArray);
                    buffer += D3D11Texture1DArrayUav.NativeRequiredSize();
                    break;

                case D3D11UavDimension.Texture2D:
                    D3D11Texture2DUav.NativeWriteTo(buffer, obj.texture2D);
                    buffer += D3D11Texture2DUav.NativeRequiredSize();
                    break;

                case D3D11UavDimension.Texture2DArray:
                    D3D11Texture2DArrayUav.NativeWriteTo(buffer, obj.texture2DArray);
                    buffer += D3D11Texture2DArrayUav.NativeRequiredSize();
                    break;

                case D3D11UavDimension.Texture3D:
                    D3D11Texture3DUav.NativeWriteTo(buffer, obj.texture3D);
                    buffer += D3D11Texture3DUav.NativeRequiredSize();
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
    public static D3D11UnorderedAccessViewDesc NativeReadFrom(nint buffer)
    {
        D3D11UnorderedAccessViewDesc obj = default;
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.viewDimension = (D3D11UavDimension)DXMarshal.ReadInt32(ref buffer);

        switch (obj.viewDimension)
        {
            case D3D11UavDimension.Buffer:
                obj.buffer = D3D11BufferUav.NativeReadFrom(buffer);
                buffer += D3D11BufferUav.NativeRequiredSize();
                break;
            case D3D11UavDimension.Texture1D:
                obj.texture1D = D3D11Texture1DUav.NativeReadFrom(buffer);
                buffer += D3D11Texture1DUav.NativeRequiredSize();
                break;
            case D3D11UavDimension.Texture1DArray:
                obj.texture1DArray = D3D11Texture1DArrayUav.NativeReadFrom(buffer);
                buffer += D3D11Texture1DArrayUav.NativeRequiredSize();
                break;
            case D3D11UavDimension.Texture2D:
                obj.texture2D = D3D11Texture2DUav.NativeReadFrom(buffer);
                buffer += D3D11Texture2DUav.NativeRequiredSize();
                break;
            case D3D11UavDimension.Texture2DArray:
                obj.texture2DArray = D3D11Texture2DArrayUav.NativeReadFrom(buffer);
                buffer += D3D11Texture2DArrayUav.NativeRequiredSize();
                break;
            case D3D11UavDimension.Texture3D:
                obj.texture3D = D3D11Texture3DUav.NativeReadFrom(buffer);
                buffer += D3D11Texture3DUav.NativeRequiredSize();
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
    public static void NativeReadFrom(nint buffer, Span<D3D11UnorderedAccessViewDesc> objects)
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
    private D3D11UavDimension viewDimension;

    /// <summary>
    /// Specifies which buffer elements can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11BufferUav buffer;

    /// <summary>
    /// Specifies the subresources in a 1D texture that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture1DUav texture1D;

    /// <summary>
    /// Specifies the subresources in a 1D texture array that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture1DArrayUav texture1DArray;

    /// <summary>
    /// Specifies the subresources in a 2D texture that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DUav texture2D;

    /// <summary>
    /// Specifies the subresources in a 2D texture array that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture2DArrayUav texture2DArray;

    /// <summary>
    /// Specifies the subresources in a 3D texture that can be accessed.
    /// </summary>
    [FieldOffset(8)]
    private D3D11Texture3DUav texture3D;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11UavDimension viewDimension)
        : this(viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue, D3D11BufferUavOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11UavDimension viewDimension,
        DxgiFormat format)
        : this(viewDimension, format, 0, 0, uint.MaxValue, D3D11BufferUavOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(viewDimension, format, mipSlice, 0, uint.MaxValue, D3D11BufferUavOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice)
        : this(viewDimension, format, mipSlice, firstArraySlice, uint.MaxValue, D3D11BufferUavOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize)
        : this(viewDimension, format, mipSlice, firstArraySlice, arraySize, D3D11BufferUavOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    /// <param name="bufferOptions">The view options for a buffer.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize,
        D3D11BufferUavOptions bufferOptions)
    {
        this.format = format;
        this.viewDimension = viewDimension;

        switch (viewDimension)
        {
            case D3D11UavDimension.Buffer:
                this.buffer = new D3D11BufferUav
                {
                    FirstElement = mipSlice,
                    NumElements = firstArraySlice,
                    Options = bufferOptions
                };
                break;

            case D3D11UavDimension.Texture1D:
                this.texture1D = new D3D11Texture1DUav
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11UavDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArrayUav
                {
                    MipSlice = mipSlice,
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            case D3D11UavDimension.Texture2D:
                this.texture2D = new D3D11Texture2DUav
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11UavDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArrayUav
                {
                    MipSlice = mipSlice,
                    FirstArraySlice = firstArraySlice,
                    ArraySize = arraySize
                };
                break;

            case D3D11UavDimension.Texture3D:
                this.texture3D = new D3D11Texture3DUav
                {
                    MipSlice = mipSlice,
                    FirstWSlice = firstArraySlice,
                    WSize = arraySize
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(viewDimension));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="firstElement">The number of bytes between the beginning of the buffer and the first element to access.</param>
    /// <param name="numElements">The total number of elements in the view.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Buffer buffer,
        DxgiFormat format,
        uint firstElement,
        uint numElements)
        : this(buffer, format, firstElement, numElements, D3D11BufferUavOptions.None)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="buffer">A buffer.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="firstElement">The number of bytes between the beginning of the buffer and the first element to access.</param>
    /// <param name="numElements">The total number of elements in the view.</param>
    /// <param name="options">The view options for a buffer.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Buffer buffer,
        DxgiFormat format,
        uint firstElement,
        uint numElements,
        D3D11BufferUavOptions options)
    {
        if (buffer is null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        this.format = format;
        this.viewDimension = D3D11UavDimension.Buffer;
        this.buffer = new D3D11BufferUav
        {
            FirstElement = firstElement,
            NumElements = numElements,
            Options = options
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture1D texture,
        D3D11UavDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture1D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture1D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, viewDimension, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture1D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice)
        : this(texture, viewDimension, format, mipSlice, firstArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 1D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture1D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;

        if (format == DxgiFormat.Unknown
            || (arraySize == uint.MaxValue && viewDimension == D3D11UavDimension.Texture1DArray))
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
            case D3D11UavDimension.Texture1D:
                this.texture1D = new D3D11Texture1DUav
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11UavDimension.Texture1DArray:
                this.texture1DArray = new D3D11Texture1DArrayUav
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
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture2D texture,
        D3D11UavDimension viewDimension)
        : this(texture, viewDimension, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture2D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format)
        : this(texture, viewDimension, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture2D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, viewDimension, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture2D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice)
        : this(texture, viewDimension, format, mipSlice, firstArraySlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 2D texture.</param>
    /// <param name="viewDimension">The resource type of the view.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstArraySlice">The index of the first element to use in an array of elements.</param>
    /// <param name="arraySize">The number of elements in the array.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture2D texture,
        D3D11UavDimension viewDimension,
        DxgiFormat format,
        uint mipSlice,
        uint firstArraySlice,
        uint arraySize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = viewDimension;

        if (format == DxgiFormat.Unknown
            || (arraySize == uint.MaxValue && viewDimension == D3D11UavDimension.Texture2DArray))
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
            case D3D11UavDimension.Texture2D:
                this.texture2D = new D3D11Texture2DUav
                {
                    MipSlice = mipSlice
                };
                break;

            case D3D11UavDimension.Texture2DArray:
                this.texture2DArray = new D3D11Texture2DArrayUav
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
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture3D texture)
        : this(texture, DxgiFormat.Unknown, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format)
        : this(texture, format, 0, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mipSlice)
        : this(texture, format, mipSlice, 0, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstWSlice">The first depth level to use.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mipSlice,
        uint firstWSlice)
        : this(texture, format, mipSlice, firstWSlice, uint.MaxValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessViewDesc"/> struct.
    /// </summary>
    /// <param name="texture">A 3D texture.</param>
    /// <param name="format">The viewing format.</param>
    /// <param name="mipSlice">The index of the mipmap level to use mip slice.</param>
    /// <param name="firstWSlice">The first depth level to use.</param>
    /// <param name="wsize">The number of depth levels to use in the render-target view.</param>
    public D3D11UnorderedAccessViewDesc(
        D3D11Texture3D texture,
        DxgiFormat format,
        uint mipSlice,
        uint firstWSlice,
        uint wsize)
    {
        if (texture is null)
        {
            throw new ArgumentNullException(nameof(texture));
        }

        this.viewDimension = D3D11UavDimension.Texture3D;

        if (format == DxgiFormat.Unknown || wsize == uint.MaxValue)
        {
            var description = texture.Description;

            if (format == DxgiFormat.Unknown)
            {
                format = description.Format;
            }

            if (wsize == uint.MaxValue)
            {
                wsize = description.Depth - firstWSlice;
            }
        }

        this.format = format;
        this.texture3D = new D3D11Texture3DUav
        {
            MipSlice = mipSlice,
            FirstWSlice = firstWSlice,
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
    public D3D11UavDimension ViewDimension
    {
        get { return this.viewDimension; }
        set { this.viewDimension = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating which buffer elements can be accessed.
    /// </summary>
    public D3D11BufferUav Buffer
    {
        get { return this.buffer; }
        set { this.buffer = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 1D texture that can be accessed.
    /// </summary>
    public D3D11Texture1DUav Texture1D
    {
        get { return this.texture1D; }
        set { this.texture1D = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 1D texture array that can be accessed.
    /// </summary>
    public D3D11Texture1DArrayUav Texture1DArray
    {
        get { return this.texture1DArray; }
        set { this.texture1DArray = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 2D texture that can be accessed.
    /// </summary>
    public D3D11Texture2DUav Texture2D
    {
        get { return this.texture2D; }
        set { this.texture2D = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 2D texture array that can be accessed.
    /// </summary>
    public D3D11Texture2DArrayUav Texture2DArray
    {
        get { return this.texture2DArray; }
        set { this.texture2DArray = value; }
    }

    /// <summary>
    /// Gets or sets the subresources in a 3D texture that can be accessed.
    /// </summary>
    public D3D11Texture3DUav Texture3D
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
    public static bool operator ==(D3D11UnorderedAccessViewDesc left, D3D11UnorderedAccessViewDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11UnorderedAccessViewDesc left, D3D11UnorderedAccessViewDesc right)
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
        return obj is D3D11UnorderedAccessViewDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11UnorderedAccessViewDesc other)
    {
        return format == other.format &&
               viewDimension == other.viewDimension &&
               buffer.Equals(other.buffer) &&
               texture1D.Equals(other.texture1D) &&
               texture1DArray.Equals(other.texture1DArray) &&
               texture2D.Equals(other.texture2D) &&
               texture2DArray.Equals(other.texture2DArray) &&
               texture3D.Equals(other.texture3D);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1211303164;
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + viewDimension.GetHashCode();
        hashCode = hashCode * -1521134295 + buffer.GetHashCode();
        hashCode = hashCode * -1521134295 + texture1D.GetHashCode();
        hashCode = hashCode * -1521134295 + texture1DArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2D.GetHashCode();
        hashCode = hashCode * -1521134295 + texture2DArray.GetHashCode();
        hashCode = hashCode * -1521134295 + texture3D.GetHashCode();
        return hashCode;
    }
}
