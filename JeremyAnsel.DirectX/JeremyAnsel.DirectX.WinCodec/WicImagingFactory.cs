// <copyright file="WicImagingFactory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;
using JeremyAnsel.DirectX.WinCodec.Interop;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class WicImagingFactory : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicImagingFactoryGuid = typeof(IWicImagingFactory).GUID;

    private readonly nint _comPtr;
    private readonly IWicImagingFactory* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicImagingFactory"/> class.
    /// </summary>
    public WicImagingFactory(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicImagingFactory**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static WicImagingFactory Create()
    {
        nint ptr;
        int hr = NativeMethods.CoCreateInstance(
            WicGuids.CLSID_WICImagingFactory,
            0,
            NativeMethods.CLSCTX_INPROC_SERVER,
            WicImagingFactoryGuid,
            &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicImagingFactory(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dstPixelFormat"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    public static WicBitmapSource ConvertBitmapSource(in WicPixelFormatGuid dstPixelFormat, WicBitmapSource source)
    {
        nint ptr;
        int hr = NativeMethods.WICConvertBitmapSource(dstPixelFormat, source.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapSource(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="accessRights"></param>
    /// <param name="metadataOptions"></param>
    /// <returns></returns>
    public WicBitmapDecoder CreateDecoderFromFilename(string fileName, WicWin32GenericAccessRights accessRights, WicDecodeOptions metadataOptions)
    {
        return CreateDecoderFromFilename(fileName.AsSpan(), accessRights, metadataOptions);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="accessRights"></param>
    /// <param name="metadataOptions"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public WicBitmapDecoder CreateDecoderFromFilename(ReadOnlySpan<char> fileName, WicWin32GenericAccessRights accessRights, WicDecodeOptions metadataOptions)
    {
        fixed (char* str = fileName)
        {
            nint ptr;
            int hr = _comImpl->CreateDecoderFromFilename(_comPtr, str, null, accessRights, metadataOptions, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new WicBitmapDecoder(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="metadataOptions"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public WicBitmapDecoder CreateDecoderFromStream(Stream stream, WicDecodeOptions metadataOptions)
    {
        var comStream = new WicWin32ComStream(stream);
        nint ptr;
        int hr = _comImpl->CreateDecoderFromStream(_comPtr, comStream.Handle, null, metadataOptions, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapDecoder(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hFile"></param>
    /// <param name="metadataOptions"></param>
    /// <returns></returns>
    public WicBitmapDecoder CreateDecoderFromFileHandle(nint hFile, WicDecodeOptions metadataOptions)
    {
        nint ptr;
        int hr = _comImpl->CreateDecoderFromFileHandle(_comPtr, hFile, null, metadataOptions, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapDecoder(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clsidComponent"></param>
    /// <returns></returns>
    public WicComponentInfo CreateComponentInfo(in Guid clsidComponent)
    {
        nint ptr;
        int hr = _comImpl->CreateComponentInfo(_comPtr, clsidComponent, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicComponentInfo(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guidContainerFormat"></param>
    /// <returns></returns>
    public WicBitmapDecoder CreateDecoder(in Guid guidContainerFormat)
    {
        nint ptr;
        int hr = _comImpl->CreateDecoder(_comPtr, guidContainerFormat, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapDecoder(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guidContainerFormat"></param>
    /// <returns></returns>
    public WicBitmapEncoder CreateEncoder(in Guid guidContainerFormat)
    {
        nint ptr;
        int hr = _comImpl->CreateEncoder(_comPtr, guidContainerFormat, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapEncoder(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicPalette CreatePalette()
    {
        nint ptr;
        int hr = _comImpl->CreatePalette(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicPalette(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicFormatConverter CreateFormatConverter()
    {
        nint ptr;
        int hr = _comImpl->CreateFormatConverter(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicFormatConverter(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapScaler CreateBitmapScaler()
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapScaler(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapScaler(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapClipper CreateBitmapClipper()
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapClipper(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapClipper(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapFlipRotator CreateBitmapFlipRotator()
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapFlipRotator(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapFlipRotator(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColorContext CreateColorContext()
    {
        nint ptr;
        int hr = _comImpl->CreateColorContext(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicColorContext(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColorTransform CreateColorTransformer()
    {
        nint ptr;
        int hr = _comImpl->CreateColorTransformer(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicColorTransform(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiWidth"></param>
    /// <param name="uiHeight"></param>
    /// <param name="pixelFormat"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public WicBitmap CreateBitmap(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, WicBitmapCreateCacheOption option)
    {
        nint ptr;
        int hr = _comImpl->CreateBitmap(_comPtr, uiWidth, uiHeight, pixelFormat, option, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmap(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pIBitmapSource"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public WicBitmap CreateBitmapFromSource(WicBitmapSource pIBitmapSource, WicBitmapCreateCacheOption option)
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapFromSource(_comPtr, pIBitmapSource.Handle, option, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmap(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pIBitmapSource"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public WicBitmap CreateBitmapFromSourceRect(WicBitmapSource pIBitmapSource, uint x, uint y, uint width, uint height)
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapFromSourceRect(_comPtr, pIBitmapSource.Handle, x, y, width, height, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmap(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiWidth"></param>
    /// <param name="uiHeight"></param>
    /// <param name="pixelFormat"></param>
    /// <param name="cbStride"></param>
    /// <param name="buffer"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, nint buffer, int length)
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapFromMemory(_comPtr, uiWidth, uiHeight, pixelFormat, cbStride, (uint)length, (void*)buffer, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmap(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiWidth"></param>
    /// <param name="uiHeight"></param>
    /// <param name="pixelFormat"></param>
    /// <param name="cbStride"></param>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public unsafe WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, byte[] buffer)
    {
        fixed (byte* data = buffer)
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromMemory(_comPtr, uiWidth, uiHeight, pixelFormat, cbStride, (uint)buffer.Length, data, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new WicBitmap(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiWidth"></param>
    /// <param name="uiHeight"></param>
    /// <param name="pixelFormat"></param>
    /// <param name="cbStride"></param>
    /// <param name="buffer"></param>
    /// <param name="start"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public unsafe WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, byte[] buffer, int start, int length)
    {
        fixed (byte* data = buffer)
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromMemory(_comPtr, uiWidth, uiHeight, pixelFormat, cbStride, (uint)length, data + start, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new WicBitmap(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uiWidth"></param>
    /// <param name="uiHeight"></param>
    /// <param name="pixelFormat"></param>
    /// <param name="cbStride"></param>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public unsafe WicBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in WicPixelFormatGuid pixelFormat, uint cbStride, ReadOnlySpan<byte> buffer)
    {
        fixed (byte* data = buffer)
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromMemory(_comPtr, uiWidth, uiHeight, pixelFormat, cbStride, (uint)buffer.Length, data, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new WicBitmap(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hBitmap"></param>
    /// <param name="hPalette"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public WicBitmap CreateBitmapFromHBITMAP(nint hBitmap, nint hPalette, WicBitmapAlphaChannelOption options)
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapFromHBITMAP(_comPtr, hBitmap, hPalette, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmap(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hIcon"></param>
    /// <returns></returns>
    public WicBitmap CreateBitmapFromHICON(nint hIcon)
    {
        nint ptr;
        int hr = _comImpl->CreateBitmapFromHICON(_comPtr, hIcon, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmap(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Device"></param>
    /// <returns></returns>
    public WicImageEncoder CreateImageEncoder(DXComObject d2d1Device)
    {
        return CreateImageEncoder(d2d1Device.Handle);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Device"></param>
    /// <returns></returns>
    public WicImageEncoder CreateImageEncoder(nint d2d1Device)
    {
        nint device = DXUtils.QueryInterface(d2d1Device, ComInteropInterfacesGuids.D2D1DeviceGuid);

        try
        {
            nint ptr;
            int hr = _comImpl->CreateImageEncoder(_comPtr, device, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new WicImageEncoder(ptr);
        }
        finally
        {
            DXUtils.Release(device);
        }
    }
}
