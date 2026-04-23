// <copyright file="DirectInputMouse2Objects.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public enum DirectInputMouse2Objects
{
    /// <summary>
    /// 
    /// </summary>
    X = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 0,

    /// <summary>
    /// 
    /// </summary>
    Y = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 1,

    /// <summary>
    /// 
    /// </summary>
    Z = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 2,

    /// <summary>
    /// 
    /// </summary>
    Button0 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 0,

    /// <summary>
    /// 
    /// </summary>
    Button1 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 1,

    /// <summary>
    /// 
    /// </summary>
    Button2 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 2,

    /// <summary>
    /// 
    /// </summary>
    Button3 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 3,

    /// <summary>
    /// 
    /// </summary>
    Button4 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 4,

    /// <summary>
    /// 
    /// </summary>
    Button5 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 5,

    /// <summary>
    /// 
    /// </summary>
    Button6 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 6,

    /// <summary>
    /// 
    /// </summary>
    Button7 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 7,
}
