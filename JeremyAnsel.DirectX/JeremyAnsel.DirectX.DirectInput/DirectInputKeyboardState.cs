namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputKeyboardState
{
    internal DirectInputKeyboardState()
    {
        Data = new byte[256];
    }

    internal void Update(byte[] data)
    {
        Array.Copy(data, 0, Data, 0, 256);
    }

    public byte[] Data { get; }

    public byte GetKeyData(DirectInputKeyboardKeys key)
    {
        return Data[(int)key];
    }

    public bool IsKeyPressed(DirectInputKeyboardKeys key)
    {
        return (Data[(int)key] & 0x80) != 0;
    }
}
