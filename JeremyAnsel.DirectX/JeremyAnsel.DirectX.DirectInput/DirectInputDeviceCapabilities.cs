// <copyright file="DirectInputDeviceCapabilities.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public sealed class DirectInputDeviceCapabilities
{
    internal DirectInputDeviceCapabilities(in DIDEVCAPS caps)
    {
        DirectInputDeviceCapabilitiesOptions flags = DirectInputDeviceCapabilitiesOptions.None;

        if (caps.Flags.HasFlag(DIDC.ATTACHED))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.Attached;
        }

        if (caps.Flags.HasFlag(DIDC.POLLEDDEVICE))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.PolledDevice;
        }

        if (caps.Flags.HasFlag(DIDC.EMULATED))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.Emulated;
        }

        if (caps.Flags.HasFlag(DIDC.POLLEDDATAFORMAT))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.PolledDataFormat;
        }

        if (caps.Flags.HasFlag(DIDC.FORCEFEEDBACK))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.ForceFeedback;
        }

        if (caps.Flags.HasFlag(DIDC.FFATTACK))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.FFAttack;
        }

        if (caps.Flags.HasFlag(DIDC.FFFADE))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.FFFade;
        }

        if (caps.Flags.HasFlag(DIDC.SATURATION))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.Saturation;
        }

        if (caps.Flags.HasFlag(DIDC.POSNEGCOEFFICIENTS))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.PosNegCoefficients;
        }

        if (caps.Flags.HasFlag(DIDC.POSNEGSATURATION))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.PosNegSaturation;
        }

        if (caps.Flags.HasFlag(DIDC.DEADBAND))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.DeadBand;
        }

        if (caps.Flags.HasFlag(DIDC.STARTDELAY))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.StartDelay;
        }

        if (caps.Flags.HasFlag(DIDC.ALIAS))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.Alias;
        }

        if (caps.Flags.HasFlag(DIDC.PHANTOM))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.Phantom;
        }

        if (caps.Flags.HasFlag(DIDC.HIDDEN))
        {
            flags |= DirectInputDeviceCapabilitiesOptions.Hidden;
        }

        Flags = flags;

        AxesCount = caps.Axes;
        ButtonsCount = caps.Buttons;
        POVsCount = caps.POVs;
        FFSamplePeriod = caps.FFSamplePeriod;
        FFMinTimeResolution = caps.FFMinTimeResolution;
        FirmwareRevision = caps.FirmwareRevision;
        HardwareRevision = caps.HardwareRevision;
        FFDriverVersion = caps.FFDriverVersion;
    }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputDeviceCapabilitiesOptions Flags { get; }

    /// <summary>
    /// 
    /// </summary>
    public int AxesCount { get; }

    /// <summary>
    /// 
    /// </summary>
    public int ButtonsCount { get; }

    /// <summary>
    /// 
    /// </summary>
    public int POVsCount { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FFSamplePeriod { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FFMinTimeResolution { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FirmwareRevision { get; }

    /// <summary>
    /// 
    /// </summary>
    public int HardwareRevision { get; }

    /// <summary>
    /// 
    /// </summary>
    public int FFDriverVersion { get; }
}
