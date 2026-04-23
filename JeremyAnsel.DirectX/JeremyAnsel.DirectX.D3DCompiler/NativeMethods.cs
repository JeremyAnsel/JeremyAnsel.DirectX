// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3DCompiler;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
    /// <summary>
    /// Compile HLSL code or an effect file into bytecode for a given target.
    /// </summary>
    /// <param name="srcData">A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</param>
    /// <param name="srcDataSize">Length of pSrcData.</param>
    /// <param name="sourceName">You can use this parameter for strings that specify error messages. If not used, set to <c>NULL</c>.</param>
    /// <param name="pDefines">An array of NULL-terminated macro definitions.</param>
    /// <param name="pInclude">A pointer to an <c>ID3DInclude</c> for handling include files.</param>
    /// <param name="entrypoint">The name of the shader entry point function where shader execution begins.</param>
    /// <param name="target">A string that specifies the shader target or set of shader features to compile against.</param>
    /// <param name="flags1">These constants specify how the compiler compiles the HLSL code.</param>
    /// <param name="flags2">These constants direct how the compiler compiles an effect file or how the runtime processes the effect file.</param>
    /// <param name="ppCode">A pointer to a variable that receives a pointer to the <c>ID3DBlob</c> interface that you can use to access the compiled code.</param>
    /// <param name="ppErrorMsgs">A pointer to a variable that receives a pointer to the <c>ID3DBlob</c> interface that you can use to access compiler error messages, or <c>NULL</c> if there are no errors.</param>

#if NET8_0_OR_GREATER
    [LibraryImport("D3dcompiler_47.dll", EntryPoint = "D3DCompile")]
    public static partial int D3DCompile(
#else
    [DllImport("D3dcompiler_47.dll", EntryPoint = "D3DCompile")]
    public static extern int D3DCompile(
#endif
        void* srcData,
        nint srcDataSize,
        void* sourceName,
        void* pDefines,
        nint pInclude,
        void* entrypoint,
        void* target,
        D3DCompileOptions flags1,
        uint flags2,
        nint* ppCode,
        nint* ppErrorMsgs);

#if NET8_0_OR_GREATER
    [LibraryImport("D3dcompiler_47.dll", EntryPoint = "D3DCompileFromFile")]
    public static partial int D3DCompileFromFile(
#else
    [DllImport("D3dcompiler_47.dll", EntryPoint = "D3DCompileFromFile")]
    public static extern int D3DCompileFromFile(
#endif
        void* sourceFileName,
        void* pDefines,
        nint pInclude,
        void* entrypoint,
        void* target,
        D3DCompileOptions flags1,
        uint flags2,
        nint* ppCode,
        nint* ppErrorMsgs);

    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">A pointer to source data as compiled HLSL code.</param>
    /// <param name="sourceDataSize">Length of <c>pSrcData</c>.</param>
    /// <param name="flags">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
    /// <param name="comments">The comment string at the top of the shader that identifies the shader constants and variables.</param>
    /// <param name="ppDisassembly">A pointer to a buffer that receives the <c>ID3DBlob</c> interface that accesses assembly text.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("D3dcompiler_47.dll", EntryPoint = "D3DDisassemble")]
    public static partial int D3DDisassemble(
#else
    [DllImport("D3dcompiler_47.dll", EntryPoint = "D3DDisassemble")]
    public static extern int D3DDisassemble(
#endif
        void* sourceData,
        nint sourceDataSize,
        D3DDisassembleOptions flags,
        void* comments,
        nint* ppDisassembly);
}
