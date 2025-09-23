namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectDataConstantForce : DirectInputEffectData
{
    public DirectInputEffectDataConstantForce()
    {
    }

    internal DirectInputEffectDataConstantForce(in DICONSTANTFORCE di)
    {
        Magnitude = di.Magnitude;
    }

    internal DICONSTANTFORCE ToDI()
    {
        DICONSTANTFORCE di;
        di.Magnitude = Magnitude;
        return di;
    }

    public int Magnitude { get; set; }
}
