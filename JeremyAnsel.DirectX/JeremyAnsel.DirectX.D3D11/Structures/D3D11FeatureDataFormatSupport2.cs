// <copyright file="D3D11FeatureDataFormatSupport2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes which unordered resource options are supported by the current graphics driver for a given format.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataFormatSupport2 : IEquatable<D3D11FeatureDataFormatSupport2>
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
        size += sizeof(int) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataFormatSupport2 obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataFormatSupport2>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataFormatSupport2> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.inFormat);
            DXMarshal.Write(ref buffer, (int)obj.outFormatSupport2);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataFormatSupport2 NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataFormatSupport2 obj;
        obj.inFormat = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.outFormatSupport2 = (D3D11FormatSupport2)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataFormatSupport2> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The <see cref="DxgiFormat"/> to return information on.
    /// </summary>
    private DxgiFormat inFormat;

    /// <summary>
    /// Combination of <see cref="D3D11FormatSupport2"/> flags indicating which unordered resource options are supported.
    /// </summary>
    private D3D11FormatSupport2 outFormatSupport2;

    /// <summary>
    /// Gets the <see cref="DxgiFormat"/> to return information on.
    /// </summary>
    public DxgiFormat InFormat
    {
        get { return this.inFormat; }
    }

    /// <summary>
    /// Gets a combination of <see cref="D3D11FormatSupport2"/> flags indicating which unordered resource options are supported.
    /// </summary>
    public D3D11FormatSupport2 OutFormatSupport2
    {
        get { return this.outFormatSupport2; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataFormatSupport2 left, D3D11FeatureDataFormatSupport2 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataFormatSupport2 left, D3D11FeatureDataFormatSupport2 right)
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
        return obj is D3D11FeatureDataFormatSupport2 support && Equals(support);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataFormatSupport2 other)
    {
        return inFormat == other.inFormat &&
               outFormatSupport2 == other.outFormatSupport2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1244152508;
        hashCode = hashCode * -1521134295 + inFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + outFormatSupport2.GetHashCode();
        return hashCode;
    }
}
