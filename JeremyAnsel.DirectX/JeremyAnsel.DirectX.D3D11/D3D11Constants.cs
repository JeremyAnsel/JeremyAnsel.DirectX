// <copyright file="D3D11Constants.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Constants generated from the D3D11 hardware spec.
    /// </summary>
    public static class D3D11Constants
    {
        /// <summary>
        /// Feature Level 9.1 Req Texture 1D Dimension.
        /// </summary>
        public const uint FeatureLevel91ReqTexture1DDimension = 2048;

        /// <summary>
        /// Feature Level 9.3 Req Texture 1D Dimension.
        /// </summary>
        public const uint FeatureLevel93ReqTexture1DDimension = 4096;

        /// <summary>
        /// Feature Level 9.1 Req Texture 2D Dimension.
        /// </summary>
        public const uint FeatureLevel91ReqTexture2DDimension = 2048;

        /// <summary>
        /// Feature Level 9.3 Req Texture 2D Dimension.
        /// </summary>
        public const uint FeatureLevel93ReqTexture2DDimension = 4096;

        /// <summary>
        /// Feature Level 9.1 Req Texture Cube Dimension.
        /// </summary>
        public const uint FeatureLevel91ReqTextureCubeDimension = 512;

        /// <summary>
        /// Feature Level 9.3 Req Texture Cube Dimension.
        /// </summary>
        public const uint FeatureLevel93ReqTextureCubeDimension = 4096;

        /// <summary>
        /// Feature Level 9.1 Req Texture 3D Dimension.
        /// </summary>
        public const uint FeatureLevel91ReqTexture3DDimension = 256;

        /// <summary>
        /// Feature Level 9.1 Default Max Anisotropy.
        /// </summary>
        public const uint FeatureLevel91DefaultMaxAnisotropy = 2;

        /// <summary>
        /// Feature Level 9.1 Input Assembler Primitive Max Count.
        /// </summary>
        public const uint FeatureLevel91InputAssemblerPrimitiveMaxCount = 65535;

        /// <summary>
        /// Feature Level 9.2 Input Assembler Primitive Max Count.
        /// </summary>
        public const uint FeatureLevel92InputAssemblerPrimitiveMaxCount = 1048575;

        /// <summary>
        /// Feature Level 9.1 Simultaneous Render Target Count.
        /// </summary>
        public const uint FeatureLevel91SimultaneousRenderTargetCount = 1;

        /// <summary>
        /// Feature Level 9.3 Simultaneous Render Target Count.
        /// </summary>
        public const uint FeatureLevel93SimultaneousRenderTargetCount = 4;

        /// <summary>
        /// Feature Level 9.1 Max Texture Repeat.
        /// </summary>
        public const uint FeatureLevel91MaxTextureRepeat = 128;

        /// <summary>
        /// Feature Level 9.2 Max Texture Repeat.
        /// </summary>
        public const uint FeatureLevel92MaxTextureRepeat = 2048;

        /// <summary>
        /// Feature Level 9.3 Max Texture Repeat.
        /// </summary>
        public const uint FeatureLevel93MaxTextureRepeat = 8192;

        /// <summary>
        /// Index Strip Cut Value 16-Bit.
        /// </summary>
        public const uint IndexStripCutValue16Bit = 0xffff;

        /// <summary>
        /// Index Strip Cut Value 32-Bit.
        /// </summary>
        public const uint IndexStripCutValue32Bit = 0xffffffff;

        /// <summary>
        /// Index Strip Cut Value 8-Bit.
        /// </summary>
        public const uint IndexStripCutValue8Bit = 0xff;

        /// <summary>
        /// Array Axis Address Range Bit Count.
        /// </summary>
        public const uint ArrayAxisAddressRangeBitCount = 9;

        /// <summary>
        /// Clip Or Cull Distance Cull.
        /// </summary>
        public const uint ClipOrCullDistanceCull = 8;

        /// <summary>
        /// Clip Or Cull Distance Element Count.
        /// </summary>
        public const uint ClipOrCullDistanceElementCount = 2;

        /// <summary>
        /// Common Shader Constant Buffer Api Slot Count.
        /// </summary>
        public const uint CommonShaderConstantBufferApiSlotCount = 14;

        /// <summary>
        /// Common Shader Constant Buffer Components.
        /// </summary>
        public const uint CommonShaderConstantBufferComponents = 4;

        /// <summary>
        /// Common Shader Constant Buffer Component Bit Count.
        /// </summary>
        public const uint CommonShaderConstantBufferComponentBitCount = 32;

        /// <summary>
        /// Common Shader Constant Buffer Hardware Slot Count.
        /// </summary>
        public const uint CommonShaderConstantBufferHardwareSlotCount = 15;

        /// <summary>
        /// Common Shader Constant Buffer Partial Update Extents Byte Alignment.
        /// </summary>
        public const uint CommonShaderConstantBufferPartialUpdateExtentsByteAlignment = 16;

        /// <summary>
        /// Common Shader Constant Buffer Register Components.
        /// </summary>
        public const uint CommonShaderConstantBufferRegisterComponents = 4;

        /// <summary>
        /// Common Shader Constant Buffer Register Count.
        /// </summary>
        public const uint CommonShaderConstantBufferRegisterCount = 15;

        /// <summary>
        /// Common Shader Constant Buffer Register Reads Per Instance.
        /// </summary>
        public const uint CommonShaderConstantBufferRegisterReadsPerInstance = 1;

        /// <summary>
        /// Common Shader Constant Buffer Register Read Ports.
        /// </summary>
        public const uint CommonShaderConstantBufferRegisterReadPorts = 1;

        /// <summary>
        /// Common Shader Flow Control Nesting Limit.
        /// </summary>
        public const uint CommonShaderFlowControlNestingLimit = 64;

        /// <summary>
        /// Common Shader Immediate Constant Buffer Register Components.
        /// </summary>
        public const uint CommonShaderImmediateConstantBufferRegisterComponents = 4;

        /// <summary>
        /// Common Shader Immediate Constant Buffer Register Count.
        /// </summary>
        public const uint CommonShaderImmediateConstantBufferRegisterCount = 1;

        /// <summary>
        /// Common Shader Immediate Constant Buffer Register Reads Per Instance.
        /// </summary>
        public const uint CommonShaderImmediateConstantBufferRegisterReadsPerInstance = 1;

        /// <summary>
        /// Common Shader Immediate Constant Buffer Register Read Ports.
        /// </summary>
        public const uint CommonShaderImmediateConstantBufferRegisterReadPorts = 1;

        /// <summary>
        /// Common Shader Immediate Value Component Bit Count.
        /// </summary>
        public const uint CommonShaderImmediateValueComponentBitCount = 32;

        /// <summary>
        /// Common Shader Input Resource Register Components.
        /// </summary>
        public const uint CommonShaderInputResourceRegisterComponents = 1;

        /// <summary>
        /// Common Shader Input Resource Register Count.
        /// </summary>
        public const uint CommonShaderInputResourceRegisterCount = 128;

        /// <summary>
        /// Common Shader Input Resource Register Reads Per Instance.
        /// </summary>
        public const uint CommonShaderInputResourceRegisterReadsPerInstance = 1;

        /// <summary>
        /// Common Shader Input Resource Register Read Ports.
        /// </summary>
        public const uint CommonShaderInputResourceRegisterReadPorts = 1;

        /// <summary>
        /// Common Shader Input Resource Slot Count.
        /// </summary>
        public const uint CommonShaderInputResourceSlotCount = 128;

        /// <summary>
        /// Common Shader Sampler Register Components.
        /// </summary>
        public const uint CommonShaderSamplerRegisterComponents = 1;

        /// <summary>
        /// Common Shader Sampler Register Count.
        /// </summary>
        public const uint CommonShaderSamplerRegisterCount = 16;

        /// <summary>
        /// Common Shader Sampler Register Reads Per Instance.
        /// </summary>
        public const uint CommonShaderSamplerRegisterReadsPerInstance = 1;

        /// <summary>
        /// Common Shader Sampler Register Read Ports.
        /// </summary>
        public const uint CommonShaderSamplerRegisterReadPorts = 1;

        /// <summary>
        /// Common Shader Sampler Slot Count.
        /// </summary>
        public const uint CommonShaderSamplerSlotCount = 16;

        /// <summary>
        /// Common Shader Subroutine Nesting Limit.
        /// </summary>
        public const uint CommonShaderSubroutineNestingLimit = 32;

        /// <summary>
        /// Common Shader Temp Register Components.
        /// </summary>
        public const uint CommonShaderTempRegisterComponents = 4;

        /// <summary>
        /// Common Shader Temp Register Component Bit Count.
        /// </summary>
        public const uint CommonShaderTempRegisterComponentBitCount = 32;

        /// <summary>
        /// Common Shader Temp Register Count.
        /// </summary>
        public const uint CommonShaderTempRegisterCount = 4096;

        /// <summary>
        /// Common Shader Temp Register Reads Per Instance.
        /// </summary>
        public const uint CommonShaderTempRegisterReadsPerInstance = 3;

        /// <summary>
        /// Common Shader Temp Register Read Ports.
        /// </summary>
        public const uint CommonShaderTempRegisterReadPorts = 3;

        /// <summary>
        /// Common Shader Tex Coord Range Reduction Max.
        /// </summary>
        public const uint CommonShaderTexCoordRangeReductionMax = 10;

        /// <summary>
        /// Common Shader Tex Coord Range Reduction Min.
        /// </summary>
        public const int CommonShaderTexCoordRangeReductionMin = -10;

        /// <summary>
        /// Common Shader Texel Offset Max Negative.
        /// </summary>
        public const int CommonShaderTexelOffsetMaxNegative = -8;

        /// <summary>
        /// Common Shader Texel Offset Max Positive.
        /// </summary>
        public const uint CommonShaderTexelOffsetMaxPositive = 7;

        /// <summary>
        /// Compute Shader 4X Bucket 00 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket00MaxBytesTgsmWritablePerThread = 256;

        /// <summary>
        /// Compute Shader 4X Bucket 00 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket00MaxNumThreadsPerGroup = 64;

        /// <summary>
        /// Compute Shader 4X Bucket 01 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket01MaxBytesTgsmWritablePerThread = 240;

        /// <summary>
        /// Compute Shader 4X Bucket 01 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket01MaxNumThreadsPerGroup = 68;

        /// <summary>
        /// Compute Shader 4X Bucket 02 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket02MaxBytesTgsmWritablePerThread = 224;

        /// <summary>
        /// Compute Shader 4X Bucket 02 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket02MaxNumThreadsPerGroup = 72;

        /// <summary>
        /// Compute Shader 4X Bucket 03 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket03MaxBytesTgsmWritablePerThread = 208;

        /// <summary>
        /// Compute Shader 4X Bucket 03 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket03MaxNumThreadsPerGroup = 76;

        /// <summary>
        /// Compute Shader 4X Bucket 04 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket04MaxBytesTgsmWritablePerThread = 192;

        /// <summary>
        /// Compute Shader 4X Bucket 04 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket04MaxNumThreadsPerGroup = 84;

        /// <summary>
        /// Compute Shader 4X Bucket 05 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket05MaxBytesTgsmWritablePerThread = 176;

        /// <summary>
        /// Compute Shader 4X Bucket 05 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket05MaxNumThreadsPerGroup = 92;

        /// <summary>
        /// Compute Shader 4X Bucket 06 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket06MaxBytesTgsmWritablePerThread = 160;

        /// <summary>
        /// Compute Shader 4X Bucket 06 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket06MaxNumThreadsPerGroup = 100;

        /// <summary>
        /// Compute Shader 4X Bucket 07 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket07MaxBytesTgsmWritablePerThread = 144;

        /// <summary>
        /// Compute Shader 4X Bucket 07 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket07MaxNumThreadsPerGroup = 112;

        /// <summary>
        /// Compute Shader 4X Bucket 08 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket08MaxBytesTgsmWritablePerThread = 128;

        /// <summary>
        /// Compute Shader 4X Bucket 08 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket08MaxNumThreadsPerGroup = 128;

        /// <summary>
        /// Compute Shader 4X Bucket 09 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket09MaxBytesTgsmWritablePerThread = 112;

        /// <summary>
        /// Compute Shader 4X Bucket 09 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket09MaxNumThreadsPerGroup = 144;

        /// <summary>
        /// Compute Shader 4X Bucket 10 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket10MaxBytesTgsmWritablePerThread = 96;

        /// <summary>
        /// Compute Shader 4X Bucket 10 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket10MaxNumThreadsPerGroup = 168;

        /// <summary>
        /// Compute Shader 4X Bucket 11 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket11MaxBytesTgsmWritablePerThread = 80;

        /// <summary>
        /// Compute Shader 4X Bucket 11 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket11MaxNumThreadsPerGroup = 204;

        /// <summary>
        /// Compute Shader 4X Bucket 12 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket12MaxBytesTgsmWritablePerThread = 64;

        /// <summary>
        /// Compute Shader 4X Bucket 12 Max Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket12MaxThreadsPerGroup = 256;

        /// <summary>
        /// Compute Shader 4X Bucker 13 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucker13MaxBytesTgsmWritablePerThread = 48;

        /// <summary>
        /// Compute Shader 4X Bucket 13 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket13MaxNumThreadsPerGroup = 340;

        /// <summary>
        /// Compute Shader 4X Bucket 14 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket14MaxBytesTgsmWritablePerThread = 32;

        /// <summary>
        /// Compute Shader 4X Bucket 14 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket14MaxNumThreadsPerGroup = 512;

        /// <summary>
        /// Compute Shader 4X Bucket 15 Max Bytes Tgsm Writable Per Thread.
        /// </summary>
        public const uint ComputeShader4XBucket15MaxBytesTgsmWritablePerThread = 16;

        /// <summary>
        /// Compute Shader 4X Bucket 15 Max Num Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XBucket15MaxNumThreadsPerGroup = 768;

        /// <summary>
        /// Compute Shader 4X Dispatch Max Thread Groups In Z Dimension.
        /// </summary>
        public const uint ComputeShader4XDispatchMaxThreadGroupsInZDimension = 1;

        /// <summary>
        /// Compute Shader 4X Raw UAV Byte Alignment.
        /// </summary>
        public const uint ComputeShader4XRawUavByteAlignment = 256;

        /// <summary>
        /// Compute Shader 4X Thread Group Max Threads Per Group.
        /// </summary>
        public const uint ComputeShader4XThreadGroupMaxThreadsPerGroup = 768;

        /// <summary>
        /// Compute Shader 4X Thread Group Max X.
        /// </summary>
        public const uint ComputeShader4XThreadGroupMaxX = 768;

        /// <summary>
        /// Compute Shader 4X Thread Group Max Y.
        /// </summary>
        public const uint ComputeShader4XThreadGroupMaxY = 768;

        /// <summary>
        /// Compute Shader 4X UAV Register Count.
        /// </summary>
        public const uint ComputeShader4XUavRegisterCount = 1;

        /// <summary>
        /// Compute Shader Dispatch Max Thread Groups Per Dimension.
        /// </summary>
        public const uint ComputeShaderDispatchMaxThreadGroupsPerDimension = 65535;

        /// <summary>
        /// Compute Shader Tgsm Register Count.
        /// </summary>
        public const uint ComputeShaderTgsmRegisterCount = 8192;

        /// <summary>
        /// Compute Shader Tgsm Register Reads Per Instance.
        /// </summary>
        public const uint ComputeShaderTgsmRegisterReadsPerInstance = 1;

        /// <summary>
        /// Compute Shader Tgsm Resource Register Components.
        /// </summary>
        public const uint ComputeShaderTgsmResourceRegisterComponents = 1;

        /// <summary>
        /// Compute Shader Tgsm Resource Register Read Ports.
        /// </summary>
        public const uint ComputeShaderTgsmResourceRegisterReadPorts = 1;

        /// <summary>
        /// Compute Shader Thread Group Id Register Components.
        /// </summary>
        public const uint ComputeShaderThreadGroupIdRegisterComponents = 3;

        /// <summary>
        /// Compute Shader Thread Group Id Register Count.
        /// </summary>
        public const uint ComputeShaderThreadGroupIdRegisterCount = 1;

        /// <summary>
        /// Compute Shader Thread Id In Group Flattened Register Components.
        /// </summary>
        public const uint ComputeShaderThreadIdInGroupFlattenedRegisterComponents = 1;

        /// <summary>
        /// Compute Shader Thread Id In Group Flattened Register Count.
        /// </summary>
        public const uint ComputeShaderThreadIdInGroupFlattenedRegisterCount = 1;

        /// <summary>
        /// Compute Shader Thread Id In Group Register Components.
        /// </summary>
        public const uint ComputeShaderThreadIdInGroupRegisterComponents = 3;

        /// <summary>
        /// Compute Shader Thread Id In Group Register Count.
        /// </summary>
        public const uint ComputeShaderThreadIdInGroupRegisterCount = 1;

        /// <summary>
        /// Compute Shader Thread Id Register Components.
        /// </summary>
        public const uint ComputeShaderThreadIdRegisterComponents = 3;

        /// <summary>
        /// Compute Shader Thread Id Register Count.
        /// </summary>
        public const uint ComputeShaderThreadIdRegisterCount = 1;

        /// <summary>
        /// Compute Shader Thread Group Max Threads Per Group.
        /// </summary>
        public const uint ComputeShaderThreadGroupMaxThreadsPerGroup = 1024;

        /// <summary>
        /// Compute Shader Thread Group Max X.
        /// </summary>
        public const uint ComputeShaderThreadGroupMaxX = 1024;

        /// <summary>
        /// Compute Shader Thread Group Max Y.
        /// </summary>
        public const uint ComputeShaderThreadGroupMaxY = 1024;

        /// <summary>
        /// Compute Shader Thread Group Max Z.
        /// </summary>
        public const uint ComputeShaderThreadGroupMaxZ = 64;

        /// <summary>
        /// Compute Shader Thread Group Min X.
        /// </summary>
        public const uint ComputeShaderThreadGroupMinX = 1;

        /// <summary>
        /// Compute Shader Thread Group Min Y.
        /// </summary>
        public const uint ComputeShaderThreadGroupMinY = 1;

        /// <summary>
        /// Compute Shader Thread Group Min Z.
        /// </summary>
        public const uint ComputeShaderThreadGroupMinZ = 1;

        /// <summary>
        /// Compute Shader Thread Local Temp Register Pool.
        /// </summary>
        public const uint ComputeShaderThreadLocalTempRegisterPool = 16384;

        /// <summary>
        /// Default Blend Factor Alpha.
        /// </summary>
        public const float DefaultBlendFactorAlpha = 1.0f;

        /// <summary>
        /// Default Blend Factor Blue.
        /// </summary>
        public const float DefaultBlendFactorBlue = 1.0f;

        /// <summary>
        /// Default Blend Factor Green.
        /// </summary>
        public const float DefaultBlendFactorGreen = 1.0f;

        /// <summary>
        /// Default Blend Factor Red
        /// </summary>
        public const float DefaultBlendFactorRed = 1.0f;

        /// <summary>
        /// Default Border Color Component.
        /// </summary>
        public const float DefaultBorderColorComponent = 0.0f;

        /// <summary>
        /// Default Depth Bias.
        /// </summary>
        public const uint DefaultDepthBias = 0;

        /// <summary>
        /// Default Depth Bias Clamp.
        /// </summary>
        public const float DefaultDepthBiasClamp = 0.0f;

        /// <summary>
        /// Default Max Anisotropy.
        /// </summary>
        public const uint DefaultMaxAnisotropy = 16;

        /// <summary>
        /// Default Mip Lod Bias.
        /// </summary>
        public const float DefaultMipLodBias = 0.0f;

        /// <summary>
        /// Default Render Target Array Index.
        /// </summary>
        public const uint DefaultRenderTargetArrayIndex = 0;

        /// <summary>
        /// Default Sample Mask.
        /// </summary>
        public const uint DefaultSampleMask = 0xffffffff;

        /// <summary>
        /// Default Scissor End X.
        /// </summary>
        public const uint DefaultScissorEndX = 0;

        /// <summary>
        /// Default Scissor End Y.
        /// </summary>
        public const uint DefaultScissorEndY = 0;

        /// <summary>
        /// Default Scissor Start X.
        /// </summary>
        public const uint DefaultScissorStartX = 0;

        /// <summary>
        /// Default Scissor Start Y.
        /// </summary>
        public const uint DefaultScissorStartY = 0;

        /// <summary>
        /// Default Slope Scaled Depth Bias.
        /// </summary>
        public const float DefaultSlopeScaledDepthBias = 0.0f;

        /// <summary>
        /// Default Stencil Read Mask.
        /// </summary>
        public const uint DefaultStencilReadMask = 0xff;

        /// <summary>
        /// Default Stencil Reference.
        /// </summary>
        public const uint DefaultStencilReference = 0;

        /// <summary>
        /// Default Stencil Write Mask.
        /// </summary>
        public const uint DefaultStencilWriteMask = 0xff;

        /// <summary>
        /// Default Viewport And Scissor Rect Index.
        /// </summary>
        public const uint DefaultViewportAndScissorRectIndex = 0;

        /// <summary>
        /// Default Viewport Height.
        /// </summary>
        public const uint DefaultViewportHeight = 0;

        /// <summary>
        /// Default Viewport Max Depth.
        /// </summary>
        public const float DefaultViewportMaxDepth = 0.0f;

        /// <summary>
        /// Default Viewport Min Depth.
        /// </summary>
        public const float DefaultViewportMinDepth = 0.0f;

        /// <summary>
        /// Default Viewport Top Left X.
        /// </summary>
        public const uint DefaultViewportTopLeftX = 0;

        /// <summary>
        /// Default Viewport Top Left Y.
        /// </summary>
        public const uint DefaultViewportTopLeftY = 0;

        /// <summary>
        /// Default Viewport Width.
        /// </summary>
        public const uint DefaultViewportWidth = 0;

        /// <summary>
        /// Domain Shader Input Control Points Max Total Scalars.
        /// </summary>
        public const uint DomainShaderInputControlPointsMaxTotalScalars = 3968;

        /// <summary>
        /// Domain Shader Input Control Point Register Components.
        /// </summary>
        public const uint DomainShaderInputControlPointRegisterComponents = 4;

        /// <summary>
        /// Domain Shader Input Control Point Register Component Bit Count.
        /// </summary>
        public const uint DomainShaderInputControlPointRegisterComponentBitCount = 32;

        /// <summary>
        /// Domain Shader Input Control Point Register Count.
        /// </summary>
        public const uint DomainShaderInputControlPointRegisterCount = 32;

        /// <summary>
        /// Domain Shader Input Control Point Register Reads Per Instance.
        /// </summary>
        public const uint DomainShaderInputControlPointRegisterReadsPerInstance = 2;

        /// <summary>
        /// Domain Shader Input Control Point Register Read Ports.
        /// </summary>
        public const uint DomainShaderInputControlPointRegisterReadPorts = 1;

        /// <summary>
        /// Domain Shader Input Domain Point Register Components.
        /// </summary>
        public const uint DomainShaderInputDomainPointRegisterComponents = 3;

        /// <summary>
        /// Domain Shader Input Domain Point Register Component Bit Count.
        /// </summary>
        public const uint DomainShaderInputDomainPointRegisterComponentBitCount = 32;

        /// <summary>
        /// Domain Shader Input Domain Point Register Count.
        /// </summary>
        public const uint DomainShaderInputDomainPointRegisterCount = 1;

        /// <summary>
        /// Domain Shader Input Domain Point Register Reads Per Instance.
        /// </summary>
        public const uint DomainShaderInputDomainPointRegisterReadsPerInstance = 2;

        /// <summary>
        /// Domain Shader Input Domain Point Register Read Ports.
        /// </summary>
        public const uint DomainShaderInputDomainPointRegisterReadPorts = 1;

        /// <summary>
        /// Domain Shader Input Patch Constant Register Components.
        /// </summary>
        public const uint DomainShaderInputPatchConstantRegisterComponents = 4;

        /// <summary>
        /// Domain Shader Input Patch Constant Register Bit Count.
        /// </summary>
        public const uint DomainShaderInputPatchConstantRegisterBitCount = 32;

        /// <summary>
        /// Domain Shader Input Patch Constant Register Count.
        /// </summary>
        public const uint DomainShaderInputPatchConstantRegisterCount = 32;

        /// <summary>
        /// Domain Shader Input Patch Constant Register Reads Per Instance.
        /// </summary>
        public const uint DomainShaderInputPatchConstantRegisterReadsPerInstance = 2;

        /// <summary>
        /// Domain Shader Input Patch Constant Register Read Ports.
        /// </summary>
        public const uint DomainShaderInputPatchConstantRegisterReadPorts = 1;

        /// <summary>
        /// Domain Shader Input Primitive Id Register Components.
        /// </summary>
        public const uint DomainShaderInputPrimitiveIdRegisterComponents = 1;

        /// <summary>
        /// Domain Shader Input Primitive Id Register Bit Count.
        /// </summary>
        public const uint DomainShaderInputPrimitiveIdRegisterBitCount = 32;

        /// <summary>
        /// Domain Shader Input Primitive Id Register Count.
        /// </summary>
        public const uint DomainShaderInputPrimitiveIdRegisterCount = 1;

        /// <summary>
        /// Domain Shader Input Primitive Id Register Reads Per Instance.
        /// </summary>
        public const uint DomainShaderInputPrimitiveIdRegisterReadsPerInstance = 2;

        /// <summary>
        /// Domain Shader Input Primitive Id Register Read Ports.
        /// </summary>
        public const uint DomainShaderInputPrimitiveIdRegisterReadPorts = 1;

        /// <summary>
        /// Domain Shader Output Register Components.
        /// </summary>
        public const uint DomainShaderOutputRegisterComponents = 4;

        /// <summary>
        /// Domain Shader Output Register Component Bit Count.
        /// </summary>
        public const uint DomainShaderOutputRegisterComponentBitCount = 32;

        /// <summary>
        /// Domain Shader Output Register Count.
        /// </summary>
        public const uint DomainShaderOutputRegisterCount = 32;

        /// <summary>
        /// Float16 Fused Tolerance In Ulp.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float Float16FusedToleranceInUlp = 0.6f;

        /// <summary>
        /// Float32 Max.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float32", Justification = "Reviewed")]
        public const float Float32Max = 3.402823466e+38f;

        /// <summary>
        /// Float32 To Integer Tolerance In Ulp.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float32", Justification = "Reviewed")]
        public const float Float32ToIntegerToleranceInUlp = 0.6f;

        /// <summary>
        /// Float To Srgb Exponent Denominator.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToSrgbExponentDenominator = 2.4f;

        /// <summary>
        /// Float To Srgb Exponent Numerator.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToSrgbExponentNumerator = 1.0f;

        /// <summary>
        /// Float To Srgb Offset.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToSrgbOffset = 0.055f;

        /// <summary>
        /// Float To Srgb Scale 1.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToSrgbScale1 = 12.92f;

        /// <summary>
        /// Float To Srgb Scale 2.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToSrgbScale2 = 1.055f;

        /// <summary>
        /// Float To Srgb Threshold.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToSrgbThreshold = 0.0031308f;

        /// <summary>
        /// Float To Int Instruction Max Input.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToIntInstructionMaxInput = 2147483647.999f;

        /// <summary>
        /// Float To Int Instruction Min Input.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToIntInstructionMinInput = -2147483648.999f;

        /// <summary>
        /// Float To UInt Instruction Max Input.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToUIntInstructionMaxInput = 4294967295.999f;

        /// <summary>
        /// Float To Uint Instruction Min Input.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float FloatToUintInstructionMinInput = 0.0f;

        /// <summary>
        /// Geometry Shader Input Instance Id Reads Per Instance.
        /// </summary>
        public const uint GeometryShaderInputInstanceIdReadsPerInstance = 2;

        /// <summary>
        /// Geometry Shader Input Instance Id Read Ports.
        /// </summary>
        public const uint GeometryShaderInputInstanceIdReadPorts = 1;

        /// <summary>
        /// Geometry Shader Input Instance Id Register Components.
        /// </summary>
        public const uint GeometryShaderInputInstanceIdRegisterComponents = 1;

        /// <summary>
        /// Geometry Shader Input Instance Id Register Component Bit Count.
        /// </summary>
        public const uint GeometryShaderInputInstanceIdRegisterComponentBitCount = 32;

        /// <summary>
        /// Geometry Shader Input Instance Id Register Count.
        /// </summary>
        public const uint GeometryShaderInputInstanceIdRegisterCount = 1;

        /// <summary>
        /// Geometry Shader Input Prim Const Register Components.
        /// </summary>
        public const uint GeometryShaderInputPrimConstRegisterComponents = 1;

        /// <summary>
        /// Geometry Shader Input Prim Const Register Component Bit Count.
        /// </summary>
        public const uint GeometryShaderInputPrimConstRegisterComponentBitCount = 32;

        /// <summary>
        /// Geometry Shader Input Prim Const Register Count.
        /// </summary>
        public const uint GeometryShaderInputPrimConstRegisterCount = 1;

        /// <summary>
        /// Geometry Shader Input Prim Const Register Reads Per Instance.
        /// </summary>
        public const uint GeometryShaderInputPrimConstRegisterReadsPerInstance = 2;

        /// <summary>
        /// Geometry Shader Input Prim Const Register Read Ports.
        /// </summary>
        public const uint GeometryShaderInputPrimConstRegisterReadPorts = 1;

        /// <summary>
        /// Geometry Shader Input Register Components.
        /// </summary>
        public const uint GeometryShaderInputRegisterComponents = 4;

        /// <summary>
        /// Geometry Shader Input Register Component Bit Count.
        /// </summary>
        public const uint GeometryShaderInputRegisterComponentBitCount = 32;

        /// <summary>
        /// Geometry Shader Input Register Count.
        /// </summary>
        public const uint GeometryShaderInputRegisterCount = 32;

        /// <summary>
        /// Geometry Shader Input Register Reads Per Instance.
        /// </summary>
        public const uint GeometryShaderInputRegisterReadsPerInstance = 2;

        /// <summary>
        /// Geometry Shader Input Register Read Ports.
        /// </summary>
        public const uint GeometryShaderInputRegisterReadPorts = 1;

        /// <summary>
        /// Geometry Shader Input Register Vertices.
        /// </summary>
        public const uint GeometryShaderInputRegisterVertices = 32;

        /// <summary>
        /// Geometry Shader Max Instance Count.
        /// </summary>
        public const uint GeometryShaderMaxInstanceCount = 32;

        /// <summary>
        /// Geometry Shader Max Output Vertex Count Across Instances.
        /// </summary>
        public const uint GeometryShaderMaxOutputVertexCountAcrossInstances = 1024;

        /// <summary>
        /// Geometry Shader Output Elements.
        /// </summary>
        public const uint GeometryShaderOutputElements = 32;

        /// <summary>
        /// Geometry Shader Output Register Components.
        /// </summary>
        public const uint GeometryShaderOutputRegisterComponents = 4;

        /// <summary>
        /// Geometry Shader Output Register Component Bit Count.
        /// </summary>
        public const uint GeometryShaderOutputRegisterComponentBitCount = 32;

        /// <summary>
        /// Geometry Shader Output Register Count.
        /// </summary>
        public const uint GeometryShaderOutputRegisterCount = 32;

        /// <summary>
        /// Hull Shader Control Point Phase Input Register Count.
        /// </summary>
        public const uint HullShaderControlPointPhaseInputRegisterCount = 32;

        /// <summary>
        /// Hull Shader Control Point Phase Output Register Count.
        /// </summary>
        public const uint HullShaderControlPointPhaseOutputRegisterCount = 32;

        /// <summary>
        /// Hull Shader Control Point Register Components.
        /// </summary>
        public const uint HullShaderControlPointRegisterComponents = 4;

        /// <summary>
        /// Hull Shader Control Point Register Component Bit Count.
        /// </summary>
        public const uint HullShaderControlPointRegisterComponentBitCount = 32;

        /// <summary>
        /// Hull Shader Control Point Register Reads Per Instance.
        /// </summary>
        public const uint HullShaderControlPointRegisterReadsPerInstance = 2;

        /// <summary>
        /// Hull Shader Control Point Register Read Ports.
        /// </summary>
        public const uint HullShaderControlPointRegisterReadPorts = 1;

        /// <summary>
        /// Hull Shader Fork Phase Instance Count Upper Bound.
        /// </summary>
        public const uint HullShaderForkPhaseInstanceCountUpperBound = 0xFFFFFFFF;

        /// <summary>
        /// Hull Shader Input Fork Instance Id Register Components.
        /// </summary>
        public const uint HullShaderInputForkInstanceIdRegisterComponents = 1;

        /// <summary>
        /// Hull Shader Input Fork Instance Id Register Component Bit Count.
        /// </summary>
        public const uint HullShaderInputForkInstanceIdRegisterComponentBitCount = 32;

        /// <summary>
        /// Hull Shader Input Fork Instance Id Register Count.
        /// </summary>
        public const uint HullShaderInputForkInstanceIdRegisterCount = 1;

        /// <summary>
        /// Hull Shader Input Fork Instance Id Register Reads Per Instance.
        /// </summary>
        public const uint HullShaderInputForkInstanceIdRegisterReadsPerInstance = 2;

        /// <summary>
        /// Hull Shader Input Fork Instance Id Register Read Ports.
        /// </summary>
        public const uint HullShaderInputForkInstanceIdRegisterReadPorts = 1;

        /// <summary>
        /// Hull Shader Input Join Instance Id Register Components.
        /// </summary>
        public const uint HullShaderInputJoinInstanceIdRegisterComponents = 1;

        /// <summary>
        /// Hull Shader Input Join Instance Id Register Component Bit Count.
        /// </summary>
        public const uint HullShaderInputJoinInstanceIdRegisterComponentBitCount = 32;

        /// <summary>
        /// Hull Shader Input Join Instance Id Register Count.
        /// </summary>
        public const uint HullShaderInputJoinInstanceIdRegisterCount = 1;

        /// <summary>
        /// Hull Shader Input Join Instance Id Register Reads Per Instance.
        /// </summary>
        public const uint HullShaderInputJoinInstanceIdRegisterReadsPerInstance = 2;

        /// <summary>
        /// Hull Shader Input Join Instance Id Register Read Ports.
        /// </summary>
        public const uint HullShaderInputJoinInstanceIdRegisterReadPorts = 1;

        /// <summary>
        /// Hull Shader Input Primitive Id Register Components.
        /// </summary>
        public const uint HullShaderInputPrimitiveIdRegisterComponents = 1;

        /// <summary>
        /// Hull Shader Input Primitive Id Register Component Bit Count.
        /// </summary>
        public const uint HullShaderInputPrimitiveIdRegisterComponentBitCount = 32;

        /// <summary>
        /// Hull Shader Input Primitive Id Register Count.
        /// </summary>
        public const uint HullShaderInputPrimitiveIdRegisterCount = 1;

        /// <summary>
        /// Hull Shader Input Primitive Id Register Reads Per Instance.
        /// </summary>
        public const uint HullShaderInputPrimitiveIdRegisterReadsPerInstance = 2;

        /// <summary>
        /// Hull Shader Input Primitive Id Register Read Ports.
        /// </summary>
        public const uint HullShaderInputPrimitiveIdRegisterReadPorts = 1;

        /// <summary>
        /// Hull Shader Join Phase Instance Count Upper Bound.
        /// </summary>
        public const uint HullShaderJoinPhaseInstanceCountUpperBound = 0xFFFFFFFF;

        /// <summary>
        /// Hull Shader Max Tessellation Factor Lower Bound.
        /// </summary>
        public const float HullShaderMaxTessellationFactorLowerBound = 1.0f;

        /// <summary>
        /// Hull Shader Max Tessellation Factor Upper Bound.
        /// </summary>
        public const float HullShaderMaxTessellationFactorUpperBound = 64.0f;

        /// <summary>
        /// Hull Shader Output Control Points Max Total Scalars.
        /// </summary>
        public const uint HullShaderOutputControlPointsMaxTotalScalars = 3968;

        /// <summary>
        /// Hull Shader Output Control Point Id Register Components.
        /// </summary>
        public const uint HullShaderOutputControlPointIdRegisterComponents = 1;

        /// <summary>
        /// Hull Shader Output Control Point Id Register Component Bit Count.
        /// </summary>
        public const uint HullShaderOutputControlPointIdRegisterComponentBitCount = 32;

        /// <summary>
        /// Hull Shader Output Control Point Id Register Count.
        /// </summary>
        public const uint HullShaderOutputControlPointIdRegisterCount = 1;

        /// <summary>
        /// Hull Shader Output Control Point Id Register Reads Per Instance.
        /// </summary>
        public const uint HullShaderOutputControlPointIdRegisterReadsPerInstance = 2;

        /// <summary>
        /// Hull Shader Output Control Point Id Register Read Ports.
        /// </summary>
        public const uint HullShaderOutputControlPointIdRegisterReadPorts = 1;

        /// <summary>
        /// Hull Shader Output Patch Constant Register Components.
        /// </summary>
        public const uint HullShaderOutputPatchConstantRegisterComponents = 4;

        /// <summary>
        /// Hull Shader Output Patch Constant Register Component Bit Count.
        /// </summary>
        public const uint HullShaderOutputPatchConstantRegisterComponentBitCount = 32;

        /// <summary>
        /// Hull Shader Output Patch Constant Register Count.
        /// </summary>
        public const uint HullShaderOutputPatchConstantRegisterCount = 32;

        /// <summary>
        /// Hull Shader Output Patch Constant Register Reads Per Instance.
        /// </summary>
        public const uint HullShaderOutputPatchConstantRegisterReadsPerInstance = 2;

        /// <summary>
        /// Hull Shader Output Patch Constant Register Read Ports.
        /// </summary>
        public const uint HullShaderOutputPatchConstantRegisterReadPorts = 1;

        /// <summary>
        /// Hull Shader Output Patch Constant Register Scalar Components.
        /// </summary>
        public const uint HullShaderOutputPatchConstantRegisterScalarComponents = 128;

        /// <summary>
        /// Input Assembler Default Index Buffer Offset In Bytes.
        /// </summary>
        public const uint InputAssemblerDefaultIndexBufferOffsetInBytes = 0;

        /// <summary>
        /// Input Assembler Default Primitive Topology.
        /// </summary>
        public const uint InputAssemblerDefaultPrimitiveTopology = 0;

        /// <summary>
        /// Input Assembler Default Vertex Buffer Offset In Bytes.
        /// </summary>
        public const uint InputAssemblerDefaultVertexBufferOffsetInBytes = 0;

        /// <summary>
        /// Input Assembler Index Input Resource Slot Count.
        /// </summary>
        public const uint InputAssemblerIndexInputResourceSlotCount = 1;

        /// <summary>
        /// Input Assembler Instance Id Bit Count.
        /// </summary>
        public const uint InputAssemblerInstanceIdBitCount = 32;

        /// <summary>
        /// Input Assembler Integer Arithmetic Bit Count.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer", Justification = "Reviewed")]
        public const uint InputAssemblerIntegerArithmeticBitCount = 32;

        /// <summary>
        /// Input Assembler Patch Max Control Point Count.
        /// </summary>
        public const uint InputAssemblerPatchMaxControlPointCount = 32;

        /// <summary>
        /// Input Assembler Primitive Id Bit Count.
        /// </summary>
        public const uint InputAssemblerPrimitiveIdBitCount = 32;

        /// <summary>
        /// Input Assembler Vertex Id Bit Count.
        /// </summary>
        public const uint InputAssemblerVertexIdBitCount = 32;

        /// <summary>
        /// Input Assembler Vertex Input Resource Slot Count.
        /// </summary>
        public const uint InputAssemblerVertexInputResourceSlotCount = 32;

        /// <summary>
        /// Input Assembler Vertex Input Structure Elements Components.
        /// </summary>
        public const uint InputAssemblerVertexInputStructureElementsComponents = 128;

        /// <summary>
        /// Input Assembler Vertex Input Structure Element Count.
        /// </summary>
        public const uint InputAssemblerVertexInputStructureElementCount = 32;

        /// <summary>
        /// Integer Divide By Zero Quotient.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer", Justification = "Reviewed")]
        public const uint IntegerDivideByZeroQuotient = 0xffffffff;

        /// <summary>
        /// Integer Divide By Zero Remainder.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer", Justification = "Reviewed")]
        public const uint IntegerDivideByZeroRemainder = 0xffffffff;

        /// <summary>
        /// Keep Render Targets And Depth Stencil.
        /// </summary>
        public const uint KeepRenderTargetsAndDepthStencil = 0xffffffff;

        /// <summary>
        /// Keep Unordered Access Views.
        /// </summary>
        public const uint KeepUnorderedAccessViews = 0xffffffff;

        /// <summary>
        /// Linear Gamma.
        /// </summary>
        public const float LinearGamma = 1.0f;

        /// <summary>
        /// Major Version.
        /// </summary>
        public const uint MajorVersion = 11;

        /// <summary>
        /// Max Border Color Component.
        /// </summary>
        public const float MaxBorderColorComponent = 1.0f;

        /// <summary>
        /// Max Depth.
        /// </summary>
        public const float MaxDepth = 1.0f;

        /// <summary>
        /// Max Anisotropy.
        /// </summary>
        public const uint MaxAnisotropy = 16;

        /// <summary>
        /// Max Multisample Sample Count.
        /// </summary>
        public const uint MaxMultisampleSampleCount = 32;

        /// <summary>
        /// Max Position Value.
        /// </summary>
        public const float MaxPositionValue = 3.402823466e+34f;

        /// <summary>
        /// Max Texture Dimension 2 To Exp.
        /// </summary>
        public const uint MaxTextureDimension2ToExp = 17;

        /// <summary>
        /// Minor Version.
        /// </summary>
        public const uint MinorVersion = 0;

        /// <summary>
        /// Min Border Color Component.
        /// </summary>
        public const float MinBorderColorComponent = 0.0f;

        /// <summary>
        /// Min Depth.
        /// </summary>
        public const float MinDepth = 0.0f;

        /// <summary>
        /// Min Max Anisotropy.
        /// </summary>
        public const uint MinMaxAnisotropy = 0;

        /// <summary>
        /// Mip Lod Bias Max.
        /// </summary>
        public const float MipLodBiasMax = 15.99f;

        /// <summary>
        /// Mip Lod Bias Min.
        /// </summary>
        public const float MipLodBiasMin = -16.0f;

        /// <summary>
        /// Mip Lod Fractional Bit Count.
        /// </summary>
        public const uint MipLodFractionalBitCount = 8;

        /// <summary>
        /// Mip Lod Range Bit Count.
        /// </summary>
        public const uint MipLodRangeBitCount = 8;

        /// <summary>
        /// Multisample Antialias Line Width.
        /// </summary>
        public const float MultisampleAntialiasLineWidth = 1.4f;

        /// <summary>
        /// Non Sample Fetch Out Of Range Access Result.
        /// </summary>
        public const uint NonSampleFetchOutOfRangeAccessResult = 0;

        /// <summary>
        /// Pixel Address Range Bit Count.
        /// </summary>
        public const uint PixelAddressRangeBitCount = 15;

        /// <summary>
        /// Pre Scissor Pixel Address Range Bit Count.
        /// </summary>
        public const uint PreScissorPixelAddressRangeBitCount = 16;

        /// <summary>
        /// Pixel Shader Compute Shader UAV Register Components.
        /// </summary>
        public const uint PixelShaderComputeShaderUavRegisterComponents = 1;

        /// <summary>
        /// Pixel Shader Compute Shader UAV Register Count.
        /// </summary>
        public const uint PixelShaderComputeShaderUavRegisterCount = 8;

        /// <summary>
        /// Pixel Shader Compute Shader UAV Register Reads Per Instance.
        /// </summary>
        public const uint PixelShaderComputeShaderUavRegisterReadsPerInstance = 1;

        /// <summary>
        /// Pixel Shader Compute Shader UAV Register Read Ports.
        /// </summary>
        public const uint PixelShaderComputeShaderUavRegisterReadPorts = 1;

        /// <summary>
        /// Pixel Shader Front Facing Default Value.
        /// </summary>
        public const uint PixelShaderFrontFacingDefaultValue = 0xFFFFFFFF;

        /// <summary>
        /// Pixel Shader Front Facing False Value.
        /// </summary>
        public const uint PixelShaderFrontFacingFalseValue = 0x00000000;

        /// <summary>
        /// Pixel Shader Front Facing True Value.
        /// </summary>
        public const uint PixelShaderFrontFacingTrueValue = 0xFFFFFFFF;

        /// <summary>
        /// Pixel Shader Input Register Components.
        /// </summary>
        public const uint PixelShaderInputRegisterComponents = 4;

        /// <summary>
        /// Pixel Shader Input Register Component Bit Count.
        /// </summary>
        public const uint PixelShaderInputRegisterComponentBitCount = 32;

        /// <summary>
        /// Pixel Shader Input Register Count.
        /// </summary>
        public const uint PixelShaderInputRegisterCount = 32;

        /// <summary>
        /// Pixel Shader Input Register Reads Per Instance.
        /// </summary>
        public const uint PixelShaderInputRegisterReadsPerInstance = 2;

        /// <summary>
        /// Pixel Shader Input Register Read Ports.
        /// </summary>
        public const uint PixelShaderInputRegisterReadPorts = 1;

        /// <summary>
        /// Pixel Shader Legacy Pixel Center Fractional Component.
        /// </summary>
        public const float PixelShaderLegacyPixelCenterFractionalComponent = 0.0f;

        /// <summary>
        /// Pixel Shader Output Depth Register Components.
        /// </summary>
        public const uint PixelShaderOutputDepthRegisterComponents = 1;

        /// <summary>
        /// Pixel Shader Output Depth Register Component Bit Count.
        /// </summary>
        public const uint PixelShaderOutputDepthRegisterComponentBitCount = 32;

        /// <summary>
        /// Pixel Shader Output Depth Register Count.
        /// </summary>
        public const uint PixelShaderOutputDepthRegisterCount = 1;

        /// <summary>
        /// Pixel Shader Output Mask Register Components.
        /// </summary>
        public const uint PixelShaderOutputMaskRegisterComponents = 1;

        /// <summary>
        /// Pixel Shader Output Mask Register Component Bit Count.
        /// </summary>
        public const uint PixelShaderOutputMaskRegisterComponentBitCount = 32;

        /// <summary>
        /// Pixel Shader Output Mask Register Count.
        /// </summary>
        public const uint PixelShaderOutputMaskRegisterCount = 1;

        /// <summary>
        /// Pixel Shader Output Register Components.
        /// </summary>
        public const uint PixelShaderOutputRegisterComponents = 4;

        /// <summary>
        /// Pixel Shader Output Register Component Bit Count.
        /// </summary>
        public const uint PixelShaderOutputRegisterComponentBitCount = 32;

        /// <summary>
        /// Pixel Shader Output Register Count.
        /// </summary>
        public const uint PixelShaderOutputRegisterCount = 8;

        /// <summary>
        /// Pixel Shader Pixel Center Fractional Component.
        /// </summary>
        public const float PixelShaderPixelCenterFractionalComponent = 0.5f;

        /// <summary>
        /// Raw UAV SRV Byte Alignment.
        /// </summary>
        public const uint RawUavSrvByteAlignment = 16;

        /// <summary>
        /// Req Blend Object Count Per Device.
        /// </summary>
        public const uint ReqBlendObjectCountPerDevice = 4096;

        /// <summary>
        /// Req Buffer Resource Texel Count 2 To Exp.
        /// </summary>
        public const uint ReqBufferResourceTexelCount2ToExp = 27;

        /// <summary>
        /// Req Constant Buffer Element Count.
        /// </summary>
        public const uint ReqConstantBufferElementCount = 4096;

        /// <summary>
        /// Req Depth Stencil Object Count Per Device.
        /// </summary>
        public const uint ReqDepthStencilObjectCountPerDevice = 4096;

        /// <summary>
        /// Req Draw Indexed Index Count 2 To Exp.
        /// </summary>
        public const uint ReqDrawIndexedIndexCount2ToExp = 32;

        /// <summary>
        /// Req Draw Vertex Count 2 To Exp.
        /// </summary>
        public const uint ReqDrawVertexCount2ToExp = 32;

        /// <summary>
        /// Req Filtering Hardware Addressable Resource Dimension.
        /// </summary>
        public const uint ReqFilteringHardwareAddressableResourceDimension = 16384;

        /// <summary>
        /// Req Geometry Shader Invocation 32 Bit Output Component Limit.
        /// </summary>
        public const uint ReqGeometryShaderInvocation32BitOutputComponentLimit = 1024;

        /// <summary>
        /// Req Immediate Constant Buffer Element Count.
        /// </summary>
        public const uint ReqImmediateConstantBufferElementCount = 4096;

        /// <summary>
        /// Req Max Anisotropy.
        /// </summary>
        public const uint ReqMaxAnisotropy = 16;

        /// <summary>
        /// Req Mip Levels.
        /// </summary>
        public const uint ReqMipLevels = 15;

        /// <summary>
        /// Req Multi Element Structure Size In Bytes.
        /// </summary>
        public const uint ReqMultiElementStructureSizeInBytes = 2048;

        /// <summary>
        /// Req Rasterizer Object Count Per Device.
        /// </summary>
        public const uint ReqRasterizerObjectCountPerDevice = 4096;

        /// <summary>
        /// Req Render To Buffer Window Width.
        /// </summary>
        public const uint ReqRenderToBufferWindowWidth = 16384;

        /// <summary>
        /// Req Resource Size In Megabytes Expression A Term.
        /// </summary>
        public const uint ReqResourceSizeInMegabytesExpressionATerm = 128;

        /// <summary>
        /// Req Resource Size In Megabytes Expression B Term.
        /// </summary>
        public const float ReqResourceSizeInMegabytesExpressionBTerm = 0.25f;

        /// <summary>
        /// Req Resource Size In Megabytes Expression C Term.
        /// </summary>
        public const uint ReqResourceSizeInMegabytesExpressionCTerm = 2048;

        /// <summary>
        /// Req Resource View Count Per Device 2 To Exp.
        /// </summary>
        public const uint ReqResourceViewCountPerDevice2ToExp = 20;

        /// <summary>
        /// Req Sampler Object Count Per Device.
        /// </summary>
        public const uint ReqSamplerObjectCountPerDevice = 4096;

        /// <summary>
        /// Req Texture 1D Array Axis Dimension.
        /// </summary>
        public const uint ReqTexture1DArrayAxisDimension = 2048;

        /// <summary>
        /// Req Texture 1D Dimension.
        /// </summary>
        public const uint ReqTexture1DDimension = 16384;

        /// <summary>
        /// Req Texture 2D Array Axis Dimension.
        /// </summary>
        public const uint ReqTexture2DArrayAxisDimension = 2048;

        /// <summary>
        /// Req Texture 2D Dimension.
        /// </summary>
        public const uint ReqTexture2DDimension = 16384;

        /// <summary>
        /// Req Texture 3D Dimension.
        /// </summary>
        public const uint ReqTexture3DDimension = 2048;

        /// <summary>
        /// Req Texture Cube Dimension.
        /// </summary>
        public const uint ReqTextureCubeDimension = 16384;

        /// <summary>
        /// Resinfo Instruction Missing Component Retval.
        /// </summary>
        public const uint ResinfoInstructionMissingComponentRetval = 0;

        /// <summary>
        /// Shader Major Version.
        /// </summary>
        public const uint ShaderMajorVersion = 5;

        /// <summary>
        /// Shader Max Instances.
        /// </summary>
        public const uint ShaderMaxInstances = 65535;

        /// <summary>
        /// Shader Max Interfaces.
        /// </summary>
        public const uint ShaderMaxInterfaces = 253;

        /// <summary>
        /// Shader Max Interface Call Sites.
        /// </summary>
        public const uint ShaderMaxInterfaceCallSites = 4096;

        /// <summary>
        /// Shader Max Types.
        /// </summary>
        public const uint ShaderMaxTypes = 65535;

        /// <summary>
        /// Shader Minor Version.
        /// </summary>
        public const uint ShaderMinorVersion = 0;

        /// <summary>
        /// Shift Instruction Pad Value.
        /// </summary>
        public const uint ShiftInstructionPadValue = 0;

        /// <summary>
        /// Shift Instruction Shift Value Bit Count.
        /// </summary>
        public const uint ShiftInstructionShiftValueBitCount = 5;

        /// <summary>
        /// Simultaneous Render Target Count.
        /// </summary>
        public const uint SimultaneousRenderTargetCount = 8;

        /// <summary>
        /// Stream Output Buffer Max Stride In Bytes.
        /// </summary>
        public const uint StreamOutputBufferMaxStrideInBytes = 2048;

        /// <summary>
        /// Stream Output Buffer Max Write Window In Bytes.
        /// </summary>
        public const uint StreamOutputBufferMaxWriteWindowInBytes = 512;

        /// <summary>
        /// Stream Output Buffer Slot Count.
        /// </summary>
        public const uint StreamOutputBufferSlotCount = 4;

        /// <summary>
        /// Stream Output Ddi Register Index Denoting Gap.
        /// </summary>
        public const uint StreamOutputDdiRegisterIndexDenotingGap = 0xffffffff;

        /// <summary>
        /// Stream Output No Rasterized Stream.
        /// </summary>
        public const uint StreamOutputNoRasterizedStream = 0xffffffff;

        /// <summary>
        /// Stream Output Output Component Count.
        /// </summary>
        public const uint StreamOutputOutputComponentCount = 128;

        /// <summary>
        /// Stream Output Stream Count.
        /// </summary>
        public const uint StreamOutputStreamCount = 4;

        /// <summary>
        /// Spec Date Day.
        /// </summary>
        public const uint SpecDateDay = 16;

        /// <summary>
        /// Spec Date Month.
        /// </summary>
        public const uint SpecDateMonth = 05;

        /// <summary>
        /// Spec Date Year.
        /// </summary>
        public const uint SpecDateYear = 2011;

        /// <summary>
        /// Spec Version.
        /// </summary>
        public const float SpecVersion = 1.07f;

        /// <summary>
        /// Srgb Gamma.
        /// </summary>
        public const float SrgbGamma = 2.2f;

        /// <summary>
        /// Srgb To Float Denominator 1.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float SrgbToFloatDenominator1 = 12.92f;

        /// <summary>
        /// Srgb To Float Denominator 2.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float SrgbToFloatDenominator2 = 1.055f;

        /// <summary>
        /// Srgb To Float Exponent.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float SrgbToFloatExponent = 2.4f;

        /// <summary>
        /// Srgb To Float Offset.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float SrgbToFloatOffset = 0.055f;

        /// <summary>
        /// Srgb To Float Threshold.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float SrgbToFloatThreshold = 0.04045f;

        /// <summary>
        /// Srgb To Float Tolerance In Ulp.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "float", Justification = "Reviewed")]
        public const float SrgbToFloatToleranceInUlp = 0.5f;

        /// <summary>
        /// Standard Component Bit Count.
        /// </summary>
        public const uint StandardComponentBitCount = 32;

        /// <summary>
        /// Standard Component Bit Count Doubled.
        /// </summary>
        public const uint StandardComponentBitCountDoubled = 64;

        /// <summary>
        /// Standard Maximum Element Alignment Byte Multiple.
        /// </summary>
        public const uint StandardMaximumElementAlignmentByteMultiple = 4;

        /// <summary>
        /// Standard Pixel Component Count.
        /// </summary>
        public const uint StandardPixelComponentCount = 128;

        /// <summary>
        /// Standard Pixel Element Count.
        /// </summary>
        public const uint StandardPixelElementCount = 32;

        /// <summary>
        /// Standard Vector Size.
        /// </summary>
        public const uint StandardVectorSize = 4;

        /// <summary>
        /// Standard Vertex Element Count.
        /// </summary>
        public const uint StandardVertexElementCount = 32;

        /// <summary>
        /// Standard Vertex Total Component Count.
        /// </summary>
        public const uint StandardVertexTotalComponentCount = 64;

        /// <summary>
        /// Subpixel Fractional Bit Count.
        /// </summary>
        public const uint SubpixelFractionalBitCount = 8;

        /// <summary>
        /// Subtexel Fractional Bit Count.
        /// </summary>
        public const uint SubtexelFractionalBitCount = 8;

        /// <summary>
        /// Tesselator Max Even Tessellation Factor.
        /// </summary>
        public const uint TesselatorMaxEvenTessellationFactor = 64;

        /// <summary>
        /// Tesselator Max Isoline Density Tessellation Factor.
        /// </summary>
        public const uint TesselatorMaxIsolineDensityTessellationFactor = 64;

        /// <summary>
        /// Tesselator Max Odd Tessellation Factor.
        /// </summary>
        public const uint TesselatorMaxOddTessellationFactor = 63;

        /// <summary>
        /// Tesselator Max Tessellation Factor.
        /// </summary>
        public const uint TesselatorMaxTessellationFactor = 64;

        /// <summary>
        /// Tesselator Min Even Tessellation Factor.
        /// </summary>
        public const uint TesselatorMinEvenTessellationFactor = 2;

        /// <summary>
        /// Tesselator Min Isoline Density Tessellation Factor.
        /// </summary>
        public const uint TesselatorMinIsolineDensityTessellationFactor = 1;

        /// <summary>
        /// Tesselator Min Odd Tessellation Factor.
        /// </summary>
        public const uint TesselatorMinOddTessellationFactor = 1;

        /// <summary>
        /// Texel Address Range Bit Count.
        /// </summary>
        public const uint TexelAddressRangeBitCount = 16;

        /// <summary>
        /// Unbound Memory Access Result.
        /// </summary>
        public const uint UnboundMemoryAccessResult = 0;

        /// <summary>
        /// Viewport And Scissor Rect Max Index.
        /// </summary>
        public const uint ViewportAndScissorRectMaxIndex = 15;

        /// <summary>
        /// Viewport And Scissor Rect Object Count Per Pipeline.
        /// </summary>
        public const uint ViewportAndScissorRectObjectCountPerPipeline = 16;

        /// <summary>
        /// Viewport Bounds Max.
        /// </summary>
        public const uint ViewportBoundsMax = 32767;

        /// <summary>
        /// Viewport Bounds Min.
        /// </summary>
        public const int ViewportBoundsMin = -32768;

        /// <summary>
        /// Vertex Shader Input Register Components.
        /// </summary>
        public const uint VertexShaderInputRegisterComponents = 4;

        /// <summary>
        /// Vertex Shader Input Register Component Bit Count.
        /// </summary>
        public const uint VertexShaderInputRegisterComponentBitCount = 32;

        /// <summary>
        /// Vertex Shader Input Register Count.
        /// </summary>
        public const uint VertexShaderInputRegisterCount = 32;

        /// <summary>
        /// Vertex Shader Input Register Reads Per Instance.
        /// </summary>
        public const uint VertexShaderInputRegisterReadsPerInstance = 2;

        /// <summary>
        /// Vertex Shader Input Register Read Ports.
        /// </summary>
        public const uint VertexShaderInputRegisterReadPorts = 1;

        /// <summary>
        /// Vertex Shader Output Register Components.
        /// </summary>
        public const uint VertexShaderOutputRegisterComponents = 4;

        /// <summary>
        /// Vertex Shader Output Register Component Bit Count.
        /// </summary>
        public const uint VertexShaderOutputRegisterComponentBitCount = 32;

        /// <summary>
        /// Vertex Shader Output Register Count.
        /// </summary>
        public const uint VertexShaderOutputRegisterCount = 32;

        /// <summary>
        /// WHQL Context Count For Resource Limit.
        /// </summary>
        public const uint WhqlContextCountForResourceLimit = 10;

        /// <summary>
        /// WHQL Draw Indexed Index Count 2 To Exp.
        /// </summary>
        public const uint WhqlDrawIndexedIndexCount2ToExp = 25;

        /// <summary>
        /// WHQL Draw Vertex Count 2 To Exp.
        /// </summary>
        public const uint WhqlDrawVertexCount2ToExp = 25;

        /// <summary>
        /// Unordered Access View Slot Count.
        /// </summary>
        public const uint UnorderedAccessViewSlotCount = 64;

        /// <summary>
        /// Tiled Resource Tile Size In Bytes.
        /// </summary>
        public const uint TiledResourceTileSizeInBytes = 65536;
    }
}
