// <copyright file="WicPngIccpProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicPngIccpProperties : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICPngIccpProfileName = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICPngIccpProfileData = 0x00000002,
}
