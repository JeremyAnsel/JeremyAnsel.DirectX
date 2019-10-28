// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler
{
    using JeremyAnsel.DirectX.D3DCompiler.ComInterfaces;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Native methods.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
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
        [DllImport("D3dcompiler_47.dll", EntryPoint = "D3DCompile", PreserveSig = true)]
        [SuppressMessage("Globalization", "CA2101:Spécifier le marshaling pour les arguments de chaîne P/Invoke", Justification = "Reviewed.")]
        public static extern int D3DCompile(
            [In, MarshalAs(UnmanagedType.LPStr)] string srcData,
            [In] IntPtr srcDataSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string sourceName,
            [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] pDefines,
            [In] IntPtr pInclude,
            [In, MarshalAs(UnmanagedType.LPStr)] string entrypoint,
            [In, MarshalAs(UnmanagedType.LPStr)] string target,
            [In] D3DCompileOptions flags1,
            [In] uint flags2,
            [Out] out ID3DBlob ppCode,
            [Out] out ID3DBlob ppErrorMsgs);

        /// <summary>
        /// Disassembles compiled HLSL code.
        /// </summary>
        /// <param name="sourceData">A pointer to source data as compiled HLSL code.</param>
        /// <param name="sourceDataSize">Length of <c>pSrcData</c>.</param>
        /// <param name="flags">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
        /// <param name="comments">The comment string at the top of the shader that identifies the shader constants and variables.</param>
        /// <param name="ppDisassembly">A pointer to a buffer that receives the <c>ID3DBlob</c> interface that accesses assembly text.</param>
        [DllImport("D3dcompiler_47.dll", EntryPoint = "D3DDisassemble", PreserveSig = false)]
        [SuppressMessage("Globalization", "CA2101:Spécifier le marshaling pour les arguments de chaîne P/Invoke", Justification = "Reviewed.")]
        public static extern void D3DDisassemble(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] sourceData,
            [In] IntPtr sourceDataSize,
            [In] D3DDisassembleOptions flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string comments,
            [Out] out ID3DBlob ppDisassembly);
    }
}
