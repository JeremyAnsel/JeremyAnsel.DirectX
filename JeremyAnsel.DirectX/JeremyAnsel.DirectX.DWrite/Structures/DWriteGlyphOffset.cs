// <copyright file="DWriteGlyphOffset.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Optional adjustment to a glyph's position. A glyph offset changes the position of a glyph without affecting
/// the pen position. Offsets are in logical, pre-transform units.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteGlyphOffset : IEquatable<DWriteGlyphOffset>
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
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteGlyphOffset obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteGlyphOffset>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteGlyphOffset> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.advanceOffset);
            DXMarshal.Write(ref buffer, obj.ascenderOffset);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteGlyphOffset NativeReadFrom(nint buffer)
    {
        DWriteGlyphOffset obj;
        obj.advanceOffset = DXMarshal.ReadSingle(ref buffer);
        obj.ascenderOffset = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteGlyphOffset> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Offset in the advance direction of the run. A positive advance offset moves the glyph to the right
    /// (in pre-transform coordinates) if the run is left-to-right or to the left if the run is right-to-left.
    /// </summary>
    private float advanceOffset;

    /// <summary>
    /// Offset in the ascent direction, i.e., the direction ascenders point. A positive ascender offset moves
    /// the glyph up (in pre-transform coordinates).
    /// </summary>
    private float ascenderOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteGlyphOffset"/> struct.
    /// </summary>
    /// <param name="advanceOffset">Offset in the advance direction of the run.</param>
    /// <param name="ascenderOffset">Offset in the ascent direction, i.e., the direction ascenders point.</param>
    public DWriteGlyphOffset(float advanceOffset, float ascenderOffset)
    {
        this.advanceOffset = advanceOffset;
        this.ascenderOffset = ascenderOffset;
    }

    /// <summary>
    /// Gets or sets the offset in the advance direction of the run. A positive advance offset moves the glyph to the right
    /// (in pre-transform coordinates) if the run is left-to-right or to the left if the run is right-to-left.
    /// </summary>
    public float AdvanceOffset
    {
        get { return this.advanceOffset; }
        set { this.advanceOffset = value; }
    }

    /// <summary>
    /// Gets or sets the offset in the ascent direction, i.e., the direction ascenders point. A positive ascender offset moves
    /// the glyph up (in pre-transform coordinates).
    /// </summary>
    public float AscenderOffset
    {
        get { return this.ascenderOffset; }
        set { this.ascenderOffset = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteGlyphOffset left, DWriteGlyphOffset right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteGlyphOffset left, DWriteGlyphOffset right)
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
        return obj is DWriteGlyphOffset offset && Equals(offset);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteGlyphOffset other)
    {
        return advanceOffset == other.advanceOffset &&
               ascenderOffset == other.ascenderOffset;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1363993241;
        hashCode = hashCode * -1521134295 + advanceOffset.GetHashCode();
        hashCode = hashCode * -1521134295 + ascenderOffset.GetHashCode();
        return hashCode;
    }
}
