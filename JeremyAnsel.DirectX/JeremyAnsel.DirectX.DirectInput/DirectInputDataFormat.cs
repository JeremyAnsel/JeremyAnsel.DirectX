// <copyright file="DirectInputDataFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputDataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputDataOptions Options { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int DataSize { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputObjectDataFormat[] ObjectDataFormats { get; set; } = Array.Empty<DirectInputObjectDataFormat>();
}
