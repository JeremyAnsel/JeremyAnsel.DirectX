namespace JeremyAnsel.DirectX.WinCodec;

[Flags]
public enum WicProgressNotification : uint
{
    None = 0,

    WICProgressNotificationBegin = 0x00010000,

    WICProgressNotificationEnd = 0x00020000,

    WICProgressNotificationFrequent = 0x00040000,

    WICProgressNotificationAll = 0xFFFF0000,
}
