// <copyright file="D3D11BufferRtv.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Specifies the elements in a buffer resource to use in a render-target view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11BufferRtv : IEquatable<D3D11BufferRtv>
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
    public static void NativeWriteTo(nint buffer, in D3D11BufferRtv obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11BufferRtv>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11BufferRtv> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.firstElement);
            DXMarshal.Write(ref buffer, obj.numElements);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11BufferRtv NativeReadFrom(nint buffer)
    {
        D3D11BufferRtv obj;
        obj.firstElement = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.numElements = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11BufferRtv> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The number of bytes between the beginning of the buffer and the first element to access.
    /// </summary>
    private uint firstElement;

    /// <summary>
    /// The total number of elements in the view.
    /// </summary>
    private uint numElements;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstElement"></param>
    /// <param name="numElements"></param>
    public D3D11BufferRtv(uint firstElement, uint numElements)
    {
        this.firstElement = firstElement;
        this.numElements = numElements;
    }

    /// <summary>
    /// Gets or sets the number of bytes between the beginning of the buffer and the first element to access.
    /// </summary>
    public uint FirstElement
    {
        get { return this.firstElement; }
        set { this.firstElement = value; }
    }

    /// <summary>
    /// Gets or sets the offset of the first element in the view to access, relative to element 0.
    /// </summary>
    public uint ElementOffset
    {
        get { return this.firstElement; }
        set { this.firstElement = value; }
    }

    /// <summary>
    /// Gets or sets the total number of elements in the view.
    /// </summary>
    public uint NumElements
    {
        get { return this.numElements; }
        set { this.numElements = value; }
    }

    /// <summary>
    /// Gets or sets the width of each element (in bytes). This can be determined from the format stored in the render-target-view description.
    /// </summary>
    public uint ElementWidth
    {
        get { return this.numElements; }
        set { this.numElements = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11BufferRtv left, D3D11BufferRtv right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11BufferRtv left, D3D11BufferRtv right)
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
        return obj is D3D11BufferRtv rtv && Equals(rtv);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11BufferRtv other)
    {
        return firstElement == other.firstElement &&
               numElements == other.numElements;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 183976445;
        hashCode = hashCode * -1521134295 + firstElement.GetHashCode();
        hashCode = hashCode * -1521134295 + numElements.GetHashCode();
        return hashCode;
    }
}
