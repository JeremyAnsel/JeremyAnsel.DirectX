// <copyright file="DIMouseState2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal unsafe struct DIMouseState2
{
    public int lX;

    public int lY;

    public int lZ;

    public fixed byte rgbButtons[8];
}
