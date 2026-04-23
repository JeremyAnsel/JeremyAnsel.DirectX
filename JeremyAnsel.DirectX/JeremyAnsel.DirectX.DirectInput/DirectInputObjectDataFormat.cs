// <copyright file="DirectInputObjectDataFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputObjectDataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public Guid? Guid { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputObjectDataTypes DataType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public short DataInstance { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputObjectDataOptions Options { get; set; }
}
