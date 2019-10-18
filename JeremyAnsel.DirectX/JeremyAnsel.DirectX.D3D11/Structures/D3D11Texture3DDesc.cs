// <copyright file="D3D11Texture3DDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Describes a 3D texture.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Texture3DDesc : IEquatable<D3D11Texture3DDesc>
    {
        /// <summary>
        /// The texture width (in texels).
        /// </summary>
        private uint width;

        /// <summary>
        /// The texture height (in texels).
        /// </summary>
        private uint height;

        /// <summary>
        /// The texture depth (in texels).
        /// </summary>
        private uint depth;

        /// <summary>
        /// The maximum number of mipmap levels in the texture.
        /// </summary>
        private uint mipLevels;

        /// <summary>
        /// The texture format.
        /// </summary>
        private DxgiFormat format;

        /// <summary>
        /// Identifies how the texture is to be read from and written to.
        /// </summary>
        private D3D11Usage usage;

        /// <summary>
        /// Options for binding to pipeline stages.
        /// </summary>
        private D3D11BindOptions bindOptions;

        /// <summary>
        /// Options to specify the types of CPU access allowed.
        /// </summary>
        private D3D11CpuAccessOptions cpuAccessOptions;

        /// <summary>
        /// Options that identify other, less common resource options.
        /// </summary>
        private D3D11ResourceMiscOptions miscOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3DDesc"/> struct.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The texture width (in texels).</param>
        /// <param name="height">The texture height (in texels).</param>
        /// <param name="depth">The texture depth (in texels).</param>
        public D3D11Texture3DDesc(DxgiFormat format, uint width, uint height, uint depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = 0;
            this.format = format;
            this.usage = D3D11Usage.Default;
            this.bindOptions = D3D11BindOptions.ShaderResource;
            this.cpuAccessOptions = 0;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3DDesc"/> struct.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The texture width (in texels).</param>
        /// <param name="height">The texture height (in texels).</param>
        /// <param name="depth">The texture depth (in texels).</param>
        /// <param name="mipLevels">The maximum number of mipmap levels in the texture.</param>
        public D3D11Texture3DDesc(DxgiFormat format, uint width, uint height, uint depth, uint mipLevels)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = mipLevels;
            this.format = format;
            this.usage = D3D11Usage.Default;
            this.bindOptions = D3D11BindOptions.ShaderResource;
            this.cpuAccessOptions = 0;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3DDesc"/> struct.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The texture width (in texels).</param>
        /// <param name="height">The texture height (in texels).</param>
        /// <param name="depth">The texture depth (in texels).</param>
        /// <param name="mipLevels">The maximum number of mipmap levels in the texture.</param>
        /// <param name="bindOptions">Options for binding to pipeline stages.</param>
        public D3D11Texture3DDesc(
            DxgiFormat format,
            uint width,
            uint height,
            uint depth,
            uint mipLevels,
            D3D11BindOptions bindOptions)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = mipLevels;
            this.format = format;
            this.usage = D3D11Usage.Default;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = 0;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3DDesc"/> struct.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The texture width (in texels).</param>
        /// <param name="height">The texture height (in texels).</param>
        /// <param name="depth">The texture depth (in texels).</param>
        /// <param name="mipLevels">The maximum number of mipmap levels in the texture.</param>
        /// <param name="bindOptions">Options for binding to pipeline stages.</param>
        /// <param name="usage">Identifies how the texture is to be read from and written to.</param>
        public D3D11Texture3DDesc(
            DxgiFormat format,
            uint width,
            uint height,
            uint depth,
            uint mipLevels,
            D3D11BindOptions bindOptions,
            D3D11Usage usage)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = mipLevels;
            this.format = format;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = 0;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3DDesc"/> struct.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The texture width (in texels).</param>
        /// <param name="height">The texture height (in texels).</param>
        /// <param name="depth">The texture depth (in texels).</param>
        /// <param name="mipLevels">The maximum number of mipmap levels in the texture.</param>
        /// <param name="bindOptions">Options for binding to pipeline stages.</param>
        /// <param name="usage">Identifies how the texture is to be read from and written to.</param>
        /// <param name="cpuAccessOptions">Options to specify the types of CPU access allowed.</param>
        public D3D11Texture3DDesc(
            DxgiFormat format,
            uint width,
            uint height,
            uint depth,
            uint mipLevels,
            D3D11BindOptions bindOptions,
            D3D11Usage usage,
            D3D11CpuAccessOptions cpuAccessOptions)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = mipLevels;
            this.format = format;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = cpuAccessOptions;
            this.miscOptions = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3DDesc"/> struct.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="width">The texture width (in texels).</param>
        /// <param name="height">The texture height (in texels).</param>
        /// <param name="depth">The texture depth (in texels).</param>
        /// <param name="mipLevels">The maximum number of mipmap levels in the texture.</param>
        /// <param name="bindOptions">Options for binding to pipeline stages.</param>
        /// <param name="usage">Identifies how the texture is to be read from and written to.</param>
        /// <param name="cpuAccessOptions">Options to specify the types of CPU access allowed.</param>
        /// <param name="miscOptions">Options that identify other, less common resource options.</param>
        public D3D11Texture3DDesc(
            DxgiFormat format,
            uint width,
            uint height,
            uint depth,
            uint mipLevels,
            D3D11BindOptions bindOptions,
            D3D11Usage usage,
            D3D11CpuAccessOptions cpuAccessOptions,
            D3D11ResourceMiscOptions miscOptions)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.mipLevels = mipLevels;
            this.format = format;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = cpuAccessOptions;
            this.miscOptions = miscOptions;
        }

        /// <summary>
        /// Gets or sets the texture width (in texels).
        /// </summary>
        public uint Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the texture height (in texels).
        /// </summary>
        public uint Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Gets or sets the texture depth (in texels).
        /// </summary>
        public uint Depth
        {
            get { return this.depth; }
            set { this.depth = value; }
        }

        /// <summary>
        /// Gets or sets the maximum number of mipmap levels in the texture.
        /// </summary>
        public uint MipLevels
        {
            get { return this.mipLevels; }
            set { this.mipLevels = value; }
        }

        /// <summary>
        /// Gets or sets the texture format.
        /// </summary>
        public DxgiFormat Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how the texture is to be read from and written to.
        /// </summary>
        public D3D11Usage Usage
        {
            get { return this.usage; }
            set { this.usage = value; }
        }

        /// <summary>
        /// Gets or sets options for binding to pipeline stages.
        /// </summary>
        public D3D11BindOptions BindOptions
        {
            get { return this.bindOptions; }
            set { this.bindOptions = value; }
        }

        /// <summary>
        /// Gets or sets options to specify the types of CPU access allowed.
        /// </summary>
        public D3D11CpuAccessOptions CpuAccessOptions
        {
            get { return this.cpuAccessOptions; }
            set { this.cpuAccessOptions = value; }
        }

        /// <summary>
        /// Gets or sets options that identify other, less common resource options.
        /// </summary>
        public D3D11ResourceMiscOptions MiscOptions
        {
            get { return this.miscOptions; }
            set { this.miscOptions = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture3DDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture3DDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture3DDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Texture3DDesc left, D3D11Texture3DDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Texture3DDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Texture3DDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Texture3DDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Texture3DDesc left, D3D11Texture3DDesc right)
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
            if (!(obj is D3D11Texture3DDesc))
            {
                return false;
            }

            return this.Equals((D3D11Texture3DDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Texture3DDesc other)
        {
            return this.width == other.width
                && this.height == other.height
                && this.depth == other.depth
                && this.mipLevels == other.mipLevels
                && this.format == other.format
                && this.usage == other.usage
                && this.bindOptions == other.bindOptions
                && this.cpuAccessOptions == other.cpuAccessOptions
                && this.miscOptions == other.miscOptions;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.width,
                this.height,
                this.depth,
                this.mipLevels,
                this.format,
                this.usage,
                this.bindOptions,
                this.cpuAccessOptions,
                this.miscOptions
            }
            .GetHashCode();
        }
    }
}
