// <copyright file="DxgiColorRgba.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The structure represents a color value with alpha, which is used for transparency.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiColorRgba : IEquatable<DxgiColorRgba>
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
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiColorRgba obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiColorRgba>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiColorRgba> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.red);
            DXMarshal.Write(ref buffer, obj.green);
            DXMarshal.Write(ref buffer, obj.blue);
            DXMarshal.Write(ref buffer, obj.alpha);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiColorRgba NativeReadFrom(nint buffer)
    {
        DxgiColorRgba obj;
        obj.red = DXMarshal.ReadSingle(ref buffer);
        obj.green = DXMarshal.ReadSingle(ref buffer);
        obj.blue = DXMarshal.ReadSingle(ref buffer);
        obj.alpha = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiColorRgba> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
    /// </summary>
    private float red;

    /// <summary>
    /// A value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
    /// </summary>
    private float green;

    /// <summary>
    /// A value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
    /// </summary>
    private float blue;

    /// <summary>
    /// A value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
    /// </summary>
    private float alpha;

    /// <summary>
    /// Gets or sets a value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
    /// </summary>
    public float Red
    {
        get { return this.red; }
        set { this.red = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
    /// </summary>
    public float Green
    {
        get { return this.green; }
        set { this.green = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
    /// </summary>
    public float Blue
    {
        get { return this.blue; }
        set { this.blue = value; }
    }

    /// <summary>
    /// Gets or sets value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
    /// </summary>
    public float Alpha
    {
        get { return this.alpha; }
        set { this.alpha = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiColorRgba left, DxgiColorRgba right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiColorRgba left, DxgiColorRgba right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0};{1};{2};{3}",
            this.red,
            this.green,
            this.blue,
            this.alpha);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiColorRgba rgba && Equals(rgba);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiColorRgba other)
    {
        return red == other.red &&
               green == other.green &&
               blue == other.blue &&
               alpha == other.alpha;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 214250488;
        hashCode = hashCode * -1521134295 + red.GetHashCode();
        hashCode = hashCode * -1521134295 + green.GetHashCode();
        hashCode = hashCode * -1521134295 + blue.GetHashCode();
        hashCode = hashCode * -1521134295 + alpha.GetHashCode();
        return hashCode;
    }
}
