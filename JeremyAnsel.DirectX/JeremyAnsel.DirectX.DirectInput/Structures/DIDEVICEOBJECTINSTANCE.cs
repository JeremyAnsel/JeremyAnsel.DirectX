// <copyright file="DIDEVICEOBJECTINSTANCE.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal unsafe struct DIDEVICEOBJECTINSTANCE : IEquatable<DIDEVICEOBJECTINSTANCE>
{
    public struct StrBuffer
    {
        public fixed char Buffer[Length];
        public const int Length = 260;
        public const int TotalSize = sizeof(char) * Length;
    }

    public int Size;

    public Guid GuidType;

    public int Ofs;

    public int Type;

    public DIDOI Flags;

    public StrBuffer NameBuffer;

    public string Name
    {
        get
        {
            fixed (char* name = NameBuffer.Buffer)
            {
                return new string(name);
            }
        }
    }

    public int FFMaxForce;

    public int FFForceResolution;

    public short CollectionNumber;

    public short DesignatorIndex;

    public short UsagePage;

    public short Usage;

    public int Dimension;

    public short Exponent;

    public short ReportId;

    public override bool Equals(object? obj)
    {
        return obj is DIDEVICEOBJECTINSTANCE dIDEVICEOBJECTINSTANCE && Equals(dIDEVICEOBJECTINSTANCE);
    }

    public bool Equals(DIDEVICEOBJECTINSTANCE other)
    {
        fixed (char* ptrThis = NameBuffer.Buffer)
        {
            ReadOnlySpan<char> spanThis = new(ptrThis, StrBuffer.Length);
            ReadOnlySpan<char> spanOther = new(other.NameBuffer.Buffer, StrBuffer.Length);

            return Size == other.Size &&
                   GuidType.Equals(other.GuidType) &&
                   Ofs == other.Ofs &&
                   Type == other.Type &&
                   Flags == other.Flags &&
                   MemoryExtensions.Equals(spanThis, spanOther, StringComparison.Ordinal) &&
                   FFMaxForce == other.FFMaxForce &&
                   FFForceResolution == other.FFForceResolution &&
                   CollectionNumber == other.CollectionNumber &&
                   DesignatorIndex == other.DesignatorIndex &&
                   UsagePage == other.UsagePage &&
                   Usage == other.Usage &&
                   Dimension == other.Dimension &&
                   Exponent == other.Exponent &&
                   ReportId == other.ReportId;
        }
    }

    public override int GetHashCode()
    {
        int hashCode = 626647449;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + GuidType.GetHashCode();
        hashCode = hashCode * -1521134295 + Ofs.GetHashCode();
        hashCode = hashCode * -1521134295 + Type.GetHashCode();
        hashCode = hashCode * -1521134295 + Flags.GetHashCode();
        hashCode = hashCode * -1521134295 + Name.GetHashCode();
        hashCode = hashCode * -1521134295 + FFMaxForce.GetHashCode();
        hashCode = hashCode * -1521134295 + FFForceResolution.GetHashCode();
        hashCode = hashCode * -1521134295 + CollectionNumber.GetHashCode();
        hashCode = hashCode * -1521134295 + DesignatorIndex.GetHashCode();
        hashCode = hashCode * -1521134295 + UsagePage.GetHashCode();
        hashCode = hashCode * -1521134295 + Usage.GetHashCode();
        hashCode = hashCode * -1521134295 + Dimension.GetHashCode();
        hashCode = hashCode * -1521134295 + Exponent.GetHashCode();
        hashCode = hashCode * -1521134295 + ReportId.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIDEVICEOBJECTINSTANCE left, DIDEVICEOBJECTINSTANCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDEVICEOBJECTINSTANCE left, DIDEVICEOBJECTINSTANCE right)
    {
        return !(left == right);
    }
}
