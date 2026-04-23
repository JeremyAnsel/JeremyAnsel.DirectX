// <copyright file="DWriteHitTestMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Geometry enclosing of text positions.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteHitTestMetrics : IEquatable<DWriteHitTestMetrics>
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
        size += sizeof(float) * 4;
        size += sizeof(int) * 2; // bool
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteHitTestMetrics obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteHitTestMetrics>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteHitTestMetrics> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.textPosition);
            DXMarshal.Write(ref buffer, obj.length);
            DXMarshal.Write(ref buffer, obj.left);
            DXMarshal.Write(ref buffer, obj.top);
            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
            DXMarshal.Write(ref buffer, obj.bidiLevel);
            DXMarshal.Write(ref buffer, obj.isText);
            DXMarshal.Write(ref buffer, obj.isTrimmed);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteHitTestMetrics NativeReadFrom(nint buffer)
    {
        DWriteHitTestMetrics obj;
        obj.textPosition = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.length = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.left = DXMarshal.ReadSingle(ref buffer);
        obj.top = DXMarshal.ReadSingle(ref buffer);
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.height = DXMarshal.ReadSingle(ref buffer);
        obj.bidiLevel = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.isText = DXMarshal.ReadBool(ref buffer);
        obj.isTrimmed = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteHitTestMetrics> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// First text position within the geometry.
    /// </summary>
    private uint textPosition;

    /// <summary>
    /// Number of text positions within the geometry.
    /// </summary>
    private uint length;

    /// <summary>
    /// Left position of the top-left coordinate of the geometry.
    /// </summary>
    private float left;

    /// <summary>
    /// Top position of the top-left coordinate of the geometry.
    /// </summary>
    private float top;

    /// <summary>
    /// Geometry's width.
    /// </summary>
    private float width;

    /// <summary>
    /// Geometry's height.
    /// </summary>
    private float height;

    /// <summary>
    /// Bidi level of text positions enclosed within the geometry.
    /// </summary>
    private uint bidiLevel;

    /// <summary>
    /// Geometry encloses text?
    /// </summary>
    private bool isText;

    /// <summary>
    /// Range is trimmed.
    /// </summary>
    private bool isTrimmed;

    /// <summary>
    /// Gets the first text position within the geometry.
    /// </summary>
    public uint TextPosition
    {
        get { return this.textPosition; }
    }

    /// <summary>
    /// Gets the number of text positions within the geometry.
    /// </summary>
    public uint Length
    {
        get { return this.length; }
    }

    /// <summary>
    /// Gets the left position of the top-left coordinate of the geometry.
    /// </summary>
    public float Left
    {
        get { return this.left; }
    }

    /// <summary>
    /// Gets the top position of the top-left coordinate of the geometry.
    /// </summary>
    public float Top
    {
        get { return this.top; }
    }

    /// <summary>
    /// Gets the geometry's width.
    /// </summary>
    public float Width
    {
        get { return this.width; }
    }

    /// <summary>
    /// Gets the geometry's height.
    /// </summary>
    public float Height
    {
        get { return this.height; }
    }

    /// <summary>
    /// Gets the bidi level of text positions enclosed within the geometry.
    /// </summary>
    public uint BidiLevel
    {
        get { return this.bidiLevel; }
    }

    /// <summary>
    /// Gets a value indicating whether the geometry encloses text.
    /// </summary>
    public bool IsText
    {
        get { return this.isText; }
    }

    /// <summary>
    /// Gets a value indicating whether the range is trimmed.
    /// </summary>
    public bool IsTrimmed
    {
        get { return this.isTrimmed; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteHitTestMetrics left, DWriteHitTestMetrics right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteHitTestMetrics left, DWriteHitTestMetrics right)
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
        return obj is DWriteHitTestMetrics metrics && Equals(metrics);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteHitTestMetrics other)
    {
        return textPosition == other.textPosition &&
               length == other.length &&
               left == other.left &&
               top == other.top &&
               width == other.width &&
               height == other.height &&
               bidiLevel == other.bidiLevel &&
               isText == other.isText &&
               isTrimmed == other.isTrimmed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 346931753;
        hashCode = hashCode * -1521134295 + textPosition.GetHashCode();
        hashCode = hashCode * -1521134295 + length.GetHashCode();
        hashCode = hashCode * -1521134295 + left.GetHashCode();
        hashCode = hashCode * -1521134295 + top.GetHashCode();
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        hashCode = hashCode * -1521134295 + bidiLevel.GetHashCode();
        hashCode = hashCode * -1521134295 + isText.GetHashCode();
        hashCode = hashCode * -1521134295 + isTrimmed.GetHashCode();
        return hashCode;
    }
}
