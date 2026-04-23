// <copyright file="DIMouseState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal unsafe struct DIMouseState
{
    public int lX;

    public int lY;

    public int lZ;

    public fixed byte rgbButtons[4];
}
