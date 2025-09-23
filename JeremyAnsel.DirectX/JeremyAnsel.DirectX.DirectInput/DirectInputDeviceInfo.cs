namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputDeviceInfo
{
    internal DirectInputDeviceInfo(in DIDEVICEINSTANCE di)
    {
        Instance = di.Instance;
        Product = di.Product;
        InstanceName = di.InstanceName;
        ProductName = di.ProductName;
        FFDriver = di.FFDriver;
    }

    public Guid Instance { get; }

    public Guid Product { get; }

    public string InstanceName { get; }

    public string ProductName { get; }

    public Guid FFDriver { get; }
}
