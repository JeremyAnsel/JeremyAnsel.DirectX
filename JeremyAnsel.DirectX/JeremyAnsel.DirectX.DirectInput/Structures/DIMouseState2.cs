using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal unsafe struct DIMouseState2
{
    public int lX;

    public int lY;

    public int lZ;

    public fixed byte rgbButtons[8];
}
