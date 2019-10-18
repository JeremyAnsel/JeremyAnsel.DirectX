// <copyright file="DxgiError.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// DXGI error codes.
    /// </summary>
    public static class DxgiError
    {
        /// <summary>
        /// The application made a call that is invalid. Either the parameters of the call or the state of some object was incorrect.
        /// </summary>
        public const int InvalidCall = unchecked((int)0x887A0001L);

        /// <summary>
        /// The object was not found.
        /// </summary>
        public const int NotFound = unchecked((int)0x887A0002L);

        /// <summary>
        /// The caller did not supply a sufficiently large buffer.
        /// </summary>
        public const int MoreData = unchecked((int)0x887A0003L);

        /// <summary>
        /// The specified device interface or feature level is not supported on this system.
        /// </summary>
        public const int Unsupported = unchecked((int)0x887A0004L);

        /// <summary>
        /// The GPU device instance has been suspended. Use GetDeviceRemovedReason to determine the appropriate action.
        /// </summary>
        public const int DeviceRemoved = unchecked((int)0x887A0005L);

        /// <summary>
        /// The GPU will not respond to more commands, most likely because of an invalid command passed by the calling application.
        /// </summary>
        public const int DeviceHung = unchecked((int)0x887A0006L);

        /// <summary>
        /// The GPU will not respond to more commands, most likely because some other application submitted invalid commands.
        /// The calling application should re-create the device and continue.
        /// </summary>
        public const int DeviceReset = unchecked((int)0x887A0007L);

        /// <summary>
        /// The GPU was busy at the moment when the call was made, and the call was neither executed nor scheduled.
        /// </summary>
        public const int WasStillDrawing = unchecked((int)0x887A000AL);

        /// <summary>
        /// An event (such as power cycle) interrupted the gathering of presentation statistics.
        /// Any previous statistics should be considered invalid.
        /// </summary>
        public const int FrameStatisticsDisjoint = unchecked((int)0x887A000BL);

        /// <summary>
        /// Full screen mode could not be achieved because the specified output was already in use.
        /// </summary>
        public const int GraphicsVidpnSourceInUse = unchecked((int)0x887A000CL);

        /// <summary>
        /// An internal issue prevented the driver from carrying out the specified operation.
        /// The driver's state is probably suspect, and the application should not continue.
        /// </summary>
        public const int DriverInternalError = unchecked((int)0x887A0020L);

        /// <summary>
        /// A global counter resource was in use, and the specified counter cannot be used by this Direct3D device at this time.
        /// </summary>
        public const int NonExclusive = unchecked((int)0x887A0021L);

        /// <summary>
        /// A resource is not available at the time of the call, but may become available later.
        /// </summary>
        public const int NotCurrentlyAvailable = unchecked((int)0x887A0022L);

        /// <summary>
        /// The application's remote device has been removed due to session disconnect or network disconnect.
        /// The application should call IDXGIFactory1::IsCurrent to find out when the remote device becomes available again.
        /// </summary>
        public const int RemoteClientDisconnected = unchecked((int)0x887A0023L);

        /// <summary>
        /// The device has been removed during a remote session because the remote computer ran out of memory.
        /// </summary>
        public const int RemoteOutOfMemory = unchecked((int)0x887A0024L);

        /// <summary>
        /// The keyed mutex was abandoned.
        /// </summary>
        public const int AccessLost = unchecked((int)0x887A0026L);

        /// <summary>
        /// The timeout value has elapsed and the resource is not yet available.
        /// </summary>
        public const int WaitTimeout = unchecked((int)0x887A0027L);

        /// <summary>
        /// The output duplication has been turned off because the Windows session ended or was disconnected.
        /// This happens when a remote user disconnects, or when "switch user" is used locally.
        /// </summary>
        public const int SessionDisconnected = unchecked((int)0x887A0028L);

        /// <summary>
        /// The DXGI output (monitor) to which the swap chain content was restricted, has been disconnected or changed.
        /// </summary>
        public const int RestrictToOutputStale = unchecked((int)0x887A0029L);

        /// <summary>
        /// DXGI is unable to provide content protection on the swap chain.
        /// This is typically caused by an older driver, or by the application using a swap chain that is incompatible with content protection.
        /// </summary>
        public const int CannotProtectContent = unchecked((int)0x887A002AL);

        /// <summary>
        /// The application is trying to use a resource to which it does not have the required access privileges.
        /// This is most commonly caused by writing to a shared resource with read-only access.
        /// </summary>
        public const int AccessDenied = unchecked((int)0x887A002BL);

        /// <summary>
        /// The application is trying to create a shared handle using a name that is already associated with some other resource.
        /// </summary>
        public const int NameAlreadyExists = unchecked((int)0x887A002CL);

        /// <summary>
        /// The application requested an operation that depends on an SDK component that is missing or mismatched.
        /// </summary>
        public const int SdkComponentMissing = unchecked((int)0x887A002DL);
    }
}
