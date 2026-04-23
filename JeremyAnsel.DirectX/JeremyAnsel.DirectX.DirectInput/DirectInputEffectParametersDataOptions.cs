// <copyright file="DirectInputEffectParametersDataOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputEffectParametersDataOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    ObjectIDs = 1,

    /// <summary>
    /// 
    /// </summary>
    ObjectOffsets = 2,

    /// <summary>
    /// 
    /// </summary>
    Cartesian = 16,

    /// <summary>
    /// 
    /// </summary>
    Polar = 32,

    /// <summary>
    /// 
    /// </summary>
    Spherical = 64
}
