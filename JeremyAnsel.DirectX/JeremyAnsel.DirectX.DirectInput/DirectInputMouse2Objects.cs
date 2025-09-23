namespace JeremyAnsel.DirectX.DirectInput;

public enum DirectInputMouse2Objects
{
    X = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 0,

    Y = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 1,

    Z = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 2,

    Button0 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 0,

    Button1 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 1,

    Button2 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 2,

    Button3 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 3,

    Button4 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 4,

    Button5 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 5,

    Button6 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 6,

    Button7 = ((int)DirectInputObjectDataTypes.RelativeAxis << 16) | 7,
}
