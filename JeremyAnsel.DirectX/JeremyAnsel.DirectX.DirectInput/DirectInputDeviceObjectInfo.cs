namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputDeviceObjectInfo
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

    public Guid GuidType { get; }

    public int Offset { get; }

    public DirectInputObjectDataTypes DataType { get; set; }

    public short DataInstance { get; set; }

    public string Name { get; }

    public int FFMaxForce { get; }

    public int FFForceResolution { get; }

    public short CollectionNumber { get; }

    public short DesignatorIndex { get; }

    public short UsagePage { get; }

    public short Usage { get; }

    public int Dimension { get; }

    public short Exponent { get; }

    public short ReportId { get; }
}
