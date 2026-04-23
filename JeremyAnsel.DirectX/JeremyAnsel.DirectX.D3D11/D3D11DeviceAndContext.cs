using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// 
/// </summary>
[SkipLocalsInit]
public unsafe sealed class D3D11DeviceAndContext : IDisposable
{
    private readonly D3D11Device _device;
    private readonly D3D11DeviceContext _context;
    private readonly D3D11FeatureLevel _featureLevel;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="device"></param>
    /// <param name="context"></param>
    /// <param name="featureLevel"></param>
    public D3D11DeviceAndContext(D3D11Device device, D3D11DeviceContext context, D3D11FeatureLevel featureLevel)
    {
        _device = device;
        _context = context;
        _featureLevel = featureLevel;
    }

    /// <summary>
    /// 
    /// </summary>
    public D3D11Device Device
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _device;
    }

    /// <summary>
    /// 
    /// </summary>
    public D3D11DeviceContext Context
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _context;
    }

    /// <summary>
    /// 
    /// </summary>
    public D3D11FeatureLevel FeatureLevel
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _featureLevel;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        _device.Dispose();
        _context.Dispose();
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel[]? featureLevels)
    {
        return Create(0, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        ReadOnlySpan<D3D11FeatureLevel> featureLevels)
    {
        return Create(0, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel[]? featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        ReadOnlySpan<D3D11FeatureLevel> featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter1 adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel[]? featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter1 adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        ReadOnlySpan<D3D11FeatureLevel> featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter2 adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel[]? featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter2 adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        ReadOnlySpan<D3D11FeatureLevel> featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter3 adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel[]? featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        DxgiAdapter3 adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        ReadOnlySpan<D3D11FeatureLevel> featureLevels)
    {
        return Create(adapter.Handle, driverType, options, featureLevels);
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        nint adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel[]? featureLevels)
    {
        return Create(adapter, driverType, options, featureLevels.AsSpan());
    }

    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <returns>The device, context, and feature level.</returns>
    public static D3D11DeviceAndContext Create(
        nint adapter,
        D3D11DriverType driverType,
        D3D11CreateDeviceOptions options,
        ReadOnlySpan<D3D11FeatureLevel> featureLevels)
    {
        int maxCount = Math.Max(7, featureLevels.Length);
        D3D11FeatureLevel* levelsPtr = stackalloc D3D11FeatureLevel[maxCount];
        int levelsCount;

        if (featureLevels.Length == 0)
        {
            levelsCount = 7;
            levelsPtr[0] = D3D11FeatureLevel.FeatureLevel111;
            levelsPtr[1] = D3D11FeatureLevel.FeatureLevel110;
            levelsPtr[2] = D3D11FeatureLevel.FeatureLevel101;
            levelsPtr[3] = D3D11FeatureLevel.FeatureLevel100;
            levelsPtr[4] = D3D11FeatureLevel.FeatureLevel93;
            levelsPtr[5] = D3D11FeatureLevel.FeatureLevel92;
            levelsPtr[6] = D3D11FeatureLevel.FeatureLevel91;
        }
        else
        {
            levelsCount = featureLevels.Length;
            featureLevels.CopyTo(new Span<D3D11FeatureLevel>(levelsPtr, featureLevels.Length));
        }

        nint deviceInterface;
        nint immediateContextInterface;
        D3D11FeatureLevel level;

        int hr = NativeMethods.D3D11CreateDevice(
            adapter,
            driverType,
            IntPtr.Zero,
            options,
            levelsPtr,
            (uint)levelsCount,
            7, // SDK_VERSION
            &deviceInterface,
            &level,
            &immediateContextInterface);

        Marshal.ThrowExceptionForHR(hr);
        return new D3D11DeviceAndContext(new(deviceInterface), new(immediateContextInterface), level);
    }
}
