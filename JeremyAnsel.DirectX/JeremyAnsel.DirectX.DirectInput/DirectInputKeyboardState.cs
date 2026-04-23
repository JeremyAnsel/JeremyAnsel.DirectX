// <copyright file="DirectInputKeyboardState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    public byte[] Data { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public byte GetKeyData(DirectInputKeyboardKeys key)
    {
        return Data[(int)key];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsKeyPressed(DirectInputKeyboardKeys key)
    {
        return (Data[(int)key] & 0x80) != 0;
    }
}
