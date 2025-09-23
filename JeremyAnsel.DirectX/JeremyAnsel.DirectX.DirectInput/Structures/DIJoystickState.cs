using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal unsafe struct DIJoystickState
{
    public int lX;

    public int lY;

    public int lZ;

    public int lRx;

    public int lRy;

    public int lRz;

    public fixed int rglSlider[2];

    public fixed int rgdwPOV[4];

    public fixed byte rgbButtons[32];
}
