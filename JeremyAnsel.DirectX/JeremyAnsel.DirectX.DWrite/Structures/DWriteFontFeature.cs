// <copyright file="DWriteFontFeature.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_FONT_FEATURE structure specifies properties used to identify and execute typographic feature in the font.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteFontFeature : IEquatable<DWriteFontFeature>
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
    public static void NativeWriteTo(nint buffer, in DWriteFontFeature obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteFontFeature>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteFontFeature> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.nameTag);
            DXMarshal.Write(ref buffer, obj.parameter);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteFontFeature NativeReadFrom(nint buffer)
    {
        DWriteFontFeature obj;
        obj.nameTag = (DWriteFontFeatureTag)DXMarshal.ReadInt32(ref buffer);
        obj.parameter = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteFontFeature> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The feature OpenType name identifier.
    /// </summary>
    private DWriteFontFeatureTag nameTag;

    /// <summary>
    /// Execution parameter of the feature.
    /// </summary>
    /// <remarks>
    /// The parameter should be non-zero to enable the feature.  Once enabled, a feature can't be disabled again within
    /// the same range.  Features requiring a selector use this value to indicate the selector index. 
    /// </remarks>
    private uint parameter;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFontFeature"/> struct.
    /// </summary>
    /// <param name="nameTag">The feature OpenType name identifier.</param>
    /// <param name="parameter">Execution parameter of the feature.</param>
    public DWriteFontFeature(DWriteFontFeatureTag nameTag, uint parameter)
    {
        this.nameTag = nameTag;
        this.parameter = parameter;
    }

    /// <summary>
    /// Gets or sets the feature OpenType name identifier.
    /// </summary>
    public DWriteFontFeatureTag NameTag
    {
        get { return this.nameTag; }
        set { this.nameTag = value; }
    }

    /// <summary>
    /// Gets or sets the execution parameter of the feature.
    /// </summary>
    /// <remarks>
    /// The parameter should be non-zero to enable the feature.  Once enabled, a feature can't be disabled again within
    /// the same range.  Features requiring a selector use this value to indicate the selector index. 
    /// </remarks>
    public uint Parameter
    {
        get { return this.parameter; }
        set { this.parameter = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteFontFeature left, DWriteFontFeature right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteFontFeature left, DWriteFontFeature right)
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
        return obj is DWriteFontFeature feature && Equals(feature);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteFontFeature other)
    {
        return nameTag == other.nameTag &&
               parameter == other.parameter;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 332760406;
        hashCode = hashCode * -1521134295 + nameTag.GetHashCode();
        hashCode = hashCode * -1521134295 + parameter.GetHashCode();
        return hashCode;
    }
}
