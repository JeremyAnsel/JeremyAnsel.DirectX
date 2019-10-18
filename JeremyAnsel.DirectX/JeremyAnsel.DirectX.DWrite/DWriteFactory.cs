// <copyright file="DWriteFactory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// The root factory interface for all DWrite objects.
    /// </summary>
    public sealed class DWriteFactory : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite factory interface.
        /// </summary>
        private IDWriteFactory handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFactory"/> class.
        /// </summary>
        /// <param name="handle">A DWrite factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteFactory(IDWriteFactory handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets an handle representing the DWrite object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle; }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteFactory value)
        {
            return value != null && value.handle != null;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DWriteFactory Create(DWriteFactoryType factoryType)
        {
            IDWriteFactory factory;
            NativeMethods.DWriteCreateFactory(factoryType, typeof(IDWriteFactory).GUID, out factory);
            return new DWriteFactory(factory);
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the DWrite object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM DWrite interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.handle);
        }

        /// <summary>
        /// Gets a font collection representing the set of installed fonts.
        /// </summary>
        /// <returns><see cref="DWriteFontCollection"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontCollection GetSystemFontCollection()
        {
            IDWriteFontCollection fontCollection;
            this.handle.GetSystemFontCollection(out fontCollection, false);
            return new DWriteFontCollection(fontCollection);
        }

        /// <summary>
        /// Gets a font collection representing the set of installed fonts.
        /// </summary>
        /// <param name="checkForUpdates">If this parameter is nonzero, the function performs an immediate check for changes to the set of
        /// installed fonts. If this parameter is FALSE, the function will still detect changes if the font cache service is running, but
        /// there may be some latency. For example, an application might specify TRUE if it has itself just installed a font and wants to 
        /// be sure the font collection contains that font.</param>
        /// <returns><see cref="DWriteFontCollection"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontCollection GetSystemFontCollection(bool checkForUpdates)
        {
            IDWriteFontCollection fontCollection;
            this.handle.GetSystemFontCollection(out fontCollection, checkForUpdates);
            return new DWriteFontCollection(fontCollection);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFile CreateFontFileReference(string filePath, ulong lastWriteTime)
        {
            IDWriteFontFile fontFile;
            this.handle.CreateFontFileReference(filePath, ref lastWriteTime, out fontFile);
            return new DWriteFontFile(fontFile);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFace CreateFontFace(DWriteFontFaceType fontFaceType, DWriteFontFile[] fontFiles, uint faceIndex, DWriteFontSimulations fontFaceSimulation)
        {
            if (fontFiles == null)
            {
                throw new ArgumentNullException(nameof(fontFiles));
            }

            IDWriteFontFace fontFace;
            this.handle.CreateFontFace(fontFaceType, (uint)fontFiles.Length, Array.ConvertAll(fontFiles, t => (IDWriteFontFile)t.Handle), faceIndex, fontFaceSimulation, out fontFace);
            return new DWriteFontFace(fontFace);
        }

        /// <summary>
        /// Creates a rendering parameters object with default settings for the primary monitor.
        /// </summary>
        /// <returns><see cref="DWriteRenderingParams"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteRenderingParams CreateRenderingParams()
        {
            IDWriteRenderingParams renderingParams;
            this.handle.CreateRenderingParams(out renderingParams);
            return new DWriteRenderingParams(renderingParams);
        }

        /// <summary>
        /// Creates a rendering parameters object with default settings for the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to read the default values from.</param>
        /// <returns><see cref="DWriteRenderingParams"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteRenderingParams CreateMonitorRenderingParams(IntPtr monitor)
        {
            IDWriteRenderingParams renderingParams;
            this.handle.CreateMonitorRenderingParams(monitor, out renderingParams);
            return new DWriteRenderingParams(renderingParams);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWritePixelGeometry pixelGeometry, DWriteRenderingMode renderingMode)
        {
            IDWriteRenderingParams renderingParams;
            this.handle.CreateCustomRenderingParams(gamma, enhancedContrast, clearTypeLevel, pixelGeometry, renderingMode, out renderingParams);
            return new DWriteRenderingParams(renderingParams);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteTextFormat CreateTextFormat(
            string fontFamilyName,
            DWriteFontCollection fontCollection,
            DWriteFontWeight fontWeight,
            DWriteFontStyle fontStyle,
            DWriteFontStretch fontStretch,
            float fontSize,
            string localeName)
        {
            IDWriteTextFormat textFormat;
            this.handle.CreateTextFormat(
                fontFamilyName,
                fontCollection == null ? null : (IDWriteFontCollection)fontCollection.Handle,
                fontWeight,
                fontStyle,
                fontStretch,
                fontSize,
                localeName,
                out textFormat);
            return new DWriteTextFormat(textFormat);
        }

        /// <summary>
        /// Create a typography object used in conjunction with text format for text layout.
        /// </summary>
        /// <returns><see cref="DWriteTypography"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteTypography CreateTypography()
        {
            IDWriteTypography typography;
            this.handle.CreateTypography(out typography);
            return new DWriteTypography(typography);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteTextLayout CreateTextLayout(string text, DWriteTextFormat textFormat, float maxWidth, float maxHeight)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (textFormat == null)
            {
                throw new ArgumentNullException(nameof(textFormat));
            }

            IDWriteTextLayout textLayout;
            this.handle.CreateTextLayout(text, (uint)text.Length, (IDWriteTextFormat)textFormat.Handle, maxWidth, maxHeight, out textLayout);
            return new DWriteTextLayout(textLayout);
        }
    }
}
