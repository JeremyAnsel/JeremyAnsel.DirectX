namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectDataPeriodic : DirectInputEffectData
{
    public DirectInputEffectDataPeriodic()
    {
    }

    internal DirectInputEffectDataPeriodic(in DIPERIODIC di)
    {
        Magnitude = di.Magnitude;
        Offset = di.Offset;
        Phase = di.Phase;
        Period = di.Period;
    }

    internal DIPERIODIC ToDI()
    {
        DIPERIODIC di;
        di.Magnitude = Magnitude;
        di.Offset = Offset;
        di.Phase = Phase;
        di.Period = Period;
        return di;
    }

    public int Magnitude { get; set; }

    public int Offset { get; set; }

    public int Phase { get; set; }

    public int Period { get; set; }
}
