// <copyright file="WicGuids.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public static class WicGuids
{
    /*=========================================================================*\
    SDK Version
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICImagingFactory = new(0x317d06e8, 0x5f24, 0x433d, 0xbd, 0xf7, 0x79, 0xce, 0x68, 0xd8, 0xab, 0xc2);

    /*=========================================================================*\
    GUID Identifiers for the vendors
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_VendorMicrosoft = new(0xf0e749ca, 0xedef, 0x4589, 0xa7, 0x3a, 0xee, 0xe, 0x62, 0x6a, 0x2a, 0x2b);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_VendorMicrosoftBuiltIn = new(0x257a30fd, 0x6b6, 0x462b, 0xae, 0xa4, 0x63, 0xf7, 0xb, 0x86, 0xe5, 0x33);


    /*=========================================================================*\
    GUID Identifiers for the codecs
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICPngDecoder = new(0xe018945b, 0xaa86, 0x4008, 0x9b, 0xd4, 0x67, 0x77, 0xa1, 0xe4, 0x0c, 0x11);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICBmpDecoder = new(0x6b462062, 0x7cbf, 0x400d, 0x9f, 0xdb, 0x81, 0x3d, 0xd1, 0x0f, 0x27, 0x78);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICIcoDecoder = new(0xc61bfcdf, 0x2e0f, 0x4aad, 0xa8, 0xd7, 0xe0, 0x6b, 0xaf, 0xeb, 0xcd, 0xfe);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICJpegDecoder = new(0x9456a480, 0xe88b, 0x43ea, 0x9e, 0x73, 0x0b, 0x2d, 0x9b, 0x71, 0xb1, 0xca);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICGifDecoder = new(0x381dda3c, 0x9ce9, 0x4834, 0xa2, 0x3e, 0x1f, 0x98, 0xf8, 0xfc, 0x52, 0xbe);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICTiffDecoder = new(0xb54e85d9, 0xfe23, 0x499f, 0x8b, 0x88, 0x6a, 0xce, 0xa7, 0x13, 0x75, 0x2b);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICWmpDecoder = new(0xa26cec36, 0x234c, 0x4950, 0xae, 0x16, 0xe3, 0x4a, 0xac, 0xe7, 0x1d, 0x0d);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICDdsDecoder = new(0x9053699f, 0xa341, 0x429d, 0x9e, 0x90, 0xee, 0x43, 0x7c, 0xf8, 0x0c, 0x73);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICBmpEncoder = new(0x69be8bb4, 0xd66d, 0x47c8, 0x86, 0x5a, 0xed, 0x15, 0x89, 0x43, 0x37, 0x82);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICPngEncoder = new(0x27949969, 0x876a, 0x41d7, 0x94, 0x47, 0x56, 0x8f, 0x6a, 0x35, 0xa4, 0xdc);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICJpegEncoder = new(0x1a34f5c1, 0x4a5a, 0x46dc, 0xb6, 0x44, 0x1f, 0x45, 0x67, 0xe7, 0xa6, 0x76);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICGifEncoder = new(0x114f5598, 0x0b22, 0x40a0, 0x86, 0xa1, 0xc8, 0x3e, 0xa4, 0x95, 0xad, 0xbd);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICTiffEncoder = new(0x0131be10, 0x2001, 0x4c5f, 0xa9, 0xb0, 0xcc, 0x88, 0xfa, 0xb6, 0x4c, 0xe8);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICWmpEncoder = new(0xac4ce3cb, 0xe1c1, 0x44cd, 0x82, 0x15, 0x5a, 0x16, 0x65, 0x50, 0x9e, 0xc2);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICDdsEncoder = new(0xa61dde94, 0x66ce, 0x4ac1, 0x88, 0x1b, 0x71, 0x68, 0x05, 0x88, 0x89, 0x5e);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICAdngDecoder = new(0x981d9411, 0x909e, 0x42a7, 0x8f, 0x5d, 0xa7, 0x47, 0xff, 0x05, 0x2e, 0xdb);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICJpegQualcommPhoneEncoder = new(0x68ed5c62, 0xf534, 0x4979, 0xb2, 0xb3, 0x68, 0x6a, 0x12, 0xb2, 0xb3, 0x4c);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICHeifDecoder = new(0xe9A4A80a, 0x44fe, 0x4DE4, 0x89, 0x71, 0x71, 0x50, 0XB1, 0X0a, 0X51, 0X99);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICHeifEncoder = new(0x0dbecec1, 0x9eb3, 0x4860, 0x9c, 0x6f, 0xdd, 0xbe, 0x86, 0x63, 0x45, 0x75);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICWebpDecoder = new(0x7693E886, 0x51C9, 0x4070, 0x84, 0x19, 0x9F, 0x70, 0X73, 0X8E, 0XC8, 0XFA);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICRAWDecoder = new(0x41945702, 0x8302, 0x44A6, 0x94, 0x45, 0xAC, 0x98, 0xE8, 0xAF, 0xA0, 0x86);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICJpegXLDecoder = new(0xfc6ceece, 0xaef5, 0x4a23, 0x96, 0xec, 0x59, 0x84, 0xff, 0xb4, 0x86, 0xd9);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICJpegXLEncoder = new(0x0e4ecd3b, 0x1ba6, 0x4636, 0x81, 0x98, 0x56, 0xc7, 0x30, 0x40, 0x96, 0x4a);

    /*=========================================================================*\
    GUID Identifiers for the image container formats
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatBmp = new(0x0af1d87e, 0xfcfe, 0x4188, 0xbd, 0xeb, 0xa7, 0x90, 0x64, 0x71, 0xcb, 0xe3);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatPng = new(0x1b7cfaf4, 0x713f, 0x473c, 0xbb, 0xcd, 0x61, 0x37, 0x42, 0x5f, 0xae, 0xaf);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatIco = new(0xa3a860c4, 0x338f, 0x4c17, 0x91, 0x9a, 0xfb, 0xa4, 0xb5, 0x62, 0x8f, 0x21);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatJpeg = new(0x19e4a5aa, 0x5662, 0x4fc5, 0xa0, 0xc0, 0x17, 0x58, 0x02, 0x8e, 0x10, 0x57);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatTiff = new(0x163bcc30, 0xe2e9, 0x4f0b, 0x96, 0x1d, 0xa3, 0xe9, 0xfd, 0xb7, 0x88, 0xa3);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatGif = new(0x1f8a5601, 0x7d4d, 0x4cbd, 0x9c, 0x82, 0x1b, 0xc8, 0xd4, 0xee, 0xb9, 0xa5);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatWmp = new(0x57a37caa, 0x367a, 0x4540, 0x91, 0x6b, 0xf1, 0x83, 0xc5, 0x09, 0x3a, 0x4b);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatDds = new(0x9967cb95, 0x2e85, 0x4ac8, 0x8c, 0xa2, 0x83, 0xd7, 0xcc, 0xd4, 0x25, 0xc9);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatAdng = new(0xf3ff6d0d, 0x38c0, 0x41c4, 0xb1, 0xfe, 0x1f, 0x38, 0x24, 0xf1, 0x7b, 0x84);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatHeif = new(0xe1e62521, 0x6787, 0x405b, 0xa3, 0x39, 0x50, 0x07, 0x15, 0xb5, 0x76, 0x3f);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatWebp = new(0xe094b0e2, 0x67f2, 0x45b3, 0xb0, 0xea, 0x11, 0x53, 0x37, 0xca, 0x7c, 0xf3);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatRaw = new(0xfe99ce60, 0xf19c, 0x433c, 0xa3, 0xae, 0x00, 0xac, 0xef, 0xa9, 0xca, 0x21);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid GUID_ContainerFormatJpegXL = new(0xfec14e3f, 0x427a, 0x4736, 0xaa, 0xe6, 0x27, 0xed, 0x84, 0xf6, 0x93, 0x22);

    /*=========================================================================*\
    Category Identifiers
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICImagingCategories = new(0xfae3d380, 0xfea4, 0x4623, 0x8c, 0x75, 0xc6, 0xb6, 0x11, 0x10, 0xb6, 0x81);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CATID_WICBitmapDecoders = new(0x7ed96837, 0x96f0, 0x4812, 0xb2, 0x11, 0xf1, 0x3c, 0x24, 0x11, 0x7e, 0xd3);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CATID_WICBitmapEncoders = new(0xac757296, 0x3522, 0x4e11, 0x98, 0x62, 0xc1, 0x7b, 0xe5, 0xa1, 0x76, 0x7e);

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid CATID_WICPixelFormats = new(new Guid(0x2b46e70f, 0xcda7, 0x473e, 0x89, 0xf6, 0xdc, 0x96, 0x30, 0xa2, 0x39, 0x0b));

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CATID_WICFormatConverters = new(0x7835eae8, 0xbf14, 0x49d1, 0x93, 0xce, 0x53, 0x3a, 0x40, 0x7b, 0x22, 0x48);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CATID_WICMetadataReader = new(0x05af94d8, 0x7174, 0x4cd2, 0xbe, 0x4a, 0x41, 0x24, 0xb8, 0x0e, 0xe4, 0xb8);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CATID_WICMetadataWriter = new(0xabe3b9a4, 0x257d, 0x4b97, 0xbd, 0x1a, 0x29, 0x4a, 0xf4, 0x96, 0x22, 0x2e);


    /*=========================================================================*\
    Format converters
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICDefaultFormatConverter = new(0x1a3f11dc, 0xb514, 0x4b17, 0x8c, 0x5f, 0x21, 0x54, 0x51, 0x38, 0x52, 0xf1);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICFormatConverterHighColor = new(0xac75d454, 0x9f37, 0x48f8, 0xb9, 0x72, 0x4e, 0x19, 0xbc, 0x85, 0x60, 0x11);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICFormatConverterNChannel = new(0xc17cabb2, 0xd4a3, 0x47d7, 0xa5, 0x57, 0x33, 0x9b, 0x2e, 0xfb, 0xd4, 0xf1);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICFormatConverterWMPhoto = new(0x9cb5172b, 0xd600, 0x46ba, 0xab, 0x77, 0x77, 0xbb, 0x7e, 0x3a, 0x00, 0xd9);

    /// <summary>
    /// 
    /// </summary>
    public static readonly Guid CLSID_WICPlanarFormatConverter = new(0x184132b8, 0x32f8, 0x4784, 0x91, 0x31, 0xdd, 0x72, 0x24, 0xb2, 0x34, 0x38);

    /*=========================================================================*\
    Pixel Format GUIDs
    \*=========================================================================*/

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormatUndefined = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x00));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat1bppIndexed = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x01));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat2bppIndexed = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x02));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat4bppIndexed = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x03));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppIndexed = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x04));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormatBlackWhite = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x05));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat2bppGray = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x06));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat4bppGray = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x07));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppGray = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x08));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppAlpha = new(new Guid(0xe6cd0116, 0xeeba, 0x4161, 0xaa, 0x85, 0x27, 0xdd, 0x9f, 0xb3, 0xa8, 0x95));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppDepth = new(new Guid(0x4c9c9f45, 0x1d89, 0x4e31, 0x9b, 0xc7, 0x69, 0x34, 0x3a, 0x0d, 0xca, 0x69));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppGain = new(new Guid(0xa884022a, 0xaf13, 0x4c16, 0xb7, 0x46, 0x61, 0x9b, 0xf6, 0x18, 0xb8, 0x78));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat24bppRGBGain = new(new Guid(0xa5022b24, 0x7109, 0x443b, 0x99, 0x48, 0x25, 0xb6, 0xed, 0x8f, 0x39, 0xfd));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppBGRGain = new(new Guid(0x837d6738, 0x208a, 0x43e0, 0x89, 0x95, 0x79, 0xab, 0x74, 0x40, 0x74, 0x02));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppBGR555 = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x09));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppBGR565 = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0a));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppBGRA5551 = new(new Guid(0x05ec7c2b, 0xf1e6, 0x4961, 0xad, 0x46, 0xe1, 0xcc, 0x81, 0x0a, 0x87, 0xd2));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppGray = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0b));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat24bppBGR = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0c));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat24bppRGB = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0d));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppBGR = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0e));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppBGRA = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0f));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppPBGRA = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x10));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppGrayFloat = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x11));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppRGB = new(new Guid(0xd98c6b95, 0x3efe, 0x47d6, 0xbb, 0x25, 0xeb, 0x17, 0x48, 0xab, 0x0c, 0xf1));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppRGBA = new(new Guid(0xf5c7ad2d, 0x6a8d, 0x43dd, 0xa7, 0xa8, 0xa2, 0x99, 0x35, 0x26, 0x1a, 0xe9));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppPRGBA = new(new Guid(0x3cc4a650, 0xa527, 0x4d37, 0xa9, 0x16, 0x31, 0x42, 0xc7, 0xeb, 0xed, 0xba));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bppRGB = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x15));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bppBGR = new(new Guid(0xe605a384, 0xb468, 0x46ce, 0xbb, 0x2e, 0x36, 0xf1, 0x80, 0xe6, 0x43, 0x13));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppRGB = new(new Guid(0xa1182111, 0x186d, 0x4d42, 0xbc, 0x6a, 0x9c, 0x83, 0x03, 0xa8, 0xdf, 0xf9));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppRGBA = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x16));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppBGRA = new(new Guid(0x1562ff7c, 0xd352, 0x46f9, 0x97, 0x9e, 0x42, 0x97, 0x6b, 0x79, 0x22, 0x46));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppPRGBA = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x17));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppPBGRA = new(new Guid(0x8c518e8e, 0xa4ec, 0x468b, 0xae, 0x70, 0xc9, 0xa3, 0x5a, 0x9c, 0x55, 0x30));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppGrayFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x13));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppBGR101010 = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x14));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bppRGBFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x12));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bppBGRFixedPoint = new(new Guid(0x49ca140e, 0xcab6, 0x493b, 0x9d, 0xdf, 0x60, 0x18, 0x7c, 0x37, 0x53, 0x2a));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat96bppRGBFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x18));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat96bppRGBFloat = new(new Guid(0xe3fed78f, 0xe8db, 0x4acf, 0x84, 0xc1, 0xe9, 0x7f, 0x61, 0x36, 0xb3, 0x27));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bppRGBAFloat = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x19));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bppPRGBAFloat = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1a));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bppRGBFloat = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1b));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppCMYK = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1c));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppRGBAFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1d));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppBGRAFixedPoint = new(new Guid(0x356de33c, 0x54d2, 0x4a23, 0xbb, 0x4, 0x9b, 0x7b, 0xf9, 0xb1, 0xd4, 0x2d));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppRGBFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x40));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bppRGBAFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1e));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bppRGBFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x41));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppRGBAHalf = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3a));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppPRGBAHalf = new(new Guid(0x58ad26c2, 0xc623, 0x4d9d, 0xb3, 0x20, 0x38, 0x7e, 0x49, 0xf8, 0xc4, 0x42));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppRGBHalf = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x42));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bppRGBHalf = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3b));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppRGBE = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3d));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppGrayHalf = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3e));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppGrayFixedPoint = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3f));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppRGBA1010102 = new(new Guid(0x25238D72, 0xFCF9, 0x4522, 0xb5, 0x14, 0x55, 0x78, 0xe5, 0xad, 0x55, 0xe0));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppRGBA1010102XR = new(new Guid(0x00DE6B9A, 0xC101, 0x434b, 0xb5, 0x02, 0xd0, 0x16, 0x5e, 0xe1, 0x12, 0x2c));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppR10G10B10A2 = new(new Guid(0x604e1bb5, 0x8a3c, 0x4b65, 0xb1, 0x1c, 0xbc, 0x0b, 0x8d, 0xd7, 0x5b, 0x7f));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bppR10G10B10A2HDR10 = new(new Guid(0x9c215c5d, 0x1acc, 0x4f0e, 0xa4, 0xbc, 0x70, 0xfb, 0x3a, 0xe8, 0xfd, 0x28));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bppCMYK = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1f));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat24bpp3Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x20));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bpp4Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x21));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat40bpp5Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x22));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bpp6Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x23));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat56bpp7Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x24));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bpp8Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x25));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bpp3Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x26));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bpp4Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x27));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat80bpp5Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x28));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat96bpp6Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x29));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat112bpp7Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2a));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bpp8Channels = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2b));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat40bppCMYKAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2c));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat80bppCMYKAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2d));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat32bpp3ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2e));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat40bpp4ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2f));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat48bpp5ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x30));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat56bpp6ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x31));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bpp7ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x32));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat72bpp8ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x33));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat64bpp3ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x34));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat80bpp4ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x35));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat96bpp5ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x36));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat112bpp6ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x37));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat128bpp7ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x38));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat144bpp8ChannelsAlpha = new(new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x39));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppY = new(new Guid(0x91B4DB54, 0x2DF9, 0x42F0, 0xB4, 0x49, 0x29, 0x09, 0xBB, 0x3D, 0xF8, 0x8E));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppCb = new(new Guid(0x1339F224, 0x6BFE, 0x4C3E, 0x93, 0x02, 0xE4, 0xF3, 0xA6, 0xD0, 0xCA, 0x2A));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat8bppCr = new(new Guid(0xB8145053, 0x2116, 0x49F0, 0x88, 0x35, 0xED, 0x84, 0x4B, 0x20, 0x5C, 0x51));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppCbCr = new(new Guid(0xFF95BA6E, 0x11E0, 0x4263, 0xBB, 0x45, 0x01, 0x72, 0x1F, 0x34, 0x60, 0xA4));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppYQuantizedDctCoefficients = new(new Guid(0xA355F433, 0x48E8, 0x4A42, 0x84, 0xD8, 0xE2, 0xAA, 0x26, 0xCA, 0x80, 0xA4));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppCbQuantizedDctCoefficients = new(new Guid(0xD2C4FF61, 0x56A5, 0x49C2, 0x8B, 0x5C, 0x4C, 0x19, 0x25, 0x96, 0x48, 0x37));

    /// <summary>
    /// 
    /// </summary>
    public static readonly WicPixelFormatGuid GUID_WICPixelFormat16bppCrQuantizedDctCoefficients = new(new Guid(0x2FE354F0, 0x1680, 0x42D8, 0x92, 0x31, 0xE7, 0x3C, 0x05, 0x65, 0xBF, 0xC1));
}
