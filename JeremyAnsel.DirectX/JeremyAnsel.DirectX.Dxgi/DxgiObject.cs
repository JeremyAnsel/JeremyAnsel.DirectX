// <copyright file="DxgiObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;


    /// <summary>
    /// An <c>IDXGIObject</c> interface is a base interface for all DXGI objects. <c>IDXGIObject</c> supports associating caller-defined (private data) with an object and retrieval of an interface to the parent object.
    /// </summary>
    [SuppressMessage("Design", "CA1063:Implémenter IDisposable correctement", Justification = "Reviewed.")]
    public abstract class DxgiObject : IDisposable, IDxgiReleasable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiObject"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiObject()
        {
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public abstract object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DXGI object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DxgiObject value)
        {
            return value != null && value.Handle != null;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.Handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the <see cref="DxgiObject"/> object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM DXGI interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Sets an application-defined data to the object and associates that data with a GUID.
        /// </summary>
        /// <param name="name">A GUID that identifies the data.</param>
        /// <param name="text">The object's text.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPrivateDataText(Guid name, string text)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(text))
            {
                text = "<unnamed>";
            }

            if (text.Length > 255)
            {
                text = text.Substring(0, 255);
            }

            byte[] textBytes = Encoding.ASCII.GetBytes(text);
            this.GetHandle<IDxgiObject>().SetPrivateData(ref name, (uint)textBytes.Length, textBytes);
        }

        /// <summary>
        /// Gets an application-defined data from the object that is associated with a GUID.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <returns>The object's text.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetPrivateDataText(Guid name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            uint dataSize = 256;
            byte[] data = new byte[dataSize];

            this.GetHandle<IDxgiObject>().GetPrivateData(ref name, ref dataSize, data);

            var text = Encoding.ASCII.GetString(data);
            return text.Substring(0, text.IndexOf('\0'));
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        /// <typeparam name="T">A DXGI interface type.</typeparam>
        /// <returns>The DXGI interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T GetHandle<T>()
        {
            return (T)this.Handle;
        }
    }
}
