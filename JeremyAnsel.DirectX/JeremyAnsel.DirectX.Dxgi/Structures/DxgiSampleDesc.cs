// <copyright file="DxgiSampleDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes multi-sampling parameters for a resource.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiSampleDesc : IEquatable<DxgiSampleDesc>
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
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiSampleDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiSampleDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiSampleDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.count);
            DXMarshal.Write(ref buffer, obj.quality);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiSampleDesc NativeReadFrom(nint buffer)
    {
        DxgiSampleDesc obj;
        obj.count = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.quality = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiSampleDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of multi-samples per pixel.
    /// </summary>
    private uint count;

    /// <summary>
    /// The image quality level. The higher the quality, the lower the performance.
    /// </summary>
    private uint quality;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiSampleDesc"/> struct.
    /// </summary>
    /// <param name="count">The number of multi-samples per pixel.</param>
    /// <param name="quality">The image quality level. The higher the quality, the lower the performance.</param>
    public DxgiSampleDesc(uint count, uint quality)
    {
        this.count = count;
        this.quality = quality;
    }

    /// <summary>
    /// Gets or sets the number of multi-samples per pixel.
    /// </summary>
    public uint Count
    {
        get { return this.count; }
        set { this.count = value; }
    }

    /// <summary>
    /// Gets or sets the image quality level. The higher the quality, the lower the performance.
    /// </summary>
    public uint Quality
    {
        get { return this.quality; }
        set { this.quality = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiSampleDesc left, DxgiSampleDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiSampleDesc left, DxgiSampleDesc right)
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
            "SampleCount:{0} SampleQuality:{1}",
            this.count,
            this.quality);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiSampleDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiSampleDesc other)
    {
        return count == other.count &&
               quality == other.quality;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -586686406;
        hashCode = hashCode * -1521134295 + count.GetHashCode();
        hashCode = hashCode * -1521134295 + quality.GetHashCode();
        return hashCode;
    }
}
