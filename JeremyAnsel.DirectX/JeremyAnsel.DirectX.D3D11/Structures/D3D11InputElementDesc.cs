// <copyright file="D3D11InputElementDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A description of a single element for the input-assembler stage.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11InputElementDesc : IEquatable<D3D11InputElementDesc>
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
        size += sizeof(nint);
        size += sizeof(uint) * 4;
        size += sizeof(int) * 2;
        return size;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11InputElementDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11InputElementDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11InputElementDesc> objects)
    {
        nint namesOffset = buffer + NativeRequiredBaseSize() * objects.Length;

        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, namesOffset + index * Buffer64.Length);
            DXMarshal.Write(ref buffer, obj.semanticIndex);
            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, obj.inputSlot);
            DXMarshal.Write(ref buffer, obj.alignedByteOffset);
            DXMarshal.Write(ref buffer, (int)obj.inputSlotClass);
            DXMarshal.Write(ref buffer, obj.instanceDataStepRate);
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
    public static D3D11InputElementDesc NativeReadFrom(nint buffer)
    {
        D3D11InputElementDesc obj = default;

        nint ptr = DXMarshal.ReadIntPtr(ref buffer);
        int bytesCount = Math.Min(DXMarshal.GetNullTerminatedStringCountAnsi(ptr), Buffer64.Length - 1);
        Buffer.MemoryCopy((void*)ptr, obj.semanticName.Buffer, bytesCount, bytesCount);
        for (int i = bytesCount; i < Buffer64.Length; i++)
        {
            obj.semanticName.Buffer[i] = 0;
        }

        obj.semanticIndex = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.inputSlot = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.alignedByteOffset = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.inputSlotClass = (D3D11InputClassification)DXMarshal.ReadInt32(ref buffer);
        obj.instanceDataStepRate = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11InputElementDesc> objects)
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
    /// The HLSL semantic associated with this element in a shader input-signature.
    /// </summary>
    private Buffer64 semanticName;

    /// <summary>
    /// The semantic index for the element.
    /// </summary>
    private uint semanticIndex;

    /// <summary>
    /// The data type of the element data.
    /// </summary>
    private DxgiFormat format;

    /// <summary>
    /// An integer value that identifies the input-assembler.
    /// </summary>
    private uint inputSlot;

    /// <summary>
    /// Offset (in bytes) between each element. Optional.
    /// </summary>
    private uint alignedByteOffset;

    /// <summary>
    /// Identifies the input data class for a single input slot.
    /// </summary>
    private D3D11InputClassification inputSlotClass;

    /// <summary>
    /// The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.
    /// </summary>
    private uint instanceDataStepRate;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11InputElementDesc"/> struct.
    /// </summary>
    /// <param name="semanticName">The HLSL semantic associated with this element in a shader input-signature.</param>
    /// <param name="semanticIndex">The semantic index for the element.</param>
    /// <param name="format">The data type of the element data.</param>
    /// <param name="inputSlot">An integer value that identifies the input-assembler.</param>
    /// <param name="alignedByteOffset">Offset (in bytes) between each element. Optional.</param>
    /// <param name="inputSlotClass">Identifies the input data class for a single input slot.</param>
    /// <param name="instanceDataStepRate">The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11InputElementDesc(
        string semanticName,
        uint semanticIndex,
        DxgiFormat format,
        uint inputSlot,
        uint alignedByteOffset,
        D3D11InputClassification inputSlotClass,
        uint instanceDataStepRate)
    {
        SetSemanticName(semanticName);
        this.semanticIndex = semanticIndex;
        this.format = format;
        this.inputSlot = inputSlot;
        this.alignedByteOffset = alignedByteOffset;
        this.inputSlotClass = inputSlotClass;
        this.instanceDataStepRate = instanceDataStepRate;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11InputElementDesc"/> struct.
    /// </summary>
    /// <param name="semanticName">The HLSL semantic associated with this element in a shader input-signature.</param>
    /// <param name="semanticIndex">The semantic index for the element.</param>
    /// <param name="format">The data type of the element data.</param>
    /// <param name="inputSlot">An integer value that identifies the input-assembler.</param>
    /// <param name="alignedByteOffset">Offset (in bytes) between each element. Optional.</param>
    /// <param name="inputSlotClass">Identifies the input data class for a single input slot.</param>
    /// <param name="instanceDataStepRate">The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11InputElementDesc(
        ReadOnlySpan<char> semanticName,
        uint semanticIndex,
        DxgiFormat format,
        uint inputSlot,
        uint alignedByteOffset,
        D3D11InputClassification inputSlotClass,
        uint instanceDataStepRate)
    {
        SetSemanticName(semanticName);
        this.semanticIndex = semanticIndex;
        this.format = format;
        this.inputSlot = inputSlot;
        this.alignedByteOffset = alignedByteOffset;
        this.inputSlotClass = inputSlotClass;
        this.instanceDataStepRate = instanceDataStepRate;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11InputElementDesc"/> struct.
    /// </summary>
    /// <param name="semanticName">The HLSL semantic associated with this element in a shader input-signature.</param>
    /// <param name="semanticIndex">The semantic index for the element.</param>
    /// <param name="format">The data type of the element data.</param>
    /// <param name="inputSlot">An integer value that identifies the input-assembler.</param>
    /// <param name="alignedByteOffset">Offset (in bytes) between each element. Optional.</param>
    /// <param name="inputSlotClass">Identifies the input data class for a single input slot.</param>
    /// <param name="instanceDataStepRate">The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
    public D3D11InputElementDesc(
        ReadOnlySpan<byte> semanticName,
        uint semanticIndex,
        DxgiFormat format,
        uint inputSlot,
        uint alignedByteOffset,
        D3D11InputClassification inputSlotClass,
        uint instanceDataStepRate)
    {
        SetSemanticName(semanticName);
        this.semanticIndex = semanticIndex;
        this.format = format;
        this.inputSlot = inputSlot;
        this.alignedByteOffset = alignedByteOffset;
        this.inputSlotClass = inputSlotClass;
        this.instanceDataStepRate = instanceDataStepRate;
    }

    /// <summary>
    /// Gets or sets the HLSL semantic associated with this element in a shader input-signature.
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
    /// Gets the HLSL semantic associated with this element in a shader input-signature.
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
    /// Gets the HLSL semantic associated with this element in a shader input-signature.
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
    /// Gets the HLSL semantic associated with this element in a shader input-signature.
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
    /// Sets the HLSL semantic associated with this element in a shader input-signature.
    /// </summary>
    /// <param name="value"></param>
    public void SetSemanticName(string value)
    {
        SetSemanticName(value.AsSpan());
    }

    /// <summary>
    /// Sets the HLSL semantic associated with this element in a shader input-signature.
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
    /// Sets the HLSL semantic associated with this element in a shader input-signature.
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
    /// Gets or sets the semantic index for the element.
    /// </summary>
    public uint SemanticIndex
    {
        get { return this.semanticIndex; }
        set { this.semanticIndex = value; }
    }

    /// <summary>
    /// Gets or sets the data type of the element data.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets an integer value that identifies the input-assembler.
    /// </summary>
    public uint InputSlot
    {
        get { return this.inputSlot; }
        set { this.inputSlot = value; }
    }

    /// <summary>
    /// Gets or sets the offset (in bytes) between each element. Optional.
    /// </summary>
    public uint AlignedByteOffset
    {
        get { return this.alignedByteOffset; }
        set { this.alignedByteOffset = value; }
    }

    /// <summary>
    /// Gets or sets the input data class for a single input slot.
    /// </summary>
    public D3D11InputClassification InputSlotClass
    {
        get { return this.inputSlotClass; }
        set { this.inputSlotClass = value; }
    }

    /// <summary>
    /// Gets or sets the number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.
    /// </summary>
    public uint InstanceDataStepRate
    {
        get { return this.instanceDataStepRate; }
        set { this.instanceDataStepRate = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11InputElementDesc left, D3D11InputElementDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11InputElementDesc left, D3D11InputElementDesc right)
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
        return obj is D3D11InputElementDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11InputElementDesc other)
    {
        fixed (byte* ptrThis = semanticName.Buffer)
        {
            ReadOnlySpan<byte> spanThis = new(ptrThis, Buffer64.Length);
            ReadOnlySpan<byte> spanOther = new(other.semanticName.Buffer, Buffer64.Length);

            return spanThis.SequenceEqual(spanOther) &&
               semanticIndex == other.semanticIndex &&
               format == other.format &&
               inputSlot == other.inputSlot &&
               alignedByteOffset == other.alignedByteOffset &&
               inputSlotClass == other.inputSlotClass &&
               instanceDataStepRate == other.instanceDataStepRate;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 804697807;
        hashCode = hashCode * -1521134295 + semanticName.GetHashCode();
        hashCode = hashCode * -1521134295 + semanticIndex.GetHashCode();
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + inputSlot.GetHashCode();
        hashCode = hashCode * -1521134295 + alignedByteOffset.GetHashCode();
        hashCode = hashCode * -1521134295 + inputSlotClass.GetHashCode();
        hashCode = hashCode * -1521134295 + instanceDataStepRate.GetHashCode();
        return hashCode;
    }
}
