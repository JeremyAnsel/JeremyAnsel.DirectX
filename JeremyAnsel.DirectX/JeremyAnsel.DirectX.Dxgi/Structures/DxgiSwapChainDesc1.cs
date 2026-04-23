// <copyright file="DxgiSwapChainDesc1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes a swap chain.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiSwapChainDesc1 : IEquatable<DxgiSwapChainDesc1>
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
        size += sizeof(uint) * 3;
        size += sizeof(int) * 6; // enum
        size += sizeof(int); // bool
        size += DxgiSampleDesc.NativeRequiredSize();
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiSwapChainDesc1 obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiSwapChainDesc1>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiSwapChainDesc1> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, obj.stereo);
            DxgiSampleDesc.NativeWriteTo(buffer, obj.sampleDescription);
            buffer += DxgiSampleDesc.NativeRequiredSize();
            DXMarshal.Write(ref buffer, (int)obj.bufferUsage);
            DXMarshal.Write(ref buffer, obj.bufferCount);
            DXMarshal.Write(ref buffer, (int)obj.scaling);
            DXMarshal.Write(ref buffer, (int)obj.swapEffect);
            DXMarshal.Write(ref buffer, (int)obj.alphaMode);
            DXMarshal.Write(ref buffer, (int)obj.options);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiSwapChainDesc1 NativeReadFrom(nint buffer)
    {
        DxgiSwapChainDesc1 obj;
        obj.width = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.height = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.stereo = DXMarshal.ReadBool(ref buffer);
        obj.sampleDescription = DxgiSampleDesc.NativeReadFrom(buffer);
        buffer += DxgiSampleDesc.NativeRequiredSize();
        obj.bufferUsage = (DxgiUsages)DXMarshal.ReadInt32(ref buffer);
        obj.bufferCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.scaling = (DxgiScaling)DXMarshal.ReadInt32(ref buffer);
        obj.swapEffect = (DxgiSwapEffect)DXMarshal.ReadInt32(ref buffer);
        obj.alphaMode = (DxgiAlphaMode)DXMarshal.ReadInt32(ref buffer);
        obj.options = (DxgiSwapChainOptions)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiSwapChainDesc1> objects)
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
    /// A member of the <see cref="DxgiFormat"/> enumeration describing the display format.
    /// </summary>
    private DxgiFormat format;

    /// <summary>
    /// Specifies whether the full-screen display mode is stereo. TRUE if stereo; otherwise, FALSE.
    /// </summary>
    private bool stereo;

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
    /// A member of the <see cref="DxgiScaling"/> enumeration describing the scaling mode.
    /// </summary>
    private DxgiScaling scaling;

    /// <summary>
    /// A member of the <see cref="DxgiSwapEffect"/> enumeration that describes options for handling the contents of the presentation buffer after presenting a surface.
    /// </summary>
    private DxgiSwapEffect swapEffect;

    /// <summary>
    /// A member of the <see cref="DxgiAlphaMode"/> enumeration that identifies the transparency behavior of the swap-chain back buffer.
    /// </summary>
    private DxgiAlphaMode alphaMode;

    /// <summary>
    /// A member of the <see cref="DxgiSwapChainOptions"/> enumeration that describes options for swap-chain behavior.
    /// </summary>
    private DxgiSwapChainOptions options;

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
    /// Gets or sets a member of the <see cref="DxgiFormat"/> enumeration describing the display format.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the full-screen display mode is stereo.
    /// </summary>
    public bool Stereo
    {
        get { return this.stereo; }
        set { this.stereo = value; }
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
    /// Gets or sets a member of the <see cref="DxgiScaling"/> enumeration describing the scaling mode.
    /// </summary>
    public DxgiScaling Scaling
    {
        get { return this.scaling; }
        set { this.scaling = value; }
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
    /// Gets or sets a member of the <see cref="DxgiAlphaMode"/> enumeration that identifies the transparency behavior of the swap-chain back buffer.
    /// </summary>
    public DxgiAlphaMode AlphaMode
    {
        get { return this.alphaMode; }
        set { this.alphaMode = value; }
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
    public static bool operator ==(DxgiSwapChainDesc1 left, DxgiSwapChainDesc1 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiSwapChainDesc1 left, DxgiSwapChainDesc1 right)
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
        return obj is DxgiSwapChainDesc1 desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiSwapChainDesc1 other)
    {
        return width == other.width &&
               height == other.height &&
               format == other.format &&
               stereo == other.stereo &&
               sampleDescription.Equals(other.sampleDescription) &&
               bufferUsage == other.bufferUsage &&
               bufferCount == other.bufferCount &&
               scaling == other.scaling &&
               swapEffect == other.swapEffect &&
               alphaMode == other.alphaMode &&
               options == other.options;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1864558923;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + stereo.GetHashCode();
        hashCode = hashCode * -1521134295 + sampleDescription.GetHashCode();
        hashCode = hashCode * -1521134295 + bufferUsage.GetHashCode();
        hashCode = hashCode * -1521134295 + bufferCount.GetHashCode();
        hashCode = hashCode * -1521134295 + scaling.GetHashCode();
        hashCode = hashCode * -1521134295 + swapEffect.GetHashCode();
        hashCode = hashCode * -1521134295 + alphaMode.GetHashCode();
        hashCode = hashCode * -1521134295 + options.GetHashCode();
        return hashCode;
    }
}
