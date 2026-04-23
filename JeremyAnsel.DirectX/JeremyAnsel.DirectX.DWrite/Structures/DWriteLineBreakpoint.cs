// <copyright file="DWriteLineBreakpoint.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Line breakpoint characteristics of a character.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteLineBreakpoint : IEquatable<DWriteLineBreakpoint>
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
        size += sizeof(byte);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteLineBreakpoint obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteLineBreakpoint>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteLineBreakpoint> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.data);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteLineBreakpoint NativeReadFrom(nint buffer)
    {
        DWriteLineBreakpoint obj;
        obj.data = DXMarshal.ReadByte(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteLineBreakpoint> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Packed data.
    /// </summary>
    private byte data;

    /// <summary>
    /// Gets or sets the breaking condition before the character.
    /// </summary>
    public DWriteBreakCondition BreakConditionBefore
    {
        get { return (DWriteBreakCondition)(this.data & 0x3U); }
        set { this.data ^= (byte)((this.data ^ (byte)value) & 0x3U); }
    }

    /// <summary>
    /// Gets or sets the breaking condition after the character.
    /// </summary>
    public DWriteBreakCondition BreakConditionAfter
    {
        get { return (DWriteBreakCondition)((this.data >> 2) & 0x3U); }
        set { this.data ^= (byte)((this.data ^ ((byte)value << 2)) & (0x3U << 2)); }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the character is some form of whitespace, which may be meaningful
    /// for justification.
    /// </summary>
    public bool IsWhitespace
    {
        get
        {
            return (this.data & (1U << 4)) != 0;
        }

        set
        {
            if (value)
            {
                this.data |= (byte)(1U << 4);
            }
            else
            {
                this.data &= unchecked((byte)~(1U << 4));
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether  the character is a soft hyphen, often used to indicate hyphenation
    /// points inside words.
    /// </summary>
    public bool IsSoftHyphen
    {
        get
        {
            return (this.data & (1U << 5)) != 0;
        }

        set
        {
            if (value)
            {
                this.data |= (byte)(1U << 5);
            }
            else
            {
                this.data &= unchecked((byte)~(1U << 5));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteLineBreakpoint left, DWriteLineBreakpoint right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteLineBreakpoint left, DWriteLineBreakpoint right)
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
        return obj is DWriteLineBreakpoint breakpoint && Equals(breakpoint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteLineBreakpoint other)
    {
        return data == other.data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 1768953197 + data.GetHashCode();
    }
}
