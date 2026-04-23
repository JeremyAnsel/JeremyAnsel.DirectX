// <copyright file="D2D1DrawingStateDescription.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the drawing state of a render target.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1DrawingStateDescription : IEquatable<D2D1DrawingStateDescription>
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
        size += sizeof(int) * 2; // enum
        size += sizeof(ulong) * 2;
        size += D2D1Matrix3X2F.NativeRequiredSize();
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1DrawingStateDescription obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1DrawingStateDescription>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1DrawingStateDescription> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.antialiasMode);
            DXMarshal.Write(ref buffer, (int)obj.textAntialiasMode);
            DXMarshal.Write(ref buffer, obj.tag1);
            DXMarshal.Write(ref buffer, obj.tag2);
            D2D1Matrix3X2F.NativeWriteTo(buffer, obj.transform);
            buffer += D2D1Matrix3X2F.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1DrawingStateDescription NativeReadFrom(nint buffer)
    {
        D2D1DrawingStateDescription obj;
        obj.antialiasMode = (D2D1AntialiasMode)DXMarshal.ReadInt32(ref buffer);
        obj.textAntialiasMode = (D2D1TextAntialiasMode)DXMarshal.ReadInt32(ref buffer);
        obj.tag1 = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.tag2 = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.transform = D2D1Matrix3X2F.NativeReadFrom(buffer);
        buffer += D2D1Matrix3X2F.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1DrawingStateDescription> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The antialiasing mode for subsequent nontext drawing operations.
    /// </summary>
    private D2D1AntialiasMode antialiasMode;

    /// <summary>
    /// The antialiasing mode for subsequent text and glyph drawing operations.
    /// </summary>
    private D2D1TextAntialiasMode textAntialiasMode;

    /// <summary>
    /// A label for subsequent drawing operations.
    /// </summary>
    private ulong tag1;

    /// <summary>
    /// A label for subsequent drawing operations.
    /// </summary>
    private ulong tag2;

    /// <summary>
    /// The transformation to apply to subsequent drawing operations.
    /// </summary>
    private D2D1Matrix3X2F transform;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1DrawingStateDescription"/> struct.
    /// </summary>
    /// <param name="antialiasMode">The antialiasing mode for subsequent nontext drawing operations.</param>
    /// <param name="textAntialiasMode">The antialiasing mode for subsequent text and glyph drawing operations.</param>
    public D2D1DrawingStateDescription(D2D1AntialiasMode antialiasMode, D2D1TextAntialiasMode textAntialiasMode)
    {
        this.antialiasMode = antialiasMode;
        this.textAntialiasMode = textAntialiasMode;
        this.tag1 = 0U;
        this.tag2 = 0U;
        this.transform = D2D1Matrix3X2F.Identity;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1DrawingStateDescription"/> struct.
    /// </summary>
    /// <param name="antialiasMode">The antialiasing mode for subsequent nontext drawing operations.</param>
    /// <param name="textAntialiasMode">The antialiasing mode for subsequent text and glyph drawing operations.</param>
    /// <param name="tag1">The first label for subsequent drawing operations.</param>
    /// <param name="tag2">The second label for subsequent drawing operations.</param>
    /// <param name="transform">The transformation to apply to subsequent drawing operations.</param>
    public D2D1DrawingStateDescription(D2D1AntialiasMode antialiasMode, D2D1TextAntialiasMode textAntialiasMode, ulong tag1, ulong tag2, D2D1Matrix3X2F transform)
    {
        this.antialiasMode = antialiasMode;
        this.textAntialiasMode = textAntialiasMode;
        this.tag1 = tag1;
        this.tag2 = tag2;
        this.transform = transform;
    }

    /// <summary>
    /// Gets default description.
    /// </summary>
    public static D2D1DrawingStateDescription Default
    {
        get { return new D2D1DrawingStateDescription(D2D1AntialiasMode.PerPrimitive, D2D1TextAntialiasMode.Default, 0U, 0U, D2D1Matrix3X2F.Identity); }
    }

    /// <summary>
    /// Gets or sets the antialiasing mode for subsequent nontext drawing operations.
    /// </summary>
    public D2D1AntialiasMode AntialiasMode
    {
        get { return this.antialiasMode; }
        set { this.antialiasMode = value; }
    }

    /// <summary>
    /// Gets or sets the antialiasing mode for subsequent text and glyph drawing operations.
    /// </summary>
    public D2D1TextAntialiasMode TextAntialiasMode
    {
        get { return this.textAntialiasMode; }
        set { this.textAntialiasMode = value; }
    }

    /// <summary>
    /// Gets or sets a label for subsequent drawing operations.
    /// </summary>
    public ulong Tag1
    {
        get { return this.tag1; }
        set { this.tag1 = value; }
    }

    /// <summary>
    /// Gets or sets a label for subsequent drawing operations.
    /// </summary>
    public ulong Tag2
    {
        get { return this.tag2; }
        set { this.tag2 = value; }
    }

    /// <summary>
    /// Gets or sets the transformation to apply to subsequent drawing operations.
    /// </summary>
    public D2D1Matrix3X2F Transform
    {
        get { return this.transform; }
        set { this.transform = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1DrawingStateDescription left, D2D1DrawingStateDescription right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1DrawingStateDescription left, D2D1DrawingStateDescription right)
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
        return obj is D2D1DrawingStateDescription description && Equals(description);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1DrawingStateDescription other)
    {
        return antialiasMode == other.antialiasMode &&
               textAntialiasMode == other.textAntialiasMode &&
               tag1 == other.tag1 &&
               tag2 == other.tag2 &&
               transform.Equals(other.transform);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 2020753257;
        hashCode = hashCode * -1521134295 + antialiasMode.GetHashCode();
        hashCode = hashCode * -1521134295 + textAntialiasMode.GetHashCode();
        hashCode = hashCode * -1521134295 + tag1.GetHashCode();
        hashCode = hashCode * -1521134295 + tag2.GetHashCode();
        hashCode = hashCode * -1521134295 + transform.GetHashCode();
        return hashCode;
    }
}
