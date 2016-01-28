// <copyright file="D3D10Utils.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class D3D10Utils
    {
        /// <summary>
        /// Immediately releases the unmanaged resources.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="obj">The object.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Reviewed")]
        public static void DisposeAndNull<T>(ref T obj) where T : class, ID3D10Releasable
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }

        /// <summary>
        /// Releases the managed reference to the COM interface.
        /// </summary>
        /// <typeparam name="T">A releasable type.</typeparam>
        /// <param name="obj">The COM interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#", Justification = "Reviewed")]
        public static void ReleaseAndNull<T>(ref T obj) where T : class, ID3D10Releasable
        {
            if (obj != null)
            {
                obj.Release();
                obj = null;
            }
        }
    }
}
