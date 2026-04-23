// <copyright file="DirectInputJoystickState2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    public int X { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int Y { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int Z { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int Rx { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int Ry { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int Rz { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int[] Sliders { get; }

    /// <summary>
    /// 
    /// </summary>
    public int[] POVs { get; }

    /// <summary>
    /// 
    /// </summary>
    public byte[] Buttons { get; }

    /// <summary>
    /// 
    /// </summary>
    public int VX { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int VY { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int VZ { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int VRx { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int VRy { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int VRz { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int[] VSliders { get; }

    /// <summary>
    /// 
    /// </summary>
    public int AX { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int AY { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int AZ { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int ARx { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int ARy { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int ARz { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int[] ASliders { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FX { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int FY { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int FZ { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int FRx { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int FRy { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int FRz { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int[] FSliders { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsButtonPressed(int index)
    {
        if (index < 0 || index >= Buttons.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (Buttons[index] & 0x80) != 0;
    }
}
