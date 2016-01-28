// <copyright file="D3D11UnorderedAccessViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Specifies the subresources from a resource that are accessible using an unordered-access view.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11UnorderedAccessViewDesc : IEquatable<D3D11UnorderedAccessViewDesc>
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
            this.buffer = new D3D11BufferUav();
            this.texture1D = new D3D11Texture1DUav();
            this.texture1DArray = new D3D11Texture1DArrayUav();
            this.texture2D = new D3D11Texture2DUav();
            this.texture2DArray = new D3D11Texture2DArrayUav();
            this.texture3D = new D3D11Texture3DUav();

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
                    throw new ArgumentOutOfRangeException("viewDimension");
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
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            this.buffer = new D3D11BufferUav();
            this.texture1D = new D3D11Texture1DUav();
            this.texture1DArray = new D3D11Texture1DArrayUav();
            this.texture2D = new D3D11Texture2DUav();
            this.texture2DArray = new D3D11Texture2DArrayUav();
            this.texture3D = new D3D11Texture3DUav();

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
            if (texture == null)
            {
                throw new ArgumentNullException("texture");
            }

            this.buffer = new D3D11BufferUav();
            this.texture1D = new D3D11Texture1DUav();
            this.texture1DArray = new D3D11Texture1DArrayUav();
            this.texture2D = new D3D11Texture2DUav();
            this.texture2DArray = new D3D11Texture2DArrayUav();
            this.texture3D = new D3D11Texture3DUav();

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
                    throw new ArgumentOutOfRangeException("viewDimension");
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
            if (texture == null)
            {
                throw new ArgumentNullException("texture");
            }

            this.buffer = new D3D11BufferUav();
            this.texture1D = new D3D11Texture1DUav();
            this.texture1DArray = new D3D11Texture1DArrayUav();
            this.texture2D = new D3D11Texture2DUav();
            this.texture2DArray = new D3D11Texture2DArrayUav();
            this.texture3D = new D3D11Texture3DUav();

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
                    throw new ArgumentOutOfRangeException("viewDimension");
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
            if (texture == null)
            {
                throw new ArgumentNullException("texture");
            }

            this.buffer = new D3D11BufferUav();
            this.texture1D = new D3D11Texture1DUav();
            this.texture1DArray = new D3D11Texture1DArrayUav();
            this.texture2D = new D3D11Texture2DUav();
            this.texture2DArray = new D3D11Texture2DArrayUav();
            this.texture3D = new D3D11Texture3DUav();

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
        /// Compares two <see cref="D3D11UnorderedAccessViewDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11UnorderedAccessViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11UnorderedAccessViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11UnorderedAccessViewDesc left, D3D11UnorderedAccessViewDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11UnorderedAccessViewDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11UnorderedAccessViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11UnorderedAccessViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11UnorderedAccessViewDesc left, D3D11UnorderedAccessViewDesc right)
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
            if (!(obj is D3D11UnorderedAccessViewDesc))
            {
                return false;
            }

            return this.Equals((D3D11UnorderedAccessViewDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11UnorderedAccessViewDesc other)
        {
            return this.format == other.format
                && this.viewDimension == other.viewDimension
                && this.buffer == other.buffer
                && this.texture1D == other.texture1D
                && this.texture1DArray == other.texture1DArray
                && this.texture2D == other.texture2D
                && this.texture2DArray == other.texture2DArray
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
                this.texture3D
            }
            .GetHashCode();
        }
    }
}
