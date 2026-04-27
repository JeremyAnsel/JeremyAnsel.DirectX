// <copyright file="DWriteTextLayout.cs" company="Jérémy Ansel">
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
/// The IDWriteTextLayout interface represents a block of text after it has
/// been fully analyzed and formatted.
/// All coordinates are in device independent pixels (DIPs).
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteTextLayout : DWriteTextFormat
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteTextLayoutGuid = typeof(IDWriteTextLayout).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteTextLayout* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteTextLayout"/> class.
    /// </summary>
    public DWriteTextLayout(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteTextLayout**)comPtr;
    }

    /// <summary>
    /// Gets or sets the layout maximum width
    /// </summary>
    public float MaxWidth
    {
        get { return _comImpl->GetMaxWidth(_comPtr); }
        set { _comImpl->SetMaxWidth(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the layout maximum height
    /// </summary>
    public float MaxHeight
    {
        get { return _comImpl->GetMaxHeight(_comPtr); }
        set { _comImpl->SetMaxHeight(_comPtr, value); }
    }

    /// <summary>
    /// Set the font collection.
    /// </summary>
    /// <param name="fontCollection">The font collection to set</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontCollection(DWriteFontCollection? fontCollection, DWriteTextRange textRange)
    {
        if (fontCollection is null)
        {
            throw new ArgumentNullException(nameof(fontCollection));
        }

        int hr = _comImpl->SetFontCollection(_comPtr, fontCollection.Handle, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set null-terminated font family name.
    /// </summary>
    /// <param name="fontFamilyName">Font family name</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontFamilyName(string fontFamilyName, DWriteTextRange textRange)
    {
        SetFontFamilyName(fontFamilyName.AsSpan(), textRange);
    }

    /// <summary>
    /// Set null-terminated font family name.
    /// </summary>
    /// <param name="fontFamilyName">Font family name</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontFamilyName(ReadOnlySpan<char> fontFamilyName, DWriteTextRange textRange)
    {
        fixed (char* ptr = fontFamilyName)
        {
            int hr = _comImpl->SetFontFamilyName(_comPtr, ptr, textRange);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Set font weight.
    /// </summary>
    /// <param name="fontWeight">Font weight</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontWeight(DWriteFontWeight fontWeight, DWriteTextRange textRange)
    {
        int hr = _comImpl->SetFontWeight(_comPtr, fontWeight, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set font style.
    /// </summary>
    /// <param name="fontStyle">Font style</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontStyle(DWriteFontStyle fontStyle, DWriteTextRange textRange)
    {
        int hr = _comImpl->SetFontStyle(_comPtr, fontStyle, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set font stretch.
    /// </summary>
    /// <param name="fontStretch">font stretch</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontStretch(DWriteFontStretch fontStretch, DWriteTextRange textRange)
    {
        int hr = _comImpl->SetFontStretch(_comPtr, fontStretch, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set font em height.
    /// </summary>
    /// <param name="fontSize">Font em height</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetFontSize(float fontSize, DWriteTextRange textRange)
    {
        int hr = _comImpl->SetFontSize(_comPtr, fontSize, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set underline.
    /// </summary>
    /// <param name="hasUnderline">The Boolean flag indicates whether underline takes place</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetUnderline(bool hasUnderline, DWriteTextRange textRange)
    {
        int hr = _comImpl->SetUnderline(_comPtr, hasUnderline ? 1 : 0, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set strikethrough.
    /// </summary>
    /// <param name="hasStrikethrough">The Boolean flag indicates whether strikethrough takes place</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetStrikethrough(bool hasStrikethrough, DWriteTextRange textRange)
    {
        int hr = _comImpl->SetStrikethrough(_comPtr, hasStrikethrough ? 1 : 0, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set font typography features.
    /// </summary>
    /// <param name="typography">Pointer to font typography setting.</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetTypography(DWriteTypography? typography, DWriteTextRange textRange)
    {
        if (typography is null)
        {
            throw new ArgumentNullException(nameof(typography));
        }

        int hr = _comImpl->SetTypography(_comPtr, typography.Handle, textRange);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Set locale name.
    /// </summary>
    /// <param name="localeName">Locale name</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetLocaleName(string localeName, DWriteTextRange textRange)
    {
        SetLocaleName(localeName.AsSpan(), textRange);
    }

    /// <summary>
    /// Set locale name.
    /// </summary>
    /// <param name="localeName">Locale name</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public void SetLocaleName(ReadOnlySpan<char> localeName, DWriteTextRange textRange)
    {
        fixed (char* ptr = localeName)
        {
            int hr = _comImpl->SetLocaleName(_comPtr, ptr, textRange);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Get the font collection where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    /// <returns><see cref="DWriteFontCollection"/></returns>
    public DWriteFontCollection GetFontCollection(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        nint ptr;
        int hr = _comImpl->GetFontCollection(_comPtr, currentPosition, &ptr, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return new DWriteFontCollection(ptr);
    }

    /// <summary>
    /// Get the length of the font family name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns></returns>
    public uint GetFontFamilyNameLength(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        uint length;
        int hr = _comImpl->GetFontFamilyNameLength(_comPtr, currentPosition, &length, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return length;
    }

    /// <summary>
    /// Copy the font family name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="string"/></returns>
    public string GetFontFamilyName(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        uint length = GetFontFamilyNameLength(currentPosition, out _) + 1;
        char* ptr = stackalloc char[(int)length];
        int hr = _comImpl->GetFontFamilyName(_comPtr, currentPosition, ptr, length, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return new string(ptr, 0, (int)length - 1);
    }

    /// <summary>
    /// Copy the font family name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <param name="name">The name.</param>
    public void GetFontFamilyName(uint currentPosition, out DWriteTextRange textRange, Span<char> name)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];

        fixed (char* ptr = name)
        {
            int hr = _comImpl->GetFontFamilyName(_comPtr, currentPosition, ptr, (uint)name.Length, rangePtr);
            Marshal.ThrowExceptionForHR(hr);
            textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        }
    }

    /// <summary>
    /// Get the font weight where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="DWriteFontWeight"/></returns>
    public DWriteFontWeight GetFontWeight(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        DWriteFontWeight weight;
        int hr = _comImpl->GetFontWeight(_comPtr, currentPosition, &weight, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return weight;
    }

    /// <summary>
    /// Get the font style where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="DWriteFontStyle"/></returns>
    public DWriteFontStyle GetFontStyle(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        DWriteFontStyle style;
        int hr = _comImpl->GetFontStyle(_comPtr, currentPosition, &style, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return style;
    }

    /// <summary>
    /// Get the font stretch where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="DWriteFontStretch"/></returns>
    public DWriteFontStretch GetFontStretch(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        DWriteFontStretch stretch;
        int hr = _comImpl->GetFontStretch(_comPtr, currentPosition, &stretch, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return stretch;
    }

    /// <summary>
    /// Get the font em height where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="float"/></returns>
    public float GetFontSize(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        float fontSize;
        int hr = _comImpl->GetFontSize(_comPtr, currentPosition, &fontSize, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return fontSize;
    }

    /// <summary>
    /// Get the underline presence where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="bool"/></returns>
    public bool GetUnderline(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        int underline;
        int hr = _comImpl->GetUnderline(_comPtr, currentPosition, &underline, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return underline != 0;
    }

    /// <summary>
    /// Get the strikethrough presence where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="bool"/></returns>
    public bool GetStrikethrough(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        int strikethrough;
        int hr = _comImpl->GetStrikethrough(_comPtr, currentPosition, &strikethrough, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return strikethrough != 0;
    }

    /// <summary>
    /// Get the typography setting where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="DWriteTypography"/></returns>
    public DWriteTypography GetTypography(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        nint ptr;
        int hr = _comImpl->GetTypography(_comPtr, currentPosition, &ptr, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return new DWriteTypography(ptr);
    }

    /// <summary>
    /// Get the length of the locale name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="nameLength">Size of the character array in character count not including the terminated NULL character.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public uint GetLocaleNameLength(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        uint length;
        int hr = _comImpl->GetLocaleNameLength(_comPtr, currentPosition, &length, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return length;
    }

    /// <summary>
    /// Get the locale name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <returns><see cref="string"/></returns>
    public string GetLocaleName(uint currentPosition, out DWriteTextRange textRange)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];
        uint length = GetLocaleNameLength(currentPosition, out _) + 1;
        char* ptr = stackalloc char[(int)length];
        int hr = _comImpl->GetLocaleName(_comPtr, currentPosition, ptr, length, rangePtr);
        Marshal.ThrowExceptionForHR(hr);
        textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        return new string(ptr, 0, (int)length - 1);
    }

    /// <summary>
    /// Get the locale name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="textRange">The position range of the current format.</param>
    /// <param name="name">The name.</param>
    public void GetLocaleName(uint currentPosition, out DWriteTextRange textRange, Span<char> name)
    {
        int size = DWriteTextRange.NativeRequiredSize();
        byte* rangePtr = stackalloc byte[size];

        fixed (char* ptr = name)
        {
            int hr = _comImpl->GetLocaleName(_comPtr, currentPosition, ptr, (uint)name.Length, rangePtr);
            Marshal.ThrowExceptionForHR(hr);
            textRange = DWriteTextRange.NativeReadFrom((nint)rangePtr);
        }
    }

    /// <summary>
    /// GetMetrics retrieves overall metrics for the formatted string.
    /// </summary>
    /// <remarks>
    /// Drawing effects like underline and strikethrough do not contribute
    /// to the text size, which is essentially the sum of advance widths and
    /// line heights. Additionally, visible swashes and other graphic
    /// adornments may extend outside the returned width and height.
    /// </remarks>
    /// <returns><see cref="DWriteTextMetrics"/></returns>
    public DWriteTextMetrics GetMetrics()
    {
        int size = DWriteTextMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetMetrics(_comPtr, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return DWriteTextMetrics.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// GetOverhangMetrics returns the overhangs (in DIPs) of the layout and all
    /// objects contained in it, including text glyphs and inline objects.
    /// </summary>
    /// <remarks>
    /// Any underline and strikethrough do not contribute to the black box
    /// determination, since these are actually drawn by the renderer, which
    /// is allowed to draw them in any variety of styles.
    /// </remarks>
    /// <returns><see cref="DWriteOverhangMetrics"/></returns>
    public DWriteOverhangMetrics GetOverhangMetrics()
    {
        int size = DWriteOverhangMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetOverhangMetrics(_comPtr, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return DWriteOverhangMetrics.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Determines the minimum possible width the layout can be set to without
    /// emergency breaking between the characters of whole words.
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public float DetermineMinWidth()
    {
        float width;
        int hr = _comImpl->DetermineMinWidth(_comPtr, &width);
        Marshal.ThrowExceptionForHR(hr);
        return width;
    }

    /// <summary>
    /// Given a coordinate (in DIPs) relative to the top-left of the layout box,
    /// this returns the corresponding hit-test metrics of the text string where
    /// the hit-test has occurred. This is useful for mapping mouse clicks to caret
    /// positions. When the given coordinate is outside the text string, the function
    /// sets the output value isInside to false but returns the nearest character
    /// position.
    /// </summary>
    /// <param name="pointX">X coordinate to hit-test, relative to the top-left location of the layout box.</param>
    /// <param name="pointY">Y coordinate to hit-test, relative to the top-left location of the layout box.</param>
    /// <param name="isTrailingHit">Output flag indicating whether the hit-test location is at the leading or the trailing
    /// side of the character. When the output isInside value is set to false, this value is set according to the output
    /// position value to represent the edge closest to the hit-test location. </param>
    /// <param name="isInside">Output flag indicating whether the hit-test location is inside the text string.
    /// When false, the position nearest the text's edge is returned.</param>
    /// <returns><see cref="DWriteHitTestMetrics"/></returns>
    public DWriteHitTestMetrics HitTestPoint(float pointX, float pointY, out bool isTrailingHit, out bool isInside)
    {
        int size = DWriteHitTestMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hit;
        int inside;
        int hr = _comImpl->HitTestPoint(_comPtr, pointX, pointY, &hit, &inside, ptr);
        Marshal.ThrowExceptionForHR(hr);
        isTrailingHit = hit != 0;
        isInside = inside != 0;
        return DWriteHitTestMetrics.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Given a text position and whether the caret is on the leading or trailing
    /// edge of that position, this returns the corresponding coordinate (in DIPs)
    /// relative to the top-left of the layout box. This is most useful for drawing
    /// the caret's current position, but it could also be used to anchor an IME to the
    /// typed text or attach a floating menu near the point of interest. It may also be
    /// used to programmatically obtain the geometry of a particular text position
    /// for UI automation.
    /// </summary>
    /// <param name="textPosition">Text position to get the coordinate of.</param>
    /// <param name="isTrailingHit">Flag indicating whether the location is of the leading or the trailing side of the specified text position. </param>
    /// <param name="pointX">Output caret X, relative to the top-left of the layout box.</param>
    /// <param name="pointY">Output caret Y, relative to the top-left of the layout box.</param>
    /// <remarks>
    /// When drawing a caret at the returned X,Y, it should be centered on X
    /// and drawn from the Y coordinate down. The height will be the size of the
    /// hit-tested text (which can vary in size within a line).
    /// Reading direction also affects which side of the character the caret is drawn.
    /// However, the returned X coordinate will be correct for either case.
    /// You can get a text length back that is larger than a single character.
    /// This happens for complex scripts when multiple characters form a single cluster,
    /// when diacritics join their base character, or when you test a surrogate pair.
    /// </remarks>
    /// <returns><see cref="DWriteHitTestMetrics"/></returns>
    public DWriteHitTestMetrics HitTestTextPosition(uint textPosition, bool isTrailingHit, out float pointX, out float pointY)
    {
        int size = DWriteHitTestMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        float x;
        float y;
        int hr = _comImpl->HitTestTextPosition(_comPtr, textPosition, isTrailingHit ? 1 : 0, &x, &y, ptr);
        Marshal.ThrowExceptionForHR(hr);
        pointX = x;
        pointY = y;
        return DWriteHitTestMetrics.NativeReadFrom((nint)ptr);
    }
}
