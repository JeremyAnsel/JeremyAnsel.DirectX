// <copyright file="DxgiSwapChainFullscreenDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes full-screen mode for a swap chain.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiSwapChainFullscreenDesc : IEquatable<DxgiSwapChainFullscreenDesc>
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
        size += DxgiRational.NativeRequiredSize();
        size += sizeof(int) * 2; // enum
        size += sizeof(int); // bool
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiSwapChainFullscreenDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiSwapChainFullscreenDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiSwapChainFullscreenDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DxgiRational.NativeWriteTo(buffer, obj.refreshRate);
            buffer += DxgiRational.NativeRequiredSize();
            DXMarshal.Write(ref buffer, (int)obj.scanlineOrdering);
            DXMarshal.Write(ref buffer, (int)obj.scaling);
            DXMarshal.Write(ref buffer, obj.isWindowed);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiSwapChainFullscreenDesc NativeReadFrom(nint buffer)
    {
        DxgiSwapChainFullscreenDesc obj;
        obj.refreshRate = DxgiRational.NativeReadFrom(buffer);
        buffer += DxgiRational.NativeRequiredSize();
        obj.scanlineOrdering = (DxgiModeScanlineOrder)DXMarshal.ReadInt32(ref buffer);
        obj.scaling = (DxgiModeScaling)DXMarshal.ReadInt32(ref buffer);
        obj.isWindowed = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiSwapChainFullscreenDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A <see cref="DxgiRational"/> structure that describes the refresh rate in hertz.
    /// </summary>
    private DxgiRational refreshRate;

    /// <summary>
    /// A member of the <see cref="DxgiModeScanlineOrder"/> enumeration that describes the scan-line drawing mode.
    /// </summary>
    private DxgiModeScanlineOrder scanlineOrdering;

    /// <summary>
    /// A member of the <see cref="DxgiModeScaling"/> enumeration that describes the scaling mode.
    /// </summary>
    private DxgiModeScaling scaling;

    /// <summary>
    /// A value that specifies whether the swap chain is in windowed mode. <value>true</value> if the swap chain is in windowed mode; otherwise, <value>false</value>.
    /// </summary>
    private bool isWindowed;

    /// <summary>
    /// Gets or sets a <see cref="DxgiRational"/> structure that describes the refresh rate in hertz.
    /// </summary>
    public DxgiRational RefreshRate
    {
        get { return this.refreshRate; }
        set { this.refreshRate = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiModeScanlineOrder"/> enumeration that describes the scan-line drawing mode.
    /// </summary>
    public DxgiModeScanlineOrder ScanlineOrdering
    {
        get { return this.scanlineOrdering; }
        set { this.scanlineOrdering = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiModeScaling"/> enumeration that describes the scaling mode.
    /// </summary>
    public DxgiModeScaling Scaling
    {
        get { return this.scaling; }
        set { this.scaling = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the swap chain is in windowed mode.
    /// </summary>
    public bool IsWindowed
    {
        get { return this.isWindowed; }
        set { this.isWindowed = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiSwapChainFullscreenDesc left, DxgiSwapChainFullscreenDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiSwapChainFullscreenDesc left, DxgiSwapChainFullscreenDesc right)
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
        return obj is DxgiSwapChainFullscreenDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiSwapChainFullscreenDesc other)
    {
        return refreshRate.Equals(other.refreshRate) &&
               scanlineOrdering == other.scanlineOrdering &&
               scaling == other.scaling &&
               isWindowed == other.isWindowed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1079135150;
        hashCode = hashCode * -1521134295 + refreshRate.GetHashCode();
        hashCode = hashCode * -1521134295 + scanlineOrdering.GetHashCode();
        hashCode = hashCode * -1521134295 + scaling.GetHashCode();
        hashCode = hashCode * -1521134295 + isWindowed.GetHashCode();
        return hashCode;
    }
}
