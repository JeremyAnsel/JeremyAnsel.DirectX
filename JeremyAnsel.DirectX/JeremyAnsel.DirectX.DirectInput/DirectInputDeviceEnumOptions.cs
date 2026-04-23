// <copyright file="DirectInputDeviceEnumOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[Flags]
public enum DirectInputDeviceEnumOptions : uint
{
    /// <summary>
    /// 
    /// </summary>
    AllDevices = 0,

    /// <summary>
    /// 
    /// </summary>
    AttachedOnly = 1,

    /// <summary>
    /// 
    /// </summary>
    ForceFeedback = 2,

    /// <summary>
    /// 
    /// </summary>
    IncludeAliases = 4,

    /// <summary>
    /// 
    /// </summary>
    IncludePhantoms = 8,

    /// <summary>
    /// 
    /// </summary>
    IncludeHidden = 16
}
