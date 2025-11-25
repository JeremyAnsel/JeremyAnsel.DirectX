// <copyright file="DWriteUtils.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class DWriteUtils
    {
        /// <summary>
        /// Immediately releases the unmanaged resources.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="o">The object.</param>
        public static void DisposeAndNull<T>(ref T? o) where T : class, IDWriteReleasable
        {
            if (o != null)
            {
                o.Dispose();
                o = null;
            }
        }

        /// <summary>
        /// Immediately releases the unmanaged resources.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="array">The objects.</param>
        public static void DisposeAndNull<T>(T?[]? array) where T : class, IDWriteReleasable
        {
            if (array is null)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                DisposeAndNull(ref array[i]);
            }
        }

        /// <summary>
        /// Releases the managed reference to the COM interface.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="o">The COM interface.</param>
        public static void ReleaseAndNull<T>(ref T? o) where T : class, IDWriteReleasable
        {
            if (o != null)
            {
                o.Release();
                o = null;
            }
        }

        /// <summary>
        /// Releases the managed reference to the COM interface.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="array">The COM interfaces.</param>
        public static void ReleaseAndNull<T>(T?[]? array) where T : class, IDWriteReleasable
        {
            if (array is null)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                ReleaseAndNull(ref array[i]);
            }
        }
    }
}
