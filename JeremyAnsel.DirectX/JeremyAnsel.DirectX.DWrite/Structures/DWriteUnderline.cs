// <copyright file="DWriteUnderline.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_UNDERLINE structure contains information about the size and
/// placement of underlines. All coordinates are in device independent
/// pixels (DIPs).
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteUnderline : IEquatable<DWriteUnderline>
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
        size += sizeof(float) * 4;
        size += sizeof(int) * 3; // enum
        size += sizeof(nint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteUnderline obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteUnderline>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteUnderline> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.thickness);
            DXMarshal.Write(ref buffer, obj.offset);
            DXMarshal.Write(ref buffer, obj.runHeight);
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
    public static DWriteUnderline NativeReadFrom(nint buffer)
    {
        DWriteUnderline obj;
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.thickness = DXMarshal.ReadSingle(ref buffer);
        obj.offset = DXMarshal.ReadSingle(ref buffer);
        obj.runHeight = DXMarshal.ReadSingle(ref buffer);
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
    public static void NativeReadFrom(nint buffer, Span<DWriteUnderline> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Width of the underline, measured parallel to the baseline.
    /// </summary>
    private float width;

    /// <summary>
    /// Thickness of the underline, measured perpendicular to the
    /// baseline.
    /// </summary>
    private float thickness;

    /// <summary>
    /// Offset of the underline from the baseline.
    /// A positive offset represents a position below the baseline and
    /// a negative offset is above.
    /// </summary>
    private float offset;

    /// <summary>
    /// Height of the tallest run where the underline applies.
    /// </summary>
    private float runHeight;

    /// <summary>
    /// Reading direction of the text associated with the underline.  This 
    /// value is used to interpret whether the width value runs horizontally 
    /// or vertically.
    /// </summary>
    private DWriteReadingDirection readingDirection;

    /// <summary>
    /// Flow direction of the text associated with the underline.  This value
    /// is used to interpret whether the thickness value advances top to 
    /// bottom, left to right, or right to left.
    /// </summary>
    private DWriteFlowDirection flowDirection;

    /// <summary>
    /// Locale of the text the underline is being drawn under. Can be
    /// pertinent where the locale affects how the underline is drawn.
    /// For example, in vertical text, the underline belongs on the
    /// left for Chinese but on the right for Japanese.
    /// This choice is completely left up to higher levels.
    /// </summary>
    private char* localeName;

    /// <summary>
    /// The measuring mode can be useful to the renderer to determine how
    /// underlines are rendered, e.g. rounding the thickness to a whole pixel
    /// in GDI-compatible modes.
    /// </summary>
    private DWriteMeasuringMode measuringMode;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteUnderline"/> struct.
    /// </summary>
    /// <param name="width">Width of the underline, measured parallel to the baseline.</param>
    /// <param name="thickness">Thickness of the underline, measured perpendicular to the baseline.</param>
    /// <param name="offset">Offset of the underline from the baseline.</param>
    /// <param name="runHeight">Height of the tallest run where the underline applies.</param>
    /// <param name="readingDirection">Reading direction of the text associated with the underline.</param>
    /// <param name="flowDirection">Flow direction of the text associated with the underline.</param>
    /// <param name="localeName">Locale of the text the underline is being drawn under.</param>
    /// <param name="measuringMode">The measuring mode.</param>
    public DWriteUnderline(
        float width,
        float thickness,
        float offset,
        float runHeight,
        DWriteReadingDirection readingDirection,
        DWriteFlowDirection flowDirection,
        char* localeName,
        DWriteMeasuringMode measuringMode)
    {
        this.width = width;
        this.thickness = thickness;
        this.offset = offset;
        this.runHeight = runHeight;
        this.readingDirection = readingDirection;
        this.flowDirection = flowDirection;
        this.localeName = localeName;
        this.measuringMode = measuringMode;
    }

    /// <summary>
    /// Gets or sets the width of the underline, measured parallel to the baseline.
    /// </summary>
    public float Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    /// <summary>
    /// Gets or sets the thickness of the underline, measured perpendicular to the
    /// baseline.
    /// </summary>
    public float Thickness
    {
        get { return this.thickness; }
        set { this.thickness = value; }
    }

    /// <summary>
    /// Gets or sets the offset of the underline from the baseline.
    /// A positive offset represents a position below the baseline and
    /// a negative offset is above.
    /// </summary>
    public float Offset
    {
        get { return this.offset; }
        set { this.offset = value; }
    }

    /// <summary>
    /// Gets or sets the height of the tallest run where the underline applies.
    /// </summary>
    public float RunHeight
    {
        get { return this.runHeight; }
        set { this.runHeight = value; }
    }

    /// <summary>
    /// Gets or sets the reading direction of the text associated with the underline.  This 
    /// value is used to interpret whether the width value runs horizontally 
    /// or vertically.
    /// </summary>
    public DWriteReadingDirection ReadingDirection
    {
        get { return this.readingDirection; }
        set { this.readingDirection = value; }
    }

    /// <summary>
    /// Gets or sets the flow direction of the text associated with the underline.  This value
    /// is used to interpret whether the thickness value advances top to 
    /// bottom, left to right, or right to left.
    /// </summary>
    public DWriteFlowDirection FlowDirection
    {
        get { return this.flowDirection; }
        set { this.flowDirection = value; }
    }

    /// <summary>
    /// Gets or sets the locale of the text the underline is being drawn under. Can be
    /// pertinent where the locale affects how the underline is drawn.
    /// For example, in vertical text, the underline belongs on the
    /// left for Chinese but on the right for Japanese.
    /// This choice is completely left up to higher levels.
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
    public static bool operator ==(DWriteUnderline left, DWriteUnderline right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteUnderline left, DWriteUnderline right)
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
        return obj is DWriteUnderline underline && Equals(underline);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteUnderline other)
    {
        return width == other.width &&
               thickness == other.thickness &&
               offset == other.offset &&
               runHeight == other.runHeight &&
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
        int hashCode = -447998388;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + thickness.GetHashCode();
        hashCode = hashCode * -1521134295 + offset.GetHashCode();
        hashCode = hashCode * -1521134295 + runHeight.GetHashCode();
        hashCode = hashCode * -1521134295 + readingDirection.GetHashCode();
        hashCode = hashCode * -1521134295 + flowDirection.GetHashCode();
        hashCode = hashCode * -1521134295 + ((nint)localeName).GetHashCode();
        hashCode = hashCode * -1521134295 + measuringMode.GetHashCode();
        return hashCode;
    }
}
