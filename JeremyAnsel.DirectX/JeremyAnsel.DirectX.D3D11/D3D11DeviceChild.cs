// <copyright file="D3D11DeviceChild.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;


    /// <summary>
    /// A device-child interface accesses data used by a device.
    /// </summary>
    [SuppressMessage("Design", "CA1063:Implémenter IDisposable correctement", Justification = "Reviewed.")]
    public abstract class D3D11DeviceChild : IDisposable, ID3D11Releasable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11DeviceChild"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11DeviceChild()
        {
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public abstract object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D3D11 device child.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D3D11DeviceChild value)
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
        /// Immediately releases the unmanaged resources used by the <see cref="D3D11DeviceChild"/> object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM D3D11 interface.
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
            this.GetHandle<ID3D11DeviceChild>().SetPrivateData(ref name, (uint)textBytes.Length, textBytes);
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

            this.GetHandle<ID3D11DeviceChild>().GetPrivateData(ref name, ref dataSize, data);

            var text = Encoding.ASCII.GetString(data);
            return text.Substring(0, text.IndexOf('\0'));
        }

        /// <summary>
        /// Sets a unique name to objects in order to assist the developer during debugging.
        /// </summary>
        /// <param name="name">The friendly name.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDebugName(string name)
        {
            this.SetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName, name);
        }

        /// <summary>
        /// Gets a unique name to objects in order to assist the developer during debugging.
        /// </summary>
        /// <returns>The friendly name.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetDebugName()
        {
            return this.GetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName);
        }

        /// <summary>
        /// Get the device that created this interface.
        /// </summary>
        /// <returns>A device.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Device GetDevice()
        {
            ID3D11Device device;
            this.GetHandle<ID3D11DeviceChild>().GetDevice(out device);
            return new D3D11Device(device);
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        /// <typeparam name="T">A D3D11 interface type.</typeparam>
        /// <returns>The D3D11 interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T GetHandle<T>()
        {
            return (T)this.Handle;
        }
    }
}
