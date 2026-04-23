// <copyright file="DIDEVICEINSTANCE.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

internal unsafe struct DIDEVICEINSTANCE : IEquatable<DIDEVICEINSTANCE>
{
    public struct NameBuffer
    {
        public fixed char Buffer[Length];
        public const int Length = 260;
        public const int TotalSize = sizeof(char) * Length;
    }

    public int Size;

    public Guid Instance;

    public Guid Product;

    public int DevType;

    public NameBuffer InstanceNameBuffer;

    public string InstanceName
    {
        get
        {
            fixed (char* name = InstanceNameBuffer.Buffer)
            {
                return new string(name);
            }
        }
    }

    public NameBuffer ProductNameBuffer;

    public string ProductName
    {
        get
        {
            fixed (char* name = ProductNameBuffer.Buffer)
            {
                return new string(name);
            }
        }
    }

    public Guid FFDriver;

    public short UsagePage;

    public short Usage;

    public override bool Equals(object? obj)
    {
        return obj is DIDEVICEINSTANCE dIDEVICEINSTANCE && Equals(dIDEVICEINSTANCE);
    }

    public bool Equals(DIDEVICEINSTANCE other)
    {
        fixed (char* ptrInstanceThis = InstanceNameBuffer.Buffer)
        fixed (char* ptrProductThis = ProductNameBuffer.Buffer)
        {
            ReadOnlySpan<char> spanInstanceThis = new(ptrInstanceThis, NameBuffer.Length);
            ReadOnlySpan<char> spanInstanceOther = new(other.InstanceNameBuffer.Buffer, NameBuffer.Length);
            ReadOnlySpan<char> spanProductThis = new(ptrProductThis, NameBuffer.Length);
            ReadOnlySpan<char> spanProductOther = new(other.ProductNameBuffer.Buffer, NameBuffer.Length);

            return Size == other.Size &&
                   Instance.Equals(other.Instance) &&
                   Product.Equals(other.Product) &&
                   DevType == other.DevType &&
                   MemoryExtensions.Equals(spanInstanceThis, spanInstanceOther, StringComparison.Ordinal) &&
                   MemoryExtensions.Equals(spanProductThis, spanProductOther, StringComparison.Ordinal) &&
                   FFDriver.Equals(other.FFDriver) &&
                   UsagePage == other.UsagePage &&
                   Usage == other.Usage;
        }
    }

    public override int GetHashCode()
    {
        int hashCode = 1722763136;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + Instance.GetHashCode();
        hashCode = hashCode * -1521134295 + Product.GetHashCode();
        hashCode = hashCode * -1521134295 + DevType.GetHashCode();
        hashCode = hashCode * -1521134295 + InstanceName.GetHashCode();
        hashCode = hashCode * -1521134295 + ProductName.GetHashCode();
        hashCode = hashCode * -1521134295 + FFDriver.GetHashCode();
        hashCode = hashCode * -1521134295 + UsagePage.GetHashCode();
        hashCode = hashCode * -1521134295 + Usage.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(DIDEVICEINSTANCE left, DIDEVICEINSTANCE right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(DIDEVICEINSTANCE left, DIDEVICEINSTANCE right)
    {
        return !(left == right);
    }
}
