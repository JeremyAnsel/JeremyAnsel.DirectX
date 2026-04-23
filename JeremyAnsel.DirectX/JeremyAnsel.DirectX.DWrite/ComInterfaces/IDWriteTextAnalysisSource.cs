// <copyright file="IDWriteTextAnalysisSource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The interface implemented by the text analyzer's client to provide text to
/// the analyzer. It allows the separation between the logical view of text as
/// a continuous stream of characters identifiable by unique text positions,
/// and the actual memory layout of potentially discrete blocks of text in the
/// client's backing store.
/// If any of these callbacks returns an error, the analysis functions will
/// stop prematurely and return a callback error. Rather than return E_NOTIMPL,
/// an application should stub the method and return a constant/null and S_OK.
/// </summary>
[Guid("688e1a58-5094-47c8-adc8-fbcea60ae92b")]
internal unsafe readonly struct IDWriteTextAnalysisSource
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Get a block of text starting at the specified text position.
    /// Returning NULL indicates the end of text - the position is after
    /// the last character. This function is called iteratively for
    /// each consecutive block, tying together several fragmented blocks
    /// in the backing store into a virtual contiguous string.
    /// </summary>
    /// <param name="textPosition">First position of the piece to obtain. All
    /// positions are in UTF16 code-units, not whole characters, which
    /// matters when supplementary characters are used.</param>
    /// <param name="textString">Address that receives a pointer to the text block
    /// at the specified position.</param>
    /// <param name="textLength">Number of UTF16 units of the retrieved chunk.
    /// The returned length is not the length of the block, but the length
    /// remaining in the block, from the given position until its end.
    /// So querying for a position that is 75 positions into a 100
    /// position block would return 25.</param>
    /// <remarks>
    /// Although apps can implement sparse textual content that only maps part of
    /// the backing store, the app must map any text that is in the range passed
    /// to any analysis functions.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, uint*, int> GetTextAtPosition;

    /// <summary>
    /// Get a block of text immediately preceding the specified position.
    /// </summary>
    /// <param name="textPosition">Position immediately after the last position of the chunk to obtain.</param>
    /// <param name="textString">Address that receives a pointer to the text block
    /// at the specified position.</param>
    /// <param name="textLength">Number of UTF16 units of the retrieved block.
    /// The length returned is from the given position to the front of
    /// the block.</param>
    /// <remarks>
    /// Although apps can implement sparse textual content that only maps part of
    /// the backing store, the app must map any text that is in the range passed
    /// to any analysis functions.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, uint*, int> GetTextBeforePosition;

    /// <summary>
    /// Get paragraph reading direction.
    /// </summary>
    /// <returns><see cref="DWriteReadingDirection"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteReadingDirection> GetParagraphReadingDirection;

    /// <summary>
    /// Get locale name on the range affected by it.
    /// </summary>
    /// <param name="textPosition">Position to get the locale name of.</param>
    /// <param name="textLength">Receives the length from the given position up to the
    /// next differing locale.</param>
    /// <param name="localeName">Address that receives a pointer to the locale
    /// at the specified position.</param>
    /// <remarks>
    /// The localeName pointer must remain valid until the next call or until
    /// the analysis returns.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, nint*, int> GetLocaleName;

    /// <summary>
    /// Get number substitution on the range affected by it.
    /// </summary>
    /// <param name="textPosition">Position to get the number substitution of.</param>
    /// <param name="textLength">Receives the length from the given position up to the
    /// next differing number substitution.</param>
    /// <param name="numberSubstitution">Address that receives a pointer to the number substitution
    /// at the specified position.</param>
    /// <remarks>
    /// Any implementation should return the number substitution with an
    /// incremented ref count, and the analysis will release when finished
    /// with it (either before the next call or before it returns). However,
    /// the sink callback may hold onto it after that.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, nint*, int> GetNumberSubstitution;
}
