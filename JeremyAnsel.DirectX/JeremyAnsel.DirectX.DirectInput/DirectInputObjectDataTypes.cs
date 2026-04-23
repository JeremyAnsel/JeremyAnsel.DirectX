// <copyright file="DirectInputObjectDataTypes.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputObjectDataTypes : uint
{
    /// <summary>
    /// 
    /// </summary>
    All = 0,

    /// <summary>
    /// 
    /// </summary>
    RelativeAxis = 0x01,

    /// <summary>
    /// 
    /// </summary>
    AbsoluteAxis = 0x02,

    /// <summary>
    /// 
    /// </summary>
    Axis = 0x03,

    /// <summary>
    /// 
    /// </summary>
    PushButton = 0x04,

    /// <summary>
    /// 
    /// </summary>
    ToggleButton = 0x08,

    /// <summary>
    /// 
    /// </summary>
    Button = 0x0C,

    /// <summary>
    /// 
    /// </summary>
    POV = 0x10,

    /// <summary>
    /// 
    /// </summary>
    Collection = 0x40,

    /// <summary>
    /// 
    /// </summary>
    NoData = 0x80,

    /// <summary>
    /// 
    /// </summary>
    FFActuator = 0x01000000,

    /// <summary>
    /// 
    /// </summary>
    FFEffectTrigger = 0x02000000,

    /// <summary>
    /// 
    /// </summary>
    Output = 0x10000000,

    /// <summary>
    /// 
    /// </summary>
    VendorDefined = 0x04000000,

    /// <summary>
    /// 
    /// </summary>
    Alias = 0x08000000
}
