// <copyright file="DirectInputMouseState2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputMouseState2
{
    internal DirectInputMouseState2()
    {
        Buttons = new byte[8];
    }

    internal unsafe void Update(in DIMouseState2 data)
    {
        X = data.lX;
        Y = data.lY;
        Z = data.lZ;

        for (int i = 0; i < 8; i++)
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
    public byte[] Buttons { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public bool IsButtonPressed(int index)
    {
        if (index < 0 || index >= Buttons.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (Buttons[index] & 0x80) != 0;
    }
}
