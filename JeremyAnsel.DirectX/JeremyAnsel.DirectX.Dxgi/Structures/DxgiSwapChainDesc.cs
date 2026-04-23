// <copyright file="DxgiSwapChainDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes a swap chain.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiSwapChainDesc : IEquatable<DxgiSwapChainDesc>
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
        size += DxgiModeDesc.NativeRequiredSize();
        size += DxgiSampleDesc.NativeRequiredSize();
        size += sizeof(int) * 3; // enum
        size += sizeof(uint);
        size += sizeof(nint);
        size += sizeof(int); // bool
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiSwapChainDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiSwapChainDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiSwapChainDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DxgiModeDesc.NativeWriteTo(buffer, obj.bufferDescription);
            buffer += DxgiModeDesc.NativeRequiredSize();
            DxgiSampleDesc.NativeWriteTo(buffer, obj.sampleDescription);
            buffer += DxgiSampleDesc.NativeRequiredSize();
            DXMarshal.Write(ref buffer, (int)obj.bufferUsage);
            DXMarshal.Write(ref buffer, obj.bufferCount);
            DXMarshal.Write(ref buffer, obj.outputWindowHandle);
            DXMarshal.Write(ref buffer, obj.isWindowed);
            DXMarshal.Write(ref buffer, (int)obj.swapEffect);
            DXMarshal.Write(ref buffer, (int)obj.options);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiSwapChainDesc NativeReadFrom(nint buffer)
    {
        DxgiSwapChainDesc obj;
        obj.bufferDescription = DxgiModeDesc.NativeReadFrom(buffer);
        buffer += DxgiModeDesc.NativeRequiredSize();
        obj.sampleDescription = DxgiSampleDesc.NativeReadFrom(buffer);
        buffer += DxgiSampleDesc.NativeRequiredSize();
        obj.bufferUsage = (DxgiUsages)DXMarshal.ReadInt32(ref buffer);
        obj.bufferCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.outputWindowHandle = DXMarshal.ReadIntPtr(ref buffer);
        obj.isWindowed = DXMarshal.ReadBool(ref buffer);
        obj.swapEffect = (DxgiSwapEffect)DXMarshal.ReadInt32(ref buffer);
        obj.options = (DxgiSwapChainOptions)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiSwapChainDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A <see cref="DxgiModeDesc"/> structure that describes the back buffer display mode.
    /// </summary>
    private DxgiModeDesc bufferDescription;

    /// <summary>
    /// A <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters.
    /// </summary>
    private DxgiSampleDesc sampleDescription;

    /// <summary>
    /// A member of the <see cref="DxgiUsages"/> enumeration that describes the surface usage and CPU access options for the back buffer. The back buffer can be used for shader input or render-target output.
    /// </summary>
    private DxgiUsages bufferUsage;

    /// <summary>
    /// A value that describes the number of buffers in the swap chain.
    /// </summary>
    private uint bufferCount;

    /// <summary>
    /// An handle to the output window. This member must not be <value>Zero</value>.
    /// </summary>
    private nint outputWindowHandle;

    /// <summary>
    /// A value indicating whether the output is in windowed mode.
    /// </summary>
    private bool isWindowed;

    /// <summary>
    /// A member of the <see cref="DxgiSwapEffect"/> enumeration that describes options for handling the contents of the presentation buffer after presenting a surface.
    /// </summary>
    private DxgiSwapEffect swapEffect;

    /// <summary>
    /// A member of the <see cref="DxgiSwapChainOptions"/> enumeration that describes options for swap-chain behavior.
    /// </summary>
    private DxgiSwapChainOptions options;

    /// <summary>
    /// Gets or sets a <see cref="DxgiModeDesc"/> structure that describes the back buffer display mode.
    /// </summary>
    public DxgiModeDesc BufferDescription
    {
        get { return this.bufferDescription; }
        set { this.bufferDescription = value; }
    }

    /// <summary>
    /// Gets or sets a <see cref="DxgiSampleDesc"/> structure that describes multi-sampling parameters.
    /// </summary>
    public DxgiSampleDesc SampleDescription
    {
        get { return this.sampleDescription; }
        set { this.sampleDescription = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiUsages"/> enumeration that describes the surface usage and CPU access options for the back buffer. The back buffer can be used for shader input or render-target output.
    /// </summary>
    public DxgiUsages BufferUsage
    {
        get { return this.bufferUsage; }
        set { this.bufferUsage = value; }
    }

    /// <summary>
    /// Gets or sets a value that describes the number of buffers in the swap chain.
    /// </summary>
    public uint BufferCount
    {
        get { return this.bufferCount; }
        set { this.bufferCount = value; }
    }

    /// <summary>
    /// Gets or sets an handle to the output window. This member must not be <value>Zero</value>.
    /// </summary>
    public nint OutputWindowHandle
    {
        get { return this.outputWindowHandle; }
        set { this.outputWindowHandle = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the output is in windowed mode.
    /// </summary>
    public bool IsWindowed
    {
        get { return this.isWindowed; }
        set { this.isWindowed = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiSwapEffect"/> enumeration that describes options for handling the contents of the presentation buffer after presenting a surface.
    /// </summary>
    public DxgiSwapEffect SwapEffect
    {
        get { return this.swapEffect; }
        set { this.swapEffect = value; }
    }

    /// <summary>
    /// Gets or sets a member of the <see cref="DxgiSwapChainOptions"/> enumeration that describes options for swap-chain behavior.
    /// </summary>
    public DxgiSwapChainOptions Options
    {
        get { return this.options; }
        set { this.options = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiSwapChainDesc left, DxgiSwapChainDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiSwapChainDesc left, DxgiSwapChainDesc right)
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
        return obj is DxgiSwapChainDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiSwapChainDesc other)
    {
        return bufferDescription.Equals(other.bufferDescription) &&
               sampleDescription.Equals(other.sampleDescription) &&
               bufferUsage == other.bufferUsage &&
               bufferCount == other.bufferCount &&
               outputWindowHandle == other.outputWindowHandle &&
               isWindowed == other.isWindowed &&
               swapEffect == other.swapEffect &&
               options == other.options;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1712447912;
        hashCode = hashCode * -1521134295 + bufferDescription.GetHashCode();
        hashCode = hashCode * -1521134295 + sampleDescription.GetHashCode();
        hashCode = hashCode * -1521134295 + bufferUsage.GetHashCode();
        hashCode = hashCode * -1521134295 + bufferCount.GetHashCode();
        hashCode = hashCode * -1521134295 + outputWindowHandle.GetHashCode();
        hashCode = hashCode * -1521134295 + isWindowed.GetHashCode();
        hashCode = hashCode * -1521134295 + swapEffect.GetHashCode();
        hashCode = hashCode * -1521134295 + options.GetHashCode();
        return hashCode;
    }
}
