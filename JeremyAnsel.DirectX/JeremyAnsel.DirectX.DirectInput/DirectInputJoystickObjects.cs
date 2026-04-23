// <copyright file="DirectInputJoystickObjects.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public enum DirectInputJoystickObjects
{
    /// <summary>
    /// 
    /// </summary>
    X = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 0,

    /// <summary>
    /// 
    /// </summary>
    Y = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 1,

    /// <summary>
    /// 
    /// </summary>
    Z = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 2,

    /// <summary>
    /// 
    /// </summary>
    Rx = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 3,

    /// <summary>
    /// 
    /// </summary>
    Ry = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 4,

    /// <summary>
    /// 
    /// </summary>
    Rz = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 5,

    /// <summary>
    /// 
    /// </summary>
    Slider0 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 6,

    /// <summary>
    /// 
    /// </summary>
    Slider1 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 7,

    /// <summary>
    /// 
    /// </summary>
    POV0 = ((int)DirectInputObjectDataTypes.POV << 16) | 0,

    /// <summary>
    /// 
    /// </summary>
    POV1 = ((int)DirectInputObjectDataTypes.POV << 16) | 1,

    /// <summary>
    /// 
    /// </summary>
    POV2 = ((int)DirectInputObjectDataTypes.POV << 16) | 2,

    /// <summary>
    /// 
    /// </summary>
    POV3 = ((int)DirectInputObjectDataTypes.POV << 16) | 3,

    /// <summary>
    /// 
    /// </summary>
    Button00 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 0,

    /// <summary>
    /// 
    /// </summary>
    Button01 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 1,

    /// <summary>
    /// 
    /// </summary>
    Button02 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 2,

    /// <summary>
    /// 
    /// </summary>
    Button03 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 3,

    /// <summary>
    /// 
    /// </summary>
    Button04 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 4,

    /// <summary>
    /// 
    /// </summary>
    Button05 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 5,

    /// <summary>
    /// 
    /// </summary>
    Button06 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 6,

    /// <summary>
    /// 
    /// </summary>
    Button07 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 7,

    /// <summary>
    /// 
    /// </summary>
    Button08 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 8,

    /// <summary>
    /// 
    /// </summary>
    Button09 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 9,

    /// <summary>
    /// 
    /// </summary>
    Button10 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 10,

    /// <summary>
    /// 
    /// </summary>
    Button11 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 11,

    /// <summary>
    /// 
    /// </summary>
    Button12 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 12,

    /// <summary>
    /// 
    /// </summary>
    Button13 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 13,

    /// <summary>
    /// 
    /// </summary>
    Button14 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 14,

    /// <summary>
    /// 
    /// </summary>
    Button15 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 15,

    /// <summary>
    /// 
    /// </summary>
    Button16 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 16,

    /// <summary>
    /// 
    /// </summary>
    Button17 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 17,

    /// <summary>
    /// 
    /// </summary>
    Button18 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 18,

    /// <summary>
    /// 
    /// </summary>
    Button19 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 19,

    /// <summary>
    /// 
    /// </summary>
    Button20 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 20,

    /// <summary>
    /// 
    /// </summary>
    Button21 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 21,

    /// <summary>
    /// 
    /// </summary>
    Button22 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 22,

    /// <summary>
    /// 
    /// </summary>
    Button23 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 23,

    /// <summary>
    /// 
    /// </summary>
    Button24 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 24,

    /// <summary>
    /// 
    /// </summary>
    Button25 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 25,

    /// <summary>
    /// 
    /// </summary>
    Button26 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 26,

    /// <summary>
    /// 
    /// </summary>
    Button27 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 27,

    /// <summary>
    /// 
    /// </summary>
    Button28 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 28,

    /// <summary>
    /// 
    /// </summary>
    Button29 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 29,

    /// <summary>
    /// 
    /// </summary>
    Button30 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 30,

    /// <summary>
    /// 
    /// </summary>
    Button31 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 31
}
