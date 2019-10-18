// <copyright file="D3D11DepthStencilViewDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Specifies the subresources of a texture that are accessible from a depth-stencil view.
    /// </summary>
    [SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable", MessageId = "texture2DMsArray", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable", MessageId = "texture2DArray", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable", MessageId = "texture1DArray", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Explicit)]
    public struct D3D11DepthStencilViewDesc : IEquatable<D3D11DepthStencilViewDesc>
    {
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
            this.texture1D = new D3D11Texture1DDsv();
            this.texture1DArray = new D3D11Texture1DArrayDsv();
            this.texture2D = new D3D11Texture2DDsv();
            this.texture2DArray = new D3D11Texture2DArrayDsv();
            this.texture2DMs = new D3D11Texture2DMsDsv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayDsv();

            this.format = format;
            this.viewDimension = viewDimension;
            this.options = options;

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.texture1D = new D3D11Texture1DDsv();
            this.texture1DArray = new D3D11Texture1DArrayDsv();
            this.texture2D = new D3D11Texture2DDsv();
            this.texture2DArray = new D3D11Texture2DArrayDsv();
            this.texture2DMs = new D3D11Texture2DMsDsv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayDsv();

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
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture));
            }

            this.texture1D = new D3D11Texture1DDsv();
            this.texture1DArray = new D3D11Texture1DArrayDsv();
            this.texture2D = new D3D11Texture2DDsv();
            this.texture2DArray = new D3D11Texture2DArrayDsv();
            this.texture2DMs = new D3D11Texture2DMsDsv();
            this.texture2DMsArray = new D3D11Texture2DMsArrayDsv();

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
        /// Compares two <see cref="D3D11DepthStencilViewDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11DepthStencilViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11DepthStencilViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11DepthStencilViewDesc left, D3D11DepthStencilViewDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11DepthStencilViewDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11DepthStencilViewDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11DepthStencilViewDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11DepthStencilViewDesc left, D3D11DepthStencilViewDesc right)
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
            if (!(obj is D3D11DepthStencilViewDesc))
            {
                return false;
            }

            return this.Equals((D3D11DepthStencilViewDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11DepthStencilViewDesc other)
        {
            return this.format == other.format
                && this.viewDimension == other.viewDimension
                && this.options == other.options
                && this.texture1D == other.texture1D
                && this.texture1DArray == other.texture1DArray
                && this.texture2D == other.texture2D
                && this.texture2DArray == other.texture2DArray
                && this.texture2DMs == other.texture2DMs
                && this.texture2DMsArray == other.texture2DMsArray;
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
                this.options,
                this.texture1D,
                this.texture1DArray,
                this.texture2D,
                this.texture2DArray,
                this.texture2DMs,
                this.texture2DMsArray
            }
            .GetHashCode();
        }
    }
}
