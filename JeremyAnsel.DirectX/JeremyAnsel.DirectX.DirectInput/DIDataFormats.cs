namespace JeremyAnsel.DirectX.DirectInput;

internal static class DIDataFormats
{
    public static readonly DirectInputDataFormat c_dfDIMouse = new DirectInputDataFormat
    {
        Options = (DirectInputDataOptions)2,
        DataSize = 16,
        ObjectDataFormats = new DirectInputObjectDataFormat[7]
        {
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 0,
                DataType = unchecked((DirectInputObjectDataTypes)3),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 4,
                DataType = unchecked((DirectInputObjectDataTypes)3),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 8,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 12,
                DataType = unchecked((DirectInputObjectDataTypes)12),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 13,
                DataType = unchecked((DirectInputObjectDataTypes)12),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 14,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 15,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
        }
    };

    public static readonly DirectInputDataFormat c_dfDIMouse2 = new DirectInputDataFormat
    {
        Options = (DirectInputDataOptions)2,
        DataSize = 20,
        ObjectDataFormats = new DirectInputObjectDataFormat[11]
        {
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 0,
                DataType = unchecked((DirectInputObjectDataTypes)3),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 4,
                DataType = unchecked((DirectInputObjectDataTypes)3),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 8,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 12,
                DataType = unchecked((DirectInputObjectDataTypes)12),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 13,
                DataType = unchecked((DirectInputObjectDataTypes)12),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 14,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 15,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 16,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 17,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 18,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 19,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
        }
    };

    public static readonly DirectInputDataFormat c_dfDIJoystick = new DirectInputDataFormat
    {
        Options = (DirectInputDataOptions)1,
        DataSize = 80,
        ObjectDataFormats = new DirectInputObjectDataFormat[44]
        {
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 0,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 4,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 8,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830388, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 12,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830389, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 16,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830371, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 20,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 24,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 28,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 32,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 36,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 40,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 44,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 48,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 49,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 50,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 51,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 52,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 53,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 54,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 55,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 56,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 57,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 58,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 59,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 60,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 61,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 62,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 63,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 64,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 65,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 66,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 67,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 68,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 69,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 70,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 71,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 72,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 73,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 74,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 75,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 76,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 77,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 78,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 79,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
        }
    };

