// <copyright file="D3D11RenderTargetViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Specifies the subresources from a resource that are accessible using a render-target view.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11RenderTargetViewDesc : IEquatable<D3D11RenderTargetViewDesc>
    {
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
            this.buffer = new D3D11BufferRtv();
            this.texture1D = new D3D11Texture1DRtv();
            this.texture1DArray = new D3D11Texture1DArrayRtv();
            this.texture2D = new D3D11Texture2DRtv();
            this.texture2DArray = new D3D11Texture2DArrayRtv();
            this.texture2DMs = new D3D11Texture2DMsRtv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayRtv();
            this.texture3D = new D3D11Texture3DRtv();

            this.format = format;
            this.viewDimension = viewDimension;

            switch (viewDimension)
            {
                case D3D11RtvDimension.Buffer:
                    this.buffer = new D3D11BufferRtv
                    {
                        FirstElement = mipSlice,
                        NumElements = firtArraySlice
                    };
                    break;

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

                case D3D11RtvDimension.Texture3D:
                    this.texture3D = new D3D11Texture3DRtv
                    {
                        MipSlice = mipSlice,
                        FirstWSlice = firtArraySlice,
                        WSize = arraySize
                    };
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
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            this.buffer = new D3D11BufferRtv();
            this.texture1D = new D3D11Texture1DRtv();
            this.texture1DArray = new D3D11Texture1DArrayRtv();
            this.texture2D = new D3D11Texture2DRtv();
            this.texture2DArray = new D3D11Texture2DArrayRtv();
            this.texture2DMs = new D3D11Texture2DMsRtv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayRtv();
            this.texture3D = new D3D11Texture3DRtv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.buffer = new D3D11BufferRtv();
            this.texture1D = new D3D11Texture1DRtv();
            this.texture1DArray = new D3D11Texture1DArrayRtv();
            this.texture2D = new D3D11Texture2DRtv();
            this.texture2DArray = new D3D11Texture2DArrayRtv();
            this.texture2DMs = new D3D11Texture2DMsRtv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayRtv();
            this.texture3D = new D3D11Texture3DRtv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.buffer = new D3D11BufferRtv();
            this.texture1D = new D3D11Texture1DRtv();
            this.texture1DArray = new D3D11Texture1DArrayRtv();
            this.texture2D = new D3D11Texture2DRtv();
            this.texture2DArray = new D3D11Texture2DArrayRtv();
            this.texture2DMs = new D3D11Texture2DMsRtv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayRtv();
            this.texture3D = new D3D11Texture3DRtv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.buffer = new D3D11BufferRtv();
            this.texture1D = new D3D11Texture1DRtv();
            this.texture1DArray = new D3D11Texture1DArrayRtv();
            this.texture2D = new D3D11Texture2DRtv();
            this.texture2DArray = new D3D11Texture2DArrayRtv();
            this.texture2DMs = new D3D11Texture2DMsRtv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayRtv();
            this.texture3D = new D3D11Texture3DRtv();

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
        /// Compares two <see cref="D3D11RenderTargetViewDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11RenderTargetViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11RenderTargetViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11RenderTargetViewDesc left, D3D11RenderTargetViewDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11RenderTargetViewDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11RenderTargetViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11RenderTargetViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11RenderTargetViewDesc left, D3D11RenderTargetViewDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not D3D11RenderTargetViewDesc)
            {
                return false;
            }

            return this.Equals((D3D11RenderTargetViewDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11RenderTargetViewDesc other)
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
                && this.texture3D == other.texture3D;
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
                this.texture3D
            }
            .GetHashCode();
        }
    }
}
