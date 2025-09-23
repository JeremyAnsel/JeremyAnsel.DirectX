namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputJoystickState
{
    internal DirectInputJoystickState()
    {
        Sliders = new int[2];
        POVs = new int[4];
        Buttons = new byte[32];
    }

    internal unsafe void Update(in DIJoystickState data)
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

        for (int i = 0; i < 32; i++)
        {
            Buttons[i] = data.rgbButtons[i];
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

    public bool IsButtonPressed(int index)
    {
        if (index < 0 || index >= Buttons.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (Buttons[index] & 0x80) != 0;
    }
}
