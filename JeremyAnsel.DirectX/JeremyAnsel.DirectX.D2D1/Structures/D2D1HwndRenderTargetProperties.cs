// <copyright file="D2D1HwndRenderTargetProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the HWND, pixel size, and presentation options for an <see cref="D2D1HwndRenderTarget"/>.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1HwndRenderTargetProperties : IEquatable<D2D1HwndRenderTargetProperties>
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
        size += sizeof(nint);
        size += D2D1SizeU.NativeRequiredSize();
        size += sizeof(int); // enum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1HwndRenderTargetProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1HwndRenderTargetProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1HwndRenderTargetProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.hwnd);
            D2D1SizeU.NativeWriteTo(buffer, obj.pixelSize);
            buffer += D2D1SizeU.NativeRequiredSize();
            DXMarshal.Write(ref buffer, (int)obj.presentOptions);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1HwndRenderTargetProperties NativeReadFrom(nint buffer)
    {
        D2D1HwndRenderTargetProperties obj;
        obj.hwnd = DXMarshal.ReadIntPtr(ref buffer);
        obj.pixelSize = D2D1SizeU.NativeReadFrom(buffer);
        buffer += D2D1SizeU.NativeRequiredSize();
        obj.presentOptions = (D2D1PresentOptions)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1HwndRenderTargetProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The HWND to which the render target issues the output from its drawing commands.
    /// </summary>
    private nint hwnd;

    /// <summary>
    /// The size of the render target, in pixels.
    /// </summary>
    private D2D1SizeU pixelSize;

    /// <summary>
    /// A value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the device to refresh before presenting.
    /// </summary>
    private D2D1PresentOptions presentOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1HwndRenderTargetProperties"/> struct.
    /// </summary>
    /// <param name="hwnd">The HWND to which the render target issues the output from its drawing commands.</param>
    public D2D1HwndRenderTargetProperties(nint hwnd)
    {
        this.hwnd = hwnd;
        this.pixelSize = new D2D1SizeU(0U, 0U);
        this.presentOptions = D2D1PresentOptions.None;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1HwndRenderTargetProperties"/> struct.
    /// </summary>
    /// <param name="hwnd">The HWND to which the render target issues the output from its drawing commands.</param>
    /// <param name="pixelSize">The size of the render target, in pixels.</param>
    /// <param name="presentOptions">A value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the device to refresh before presenting.</param>
    public D2D1HwndRenderTargetProperties(IntPtr hwnd, D2D1SizeU pixelSize, D2D1PresentOptions presentOptions)
    {
        this.hwnd = hwnd;
        this.pixelSize = pixelSize;
        this.presentOptions = presentOptions;
    }

    /// <summary>
    /// Gets or sets the HWND to which the render target issues the output from its drawing commands.
    /// </summary>
    public nint Hwnd
    {
        get { return this.hwnd; }
        set { this.hwnd = value; }
    }

    /// <summary>
    /// Gets or sets the size of the render target, in pixels.
    /// </summary>
    public D2D1SizeU PixelSize
    {
        get { return this.pixelSize; }
        set { this.pixelSize = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the device to refresh before presenting.
    /// </summary>
    public D2D1PresentOptions PresentOptions
    {
        get { return this.presentOptions; }
        set { this.presentOptions = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1HwndRenderTargetProperties left, D2D1HwndRenderTargetProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1HwndRenderTargetProperties left, D2D1HwndRenderTargetProperties right)
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
        return obj is D2D1HwndRenderTargetProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1HwndRenderTargetProperties other)
    {
        return EqualityComparer<nint>.Default.Equals(hwnd, other.hwnd) &&
               pixelSize.Equals(other.pixelSize) &&
               presentOptions == other.presentOptions;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -368520166;
        hashCode = hashCode * -1521134295 + hwnd.GetHashCode();
        hashCode = hashCode * -1521134295 + pixelSize.GetHashCode();
        hashCode = hashCode * -1521134295 + presentOptions.GetHashCode();
        return hashCode;
    }
}
