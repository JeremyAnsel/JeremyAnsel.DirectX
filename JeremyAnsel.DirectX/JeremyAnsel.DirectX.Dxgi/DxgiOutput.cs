// <copyright file="DxgiOutput.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// An <c>IDXGIOutput</c> interface represents an adapter output (such as a monitor).
    /// </summary>
    public sealed class DxgiOutput : DxgiObject
    {
        /// <summary>
        /// The DXGI output interface.
        /// </summary>
        private IDxgiOutput output;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiOutput"/> class.
        /// </summary>
        /// <param name="output">A DXGI output interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiOutput(IDxgiOutput output)
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
        /// Gets the display modes that match the requested format and other input options.
        /// </summary>
        /// <param name="format">The color format.</param>
        /// <param name="modes">Options for modes to include.</param>
        /// <returns>An array of <see cref="DxgiModeDesc"/> structure.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiModeDesc[] GetDisplayModeList(DxgiFormat format, DxgiEnumModes modes)
        {
            uint numModes = 0;
            this.output.GetDisplayModeList(format, modes, ref numModes, null);

            DxgiModeDesc[] displayModes = new DxgiModeDesc[numModes];

            this.output.GetDisplayModeList(format, modes, ref numModes, displayModes);

            return displayModes;
        }

        /// <summary>
        /// Finds the display mode that most closely matches the requested display mode.
        /// </summary>
        /// <param name="modeToMatch">The desired display mode.</param>
        /// <param name="concernedDevice">The Direct3D device interface. If this parameter is <value>null</value>, only modes whose format matches that of <c>modeToMatch</c> will be returned; otherwise, only those formats that are supported for scan-out by the device are returned.</param>
        /// <returns>The mode that most closely matches <c>modeToMatch</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiModeDesc FindClosestMatchingMode(DxgiModeDesc modeToMatch, object concernedDevice)
        {
            DxgiModeDesc closestMatch;
            this.output.FindClosestMatchingMode(ref modeToMatch, out closestMatch, concernedDevice);
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
        /// Gets a copy of the current display surface.
        /// </summary>
        /// <param name="destination">A destination surface.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetDisplaySurfaceData(DxgiSurface destination)
        {
            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            this.output.GetDisplaySurfaceData(destination.GetHandle<IDxgiSurface>());
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
