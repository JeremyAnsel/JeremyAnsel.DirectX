// <copyright file="DirectInputDeviceInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Xml.Linq;

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public unsafe sealed class DirectInputDeviceInfo
{
    internal DirectInputDeviceInfo(in DIDEVICEINSTANCE di)
    {
        Instance = di.Instance;
        Product = di.Product;
        InstanceName = di.InstanceName;
        ProductName = di.ProductName;
        FFDriver = di.FFDriver;
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Instance { get; }

    /// <summary>
    /// 
    /// </summary>
    public Guid Product { get; }

    /// <summary>
    /// 
    /// </summary>
    public string InstanceName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ProductName { get; }

    /// <summary>
    /// 
    /// </summary>
    public Guid FFDriver { get; }
}
