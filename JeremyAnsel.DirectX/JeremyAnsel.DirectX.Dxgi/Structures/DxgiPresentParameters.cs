// <copyright file="DxgiPresentParameters.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes information about present that helps the operating system optimize presentation.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiPresentParameters : IEquatable<DxgiPresentParameters>
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
        size += sizeof(int);
        size += sizeof(nint) * 3;
        size += DXMarshal.PaddingSize();
        return size * count;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiPresentParameters obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiPresentParameters>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiPresentParameters> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.dirtyRectsCount);
            DXMarshal.WritePadding(ref buffer);
            DXMarshal.Write(ref buffer, obj.dirtyRects);
            DXMarshal.Write(ref buffer, obj.scrollRect);
            DXMarshal.Write(ref buffer, obj.scrollOffset);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiPresentParameters NativeReadFrom(nint buffer)
    {
        DxgiPresentParameters obj;
        obj.dirtyRectsCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        buffer += DXMarshal.PaddingSize();
        obj.dirtyRects = DXMarshal.ReadIntPtr(ref buffer);
        obj.scrollRect = DXMarshal.ReadIntPtr(ref buffer);
        obj.scrollOffset = DXMarshal.ReadIntPtr(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiPresentParameters> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of updated rectangles that you update in the back buffer for the presented frame. The operating system uses this information to optimize presentation. You can set this member to 0 to indicate that you update the whole frame.
    /// </summary>
    private uint dirtyRectsCount;

    /// <summary>
    /// A list of updated rectangles that you update in the back buffer for the presented frame. An application must update every single pixel in each rectangle that it reports to the runtime; the application cannot assume that the pixels are saved from the previous frame.
    /// </summary>
    private nint dirtyRects;

    /// <summary>
    /// A pointer to the scrolled rectangle. The scrolled rectangle is the rectangle of the previous frame from which the runtime bit-block transfers content. The runtime also uses the scrolled rectangle to optimize presentation in terminal server and indirect display scenarios.
    /// </summary>
    private nint scrollRect;

    /// <summary>
    /// A pointer to the offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).
    /// </summary>
    private nint scrollOffset;

    /// <summary>
    /// Gets or sets the number of updated rectangles that you update in the back buffer for the presented frame. The operating system uses this information to optimize presentation. You can set this member to 0 to indicate that you update the whole frame.
    /// </summary>
    public uint DirtyRectsCount
    {
        get { return this.dirtyRectsCount; }
        set { this.dirtyRectsCount = value; }
    }

    /// <summary>
    /// Gets or sets list of updated rectangles that you update in the back buffer for the presented frame. An application must update every single pixel in each rectangle that it reports to the runtime; the application cannot assume that the pixels are saved from the previous frame.
    /// </summary>
    public nint DirtyRects
    {
        get { return this.dirtyRects; }
        set { this.dirtyRects = value; }
    }

    /// <summary>
    /// Gets or sets the scrolled rectangle. The scrolled rectangle is the rectangle of the previous frame from which the runtime bit-block transfers content. The runtime also uses the scrolled rectangle to optimize presentation in terminal server and indirect display scenarios.
    /// </summary>
    public nint ScrollRect
    {
        get { return this.scrollRect; }
        set { this.scrollRect = value; }
    }

    /// <summary>
    /// Gets or sets the offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).
    /// </summary>
    public nint ScrollOffset
    {
        get { return this.scrollOffset; }
        set { this.scrollOffset = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiPresentParameters left, DxgiPresentParameters right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiPresentParameters left, DxgiPresentParameters right)
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
        return obj is DxgiPresentParameters parameters && Equals(parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiPresentParameters other)
    {
        return dirtyRectsCount == other.dirtyRectsCount &&
               dirtyRects == other.dirtyRects &&
               scrollRect == other.scrollRect &&
               scrollOffset == other.scrollOffset;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 617025092;
        hashCode = hashCode * -1521134295 + dirtyRectsCount.GetHashCode();
        hashCode = hashCode * -1521134295 + dirtyRects.GetHashCode();
        hashCode = hashCode * -1521134295 + scrollRect.GetHashCode();
        hashCode = hashCode * -1521134295 + scrollOffset.GetHashCode();
        return hashCode;
    }
}
