// <copyright file="D3D11FeatureDataD3D11Options.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Describes Direct3D 11.1 feature options in the current graphics driver.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11FeatureDataD3D11Options : IEquatable<D3D11FeatureDataD3D11Options>
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
        size += sizeof(int) * 14;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11FeatureDataD3D11Options obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11FeatureDataD3D11Options>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11FeatureDataD3D11Options> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.isOutputMergerLogicOperationsSupported);
            DXMarshal.Write(ref buffer, obj.isUavOnlyRenderingForcedSampleCountSupported);
            DXMarshal.Write(ref buffer, obj.isDiscardApisSeenByDriverSupported);
            DXMarshal.Write(ref buffer, obj.isOptionsForUpdateAndCopySeenByDriverSupported);
            DXMarshal.Write(ref buffer, obj.isClearViewSupported);
            DXMarshal.Write(ref buffer, obj.isCopyWithOverlapSupported);
            DXMarshal.Write(ref buffer, obj.isConstantBufferPartialUpdateSupported);
            DXMarshal.Write(ref buffer, obj.isConstantBufferOffsettingSupported);
            DXMarshal.Write(ref buffer, obj.isMapNoOverwriteOnDynamicConstantBufferSupported);
            DXMarshal.Write(ref buffer, obj.isMapNoOverwriteOnDynamicBufferSrvSupported);
            DXMarshal.Write(ref buffer, obj.isMultisampleRtvWithForcedSampleCountOneSupported);
            DXMarshal.Write(ref buffer, obj.isSad4ShaderInstructionsSupported);
            DXMarshal.Write(ref buffer, obj.isExtendedDoublesShaderInstructionsSupported);
            DXMarshal.Write(ref buffer, obj.isExtendedResourceSharingSupported);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11FeatureDataD3D11Options NativeReadFrom(nint buffer)
    {
        D3D11FeatureDataD3D11Options obj;
        obj.isOutputMergerLogicOperationsSupported = DXMarshal.ReadBool(ref buffer);
        obj.isUavOnlyRenderingForcedSampleCountSupported = DXMarshal.ReadBool(ref buffer);
        obj.isDiscardApisSeenByDriverSupported = DXMarshal.ReadBool(ref buffer);
        obj.isOptionsForUpdateAndCopySeenByDriverSupported = DXMarshal.ReadBool(ref buffer);
        obj.isClearViewSupported = DXMarshal.ReadBool(ref buffer);
        obj.isCopyWithOverlapSupported = DXMarshal.ReadBool(ref buffer);
        obj.isConstantBufferPartialUpdateSupported = DXMarshal.ReadBool(ref buffer);
        obj.isConstantBufferOffsettingSupported = DXMarshal.ReadBool(ref buffer);
        obj.isMapNoOverwriteOnDynamicConstantBufferSupported = DXMarshal.ReadBool(ref buffer);
        obj.isMapNoOverwriteOnDynamicBufferSrvSupported = DXMarshal.ReadBool(ref buffer);
        obj.isMultisampleRtvWithForcedSampleCountOneSupported = DXMarshal.ReadBool(ref buffer);
        obj.isSad4ShaderInstructionsSupported = DXMarshal.ReadBool(ref buffer);
        obj.isExtendedDoublesShaderInstructionsSupported = DXMarshal.ReadBool(ref buffer);
        obj.isExtendedResourceSharingSupported = DXMarshal.ReadBool(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11FeatureDataD3D11Options> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Specifies whether logic operations are available in blend state.
    /// </summary>
    private bool isOutputMergerLogicOperationsSupported;

    /// <summary>
    /// Specifies whether the driver can render with no render target views (RTVs) or depth stencil views (DSVs), and only unordered access views (UAVs) bound.
    /// </summary>
    private bool isUavOnlyRenderingForcedSampleCountSupported;

    /// <summary>
    /// Specifies whether the driver supports the <c>ID3D11DeviceContext1.DiscardView</c> and <c>ID3D11DeviceContext1.DiscardResource</c> methods.
    /// </summary>
    private bool isDiscardApisSeenByDriverSupported;

    /// <summary>
    /// Specifies whether the driver supports new semantics for copy and update.
    /// </summary>
    private bool isOptionsForUpdateAndCopySeenByDriverSupported;

    /// <summary>
    /// Specifies whether the driver supports the <c>ID3D11DeviceContext1.ClearView</c> method.
    /// </summary>
    private bool isClearViewSupported;

    /// <summary>
    /// Specifies whether you can call <c>ID3D11DeviceContext1.CopySubresourceRegion1</c> with overlapping source and destination rectangles.
    /// </summary>
    private bool isCopyWithOverlapSupported;

    /// <summary>
    /// Specifies whether the driver supports partial updates of constant buffers.
    /// </summary>
    private bool isConstantBufferPartialUpdateSupported;

    /// <summary>
    /// Specifies whether the driver supports new semantics for setting offsets in constant buffers for a shader.
    /// </summary>
    private bool isConstantBufferOffsettingSupported;

    /// <summary>
    /// Specifies whether you can call <c>ID3D11DeviceContext.Map</c> with <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> on a dynamic constant buffer.
    /// </summary>
    private bool isMapNoOverwriteOnDynamicConstantBufferSupported;

    /// <summary>
    /// Specifies whether you can call <c>ID3D11DeviceContext.Map</c> with <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> on a dynamic buffer SRV.
    /// </summary>
    private bool isMapNoOverwriteOnDynamicBufferSrvSupported;

    /// <summary>
    /// Specifies whether the driver supports multisample rendering when you render with RTVs bound.
    /// </summary>
    private bool isMultisampleRtvWithForcedSampleCountOneSupported;

    /// <summary>
    /// Specifies whether the hardware and driver support the <c>msad4</c> intrinsic function in shaders.
    /// </summary>
    private bool isSad4ShaderInstructionsSupported;

    /// <summary>
    /// Specifies whether the hardware and driver support the <c>fma</c> intrinsic function and other extended doubles instructions ( <c>DDIV</c> and <c>DRCP</c>) in shaders.
    /// </summary>
    private bool isExtendedDoublesShaderInstructionsSupported;

    /// <summary>
    /// Specifies whether the hardware and driver support sharing a greater variety of Texture2D resource types and formats.
    /// </summary>
    private bool isExtendedResourceSharingSupported;

    /// <summary>
    /// Gets a value indicating whether logic operations are available in blend state.
    /// </summary>
    public bool IsOutputMergerLogicOperationsSupported
    {
        get { return this.isOutputMergerLogicOperationsSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver can render with no render target views (RTVs) or depth stencil views (DSVs), and only unordered access views (UAVs) bound.
    /// </summary>
    public bool IsUavOnlyRenderingForcedSampleCountSupported
    {
        get { return this.isUavOnlyRenderingForcedSampleCountSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports the <c>ID3D11DeviceContext1.DiscardView</c> and <c>ID3D11DeviceContext1.DiscardResource</c> methods.
    /// </summary>
    public bool IsDiscardApisSeenByDriverSupported
    {
        get { return this.isDiscardApisSeenByDriverSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports new semantics for copy and update.
    /// </summary>
    public bool IsOptionsForUpdateAndCopySeenByDriverSupported
    {
        get { return this.isOptionsForUpdateAndCopySeenByDriverSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports the <c>ID3D11DeviceContext1.ClearView</c> method.
    /// </summary>
    public bool IsClearViewSupported
    {
        get { return this.isClearViewSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether you can call <c>ID3D11DeviceContext1.CopySubresourceRegion1</c> with overlapping source and destination rectangles.
    /// </summary>
    public bool IsCopyWithOverlapSupported
    {
        get { return this.isCopyWithOverlapSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports partial updates of constant buffers.
    /// </summary>
    public bool IsConstantBufferPartialUpdateSupported
    {
        get { return this.isConstantBufferPartialUpdateSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports new semantics for setting offsets in constant buffers for a shader.
    /// </summary>
    public bool IsConstantBufferOffsettingSupported
    {
        get { return this.isConstantBufferOffsettingSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether you can call <c>ID3D11DeviceContext.Map</c> with <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> on a dynamic constant buffer.
    /// </summary>
    public bool IsMapNoOverwriteOnDynamicConstantBufferSupported
    {
        get { return this.isMapNoOverwriteOnDynamicConstantBufferSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether you can call <c>ID3D11DeviceContext.Map</c> with <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> on a dynamic buffer SRV.
    /// </summary>
    public bool IsMapNoOverwriteOnDynamicBufferSrvSupported
    {
        get { return this.isMapNoOverwriteOnDynamicBufferSrvSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the driver supports multisample rendering when you render with RTVs bound.
    /// </summary>
    public bool IsMultisampleRtvWithForcedSampleCountOneSupported
    {
        get { return this.isMultisampleRtvWithForcedSampleCountOneSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support the <c>msad4</c> intrinsic function in shaders.
    /// </summary>
    public bool IsSad4ShaderInstructionsSupported
    {
        get { return this.isSad4ShaderInstructionsSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support the <c>fma</c> intrinsic function and other extended doubles instructions ( <c>DDIV</c> and <c>DRCP</c>) in shaders.
    /// </summary>
    public bool IsExtendedDoublesShaderInstructionsSupported
    {
        get { return this.isExtendedDoublesShaderInstructionsSupported; }
    }

    /// <summary>
    /// Gets a value indicating whether the hardware and driver support sharing a greater variety of Texture2D resource types and formats.
    /// </summary>
    public bool IsExtendedResourceSharingSupported
    {
        get { return this.isExtendedResourceSharingSupported; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11FeatureDataD3D11Options left, D3D11FeatureDataD3D11Options right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11FeatureDataD3D11Options left, D3D11FeatureDataD3D11Options right)
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
        return obj is D3D11FeatureDataD3D11Options options && Equals(options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11FeatureDataD3D11Options other)
    {
        return isOutputMergerLogicOperationsSupported == other.isOutputMergerLogicOperationsSupported &&
               isUavOnlyRenderingForcedSampleCountSupported == other.isUavOnlyRenderingForcedSampleCountSupported &&
               isDiscardApisSeenByDriverSupported == other.isDiscardApisSeenByDriverSupported &&
               isOptionsForUpdateAndCopySeenByDriverSupported == other.isOptionsForUpdateAndCopySeenByDriverSupported &&
               isClearViewSupported == other.isClearViewSupported &&
               isCopyWithOverlapSupported == other.isCopyWithOverlapSupported &&
               isConstantBufferPartialUpdateSupported == other.isConstantBufferPartialUpdateSupported &&
               isConstantBufferOffsettingSupported == other.isConstantBufferOffsettingSupported &&
               isMapNoOverwriteOnDynamicConstantBufferSupported == other.isMapNoOverwriteOnDynamicConstantBufferSupported &&
               isMapNoOverwriteOnDynamicBufferSrvSupported == other.isMapNoOverwriteOnDynamicBufferSrvSupported &&
               isMultisampleRtvWithForcedSampleCountOneSupported == other.isMultisampleRtvWithForcedSampleCountOneSupported &&
               isSad4ShaderInstructionsSupported == other.isSad4ShaderInstructionsSupported &&
               isExtendedDoublesShaderInstructionsSupported == other.isExtendedDoublesShaderInstructionsSupported &&
               isExtendedResourceSharingSupported == other.isExtendedResourceSharingSupported;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1700152703;
        hashCode = hashCode * -1521134295 + isOutputMergerLogicOperationsSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isUavOnlyRenderingForcedSampleCountSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isDiscardApisSeenByDriverSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isOptionsForUpdateAndCopySeenByDriverSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isClearViewSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isCopyWithOverlapSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isConstantBufferPartialUpdateSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isConstantBufferOffsettingSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isMapNoOverwriteOnDynamicConstantBufferSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isMapNoOverwriteOnDynamicBufferSrvSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isMultisampleRtvWithForcedSampleCountOneSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isSad4ShaderInstructionsSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isExtendedDoublesShaderInstructionsSupported.GetHashCode();
        hashCode = hashCode * -1521134295 + isExtendedResourceSharingSupported.GetHashCode();
        return hashCode;
    }
}
