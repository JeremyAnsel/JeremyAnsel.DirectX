namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectInfo
{
    internal DirectInputEffectInfo(in DIEFFECTINFO di)
    {
        Identifier = di.guid;
        EffectType = (DirectInputEffectTypes)(uint)di.EffType;
        StaticParams = (DirectInputEffectParameterOptions)(uint)di.StaticParams;
        DynamicParams = (DirectInputEffectParameterOptions)(uint)di.DynamicParams;
        Name = di.Name;
    }

    public Guid Identifier { get; }

    public DirectInputEffectTypes EffectType { get; }

    public DirectInputEffectParameterOptions StaticParams { get; }

    public DirectInputEffectParameterOptions DynamicParams { get; }

    public string Name { get; }
}
