// <copyright file="D2D1Error.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// D2D1 error codes.
    /// </summary>
    public static class D2D1Error
    {
        /// <summary>
        /// The object was not in the correct state to process the method.
        /// </summary>
        public const int WrongState = unchecked((int)0x88990001L);

        /// <summary>
        /// The object has not yet been initialized.
        /// </summary>
        public const int NotInitialized = unchecked((int)0x88990002L);

        /// <summary>
        /// The requested operation is not supported.
        /// </summary>
        public const int UnsupportedOperation = unchecked((int)0x88990003L);

        /// <summary>
        /// The geometry scanner failed to process the data.
        /// </summary>
        public const int ScannerFailed = unchecked((int)0x88990004L);

        /// <summary>
        /// Direct2D could not access the screen.
        /// </summary>
        public const int ScreenAccessDenied = unchecked((int)0x88990005L);

        /// <summary>
        /// A valid display state could not be determined.
        /// </summary>
        public const int DisplayStateInvalid = unchecked((int)0x88990006L);

        /// <summary>
        /// The supplied vector is zero.
        /// </summary>
        public const int ZeroVector = unchecked((int)0x88990007L);

        /// <summary>
        /// An internal error (Direct2D bug) occurred. On checked builds, we would assert. The application should close this instance of Direct2D and should consider restarting its process.
        /// </summary>
        public const int InternalError = unchecked((int)0x88990008L);

        /// <summary>
        /// The display format Direct2D needs to render is not supported by the hardware device.
        /// </summary>
        public const int DisplayFormatNotSupported = unchecked((int)0x88990009L);

        /// <summary>
        /// A call to this method is invalid.
        /// </summary>
        public const int InvalidCall = unchecked((int)0x8899000AL);

        /// <summary>
        /// No hardware rendering device is available for this operation.
        /// </summary>
        public const int NoHardwareDevice = unchecked((int)0x8899000BL);

        /// <summary>
        /// There has been a presentation error that may be recoverable. The caller needs to recreate, rerender the entire frame, and reattempt present.
        /// </summary>
        public const int RecreateTarget = unchecked((int)0x8899000CL);

        /// <summary>
        /// Shader construction failed because it was too complex.
        /// </summary>
        public const int TooManyShaderElements = unchecked((int)0x8899000DL);

        /// <summary>
        /// Shader compilation failed.
        /// </summary>
        public const int ShaderCompileFailed = unchecked((int)0x8899000EL);

        /// <summary>
        /// Requested DirectX surface size exceeded maximum texture size.
        /// </summary>
        public const int MaxTextureSizeExceeded = unchecked((int)0x8899000FL);

        /// <summary>
        /// The requested Direct2D version is not supported.
        /// </summary>
        public const int UnsupportedVersion = unchecked((int)0x88990010L);

        /// <summary>
        /// Invalid number.
        /// </summary>
        public const int BadNumber = unchecked((int)0x88990011L);

        /// <summary>
        /// Objects used together must be created from the same factory instance.
        /// </summary>
        public const int WrongFactory = unchecked((int)0x88990012L);

        /// <summary>
        /// A layer resource can only be in use once at any point in time.
        /// </summary>
        public const int LayerAlreadyInUse = unchecked((int)0x88990013L);

        /// <summary>
        /// The pop call did not match the corresponding push call.
        /// </summary>
        public const int PopCallDidNotMatchPush = unchecked((int)0x88990014L);

        /// <summary>
        /// The resource was realized on the wrong render target.
        /// </summary>
        public const int WrongResourceDomain = unchecked((int)0x88990015L);

        /// <summary>
        /// The push and pop calls were unbalanced.
        /// </summary>
        public const int PushPopUnbalanced = unchecked((int)0x88990016L);

        /// <summary>
        /// Attempt to copy from a render target while a layer or clip rectangle is applied.
        /// </summary>
        public const int RenderTargetHasLayerOrClipRect = unchecked((int)0x88990017L);

        /// <summary>
        /// The brush types are incompatible for the call.
        /// </summary>
        public const int IncompatibleBrushTypes = unchecked((int)0x88990018L);

        /// <summary>
        /// An unknown win32 failure occurred.
        /// </summary>
        public const int Win32Error = unchecked((int)0x88990019L);

        /// <summary>
        /// The render target is not compatible with GDI.
        /// </summary>
        public const int TargetNotGdiCompatible = unchecked((int)0x8899001AL);

        /// <summary>
        /// A text client drawing effect object is of the wrong type.
        /// </summary>
        public const int TextEffectIsWrongType = unchecked((int)0x8899001BL);

        /// <summary>
        /// The application is holding a reference to the IDWriteTextRenderer interface after the corresponding DrawText or DrawTextLayout call has returned. The IDWriteTextRenderer instance will be invalid.
        /// </summary>
        public const int TextRendererNotReleased = unchecked((int)0x8899001CL);

        /// <summary>
        /// The requested size is larger than the guaranteed supported texture size at the Direct3D device's current feature level.
        /// </summary>
        public const int ExceedsMaxBitmapSize = unchecked((int)0x8899001DL);

        /// <summary>
        /// There was a configuration error in the graph.
        /// </summary>
        public const int InvalidGraphConfiguration = unchecked((int)0x8899001EL);

        /// <summary>
        /// There was a internal configuration error in the graph.
        /// </summary>
        public const int InvalidInternalGraphConfiguration = unchecked((int)0x8899001FL);

        /// <summary>
        /// There was a cycle in the graph.
        /// </summary>
        public const int CyclicGraph = unchecked((int)0x88990020L);

        /// <summary>
        /// Cannot draw with a bitmap that has the D2D1_BITMAP_OPTIONS_CANNOT_DRAW option.
        /// </summary>
        public const int BitmapCannotDraw = unchecked((int)0x88990021L);

        /// <summary>
        /// The operation cannot complete while there are outstanding references to the target bitmap.
        /// </summary>
        public const int OutstandingBitmapReferences = unchecked((int)0x88990022L);

        /// <summary>
        /// The operation failed because the original target is not currently bound as a target.
        /// </summary>
        public const int OriginalTargetNotBound = unchecked((int)0x88990023L);

        /// <summary>
        /// Cannot set the image as a target because it is either an effect or is a bitmap that does not have the D2D1_BITMAP_OPTIONS_TARGET flag set.
        /// </summary>
        public const int InvalidTarget = unchecked((int)0x88990024L);

        /// <summary>
        /// Cannot draw with a bitmap that is currently bound as the target bitmap.
        /// </summary>
        public const int BitmapBoundAsTarget = unchecked((int)0x88990025L);

        /// <summary>
        /// D3D Device does not have sufficient capabilities to perform the requested action.
        /// </summary>
        public const int InsufficientDeviceCapabilities = unchecked((int)0x88990026L);

        /// <summary>
        /// The graph could not be rendered with the context's current tiling settings.
        /// </summary>
        public const int IntermediateTooLarge = unchecked((int)0x88990027L);

        /// <summary>
        /// The CLSID provided to Unregister did not correspond to a registered effect.
        /// </summary>
        public const int EffectIsNotRegistered = unchecked((int)0x88990028L);

        /// <summary>
        /// The specified property does not exist.
        /// </summary>
        public const int InvalidProperty = unchecked((int)0x88990029L);

        /// <summary>
        /// The specified sub-property does not exist.
        /// </summary>
        public const int NoSubproperties = unchecked((int)0x8899002AL);

        /// <summary>
        /// AddPage or Close called after print job is already closed.
        /// </summary>
        public const int PrintJobClosed = unchecked((int)0x8899002BL);

        /// <summary>
        /// Error during print control creation. Indicates that none of the package target types (representing printer formats) are supported by Direct2D print control.
        /// </summary>
        public const int PrintFormatNotSupported = unchecked((int)0x8899002CL);

        /// <summary>
        /// An effect attempted to use a transform with too many inputs.
        /// </summary>
        public const int TooManyTransformInputs = unchecked((int)0x8899002DL);
    }
}
