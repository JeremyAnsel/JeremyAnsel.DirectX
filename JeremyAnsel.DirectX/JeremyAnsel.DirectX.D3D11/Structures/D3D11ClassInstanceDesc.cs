// <copyright file="D3D11ClassInstanceDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes an HLSL class instance.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11ClassInstanceDesc : IEquatable<D3D11ClassInstanceDesc>
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
        size += sizeof(uint) * 7;
        size += sizeof(int);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11ClassInstanceDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11ClassInstanceDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11ClassInstanceDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.instanceId);
            DXMarshal.Write(ref buffer, obj.instanceIndex);
            DXMarshal.Write(ref buffer, obj.typeId);
            DXMarshal.Write(ref buffer, obj.constantBuffer);
            DXMarshal.Write(ref buffer, obj.baseConstantBufferOffset);
            DXMarshal.Write(ref buffer, obj.baseTexture);
            DXMarshal.Write(ref buffer, obj.baseSampler);
            DXMarshal.Write(ref buffer, obj.isCreated);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11ClassInstanceDesc NativeReadFrom(nint buffer)
    {
        D3D11ClassInstanceDesc obj;
        obj.instanceId = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.instanceIndex = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.typeId = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.constantBuffer = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.baseConstantBufferOffset = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.baseTexture = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.baseSampler = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.isCreated = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11ClassInstanceDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The instance ID of an HLSL class; the default value is 0.
    /// </summary>
    private uint instanceId;

    /// <summary>
    /// The instance index of an HLSL class; the default value is 0.
    /// </summary>
    private uint instanceIndex;

    /// <summary>
    /// The type ID of an HLSL class; the default value is 0.
    /// </summary>
    private uint typeId;

    /// <summary>
    /// Describes the constant buffer associated with an HLSL class; the default value is 0.
    /// </summary>
    private uint constantBuffer;

    /// <summary>
    /// The base constant buffer offset associated with an HLSL class; the default value is 0.
    /// </summary>
    private uint baseConstantBufferOffset;

    /// <summary>
    /// The base texture associated with an HLSL class; the default value is 127.
    /// </summary>
    private uint baseTexture;

    /// <summary>
    /// The base sampler associated with an HLSL class; the default value is 15.
    /// </summary>
    private uint baseSampler;

    /// <summary>
    /// Indicates whether the class was created; the default value is false.
    /// </summary>
    private bool isCreated;

    /// <summary>
    /// Gets the instance ID of an HLSL class; the default value is 0.
    /// </summary>
    public uint InstanceId
    {
        get { return this.instanceId; }
    }

    /// <summary>
    /// Gets the instance index of an HLSL class; the default value is 0.
    /// </summary>
    public uint InstanceIndex
    {
        get { return this.instanceIndex; }
    }

    /// <summary>
    /// Gets the type ID of an HLSL class; the default value is 0.
    /// </summary>
    public uint TypeId
    {
        get { return this.typeId; }
    }

    /// <summary>
    /// Gets a value indicating the constant buffer associated with an HLSL class; the default value is 0.
    /// </summary>
    public uint ConstanceBuffer
    {
        get { return this.constantBuffer; }
    }

    /// <summary>
    /// Gets the base constant buffer offset associated with an HLSL class; the default value is 0.
    /// </summary>
    public uint BaseConstantBufferOffset
    {
        get { return this.baseConstantBufferOffset; }
    }

    /// <summary>
    /// Gets the base texture associated with an HLSL class; the default value is 127.
    /// </summary>
    public uint BaseTexture
    {
        get { return this.baseTexture; }
    }

    /// <summary>
    /// Gets the base sampler associated with an HLSL class; the default value is 15.
    /// </summary>
    public uint BaseSampler
    {
        get { return this.baseSampler; }
    }

    /// <summary>
    /// Gets a value indicating whether the class was created; the default value is false.
    /// </summary>
    public bool IsCreated
    {
        get { return this.isCreated; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11ClassInstanceDesc left, D3D11ClassInstanceDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11ClassInstanceDesc left, D3D11ClassInstanceDesc right)
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
        return obj is D3D11ClassInstanceDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11ClassInstanceDesc other)
    {
        return instanceId == other.instanceId &&
               instanceIndex == other.instanceIndex &&
               typeId == other.typeId &&
               constantBuffer == other.constantBuffer &&
               baseConstantBufferOffset == other.baseConstantBufferOffset &&
               baseTexture == other.baseTexture &&
               baseSampler == other.baseSampler &&
               isCreated == other.isCreated;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -32421617;
        hashCode = hashCode * -1521134295 + instanceId.GetHashCode();
        hashCode = hashCode * -1521134295 + instanceIndex.GetHashCode();
        hashCode = hashCode * -1521134295 + typeId.GetHashCode();
        hashCode = hashCode * -1521134295 + constantBuffer.GetHashCode();
        hashCode = hashCode * -1521134295 + baseConstantBufferOffset.GetHashCode();
        hashCode = hashCode * -1521134295 + baseTexture.GetHashCode();
        hashCode = hashCode * -1521134295 + baseSampler.GetHashCode();
        hashCode = hashCode * -1521134295 + isCreated.GetHashCode();
        return hashCode;
    }
}
