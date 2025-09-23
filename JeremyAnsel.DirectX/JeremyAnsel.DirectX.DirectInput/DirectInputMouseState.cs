namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputMouseState
{
    internal DirectInputMouseState()
    {
        Buttons = new byte[4];
    }

    internal unsafe void Update(in DIMouseState data)
    {
        X = data.lX;
        Y = data.lY;
        Z = data.lZ;

        for (int i = 0; i < 4; i++)
        {
            Buttons[i] = data.rgbButtons[i];
        }
    }

    public int X { get; private set; }

    public int Y { get; private set; }

    public int Z { get; private set; }

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
