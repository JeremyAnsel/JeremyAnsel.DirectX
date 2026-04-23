// <copyright file="DirectInputDeviceObjectInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public unsafe sealed class DirectInputDeviceObjectInfo
{
    internal DirectInputDeviceObjectInfo(in DIDEVICEOBJECTINSTANCE di)
    {
        GuidType = di.GuidType;
        Offset = di.Ofs;
        DataType = (DirectInputObjectDataTypes)(di.Type & 0xff0000ff);
        DataInstance = (short)((di.Type & 0xffff00) >> 8);
        Name = di.Name;
        FFMaxForce = di.FFMaxForce;
        FFForceResolution = di.FFForceResolution;
        CollectionNumber = di.CollectionNumber;
        DesignatorIndex = di.DesignatorIndex;
        UsagePage = di.UsagePage;
        Usage = di.Usage;
        Dimension = di.Dimension;
        Exponent = di.Exponent;
        ReportId = di.ReportId;
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid GuidType { get; }

    /// <summary>
    /// 
    /// </summary>
    public int Offset { get; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputObjectDataTypes DataType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public short DataInstance { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FFMaxForce { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FFForceResolution { get; }

    /// <summary>
    /// 
    /// </summary>
    public short CollectionNumber { get; }

    /// <summary>
    /// 
    /// </summary>
    public short DesignatorIndex { get; }

    /// <summary>
    /// 
    /// </summary>
    public short UsagePage { get; }

    /// <summary>
    /// 
    /// </summary>
    public short Usage { get; }

    /// <summary>
    /// 
    /// </summary>
    public int Dimension { get; }

    /// <summary>
    /// 
    /// </summary>
    public short Exponent { get; }

    /// <summary>
    /// 
    /// </summary>
    public short ReportId { get; }
}
