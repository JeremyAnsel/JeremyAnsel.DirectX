// <copyright file="DWriteTextFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The format of text used for text layout.
/// </summary>
/// <remarks>
/// This object may not be thread-safe and it may carry the state of text format change.
/// </remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteTextFormat : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteTextFormatGuid = typeof(IDWriteTextFormat).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteTextFormat* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteTextFormat"/> class.
    /// </summary>
    public DWriteTextFormat(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteTextFormat**)comPtr;
    }

    /// <summary>
    /// Gets or sets the alignment option of text relative to layout box's leading and trailing edge.
    /// </summary>
    public DWriteTextAlignment TextAlignment
    {
        get { return _comImpl->GetTextAlignment(_comPtr); }
        set { _comImpl->SetTextAlignment(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the alignment option of paragraph relative to layout box's top and bottom edge.
    /// </summary>
    public DWriteParagraphAlignment ParagraphAlignment
    {
        get { return _comImpl->GetParagraphAlignement(_comPtr); }
        set { _comImpl->SetParagraphAlignment(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the word wrapping option.
    /// </summary>
    public DWriteWordWrapping WordWrapping
    {
        get { return _comImpl->GetWordWrapping(_comPtr); }
        set { _comImpl->SetWordWrapping(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the paragraph reading direction.
    /// </summary>
    /// <remarks>
    /// The flow direction must be perpendicular to the reading direction.
    /// Setting both to a vertical direction or both to horizontal yields
    /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
    /// </remarks>
    public DWriteReadingDirection ReadingDirection
    {
        get { return _comImpl->GetReadingDirection(_comPtr); }
        set { _comImpl->SetReadingDirection(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets paragraph flow direction.
    /// </summary>
    /// <remarks>
    /// The flow direction must be perpendicular to the reading direction.
    /// Setting both to a vertical direction or both to horizontal yields
    /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
    /// </remarks>
    public DWriteFlowDirection FlowDirection
    {
        get { return _comImpl->GetFlowDirection(_comPtr); }
        set { _comImpl->SetFlowDirection(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the incremental tab stop position.
    /// </summary>
    public float IncrementalTabStop
    {
        get { return _comImpl->GetIncrementalTabStop(_comPtr); }
        set { _comImpl->SetIncrementalTabStop(_comPtr, value); }
    }

    /// <summary>
    /// Gets the font weight.
    /// </summary>
    public DWriteFontWeight FontWeight
    {
        get { return _comImpl->GetFontWeight(_comPtr); }
    }

    /// <summary>
    /// Gets the font style.
    /// </summary>
    public DWriteFontStyle FontStyle
    {
        get { return _comImpl->GetFontStyle(_comPtr); }
    }

    /// <summary>
    /// Gets the font stretch.
    /// </summary>
    public DWriteFontStretch FontStretch
    {
        get { return _comImpl->GetFontStretch(_comPtr); }
    }

    /// <summary>
    /// Gets the font em height.
    /// </summary>
    public float FontSize
    {
        get { return _comImpl->GetFontSize(_comPtr); }
    }

    /// <summary>
    /// Set trimming options for any trailing text exceeding the layout width
    /// or for any far text exceeding the layout height.
    /// </summary>
    /// <param name="trimmingOptions">Text trimming options.</param>
    public void SetTrimming(in DWriteTrimming trimmingOptions)
    {
        int size = DWriteTrimming.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        DWriteTrimming.NativeWriteTo((nint)ptr, trimmingOptions);
        int hr = _comImpl->SetTrimming(_comPtr, ptr, 0);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set line spacing.
    /// </summary>
    /// <param name="lineSpacingMethod">How to determine line height.</param>
    /// <param name="lineSpacing">The line height, or rather distance between one baseline to another.</param>
    /// <param name="baseline">Distance from top of line to baseline. A reasonable ratio to lineSpacing is 80%.</param>
    /// <remarks>
    /// For the default method, spacing depends solely on the content.
    /// For uniform spacing, the given line height will override the content.
    /// </remarks>
    public void SetLineSpacing(DWriteLineSpacingMethod lineSpacingMethod, float lineSpacing, float baseline)
    {
        int hr = _comImpl->SetLineSpacing(_comPtr, lineSpacingMethod, lineSpacing, baseline);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get trimming options for text overflowing the layout width.
    /// </summary>
    /// <returns><see cref="DWriteTrimming"/></returns>
    public DWriteTrimming GetTrimming()
    {
        int size = DWriteTrimming.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetTrimming(_comPtr, ptr, null);
        Marshal.ThrowExceptionForHR(hr);
        return DWriteTrimming.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Get line spacing.
    /// </summary>
    /// <param name="lineSpacingMethod">How line height is determined.</param>
    /// <param name="lineSpacing">The line height, or rather distance between one baseline to another.</param>
    /// <param name="baseline">Distance from top of line to baseline.</param>
    public void GetLineSpacing(out DWriteLineSpacingMethod lineSpacingMethod, out float lineSpacing, out float baseline)
    {
        DWriteLineSpacingMethod method;
        float spacing;
        float line;
        int hr = _comImpl->GetLineSpacing(_comPtr, &method, &spacing, &line);
        Marshal.ThrowExceptionForHR(hr);
        lineSpacingMethod = method;
        lineSpacing = spacing;
        baseline = line;
    }

    /// <summary>
    /// Get the font collection.
    /// </summary>
    /// <returns><see cref="DWriteFontCollection"/></returns>
    public DWriteFontCollection GetFontCollection()
    {
        nint ptr;
        int hr = _comImpl->GetFontCollection(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontCollection(ptr);
    }

    /// <summary>
    /// Get the length of the font family name, in characters, not including the terminating NULL character.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetFontFamilyNameLength()
    {
        return _comImpl->GetFontFamilyNameLength(_comPtr);
    }

    /// <summary>
    /// Get a copy of the font family name.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    public string GetFontFamilyName()
    {
        uint length = GetFontFamilyNameLength() + 1;
        char* ptr = stackalloc char[(int)length];
        int hr = _comImpl->GetFontFamilyName(_comPtr, ptr, length);
        Marshal.ThrowExceptionForHR(hr);
        return new string(ptr, 0, (int)length - 1);
    }

    /// <summary>
    /// Get a copy of the font family name.
    /// </summary>
    /// <param name="name">The name.</param>
    public void GetFontFamilyName(Span<char> name)
    {
        fixed (char* ptr = name)
        {
            int hr = _comImpl->GetFontFamilyName(_comPtr, ptr, (uint)name.Length);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Get the length of the locale name, in characters, not including the terminating NULL character.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetLocaleNameLength()
    {
        return _comImpl->GetLocaleNameLength(_comPtr);
    }

    /// <summary>
    /// Get a copy of the locale name.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    public string GetLocaleName()
    {
        uint length = GetLocaleNameLength() + 1;
        char* ptr = stackalloc char[(int)length];
        int hr = _comImpl->GetLocaleName(_comPtr, ptr, length);
        Marshal.ThrowExceptionForHR(hr);
        return new string(ptr, 0, (int)length - 1);
    }

    /// <summary>
    /// Get a copy of the locale name.
    /// </summary>
    /// <param name="str">The string.</param>
    public void GetLocaleName(Span<char> str)
    {
        fixed (char* ptr = str)
        {
            int hr = _comImpl->GetLocaleName(_comPtr, ptr, (uint)str.Length);
            Marshal.ThrowExceptionForHR(hr);
        }
    }
}
