// <copyright file="D2D1FactoryOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the debugging level of an <see cref="D2D1Factory"/> object.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1FactoryOptions : IEquatable<D2D1FactoryOptions>
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
        size += sizeof(int); // enum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1FactoryOptions obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1FactoryOptions>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1FactoryOptions> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.debugLevel);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1FactoryOptions NativeReadFrom(nint buffer)
    {
        D2D1FactoryOptions obj;
        obj.debugLevel = (D2D1DebugLevel)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1FactoryOptions> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Requests a certain level of debugging information from the debug layer. This
    /// parameter is ignored if the debug layer DLL is not present.
    /// </summary>
    private D2D1DebugLevel debugLevel;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1FactoryOptions"/> struct.
    /// </summary>
    /// <param name="debugLevel">The level of debugging information.</param>
    public D2D1FactoryOptions(D2D1DebugLevel debugLevel)
    {
        this.debugLevel = debugLevel;
    }

    /// <summary>
    /// Gets or sets a certain level of debugging information from the debug layer. This
    /// parameter is ignored if the debug layer DLL is not present.
    /// </summary>
    public D2D1DebugLevel DebugLevel
    {
        get { return this.debugLevel; }
        set { this.debugLevel = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1FactoryOptions left, D2D1FactoryOptions right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1FactoryOptions left, D2D1FactoryOptions right)
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
        return obj is D2D1FactoryOptions options && Equals(options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1FactoryOptions other)
    {
        return debugLevel == other.debugLevel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 90279198 + debugLevel.GetHashCode();
    }
}
