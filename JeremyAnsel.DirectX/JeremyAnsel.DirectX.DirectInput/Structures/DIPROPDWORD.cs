// <copyright file="DIPROPDWORD.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal struct DIPROPDWORD : IEquatable<DIPROPDWORD>
{
    public DIPROPHEADER Header;

    public uint Data;

    public override bool Equals(object? obj)
    {
        return obj is DIPROPDWORD dIPROPDWORD && Equals(dIPROPDWORD);
    }

    public bool Equals(DIPROPDWORD other)
    {
        return Header.Equals(other.Header) &&
               Data == other.Data;
    }

    public override int GetHashCode()
    {
        int hashCode = -360083643;
        hashCode = hashCode * -1521134295 + Header.GetHashCode();
        hashCode = hashCode * -1521134295 + Data.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIPROPDWORD left, DIPROPDWORD right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIPROPDWORD left, DIPROPDWORD right)
    {
        return !(left == right);
    }
}
