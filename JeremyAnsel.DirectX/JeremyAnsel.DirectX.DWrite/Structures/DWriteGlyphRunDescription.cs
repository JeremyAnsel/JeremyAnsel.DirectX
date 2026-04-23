// <copyright file="DWriteGlyphRunDescription.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_GLYPH_RUN_DESCRIPTION structure contains additional properties
/// related to those in DWRITE_GLYPH_RUN.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteGlyphRunDescription : IEquatable<DWriteGlyphRunDescription>
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
        size += sizeof(nint) * 3;
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteGlyphRunDescription obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteGlyphRunDescription>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteGlyphRunDescription> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (nint)obj.localeName);
            DXMarshal.Write(ref buffer, (nint)obj.textString);
            DXMarshal.Write(ref buffer, (nint)obj.textLength);
            DXMarshal.Write(ref buffer, (nint)obj.clusterMap);
            DXMarshal.Write(ref buffer, obj.textPosition);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteGlyphRunDescription NativeReadFrom(nint buffer)
    {
        DWriteGlyphRunDescription obj;
        obj.localeName = (char*)DXMarshal.ReadIntPtr(ref buffer);
        obj.textString = (char*)DXMarshal.ReadIntPtr(ref buffer);
        obj.textLength = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.clusterMap = (ushort*)DXMarshal.ReadIntPtr(ref buffer);
        obj.textPosition = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteGlyphRunDescription> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The locale name associated with this run.
    /// </summary>
    private char* localeName;

    /// <summary>
    /// The text associated with the glyphs.
    /// </summary>
    private char* textString;

    /// <summary>
    /// The number of characters (UTF16 code-units).
    /// Note that this may be different than the number of glyphs.
    /// </summary>
    private uint textLength;

    /// <summary>
    /// An array of indices to the glyph indices array, of the first glyphs of
    /// all the glyph clusters of the glyphs to render. 
    /// </summary>
    private ushort* clusterMap;

    /// <summary>
    /// Corresponding text position in the original string
    /// this glyph run came from.
    /// </summary>
    private uint textPosition;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="localeName"></param>
    /// <param name="textString"></param>
    /// <param name="clusterMap"></param>
    /// <param name="textPosition"></param>
    public DWriteGlyphRunDescription(char* localeName, char* textString, ushort* clusterMap, uint textPosition)
    {
        LocaleName = localeName;
        TextString = textString;
        ClusterMap = clusterMap;
        TextPosition = textPosition;
    }

    /// <summary>
    /// Gets or sets the locale name associated with this run.
    /// </summary>
    public char* LocaleName
    {
        get { return this.localeName; }
        set { this.localeName = value; }
    }

    /// <summary>
    /// Gets or sets the text associated with the glyphs.
    /// </summary>
    public char* TextString
    {
        get
        {
            return this.textString;
        }

        set
        {
            this.textString = value;
            this.textLength = value == null ? 0U : (uint)DXMarshal.GetNullTerminatedStringCountUni((nint)value);
        }
    }

    /// <summary>
    /// Gets the number of characters (UTF16 code-units).
    /// Note that this may be different than the number of glyphs.
    /// </summary>
    public uint TextLength
    {
        get { return this.textLength; }
    }

    /// <summary>
    /// Gets or sets an array of indices to the glyph indices array, of the first glyphs of
    /// all the glyph clusters of the glyphs to render. 
    /// </summary>
    public ushort* ClusterMap
    {
        get
        {
            return this.clusterMap;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.clusterMap = value;
        }
    }

    /// <summary>
    /// Gets or sets the corresponding text position in the original string
    /// this glyph run came from.
    /// </summary>
    public uint TextPosition
    {
        get { return this.textPosition; }
        set { this.textPosition = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteGlyphRunDescription left, DWriteGlyphRunDescription right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteGlyphRunDescription left, DWriteGlyphRunDescription right)
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
        return obj is DWriteGlyphRunDescription description && Equals(description);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteGlyphRunDescription other)
    {
        return localeName == other.localeName &&
               textString == other.textString &&
               textLength == other.textLength &&
               clusterMap == other.clusterMap &&
               textPosition == other.textPosition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1258780513;
        hashCode = hashCode * -1521134295 + ((nint)localeName).GetHashCode();
        hashCode = hashCode * -1521134295 + ((nint)textString).GetHashCode();
        hashCode = hashCode * -1521134295 + textLength.GetHashCode();
        hashCode = hashCode * -1521134295 + ((nint)clusterMap).GetHashCode();
        hashCode = hashCode * -1521134295 + textPosition.GetHashCode();
        return hashCode;
    }
}
