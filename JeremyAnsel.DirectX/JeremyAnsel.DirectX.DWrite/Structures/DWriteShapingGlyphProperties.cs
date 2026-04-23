// <copyright file="DWriteShapingGlyphProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Shaping output properties per output glyph.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteShapingGlyphProperties : IEquatable<DWriteShapingGlyphProperties>
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
        size += sizeof(ushort);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteShapingGlyphProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteShapingGlyphProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteShapingGlyphProperties> objects)
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
    public static DWriteShapingGlyphProperties NativeReadFrom(nint buffer)
    {
        DWriteShapingGlyphProperties obj;
        obj.data = DXMarshal.ReadUnsignedInt16(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteShapingGlyphProperties> objects)
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
    private ushort data;

    /// <summary>
    /// Gets or sets the justification class, whether to use spacing, kashidas, or
    /// another method. This exists for backwards compatibility
    /// with <c>Uniscribe's SCRIPT_JUSTIFY</c> enumeration.
    /// </summary>
    public ushort Justification
    {
        get { return (ushort)(this.data & 0xFU); }
        set { this.data ^= (ushort)((this.data ^ value) & 0xFU); }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the glyph is the first of a cluster.
    /// </summary>
    public bool IsClusterStart
    {
        get
        {
            return (this.data & (1U << 4)) != 0;
        }

        set
        {
            if (value)
            {
                this.data |= (ushort)(1U << 4);
            }
            else
            {
                this.data &= unchecked((ushort)~(1U << 4));
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether  the glyph is a diacritic.
    /// </summary>
    public bool IsDiacritic
    {
        get
        {
            return (this.data & (1U << 5)) != 0;
        }

        set
        {
            if (value)
            {
                this.data |= (ushort)(1U << 5);
            }
            else
            {
                this.data &= unchecked((ushort)~(1U << 5));
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the glyph has no width, blank, ZWJ, ZWNJ etc.
    /// </summary>
    public bool IsZeroWidthSpace
    {
        get
        {
            return (this.data & (1U << 6)) != 0;
        }

        set
        {
            if (value)
            {
                this.data |= (ushort)(1U << 6);
            }
            else
            {
                this.data &= unchecked((ushort)~(1U << 6));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteShapingGlyphProperties left, DWriteShapingGlyphProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteShapingGlyphProperties left, DWriteShapingGlyphProperties right)
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
        return obj is DWriteShapingGlyphProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteShapingGlyphProperties other)
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
