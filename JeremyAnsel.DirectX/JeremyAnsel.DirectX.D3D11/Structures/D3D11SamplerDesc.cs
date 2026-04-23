// <copyright file="D3D11SamplerDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes a sampler state.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11SamplerDesc : IEquatable<D3D11SamplerDesc>
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
        size += sizeof(int) * 5;
        size += sizeof(float) * 7;
        size += sizeof(uint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11SamplerDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11SamplerDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11SamplerDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.filter);
            DXMarshal.Write(ref buffer, (int)obj.addressU);
            DXMarshal.Write(ref buffer, (int)obj.addressV);
            DXMarshal.Write(ref buffer, (int)obj.addressW);
            DXMarshal.Write(ref buffer, obj.mipLodBias);
            DXMarshal.Write(ref buffer, obj.maxAnisotropy);
            DXMarshal.Write(ref buffer, (int)obj.comparisonFunction);
            DXMarshal.Write(ref buffer, obj.borderColorR);
            DXMarshal.Write(ref buffer, obj.borderColorG);
            DXMarshal.Write(ref buffer, obj.borderColorB);
            DXMarshal.Write(ref buffer, obj.borderColorA);
            DXMarshal.Write(ref buffer, obj.minLod);
            DXMarshal.Write(ref buffer, obj.maxLod);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11SamplerDesc NativeReadFrom(nint buffer)
    {
        D3D11SamplerDesc obj;
        obj.filter = (D3D11Filter)DXMarshal.ReadInt32(ref buffer);
        obj.addressU = (D3D11TextureAddressMode)DXMarshal.ReadInt32(ref buffer);
        obj.addressV = (D3D11TextureAddressMode)DXMarshal.ReadInt32(ref buffer);
        obj.addressW = (D3D11TextureAddressMode)DXMarshal.ReadInt32(ref buffer);
        obj.mipLodBias = DXMarshal.ReadSingle(ref buffer);
        obj.maxAnisotropy = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.comparisonFunction = (D3D11ComparisonFunction)DXMarshal.ReadInt32(ref buffer);
        obj.borderColorR = DXMarshal.ReadSingle(ref buffer);
        obj.borderColorG = DXMarshal.ReadSingle(ref buffer);
        obj.borderColorB = DXMarshal.ReadSingle(ref buffer);
        obj.borderColorA = DXMarshal.ReadSingle(ref buffer);
        obj.minLod = DXMarshal.ReadSingle(ref buffer);
        obj.maxLod = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11SamplerDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The filtering method to use when sampling a texture.
    /// </summary>
    private D3D11Filter filter;

    /// <summary>
    /// The method to use for resolving a u texture coordinate that is outside the 0 to 1 range.
    /// </summary>
    private D3D11TextureAddressMode addressU;

    /// <summary>
    /// The method to use for resolving a v texture coordinate that is outside the 0 to 1 range.
    /// </summary>
    private D3D11TextureAddressMode addressV;

    /// <summary>
    /// The method to use for resolving a w texture coordinate that is outside the 0 to 1 range.
    /// </summary>
    private D3D11TextureAddressMode addressW;

    /// <summary>
    /// The offset from the calculated mipmap level.
    /// </summary>
    private float mipLodBias;

    /// <summary>
    /// The clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.
    /// </summary>
    private uint maxAnisotropy;

    /// <summary>
    /// A function that compares sampled data against existing sampled data.
    /// </summary>
    private D3D11ComparisonFunction comparisonFunction;

    /// <summary>
    /// The border color red component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    private float borderColorR;

    /// <summary>
    /// The border color green component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    private float borderColorG;

    /// <summary>
    /// The border color blue component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    private float borderColorB;

    /// <summary>
    /// The border color alpha component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    private float borderColorA;

    /// <summary>
    /// The lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
    /// </summary>
    private float minLod;

    /// <summary>
    /// The upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
    /// </summary>
    private float maxLod;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SamplerDesc"/> struct.
    /// </summary>
    /// <param name="filter">The filtering method to use when sampling a texture.</param>
    /// <param name="addressU">The method to use for resolving a u texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="addressV">The method to use for resolving a v texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="addressW">The method to use for resolving a w texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="mipLodBias">The offset from the calculated mipmap level.</param>
    /// <param name="maxAnisotropy">The clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.</param>
    /// <param name="comparisonFunction">A function that compares sampled data against existing sampled data.</param>
    /// <param name="borderColor">The border color to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
    /// <param name="minLod">The lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
    /// <param name="maxLod">The upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
    public D3D11SamplerDesc(
        D3D11Filter filter,
        D3D11TextureAddressMode addressU,
        D3D11TextureAddressMode addressV,
        D3D11TextureAddressMode addressW,
        float mipLodBias,
        uint maxAnisotropy,
        D3D11ComparisonFunction comparisonFunction,
        float[]? borderColor,
        float minLod,
        float maxLod)
    {
        if (borderColor is not null && borderColor.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(borderColor));
        }

        this.filter = filter;
        this.addressU = addressU;
        this.addressV = addressV;
        this.addressW = addressW;
        this.mipLodBias = mipLodBias;
        this.maxAnisotropy = maxAnisotropy;
        this.comparisonFunction = comparisonFunction;

        if (borderColor is null)
        {
            this.borderColorR = 1.0f;
            this.borderColorB = 1.0f;
            this.borderColorB = 1.0f;
            this.borderColorA = 1.0f;
        }
        else
        {
            this.borderColorR = borderColor[0];
            this.borderColorG = borderColor[1];
            this.borderColorB = borderColor[2];
            this.borderColorA = borderColor[3];
        }

        this.minLod = minLod;
        this.maxLod = maxLod;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SamplerDesc"/> struct.
    /// </summary>
    /// <param name="filter">The filtering method to use when sampling a texture.</param>
    /// <param name="addressU">The method to use for resolving a u texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="addressV">The method to use for resolving a v texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="addressW">The method to use for resolving a w texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="mipLodBias">The offset from the calculated mipmap level.</param>
    /// <param name="maxAnisotropy">The clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.</param>
    /// <param name="comparisonFunction">A function that compares sampled data against existing sampled data.</param>
    /// <param name="borderColor">The border color to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
    /// <param name="minLod">The lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
    /// <param name="maxLod">The upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
    public D3D11SamplerDesc(
        D3D11Filter filter,
        D3D11TextureAddressMode addressU,
        D3D11TextureAddressMode addressV,
        D3D11TextureAddressMode addressW,
        float mipLodBias,
        uint maxAnisotropy,
        D3D11ComparisonFunction comparisonFunction,
        ReadOnlySpan<float> borderColor,
        float minLod,
        float maxLod)
    {
        if (borderColor.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(borderColor));
        }

        this.filter = filter;
        this.addressU = addressU;
        this.addressV = addressV;
        this.addressW = addressW;
        this.mipLodBias = mipLodBias;
        this.maxAnisotropy = maxAnisotropy;
        this.comparisonFunction = comparisonFunction;
        this.borderColorR = borderColor[0];
        this.borderColorG = borderColor[1];
        this.borderColorB = borderColor[2];
        this.borderColorA = borderColor[3];
        this.minLod = minLod;
        this.maxLod = maxLod;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SamplerDesc"/> struct.
    /// </summary>
    /// <param name="filter">The filtering method to use when sampling a texture.</param>
    /// <param name="addressU">The method to use for resolving a u texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="addressV">The method to use for resolving a v texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="addressW">The method to use for resolving a w texture coordinate that is outside the 0 to 1 range.</param>
    /// <param name="mipLodBias">The offset from the calculated mipmap level.</param>
    /// <param name="maxAnisotropy">The clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.</param>
    /// <param name="comparisonFunction">A function that compares sampled data against existing sampled data.</param>
    /// <param name="borderColorR">The border color red to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
    /// <param name="borderColorG">The border color green to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
    /// <param name="borderColorB">The border color blue to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
    /// <param name="borderColorA">The border color alpha to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.</param>
    /// <param name="minLod">The lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
    /// <param name="maxLod">The upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.</param>
    public D3D11SamplerDesc(
        D3D11Filter filter,
        D3D11TextureAddressMode addressU,
        D3D11TextureAddressMode addressV,
        D3D11TextureAddressMode addressW,
        float mipLodBias,
        uint maxAnisotropy,
        D3D11ComparisonFunction comparisonFunction,
        float borderColorR,
        float borderColorG,
        float borderColorB,
        float borderColorA,
        float minLod,
        float maxLod)
    {
        this.filter = filter;
        this.addressU = addressU;
        this.addressV = addressV;
        this.addressW = addressW;
        this.mipLodBias = mipLodBias;
        this.maxAnisotropy = maxAnisotropy;
        this.comparisonFunction = comparisonFunction;
        this.borderColorR = borderColorR;
        this.borderColorG = borderColorG;
        this.borderColorB = borderColorB;
        this.borderColorA = borderColorA;
        this.minLod = minLod;
        this.maxLod = maxLod;
    }

    /// <summary>
    /// Gets default sampler-state values.
    /// </summary>
    public static D3D11SamplerDesc Default
    {
        get
        {
            return new D3D11SamplerDesc(
                D3D11Filter.MinMagMipLinear,
                D3D11TextureAddressMode.Clamp,
                D3D11TextureAddressMode.Clamp,
                D3D11TextureAddressMode.Clamp,
                0.0f,
                1,
                D3D11ComparisonFunction.Never,
                1.0f, 1.0f, 1.0f, 1.0f,
                float.MinValue,
                float.MaxValue);
        }
    }

    /// <summary>
    /// Gets or sets the filtering method to use when sampling a texture.
    /// </summary>
    public D3D11Filter Filter
    {
        get { return this.filter; }
        set { this.filter = value; }
    }

    /// <summary>
    /// Gets or sets the method to use for resolving a u texture coordinate that is outside the 0 to 1 range.
    /// </summary>
    public D3D11TextureAddressMode AddressU
    {
        get { return this.addressU; }
        set { this.addressU = value; }
    }

    /// <summary>
    /// Gets or sets the method to use for resolving a v texture coordinate that is outside the 0 to 1 range.
    /// </summary>
    public D3D11TextureAddressMode AddressV
    {
        get { return this.addressV; }
        set { this.addressV = value; }
    }

    /// <summary>
    /// Gets or sets the method to use for resolving a w texture coordinate that is outside the 0 to 1 range.
    /// </summary>
    public D3D11TextureAddressMode AddressW
    {
        get { return this.addressW; }
        set { this.addressW = value; }
    }

    /// <summary>
    /// Gets or sets the offset from the calculated mipmap level.
    /// </summary>
    public float MipLodBias
    {
        get { return this.mipLodBias; }
        set { this.mipLodBias = value; }
    }

    /// <summary>
    /// Gets or sets the clamping value used if <see cref="D3D11Filter.Anisotropic"/> or <see cref="D3D11Filter.ComparisonAnisotropic"/> is specified in <c>Filter</c>.
    /// </summary>
    public uint MaxAnisotropy
    {
        get { return this.maxAnisotropy; }
        set { this.maxAnisotropy = value; }
    }

    /// <summary>
    /// Gets or sets a function that compares sampled data against existing sampled data.
    /// </summary>
    public D3D11ComparisonFunction ComparisonFunction
    {
        get { return this.comparisonFunction; }
        set { this.comparisonFunction = value; }
    }

    /// <summary>
    /// Gets or sets the border color red component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    public float BorderColorR
    {
        get { return this.borderColorR; }
        set { this.borderColorR = value; }
    }

    /// <summary>
    /// Gets or sets the border color green component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    public float BorderColorG
    {
        get { return this.borderColorG; }
        set { this.borderColorG = value; }
    }

    /// <summary>
    /// Gets or sets the border color blue component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    public float BorderColorB
    {
        get { return this.borderColorB; }
        set { this.borderColorB = value; }
    }

    /// <summary>
    /// Gets or sets the border color alpha component to use if <see cref="D3D11TextureAddressMode.Border"/> is specified for <c>AddressU</c>, <c>AddressV</c>, or <c>AddressW</c>.
    /// </summary>
    public float BorderColorA
    {
        get { return this.borderColorA; }
        set { this.borderColorA = value; }
    }

    /// <summary>
    /// Gets or sets the lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
    /// </summary>
    public float MinLod
    {
        get { return this.minLod; }
        set { this.minLod = value; }
    }

    /// <summary>
    /// Gets or sets the upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher than that is less detailed.
    /// </summary>
    public float MaxLod
    {
        get { return this.maxLod; }
        set { this.maxLod = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11SamplerDesc left, D3D11SamplerDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11SamplerDesc left, D3D11SamplerDesc right)
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
        return obj is D3D11SamplerDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11SamplerDesc other)
    {
        return filter == other.filter &&
               addressU == other.addressU &&
               addressV == other.addressV &&
               addressW == other.addressW &&
               mipLodBias == other.mipLodBias &&
               maxAnisotropy == other.maxAnisotropy &&
               comparisonFunction == other.comparisonFunction &&
               borderColorR == other.borderColorR &&
               borderColorG == other.borderColorG &&
               borderColorB == other.borderColorB &&
               borderColorA == other.borderColorA &&
               minLod == other.minLod &&
               maxLod == other.maxLod;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1760343536;
        hashCode = hashCode * -1521134295 + filter.GetHashCode();
        hashCode = hashCode * -1521134295 + addressU.GetHashCode();
        hashCode = hashCode * -1521134295 + addressV.GetHashCode();
        hashCode = hashCode * -1521134295 + addressW.GetHashCode();
        hashCode = hashCode * -1521134295 + mipLodBias.GetHashCode();
        hashCode = hashCode * -1521134295 + maxAnisotropy.GetHashCode();
        hashCode = hashCode * -1521134295 + comparisonFunction.GetHashCode();
        hashCode = hashCode * -1521134295 + borderColorR.GetHashCode();
        hashCode = hashCode * -1521134295 + borderColorG.GetHashCode();
        hashCode = hashCode * -1521134295 + borderColorB.GetHashCode();
        hashCode = hashCode * -1521134295 + borderColorA.GetHashCode();
        hashCode = hashCode * -1521134295 + minLod.GetHashCode();
        hashCode = hashCode * -1521134295 + maxLod.GetHashCode();
        return hashCode;
    }
}
