// <copyright file="DWriteFontFeatureTag.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Typographic feature of text supplied by the font.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "Reviewed")]
    public enum DWriteFontFeatureTag
    {
        /// <summary>
        /// Replaces figures separated by a slash with an alternative form.
        /// </summary>
        /// <value>afrc</value>
        AlternativeFractions = 0x63726661, // 'afrc'

        /// <summary>
        /// Turns capital characters into petite capitals. It is generally used for words which would otherwise be set in all caps, such as acronyms, but which are desired in petite-cap form to avoid disrupting the flow of text. See the pcap feature description for notes on the relationship of caps, smallcaps and petite caps.
        /// </summary>
        /// <value>c2pc</value>
        PetiteCapitalsFromCapitals = 0x63703263, // 'c2pc'

        /// <summary>
        /// Turns capital characters into small capitals. It is generally used for words which would otherwise be set in all caps, such as acronyms, but which are desired in small-cap form to avoid disrupting the flow of text.
        /// </summary>
        /// <value>c2sc</value>
        SmallCapitalsFromCapitals = 0x63733263, // 'c2sc'

        /// <summary>
        /// In specified situations, replaces default glyphs with alternate forms which provide better joining behavior. Used in script typefaces which are designed to have some or all of their glyphs join.
        /// </summary>
        /// <value>calt</value>
        ContextualAlternates = 0x746c6163, // 'calt'

        /// <summary>
        /// Shifts various punctuation marks up to a position that works better with all-capital sequences or sets of lining figures; also changes oldstyle figures to lining figures. By default, glyphs in a text face are designed to work with lowercase characters. Some characters should be shifted vertically to fit the higher visual center of all-capital or lining text. Also, lining figures are the same height (or close to it) as capitals, and fit much better with all-capital text.
        /// </summary>
        /// <value>case</value>
        CaseSensitiveForms = 0x65736163, // 'case'

        /// <summary>
        /// To minimize the number of glyph alternates, it is sometimes desired to decompose a character into two glyphs. Additionally, it may be preferable to compose two characters into a single glyph for better glyph processing. This feature permits such composition/decomposition. The feature should be processed as the first feature processed, and should be processed only when it is called.
        /// </summary>
        /// <value>ccmp</value>
        GlyphCompositionDecomposition = 0x706d6363, // 'ccmp'

        /// <summary>
        /// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. Unlike other ligature features, clig specifies the context in which the ligature is recommended. This capability is important in some script designs and for swash ligatures.
        /// </summary>
        /// <value>clig</value>
        ContextualLigatures = 0x67696c63, // 'clig'

        /// <summary>
        /// Globally adjusts inter-glyph spacing for all-capital text. Most typefaces contain capitals and lowercase characters, and the capitals are positioned to work with the lowercase. When capitals are used for words, they need more space between them for legibility and esthetics. This feature would not apply to monospaced designs. Of course the user may want to override this behavior in order to do more pronounced letter spacing for esthetic reasons.
        /// </summary>
        /// <value>cpsp</value>
        CapitalSpacing = 0x70737063, // 'cpsp'

        /// <summary>
        /// Replaces default character glyphs with corresponding swash glyphs in a specified context. Note that there may be more than one swash alternate for a given character.
        /// </summary>
        /// <value>cswh</value>
        ContextualSwash = 0x68777363, // 'cswh'

        /// <summary>
        /// In cursive scripts like Arabic, this feature cursively positions adjacent glyphs.
        /// </summary>
        /// <value>curs</value>
        CursivePositioning = 0x73727563, // 'curs'

        /// <summary>
        /// The default.
        /// </summary>
        /// <value>dflt</value>
        Default = 0x746c6664, // 'dflt'

        /// <summary>
        /// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. This feature covers those ligatures which may be used for special effect, at the user's preference.
        /// </summary>
        /// <value>dlig</value>
        DiscretionaryLigatures = 0x67696c64, // 'dlig'

        /// <summary>
        /// Replaces standard forms in Japanese fonts with corresponding forms preferred by typographers. For example, a user would invoke this feature to replace kanji character U+5516 with U+555E.
        /// </summary>
        /// <value>expt</value>
        ExpertForms = 0x74707865, // 'expt'

        /// <summary>
        /// Replaces figures separated by a slash with 'common' (diagonal) fractions.
        /// </summary>
        /// <value>frac</value>
        Fractions = 0x63617266, // 'frac'

        /// <summary>
        /// Replaces glyphs set on other widths with glyphs set on full (usually em) widths. In a CJKV font, this may include "lower ASCII" Latin characters and various symbols. In a European font, this feature replaces proportionally-spaced glyphs with monospaced glyphs, which are generally set on widths of 0.6 em. For example, a user may invoke this feature in a Japanese font to get full monospaced Latin glyphs instead of the corresponding proportionally-spaced versions.
        /// </summary>
        /// <value>fwid</value>
        FullWidth = 0x64697766, // 'fwid'

        /// <summary>
        /// Produces the half forms of consonants in Indic scripts. For example, in Hindi (Devanagari script), the conjunct KKa, obtained by doubling the Ka, is denoted with a half form of Ka followed by the full form.
        /// </summary>
        /// <value>half</value>
        HalfForms = 0x666c6168, // 'half'

        /// <summary>
        /// Produces the halant forms of consonants in Indic scripts. For example, in Sanskrit (Devanagari script), syllable final consonants are frequently required in their halant form.
        /// </summary>
        /// <value>haln</value>
        HalantForms = 0x6e6c6168, // 'haln'

        /// <summary>
        /// Respaces glyphs designed to be set on full-em widths, fitting them onto half-em widths. This differs from hwid in that it does not substitute new glyphs.
        /// </summary>
        /// <value>halt</value>
        AlternateHalfWidth = 0x746c6168, // 'halt'

        /// <summary>
        /// Replaces the default (current) forms with the historical alternates. While some ligatures are also used for historical effect, this feature deals only with single characters. Some fonts include the historical forms as alternates, so they can be used for a 'period' effect.
        /// </summary>
        /// <value>hist</value>
        HistoricalForms = 0x74736968, // 'hist'

        /// <summary>
        /// Replaces standard kana with forms that have been specially designed for only horizontal writing. This is a typographic optimization for improved fit and more even color.
        /// </summary>
        /// <value>hkna</value>
        HorizontalKanaAlternates = 0x616e6b68, // 'hkna'

        /// <summary>
        /// Replaces the default (current) forms with the historical alternates. Some ligatures were in common use in the past, but appear anachronistic today. Some fonts include the historical forms as alternates, so they can be used for a 'period' effect.
        /// </summary>
        /// <value>hlig</value>
        HistoricalLigatures = 0x67696c68, // 'hlig'

        /// <summary>
        /// Replaces glyphs on proportional widths, or fixed widths other than half an em, with glyphs on half-em (en) widths. Many CJKV fonts have glyphs which are set on multiple widths; this feature selects the half-em version. There are various contexts in which this is the preferred behavior, including compatibility with older desktop documents.
        /// </summary>
        /// <value>hwid</value>
        HalfWidth = 0x64697768, // 'hwid'

        /// <summary>
        /// Used to access the JIS X 0212-1990 glyphs for the cases when the JIS X 0213:2004 form is encoded. The JIS X 0212-1990 (aka, "Hojo Kanji") and JIS X 0213:2004 character sets overlap significantly. In some cases their prototypical glyphs differ. When building fonts that support both JIS X 0212-1990 and JIS X 0213:2004 (such as those supporting the Adobe-Japan 1-6 character collection), it is recommended that JIS X 0213:2004 forms be the preferred encoded form.
        /// </summary>
        /// <value>hojo</value>
        HojoKanjiForms = 0x6f6a6f68, // 'hojo'

        /// <summary>
        /// The National Language Council (NLC) of Japan has defined new glyph shapes for a number of JIS characters, which were incorporated into JIS X 0213:2004 as new prototypical forms. The 'jp04' feature is A subset of the 'nlck' feature, and is used to access these prototypical glyphs in a manner that maintains the integrity of JIS X 0213:2004.
        /// </summary>
        /// <value>jp04</value>
        Jis04Forms = 0x3430706a, // 'jp04'

        /// <summary>
        /// Replaces default (JIS90) Japanese glyphs with the corresponding forms from the JIS C 6226-1978 (JIS78) specification.
        /// </summary>
        /// <value>jp78</value>
        Jis78Forms = 0x3837706a, // 'jp78'

        /// <summary>
        /// Replaces default (JIS90) Japanese glyphs with the corresponding forms from the JIS X 0208-1983 (JIS83) specification.
        /// </summary>
        /// <value>jp83</value>
        Jis83Forms = 0x3338706a, // 'jp83'

        /// <summary>
        /// Replaces Japanese glyphs from the JIS78 or JIS83 specifications with the corresponding forms from the JIS X 0208-1990 (JIS90) specification.
        /// </summary>
        /// <value>jp90</value>
        Jis90Forms = 0x3039706a, // 'jp90'

        /// <summary>
        /// Adjusts amount of space between glyphs, generally to provide optically consistent spacing between glyphs. Although a well-designed typeface has consistent inter-glyph spacing overall, some glyph combinations require adjustment for improved legibility. Besides standard adjustment in the horizontal direction, this feature can supply size-dependent kerning data via device tables, "cross-stream" kerning in the Y text direction, and adjustment of glyph placement independent of the advance adjustment. Note that this feature may apply to runs of more than two glyphs, and would not be used in monospaced fonts. Also note that this feature does not apply to text set vertically.
        /// </summary>
        /// <value>kern</value>
        Kerning = 0x6e72656b, // 'kern'

        /// <summary>
        /// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. This feature covers the ligatures which the designer/manufacturer judges should be used in normal conditions.
        /// </summary>
        /// <value>liga</value>
        StandardLigatures = 0x6167696c, // 'liga'

        /// <summary>
        /// Changes selected figures from oldstyle to the default lining form. For example, a user may invoke this feature in order to get lining figures, which fit better with all-capital text. This feature overrides results of the Oldstyle Figures feature (onum).
        /// </summary>
        /// <value>lnum</value>
        LiningFigures = 0x6d756e6c, // 'lnum'

        /// <summary>
        /// Enables localized forms of glyphs to be substituted for default forms. Many scripts used to write multiple languages over wide geographical areas have developed localized variant forms of specific letters, which are used by individual literary communities. For example, a number of letters in the Bulgarian and Serbian alphabets have forms distinct from their Russian counterparts and from each other. In some cases the localized form differs only subtly from the script 'norm', in others the forms are radically distinct.
        /// </summary>
        /// <value>locl</value>
        LocalizedForms = 0x6c636f6c, // 'locl'

        /// <summary>
        /// Positions mark glyphs with respect to base glyphs. For example, in Arabic script positioning the Hamza above the Yeh.
        /// </summary>
        /// <value>mark</value>
        MarkPositioning = 0x6b72616d, // 'mark'

        /// <summary>
        /// Replaces standard typographic forms of Greek glyphs with corresponding forms commonly used in mathematical notation (which are a subset of the Greek alphabet).
        /// </summary>
        /// <value>mgrk</value>
        MathematicalGreek = 0x6b72676d, // 'mgrk'

        /// <summary>
        /// Positions marks with respect to other marks. Required in various non-Latin scripts like Arabic. For example, in Arabic, the ligaturised mark Ha with Hamza above it can also be obtained by positioning these marks relative to one another.
        /// </summary>
        /// <value>mkmk</value>
        MarkToMarkPositioning = 0x6b6d6b6d, // 'mkmk'

        /// <summary>
        /// Replaces default glyphs with various notational forms (such as glyphs placed in open or solid circles, squares, parentheses, diamonds or rounded boxes). In some cases an annotation form may already be present, but the user may want a different one.
        /// </summary>
        /// <value>nalt</value>
        AlternateAnnotationForms = 0x746c616e, // 'nalt'

        /// <summary>
        /// Used to access glyphs made from glyph shapes defined by the National Language Council (NLC) of Japan for a number of JIS characters in 2000.
        /// </summary>
        /// <value>nlck</value>
        NlcKanjiForms = 0x6b636c6e, // 'nlck'

        /// <summary>
        /// Changes selected figures from the default lining style to oldstyle form. For example, a user may invoke this feature to get oldstyle figures, which fit better into the flow of normal upper- and lowercase text. This feature overrides results of the Lining Figures feature (lnum).
        /// </summary>
        /// <value>onum</value>
        OldStyleFigures = 0x6d756e6f, // 'onum'

        /// <summary>
        /// Replaces default alphabetic glyphs with the corresponding ordinal forms for use after figures. One exception to the follows-a-figure rule is the numero character (U+2116), which is actually a ligature substitution, but is best accessed through this feature.
        /// </summary>
        /// <value>ordn</value>
        Ordinals = 0x6e64726f, // 'ordn'

        /// <summary>
        /// Respaces glyphs designed to be set on full-em widths, fitting them onto individual (more or less proportional) horizontal widths. This differs from pwid in that it does not substitute new glyphs (GPOS, not GSUB feature). The user may prefer the monospaced form, or may simply want to ensure that the glyph is well-fit and not rotated in vertical setting (Latin forms designed for proportional spacing would be rotated).
        /// </summary>
        /// <value>palt</value>
        ProportionalAlternateWidth = 0x746c6170, // 'palt'

        /// <summary>
        /// Turns lowercase characters into petite capitals. Forms related to petite capitals, such as specially designed figures, may be included. Some fonts contain an additional size of capital letters, shorter than the regular smallcaps and it is referred to as petite caps. Such forms are most likely to be found in designs with a small lowercase x-height, where they better harmonise with lowercase text than the taller smallcaps.
        /// </summary>
        /// <value>pcap</value>
        PetiteCapitals = 0x70616370, // 'pcap'

        /// <summary>
        /// Replaces figure glyphs set on uniform (tabular) widths with corresponding glyphs set on glyph-specific (proportional) widths. Tabular widths will generally be the default, but this cannot be safely assumed. Of course this feature would not be present in monospaced designs.
        /// </summary>
        /// <value>pnum</value>
        ProportionalFigures = 0x6d756e70, // 'pnum'

        /// <summary>
        /// Replaces glyphs set on uniform widths (typically full or half-em) with proportionally spaced glyphs. The proportional variants are often used for the Latin characters in CJKV fonts, but may also be used for Kana in Japanese fonts.
        /// </summary>
        /// <value>pwid</value>
        ProportionalWidths = 0x64697770, // 'pwid'

        /// <summary>
        /// Replaces glyphs on other widths with glyphs set on widths of one quarter of an em (half an en). The characters involved are normally figures and some forms of punctuation.
        /// </summary>
        /// <value>qwid</value>
        QuarterWidths = 0x64697771, // 'qwid'

        /// <summary>
        /// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. This feature covers those ligatures, which the script determines as required to be used in normal conditions. This feature is important for some scripts to ensure correct glyph formation.
        /// </summary>
        /// <value>rlig</value>
        RequiredLigatures = 0x67696c72, // 'rlig'

        /// <summary>
        /// Identifies glyphs in the font which have been designed for "ruby", from the old typesetting term for four-point-sized type. Japanese typesetting often uses smaller kana glyphs, generally in superscripted form, to clarify the meaning of kanji which may be unfamiliar to the reader.
        /// </summary>
        /// <value>ruby</value>
        RubyNotationForms = 0x79627572, // 'ruby'

        /// <summary>
        /// Replaces the default forms with the stylistic alternates. Many fonts contain alternate glyph designs for a purely esthetic effect; these don't always fit into a clear category like swash or historical. As in the case of swash glyphs, there may be more than one alternate form.
        /// </summary>
        /// <value>salt</value>
        StylisticAlternates = 0x746c6173, // 'salt'

        /// <summary>
        /// Replaces lining or oldstyle figures with inferior figures (smaller glyphs which sit lower than the standard baseline, primarily for chemical or mathematical notation). May also replace lowercase characters with alphabetic inferiors.
        /// </summary>
        /// <value>sinf</value>
        ScientificInferiors = 0x666e6973, // 'sinf'

        /// <summary>
        /// Turns lowercase characters into small capitals. This corresponds to the common SC font layout. It is generally used for display lines set in Large &amp; small caps, such as titles. Forms related to small capitals, such as oldstyle figures, may be included.
        /// </summary>
        /// <value>smcp</value>
        SmallCapitals = 0x70636d73, // 'smcp'

        /// <summary>
        /// Replaces 'traditional' Chinese or Japanese forms with the corresponding 'simplified' forms.
        /// </summary>
        /// <value>smpl</value>
        SimplifiedForms = 0x6c706d73, // 'smpl'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss01</value>
        StylisticSet1 = 0x31307373, // 'ss01'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss02</value>
        StylisticSet2 = 0x32307373, // 'ss02'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss03</value>
        StylisticSet3 = 0x33307373, // 'ss03'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss04</value>
        StylisticSet4 = 0x34307373, // 'ss04'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss05</value>
        StylisticSet5 = 0x35307373, // 'ss05'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss06</value>
        StylisticSet6 = 0x36307373, // 'ss06'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss07</value>
        StylisticSet7 = 0x37307373, // 'ss07'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss08</value>
        StylisticSet8 = 0x38307373, // 'ss08'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss09</value>
        StylisticSet9 = 0x39307373, // 'ss09'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss10</value>
        StylisticSet10 = 0x30317373, // 'ss10'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss11</value>
        StylisticSet11 = 0x31317373, // 'ss11'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss12</value>
        StylisticSet12 = 0x32317373, // 'ss12'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss13</value>
        StylisticSet13 = 0x33317373, // 'ss13'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss14</value>
        StylisticSet14 = 0x34317373, // 'ss14'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss15</value>
        StylisticSet15 = 0x35317373, // 'ss15'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss16</value>
        StylisticSet16 = 0x36317373, // 'ss16'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss17</value>
        StylisticSet17 = 0x37317373, // 'ss17'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss17</value>
        StylisticSet18 = 0x38317373, // 'ss18'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss19</value>
        StylisticSet19 = 0x39317373, // 'ss19'

        /// <summary>
        /// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise work together. Individual features numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available stylistic sets.
        /// </summary>
        /// <value>ss20</value>
        StylisticSet20 = 0x30327373, // 'ss20'

        /// <summary>
        /// May replace a default glyph with a subscript glyph, or it may combine a glyph substitution with positioning adjustments for proper placement.
        /// </summary>
        /// <value>subs</value>
        Subscript = 0x73627573, // 'subs'

        /// <summary>
        /// Replaces lining or oldstyle figures with superior figures (primarily for footnote indication), and replaces lowercase letters with superior letters (primarily for abbreviated French titles).
        /// </summary>
        /// <value>sups</value>
        Superscript = 0x73707573, // 'sups'

        /// <summary>
        /// Replaces default character glyphs with corresponding swash glyphs. Note that there may be more than one swash alternate for a given character.
        /// </summary>
        /// <value>swsh</value>
        Swash = 0x68737773, // 'swsh'

        /// <summary>
        /// Replaces the default glyphs with corresponding forms designed specifically for titling. These may be all-capital and/or larger on the body, and adjusted for viewing at larger sizes.
        /// </summary>
        /// <value>titl</value>
        Titling = 0x6c746974, // 'titl'

        /// <summary>
        /// Replaces 'simplified' Japanese kanji forms with the corresponding 'traditional' forms. This is equivalent to the Traditional Forms feature, but explicitly limited to the traditional forms considered proper for use in personal names (as many as 205 glyphs in some fonts).
        /// </summary>
        /// <value>tnam</value>
        TraditionalNameForms = 0x6d616e74, // 'tnam'

        /// <summary>
        /// Replaces figure glyphs set on proportional widths with corresponding glyphs set on uniform (tabular) widths. Tabular widths will generally be the default, but this cannot be safely assumed. Of course this feature would not be present in monospaced designs.
        /// </summary>
        /// <value>tnum</value>
        TabularFigures = 0x6d756e74, // 'tnum'

        /// <summary>
        /// Replaces 'simplified' Chinese hanzi or Japanese kanji forms with the corresponding 'traditional' forms.
        /// </summary>
        /// <value>trad</value>
        TraditionalForms = 0x64617274, // 'trad'

        /// <summary>
        /// Replaces glyphs on other widths with glyphs set on widths of one third of an em. The characters involved are normally figures and some forms of punctuation.
        /// </summary>
        /// <value>twid</value>
        ThirdWidths = 0x64697774, // 'twid'

        /// <summary>
        /// Maps upper- and lowercase letters to a mixed set of lowercase and small capital forms, resulting in a single case alphabet (for an example of unicase, see the Emigre type family Filosofia). The letters substituted may vary from font to font, as appropriate to the design. If aligning to the x-height, smallcap glyphs may be substituted, or specially designed unicase forms might be used. Substitutions might also include specially designed figures.
        /// </summary>
        /// <value>unic</value>
        Unicase = 0x63696e75, // 'unic'

        /// <summary>
        /// Indicates that the font is displayed vertically.
        /// </summary>
        /// <value>vert</value>
        VerticalWriting = 0x74726576, // 'vert'

        /// <summary>
        /// Replaces normal figures with figures adjusted for vertical display.
        /// </summary>
        /// <value>vrt2</value>
        VerticalAlternatesAndRotation = 0x32747276, // 'vrt2'

        /// <summary>
        /// Allows the user to change from the default 0 to a slashed form. Some fonts contain both a default form of zero, and an alternative form which uses a diagonal slash through the counter. Especially in condensed designs, it can be difficult to distinguish between 0 and O (zero and capital O) in any situation where capitals and lining figures may be arbitrarily mixed.
        /// </summary>
        /// <value>zero</value>
        SlashedZero = 0x6f72657a, // 'zero'
    }
}
