// <copyright file="DxgiAdapterDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Represents an RGB color.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiColorRgb : IEquatable<DxgiColorRgb>
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
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiColorRgb obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiColorRgb>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiColorRgb> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.red);
            DXMarshal.Write(ref buffer, obj.green);
            DXMarshal.Write(ref buffer, obj.blue);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiColorRgb NativeReadFrom(nint buffer)
    {
        DxgiColorRgb obj;
        obj.red = DXMarshal.ReadSingle(ref buffer);
        obj.green = DXMarshal.ReadSingle(ref buffer);
        obj.blue = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiColorRgb> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value representing the color of the red component. The range of this value is between 0 and 1.
    /// </summary>
    private float red;

    /// <summary>
    /// A value representing the color of the green component. The range of this value is between 0 and 1.
    /// </summary>
    private float green;

    /// <summary>
    /// A value representing the color of the blue component. The range of this value is between 0 and 1.
    /// </summary>
    private float blue;

    /// <summary>
    /// Gets or sets a value representing the color of the red component. The range of this value is between 0 and 1.
    /// </summary>
    public float Red
    {
        get { return this.red; }
        set { this.red = value; }
    }

    /// <summary>
    /// Gets or sets a value representing the color of the green component. The range of this value is between 0 and 1.
    /// </summary>
    public float Green
    {
        get { return this.green; }
        set { this.green = value; }
    }

    /// <summary>
    /// Gets or sets a value representing the color of the blue component. The range of this value is between 0 and 1.
    /// </summary>
    public float Blue
    {
        get { return this.blue; }
        set { this.blue = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiColorRgb left, DxgiColorRgb right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiColorRgb left, DxgiColorRgb right)
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
            "{0};{1};{2}",
            this.red,
            this.green,
            this.blue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiColorRgb rgb && Equals(rgb);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiColorRgb other)
    {
        return red == other.red &&
               green == other.green &&
               blue == other.blue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1602832517;
        hashCode = hashCode * -1521134295 + red.GetHashCode();
        hashCode = hashCode * -1521134295 + green.GetHashCode();
        hashCode = hashCode * -1521134295 + blue.GetHashCode();
        return hashCode;
    }
}
