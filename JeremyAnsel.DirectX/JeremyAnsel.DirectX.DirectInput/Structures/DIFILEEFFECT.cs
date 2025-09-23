using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIFILEEFFECT
{
    public int Size;

    public Guid GuidEffect;

    public IntPtr DiEffect;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string FriendlyName;
}
