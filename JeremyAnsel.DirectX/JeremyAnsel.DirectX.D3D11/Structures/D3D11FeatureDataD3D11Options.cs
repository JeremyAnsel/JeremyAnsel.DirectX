// <copyright file="D3D11FeatureDataD3D11Options.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes Direct3D 11.1 feature options in the current graphics driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11FeatureDataD3D11Options : IEquatable<D3D11FeatureDataD3D11Options>
    {
        /// <summary>
        /// Specifies whether logic operations are available in blend state.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isOutputMergerLogicOperationsSupported;

        /// <summary>
        /// Specifies whether the driver can render with no render target views (RTVs) or depth stencil views (DSVs), and only unordered access views (UAVs) bound.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isUavOnlyRenderingForcedSampleCountSupported;

        /// <summary>
        /// Specifies whether the driver supports the <c>ID3D11DeviceContext1.DiscardView</c> and <c>ID3D11DeviceContext1.DiscardResource</c> methods.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isDiscardApisSeenByDriverSupported;

        /// <summary>
        /// Specifies whether the driver supports new semantics for copy and update.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isOptionsForUpdateAndCopySeenByDriverSupported;

        /// <summary>
        /// Specifies whether the driver supports the <c>ID3D11DeviceContext1.ClearView</c> method.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isClearViewSupported;

        /// <summary>
        /// Specifies whether you can call <c>ID3D11DeviceContext1.CopySubresourceRegion1</c> with overlapping source and destination rectangles.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isCopyWithOverlapSupported;

        /// <summary>
        /// Specifies whether the driver supports partial updates of constant buffers.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isConstantBufferPartialUpdateSupported;

        /// <summary>
        /// Specifies whether the driver supports new semantics for setting offsets in constant buffers for a shader.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isConstantBufferOffsettingSupported;

        /// <summary>
        /// Specifies whether you can call <c>ID3D11DeviceContext.Map</c> with <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> on a dynamic constant buffer.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isMapNoOverwriteOnDynamicConstantBufferSupported;

        /// <summary>
        /// Specifies whether you can call <c>ID3D11DeviceContext.Map</c> with <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> on a dynamic buffer SRV.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isMapNoOverwriteOnDynamicBufferSrvSupported;

        /// <summary>
        /// Specifies whether the driver supports multisample rendering when you render with RTVs bound.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isMultisampleRtvWithForcedSampleCountOneSupported;

        /// <summary>
        /// Specifies whether the hardware and driver support the <c>msad4</c> intrinsic function in shaders.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isSad4ShaderInstructionsSupported;

        /// <summary>
        /// Specifies whether the hardware and driver support the <c>fma</c> intrinsic function and other extended doubles instructions ( <c>DDIV</c> and <c>DRCP</c>) in shaders.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isExtendedDoublesShaderInstructionsSupported;

        /// <summary>
        /// Specifies whether the hardware and driver support sharing a greater variety of Texture2D resource types and formats.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isExtendedResourceSharingSupported;

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
        /// Compares two <see cref="D3D11FeatureDataD3D11Options"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D11Options"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D11Options"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11FeatureDataD3D11Options left, D3D11FeatureDataD3D11Options right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11FeatureDataD3D11Options"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11FeatureDataD3D11Options"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11FeatureDataD3D11Options"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11FeatureDataD3D11Options left, D3D11FeatureDataD3D11Options right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not D3D11FeatureDataD3D11Options)
            {
                return false;
            }

            return this.Equals((D3D11FeatureDataD3D11Options)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11FeatureDataD3D11Options other)
        {
            return this.isOutputMergerLogicOperationsSupported == other.isOutputMergerLogicOperationsSupported
                && this.isUavOnlyRenderingForcedSampleCountSupported == other.isUavOnlyRenderingForcedSampleCountSupported
                && this.isDiscardApisSeenByDriverSupported == other.isDiscardApisSeenByDriverSupported
                && this.isOptionsForUpdateAndCopySeenByDriverSupported == other.isOptionsForUpdateAndCopySeenByDriverSupported
                && this.isClearViewSupported == other.isClearViewSupported
                && this.isCopyWithOverlapSupported == other.isCopyWithOverlapSupported
                && this.isConstantBufferPartialUpdateSupported == other.isConstantBufferPartialUpdateSupported
                && this.isConstantBufferOffsettingSupported == other.isConstantBufferOffsettingSupported
                && this.isMapNoOverwriteOnDynamicConstantBufferSupported == other.isMapNoOverwriteOnDynamicConstantBufferSupported
                && this.isMapNoOverwriteOnDynamicBufferSrvSupported == other.isMapNoOverwriteOnDynamicBufferSrvSupported
                && this.isMultisampleRtvWithForcedSampleCountOneSupported == other.isMultisampleRtvWithForcedSampleCountOneSupported
                && this.isSad4ShaderInstructionsSupported == other.isSad4ShaderInstructionsSupported
                && this.isExtendedDoublesShaderInstructionsSupported == other.isExtendedDoublesShaderInstructionsSupported
                && this.isExtendedResourceSharingSupported == other.isExtendedResourceSharingSupported;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isOutputMergerLogicOperationsSupported,
                this.isUavOnlyRenderingForcedSampleCountSupported,
                this.isDiscardApisSeenByDriverSupported,
                this.isOptionsForUpdateAndCopySeenByDriverSupported,
                this.isClearViewSupported,
                this.isCopyWithOverlapSupported,
                this.isConstantBufferPartialUpdateSupported,
                this.isConstantBufferOffsettingSupported,
                this.isMapNoOverwriteOnDynamicConstantBufferSupported,
                this.isMapNoOverwriteOnDynamicBufferSrvSupported,
                this.isMultisampleRtvWithForcedSampleCountOneSupported,
                this.isSad4ShaderInstructionsSupported,
                this.isExtendedDoublesShaderInstructionsSupported,
                this.isExtendedResourceSharingSupported
            }
            .GetHashCode();
        }
    }
}
