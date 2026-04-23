// <copyright file="D3D11Texture3DDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a 3D texture.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Texture3DDesc : IEquatable<D3D11Texture3DDesc>
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
        size += sizeof(uint) * 4;
        size += sizeof(int) * 5;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Texture3DDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Texture3DDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Texture3DDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, obj.depth);
            DXMarshal.Write(ref buffer, obj.mipLevels);
            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.usage);
            DXMarshal.Write(ref buffer, (int)obj.bindOptions);
            DXMarshal.Write(ref buffer, (int)obj.cpuAccessOptions);
            DXMarshal.Write(ref buffer, (int)obj.miscOptions);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Texture3DDesc NativeReadFrom(nint buffer)
    {
        D3D11Texture3DDesc obj;
        obj.width = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.height = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.depth = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.mipLevels = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.usage = (D3D11Usage)DXMarshal.ReadInt32(ref buffer);
        obj.bindOptions = (D3D11BindOptions)DXMarshal.ReadInt32(ref buffer);
        obj.cpuAccessOptions = (D3D11CpuAccessOptions)DXMarshal.ReadInt32(ref buffer);
        obj.miscOptions = (D3D11ResourceMiscOptions)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Texture3DDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

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
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11Texture3DDesc left, D3D11Texture3DDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Texture3DDesc left, D3D11Texture3DDesc right)
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
        return obj is D3D11Texture3DDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Texture3DDesc other)
    {
        return width == other.width &&
               height == other.height &&
               depth == other.depth &&
               mipLevels == other.mipLevels &&
               format == other.format &&
               usage == other.usage &&
               bindOptions == other.bindOptions &&
               cpuAccessOptions == other.cpuAccessOptions &&
               miscOptions == other.miscOptions;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1015781703;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + depth.GetHashCode();
        hashCode = hashCode * -1521134295 + mipLevels.GetHashCode();
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + usage.GetHashCode();
        hashCode = hashCode * -1521134295 + bindOptions.GetHashCode();
        hashCode = hashCode * -1521134295 + cpuAccessOptions.GetHashCode();
        hashCode = hashCode * -1521134295 + miscOptions.GetHashCode();
        return hashCode;
    }
}
