// <copyright file="DxgiMappedRect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes a mapped rectangle that is used to access a surface.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiMappedRect : IEquatable<DxgiMappedRect>
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
        size += sizeof(nint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiMappedRect obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiMappedRect>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiMappedRect> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.pitch);
            DXMarshal.Write(ref buffer, obj.bitsPointer);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiMappedRect NativeReadFrom(nint buffer)
    {
        DxgiMappedRect obj;
        obj.pitch = DXMarshal.ReadInt32(ref buffer);
        obj.bitsPointer = DXMarshal.ReadIntPtr(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiMappedRect> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that describes the width, in bytes, of the surface.
    /// </summary>
    private int pitch;

    /// <summary>
    /// A pointer to the image buffer of the surface.
    /// </summary>
    private nint bitsPointer;

    /// <summary>
    /// Gets a value that describes the width, in bytes, of the surface.
    /// </summary>
    public readonly int Pitch
    {
        get { return this.pitch; }
    }

    /// <summary>
    /// Gets a pointer to the image buffer of the surface.
    /// </summary>
    public readonly nint BitsPointer
    {
        get { return this.bitsPointer; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiMappedRect left, DxgiMappedRect right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiMappedRect left, DxgiMappedRect right)
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
        return obj is DxgiMappedRect rect && Equals(rect);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiMappedRect other)
    {
        return pitch == other.pitch &&
               bitsPointer == other.bitsPointer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 469234111;
        hashCode = hashCode * -1521134295 + pitch.GetHashCode();
        hashCode = hashCode * -1521134295 + bitsPointer.GetHashCode();
        return hashCode;
    }
}
