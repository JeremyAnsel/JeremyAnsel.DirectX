// <copyright file="DxgiUtils.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class DxgiUtils
    {
        /// <summary>
        /// Immediately releases the unmanaged resources.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="o">The object.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Reviewed")]
        public static void DisposeAndNull<T>(ref T? o) where T : class, IDxgiReleasable
        {
            if (o != null)
            {
                o.Dispose();
                o = null;
            }
        }

        /// <summary>
        /// Releases the managed reference to the COM interface.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="o">The COM interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Reviewed")]
        public static void ReleaseAndNull<T>(ref T? o) where T : class, IDxgiReleasable
        {
            if (o != null)
            {
                o.Release();
                o = null;
            }
        }
    }
}
