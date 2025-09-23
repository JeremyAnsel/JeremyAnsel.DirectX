using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffectParametersData
{
    public DirectInputEffectParametersData()
    {
    }

    public DirectInputEffectParametersDataOptions Options { get; set; }

    public int Duration { get; set; }

    public int SamplePeriod { get; set; }

    public int Gain { get; set; }

    public int TriggerButton { get; set; }

    public int TriggerRepeatInterval { get; set; }

    public int[] Axes { get; set; } = Array.Empty<int>();

    public int[] Direction { get; set; } = Array.Empty<int>();

    public DirectInputEffectEnvelope? Envelope { get; set; }

    public DirectInputEffectData[]? TypeSpecificParams { get; set; }

    public int StartDelay { get; set; }

    private DirectInputEffectTypes GetEffectTypes()
    {
        DirectInputEffectTypes effectType = DirectInputEffectTypes.All;

        if (TypeSpecificParams is not null && TypeSpecificParams.Length > 0)
        {
            DirectInputEffectData d = TypeSpecificParams[0];

            effectType = d switch
            {
                DirectInputEffectDataCondition => DirectInputEffectTypes.Condition,
                DirectInputEffectDataCustomForce => DirectInputEffectTypes.CustomForce,
                DirectInputEffectDataPeriodic => DirectInputEffectTypes.Periodic,
                DirectInputEffectDataConstantForce => DirectInputEffectTypes.ConstantForce,
                DirectInputEffectDataRampForce => DirectInputEffectTypes.RampForce,
                _ => effectType
            };
        }

        return effectType;
    }

    internal static IntPtr AllocRawData(DirectInputEffectParameterOptions options, DirectInputEffectTypes effectType)
    {
        int diEffectSize = Marshal.SizeOf<DIEFFECT>();
        int diAxesSize = 4 * 32;
        int diDirectionSize = 4 * 32;
        int diEnvelopeSize = Marshal.SizeOf<DIENVELOPE>();

        int specificParamsSize = 0;

        if (effectType.HasFlag(DirectInputEffectTypes.Condition))
        {
            specificParamsSize = Marshal.SizeOf<DICONDITION>() * 32;
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
        {
            specificParamsSize = Marshal.SizeOf<DICUSTOMFORCE>();
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
        {
            specificParamsSize = Marshal.SizeOf<DIPERIODIC>();
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
        {
            specificParamsSize = Marshal.SizeOf<DICONSTANTFORCE>();
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
        {
            specificParamsSize = Marshal.SizeOf<DIRAMPFORCE>();
        }

        int size = diEffectSize + diAxesSize + diDirectionSize + diEnvelopeSize + specificParamsSize;

        IntPtr ptr = Marshal.AllocHGlobal(size);
        IntPtr axesPtr = ptr + diEffectSize;
        IntPtr directionPtr = ptr + diEffectSize + diAxesSize;
        IntPtr envelopePtr = ptr + diEffectSize + diAxesSize + diDirectionSize;
        IntPtr specificParamsPtr = specificParamsSize == 0 ? IntPtr.Zero : (ptr + diEffectSize + diAxesSize + diDirectionSize + diEnvelopeSize);

        Marshal.WriteInt32(ptr, 0, diEffectSize);
        Marshal.WriteInt32(ptr, 28, 32);
        Marshal.WriteIntPtr(ptr, 32, axesPtr);
        Marshal.WriteIntPtr(ptr, 32 + IntPtr.Size, directionPtr);
        Marshal.WriteIntPtr(ptr, 32 + IntPtr.Size * 2, envelopePtr);
        Marshal.WriteInt32(ptr, 32 + IntPtr.Size * 3, specificParamsSize);
        Marshal.WriteIntPtr(ptr, 36 + IntPtr.Size * 3, specificParamsPtr);

        Marshal.WriteInt32(envelopePtr, 0, diEnvelopeSize);

        return ptr;
    }

    internal IntPtr ToRawData(DirectInputEffectParameterOptions options)
    {
        DirectInputEffectTypes effectType = GetEffectTypes();
        IntPtr ptr = AllocRawData(options, effectType);

        int diEffectSize = Marshal.SizeOf<DIEFFECT>();
        int axesCount = Axes.Length;
        int diAxesSize = 4 * axesCount;
        int diDirectionSize = 4 * axesCount;
        int diEnvelopeSize = Marshal.SizeOf<DIENVELOPE>();

        int specificParamsSize = 0;

        if (TypeSpecificParams is not null)
        {
            if (effectType.HasFlag(DirectInputEffectTypes.Condition))
            {
                specificParamsSize = Marshal.SizeOf<DICONDITION>() * axesCount;
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
            {
                specificParamsSize = Marshal.SizeOf<DICUSTOMFORCE>();
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
            {
                specificParamsSize = Marshal.SizeOf<DIPERIODIC>();
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
            {
                specificParamsSize = Marshal.SizeOf<DICONSTANTFORCE>();
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
            {
                specificParamsSize = Marshal.SizeOf<DIRAMPFORCE>();
            }
        }

        IntPtr axesPtr = ptr + diEffectSize;
        IntPtr directionPtr = ptr + diEffectSize + diAxesSize;
        IntPtr envelopePtr = ptr + diEffectSize + diAxesSize + diDirectionSize;
        IntPtr specificParamsPtr = specificParamsSize == 0 ? IntPtr.Zero : (ptr + diEffectSize + diAxesSize + diDirectionSize + diEnvelopeSize);

        Marshal.WriteInt32(ptr, 0, diEffectSize);
        Marshal.WriteInt32(ptr, 4, (int)Options);
        Marshal.WriteInt32(ptr, 8, Duration);
        Marshal.WriteInt32(ptr, 12, SamplePeriod);
        Marshal.WriteInt32(ptr, 16, Gain);
        Marshal.WriteInt32(ptr, 20, TriggerButton);
        Marshal.WriteInt32(ptr, 24, TriggerRepeatInterval);
        Marshal.WriteInt32(ptr, 28, axesCount);
        Marshal.WriteIntPtr(ptr, 32, axesPtr);
        Marshal.WriteIntPtr(ptr, 32 + IntPtr.Size, directionPtr);
        Marshal.WriteIntPtr(ptr, 32 + IntPtr.Size * 2, Envelope is null ? IntPtr.Zero : envelopePtr);
        Marshal.WriteInt32(ptr, 32 + IntPtr.Size * 3, specificParamsSize);
        Marshal.WriteIntPtr(ptr, 36 + IntPtr.Size * 3, specificParamsPtr);
        Marshal.WriteInt32(ptr, 36 + IntPtr.Size * 4, StartDelay);

        for (int i = 0; i < axesCount; i++)
        {
            Marshal.WriteInt32(axesPtr, i * 4, Axes[i]);
        }

        for (int i = 0; i < axesCount; i++)
        {
            Marshal.WriteInt32(directionPtr, i * 4, Direction[i]);
        }

        if (Envelope is not null)
        {
            Marshal.WriteInt32(envelopePtr, 0, diEnvelopeSize);
            Marshal.WriteInt32(envelopePtr, 4, Envelope.AttackLevel);
            Marshal.WriteInt32(envelopePtr, 8, Envelope.AttackTime);
            Marshal.WriteInt32(envelopePtr, 12, Envelope.FadeLevel);
            Marshal.WriteInt32(envelopePtr, 16, Envelope.FadeTime);
        }

        if (TypeSpecificParams is not null)
        {
            if (effectType.HasFlag(DirectInputEffectTypes.Condition))
            {
                int itemSize = Marshal.SizeOf<DICONDITION>();

                for (int i = 0; i < axesCount; i++)
                {
                    DirectInputEffectDataCondition d = (DirectInputEffectDataCondition)TypeSpecificParams![i];
                    Marshal.StructureToPtr(d.ToDI(), specificParamsPtr + i * itemSize, false);
                }
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
            {
                DirectInputEffectDataCustomForce d = (DirectInputEffectDataCustomForce)TypeSpecificParams![0];
                Marshal.StructureToPtr(d.ToDI(), specificParamsPtr, false);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
            {
                DirectInputEffectDataPeriodic d = (DirectInputEffectDataPeriodic)TypeSpecificParams![0];
                Marshal.StructureToPtr(d.ToDI(), specificParamsPtr, false);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
            {
                DirectInputEffectDataConstantForce d = (DirectInputEffectDataConstantForce)TypeSpecificParams![0];
                Marshal.StructureToPtr(d.ToDI(), specificParamsPtr, false);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
            {
                DirectInputEffectDataRampForce d = (DirectInputEffectDataRampForce)TypeSpecificParams![0];
                Marshal.StructureToPtr(d.ToDI(), specificParamsPtr, false);
            }
        }

        return ptr;
    }

    internal static DirectInputEffectParametersData FromRawData(IntPtr ptr, DirectInputEffectParameterOptions options, DirectInputEffectTypes effectType)
    {
        DirectInputEffectParametersData data = new();

        int diEffectSize = Marshal.SizeOf<DIEFFECT>();
        int axesCount = Marshal.ReadInt32(ptr, 28);
        int diAxesSize = 4 * axesCount;
        int diDirectionSize = 4 * axesCount;
        int diEnvelopeSize = Marshal.SizeOf<DIENVELOPE>();

        int specificParamsSize = Marshal.ReadInt32(ptr, 32 + IntPtr.Size * 3);

        IntPtr axesPtr = Marshal.ReadIntPtr(ptr, 32);
        IntPtr directionPtr = Marshal.ReadIntPtr(ptr, 32 + IntPtr.Size);
        IntPtr envelopePtr = Marshal.ReadIntPtr(ptr, 32 + IntPtr.Size * 2);
        IntPtr specificParamsPtr = Marshal.ReadIntPtr(ptr, 36 + IntPtr.Size * 3);

        data.Options = (DirectInputEffectParametersDataOptions)Marshal.ReadInt32(ptr, 4);
        data.Duration = Marshal.ReadInt32(ptr, 8); ;
        data.SamplePeriod = Marshal.ReadInt32(ptr, 12);
        data.Gain = Marshal.ReadInt32(ptr, 16);
        data.TriggerButton = Marshal.ReadInt32(ptr, 20);
        data.TriggerRepeatInterval = Marshal.ReadInt32(ptr, 24);
        data.StartDelay = Marshal.ReadInt32(ptr, 36 + IntPtr.Size * 4);

        data.Axes = new int[axesCount];
        for (int i = 0; i < axesCount; i++)
        {
            data.Axes[i] = Marshal.ReadInt32(axesPtr, i * 4);
        }

        data.Direction = new int[axesCount];
        for (int i = 0; i < axesCount; i++)
        {
            data.Direction[i] = Marshal.ReadInt32(directionPtr, i * 4);
        }

        if (envelopePtr != IntPtr.Zero)
        {
            DIENVELOPE diEnvelope = Marshal.PtrToStructure<DIENVELOPE>(envelopePtr);
            data.Envelope = new DirectInputEffectEnvelope(diEnvelope);
        }

        if (specificParamsPtr != IntPtr.Zero)
        {
            if (effectType.HasFlag(DirectInputEffectTypes.Condition))
            {
                int itemSize = Marshal.SizeOf<DICONDITION>();
                int count = specificParamsSize / itemSize;
                data.TypeSpecificParams = new DirectInputEffectDataCondition[count];

                for (int i = 0; i < count; i++)
                {
                    DICONDITION di = Marshal.PtrToStructure<DICONDITION>(specificParamsPtr + i * itemSize);
                    data.TypeSpecificParams[i] = new DirectInputEffectDataCondition(di);
                }
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
            {
                data.TypeSpecificParams = new DirectInputEffectDataCustomForce[1];
                DICUSTOMFORCE di = Marshal.PtrToStructure<DICUSTOMFORCE>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataCustomForce(di);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
            {
                data.TypeSpecificParams = new DirectInputEffectDataPeriodic[1];
                DIPERIODIC di = Marshal.PtrToStructure<DIPERIODIC>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataPeriodic(di);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
            {
                data.TypeSpecificParams = new DirectInputEffectDataConstantForce[1];
                DICONSTANTFORCE di = Marshal.PtrToStructure<DICONSTANTFORCE>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataConstantForce(di);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
            {
                data.TypeSpecificParams = new DirectInputEffectDataRampForce[1];
                DIRAMPFORCE di = Marshal.PtrToStructure<DIRAMPFORCE>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataRampForce(di);
            }
        }

        return data;
    }

    internal static void FreeRawData(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
        {
            return;
        }

        Marshal.FreeHGlobal(ptr);
    }
}
