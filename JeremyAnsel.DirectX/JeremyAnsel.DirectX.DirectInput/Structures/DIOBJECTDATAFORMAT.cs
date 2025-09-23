using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIOBJECTDATAFORMAT
{
    public IntPtr Guid;

    public int Ofs;

    public DIDFT Type;

    public DIDOI Flags;
}
