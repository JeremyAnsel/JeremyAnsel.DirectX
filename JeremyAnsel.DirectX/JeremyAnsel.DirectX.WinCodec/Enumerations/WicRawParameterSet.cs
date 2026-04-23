// <copyright file="WicRawParameterSet.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicRawParameterSet : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICAsShotParameterSet = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICUserAdjustedParameterSet = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICAutoAdjustedParameterSet = 0x00000003,
}
