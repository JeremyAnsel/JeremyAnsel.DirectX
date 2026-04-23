// <copyright file="DirectInputMouseObjects.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public enum DirectInputMouseObjects
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
}
