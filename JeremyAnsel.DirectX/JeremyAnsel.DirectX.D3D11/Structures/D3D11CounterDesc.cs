// <copyright file="D3D11CounterDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a counter.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11CounterDesc : IEquatable<D3D11CounterDesc>
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
        size += sizeof(uint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11CounterDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11CounterDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11CounterDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.counter);
            DXMarshal.Write(ref buffer, obj.miscOptions);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11CounterDesc NativeReadFrom(nint buffer)
    {
        D3D11CounterDesc obj;
        obj.counter = (D3D11CounterType)DXMarshal.ReadInt32(ref buffer);
        obj.miscOptions = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11CounterDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The type of the counter.
    /// </summary>
    private D3D11CounterType counter;

    /// <summary>
    /// Reserved value.
    /// </summary>
    private uint miscOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11CounterDesc"/> struct.
    /// </summary>
    /// <param name="counter">The type of the counter.</param>
    public D3D11CounterDesc(D3D11CounterType counter)
    {
        this.counter = counter;
        this.miscOptions = 0;
    }

    /// <summary>
    /// Gets or sets the type of the counter.
    /// </summary>
    public D3D11CounterType Counter
    {
        get { return this.counter; }
        set { this.counter = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11CounterDesc left, D3D11CounterDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11CounterDesc left, D3D11CounterDesc right)
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
        return obj is D3D11CounterDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11CounterDesc other)
    {
        return counter == other.counter &&
               miscOptions == other.miscOptions;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1214632308;
        hashCode = hashCode * -1521134295 + counter.GetHashCode();
        hashCode = hashCode * -1521134295 + miscOptions.GetHashCode();
        return hashCode;
    }
}
