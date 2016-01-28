// <copyright file="DxgiOutput3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// Represents an adapter output (such as a monitor). The <c>IDXGIOutput2</c> interface exposes a method to check for multi-plane overlay support on the primary output adapter.
    /// </summary>
    public sealed class DxgiOutput3 : DxgiObject
    {
        /// <summary>
        /// The DXGI output interface.
        /// </summary>
        private IDxgiOutput2 output;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiOutput3"/> class.
        /// </summary>
        /// <param name="output">A DXGI output interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiOutput3(IDxgiOutput2 output)
        {
            this.output = output;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.output; }
        }

        /// <summary>
        /// Gets a description of the output.
        /// </summary>
        public DxgiOutputDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.output.GetDesc();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the output adapter supports multi-plane overlay.
        /// </summary>
        public bool SupportsOverlays
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.output.SupportsOverlays();
            }
        }

        /// <summary>
        /// Gets the display modes that match the requested format and other input options.
        /// </summary>
        /// <param name="format">The color format.</param>
        /// <param name="modes">Options for modes to include.</param>
        /// <returns>An array of <see cref="DxgiModeDesc"/> structure.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiModeDesc1[] GetDisplayModeList(DxgiFormat format, DxgiEnumModes modes)
        {
            uint numModes = 0;
            this.output.GetDisplayModeList1(format, modes, ref numModes, null);

            DxgiModeDesc1[] displayModes = new DxgiModeDesc1[numModes];

            this.output.GetDisplayModeList1(format, modes, ref numModes, displayModes);

            return displayModes;
        }

        /// <summary>
        /// Finds the display mode that most closely matches the requested display mode.
        /// </summary>
        /// <param name="modeToMatch">The desired display mode.</param>
        /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
        /// <returns>The mode that most closely matches <c>modeToMatch</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiModeDesc1 FindClosestMatchingMode(DxgiModeDesc1 modeToMatch, object concernedDevice)
        {
            DxgiModeDesc1 closestMatch;
            this.output.FindClosestMatchingMode1(ref modeToMatch, out closestMatch, concernedDevice);
            return closestMatch;
        }

        /// <summary>
        /// Halt a thread until the next vertical blank occurs.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitForVBlank()
        {
            this.output.WaitForVBlank();
        }

        /// <summary>
        /// Copies the display surface (front buffer) to a user-provided resource.
        /// </summary>
        /// <param name="destination">A resource interface that represents the resource to which copies the display surface.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetDisplaySurfaceData(DxgiResource3 destination)
        {
            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            this.output.GetDisplaySurfaceData1(destination.GetHandle<IDxgiResource>());
        }

        /// <summary>
        /// Gets statistics about recently rendered frames.
        /// </summary>
        /// <returns>The frame statistics.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiFrameStatistics GetFrameStatistics()
        {
            return this.output.GetFrameStatistics();
        }
    }
}
