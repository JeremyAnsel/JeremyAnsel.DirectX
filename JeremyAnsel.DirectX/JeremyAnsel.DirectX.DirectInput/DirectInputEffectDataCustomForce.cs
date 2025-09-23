namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectDataCustomForce : DirectInputEffectData
{
    public DirectInputEffectDataCustomForce()
    {
    }

    internal DirectInputEffectDataCustomForce(in DICUSTOMFORCE di)
    {
        Channels = di.Channels;
        SamplePeriod = di.SamplePeriod;
        ForceData = di.ForceData;
    }

    internal DICUSTOMFORCE ToDI()
    {
        DICUSTOMFORCE di;
        di.Channels = Channels;
        di.SamplePeriod = SamplePeriod;
        di.Samples = ForceData.Length;
        di.ForceData = ForceData;
        return di;
    }

    public int Channels { get; set; }

    public int SamplePeriod { get; set; }

    public int[] ForceData { get; set; } = Array.Empty<int>();
}