    public static readonly DirectInputDataFormat c_dfDIJoystick2 = new DirectInputDataFormat
    {
        Options = (DirectInputDataOptions)1,
        DataSize = 272,
        ObjectDataFormats = new DirectInputObjectDataFormat[164]
        {
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 0,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 4,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 8,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830388, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 12,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830389, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 16,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830371, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 20,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 24,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 28,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)256
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 32,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 36,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 40,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830386, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 44,
                DataType = unchecked((DirectInputObjectDataTypes)2147483664),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 48,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 49,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 50,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 51,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 52,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 53,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 54,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 55,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 56,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 57,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 58,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 59,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 60,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 61,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 62,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 63,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 64,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 65,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 66,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 67,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 68,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 69,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 70,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 71,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 72,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 73,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 74,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 75,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 76,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 77,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 78,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 79,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 80,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 81,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 82,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 83,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 84,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 85,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 86,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 87,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 88,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 89,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 90,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 91,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 92,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 93,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 94,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 95,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 96,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 97,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 98,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 99,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 100,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 101,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 102,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 103,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 104,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 105,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 106,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 107,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 108,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 109,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 110,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 111,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 112,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 113,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 114,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 115,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 116,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 117,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 118,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 119,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 120,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 121,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 122,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 123,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 124,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 125,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 126,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 127,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 128,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 129,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 130,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 131,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 132,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 133,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 134,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 135,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 136,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 137,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 138,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 139,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 140,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 141,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 142,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 143,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 144,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 145,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 146,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 147,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 148,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 149,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 150,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 151,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 152,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 153,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 154,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 155,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 156,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 157,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 158,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 159,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 160,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 161,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 162,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 163,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 164,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 165,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 166,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 167,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 168,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 169,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 170,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 171,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 172,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 173,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 174,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = null,
                Offset = 175,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 176,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 180,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 184,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830388, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 188,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830389, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 192,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830371, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 196,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 24,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 28,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)512
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 208,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 212,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 216,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830388, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 220,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830389, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 224,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830371, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 228,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 24,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 28,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)768
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830368, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 240,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830369, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 244,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830370, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 248,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830388, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 252,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830389, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 256,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830371, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 260,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 24,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(2741830372, 51699, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 28,
                DataType = unchecked((DirectInputObjectDataTypes)2147483651),
                DataInstance = -1,
                Options = (DirectInputObjectDataOptions)1024
            },
        }
    };

    public static readonly DirectInputDataFormat c_dfDIKeyboard = new DirectInputDataFormat
    {
        Options = (DirectInputDataOptions)2,
        DataSize = 256,
        ObjectDataFormats = new DirectInputObjectDataFormat[256]
        {
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 0,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 0,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 1,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 1,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 2,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 2,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 3,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 3,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 4,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 4,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 5,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 5,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 6,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 6,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 7,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 7,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 8,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 8,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 9,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 9,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 10,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 10,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 11,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 11,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 12,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 12,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 13,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 13,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 14,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 14,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 15,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 15,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 16,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 16,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 17,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 17,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 18,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 18,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 19,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 19,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 20,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 20,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 21,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 21,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 22,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 22,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 23,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 23,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 24,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 24,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 25,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 25,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 26,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 26,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 27,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 27,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 28,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 28,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 29,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 29,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 30,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 30,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 31,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 31,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 32,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 32,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 33,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 33,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 34,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 34,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 35,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 35,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 36,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 36,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 37,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 37,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 38,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 38,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 39,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 39,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 40,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 40,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 41,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 41,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 42,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 42,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 43,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 43,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 44,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 44,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 45,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 45,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 46,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 46,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 47,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 47,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 48,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 48,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 49,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 49,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 50,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 50,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 51,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 51,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 52,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 52,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 53,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 53,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 54,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 54,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 55,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 55,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 56,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 56,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 57,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 57,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 58,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 58,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 59,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 59,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 60,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 60,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 61,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 61,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 62,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 62,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 63,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 63,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 64,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 64,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 65,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 65,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 66,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 66,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 67,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 67,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 68,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 68,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 69,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 69,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 70,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 70,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 71,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 71,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 72,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 72,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 73,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 73,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 74,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 74,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 75,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 75,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 76,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 76,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 77,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 77,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 78,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 78,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 79,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 79,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 80,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 80,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 81,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 81,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 82,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 82,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 83,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 83,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 84,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 84,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 85,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 85,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 86,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 86,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 87,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 87,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 88,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 88,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 89,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 89,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 90,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 90,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 91,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 91,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 92,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 92,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 93,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 93,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 94,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 94,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 95,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 95,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 96,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 96,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 97,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 97,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 98,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 98,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 99,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 99,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 100,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 100,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 101,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 101,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 102,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 102,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 103,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 103,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 104,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 104,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 105,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 105,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 106,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 106,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 107,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 107,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 108,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 108,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 109,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 109,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 110,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 110,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 111,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 111,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 112,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 112,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 113,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 113,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 114,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 114,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 115,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 115,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 116,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 116,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 117,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 117,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 118,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 118,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 119,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 119,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 120,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 120,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 121,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 121,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 122,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 122,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 123,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 123,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 124,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 124,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 125,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 125,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 126,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 126,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 127,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 127,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 128,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 128,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 129,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 129,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 130,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 130,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 131,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 131,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 132,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 132,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 133,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 133,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 134,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 134,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 135,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 135,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 136,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 136,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 137,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 137,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 138,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 138,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 139,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 139,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 140,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 140,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 141,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 141,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 142,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 142,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 143,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 143,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 144,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 144,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 145,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 145,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 146,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 146,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 147,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 147,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 148,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 148,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 149,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 149,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 150,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 150,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 151,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 151,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 152,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 152,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 153,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 153,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 154,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 154,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 155,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 155,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 156,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 156,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 157,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 157,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 158,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 158,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 159,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 159,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 160,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 160,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 161,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 161,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 162,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 162,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 163,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 163,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 164,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 164,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 165,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 165,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 166,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 166,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 167,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 167,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 168,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 168,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 169,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 169,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 170,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 170,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 171,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 171,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 172,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 172,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 173,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 173,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 174,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 174,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 175,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 175,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 176,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 176,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 177,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 177,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 178,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 178,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 179,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 179,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 180,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 180,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 181,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 181,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 182,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 182,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 183,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 183,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 184,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 184,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 185,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 185,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 186,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 186,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 187,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 187,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 188,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 188,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 189,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 189,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 190,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 190,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 191,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 191,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 192,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 192,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 193,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 193,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 194,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 194,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 195,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 195,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 196,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 196,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 197,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 197,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 198,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 198,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 199,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 199,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 200,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 200,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 201,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 201,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 202,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 202,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 203,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 203,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 204,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 204,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 205,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 205,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 206,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 206,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 207,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 207,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 208,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 208,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 209,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 209,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 210,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 210,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 211,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 211,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 212,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 212,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 213,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 213,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 214,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 214,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 215,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 215,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 216,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 216,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 217,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 217,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 218,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 218,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 219,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 219,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 220,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 220,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 221,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 221,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 222,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 222,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 223,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 223,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 224,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 224,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 225,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 225,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 226,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 226,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 227,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 227,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 228,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 228,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 229,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 229,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 230,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 230,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 231,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 231,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 232,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 232,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 233,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 233,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 234,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 234,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 235,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 235,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 236,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 236,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 237,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 237,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 238,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 238,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 239,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 239,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 240,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 240,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 241,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 241,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 242,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 242,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 243,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 243,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 244,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 244,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 245,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 245,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 246,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 246,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 247,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 247,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 248,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 248,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 249,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 249,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 250,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 250,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 251,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 251,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 252,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 252,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 253,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 253,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 254,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 254,
                Options = (DirectInputObjectDataOptions)0
            },
            new DirectInputObjectDataFormat
            {
                Guid = new Guid(1433567776, 54076, 4559, 191, 199, 68, 69, 83, 84, 0, 0),
                Offset = 255,
                DataType = unchecked((DirectInputObjectDataTypes)2147483660),
                DataInstance = 255,
                Options = (DirectInputObjectDataOptions)0
            },
        }
    };
}
