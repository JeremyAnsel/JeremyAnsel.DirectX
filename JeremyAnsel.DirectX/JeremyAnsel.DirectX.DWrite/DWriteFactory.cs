// <copyright file="DWriteFactory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The root factory interface for all DWrite objects.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFactory : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFactoryGuid = typeof(IDWriteFactory).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFactory* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFactory"/> class.
    /// </summary>
    public DWriteFactory(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFactory**)comPtr;
    }

    /// <summary>
    /// Creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.
    /// </summary>
    /// <remarks>
    /// Obtains DirectWrite factory object that is used for subsequent creation of individual DirectWrite classes.
    /// DirectWrite factory contains internal state such as font loader registration and cached font data.
    /// In most cases it is recommended to use the shared factory object, because it allows multiple components
    /// that use DirectWrite to share internal DirectWrite state and reduce memory usage.
    /// However, there are cases when it is desirable to reduce the impact of a component,
    /// such as a plug-in from an untrusted source, on the rest of the process by sandboxing and isolating it
    /// from the rest of the process components. In such cases, it is recommended to use an isolated factory for the sandboxed
    /// component.
    /// </remarks>
    /// <returns><see cref="DWriteFactory"/></returns>
    public static DWriteFactory Create()
    {
        return Create(DWriteFactoryType.Shared);
    }

    /// <summary>
    /// Creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.
    /// </summary>
    /// <param name="factoryType">Identifies whether the factory object will be shared or isolated.</param>
    /// <remarks>
    /// Obtains DirectWrite factory object that is used for subsequent creation of individual DirectWrite classes.
    /// DirectWrite factory contains internal state such as font loader registration and cached font data.
    /// In most cases it is recommended to use the shared factory object, because it allows multiple components
    /// that use DirectWrite to share internal DirectWrite state and reduce memory usage.
    /// However, there are cases when it is desirable to reduce the impact of a component,
    /// such as a plug-in from an untrusted source, on the rest of the process by sandboxing and isolating it
    /// from the rest of the process components. In such cases, it is recommended to use an isolated factory for the sandboxed
    /// component.
    /// </remarks>
    /// <returns><see cref="DWriteFactory"/></returns>
    public static DWriteFactory Create(DWriteFactoryType factoryType)
    {
        nint ptr;
        int hr = NativeMethods.DWriteCreateFactory(factoryType, typeof(IDWriteFactory).GUID, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFactory(ptr);
    }

    /// <summary>
    /// Gets a font collection representing the set of installed fonts.
    /// </summary>
    /// <returns><see cref="DWriteFontCollection"/></returns>
    public DWriteFontCollection GetSystemFontCollection()
    {
        return GetSystemFontCollection(false);
    }

    /// <summary>
    /// Gets a font collection representing the set of installed fonts.
    /// </summary>
    /// <param name="checkForUpdates">If this parameter is nonzero, the function performs an immediate check for changes to the set of
    /// installed fonts. If this parameter is FALSE, the function will still detect changes if the font cache service is running, but
    /// there may be some latency. For example, an application might specify TRUE if it has itself just installed a font and wants to 
    /// be sure the font collection contains that font.</param>
    /// <returns><see cref="DWriteFontCollection"/></returns>
    public DWriteFontCollection GetSystemFontCollection(bool checkForUpdates)
    {
        nint ptr;
        int hr = _comImpl->GetSystemFontCollection(_comPtr, &ptr, checkForUpdates ? 1 : 0);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontCollection(ptr);
    }

    /// <summary>
    /// CreateFontFileReference creates a font file reference object from a local font file.
    /// </summary>
    /// <param name="filePath">Absolute file path. Subsequent operations on the constructed object may fail
    /// if the user provided filePath doesn't correspond to a valid file on the disk.</param>
    /// <param name="lastWriteTime">Last modified time of the input file path. If the parameter is omitted,
    /// the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value
    /// to avoid extra disk access. Subsequent operations on the constructed object may fail
    /// if the user provided lastWriteTime doesn't match the file on the disk.</param>
    /// <returns><see cref="DWriteFontFile"/></returns>
    public DWriteFontFile CreateFontFileReference(string filePath)
    {
        return CreateFontFileReference(filePath.AsSpan(), 0);
    }

    /// <summary>
    /// CreateFontFileReference creates a font file reference object from a local font file.
    /// </summary>
    /// <param name="filePath">Absolute file path. Subsequent operations on the constructed object may fail
    /// if the user provided filePath doesn't correspond to a valid file on the disk.</param>
    /// <param name="lastWriteTime">Last modified time of the input file path. If the parameter is omitted,
    /// the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value
    /// to avoid extra disk access. Subsequent operations on the constructed object may fail
    /// if the user provided lastWriteTime doesn't match the file on the disk.</param>
    /// <returns><see cref="DWriteFontFile"/></returns>
    public DWriteFontFile CreateFontFileReference(string filePath, ulong lastWriteTime)
    {
        return CreateFontFileReference(filePath.AsSpan(), lastWriteTime);
    }

    /// <summary>
    /// CreateFontFileReference creates a font file reference object from a local font file.
    /// </summary>
    /// <param name="filePath">Absolute file path. Subsequent operations on the constructed object may fail
    /// if the user provided filePath doesn't correspond to a valid file on the disk.</param>
    /// <param name="lastWriteTime">Last modified time of the input file path. If the parameter is omitted,
    /// the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value
    /// to avoid extra disk access. Subsequent operations on the constructed object may fail
    /// if the user provided lastWriteTime doesn't match the file on the disk.</param>
    /// <returns><see cref="DWriteFontFile"/></returns>
    public DWriteFontFile CreateFontFileReference(ReadOnlySpan<char> filePath)
    {
        return CreateFontFileReference(filePath, 0);
    }

    /// <summary>
    /// CreateFontFileReference creates a font file reference object from a local font file.
    /// </summary>
    /// <param name="filePath">Absolute file path. Subsequent operations on the constructed object may fail
    /// if the user provided filePath doesn't correspond to a valid file on the disk.</param>
    /// <param name="lastWriteTime">Last modified time of the input file path. If the parameter is omitted,
    /// the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value
    /// to avoid extra disk access. Subsequent operations on the constructed object may fail
    /// if the user provided lastWriteTime doesn't match the file on the disk.</param>
    /// <returns><see cref="DWriteFontFile"/></returns>
    public DWriteFontFile CreateFontFileReference(ReadOnlySpan<char> filePath, ulong lastWriteTime)
    {
        fixed (char* filePathPtr = filePath)
        {
            ulong* lastWriteTimePtr = lastWriteTime == 0 ? null : &lastWriteTime;
            nint ptr;
            int hr = _comImpl->CreateFontFileReference(_comPtr, filePathPtr, lastWriteTimePtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new DWriteFontFile(ptr);
        }
    }

    /// <summary>
    /// Creates a font face object.
    /// </summary>
    /// <param name="fontFaceType">The file format of the font face.</param>
    /// <param name="fontFiles">Font files representing the font face. Since IDWriteFontFace maintains its own references
    /// to the input font file objects, it's OK to release them after this call.</param>
    /// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces.
    /// If the font files contain a single face, this value should be zero.</param>
    /// <param name="fontFaceSimulation">Font face simulation flags for algorithmic emboldening and italicization.</param>
    /// <returns><see cref="DWriteFontFace"/></returns>
    public DWriteFontFace CreateFontFace(DWriteFontFaceType fontFaceType, DWriteFontFile[]? fontFiles, uint faceIndex, DWriteFontSimulations fontFaceSimulation)
    {
        return CreateFontFace(fontFaceType, fontFiles.AsSpan(), faceIndex, fontFaceSimulation);
    }

    /// <summary>
    /// Creates a font face object.
    /// </summary>
    /// <param name="fontFaceType">The file format of the font face.</param>
    /// <param name="fontFiles">Font files representing the font face. Since IDWriteFontFace maintains its own references
    /// to the input font file objects, it's OK to release them after this call.</param>
    /// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces.
    /// If the font files contain a single face, this value should be zero.</param>
    /// <param name="fontFaceSimulation">Font face simulation flags for algorithmic emboldening and italicization.</param>
    /// <returns><see cref="DWriteFontFace"/></returns>
    public DWriteFontFace CreateFontFace(DWriteFontFaceType fontFaceType, ReadOnlySpan<DWriteFontFile> fontFiles, uint faceIndex, DWriteFontSimulations fontFaceSimulation)
    {
        if (fontFiles.Length == 0)
        {
            throw new ArgumentNullException(nameof(fontFiles));
        }

        nint* fontFilesPtr = stackalloc nint[fontFiles.Length];
        for (int i = 0; i < fontFiles.Length; i++)
        {
            fontFilesPtr[i] = fontFiles[i].Handle;
        }

        nint ptr;
        int hr = _comImpl->CreateFontFace(_comPtr, fontFaceType, (uint)fontFiles.Length, fontFilesPtr, faceIndex, fontFaceSimulation, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontFace(ptr);
    }

    /// <summary>
    /// Creates a font face object.
    /// </summary>
    /// <param name="fontFaceType">The file format of the font face.</param>
    /// <param name="fontFiles">Font files representing the font face. Since IDWriteFontFace maintains its own references
    /// to the input font file objects, it's OK to release them after this call.</param>
    /// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces.
    /// If the font files contain a single face, this value should be zero.</param>
    /// <param name="fontFaceSimulation">Font face simulation flags for algorithmic emboldening and italicization.</param>
    /// <returns><see cref="DWriteFontFace"/></returns>
    public DWriteFontFace CreateFontFace(DWriteFontFaceType fontFaceType, DWriteFontFile fontFiles, uint faceIndex, DWriteFontSimulations fontFaceSimulation)
    {
        nint fontFilesPtr = fontFiles.Handle;
        nint ptr;
        int hr = _comImpl->CreateFontFace(_comPtr, fontFaceType, 1, &fontFilesPtr, faceIndex, fontFaceSimulation, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontFace(ptr);
    }

    /// <summary>
    /// Creates a rendering parameters object with default settings for the primary monitor.
    /// </summary>
    /// <returns><see cref="DWriteRenderingParams"/></returns>
    public DWriteRenderingParams CreateRenderingParams()
    {
        nint ptr;
        int hr = _comImpl->CreateRenderingParams(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteRenderingParams(ptr);
    }

    /// <summary>
    /// Creates a rendering parameters object with default settings for the specified monitor.
    /// </summary>
    /// <param name="monitor">The monitor to read the default values from.</param>
    /// <returns><see cref="DWriteRenderingParams"/></returns>
    public DWriteRenderingParams CreateMonitorRenderingParams(nint monitor)
    {
        nint ptr;
        int hr = _comImpl->CreateMonitorRenderingParams(_comPtr, monitor, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteRenderingParams(ptr);
    }

    /// <summary>
    /// Creates a rendering parameters object with the specified properties.
    /// </summary>
    /// <param name="gamma">The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</param>
    /// <param name="enhancedContrast">The amount of contrast enhancement, zero or greater.</param>
    /// <param name="clearTypeLevel">The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</param>
    /// <param name="pixelGeometry">The geometry of a device pixel.</param>
    /// <param name="renderingMode">Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.</param>
    /// <returns><see cref="DWriteRenderingParams"/></returns>
    public DWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWritePixelGeometry pixelGeometry, DWriteRenderingMode renderingMode)
    {
        nint ptr;
        int hr = _comImpl->CreateCustomRenderingParams(_comPtr, gamma, enhancedContrast, clearTypeLevel, pixelGeometry, renderingMode, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteRenderingParams(ptr);
    }

    /// <summary>
    /// Create a text format object used for text layout.
    /// </summary>
    /// <param name="fontFamilyName">Name of the font family</param>
    /// <param name="fontCollection">Font collection. NULL indicates the system font collection.</param>
    /// <param name="fontWeight">Font weight</param>
    /// <param name="fontStyle">Font style</param>
    /// <param name="fontStretch">Font stretch</param>
    /// <param name="fontSize">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
    /// <param name="localeName">Locale name</param>
    /// <returns><see cref="DWriteTextFormat"/></returns>
    public DWriteTextFormat CreateTextFormat(
        string fontFamilyName,
        DWriteFontCollection? fontCollection,
        DWriteFontWeight fontWeight,
        DWriteFontStyle fontStyle,
        DWriteFontStretch fontStretch,
        float fontSize,
        string localeName)
    {
        return CreateTextFormat(fontFamilyName.AsSpan(), fontCollection, fontWeight, fontStyle, fontStretch, fontSize, localeName.AsSpan());
    }

    /// <summary>
    /// Create a text format object used for text layout.
    /// </summary>
    /// <param name="fontFamilyName">Name of the font family</param>
    /// <param name="fontCollection">Font collection. NULL indicates the system font collection.</param>
    /// <param name="fontWeight">Font weight</param>
    /// <param name="fontStyle">Font style</param>
    /// <param name="fontStretch">Font stretch</param>
    /// <param name="fontSize">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
    /// <param name="localeName">Locale name</param>
    /// <returns><see cref="DWriteTextFormat"/></returns>
    public DWriteTextFormat CreateTextFormat(
        ReadOnlySpan<char> fontFamilyName,
        DWriteFontCollection? fontCollection,
        DWriteFontWeight fontWeight,
        DWriteFontStyle fontStyle,
        DWriteFontStretch fontStretch,
        float fontSize,
        ReadOnlySpan<char> localeName)
    {
        fixed (char* fontFamilyNamePtr = fontFamilyName)
        fixed (char* localeNamePtr = localeName)
        {
            char* locale = stackalloc char[1];
            locale[0] = '\0';
            if (localeNamePtr != null)
            {
                locale = localeNamePtr;
            }

            nint fontCollectionPtr = fontCollection is null ? 0 : fontCollection.Handle;
            nint ptr;
            int hr = _comImpl->CreateTextFormat(_comPtr, fontFamilyNamePtr, fontCollectionPtr, fontWeight, fontStyle, fontStretch, fontSize, locale, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new DWriteTextFormat(ptr);
        }
    }

    /// <summary>
    /// Create a typography object used in conjunction with text format for text layout.
    /// </summary>
    /// <returns><see cref="DWriteTypography"/></returns>
    public DWriteTypography CreateTypography()
    {
        nint ptr;
        int hr = _comImpl->CreateTypography(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteTypography(ptr);
    }

    /// <summary>
    /// CreateTextLayout takes a string, format, and associated constraints
    /// and produces an object representing the fully analyzed
    /// and formatted result.
    /// </summary>
    /// <param name="text">The string to layout.</param>
    /// <param name="textFormat">The format to apply to the string.</param>
    /// <param name="maxWidth">Width of the layout box.</param>
    /// <param name="maxHeight">Height of the layout box.</param>
    /// <returns><see cref="DWriteTextLayout"/></returns>
    public DWriteTextLayout CreateTextLayout(string? text, DWriteTextFormat? textFormat, float maxWidth, float maxHeight)
    {
        return CreateTextLayout(text.AsSpan(), textFormat, maxWidth, maxHeight);
    }

    /// <summary>
    /// CreateTextLayout takes a string, format, and associated constraints
    /// and produces an object representing the fully analyzed
    /// and formatted result.
    /// </summary>
    /// <param name="text">The string to layout.</param>
    /// <param name="textFormat">The format to apply to the string.</param>
    /// <param name="maxWidth">Width of the layout box.</param>
    /// <param name="maxHeight">Height of the layout box.</param>
    /// <returns><see cref="DWriteTextLayout"/></returns>
    public DWriteTextLayout CreateTextLayout(ReadOnlySpan<char> text, DWriteTextFormat? textFormat, float maxWidth, float maxHeight)
    {
        if (text.Length == 0)
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (textFormat is null)
        {
            throw new ArgumentNullException(nameof(textFormat));
        }

        fixed (char* textPtr = text)
        {
            nint textFormatPtr = textFormat is null ? 0 : textFormat.Handle;
            nint ptr;
            int hr = _comImpl->CreateTextLayout(_comPtr, textPtr, (uint)text.Length, textFormatPtr, maxWidth, maxHeight, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new DWriteTextLayout(ptr);
        }
    }
}
