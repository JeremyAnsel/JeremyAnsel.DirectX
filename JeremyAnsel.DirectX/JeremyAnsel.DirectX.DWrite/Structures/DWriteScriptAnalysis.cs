// <copyright file="DWriteScriptAnalysis.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Association of text and its writing system script as well as some display attributes.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteScriptAnalysis : IEquatable<DWriteScriptAnalysis>
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
        size += sizeof(ushort);
        size += sizeof(int); // enum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DWriteScriptAnalysis obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteScriptAnalysis>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteScriptAnalysis> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.script);
            DXMarshal.Write(ref buffer, (int)obj.shapes);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteScriptAnalysis NativeReadFrom(nint buffer)
    {
        DWriteScriptAnalysis obj;
        obj.script = DXMarshal.ReadUnsignedInt16(ref buffer);
        obj.shapes = (DWriteScriptShape)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteScriptAnalysis> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Zero-based index representation of writing system script.
    /// </summary>
    private ushort script;

    /// <summary>
    /// Additional shaping requirement of text.
    /// </summary>
    private DWriteScriptShape shapes;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteScriptAnalysis"/> struct.
    /// </summary>
    /// <param name="script">Zero-based index representation of writing system script.</param>
    /// <param name="shapes">Additional shaping requirement of text.</param>
    public DWriteScriptAnalysis(ushort script, DWriteScriptShape shapes)
    {
        this.script = script;
        this.shapes = shapes;
    }

    /// <summary>
    /// Gets or sets the zero-based index representation of writing system script.
    /// </summary>
    public ushort Script
    {
        get { return this.script; }
        set { this.script = value; }
    }

    /// <summary>
    /// Gets or sets the additional shaping requirement of text.
    /// </summary>
    public DWriteScriptShape Shapes
    {
        get { return this.shapes; }
        set { this.shapes = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteScriptAnalysis left, DWriteScriptAnalysis right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteScriptAnalysis left, DWriteScriptAnalysis right)
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
        return obj is DWriteScriptAnalysis analysis && Equals(analysis);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteScriptAnalysis other)
    {
        return script == other.script &&
               shapes == other.shapes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 987002121;
        hashCode = hashCode * -1521134295 + script.GetHashCode();
        hashCode = hashCode * -1521134295 + shapes.GetHashCode();
        return hashCode;
    }
}
