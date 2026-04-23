// <copyright file="DxgiGammaControl.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Controls the settings of a gamma curve.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiGammaControl : IEquatable<DxgiGammaControl>
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
        size += DxgiColorRgb.NativeRequiredSize(2);
        size += DxgiColorRgb1025.TotalSize;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiGammaControl obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiGammaControl>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiGammaControl> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DxgiColorRgb.NativeWriteTo(buffer, obj.scale);
            buffer += DxgiColorRgb.NativeRequiredSize();
            DxgiColorRgb.NativeWriteTo(buffer, obj.offset);
            buffer += DxgiColorRgb.NativeRequiredSize();

            fixed (byte* ptr = obj.gammaCurve.Buffer)
            {
                DXMarshal.Write(ref buffer, new ReadOnlySpan<byte>(ptr, DxgiColorRgb1025.TotalSize));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiGammaControl NativeReadFrom(nint buffer)
    {
        DxgiGammaControl obj;
        obj.scale = DxgiColorRgb.NativeReadFrom(buffer);
        buffer += DxgiColorRgb.NativeRequiredSize();
        obj.offset = DxgiColorRgb.NativeReadFrom(buffer);
        buffer += DxgiColorRgb.NativeRequiredSize();
        DXMarshal.ReadSpanByte(ref buffer, new Span<byte>(obj.gammaCurve.Buffer, DxgiColorRgb1025.TotalSize));
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiGammaControl> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    private struct DxgiColorRgb1025
    {
        public fixed byte Buffer[TotalSize];
        public const int Length = 1025;
        public const int TotalSize = sizeof(float) * 3 * Length;
    }

    /// <summary>
    /// A <see cref="DxgiColorRgb"/> structure with scalar values that are applied to RGB values before being sent to the gamma look up table.
    /// </summary>
    private DxgiColorRgb scale;

    /// <summary>
    /// A <see cref="DxgiColorRgb"/> structure with offset values that are applied to the RGB values before being sent to the gamma look up table.
    /// </summary>
    private DxgiColorRgb offset;

    /// <summary>
    /// An array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    private DxgiColorRgb1025 gammaCurve;

    /// <summary>
    /// Gets or sets a <see cref="DxgiColorRgb"/> structure with scalar values that are applied to RGB values before being sent to the gamma look up table.
    /// </summary>
    public DxgiColorRgb Scale
    {
        get { return this.scale; }
        set { this.scale = value; }
    }

    /// <summary>
    /// Gets or sets a <see cref="DxgiColorRgb"/> structure with offset values that are applied to the RGB values before being sent to the gamma look up table.
    /// </summary>
    public DxgiColorRgb Offset
    {
        get { return this.offset; }
        set { this.offset = value; }
    }

    /// <summary>
    /// Gets the count of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    public const int GammaCurveLength = DxgiColorRgb1025.Length;

    /// <summary>
    /// Gets an array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    /// <returns>An array of <see cref="DxgiColorRgb"/> structures.</returns>
    public readonly DxgiColorRgb[] GetGammaCurve()
    {
        var curve = new DxgiColorRgb[DxgiColorRgb1025.Length];
        fixed (byte* ptr = this.gammaCurve.Buffer)
        {
            new ReadOnlySpan<DxgiColorRgb>(ptr, DxgiColorRgb1025.Length)
                .CopyTo(curve.AsSpan());
        }

        return curve;
    }

    /// <summary>
    /// Gets an array as span of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    /// <returns></returns>
    public readonly ReadOnlySpan<DxgiColorRgb> GetGammaCurveAsSpan()
    {
        fixed (byte* ptr = this.gammaCurve.Buffer)
        {
            return new ReadOnlySpan<DxgiColorRgb>(ptr, DxgiColorRgb1025.Length);
        }
    }

    /// <summary>
    /// Sets an array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    /// <param name="curve">An array of <see cref="DxgiColorRgb"/> structures.</param>
    public void SetGammaCurve(DxgiColorRgb[]? curve)
    {
        if (curve == null)
        {
            throw new ArgumentNullException(nameof(curve));
        }

        if (curve.Length != DxgiColorRgb1025.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(curve));
        }

        fixed (byte* ptr = this.gammaCurve.Buffer)
        {
            curve.AsSpan()
                .CopyTo(new Span<DxgiColorRgb>(ptr, DxgiColorRgb1025.Length));
        }
    }

    /// <summary>
    /// Sets an array of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    /// <param name="curve">An array of <see cref="DxgiColorRgb"/> structures.</param>
    public void SetGammaCurve(ReadOnlySpan<DxgiColorRgb> curve)
    {
        if (curve.Length != DxgiColorRgb1025.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(curve));
        }

        fixed (byte* ptr = this.gammaCurve.Buffer)
        {
            curve.CopyTo(new Span<DxgiColorRgb>(ptr, DxgiColorRgb1025.Length));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiGammaControl left, DxgiGammaControl right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiGammaControl left, DxgiGammaControl right)
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
        return obj is DxgiGammaControl control && Equals(control);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiGammaControl other)
    {
        fixed (byte* ptrThis = gammaCurve.Buffer)
        {
            ReadOnlySpan<DxgiColorRgb> spanThis = new(ptrThis, DxgiColorRgb1025.Length);
            ReadOnlySpan<DxgiColorRgb> spanOther = new(other.gammaCurve.Buffer, DxgiColorRgb1025.Length);

            return scale.Equals(other.scale) &&
                   offset.Equals(other.offset) &&
                   spanThis.SequenceEqual(spanOther);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1067500168;
        hashCode = hashCode * -1521134295 + scale.GetHashCode();
        hashCode = hashCode * -1521134295 + offset.GetHashCode();
        hashCode = hashCode * -1521134295 + gammaCurve.GetHashCode();
        return hashCode;
    }
}
