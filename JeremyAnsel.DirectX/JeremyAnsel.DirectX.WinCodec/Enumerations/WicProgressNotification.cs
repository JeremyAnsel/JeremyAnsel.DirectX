// <copyright file="WicProgressNotification.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[Flags]
public enum WicProgressNotification : uint
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// 
    /// </summary>
    WICProgressNotificationBegin = 0x00010000,

    /// <summary>
    /// 
    /// </summary>
    WICProgressNotificationEnd = 0x00020000,

    /// <summary>
    /// 
    /// </summary>
    WICProgressNotificationFrequent = 0x00040000,

    /// <summary>
    /// 
    /// </summary>
    WICProgressNotificationAll = 0xFFFF0000,
}
