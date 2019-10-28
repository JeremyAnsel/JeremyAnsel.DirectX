// <copyright file="D3DCompileOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler
{
    using System;

    /// <summary>
    /// These constants specify how the compiler compiles the HLSL code.
    /// </summary>
    [Flags]
    public enum D3DCompileOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Directs the compiler to insert debug file/line/type/symbol information into the output code.
        /// </summary>
        Debug = 1 << 0,

        /// <summary>
        /// Directs the compiler not to validate the generated code against known capabilities and constraints. We recommend that you use this constant only with shaders that have been successfully compiled in the past. DirectX always validates shaders before it sets them to a device.
        /// </summary>
        SkipValidation = 1 << 1,

        /// <summary>
        /// Directs the compiler to skip optimization steps during code generation. We recommend that you set this constant for debug purposes only.
        /// </summary>
        SkipOptimization = 1 << 2,

        /// <summary>
        /// Directs the compiler to pack matrices in row-major order on input and output from the shader.
        /// </summary>
        PackMatrixRowMajor = 1 << 3,

        /// <summary>
        /// Directs the compiler to pack matrices in column-major order on input and output from the shader. This type of packing is generally more efficient because a series of dot-products can then perform vector-matrix multiplication.
        /// </summary>
        PackMatrixColumnMajor = 1 << 4,

        /// <summary>
        /// Directs the compiler to perform all computations with partial precision. If you set this constant, the compiled code might run faster on some hardware.
        /// </summary>
        PartialPrecision = 1 << 5,

        /// <summary>
        /// Directs the compiler to compile a vertex shader for the next highest shader profile. This constant turns debugging on and optimizations off.
        /// </summary>
        ForceVertexShaderSoftwareNoOptimization = 1 << 6,

        /// <summary>
        /// Directs the compiler to compile a pixel shader for the next highest shader profile. This constant also turns debugging on and optimizations off.
        /// </summary>
        ForcePixelShaderSoftwareNoOptimization = 1 << 7,

        /// <summary>
        /// Directs the compiler to disable Preshaders. If you set this constant, the compiler does not pull out static expression for evaluation.
        /// </summary>
        NoPreshader = 1 << 8,

        /// <summary>
        /// Directs the compiler to not use flow-control constructs where possible.
        /// </summary>
        AvoidFlowControl = 1 << 9,

        /// <summary>
        /// Directs the compiler to use flow-control constructs where possible.
        /// </summary>
        PreferFlowControl = 1 << 10,

        /// <summary>
        /// Forces strict compile, which might not allow for legacy syntax. By default, the compiler disables strictness on deprecated syntax.
        /// </summary>
        EnableStrictness = 1 << 11,

        /// <summary>
        /// Directs the compiler to enable older shaders to compile to 5_0 targets.
        /// </summary>
        EnableBackwardsCompatibility = 1 << 12,

        /// <summary>
        /// Forces the IEEE strict compile.
        /// </summary>
        IEEEStrictness = 1 << 13,

        /// <summary>
        /// Directs the compiler to use the lowest optimization level. If you set this constant, the compiler might produce slower code but produces the code more quickly. Set this constant when you develop the shader iteratively.
        /// </summary>
        OptimizationLevel0 = 1 << 14,

        /// <summary>
        /// Directs the compiler to use the second lowest optimization level.
        /// </summary>
        OptimizationLevel1 = 0,

        /// <summary>
        /// Directs the compiler to use the second highest optimization level.
        /// </summary>
        OptimizationLevel2 = (1 << 14) | (1 << 15),

        /// <summary>
        /// Directs the compiler to use the highest optimization level. If you set this constant, the compiler produces the best possible code but might take significantly longer to do so. Set this constant for final builds of an application when performance is the most important factor.
        /// </summary>
        OptimizationLevel3 = 1 << 15,

        /// <summary>
        /// Directs the compiler to treat all warnings as errors when it compiles the shader code. We recommend that you use this constant for new shader code, so that you can resolve all warnings and lower the number of hard-to-find code defects.
        /// </summary>
        WarningsAreErrors = 1 << 18,

        /// <summary>
        /// Directs the compiler to assume that unordered access views (UAVs) and shader resource views (SRVs) may alias for cs_5_0.
        /// </summary>
        ResourcesMayAlias = 1 << 19,

        /// <summary>
        /// Directs the compiler to enable unbounded descriptor tables.
        /// </summary>
        EnableUnboundedDescriptorTables = 1 << 20,

        /// <summary>
        /// Directs the compiler to ensure all resources are bound.
        /// </summary>
        AllResourcesBound = 1 << 21
    }
}
