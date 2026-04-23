// <copyright file="DXMarshal.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXCommon;

/// <summary>
/// 
/// </summary>
[SkipLocalsInit]
public static unsafe class DXMarshal
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SizeOf<T>() where T : unmanaged
    {
        return sizeof(T);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SizeOf<T>(T[] data) where T : unmanaged
    {
        return sizeof(T) * data.Length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SizeOf<T>(ReadOnlySpan<T> data) where T : unmanaged
    {
        return sizeof(T) * data.Length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, bool value)
    {
        *(int*)buffer = value ? 1 : 0;
        buffer += sizeof(int);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, char value)
    {
        *(char*)buffer = value;
        buffer += sizeof(char);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, byte value)
    {
        *(byte*)buffer = value;
        buffer += sizeof(byte);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, sbyte value)
    {
        *(sbyte*)buffer = value;
        buffer += sizeof(sbyte);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, short value)
    {
        *(short*)buffer = value;
        buffer += sizeof(short);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, ushort value)
    {
        *(ushort*)buffer = value;
        buffer += sizeof(ushort);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, int value)
    {
        *(int*)buffer = value;
        buffer += sizeof(int);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, uint value)
    {
        *(uint*)buffer = value;
        buffer += sizeof(uint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, long value)
    {
        *(long*)buffer = value;
        buffer += sizeof(long);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, ulong value)
    {
        *(ulong*)buffer = value;
        buffer += sizeof(ulong);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, float value)
    {
        *(float*)buffer = value;
        buffer += sizeof(float);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, double value)
    {
        *(double*)buffer = value;
        buffer += sizeof(double);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, nint value)
    {
        *(nint*)buffer = value;
        buffer += sizeof(nint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, nuint value)
    {
        *(nuint*)buffer = value;
        buffer += sizeof(nuint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, ReadOnlySpan<char> value)
    {
        value.CopyTo(new Span<char>((void*)buffer, value.Length));
        buffer += 2 * value.Length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(ref nint buffer, ReadOnlySpan<byte> value)
    {
        value.CopyTo(new Span<byte>((void*)buffer, value.Length));
        buffer += value.Length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ReadBool(ref nint buffer)
    {
        bool value = *(int*)buffer != 0;
        buffer += sizeof(int);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ReadChar(ref nint buffer)
    {
        char value = *(char*)buffer;
        buffer += sizeof(char);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ReadByte(ref nint buffer)
    {
        byte value = *(byte*)buffer;
        buffer += sizeof(byte);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte ReadSignedByte(ref nint buffer)
    {
        sbyte value = *(sbyte*)buffer;
        buffer += sizeof(sbyte);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ReadInt16(ref nint buffer)
    {
        short value = *(short*)buffer;
        buffer += sizeof(short);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort ReadUnsignedInt16(ref nint buffer)
    {
        ushort value = *(ushort*)buffer;
        buffer += sizeof(ushort);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ReadInt32(ref nint buffer)
    {
        int value = *(int*)buffer;
        buffer += sizeof(int);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint ReadUnsignedInt32(ref nint buffer)
    {
        uint value = *(uint*)buffer;
        buffer += sizeof(uint);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long ReadInt64(ref nint buffer)
    {
        long value = *(long*)buffer;
        buffer += sizeof(long);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong ReadUnsignedInt64(ref nint buffer)
    {
        ulong value = *(ulong*)buffer;
        buffer += sizeof(ulong);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ReadSingle(ref nint buffer)
    {
        float value = *(float*)buffer;
        buffer += sizeof(float);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ReadDouble(ref nint buffer)
    {
        double value = *(double*)buffer;
        buffer += sizeof(double);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nint ReadIntPtr(ref nint buffer)
    {
        nint value = *(nint*)buffer;
        buffer += sizeof(nint);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nuint ReadUnsignedIntPtr(ref nint buffer)
    {
        nuint value = *(nuint*)buffer;
        buffer += sizeof(nuint);
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReadSpanChar(ref nint buffer, Span<char> value)
    {
        new Span<char>((void*)buffer, value.Length)
            .CopyTo(value);
        buffer += 2 * value.Length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReadSpanByte(ref nint buffer, Span<byte> value)
    {
        new Span<byte>((void*)buffer, value.Length)
            .CopyTo(value);
        buffer += value.Length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int GetNullTerminatedStringCountAnsi(nint str)
    {
        int count = 0;

        while ((*(byte*)str) != 0)
        {
            count++;
            str++;
        }

        return count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int GetNullTerminatedStringCountUni(nint str)
    {
        int count = 0;

        while ((*(char*)str) != 0)
        {
            count++;
            str++;
            str++;
        }

        return count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="buffer"></param>
    /// <param name="value"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteStructure<T>(nint buffer, in T value) where T : unmanaged
    {
        *(T*)buffer = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="buffer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ReadStructure<T>(nint buffer) where T : unmanaged
    {
        return *(T*)buffer;
    }
}
