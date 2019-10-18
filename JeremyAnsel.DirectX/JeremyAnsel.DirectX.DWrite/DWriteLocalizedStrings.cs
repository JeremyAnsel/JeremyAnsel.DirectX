// <copyright file="DWriteLocalizedStrings.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// Represents a collection of strings indexed by locale name.
    /// </summary>
    public sealed class DWriteLocalizedStrings : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite localized strings interface.
        /// </summary>
        private IDWriteLocalizedStrings handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteLocalizedStrings"/> class.
        /// </summary>
        /// <param name="handle">A DWrite font collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteLocalizedStrings(IDWriteLocalizedStrings handle)
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
        public static implicit operator bool(DWriteLocalizedStrings value)
        {
            return value != null && value.handle != null;
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
        /// Gets the number of language/string pairs.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetCount()
        {
            return this.handle.GetCount();
        }

        /// <summary>
        /// Gets the index of the item with the specified locale name.
        /// </summary>
        /// <param name="localeName">Locale name to look for.</param>
        /// <param name="index">Receives the zero-based index of the locale name/string pair.</param>
        /// <returns>TRUE if the locale name exists or FALSE if not.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FindLocaleName(string localeName, out uint index)
        {
            bool exists;
            this.handle.FindLocaleName(localeName, out index, out exists);
            return exists;
        }

        /// <summary>
        /// Copies the locale name with the specified index to the specified array.
        /// </summary>
        /// <param name="index">Zero-based index of the locale name.</param>
        /// <returns><see cref="string"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetLocaleName(uint index)
        {
            uint length;
            this.handle.GetLocaleNameLength(index, out length);
            length++;

            StringBuilder localeName = new StringBuilder((int)length);
            this.handle.GetLocaleName(index, localeName, length);

            return localeName.ToString();
        }

        /// <summary>
        /// Copies the string with the specified index to the specified array.
        /// </summary>
        /// <param name="index">Zero-based index of the string.</param>
        /// <returns><see cref="string"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString(uint index)
        {
            uint length;
            this.handle.GetStringLength(index, out length);
            length++;

            StringBuilder name = new StringBuilder((int)length);
            this.handle.GetString(index, name, length);

            return name.ToString();
        }
    }
}
