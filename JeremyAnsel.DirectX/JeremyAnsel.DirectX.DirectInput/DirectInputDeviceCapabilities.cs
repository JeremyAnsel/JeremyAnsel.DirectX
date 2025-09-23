namespace JeremyAnsel.DirectX.DirectInput;

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

    public DirectInputDeviceCapabilitiesOptions Flags { get; }

    public int AxesCount { get; }

    public int ButtonsCount { get; }

    public int POVsCount { get; }

    public int FFSamplePeriod { get; }

    public int FFMinTimeResolution { get; }

    public int FirmwareRevision { get; }

    public int HardwareRevision { get; }

    public int FFDriverVersion { get; }
}
