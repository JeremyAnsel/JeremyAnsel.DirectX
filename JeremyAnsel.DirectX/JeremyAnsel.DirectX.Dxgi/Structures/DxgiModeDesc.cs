// <copyright file="DxgiModeDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes a display mode.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiModeDesc : IEquatable<DxgiModeDesc>
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
        size += DxgiRational.NativeRequiredSize();
        size += sizeof(int) * 3; // enum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiModeDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiModeDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiModeDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DxgiRational.NativeWriteTo(buffer, obj.refreshRate);
            buffer += DxgiRational.NativeRequiredSize();
            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.scanlineOrdering);
            DXMarshal.Write(ref buffer, (int)obj.scaling);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiModeDesc NativeReadFrom(nint buffer)
    {
        DxgiModeDesc obj;
        obj.width = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.height = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.refreshRate = DxgiRational.NativeReadFrom(buffer);
        buffer += DxgiRational.NativeRequiredSize();
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.scanlineOrdering = (DxgiModeScanlineOrder)DXMarshal.ReadInt32(ref buffer);
        obj.scaling = (DxgiModeScaling)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiModeDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that describes the resolution width.
    /// </summary>
    private uint width;

    /// <summary>
    /// A value describing the resolution height.
    /// </summary>
    private uint height;

    /// <summary>
    /// A <see cref="DxgiRational"/> structure describing the refresh rate in hertz.
    /// </summary>
    private DxgiRational refreshRate;

    /// <summary>
    /// A member of the <see cref="DxgiFormat"/> enumeration describing the display format.
    /// </summary>
    private DxgiFormat format;

    /// <summary>
    /// A member of the <see cref="DxgiModeScanlineOrder"/> enumeration describing the scanline drawing mode.
    /// </summary>
    private DxgiModeScanlineOrder scanlineOrdering;

    /// <summary>
    /// A member of the <see cref="DxgiModeScaling"/> enumeration describing the scaling mode.
    /// </summary>
    private DxgiModeScaling scaling;

    /// <summary>
    /// Gets or sets a value that describes the resolution width.
    /// </summary>
    public uint Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    /// <summary>
    /// Gets or sets a value describing the resolution height.
    /// </summary>
    public uint Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    /// <summary>
    /// Gets or sets a <see cref="DxgiRational"/> structure describing the refresh rate in hertz.
    /// </summary>
    public DxgiRational RefreshRate
    {
        get { return this.refreshRate; }
        set { this.refreshRate = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiFormat"/> enumeration describing the display format.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiModeScanlineOrder"/> enumeration describing the scanline drawing mode.
    /// </summary>
    public DxgiModeScanlineOrder ScanlineOrdering
    {
        get { return this.scanlineOrdering; }
        set { this.scanlineOrdering = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiModeScaling"/> enumeration describing the scaling mode.
    /// </summary>
    public DxgiModeScaling Scaling
    {
        get { return this.scaling; }
        set { this.scaling = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiModeDesc left, DxgiModeDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiModeDesc left, DxgiModeDesc right)
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
            "{0}x{1} {2} Hz {3}",
            this.width,
            this.height,
            this.refreshRate,
            this.format);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiModeDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiModeDesc other)
    {
        return width == other.width &&
               height == other.height &&
               refreshRate.Equals(other.refreshRate) &&
               format == other.format &&
               scanlineOrdering == other.scanlineOrdering &&
               scaling == other.scaling;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -577747255;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + refreshRate.GetHashCode();
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + scanlineOrdering.GetHashCode();
        hashCode = hashCode * -1521134295 + scaling.GetHashCode();
        return hashCode;
    }
}
