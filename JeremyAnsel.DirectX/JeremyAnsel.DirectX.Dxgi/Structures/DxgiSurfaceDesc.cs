// <copyright file="DxgiSurfaceDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes a surface.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiSurfaceDesc : IEquatable<DxgiSurfaceDesc>
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
        size += sizeof(int); // enum
        size += DxgiSampleDesc.NativeRequiredSize();
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiSurfaceDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiSurfaceDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiSurfaceDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, (int)obj.format);
            DxgiSampleDesc.NativeWriteTo(buffer, obj.sampleDesc);
            buffer += DxgiSampleDesc.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiSurfaceDesc NativeReadFrom(nint buffer)
    {
        DxgiSurfaceDesc obj;
        obj.width = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.height = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.sampleDesc = DxgiSampleDesc.NativeReadFrom(buffer);
        buffer += DxgiSampleDesc.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiSurfaceDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value describing the surface width.
    /// </summary>
    private uint width;

    /// <summary>
    /// A value describing the surface height.
    /// </summary>
    private uint height;

    /// <summary>
    /// A member of the <see cref="DxgiFormat"/> enumeration that describes the surface format.
    /// </summary>
    private DxgiFormat format;

    /// <summary>
    /// A <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters for the surface.
    /// </summary>
    private DxgiSampleDesc sampleDesc;

    /// <summary>
    /// Gets or sets a value describing the surface width.
    /// </summary>
    public uint Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    /// <summary>
    /// Gets or sets a value describing the surface height.
    /// </summary>
    public uint Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiFormat"/> enumeration that describes the surface format.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets a <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters for the surface.
    /// </summary>
    public DxgiSampleDesc SampleDesc
    {
        get { return this.sampleDesc; }
        set { this.sampleDesc = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiSurfaceDesc left, DxgiSurfaceDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiSurfaceDesc left, DxgiSurfaceDesc right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0}x{1} {2} {3}",
            this.width,
            this.height,
            this.format,
            this.sampleDesc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiSurfaceDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiSurfaceDesc other)
    {
        return width == other.width &&
               height == other.height &&
               format == other.format &&
               sampleDesc.Equals(other.sampleDesc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1065130499;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + sampleDesc.GetHashCode();
        return hashCode;
    }
}
