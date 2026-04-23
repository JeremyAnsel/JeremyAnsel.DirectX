// <copyright file="D3D11QueryDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a query.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11QueryDesc : IEquatable<D3D11QueryDesc>
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
    public static void NativeWriteTo(nint buffer, in D3D11QueryDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11QueryDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11QueryDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.query);
            DXMarshal.Write(ref buffer, (int)obj.miscOptions);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11QueryDesc NativeReadFrom(nint buffer)
    {
        D3D11QueryDesc obj;
        obj.query = (D3D11QueryType)DXMarshal.ReadInt32(ref buffer);
        obj.miscOptions = (D3D11QueryMiscOptions)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11QueryDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The type of query.
    /// </summary>
    private D3D11QueryType query;

    /// <summary>
    /// Miscellaneous options.
    /// </summary>
    private D3D11QueryMiscOptions miscOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11QueryDesc"/> struct.
    /// </summary>
    /// <param name="query">The type of query.</param>
    public D3D11QueryDesc(D3D11QueryType query)
    {
        this.query = query;
        this.miscOptions = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11QueryDesc"/> struct.
    /// </summary>
    /// <param name="query">The type of query.</param>
    /// <param name="miscOptions">Miscellaneous options.</param>
    public D3D11QueryDesc(D3D11QueryType query, D3D11QueryMiscOptions miscOptions)
    {
        this.query = query;
        this.miscOptions = miscOptions;
    }

    /// <summary>
    /// Gets or sets the type of query.
    /// </summary>
    public D3D11QueryType Query
    {
        get { return this.query; }
        set { this.query = value; }
    }

    /// <summary>
    /// Gets or sets miscellaneous options.
    /// </summary>
    public D3D11QueryMiscOptions MiscOptions
    {
        get { return this.miscOptions; }
        set { this.miscOptions = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11QueryDesc left, D3D11QueryDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11QueryDesc left, D3D11QueryDesc right)
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
        return obj is D3D11QueryDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11QueryDesc other)
    {
        return query == other.query &&
               miscOptions == other.miscOptions;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1021428660;
        hashCode = hashCode * -1521134295 + query.GetHashCode();
        hashCode = hashCode * -1521134295 + miscOptions.GetHashCode();
        return hashCode;
    }
}
