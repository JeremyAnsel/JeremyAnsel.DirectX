namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectDataCondition : DirectInputEffectData
{
    public DirectInputEffectDataCondition()
    {
    }

    internal DirectInputEffectDataCondition(in DICONDITION di)
    {
        Offset = di.Offset;
        PositiveCoefficient = di.PositiveCoefficient;
        NegativeCoefficient = di.NegativeCoefficient;
        PositiveSaturation = di.PositiveSaturation;
        NegativeSaturation = di.NegativeSaturation;
        DeadBand = di.DeadBand;
    }

    internal DICONDITION ToDI()
    {
        DICONDITION di;
        di.Offset = Offset;
        di.PositiveCoefficient = PositiveCoefficient;
        di.NegativeCoefficient = NegativeCoefficient;
        di.PositiveSaturation = PositiveSaturation;
        di.NegativeSaturation = NegativeSaturation;
        di.DeadBand = DeadBand;
        return di;
    }

    public int Offset { get; set; }

    public int PositiveCoefficient { get; set; }

    public int NegativeCoefficient { get; set; }

    public int PositiveSaturation { get; set; }

    public int NegativeSaturation { get; set; }

    public int DeadBand { get; set; }
}
