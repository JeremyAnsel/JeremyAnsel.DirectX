using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIDATAFORMAT
{
    public int Size;

    public int ObjSize;

    public DIDF Flags;

    public int DataSize;

    public int NumObjs;

    public IntPtr rgodf;
}
