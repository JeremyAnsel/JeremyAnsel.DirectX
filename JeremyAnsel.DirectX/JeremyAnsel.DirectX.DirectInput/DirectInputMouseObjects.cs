namespace JeremyAnsel.DirectX.DirectInput;

public enum DirectInputMouseObjects
{
    X = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 0,

    Y = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 1,

    Z = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 2,

    Button0 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 0,

    Button1 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 1,

    Button2 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 2,

    Button3 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 3,
}
