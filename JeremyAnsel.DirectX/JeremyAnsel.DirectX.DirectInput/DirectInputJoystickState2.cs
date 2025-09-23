namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputJoystickState2
{
    internal DirectInputJoystickState2()
    {
        Sliders = new int[2];
        POVs = new int[4];
        Buttons = new byte[128];
        VSliders = new int[2];
        ASliders = new int[2];
        FSliders = new int[2];
    }

    internal unsafe void Update(in DIJoystickState2 data)
    {
        X = data.lX;
        Y = data.lY;
        Z = data.lZ;
        Rx = data.lRx;
        Ry = data.lRy;
        Rz = data.lRz;

        for (int i = 0; i < 2; i++)
        {
            Sliders[i] = data.rglSlider[i];
        }

        for (int i = 0; i < 4; i++)
        {
            POVs[i] = data.rgdwPOV[i];
        }

        for (int i = 0; i < 128; i++)
        {
            Buttons[i] = data.rgbButtons[i];
        }

        VX = data.lVX;
        VY = data.lVY;
        VZ = data.lVZ;
        VRx = data.lVRx;
        VRy = data.lVRy;
        VRz = data.lVRz;

        for (int i = 0; i < 2; i++)
        {
            VSliders[i] = data.rglVSlider[i];
        }

        AX = data.lAX;
        AY = data.lAY;
        AZ = data.lAZ;
        ARx = data.lARx;
        ARy = data.lARy;
        ARz = data.lARz;

        for (int i = 0; i < 2; i++)
        {
            ASliders[i] = data.rglASlider[i];
        }

        FX = data.lFX;
        FY = data.lFY;
        FZ = data.lFZ;
        FRx = data.lFRx;
        FRy = data.lFRy;
        FRz = data.lFRz;

        for (int i = 0; i < 2; i++)
        {
            FSliders[i] = data.rglFSlider[i];
        }
    }

    public int X { get; private set; }

    public int Y { get; private set; }

    public int Z { get; private set; }

    public int Rx { get; private set; }

    public int Ry { get; private set; }

    public int Rz { get; private set; }

    public int[] Sliders { get; }

    public int[] POVs { get; }

    public byte[] Buttons { get; }

    public int VX { get; private set; }

    public int VY { get; private set; }

    public int VZ { get; private set; }

    public int VRx { get; private set; }

    public int VRy { get; private set; }

    public int VRz { get; private set; }

    public int[] VSliders { get; }

    public int AX { get; private set; }

    public int AY { get; private set; }

    public int AZ { get; private set; }

    public int ARx { get; private set; }

    public int ARy { get; private set; }

    public int ARz { get; private set; }

    public int[] ASliders { get; }

    public int FX { get; private set; }

    public int FY { get; private set; }

    public int FZ { get; private set; }

    public int FRx { get; private set; }

    public int FRy { get; private set; }

    public int FRz { get; private set; }

    public int[] FSliders { get; }

    public bool IsButtonPressed(int index)
    {
        if (index < 0 || index >= Buttons.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (Buttons[index] & 0x80) != 0;
    }
}
