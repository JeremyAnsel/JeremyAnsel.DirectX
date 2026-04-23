// <copyright file="DWriteStrikethrough.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_STRIKETHROUGH structure contains information about the size and
/// placement of strikethroughs. All coordinates are in device independent
/// pixels (DIPs).
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteStrikethrough : IEquatable<DWriteStrikethrough>
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
        size += sizeof(float) * 3;
        size += sizeof(int) * 3; // enum
        size += sizeof(nint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteStrikethrough obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteStrikethrough>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteStrikethrough> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.thickness);
            DXMarshal.Write(ref buffer, obj.offset);
            DXMarshal.Write(ref buffer, (int)obj.readingDirection);
            DXMarshal.Write(ref buffer, (int)obj.flowDirection);
            DXMarshal.Write(ref buffer, (nint)obj.localeName);
            DXMarshal.Write(ref buffer, (int)obj.measuringMode);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteStrikethrough NativeReadFrom(nint buffer)
    {
        DWriteStrikethrough obj;
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.thickness = DXMarshal.ReadSingle(ref buffer);
        obj.offset = DXMarshal.ReadSingle(ref buffer);
        obj.readingDirection = (DWriteReadingDirection)DXMarshal.ReadInt32(ref buffer);
        obj.flowDirection = (DWriteFlowDirection)DXMarshal.ReadInt32(ref buffer);
        obj.localeName = (char*)DXMarshal.ReadIntPtr(ref buffer);
        obj.measuringMode = (DWriteMeasuringMode)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteStrikethrough> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Width of the strikethrough, measured parallel to the baseline.
    /// </summary>
    private float width;

    /// <summary>
    /// Thickness of the strikethrough, measured perpendicular to the
    /// baseline.
    /// </summary>
    private float thickness;

    /// <summary>
    /// Offset of the strikethrough from the baseline.
    /// A positive offset represents a position below the baseline and
    /// a negative offset is above.
    /// </summary>
    private float offset;

    /// <summary>
    /// Reading direction of the text associated with the strikethrough.  This
    /// value is used to interpret whether the width value runs horizontally 
    /// or vertically.
    /// </summary>
    private DWriteReadingDirection readingDirection;

    /// <summary>
    /// Flow direction of the text associated with the strikethrough.  This 
    /// value is used to interpret whether the thickness value advances top to
    /// bottom, left to right, or right to left.
    /// </summary>
    private DWriteFlowDirection flowDirection;

    /// <summary>
    /// Locale of the range. Can be pertinent where the locale affects the style.
    /// </summary>
    private char* localeName;

    /// <summary>
    /// The measuring mode can be useful to the renderer to determine how
    /// underlines are rendered, e.g. rounding the thickness to a whole pixel
    /// in GDI-compatible modes.
    /// </summary>
    private DWriteMeasuringMode measuringMode;

    /// <summary>
    /// Gets or sets the width of the strikethrough, measured parallel to the baseline.
    /// </summary>
    public float Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    /// <summary>
    /// Gets or sets the thickness of the strikethrough, measured perpendicular to the
    /// baseline.
    /// </summary>
    public float Thickness
    {
        get { return this.thickness; }
        set { this.thickness = value; }
    }

    /// <summary>
    /// Gets or sets the offset of the strikethrough from the baseline.
    /// A positive offset represents a position below the baseline and
    /// a negative offset is above.
    /// </summary>
    public float Offset
    {
        get { return this.offset; }
        set { this.offset = value; }
    }

    /// <summary>
    /// Gets or sets the reading direction of the text associated with the strikethrough.  This
    /// value is used to interpret whether the width value runs horizontally 
    /// or vertically.
    /// </summary>
    public DWriteReadingDirection ReadingDirection
    {
        get { return this.readingDirection; }
        set { this.readingDirection = value; }
    }

    /// <summary>
    /// Gets or sets the flow direction of the text associated with the strikethrough.  This 
    /// value is used to interpret whether the thickness value advances top to
    /// bottom, left to right, or right to left.
    /// </summary>
    public DWriteFlowDirection FlowDirection
    {
        get { return this.flowDirection; }
        set { this.flowDirection = value; }
    }

    /// <summary>
    /// Gets or sets the locale of the range. Can be pertinent where the locale affects the style.
    /// </summary>
    public char* LocaleName
    {
        get { return this.localeName; }
        set { this.localeName = value; }
    }

    /// <summary>
    /// Gets or sets the measuring mode can be useful to the renderer to determine how
    /// underlines are rendered, e.g. rounding the thickness to a whole pixel
    /// in GDI-compatible modes.
    /// </summary>
    public DWriteMeasuringMode MeasuringMode
    {
        get { return this.measuringMode; }
        set { this.measuringMode = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteStrikethrough left, DWriteStrikethrough right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteStrikethrough left, DWriteStrikethrough right)
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
        return obj is DWriteStrikethrough strikethrough && Equals(strikethrough);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteStrikethrough other)
    {
        return width == other.width &&
               thickness == other.thickness &&
               offset == other.offset &&
               readingDirection == other.readingDirection &&
               flowDirection == other.flowDirection &&
               localeName == other.localeName &&
               measuringMode == other.measuringMode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1682905197;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + thickness.GetHashCode();
        hashCode = hashCode * -1521134295 + offset.GetHashCode();
        hashCode = hashCode * -1521134295 + readingDirection.GetHashCode();
        hashCode = hashCode * -1521134295 + flowDirection.GetHashCode();
        hashCode = hashCode * -1521134295 + ((nint)localeName).GetHashCode();
        hashCode = hashCode * -1521134295 + measuringMode.GetHashCode();
        return hashCode;
    }
}
