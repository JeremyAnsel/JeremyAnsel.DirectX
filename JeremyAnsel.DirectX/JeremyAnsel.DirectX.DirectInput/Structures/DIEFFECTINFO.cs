// <copyright file="DIEFFECTINFO.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal unsafe struct DIEFFECTINFO : IEquatable<DIEFFECTINFO>
{
    public struct NameBuffer
    {
        public fixed char Buffer[Length];
        public const int Length = 260;
        public const int TotalSize = sizeof(char) * Length;
    }

    public int Size;

    public Guid guid;

    public DIEFT EffType;

    public DIEP StaticParams;

    public DIEP DynamicParams;

    public NameBuffer Name;

    public override bool Equals(object? obj)
    {
        return obj is DIEFFECTINFO dIEFFECTINFO && Equals(dIEFFECTINFO);
    }

    public bool Equals(DIEFFECTINFO other)
    {
        fixed (char* ptrThis = Name.Buffer)
        {
            ReadOnlySpan<char> spanThis = new(ptrThis, NameBuffer.Length);
            ReadOnlySpan<char> spanOther = new(other.Name.Buffer, NameBuffer.Length);

            return Size == other.Size &&
                   guid.Equals(other.guid) &&
                   EffType.Equals(other.EffType) &&
                   StaticParams.Equals(other.StaticParams) &&
                   DynamicParams.Equals(other.DynamicParams) &&
                   MemoryExtensions.Equals(spanThis, spanOther, StringComparison.Ordinal);
        }
    }

    public override int GetHashCode()
    {
        int hashCode = 330398071;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + guid.GetHashCode();
        hashCode = hashCode * -1521134295 + EffType.GetHashCode();
        hashCode = hashCode * -1521134295 + StaticParams.GetHashCode();
        hashCode = hashCode * -1521134295 + DynamicParams.GetHashCode();
        hashCode = hashCode * -1521134295 + Name.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIEFFECTINFO left, DIEFFECTINFO right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIEFFECTINFO left, DIEFFECTINFO right)
    {
        return !(left == right);
    }
}
