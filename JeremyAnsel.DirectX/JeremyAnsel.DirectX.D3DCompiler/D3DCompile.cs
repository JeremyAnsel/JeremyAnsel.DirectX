﻿// <copyright file="D3DCompile.cs" company="Jérémy Ansel">
// Copyright (c) 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler
{
    using JeremyAnsel.DirectX.D3DCompiler.ComInterfaces;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Contains methods for compiling HLSL shaders.
    /// </summary>
    public static class D3DCompile
    {
        /// <summary>
        /// Compile HLSL code or an effect file into bytecode for a given target.
        /// </summary>
        /// <param name="sourceData">Uncompiled shader data.</param>
        /// <param name="sourceName">You can use this parameter for strings that specify error messages. If not used, set to <c>NULL</c>.</param>
        /// <param name="defines">An array of macro definitions.</param>
        /// <param name="entrypoint">The name of the shader entry point function where shader execution begins.</param>
        /// <param name="target">A string that specifies the shader target or set of shader features to compile against.</param>
        /// <param name="options">Constants that specify how the compiler compiles the HLSL code.</param>
        /// <param name="code">A pointer to a variable that receives the compiled code.</param>
        /// <param name="errorMessages">A pointer to a variable that receives compiler error messages, or <c>NULL</c> if there are no errors.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Compile(string sourceData, string sourceName, D3DShaderMacro[] defines, string entrypoint, string target, D3DCompileOptions options, out byte[] code, out string errorMessages)
        {
            if (string.IsNullOrEmpty(sourceData))
            {
                throw new ArgumentNullException(nameof(sourceData));
            }

            if (string.IsNullOrEmpty(sourceName))
            {
                sourceName = "Unknown";
            }

            if (string.IsNullOrEmpty(entrypoint))
            {
                throw new ArgumentNullException(nameof(entrypoint));
            }

            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException(nameof(target));
            }

            IntPtr[] definesPtr = null;

            if (defines != null && defines.Length != 0)
            {
                definesPtr = new IntPtr[defines.Length * 2 + 2];

                for (int i = 0; i < defines.Length; i++)
                {
                    definesPtr[i * 2 + 0] = Marshal.StringToHGlobalAnsi(defines[i].Name);
                    definesPtr[i * 2 + 1] = Marshal.StringToHGlobalAnsi(defines[i].Definition);
                }

                definesPtr[defines.Length * 2 + 0] = IntPtr.Zero;
                definesPtr[defines.Length * 2 + 1] = IntPtr.Zero;
            }

            int hr = 0;
            ID3DBlob codeBlob = null;
            ID3DBlob errorMessagesBlob = null;

            try
            {
                hr = NativeMethods.D3DCompile(
                    sourceData,
                    new IntPtr(Encoding.ASCII.GetByteCount(sourceData)),
                    sourceName,
                    definesPtr,
                    new IntPtr(1), // D3D_COMPILE_STANDARD_FILE_INCLUDE
                    entrypoint,
                    target,
                    options,
                    0,
                    out codeBlob,
                    out errorMessagesBlob);
            }
            finally
            {
                if (definesPtr != null)
                {
                    for (int i = 0; i < definesPtr.Length; i++)
                    {
                        Marshal.FreeHGlobal(definesPtr[i]);
                    }
                }
            }

            try
            {
                if (codeBlob != null)
                {
                    IntPtr ptr = codeBlob.GetBufferPointer();
                    int length = (int)codeBlob.GetBufferSize().ToUInt32();

                    var bytes = new byte[length];
                    Marshal.Copy(ptr, bytes, 0, length);
                    code = bytes;
                }
                else
                {
                    code = null;
                }

                if (errorMessagesBlob != null)
                {
                    IntPtr ptr = errorMessagesBlob.GetBufferPointer();
                    int length = (int)errorMessagesBlob.GetBufferSize().ToUInt32();

                    var bytes = new byte[length];
                    Marshal.Copy(ptr, bytes, 0, length);
                    errorMessages = Encoding.ASCII.GetString(bytes);
                }
                else
                {
                    errorMessages = null;
                }
            }
            finally
            {
                if (codeBlob != null)
                {
                    Marshal.ReleaseComObject(codeBlob);
                }

                if (errorMessagesBlob != null)
                {
                    Marshal.ReleaseComObject(errorMessagesBlob);
                }
            }

            if (hr != 0)
            {
                throw new ExternalException(errorMessages, hr);
            }
        }

        /// <summary>
        /// Compile HLSL code or an effect file into bytecode for a given target.
        /// </summary>
        /// <param name="sourceData">Uncompiled shader data.</param>
        /// <param name="sourceName">You can use this parameter for strings that specify error messages. If not used, set to <c>NULL</c>.</param>
        /// <param name="entrypoint">The name of the shader entry point function where shader execution begins.</param>
        /// <param name="target">A string that specifies the shader target or set of shader features to compile against.</param>
        /// <param name="options">Constants that specify how the compiler compiles the HLSL code.</param>
        /// <param name="code">A pointer to a variable that receives the compiled code.</param>
        /// <param name="errorMessages">A pointer to a variable that receives compiler error messages, or <c>NULL</c> if there are no errors.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Compile(string sourceData, string sourceName, string entrypoint, string target, D3DCompileOptions options, out byte[] code, out string errorMessages)
        {
            D3DCompile.Compile(sourceData, sourceName, null, entrypoint, target, options, out code, out errorMessages);
        }

        /// <summary>
        /// Compile HLSL code or an effect file into bytecode for a given target.
        /// </summary>
        /// <param name="sourceFileName">The name of the file that contains the shader code.</param>
        /// <param name="defines">An array of macro definitions.</param>
        /// <param name="entrypoint">The name of the shader entry point function where shader execution begins.</param>
        /// <param name="target">A string that specifies the shader target or set of shader features to compile against.</param>
        /// <param name="options">Constants that specify how the compiler compiles the HLSL code.</param>
        /// <param name="code">A pointer to a variable that receives the compiled code.</param>
        /// <param name="errorMessages">A pointer to a variable that receives compiler error messages, or <c>NULL</c> if there are no errors.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompileFromFile(string sourceFileName, D3DShaderMacro[] defines, string entrypoint, string target, D3DCompileOptions options, out byte[] code, out string errorMessages)
        {
            if (string.IsNullOrEmpty(sourceFileName))
            {
                throw new ArgumentNullException(nameof(sourceFileName));
            }

            string sourceData = File.ReadAllText(sourceFileName);
            D3DCompile.Compile(sourceData, Path.GetFileName(sourceFileName), defines, entrypoint, target, options, out code, out errorMessages);
        }

        /// <summary>
        /// Compile HLSL code or an effect file into bytecode for a given target.
        /// </summary>
        /// <param name="sourceFileName">The name of the file that contains the shader code.</param>
        /// <param name="entrypoint">The name of the shader entry point function where shader execution begins.</param>
        /// <param name="target">A string that specifies the shader target or set of shader features to compile against.</param>
        /// <param name="options">Constants that specify how the compiler compiles the HLSL code.</param>
        /// <param name="code">A pointer to a variable that receives the compiled code.</param>
        /// <param name="errorMessages">A pointer to a variable that receives compiler error messages, or <c>NULL</c> if there are no errors.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompileFromFile(string sourceFileName, string entrypoint, string target, D3DCompileOptions options, out byte[] code, out string errorMessages)
        {
            D3DCompile.CompileFromFile(sourceFileName, null, entrypoint, target, options, out code, out errorMessages);
        }

        /// <summary>
        /// Disassembles compiled HLSL code.
        /// </summary>
        /// <param name="sourceData">The source data as compiled HLSL code.</param>
        /// <param name="options">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
        /// <param name="comments">The comment string at the top of the shader that identifies the shader constants and variables.</param>
        /// <returns>The assembly text.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Disassemble(byte[] sourceData, D3DDisassembleOptions options, string comments)
        {
            if (sourceData == null)
            {
                throw new ArgumentNullException(nameof(sourceData));
            }

            if (comments != null && !comments.EndsWith("\n", StringComparison.Ordinal))
            {
                comments += "\n";
            }

            NativeMethods.D3DDisassemble(sourceData, new IntPtr(sourceData.Length), options, comments, out ID3DBlob disassemblyBlob);

            try
            {
                IntPtr ptr = disassemblyBlob.GetBufferPointer();
                int length = (int)disassemblyBlob.GetBufferSize().ToUInt32();

                var bytes = new byte[length];
                Marshal.Copy(ptr, bytes, 0, length);
                return Encoding.ASCII.GetString(bytes);
            }
            finally
            {
                if (disassemblyBlob != null)
                {
                    Marshal.ReleaseComObject(disassemblyBlob);
                }
            }
        }

        /// <summary>
        /// Disassembles compiled HLSL code.
        /// </summary>
        /// <param name="sourceData">The source data as compiled HLSL code.</param>
        /// <param name="options">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
        /// <returns>The assembly text.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Disassemble(byte[] sourceData, D3DDisassembleOptions options)
        {
            return D3DCompile.Disassemble(sourceData, options, null);
        }

        /// <summary>
        /// Disassembles compiled HLSL code.
        /// </summary>
        /// <param name="sourceData">The source data as compiled HLSL code.</param>
        /// <returns>The assembly text.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Disassemble(byte[] sourceData)
        {
            return D3DCompile.Disassemble(sourceData, D3DDisassembleOptions.None, null);
        }
    }
}
