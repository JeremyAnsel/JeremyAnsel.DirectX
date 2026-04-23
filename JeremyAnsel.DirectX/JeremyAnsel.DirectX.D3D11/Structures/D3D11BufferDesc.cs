// <copyright file="D3D11BufferDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a buffer resource.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11BufferDesc : IEquatable<D3D11BufferDesc>
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
        size += sizeof(uint) * 2;
        size += sizeof(int) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11BufferDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11BufferDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11BufferDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.byteWidth);
            DXMarshal.Write(ref buffer, (int)obj.usage);
            DXMarshal.Write(ref buffer, (int)obj.bindOptions);
            DXMarshal.Write(ref buffer, (int)obj.cpuAccessOptions);
            DXMarshal.Write(ref buffer, (int)obj.miscOptions);
            DXMarshal.Write(ref buffer, obj.structureByteStride);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11BufferDesc NativeReadFrom(nint buffer)
    {
        D3D11BufferDesc obj;
        obj.byteWidth = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.usage = (D3D11Usage)DXMarshal.ReadInt32(ref buffer);
        obj.bindOptions = (D3D11BindOptions)DXMarshal.ReadInt32(ref buffer);
        obj.cpuAccessOptions = (D3D11CpuAccessOptions)DXMarshal.ReadInt32(ref buffer);
        obj.miscOptions = (D3D11ResourceMiscOptions)DXMarshal.ReadInt32(ref buffer);
        obj.structureByteStride = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11BufferDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Size of the buffer in bytes.
    /// </summary>
    private uint byteWidth;

    /// <summary>
    /// Identify how the buffer is expected to be read from and written to.
    /// </summary>
    private D3D11Usage usage;

    /// <summary>
    /// Identify how the buffer will be bound to the pipeline.
    /// </summary>
    private D3D11BindOptions bindOptions;

    /// <summary>
    /// CPU access flags or 0 if no CPU access is necessary.
    /// </summary>
    private D3D11CpuAccessOptions cpuAccessOptions;

    /// <summary>
    /// Miscellaneous flags or 0 if unused.
    /// </summary>
    private D3D11ResourceMiscOptions miscOptions;

    /// <summary>
    /// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
    /// </summary>
    private uint structureByteStride;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
    /// </summary>
    /// <param name="byteWidth">Size of the buffer in bytes.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11BufferDesc(uint byteWidth, D3D11BindOptions bindOptions)
    {
        this.byteWidth = byteWidth;
        this.usage = D3D11Usage.Default;
        this.bindOptions = bindOptions;
        this.cpuAccessOptions = 0;
        this.miscOptions = D3D11ResourceMiscOptions.None;
        this.structureByteStride = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
    /// </summary>
    /// <param name="byteWidth">Size of the buffer in bytes.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11BufferDesc(uint byteWidth, D3D11BindOptions bindOptions, D3D11Usage usage)
    {
        this.byteWidth = byteWidth;
        this.usage = usage;
        this.bindOptions = bindOptions;
        this.cpuAccessOptions = 0;
        this.miscOptions = D3D11ResourceMiscOptions.None;
        this.structureByteStride = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
    /// </summary>
    /// <param name="byteWidth">Size of the buffer in bytes.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    /// <param name="cpuAccessOptions">CPU access flags or 0 if no CPU access is necessary.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11BufferDesc(
        uint byteWidth,
        D3D11BindOptions bindOptions,
        D3D11Usage usage,
        D3D11CpuAccessOptions cpuAccessOptions)
    {
        this.byteWidth = byteWidth;
        this.usage = usage;
        this.bindOptions = bindOptions;
        this.cpuAccessOptions = cpuAccessOptions;
        this.miscOptions = D3D11ResourceMiscOptions.None;
        this.structureByteStride = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
    /// </summary>
    /// <param name="byteWidth">Size of the buffer in bytes.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    /// <param name="cpuAccessOptions">CPU access flags or 0 if no CPU access is necessary.</param>
    /// <param name="miscOptions">Miscellaneous flags or 0 if unused.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11BufferDesc(
        uint byteWidth,
        D3D11BindOptions bindOptions,
        D3D11Usage usage,
        D3D11CpuAccessOptions cpuAccessOptions,
        D3D11ResourceMiscOptions miscOptions)
    {
        this.byteWidth = byteWidth;
        this.usage = usage;
        this.bindOptions = bindOptions;
        this.cpuAccessOptions = cpuAccessOptions;
        this.miscOptions = miscOptions;
        this.structureByteStride = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
    /// </summary>
    /// <param name="byteWidth">Size of the buffer in bytes.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    /// <param name="cpuAccessOptions">CPU access flags or 0 if no CPU access is necessary.</param>
    /// <param name="miscOptions">Miscellaneous flags or 0 if unused.</param>
    /// <param name="structureByteStride">The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11BufferDesc(
        uint byteWidth,
        D3D11BindOptions bindOptions,
        D3D11Usage usage,
        D3D11CpuAccessOptions cpuAccessOptions,
        D3D11ResourceMiscOptions miscOptions,
        uint structureByteStride)
    {
        this.byteWidth = byteWidth;
        this.usage = usage;
        this.bindOptions = bindOptions;
        this.cpuAccessOptions = cpuAccessOptions;
        this.miscOptions = miscOptions;
        this.structureByteStride = structureByteStride;
    }

    /// <summary>
    /// Gets or sets the size of the buffer in bytes.
    /// </summary>
    public uint ByteWidth
    {
        get { return this.byteWidth; }
        set { this.byteWidth = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating how the buffer is expected to be read from and written to.
    /// </summary>
    public D3D11Usage Usage
    {
        get { return this.usage; }
        set { this.usage = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating how the buffer will be bound to the pipeline.
    /// </summary>
    public D3D11BindOptions BindOptions
    {
        get { return this.bindOptions; }
        set { this.bindOptions = value; }
    }

    /// <summary>
    /// Gets or sets the CPU access flags or 0 if no CPU access is necessary.
    /// </summary>
    public D3D11CpuAccessOptions CpuAccessOptions
    {
        get { return this.cpuAccessOptions; }
        set { this.cpuAccessOptions = value; }
    }

    /// <summary>
    /// Gets or sets the miscellaneous flags or 0 if unused.
    /// </summary>
    public D3D11ResourceMiscOptions MiscOptions
    {
        get { return this.miscOptions; }
        set { this.miscOptions = value; }
    }

    /// <summary>
    /// Gets or sets the size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
    /// </summary>
    public uint StructureByteStride
    {
        get { return this.structureByteStride; }
        set { this.structureByteStride = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11BufferDesc left, D3D11BufferDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11BufferDesc left, D3D11BufferDesc right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
    /// </summary>
    /// <typeparam name="T">A struct.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
    public static D3D11BufferDesc From<T>(T[] data, D3D11BindOptions bindOptions)
        where T : unmanaged
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return new D3D11BufferDesc((uint)sizeof(T) * (uint)data.Length, bindOptions);
    }

    /// <summary>
    /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
    /// </summary>
    /// <typeparam name="T">A struct.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
    public static D3D11BufferDesc From<T>(T[] data, D3D11BindOptions bindOptions, D3D11Usage usage)
        where T : unmanaged
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return new D3D11BufferDesc((uint)sizeof(T) * (uint)data.Length, bindOptions, usage);
    }

    /// <summary>
    /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
    /// </summary>
    /// <typeparam name="T">A struct.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
    public static D3D11BufferDesc From<T>(ReadOnlySpan<T> data, D3D11BindOptions bindOptions)
        where T : unmanaged
    {
        return new D3D11BufferDesc((uint)sizeof(T) * (uint)data.Length, bindOptions);
    }

    /// <summary>
    /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
    /// </summary>
    /// <typeparam name="T">A struct.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
    public static D3D11BufferDesc From<T>(ReadOnlySpan<T> data, D3D11BindOptions bindOptions, D3D11Usage usage)
        where T : unmanaged
    {
        return new D3D11BufferDesc((uint)sizeof(T) * (uint)data.Length, bindOptions, usage);
    }

    /// <summary>
    /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
    /// </summary>
    /// <typeparam name="T">A struct.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
    public static D3D11BufferDesc From<T>(D3D11BindOptions bindOptions)
        where T : unmanaged
    {
        return new D3D11BufferDesc((uint)sizeof(T), bindOptions);
    }

    /// <summary>
    /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
    /// </summary>
    /// <typeparam name="T">A struct.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
    /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
    /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
    public static D3D11BufferDesc From<T>(D3D11BindOptions bindOptions, D3D11Usage usage)
        where T : unmanaged
    {
        return new D3D11BufferDesc((uint)sizeof(T), bindOptions, usage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is D3D11BufferDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11BufferDesc other)
    {
        return byteWidth == other.byteWidth &&
               usage == other.usage &&
               bindOptions == other.bindOptions &&
               cpuAccessOptions == other.cpuAccessOptions &&
               miscOptions == other.miscOptions &&
               structureByteStride == other.structureByteStride;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1326881094;
        hashCode = hashCode * -1521134295 + byteWidth.GetHashCode();
        hashCode = hashCode * -1521134295 + usage.GetHashCode();
        hashCode = hashCode * -1521134295 + bindOptions.GetHashCode();
        hashCode = hashCode * -1521134295 + cpuAccessOptions.GetHashCode();
        hashCode = hashCode * -1521134295 + miscOptions.GetHashCode();
        hashCode = hashCode * -1521134295 + structureByteStride.GetHashCode();
        return hashCode;
    }
}
