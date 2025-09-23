using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectEnvelope
{
    public DirectInputEffectEnvelope()
    {
    }

    internal DirectInputEffectEnvelope(in DIENVELOPE di)
    {
        AttackLevel = di.AttackLevel;
        AttackTime = di.AttackTime;
        FadeLevel = di.FadeLevel;
        FadeTime = di.FadeTime;
    }

    internal DIENVELOPE ToDI()
    {
        DIENVELOPE di;
        di.Size = Marshal.SizeOf<DIENVELOPE>();
        di.AttackLevel = AttackLevel;
        di.AttackTime = AttackTime;
        di.FadeLevel = FadeLevel;
        di.FadeTime = FadeTime;
        return di;
    }

    public int AttackLevel { get; set; }

    public int AttackTime { get; set; }

    public int FadeLevel { get; set; }

    public int FadeTime { get; set; }
}
