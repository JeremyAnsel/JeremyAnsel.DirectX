// <copyright file="D3D11StreamOutputDeclarationEntry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Text;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Description of a vertex element in a vertex buffer in an output slot.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11StreamOutputDeclarationEntry : IEquatable<D3D11StreamOutputDeclarationEntry>
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
        size += NativeRequiredBaseSize();
        size += Buffer64.TotalSize;
        return size * count;
    }

    private static int NativeRequiredBaseSize()
    {
        int size = 0;
        size += sizeof(uint) * 2;
        size += DXMarshal.PaddingSize();
        size += sizeof(nint);
        size += sizeof(byte) * 3;
        size += 1; // padding
        return size;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11StreamOutputDeclarationEntry obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11StreamOutputDeclarationEntry>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11StreamOutputDeclarationEntry> objects)
    {
        nint namesOffset = buffer + NativeRequiredBaseSize() * objects.Length;

        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.stream);
            DXMarshal.WritePadding(ref buffer);
            int nameLength = obj.GetSemanticNameCharCount();
            DXMarshal.Write(ref buffer, nameLength == 0 ? 0 : (namesOffset + index * Buffer64.Length));
            DXMarshal.Write(ref buffer, obj.semanticIndex);
            DXMarshal.Write(ref buffer, obj.startComponent);
            DXMarshal.Write(ref buffer, obj.componentCount);
            DXMarshal.Write(ref buffer, obj.outputSlot);
            DXMarshal.Write(ref buffer, (byte)0); // padding
        }

        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            fixed (byte* ptr = obj.semanticName.Buffer)
            {
                DXMarshal.Write(ref buffer, new ReadOnlySpan<byte>(ptr, Buffer64.Length));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11StreamOutputDeclarationEntry NativeReadFrom(nint buffer)
    {
        D3D11StreamOutputDeclarationEntry obj = default;

        obj.stream = DXMarshal.ReadUnsignedInt32(ref buffer);
        buffer += DXMarshal.PaddingSize();

        nint ptr = DXMarshal.ReadIntPtr(ref buffer);
        int bytesCount = ptr == 0 ? 0 : Math.Min(DXMarshal.GetNullTerminatedStringCountAnsi(ptr), Buffer64.Length - 1);

        if (bytesCount != 0)
        {
            Buffer.MemoryCopy((void*)ptr, obj.semanticName.Buffer, bytesCount, bytesCount);
        }

        for (int i = bytesCount; i < Buffer64.Length; i++)
        {
            obj.semanticName.Buffer[i] = 0;
        }

        obj.semanticIndex = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.startComponent = DXMarshal.ReadByte(ref buffer);
        obj.componentCount = DXMarshal.ReadByte(ref buffer);
        obj.outputSlot = DXMarshal.ReadByte(ref buffer);
        buffer += 1; // padding
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11StreamOutputDeclarationEntry> objects)
    {
        int size = NativeRequiredBaseSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    private struct Buffer64
    {
        public fixed byte Buffer[Length];
        public const int Length = 64;
        public const int TotalSize = sizeof(byte) * Length;
    }

    /// <summary>
    /// The stream number.
    /// </summary>
    private uint stream;

    /// <summary>
    /// The type of output element.
    /// </summary>
    private Buffer64 semanticName;

    /// <summary>
    /// The output element's index.
    /// </summary>
    private uint semanticIndex;

    /// <summary>
    /// Which component of the entry to begin writing out to. Valid values are 0 to 3.
    /// </summary>
    private byte startComponent;

    /// <summary>
    /// The number of components of the entry to write out to. Valid values are 1 to 4.
    /// </summary>
    private byte componentCount;

    /// <summary>
    /// The associated stream output buffer that is bound to the pipeline.
    /// </summary>
    private byte outputSlot;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11StreamOutputDeclarationEntry"/> struct.
    /// </summary>
    /// <param name="stream">The stream number.</param>
    /// <param name="semanticName">The type of output element.</param>
    /// <param name="semanticIndex">The output element's index.</param>
    /// <param name="startComponent">Which component of the entry to begin writing out to. Valid values are 0 to 3.</param>
    /// <param name="componentCount">The number of components of the entry to write out to. Valid values are 1 to 4.</param>
    /// <param name="outputSlot">The associated stream output buffer that is bound to the pipeline.</param>
    public D3D11StreamOutputDeclarationEntry(
        uint stream,
        string semanticName,
        uint semanticIndex,
        byte startComponent,
        byte componentCount,
        byte outputSlot)
    {
        this.stream = stream;
        SetSemanticName(semanticName);
        this.semanticIndex = semanticIndex;
        this.startComponent = startComponent;
        this.componentCount = componentCount;
        this.outputSlot = outputSlot;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11StreamOutputDeclarationEntry"/> struct.
    /// </summary>
    /// <param name="stream">The stream number.</param>
    /// <param name="semanticName">The type of output element.</param>
    /// <param name="semanticIndex">The output element's index.</param>
    /// <param name="startComponent">Which component of the entry to begin writing out to. Valid values are 0 to 3.</param>
    /// <param name="componentCount">The number of components of the entry to write out to. Valid values are 1 to 4.</param>
    /// <param name="outputSlot">The associated stream output buffer that is bound to the pipeline.</param>
    public D3D11StreamOutputDeclarationEntry(
        uint stream,
        ReadOnlySpan<char> semanticName,
        uint semanticIndex,
        byte startComponent,
        byte componentCount,
        byte outputSlot)
    {
        this.stream = stream;
        SetSemanticName(semanticName);
        this.semanticIndex = semanticIndex;
        this.startComponent = startComponent;
        this.componentCount = componentCount;
        this.outputSlot = outputSlot;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11StreamOutputDeclarationEntry"/> struct.
    /// </summary>
    /// <param name="stream">The stream number.</param>
    /// <param name="semanticName">The type of output element.</param>
    /// <param name="semanticIndex">The output element's index.</param>
    /// <param name="startComponent">Which component of the entry to begin writing out to. Valid values are 0 to 3.</param>
    /// <param name="componentCount">The number of components of the entry to write out to. Valid values are 1 to 4.</param>
    /// <param name="outputSlot">The associated stream output buffer that is bound to the pipeline.</param>
    public D3D11StreamOutputDeclarationEntry(
        uint stream,
        ReadOnlySpan<byte> semanticName,
        uint semanticIndex,
        byte startComponent,
        byte componentCount,
        byte outputSlot)
    {
        this.stream = stream;
        SetSemanticName(semanticName);
        this.semanticIndex = semanticIndex;
        this.startComponent = startComponent;
        this.componentCount = componentCount;
        this.outputSlot = outputSlot;
    }

    /// <summary>
    /// Gets or sets the stream number.
    /// </summary>
    public uint Stream
    {
        get { return this.stream; }
        set { this.stream = value; }
    }

    /// <summary>
    /// Gets or sets the type of output element.
    /// </summary>
    public string SemanticName
    {
        get
        {
            fixed (byte* ptr = this.semanticName.Buffer)
            {
                int length = DXMarshal.GetNullTerminatedStringCountAnsi((nint)ptr);
                return Encoding.ASCII.GetString(ptr, length);
            }
        }

        set
        {
            SetSemanticName(value);
        }
    }

    /// <summary>
    /// Gets the maximum char count of the string that contains the semantic name.
    /// </summary>
    public const int SemanticNameMaxLength = Buffer64.Length;

    /// <summary>
    /// Gets the type of output element.
    /// </summary>
    /// <returns>The count.</returns>
    public int GetSemanticNameCharCount()
    {
        fixed (byte* ptr = this.semanticName.Buffer)
        {
            return DXMarshal.GetNullTerminatedStringCountAnsi((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the type of output element.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public int GetSemanticNameChars(Span<char> text)
    {
        fixed (byte* ptr = this.semanticName.Buffer)
        fixed (char* textPtr = text)
        {
            int length = DXMarshal.GetNullTerminatedStringCountAnsi((nint)ptr);
            int count = Encoding.ASCII.GetChars(ptr, length, textPtr, text.Length);
            return count;
        }
    }

    /// <summary>
    /// Gets the type of output element.
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<byte> GetSemanticNameAsSpan()
    {
        fixed (byte* semanticNamePtr = semanticName.Buffer)
        {
            int bytesCount = DXMarshal.GetNullTerminatedStringCountAnsi((nint)semanticNamePtr);
            return new ReadOnlySpan<byte>(semanticNamePtr, bytesCount);
        }
    }

    /// <summary>
    /// Sets the type of output element.
    /// </summary>
    /// <param name="value"></param>
    public void SetSemanticName(string value)
    {
        SetSemanticName(value.AsSpan());
    }

    /// <summary>
    /// Sets the type of output element.
    /// </summary>
    /// <param name="value"></param>
    public void SetSemanticName(ReadOnlySpan<char> value)
    {
        int bytesCount;
        fixed (char* textPtr = value)
        {
            bytesCount = Encoding.ASCII.GetByteCount(textPtr, value.Length);
        }

        bytesCount = Math.Min(bytesCount, Buffer64.Length - 1);

        fixed (char* textPtr = value)
        fixed (byte* semanticNamePtr = semanticName.Buffer)
        {
            int count = Encoding.ASCII.GetBytes(textPtr, bytesCount, semanticNamePtr, bytesCount);
            for (int i = count; i < Buffer64.Length; i++)
            {
                semanticNamePtr[i] = 0;
            }
        }
    }

    /// <summary>
    /// Sets the type of output element.
    /// </summary>
    /// <param name="value"></param>
    public void SetSemanticName(ReadOnlySpan<byte> value)
    {
        int bytesCount = Math.Min(value.Length, Buffer64.Length - 1);

        fixed (byte* semanticNamePtr = semanticName.Buffer)
        {
            Span<byte> semanticNameSpan = new(semanticNamePtr, bytesCount);
            value.CopyTo(semanticNameSpan);
            for (int i = bytesCount; i < Buffer64.Length; i++)
            {
                semanticNamePtr[i] = 0;
            }
        }
    }

    /// <summary>
    /// Gets or sets the output element's index.
    /// </summary>
    public uint SemanticIndex
    {
        get { return this.semanticIndex; }
        set { this.semanticIndex = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating which component of the entry to begin writing out to. Valid values are 0 to 3.
    /// </summary>
    public byte StartComponent
    {
        get { return this.startComponent; }
        set { this.startComponent = value; }
    }

    /// <summary>
    /// Gets or sets the number of components of the entry to write out to. Valid values are 1 to 4.
    /// </summary>
    public byte ComponentCount
    {
        get { return this.componentCount; }
        set { this.componentCount = value; }
    }

    /// <summary>
    /// Gets or sets the associated stream output buffer that is bound to the pipeline.
    /// </summary>
    public byte OutputSlot
    {
        get { return this.outputSlot; }
        set { this.outputSlot = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11StreamOutputDeclarationEntry left, D3D11StreamOutputDeclarationEntry right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11StreamOutputDeclarationEntry left, D3D11StreamOutputDeclarationEntry right)
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
        return obj is D3D11StreamOutputDeclarationEntry entry && Equals(entry);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11StreamOutputDeclarationEntry other)
    {
        fixed (byte* ptrThis = semanticName.Buffer)
        {
            ReadOnlySpan<byte> spanThis = new(ptrThis, Buffer64.Length);
            ReadOnlySpan<byte> spanOther = new(other.semanticName.Buffer, Buffer64.Length);

            return stream == other.stream &&
               spanThis.SequenceEqual(spanOther) &&
               semanticIndex == other.semanticIndex &&
               startComponent == other.startComponent &&
               componentCount == other.componentCount &&
               outputSlot == other.outputSlot;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -600471073;
        hashCode = hashCode * -1521134295 + stream.GetHashCode();
        hashCode = hashCode * -1521134295 + semanticName.GetHashCode();
        hashCode = hashCode * -1521134295 + semanticIndex.GetHashCode();
        hashCode = hashCode * -1521134295 + startComponent.GetHashCode();
        hashCode = hashCode * -1521134295 + componentCount.GetHashCode();
        hashCode = hashCode * -1521134295 + outputSlot.GetHashCode();
        return hashCode;
    }
}
