using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal unsafe struct DIJoystickState2
{
    public int lX;

    public int lY;

    public int lZ;

    public int lRx;

    public int lRy;

    public int lRz;

    public fixed int rglSlider[2];

    public fixed int rgdwPOV[4];

    public fixed byte rgbButtons[128];

    public int lVX;

    public int lVY;

    public int lVZ;

    public int lVRx;

    public int lVRy;

    public int lVRz;

    public fixed int rglVSlider[2];

    public int lAX;

    public int lAY;

    public int lAZ;

    public int lARx;

    public int lARy;

    public int lARz;

    public fixed int rglASlider[2];

    public int lFX;

    public int lFY;

    public int lFZ;

    public int lFRx;

    public int lFRy;

    public int lFRz;

    public fixed int rglFSlider[2];
}
