// <copyright file="D3DCompile.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3DCompiler.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.D3DCompiler;

/// <summary>
/// Contains methods for compiling HLSL shaders.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public static unsafe class D3DCompile
{
    private static string? _includeRootDirectory = null;
    private static readonly Stack<string> _includeDirectories = new();

    private static readonly IncludeOpenCallBack _includeOpenCallback = new(IncludeOpen);
    private static readonly IncludeCloseCallBack _includeCloseCallback = new(IncludeClose);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate int IncludeOpenCallBack(nint thisPtr, D3DIncludeLocation includeLocation, nint fileNameRef, nint pParentData, out nint dataRef, out int bytesRef);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate int IncludeCloseCallBack(nint thisPtr, nint pData);

    private static int IncludeOpen(nint thisPtr, D3DIncludeLocation includeLocation, nint fileNameRef, nint pParentData, out nint dataRef, out int bytesRef)
    {
        string fileName = Marshal.PtrToStringAnsi(fileNameRef)!;
        string includeDirectory = includeLocation == D3DIncludeLocation.Local ? _includeDirectories.Peek() : _includeRootDirectory!;
        string sourceFileName = Path.GetFullPath(Path.Combine(includeDirectory, fileName));

        string sourceData = File.ReadAllText(sourceFileName);

        bytesRef = Encoding.UTF8.GetByteCount(sourceData);
        dataRef = Marshal.AllocHGlobal(bytesRef);

        fixed (char* src = sourceData)
        {
            Encoding.UTF8.GetBytes(src, sourceData.Length, (byte*)dataRef, bytesRef);
        }

        _includeDirectories.Push(Path.GetDirectoryName(sourceFileName)!);
        return 0;
    }

    private static int IncludeClose(nint thisPtr, nint pData)
    {
        Marshal.FreeHGlobal(pData);

        _includeDirectories.Pop();
        return 0;
    }

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
    public static D3DCompileResult Compile(ReadOnlySpan<char> sourceData, string? sourceName, ReadOnlySpan<D3DShaderMacro> defines, string? entrypoint, string? target, D3DCompileOptions options)
    {
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

        int definesCount = defines.Length == 0 ? 0 : (defines.Length * 2 + 2);
        nint* definesPtr = stackalloc nint[definesCount];

        if (defines.Length != 0)
        {
            for (int i = 0; i < defines.Length; i++)
            {
                definesPtr[i * 2 + 0] = Marshal.StringToHGlobalAnsi(defines[i].Name);
                definesPtr[i * 2 + 1] = Marshal.StringToHGlobalAnsi(defines[i].Definition);
            }

            definesPtr[defines.Length * 2 + 0] = 0;
            definesPtr[defines.Length * 2 + 1] = 0;
        }

        nint includePointer = 0;

        if (_includeDirectories.Count != 0)
        {
            includePointer = Marshal.AllocHGlobal(sizeof(nint) * 3);
            Marshal.WriteIntPtr(includePointer, includePointer + sizeof(nint));
            Marshal.WriteIntPtr(includePointer + sizeof(nint), Marshal.GetFunctionPointerForDelegate(_includeOpenCallback));
            Marshal.WriteIntPtr(includePointer + sizeof(nint) * 2, Marshal.GetFunctionPointerForDelegate(_includeCloseCallback));
        }

        int hr = 0;
        nint codeBlobPtr = 0;
        nint errorMessagesBlobPtr = 0;

        int sourceDataSize;
        nint sourceDataPtr;
        fixed (char* ptr = sourceData)
        {
            sourceDataSize = Encoding.UTF8.GetByteCount(ptr, sourceData.Length);
            sourceDataPtr = Marshal.AllocHGlobal(sourceDataSize);
            Encoding.UTF8.GetBytes(ptr, sourceData.Length, (byte*)sourceDataPtr, sourceDataSize);
        }

        try
        {
            int sourceNameSize = Encoding.UTF8.GetByteCount(sourceName);
            byte* sourceNamePtr = stackalloc byte[sourceNameSize + 1];
            sourceNamePtr[sourceNameSize] = 0;
            fixed (char* ptr = sourceName)
            {
                Encoding.UTF8.GetBytes(ptr, sourceName!.Length, sourceNamePtr, sourceNameSize);
            }

            int entrypointSize = Encoding.UTF8.GetByteCount(entrypoint);
            byte* entrypointPtr = stackalloc byte[entrypointSize + 1];
            entrypointPtr[entrypointSize] = 0;
            fixed (char* ptr = entrypoint)
            {
                Encoding.UTF8.GetBytes(ptr, entrypoint!.Length, entrypointPtr, entrypointSize);
            }

            int targetSize = Encoding.UTF8.GetByteCount(target);
            byte* targetPtr = stackalloc byte[targetSize + 1];
            targetPtr[targetSize] = 0;
            fixed (char* ptr = target)
            {
                Encoding.UTF8.GetBytes(ptr, target!.Length, targetPtr, targetSize);
            }

            hr = NativeMethods.D3DCompile(
                (void*)sourceDataPtr,
                sourceDataSize,
                sourceNamePtr,
                definesPtr,
                includePointer != 0 ? includePointer : 1, // D3D_COMPILE_STANDARD_FILE_INCLUDE
                entrypointPtr,
                targetPtr,
                options,
                0,
                &codeBlobPtr,
                &errorMessagesBlobPtr);
        }
        finally
        {
            Marshal.FreeHGlobal(sourceDataPtr);

            if (includePointer != 0)
            {
                Marshal.FreeHGlobal(includePointer);
            }

            if (definesPtr is not null)
            {
                for (int i = 0; i < definesCount; i++)
                {
                    Marshal.FreeHGlobal(definesPtr[i]);
                }
            }
        }

        try
        {
            if (hr != 0)
            {
                string? errorMessage = null;

                if (errorMessagesBlobPtr != 0)
                {
                    ID3DBlob* errorMessagesBlobImpl = *(ID3DBlob**)errorMessagesBlobPtr;
                    nint ptr = errorMessagesBlobImpl->GetBufferPointer(errorMessagesBlobPtr);
                    int length = (int)errorMessagesBlobImpl->GetBufferSize(errorMessagesBlobPtr);
                    errorMessage = new string((sbyte*)ptr, 0, length, Encoding.UTF8);
                }

                throw new ExternalException(errorMessage, hr);
            }
        }
        catch
        {
            DXUtils.Release(codeBlobPtr);
            throw;
        }
        finally
        {
            DXUtils.Release(errorMessagesBlobPtr);
        }

        return new D3DCompileResult(codeBlobPtr);
    }

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
    public static D3DCompileResult Compile(string? sourceData, string? sourceName, D3DShaderMacro[]? defines, string? entrypoint, string? target, D3DCompileOptions options)
    {
        if (string.IsNullOrEmpty(sourceData))
        {
            throw new ArgumentNullException(nameof(sourceData));
        }

        return Compile(sourceData.AsSpan(), sourceName, defines.AsSpan(), entrypoint, target, options);
    }

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
    public static D3DCompileResult Compile(ReadOnlySpan<char> sourceData, string? sourceName, D3DShaderMacro[]? defines, string? entrypoint, string? target, D3DCompileOptions options)
    {
        return Compile(sourceData, sourceName, defines.AsSpan(), entrypoint, target, options);
    }

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
    public static D3DCompileResult Compile(string? sourceData, string? sourceName, ReadOnlySpan<D3DShaderMacro> defines, string? entrypoint, string? target, D3DCompileOptions options)
    {
        if (string.IsNullOrEmpty(sourceData))
        {
            throw new ArgumentNullException(nameof(sourceData));
        }

        return Compile(sourceData.AsSpan(), sourceName, defines, entrypoint, target, options);
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
    public static D3DCompileResult Compile(string? sourceData, string? sourceName, string? entrypoint, string? target, D3DCompileOptions options)
    {
        return Compile(sourceData, sourceName, null, entrypoint, target, options);
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
    public static D3DCompileResult Compile(ReadOnlySpan<char> sourceData, string? sourceName, string? entrypoint, string? target, D3DCompileOptions options)
    {
        return Compile(sourceData, sourceName, [], entrypoint, target, options);
    }

    private static readonly byte[] _bomBytes = new byte[3];

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
    public static D3DCompileResult CompileFromFile(string? sourceFileName, ReadOnlySpan<D3DShaderMacro> defines, string? entrypoint, string? target, D3DCompileOptions options)
    {
        if (string.IsNullOrEmpty(sourceFileName))
        {
            throw new ArgumentNullException(nameof(sourceFileName));
        }

        //bool hasBom = false;
        //using (var fs = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 3))
        //{
        //    int read = fs.Read(_bomBytes, 0, 3);

        //    if (read >= 3 && _bomBytes[0] == 0xEF && _bomBytes[1] == 0xBB && _bomBytes[2] == 0xBF)
        //    {
        //        hasBom = true;
        //    }
        //}

        //if (hasBom)
        {
            string sourceData = File.ReadAllText(sourceFileName);

            _includeRootDirectory = Path.GetDirectoryName(sourceFileName)!;
            _includeDirectories.Push(_includeRootDirectory);

            try
            {
                return Compile(sourceData, sourceFileName, defines, entrypoint, target, options);
            }
            finally
            {
                _includeRootDirectory = null;
                _includeDirectories.Clear();
            }
        }

        //if (string.IsNullOrEmpty(entrypoint))
        //{
        //    throw new ArgumentNullException(nameof(entrypoint));
        //}

        //if (string.IsNullOrEmpty(target))
        //{
        //    throw new ArgumentNullException(nameof(target));
        //}

        //int definesCount = defines.Length == 0 ? 0 : (defines.Length * 2 + 2);
        //nint* definesPtr = stackalloc nint[definesCount];

        //if (defines.Length != 0)
        //{
        //    for (int i = 0; i < defines.Length; i++)
        //    {
        //        definesPtr[i * 2 + 0] = Marshal.StringToHGlobalAnsi(defines[i].Name);
        //        definesPtr[i * 2 + 1] = Marshal.StringToHGlobalAnsi(defines[i].Definition);
        //    }

        //    definesPtr[defines.Length * 2 + 0] = 0;
        //    definesPtr[defines.Length * 2 + 1] = 0;
        //}

        //int hr = 0;
        //nint codeBlobPtr = 0;
        //nint errorMessagesBlobPtr = 0;

        //try
        //{
        //    int entrypointSize = Encoding.UTF8.GetByteCount(entrypoint);
        //    byte* entrypointPtr = stackalloc byte[entrypointSize + 1];
        //    entrypointPtr[entrypointSize] = 0;
        //    fixed (char* ptr = entrypoint)
        //    {
        //        Encoding.UTF8.GetBytes(ptr, entrypoint!.Length, entrypointPtr, entrypointSize);
        //    }

        //    int targetSize = Encoding.UTF8.GetByteCount(target);
        //    byte* targetPtr = stackalloc byte[targetSize + 1];
        //    targetPtr[targetSize] = 0;
        //    fixed (char* ptr = target)
        //    {
        //        Encoding.UTF8.GetBytes(ptr, target!.Length, targetPtr, targetSize);
        //    }

        //    fixed (char* sourceFileNamePtr = sourceFileName)
        //    {
        //        hr = NativeMethods.D3DCompileFromFile(
        //            sourceFileNamePtr,
        //            definesPtr,
        //            1, // D3D_COMPILE_STANDARD_FILE_INCLUDE
        //            entrypointPtr,
        //            targetPtr,
        //            options,
        //            0,
        //            &codeBlobPtr,
        //            &errorMessagesBlobPtr);
        //    }
        //}
        //finally
        //{
        //    if (definesPtr is not null)
        //    {
        //        for (int i = 0; i < definesCount; i++)
        //        {
        //            Marshal.FreeHGlobal(definesPtr[i]);
        //        }
        //    }
        //}

        //try
        //{
        //    if (hr != 0)
        //    {
        //        string? errorMessage = null;

        //        if (errorMessagesBlobPtr != 0)
        //        {
        //            ID3DBlob* errorMessagesBlobImpl = *(ID3DBlob**)errorMessagesBlobPtr;
        //            nint ptr = errorMessagesBlobImpl->GetBufferPointer(errorMessagesBlobPtr);
        //            int length = (int)errorMessagesBlobImpl->GetBufferSize(errorMessagesBlobPtr);
        //            errorMessage = new string((sbyte*)ptr, 0, length, Encoding.UTF8);
        //        }

        //        throw new ExternalException(errorMessage, hr);
        //    }
        //}
        //catch
        //{
        //    DXUtils.Release(codeBlobPtr);
        //    throw;
        //}
        //finally
        //{
        //    DXUtils.Release(errorMessagesBlobPtr);
        //}

        //return new D3DCompileResult(codeBlobPtr);
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
    public static D3DCompileResult CompileFromFile(string? sourceFileName, D3DShaderMacro[]? defines, string? entrypoint, string? target, D3DCompileOptions options)
    {
        return CompileFromFile(sourceFileName, defines.AsSpan(), entrypoint, target, options);
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
    public static D3DCompileResult CompileFromFile(string? sourceFileName, string? entrypoint, string? target, D3DCompileOptions options)
    {
        return CompileFromFile(sourceFileName, null, entrypoint, target, options);
    }

    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">The source data as compiled HLSL code.</param>
    /// <param name="options">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
    /// <param name="comments">The comment string at the top of the shader that identifies the shader constants and variables.</param>
    /// <returns>The assembly text.</returns>
    public static string Disassemble(ReadOnlySpan<byte> sourceData, D3DDisassembleOptions options, string? comments)
    {
        if (sourceData.Length == 0)
        {
            return string.Empty;
        }

        if (comments is not null && !comments.EndsWith("\n", StringComparison.Ordinal))
        {
            comments += "\n";
        }

        int commentsSize = comments is null ? 0 : Encoding.UTF8.GetByteCount(comments);
        byte* commentsPtr = stackalloc byte[commentsSize + 1];
        commentsPtr[commentsSize] = 0;
        if (comments is not null)
        {
            fixed (char* ptr = comments)
            {
                Encoding.UTF8.GetBytes(ptr, comments.Length, commentsPtr, commentsSize);
            }
        }

        nint disassemblyBlobPtr = 0;
        ID3DBlob* disassemblyBlobImpl = null;
        int hr;

        fixed (byte* sourceDataPtr = sourceData)
        {
            hr = NativeMethods.D3DDisassemble(sourceDataPtr, sourceData.Length, options, comments is null ? null : commentsPtr, &disassemblyBlobPtr);
        }

        if (disassemblyBlobPtr == 0)
        {
            throw new InvalidDataException();
        }

        Marshal.ThrowExceptionForHR(hr);

        disassemblyBlobImpl = *(ID3DBlob**)disassemblyBlobPtr;

        try
        {
            nint ptr = disassemblyBlobImpl->GetBufferPointer(disassemblyBlobPtr);
            int length = (int)disassemblyBlobImpl->GetBufferSize(disassemblyBlobPtr);
            return new string((sbyte*)ptr, 0, length, Encoding.UTF8);
        }
        finally
        {
            DXUtils.Release(disassemblyBlobPtr);
        }
    }

    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">The source data as compiled HLSL code.</param>
    /// <param name="options">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
    /// <param name="comments">The comment string at the top of the shader that identifies the shader constants and variables.</param>
    /// <returns>The assembly text.</returns>
    public static string Disassemble(byte[]? sourceData, D3DDisassembleOptions options, string? comments)
    {
        if (sourceData is null)
        {
            throw new ArgumentNullException(nameof(sourceData));
        }

        return Disassemble(sourceData.AsSpan(), options, comments);
    }


    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">The source data as compiled HLSL code.</param>
    /// <param name="options">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
    /// <returns>The assembly text.</returns>
    public static string Disassemble(byte[]? sourceData, D3DDisassembleOptions options)
    {
        return Disassemble(sourceData, options, null);
    }

    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">The source data as compiled HLSL code.</param>
    /// <param name="options">Flags affecting the behavior of <c>D3DDisassemble</c>.</param>
    /// <returns>The assembly text.</returns>
    public static string Disassemble(ReadOnlySpan<byte> sourceData, D3DDisassembleOptions options)
    {
        return Disassemble(sourceData, options, null);
    }

    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">The source data as compiled HLSL code.</param>
    /// <returns>The assembly text.</returns>
    public static string Disassemble(byte[]? sourceData)
    {
        return Disassemble(sourceData, D3DDisassembleOptions.None, null);
    }

    /// <summary>
    /// Disassembles compiled HLSL code.
    /// </summary>
    /// <param name="sourceData">The source data as compiled HLSL code.</param>
    /// <returns>The assembly text.</returns>
    public static string Disassemble(ReadOnlySpan<byte> sourceData)
    {
        return Disassemble(sourceData, D3DDisassembleOptions.None, null);
    }
}
