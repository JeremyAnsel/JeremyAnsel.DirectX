// <copyright file="DxgiGammaControlCapabilities.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Controls the gamma capabilities of an adapter.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiGammaControlCapabilities : IEquatable<DxgiGammaControlCapabilities>
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
        size += sizeof(int); // bool
        size += sizeof(float) * 2;
        size += sizeof(uint);
        size += Single1025.TotalSize;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiGammaControlCapabilities obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiGammaControlCapabilities>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiGammaControlCapabilities> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isScaleAndOffsetSupported);
            DXMarshal.Write(ref buffer, obj.maximumConvertedValue);
            DXMarshal.Write(ref buffer, obj.minimumConvertedValue);
            DXMarshal.Write(ref buffer, obj.gammaControlPointsCount);

            fixed (float* ptr = obj.gammaControlPointPositions.Buffer)
            {
                DXMarshal.Write(ref buffer, new ReadOnlySpan<byte>(ptr, Single1025.TotalSize));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiGammaControlCapabilities NativeReadFrom(nint buffer)
    {
        DxgiGammaControlCapabilities obj;
        obj.isScaleAndOffsetSupported = DXMarshal.ReadBool(ref buffer);
        obj.maximumConvertedValue = DXMarshal.ReadSingle(ref buffer);
        obj.minimumConvertedValue = DXMarshal.ReadSingle(ref buffer);
        obj.gammaControlPointsCount = DXMarshal.ReadUnsignedInt32(ref buffer);
        DXMarshal.ReadSpanByte(ref buffer, new Span<byte>(obj.gammaControlPointPositions.Buffer, Single1025.TotalSize));
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiGammaControlCapabilities> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    private struct Single1025
    {
        public fixed float Buffer[Length];
        public const int Length = 1025;
        public const int TotalSize = sizeof(float) * Length;
    }

    /// <summary>
    /// <value>true</value> if scaling and offset operations are supported during gamma correction; otherwise, <value>false</value>.
    /// </summary>
    private bool isScaleAndOffsetSupported;

    /// <summary>
    /// A value describing the maximum range of the control-point positions.
    /// </summary>
    private float maximumConvertedValue;

    /// <summary>
    /// A value describing the minimum range of the control-point positions.
    /// </summary>
    private float minimumConvertedValue;

    /// <summary>
    /// A value describing the number of control points in the array.
    /// </summary>
    private uint gammaControlPointsCount;

    /// <summary>
    /// An array of values describing control points; the maximum length of control points is 1025.
    /// </summary>
    private Single1025 gammaControlPointPositions;

    /// <summary>
    /// Gets a value indicating whether scaling and offset operations are supported during gamma correction.
    /// </summary>
    public bool IsScaleAndOffsetSupported
    {
        get { return this.isScaleAndOffsetSupported; }
    }

    /// <summary>
    /// Gets a value describing the maximum range of the control-point positions.
    /// </summary>
    public float MaximumConvertedValue
    {
        get { return this.maximumConvertedValue; }
    }

    /// <summary>
    /// Gets a value describing the minimum range of the control-point positions.
    /// </summary>
    public float MinimumConvertedValue
    {
        get { return this.minimumConvertedValue; }
    }

    /// <summary>
    /// A value describing the number of control points in the array.
    /// </summary>
    public uint GammaControlPointsCount
    {
        get { return this.gammaControlPointsCount; }
    }

    /// <summary>
    /// Gets the count of <see cref="float"/> structures that control the points of a gamma curve.
    /// </summary>
    public const int GammaControlPointPositionsLength = Single1025.Length;

    /// <summary>
    /// Gets an array of values describing control points; the maximum length of control points is 1025.
    /// </summary>
    /// <returns>An array of values describing control points.</returns>
    public readonly float[] GetGammaControlPointPositions()
    {
        var positions = new float[Single1025.Length];
        fixed (float* ptr = this.gammaControlPointPositions.Buffer)
        {
            new ReadOnlySpan<float>(ptr, Single1025.Length)
                .CopyTo(positions.AsSpan());
        }

        return positions;
    }

    /// <summary>
    /// Gets an array as span of <see cref="DxgiColorRgb"/> structures that control the points of a gamma curve.
    /// </summary>
    /// <returns></returns>
    public readonly ReadOnlySpan<float> GetGammaControlPointPositionsAsSpan()
    {
        fixed (float* ptr = this.gammaControlPointPositions.Buffer)
        {
            return new ReadOnlySpan<float>(ptr, Single1025.Length);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiGammaControlCapabilities left, DxgiGammaControlCapabilities right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiGammaControlCapabilities left, DxgiGammaControlCapabilities right)
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
        return obj is DxgiGammaControlCapabilities capabilities && Equals(capabilities);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiGammaControlCapabilities other)
    {
        fixed (float* ptrThis = gammaControlPointPositions.Buffer)
        {
            ReadOnlySpan<float> spanThis = new(ptrThis, Single1025.Length);
            ReadOnlySpan<float> spanOther = new(other.gammaControlPointPositions.Buffer, Single1025.Length);

            return isScaleAndOffsetSupported == other.isScaleAndOffsetSupported &&
                   maximumConvertedValue == other.maximumConvertedValue &&
                   minimumConvertedValue == other.minimumConvertedValue &&
                   gammaControlPointsCount == other.gammaControlPointsCount &&
                   spanThis.SequenceEqual(spanOther);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -813563733;
        hashCode = hashCode * -1521134295 + isScaleAndOffsetSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + maximumConvertedValue.GetHashCode();
        hashCode = hashCode * -1521134295 + minimumConvertedValue.GetHashCode();
        hashCode = hashCode * -1521134295 + gammaControlPointsCount.GetHashCode();
        hashCode = hashCode * -1521134295 + gammaControlPointPositions.GetHashCode();
        return hashCode;
    }
}
