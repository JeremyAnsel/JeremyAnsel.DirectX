namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectDataRampForce : DirectInputEffectData
{
    public DirectInputEffectDataRampForce()
    {
    }

    internal DirectInputEffectDataRampForce(in DIRAMPFORCE di)
    {
        Start = di.Start;
        End = di.End;
    }

    internal DIRAMPFORCE ToDI()
    {
        DIRAMPFORCE di;
        di.Start = Start;
        di.End = End;
        return di;
    }

    public int Start { get; set; }

    public int End { get; set; }
}
