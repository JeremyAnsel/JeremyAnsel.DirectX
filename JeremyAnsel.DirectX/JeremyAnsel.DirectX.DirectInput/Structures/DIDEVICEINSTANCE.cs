using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIDEVICEINSTANCE : IEquatable<DIDEVICEINSTANCE>
{
    public int Size;

    public Guid Instance;

    public Guid Product;

    public int DevType;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string InstanceName;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string ProductName;

    public Guid FFDriver;

    public short UsagePage;

    public short Usage;

    public override bool Equals(object? obj)
    {
        return obj is DIDEVICEINSTANCE dIDEVICEINSTANCE && Equals(dIDEVICEINSTANCE);
    }

    public bool Equals(DIDEVICEINSTANCE other)
    {
        return Size == other.Size &&
               Instance.Equals(other.Instance) &&
               Product.Equals(other.Product) &&
               DevType == other.DevType &&
               InstanceName == other.InstanceName &&
               ProductName == other.ProductName &&
               FFDriver.Equals(other.FFDriver) &&
               UsagePage == other.UsagePage &&
               Usage == other.Usage;
    }

    public override int GetHashCode()
    {
        int hashCode = 1722763136;
        hashCode = hashCode * -1521134295 + Size.GetHashCode();
        hashCode = hashCode * -1521134295 + Instance.GetHashCode();
        hashCode = hashCode * -1521134295 + Product.GetHashCode();
        hashCode = hashCode * -1521134295 + DevType.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(InstanceName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
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
