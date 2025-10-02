using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicImagingFactory : IDisposable
{
    private IWicImagingFactory? _handle;

    internal WicImagingFactory(IWicImagingFactory handle)
    {
        _handle = handle;
    }

    public WicImagingFactory(object handle)
    {
        _handle = (IWicImagingFactory)handle;
    }

    public static WicImagingFactory Create()
    {
        Type? t = Type.GetTypeFromCLSID(WicGuids.CLSID_WICImagingFactory);
        IWicImagingFactory? handle = null;

        if (t is not null)
        {
            handle = (IWicImagingFactory?)Activator.CreateInstance(t);
        }

        if (handle is null)
        {
            throw new InvalidOperationException("WIC imaging factory creation failed.");
        }

        return new WicImagingFactory(handle);
    }

    public static WicBitmapSource? ConvertBitmapSource(in WicPixelFormatGuid dstPixelFormat, WicBitmapSource source)
    {
        NativeMethods.WICConvertBitmapSource(dstPixelFormat, source.GetWicBitmapSource(), out IWicBitmapSource? destination);

        if (destination is null)
        {
            return null;
        }

        return new WicBitmapSource(destination);
    }

    public object Handle => _handle ?? throw new ObjectDisposedException(nameof(_handle));

    public void Dispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }
    }

    public WicBitmapDecoder CreateDecoderFromFilename(string fileName, WicWin32GenericAccessRights accessRights, WicDecodeOptions metadataOptions)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateDecoderFromFilename(fileName, IntPtr.Zero, accessRights, metadataOptions, out IWicBitmapDecoder? decoder);

        if (decoder is null)
        {
            throw new InvalidOperationException();
        }

        return new WicBitmapDecoder(decoder);
    }

    public WicBitmapDecoder CreateDecoderFromStream(Stream stream, WicDecodeOptions metadataOptions)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var comStream = new WicWin32ComStream(stream);
        _handle.CreateDecoderFromStream(comStream, IntPtr.Zero, metadataOptions, out IWicBitmapDecoder? decoder);

        if (decoder is null)
        {
            throw new InvalidOperationException();
        }

        return new WicBitmapDecoder(decoder);
    }

    public WicBitmapDecoder CreateDecoderFromFileHandle(IntPtr hFile, WicDecodeOptions metadataOptions)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateDecoderFromFileHandle(hFile, IntPtr.Zero, metadataOptions, out IWicBitmapDecoder decoder);
        return new WicBitmapDecoder(decoder);
    }

    public WicComponentInfo CreateComponentInfo(in Guid clsidComponent)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateComponentInfo(clsidComponent, out IWicComponentInfo info);
        return new WicComponentInfo(info);
    }

    public WicBitmapDecoder CreateDecoder(in Guid guidContainerFormat)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateDecoder(guidContainerFormat, IntPtr.Zero, out IWicBitmapDecoder decoder);
        return new WicBitmapDecoder(decoder);
    }

    public WicBitmapEncoder CreateEncoder(in Guid guidContainerFormat)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateEncoder(guidContainerFormat, IntPtr.Zero, out IWicBitmapEncoder encoder);
        return new WicBitmapEncoder(encoder);
    }

    public WicPalette CreatePalette()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreatePalette(out IWicPalette palette);
        return new WicPalette(palette);
    }

    public WicFormatConverter CreateFormatConverter()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateFormatConverter(out IWicFormatConverter converter);
        return new WicFormatConverter(converter);
    }

    public WicBitmapScaler CreateBitmapScaler()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapScaler(out IWicBitmapScaler scaler);
        return new WicBitmapScaler(scaler);
    }

    public WicBitmapClipper CreateBitmapClipper()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapClipper(out IWicBitmapClipper clipper);
        return new WicBitmapClipper(clipper);
    }

    public WicBitmapFlipRotator CreateBitmapFlipRotator()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapFlipRotator(out IWicBitmapFlipRotator rotator);
        return new WicBitmapFlipRotator(rotator);
    }

    public WicColorContext CreateColorContext()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateColorContext(out IWicColorContext colorContext);
        return new WicColorContext(colorContext);
    }

    public WicColorTransform CreateColorTransformer()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateColorTransformer(out IWicColorTransform transform);
        return new WicColorTransform(transform);
    }

    public WicBitmap CreateBitmap(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, WicBitmapCreateCacheOption option)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmap(uiWidth, uiHeight, pixelFormat, option, out IWicBitmap bitmap);
        return new WicBitmap(bitmap);
    }

    public WicBitmap CreateBitmapFromSource(WicBitmapSource pIBitmapSource, WicBitmapCreateCacheOption option)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapFromSource(pIBitmapSource.GetWicBitmapSource(), option, out IWicBitmap bitmap);
        return new WicBitmap(bitmap);
    }

    public WicBitmap CreateBitmapFromSourceRect(WicBitmapSource pIBitmapSource, uint x, uint y, uint width, uint height)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapFromSourceRect(pIBitmapSource.GetWicBitmapSource(), x, y, width, height, out IWicBitmap bitmap);
        return new WicBitmap(bitmap);
    }

    public WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, IntPtr buffer, int length)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapFromMemory(uiWidth, uiHeight, pixelFormat, cbStride, (uint)length, buffer, out IWicBitmap bitmap);
        return new WicBitmap(bitmap);
    }

    public unsafe WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, byte[] buffer)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        IWicBitmap bitmap;

        fixed (byte* ptr = buffer)
        {
            _handle.CreateBitmapFromMemory(uiWidth, uiHeight, pixelFormat, cbStride, (uint)buffer.Length, new IntPtr(ptr), out bitmap);
        }

        return new WicBitmap(bitmap);
    }

    public unsafe WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, byte[] buffer, int start, int length)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        IWicBitmap bitmap;

        fixed (byte* ptr = buffer)
        {
            _handle.CreateBitmapFromMemory(uiWidth, uiHeight, pixelFormat, cbStride, (uint)length, new IntPtr(ptr + start), out bitmap);
        }

        return new WicBitmap(bitmap);
    }

    public WicBitmap CreateBitmapFromHBITMAP(IntPtr hBitmap, IntPtr hPalette, WicBitmapAlphaChannelOption options)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapFromHBITMAP(hBitmap, hPalette, options, out IWicBitmap bitmap);
        return new WicBitmap(bitmap);
    }

    public WicBitmap CreateBitmapFromHICON(IntPtr hIcon)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateBitmapFromHICON(hIcon, out IWicBitmap bitmap);
        return new WicBitmap(bitmap);
    }

    public WicImageEncoder CreateImageEncoder(object d2d1Device)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateImageEncoder((ID2D1Device)d2d1Device, out IWicImageEncoder encoder);
        return new WicImageEncoder(encoder);
    }
}
