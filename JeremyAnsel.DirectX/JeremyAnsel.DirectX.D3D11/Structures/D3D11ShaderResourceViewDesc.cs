// <copyright file="D3D11ShaderResourceViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Describes a shader resource view.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11ShaderResourceViewDesc : IEquatable<D3D11ShaderResourceViewDesc>
    {
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
            this.buffer = new D3D11BufferSrv();
            this.texture1D = new D3D11Texture1DSrv();
            this.texture1DArray = new D3D11Texture1DArraySrv();
            this.texture2D = new D3D11Texture2DSrv();
            this.texture2DArray = new D3D11Texture2DArraySrv();
            this.texture2DMs = new D3D11Texture2DMsSrv();
            this.texture2DMsArray = new D3D11Texture2DMsArraySrv();
            this.texture3D = new D3D11Texture3DSrv();
            this.textureCube = new D3D11TextureCubeSrv();
            this.textureCubeArray = new D3D11TextureCubeArraySrv();
            this.bufferEx = new D3D11BufferExSrv();

            this.format = format;
            this.viewDimension = viewDimension;

            switch (viewDimension)
            {
                case D3D11SrvDimension.Buffer:
                    this.buffer = new D3D11BufferSrv
                    {
                        FirstElement = mostDetailedMip,
                        NumElements = mipLevels
                    };
                    break;

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

                case D3D11SrvDimension.Texture3D:
                    this.texture3D = new D3D11Texture3DSrv
                    {
                        MostDetailedMip = mostDetailedMip,
                        MipLevels = mipLevels
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

                case D3D11SrvDimension.BufferEx:
                    this.bufferEx = new D3D11BufferExSrv
                    {
                        FirstElement = mostDetailedMip,
                        NumElements = mipLevels,
                        Options = bufferExOptions
                    };
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
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            this.buffer = new D3D11BufferSrv();
            this.texture1D = new D3D11Texture1DSrv();
            this.texture1DArray = new D3D11Texture1DArraySrv();
            this.texture2D = new D3D11Texture2DSrv();
            this.texture2DArray = new D3D11Texture2DArraySrv();
            this.texture2DMs = new D3D11Texture2DMsSrv();
            this.texture2DMsArray = new D3D11Texture2DMsArraySrv();
            this.texture3D = new D3D11Texture3DSrv();
            this.textureCube = new D3D11TextureCubeSrv();
            this.textureCubeArray = new D3D11TextureCubeArraySrv();
            this.bufferEx = new D3D11BufferExSrv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.buffer = new D3D11BufferSrv();
            this.texture1D = new D3D11Texture1DSrv();
            this.texture1DArray = new D3D11Texture1DArraySrv();
            this.texture2D = new D3D11Texture2DSrv();
            this.texture2DArray = new D3D11Texture2DArraySrv();
            this.texture2DMs = new D3D11Texture2DMsSrv();
            this.texture2DMsArray = new D3D11Texture2DMsArraySrv();
            this.texture3D = new D3D11Texture3DSrv();
            this.textureCube = new D3D11TextureCubeSrv();
            this.textureCubeArray = new D3D11TextureCubeArraySrv();
            this.bufferEx = new D3D11BufferExSrv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.buffer = new D3D11BufferSrv();
            this.texture1D = new D3D11Texture1DSrv();
            this.texture1DArray = new D3D11Texture1DArraySrv();
            this.texture2D = new D3D11Texture2DSrv();
            this.texture2DArray = new D3D11Texture2DArraySrv();
            this.texture2DMs = new D3D11Texture2DMsSrv();
            this.texture2DMsArray = new D3D11Texture2DMsArraySrv();
            this.texture3D = new D3D11Texture3DSrv();
            this.textureCube = new D3D11TextureCubeSrv();
            this.textureCubeArray = new D3D11TextureCubeArraySrv();
            this.bufferEx = new D3D11BufferExSrv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.buffer = new D3D11BufferSrv();
            this.texture1D = new D3D11Texture1DSrv();
            this.texture1DArray = new D3D11Texture1DArraySrv();
            this.texture2D = new D3D11Texture2DSrv();
            this.texture2DArray = new D3D11Texture2DArraySrv();
            this.texture2DMs = new D3D11Texture2DMsSrv();
            this.texture2DMsArray = new D3D11Texture2DMsArraySrv();
            this.texture3D = new D3D11Texture3DSrv();
            this.textureCube = new D3D11TextureCubeSrv();
            this.textureCubeArray = new D3D11TextureCubeArraySrv();
            this.bufferEx = new D3D11BufferExSrv();

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
        /// Compares two <see cref="D3D11ShaderResourceViewDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11ShaderResourceViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11ShaderResourceViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11ShaderResourceViewDesc left, D3D11ShaderResourceViewDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11ShaderResourceViewDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11ShaderResourceViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11ShaderResourceViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11ShaderResourceViewDesc left, D3D11ShaderResourceViewDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is D3D11ShaderResourceViewDesc))
            {
                return false;
            }

            return this.Equals((D3D11ShaderResourceViewDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11ShaderResourceViewDesc other)
        {
            return this.format == other.format
                && this.viewDimension == other.viewDimension
                && this.buffer == other.buffer
                && this.texture1D == other.texture1D
                && this.texture1DArray == other.texture1DArray
                && this.texture2D == other.texture2D
                && this.texture2DArray == other.texture2DArray
                && this.texture2DMs == other.texture2DMs
                && this.texture2DMsArray == other.texture2DMsArray
                && this.texture3D == other.texture3D
                && this.textureCube == other.textureCube
                && this.textureCubeArray == other.textureCubeArray
                && this.bufferEx == other.bufferEx;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.format,
                this.viewDimension,
                this.buffer,
                this.texture1D,
                this.texture1DArray,
                this.texture2D,
                this.texture2DArray,
                this.texture2DMs,
                this.texture2DMsArray,
                this.texture3D,
                this.textureCube,
                this.textureCubeArray,
                this.bufferEx
            }
            .GetHashCode();
        }
    }
}
