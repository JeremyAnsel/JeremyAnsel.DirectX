// <copyright file="D3D11BufferUav.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes the elements in a buffer to use in a unordered-access view.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11BufferUav : IEquatable<D3D11BufferUav>
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
        size += sizeof(int);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11BufferUav obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11BufferUav>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11BufferUav> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.firstElement);
            DXMarshal.Write(ref buffer, obj.numElements);
            DXMarshal.Write(ref buffer, (int)obj.options);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11BufferUav NativeReadFrom(nint buffer)
    {
        D3D11BufferUav obj;
        obj.firstElement = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.numElements = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.options = (D3D11BufferUavOptions)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11BufferUav> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The zero-based index of the first element to be accessed.
    /// </summary>
    private uint firstElement;

    /// <summary>
    /// The number of elements in the resource. For structured buffers, this is the number of structures in the buffer.
    /// </summary>
    private uint numElements;

    /// <summary>
    /// The view options for the resource.
    /// </summary>
    private D3D11BufferUavOptions options;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstElement"></param>
    /// <param name="numElements"></param>
    public D3D11BufferUav(uint firstElement, uint numElements)
    {
        this.firstElement = firstElement;
        this.numElements = numElements;
        this.options = D3D11BufferUavOptions.None;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstElement"></param>
    /// <param name="numElements"></param>
    /// <param name="options"></param>
    public D3D11BufferUav(uint firstElement, uint numElements, D3D11BufferUavOptions options)
    {
        this.firstElement = firstElement;
        this.numElements = numElements;
        this.options = options;
    }

    /// <summary>
    /// Gets or sets the zero-based index of the first element to be accessed.
    /// </summary>
    public uint FirstElement
    {
        get { return this.firstElement; }
        set { this.firstElement = value; }
    }

    /// <summary>
    /// Gets or sets the number of elements in the resource. For structured buffers, this is the number of structures in the buffer.
    /// </summary>
    public uint NumElements
    {
        get { return this.numElements; }
        set { this.numElements = value; }
    }

    /// <summary>
    /// Gets or sets the view options for the resource.
    /// </summary>
    public D3D11BufferUavOptions Options
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
    public static bool operator ==(D3D11BufferUav left, D3D11BufferUav right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11BufferUav left, D3D11BufferUav right)
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
        return obj is D3D11BufferUav uav && Equals(uav);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11BufferUav other)
    {
        return firstElement == other.firstElement &&
               numElements == other.numElements &&
               options == other.options;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1012138198;
        hashCode = hashCode * -1521134295 + firstElement.GetHashCode();
        hashCode = hashCode * -1521134295 + numElements.GetHashCode();
        hashCode = hashCode * -1521134295 + options.GetHashCode();
        return hashCode;
    }
}
