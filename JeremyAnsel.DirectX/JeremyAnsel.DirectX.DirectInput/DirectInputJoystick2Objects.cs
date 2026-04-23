// <copyright file="DirectInputJoystick2Objects.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public enum DirectInputJoystick2Objects
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
    Button000 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 0,

    /// <summary>
    /// 
    /// </summary>
    Button001 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 1,

    /// <summary>
    /// 
    /// </summary>
    Button002 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 2,

    /// <summary>
    /// 
    /// </summary>
    Button003 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 3,

    /// <summary>
    /// 
    /// </summary>
    Button004 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 4,

    /// <summary>
    /// 
    /// </summary>
    Button005 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 5,

    /// <summary>
    /// 
    /// </summary>
    Button006 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 6,

    /// <summary>
    /// 
    /// </summary>
    Button007 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 7,

    /// <summary>
    /// 
    /// </summary>
    Button008 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 8,

    /// <summary>
    /// 
    /// </summary>
    Button009 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 9,

    /// <summary>
    /// 
    /// </summary>
    Button010 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 10,

    /// <summary>
    /// 
    /// </summary>
    Button011 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 11,

    /// <summary>
    /// 
    /// </summary>
    Button012 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 12,

    /// <summary>
    /// 
    /// </summary>
    Button013 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 13,

    /// <summary>
    /// 
    /// </summary>
    Button014 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 14,

    /// <summary>
    /// 
    /// </summary>
    Button015 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 15,

    /// <summary>
    /// 
    /// </summary>
    Button016 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 16,

    /// <summary>
    /// 
    /// </summary>
    Button017 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 17,

    /// <summary>
    /// 
    /// </summary>
    Button018 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 18,

    /// <summary>
    /// 
    /// </summary>
    Button019 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 19,

    /// <summary>
    /// 
    /// </summary>
    Button020 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 20,

    /// <summary>
    /// 
    /// </summary>
    Button021 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 21,

    /// <summary>
    /// 
    /// </summary>
    Button022 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 22,

    /// <summary>
    /// 
    /// </summary>
    Button023 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 23,

    /// <summary>
    /// 
    /// </summary>
    Button024 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 24,

    /// <summary>
    /// 
    /// </summary>
    Button025 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 25,

    /// <summary>
    /// 
    /// </summary>
    Button026 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 26,

    /// <summary>
    /// 
    /// </summary>
    Button027 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 27,

    /// <summary>
    /// 
    /// </summary>
    Button028 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 28,

    /// <summary>
    /// 
    /// </summary>
    Button029 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 29,

    /// <summary>
    /// 
    /// </summary>
    Button030 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 30,

    /// <summary>
    /// 
    /// </summary>
    Button031 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 31,

    /// <summary>
    /// 
    /// </summary>
    Button032 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 32,

    /// <summary>
    /// 
    /// </summary>
    Button033 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 33,

    /// <summary>
    /// 
    /// </summary>
    Button034 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 34,

    /// <summary>
    /// 
    /// </summary>
    Button035 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 35,

    /// <summary>
    /// 
    /// </summary>
    Button036 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 36,

    /// <summary>
    /// 
    /// </summary>
    Button037 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 37,

    /// <summary>
    /// 
    /// </summary>
    Button038 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 38,

    /// <summary>
    /// 
    /// </summary>
    Button039 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 39,

    /// <summary>
    /// 
    /// </summary>
    Button040 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 40,

    /// <summary>
    /// 
    /// </summary>
    Button041 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 41,

    /// <summary>
    /// 
    /// </summary>
    Button042 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 42,

    /// <summary>
    /// 
    /// </summary>
    Button043 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 43,

    /// <summary>
    /// 
    /// </summary>
    Button044 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 44,

    /// <summary>
    /// 
    /// </summary>
    Button045 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 45,

    /// <summary>
    /// 
    /// </summary>
    Button046 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 46,

    /// <summary>
    /// 
    /// </summary>
    Button047 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 47,

    /// <summary>
    /// 
    /// </summary>
    Button048 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 48,

    /// <summary>
    /// 
    /// </summary>
    Button049 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 49,

    /// <summary>
    /// 
    /// </summary>
    Button050 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 50,

    /// <summary>
    /// 
    /// </summary>
    Button051 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 51,

    /// <summary>
    /// 
    /// </summary>
    Button052 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 52,

    /// <summary>
    /// 
    /// </summary>
    Button053 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 53,

    /// <summary>
    /// 
    /// </summary>
    Button054 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 54,

    /// <summary>
    /// 
    /// </summary>
    Button055 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 55,

    /// <summary>
    /// 
    /// </summary>
    Button056 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 56,

    /// <summary>
    /// 
    /// </summary>
    Button057 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 57,

    /// <summary>
    /// 
    /// </summary>
    Button058 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 58,

    /// <summary>
    /// 
    /// </summary>
    Button059 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 59,

    /// <summary>
    /// 
    /// </summary>
    Button060 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 60,

    /// <summary>
    /// 
    /// </summary>
    Button061 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 61,

    /// <summary>
    /// 
    /// </summary>
    Button062 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 62,

    /// <summary>
    /// 
    /// </summary>
    Button063 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 63,

    /// <summary>
    /// 
    /// </summary>
    Button064 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 64,

    /// <summary>
    /// 
    /// </summary>
    Button065 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 65,

    /// <summary>
    /// 
    /// </summary>
    Button066 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 66,

    /// <summary>
    /// 
    /// </summary>
    Button067 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 67,

    /// <summary>
    /// 
    /// </summary>
    Button068 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 68,

    /// <summary>
    /// 
    /// </summary>
    Button069 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 69,

    /// <summary>
    /// 
    /// </summary>
    Button070 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 70,

    /// <summary>
    /// 
    /// </summary>
    Button071 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 71,

    /// <summary>
    /// 
    /// </summary>
    Button072 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 72,

    /// <summary>
    /// 
    /// </summary>
    Button073 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 73,

    /// <summary>
    /// 
    /// </summary>
    Button074 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 74,

    /// <summary>
    /// 
    /// </summary>
    Button075 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 75,

    /// <summary>
    /// 
    /// </summary>
    Button076 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 76,

    /// <summary>
    /// 
    /// </summary>
    Button077 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 77,

    /// <summary>
    /// 
    /// </summary>
    Button078 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 78,

    /// <summary>
    /// 
    /// </summary>
    Button079 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 79,

    /// <summary>
    /// 
    /// </summary>
    Button080 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 80,

    /// <summary>
    /// 
    /// </summary>
    Button081 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 81,

    /// <summary>
    /// 
    /// </summary>
    Button082 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 82,

    /// <summary>
    /// 
    /// </summary>
    Button083 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 83,

    /// <summary>
    /// 
    /// </summary>
    Button084 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 84,

    /// <summary>
    /// 
    /// </summary>
    Button085 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 85,

    /// <summary>
    /// 
    /// </summary>
    Button086 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 86,

    /// <summary>
    /// 
    /// </summary>
    Button087 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 87,

    /// <summary>
    /// 
    /// </summary>
    Button088 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 88,

    /// <summary>
    /// 
    /// </summary>
    Button089 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 89,

    /// <summary>
    /// 
    /// </summary>
    Button090 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 90,

    /// <summary>
    /// 
    /// </summary>
    Button091 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 91,

    /// <summary>
    /// 
    /// </summary>
    Button092 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 92,

    /// <summary>
    /// 
    /// </summary>
    Button093 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 93,

    /// <summary>
    /// 
    /// </summary>
    Button094 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 94,

    /// <summary>
    /// 
    /// </summary>
    Button095 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 95,

    /// <summary>
    /// 
    /// </summary>
    Button096 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 96,

    /// <summary>
    /// 
    /// </summary>
    Button097 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 97,

    /// <summary>
    /// 
    /// </summary>
    Button098 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 98,

    /// <summary>
    /// 
    /// </summary>
    Button099 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 99,

    /// <summary>
    /// 
    /// </summary>
    Button100 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 100,

    /// <summary>
    /// 
    /// </summary>
    Button101 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 101,

    /// <summary>
    /// 
    /// </summary>
    Button102 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 102,

    /// <summary>
    /// 
    /// </summary>
    Button103 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 103,

    /// <summary>
    /// 
    /// </summary>
    Button104 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 104,

    /// <summary>
    /// 
    /// </summary>
    Button105 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 105,

    /// <summary>
    /// 
    /// </summary>
    Button106 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 106,

    /// <summary>
    /// 
    /// </summary>
    Button107 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 107,

    /// <summary>
    /// 
    /// </summary>
    Button108 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 108,

    /// <summary>
    /// 
    /// </summary>
    Button109 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 109,

    /// <summary>
    /// 
    /// </summary>
    Button110 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 110,

    /// <summary>
    /// 
    /// </summary>
    Button111 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 111,

    /// <summary>
    /// 
    /// </summary>
    Button112 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 112,

    /// <summary>
    /// 
    /// </summary>
    Button113 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 113,

    /// <summary>
    /// 
    /// </summary>
    Button114 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 114,

    /// <summary>
    /// 
    /// </summary>
    Button115 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 115,

    /// <summary>
    /// 
    /// </summary>
    Button116 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 116,

    /// <summary>
    /// 
    /// </summary>
    Button117 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 117,

    /// <summary>
    /// 
    /// </summary>
    Button118 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 118,

    /// <summary>
    /// 
    /// </summary>
    Button119 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 119,

    /// <summary>
    /// 
    /// </summary>
    Button120 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 120,

    /// <summary>
    /// 
    /// </summary>
    Button121 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 121,

    /// <summary>
    /// 
    /// </summary>
    Button122 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 122,

    /// <summary>
    /// 
    /// </summary>
    Button123 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 123,

    /// <summary>
    /// 
    /// </summary>
    Button124 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 124,

    /// <summary>
    /// 
    /// </summary>
    Button125 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 125,

    /// <summary>
    /// 
    /// </summary>
    Button126 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 126,

    /// <summary>
    /// 
    /// </summary>
    Button127 = ((int)DirectInputObjectDataTypes.PushButton << 16) | 127,

    /// <summary>
    /// 
    /// </summary>
    VX = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 8,

    /// <summary>
    /// 
    /// </summary>
    VY = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 9,

    /// <summary>
    /// 
    /// </summary>
    VZ = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 10,

    /// <summary>
    /// 
    /// </summary>
    VRx = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 11,

    /// <summary>
    /// 
    /// </summary>
    VRy = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 12,

    /// <summary>
    /// 
    /// </summary>
    VRz = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 13,

    /// <summary>
    /// 
    /// </summary>
    VSlider0 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 14,

    /// <summary>
    /// 
    /// </summary>
    VSlider1 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 15,

    /// <summary>
    /// 
    /// </summary>
    AX = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 16,

    /// <summary>
    /// 
    /// </summary>
    AY = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 17,

    /// <summary>
    /// 
    /// </summary>
    AZ = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 18,

    /// <summary>
    /// 
    /// </summary>
    ARx = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 19,

    /// <summary>
    /// 
    /// </summary>
    ARy = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 20,

    /// <summary>
    /// 
    /// </summary>
    ARz = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 21,

    /// <summary>
    /// 
    /// </summary>
    ASlider0 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 22,

    /// <summary>
    /// 
    /// </summary>
    ASlider1 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 23,

    /// <summary>
    /// 
    /// </summary>
    FX = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 24,

    /// <summary>
    /// 
    /// </summary>
    FY = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 25,

    /// <summary>
    /// 
    /// </summary>
    FZ = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 26,

    /// <summary>
    /// 
    /// </summary>
    FRx = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 27,

    /// <summary>
    /// 
    /// </summary>
    FRy = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 28,

    /// <summary>
    /// 
    /// </summary>
    FRz = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 29,

    /// <summary>
    /// 
    /// </summary>
    FSlider0 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 30,

    /// <summary>
    /// 
    /// </summary>
    FSlider1 = ((int)DirectInputObjectDataTypes.AbsoluteAxis << 16) | 31
}
