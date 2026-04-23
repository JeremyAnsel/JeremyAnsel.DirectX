// <copyright file="DirectInputJoystickState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
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
    public bool IsButtonPressed(int index)
    {
        if (index < 0 || index >= Buttons.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (Buttons[index] & 0x80) != 0;
    }
}
