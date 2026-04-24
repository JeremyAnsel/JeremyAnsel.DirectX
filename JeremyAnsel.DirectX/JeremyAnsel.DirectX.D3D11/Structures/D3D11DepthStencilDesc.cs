// <copyright file="D3D11DepthStencilDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes depth-stencil state.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11DepthStencilDesc : IEquatable<D3D11DepthStencilDesc>
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
        size += sizeof(int) * 2;
        size += sizeof(byte) * 2;
        size += 2; // padding
        size += D3D11DepthStencilOperationDesc.NativeRequiredSize(2);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11DepthStencilDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11DepthStencilDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11DepthStencilDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isDepthEnabled);
            DXMarshal.Write(ref buffer, (int)obj.depthWriteMask);
            DXMarshal.Write(ref buffer, (int)obj.depthFunction);
            DXMarshal.Write(ref buffer, obj.isStencilEnabled);
            DXMarshal.Write(ref buffer, obj.stencilReadMask);
            DXMarshal.Write(ref buffer, obj.stencilWriteMask);
            DXMarshal.Write(ref buffer, (byte)0); // padding
            DXMarshal.Write(ref buffer, (byte)0); // padding
            D3D11DepthStencilOperationDesc.NativeWriteTo(buffer, obj.frontFace);
            buffer += D3D11DepthStencilOperationDesc.NativeRequiredSize();
            D3D11DepthStencilOperationDesc.NativeWriteTo(buffer, obj.backFace);
            buffer += D3D11DepthStencilOperationDesc.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11DepthStencilDesc NativeReadFrom(nint buffer)
    {
        D3D11DepthStencilDesc obj;
        obj.isDepthEnabled = DXMarshal.ReadBool(ref buffer);
        obj.depthWriteMask = (D3D11DepthWriteMask)DXMarshal.ReadInt32(ref buffer);
        obj.depthFunction = (D3D11ComparisonFunction)DXMarshal.ReadInt32(ref buffer);
        obj.isStencilEnabled = DXMarshal.ReadBool(ref buffer);
        obj.stencilReadMask = DXMarshal.ReadByte(ref buffer);
        obj.stencilWriteMask = DXMarshal.ReadByte(ref buffer);
        buffer += 2;  // padding
        obj.frontFace = D3D11DepthStencilOperationDesc.NativeReadFrom(buffer);
        buffer += D3D11DepthStencilOperationDesc.NativeRequiredSize();
        obj.backFace = D3D11DepthStencilOperationDesc.NativeReadFrom(buffer);
        buffer += D3D11DepthStencilOperationDesc.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11DepthStencilDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Enable depth testing.
    /// </summary>
    private bool isDepthEnabled;

    /// <summary>
    /// Identify a portion of the depth-stencil buffer that can be modified by depth data.
    /// </summary>
    private D3D11DepthWriteMask depthWriteMask;

    /// <summary>
    /// A function that compares depth data against existing depth data.
    /// </summary>
    private D3D11ComparisonFunction depthFunction;

    /// <summary>
    /// Enable stencil testing.
    /// </summary>
    private bool isStencilEnabled;

    /// <summary>
    /// Identify a portion of the depth-stencil buffer for reading stencil data.
    /// </summary>
    private byte stencilReadMask;

    /// <summary>
    /// Identify a portion of the depth-stencil buffer for writing stencil data.
    /// </summary>
    private byte stencilWriteMask;

    /// <summary>
    /// Identify how to use the results of the depth test and the stencil test for pixels whose surface normal is facing towards the camera.
    /// </summary>
    private D3D11DepthStencilOperationDesc frontFace;

    /// <summary>
    /// Identify how to use the results of the depth test and the stencil test for pixels whose surface normal is facing away from the camera.
    /// </summary>
    private D3D11DepthStencilOperationDesc backFace;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilDesc"/> struct.
    /// </summary>
    /// <param name="isDepthEnabled">Enable depth testing.</param>
    /// <param name="depthWriteMask">Identify a portion of the depth-stencil buffer that can be modified by depth data.</param>
    /// <param name="depthFunction">A function that compares depth data against existing depth data.</param>
    /// <param name="isStencilEnabled">Enable stencil testing.</param>
    /// <param name="stencilReadMask">Identify a portion of the depth-stencil buffer for reading stencil data.</param>
    /// <param name="stencilWriteMask">Identify a portion of the depth-stencil buffer for writing stencil data.</param>
    /// <param name="frontStencilFailOperation">The stencil operation to perform when stencil testing fails for pixels whose surface normal is facing towards the camera.</param>
    /// <param name="frontStencilDepthFailOperation">The stencil operation to perform when stencil testing passes and depth testing fails for pixels whose surface normal is facing towards the camera.</param>
    /// <param name="frontStencilPassOperation">The stencil operation to perform when stencil testing and depth testing both pass for pixels whose surface normal is facing towards the camera.</param>
    /// <param name="frontStencilFunction">A function that compares stencil data against existing stencil data for pixels whose surface normal is facing towards the camera.</param>
    /// <param name="backStencilFailOperation">The stencil operation to perform when stencil testing fails for pixels whose surface normal is facing away from the camera.</param>
    /// <param name="backStencilDepthFailOperation">The stencil operation to perform when stencil testing passes and depth testing fails for pixels whose surface normal is facing away from the camera.</param>
    /// <param name="backStencilPassOperation">The stencil operation to perform when stencil testing and depth testing both pass for pixels whose surface normal is facing away from the camera.</param>
    /// <param name="backStencilFunction">A function that compares stencil data against existing stencil data for pixels whose surface normal is facing away from the camera.</param>
    public D3D11DepthStencilDesc(
        bool isDepthEnabled,
        D3D11DepthWriteMask depthWriteMask,
        D3D11ComparisonFunction depthFunction,
        bool isStencilEnabled,
        byte stencilReadMask,
        byte stencilWriteMask,
        D3D11StencilOperation frontStencilFailOperation,
        D3D11StencilOperation frontStencilDepthFailOperation,
        D3D11StencilOperation frontStencilPassOperation,
        D3D11ComparisonFunction frontStencilFunction,
        D3D11StencilOperation backStencilFailOperation,
        D3D11StencilOperation backStencilDepthFailOperation,
        D3D11StencilOperation backStencilPassOperation,
        D3D11ComparisonFunction backStencilFunction)
    {
        this.isDepthEnabled = isDepthEnabled;
        this.depthWriteMask = depthWriteMask;
        this.depthFunction = depthFunction;
        this.isStencilEnabled = isStencilEnabled;
        this.stencilReadMask = stencilReadMask;
        this.stencilWriteMask = stencilWriteMask;

        this.frontFace = new D3D11DepthStencilOperationDesc(
            frontStencilFailOperation,
            frontStencilDepthFailOperation,
            frontStencilPassOperation,
            frontStencilFunction);

        this.backFace = new D3D11DepthStencilOperationDesc(
            backStencilFailOperation,
            backStencilDepthFailOperation,
            backStencilPassOperation,
            backStencilFunction);
    }

    /// <summary>
    /// Gets default depth-stencil-state values
    /// </summary>
    public static D3D11DepthStencilDesc Default
    {
        get
        {
            return new D3D11DepthStencilDesc(
                true,
                D3D11DepthWriteMask.All,
                D3D11ComparisonFunction.Less,
                false,
                0xff,
                0xff,
                D3D11StencilOperation.Keep,
                D3D11StencilOperation.Keep,
                D3D11StencilOperation.Keep,
                D3D11ComparisonFunction.Always,
                D3D11StencilOperation.Keep,
                D3D11StencilOperation.Keep,
                D3D11StencilOperation.Keep,
                D3D11ComparisonFunction.Always);
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether depth testing is enabled.
    /// </summary>
    public bool IsDepthEnabled
    {
        get { return this.isDepthEnabled; }
        set { this.isDepthEnabled = value; }
    }

    /// <summary>
    /// Gets or sets a portion of the depth-stencil buffer that can be modified by depth data.
    /// </summary>
    public D3D11DepthWriteMask DepthWriteMask
    {
        get { return this.depthWriteMask; }
        set { this.depthWriteMask = value; }
    }

    /// <summary>
    /// Gets or sets a function that compares depth data against existing depth data.
    /// </summary>
    public D3D11ComparisonFunction DepthFunction
    {
        get { return this.depthFunction; }
        set { this.depthFunction = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether stencil testing is enabled.
    /// </summary>
    public bool IsStencilEnabled
    {
        get { return this.isStencilEnabled; }
        set { this.isStencilEnabled = value; }
    }

    /// <summary>
    /// Gets or sets a portion of the depth-stencil buffer for reading stencil data.
    /// </summary>
    public byte StencilReadMask
    {
        get { return this.stencilReadMask; }
        set { this.stencilReadMask = value; }
    }

    /// <summary>
    /// Gets or sets a portion of the depth-stencil buffer for writing stencil data.
    /// </summary>
    public byte StencilWriteMask
    {
        get { return this.stencilWriteMask; }
        set { this.stencilWriteMask = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating how to use the results of the depth test and the stencil test for pixels whose surface normal is facing towards the camera.
    /// </summary>
    public D3D11DepthStencilOperationDesc FrontFace
    {
        get { return this.frontFace; }
        set { this.frontFace = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating how to use the results of the depth test and the stencil test for pixels whose surface normal is facing away from the camera.
    /// </summary>
    public D3D11DepthStencilOperationDesc BackFace
    {
        get { return this.backFace; }
        set { this.backFace = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11DepthStencilDesc left, D3D11DepthStencilDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11DepthStencilDesc left, D3D11DepthStencilDesc right)
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
        return obj is D3D11DepthStencilDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11DepthStencilDesc other)
    {
        return isDepthEnabled == other.isDepthEnabled &&
               depthWriteMask == other.depthWriteMask &&
               depthFunction == other.depthFunction &&
               isStencilEnabled == other.isStencilEnabled &&
               stencilReadMask == other.stencilReadMask &&
               stencilWriteMask == other.stencilWriteMask &&
               frontFace.Equals(other.frontFace) &&
               backFace.Equals(other.backFace);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -2028333333;
        hashCode = hashCode * -1521134295 + isDepthEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + depthWriteMask.GetHashCode();
        hashCode = hashCode * -1521134295 + depthFunction.GetHashCode();
        hashCode = hashCode * -1521134295 + isStencilEnabled.GetHashCode();
        hashCode = hashCode * -1521134295 + stencilReadMask.GetHashCode();
        hashCode = hashCode * -1521134295 + stencilWriteMask.GetHashCode();
        hashCode = hashCode * -1521134295 + frontFace.GetHashCode();
        hashCode = hashCode * -1521134295 + backFace.GetHashCode();
        return hashCode;
    }
}
