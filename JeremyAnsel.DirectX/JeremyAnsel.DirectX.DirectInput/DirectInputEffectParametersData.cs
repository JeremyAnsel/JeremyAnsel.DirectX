// <copyright file="DirectInputEffectParametersData.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>


using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public unsafe sealed class DirectInputEffectParametersData
{
    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectParametersData()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectParametersDataOptions Options { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int SamplePeriod { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Gain { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int TriggerButton { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int TriggerRepeatInterval { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int[] Axes { get; set; } = Array.Empty<int>();

    /// <summary>
    /// 
    /// </summary>
    public int[] Direction { get; set; } = Array.Empty<int>();

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectEnvelope? Envelope { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectData[]? TypeSpecificParams { get; set; }

    /// <summary>
    /// 
    /// </summary>
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

    internal static nint AllocRawData(DirectInputEffectParameterOptions options, DirectInputEffectTypes effectType)
    {
        int diEffectSize = DXMarshal.SizeOf<DIEFFECT>();
        int diAxesSize = 4 * 32;
        int diDirectionSize = 4 * 32;
        int diEnvelopeSize = DXMarshal.SizeOf<DIENVELOPE>();

        int specificParamsSize = 0;

        if (effectType.HasFlag(DirectInputEffectTypes.Condition))
        {
            specificParamsSize = DXMarshal.SizeOf<DICONDITION>() * 32;
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
        {
            specificParamsSize = DXMarshal.SizeOf<DICUSTOMFORCE>();
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
        {
            specificParamsSize = DXMarshal.SizeOf<DIPERIODIC>();
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
        {
            specificParamsSize = DXMarshal.SizeOf<DICONSTANTFORCE>();
        }
        else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
        {
            specificParamsSize = DXMarshal.SizeOf<DIRAMPFORCE>();
        }

        int size = diEffectSize + diAxesSize + diDirectionSize + diEnvelopeSize + specificParamsSize;

        nint ptr = Marshal.AllocHGlobal(size);
        nint axesPtr = ptr + diEffectSize;
        nint directionPtr = ptr + diEffectSize + diAxesSize;
        nint envelopePtr = ptr + diEffectSize + diAxesSize + diDirectionSize;
        nint specificParamsPtr = specificParamsSize == 0 ? 0 : (ptr + diEffectSize + diAxesSize + diDirectionSize + diEnvelopeSize);

        nint buffer = ptr;
        DXMarshal.Write(ref buffer, diEffectSize);

        buffer = ptr + 28;
        DXMarshal.Write(ref buffer, 32);
        DXMarshal.Write(ref buffer, axesPtr);
        DXMarshal.Write(ref buffer, directionPtr);
        DXMarshal.Write(ref buffer, envelopePtr);
        DXMarshal.Write(ref buffer, specificParamsSize);
        DXMarshal.Write(ref buffer, specificParamsPtr);

        buffer = envelopePtr;
        DXMarshal.Write(ref buffer, diEnvelopeSize);

        return ptr;
    }

    internal nint ToRawData(DirectInputEffectParameterOptions options)
    {
        DirectInputEffectTypes effectType = GetEffectTypes();
        nint ptr = AllocRawData(options, effectType);

        int diEffectSize = DXMarshal.SizeOf<DIEFFECT>();
        int axesCount = Axes.Length;
        int diAxesSize = 4 * axesCount;
        int diDirectionSize = 4 * axesCount;
        int diEnvelopeSize = DXMarshal.SizeOf<DIENVELOPE>();

        int specificParamsSize = 0;

        if (TypeSpecificParams is not null)
        {
            if (effectType.HasFlag(DirectInputEffectTypes.Condition))
            {
                specificParamsSize = DXMarshal.SizeOf<DICONDITION>() * axesCount;
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
            {
                specificParamsSize = DXMarshal.SizeOf<DICUSTOMFORCE>();
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
            {
                specificParamsSize = DXMarshal.SizeOf<DIPERIODIC>();
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
            {
                specificParamsSize = DXMarshal.SizeOf<DICONSTANTFORCE>();
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
            {
                specificParamsSize = DXMarshal.SizeOf<DIRAMPFORCE>();
            }
        }

        nint axesPtr = ptr + diEffectSize;
        nint directionPtr = ptr + diEffectSize + diAxesSize;
        nint envelopePtr = ptr + diEffectSize + diAxesSize + diDirectionSize;
        nint specificParamsPtr = specificParamsSize == 0 ? 0 : (ptr + diEffectSize + diAxesSize + diDirectionSize + diEnvelopeSize);

        nint buffer = ptr;
        DXMarshal.Write(ref buffer, diEffectSize);
        DXMarshal.Write(ref buffer, (int)Options);
        DXMarshal.Write(ref buffer, Duration);
        DXMarshal.Write(ref buffer, SamplePeriod);
        DXMarshal.Write(ref buffer, Gain);
        DXMarshal.Write(ref buffer, TriggerButton);
        DXMarshal.Write(ref buffer, TriggerRepeatInterval);
        DXMarshal.Write(ref buffer, axesCount);
        DXMarshal.Write(ref buffer, axesPtr);
        DXMarshal.Write(ref buffer, directionPtr);
        DXMarshal.Write(ref buffer, Envelope is null ? 0 : envelopePtr);
        DXMarshal.Write(ref buffer, specificParamsSize);
        DXMarshal.Write(ref buffer, specificParamsPtr);
        DXMarshal.Write(ref buffer, StartDelay);

        buffer = axesPtr;
        for (int i = 0; i < axesCount; i++)
        {
            DXMarshal.Write(ref buffer, Axes[i]);
        }

        buffer = directionPtr;
        for (int i = 0; i < axesCount; i++)
        {
            DXMarshal.Write(ref buffer, Direction[i]);
        }

        if (Envelope is not null)
        {
            buffer = envelopePtr;
            DXMarshal.Write(ref buffer, diEnvelopeSize);
            DXMarshal.Write(ref buffer, Envelope.AttackLevel);
            DXMarshal.Write(ref buffer, Envelope.AttackTime);
            DXMarshal.Write(ref buffer, Envelope.FadeLevel);
            DXMarshal.Write(ref buffer, Envelope.FadeTime);
        }

        if (TypeSpecificParams is not null)
        {
            if (effectType.HasFlag(DirectInputEffectTypes.Condition))
            {
                int itemSize = DXMarshal.SizeOf<DICONDITION>();

                for (int i = 0; i < axesCount; i++)
                {
                    DirectInputEffectDataCondition d = (DirectInputEffectDataCondition)TypeSpecificParams![i];
                    DXMarshal.WriteStructure(specificParamsPtr + i * itemSize, d.ToDI());
                }
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
            {
                DirectInputEffectDataCustomForce d = (DirectInputEffectDataCustomForce)TypeSpecificParams![0];
                DXMarshal.WriteStructure(specificParamsPtr, d.ToDI());
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
            {
                DirectInputEffectDataPeriodic d = (DirectInputEffectDataPeriodic)TypeSpecificParams![0];
                DXMarshal.WriteStructure(specificParamsPtr, d.ToDI());
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
            {
                DirectInputEffectDataConstantForce d = (DirectInputEffectDataConstantForce)TypeSpecificParams![0];
                DXMarshal.WriteStructure(specificParamsPtr, d.ToDI());
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
            {
                DirectInputEffectDataRampForce d = (DirectInputEffectDataRampForce)TypeSpecificParams![0];
                DXMarshal.WriteStructure(specificParamsPtr, d.ToDI());
            }
        }

        return ptr;
    }

    internal static DirectInputEffectParametersData FromRawData(nint ptr, DirectInputEffectParameterOptions options, DirectInputEffectTypes effectType)
    {
        DirectInputEffectParametersData data = new();
        nint buffer;

        int diEffectSize = DXMarshal.SizeOf<DIEFFECT>();
        buffer = ptr + 28;
        int axesCount = DXMarshal.ReadInt32(ref buffer);
        int diAxesSize = 4 * axesCount;
        int diDirectionSize = 4 * axesCount;
        int diEnvelopeSize = DXMarshal.SizeOf<DIENVELOPE>();

        buffer = ptr + 32 + sizeof(nint) * 3;
        int specificParamsSize = DXMarshal.ReadInt32(ref buffer);

        buffer = ptr + 32;
        nint axesPtr = DXMarshal.ReadIntPtr(ref buffer);
        nint directionPtr = DXMarshal.ReadIntPtr(ref buffer);
        nint envelopePtr = DXMarshal.ReadIntPtr(ref buffer);
        buffer = 36 + sizeof(nint) * 3;
        nint specificParamsPtr = DXMarshal.ReadIntPtr(ref buffer);

        buffer = ptr + 4;
        data.Options = (DirectInputEffectParametersDataOptions)DXMarshal.ReadInt32(ref buffer);
        data.Duration = DXMarshal.ReadInt32(ref buffer);
        data.SamplePeriod = DXMarshal.ReadInt32(ref buffer);
        data.Gain = DXMarshal.ReadInt32(ref buffer);
        data.TriggerButton = DXMarshal.ReadInt32(ref buffer);
        data.TriggerRepeatInterval = DXMarshal.ReadInt32(ref buffer);
        buffer = ptr + 36 + sizeof(nint) * 4;
        data.StartDelay = DXMarshal.ReadInt32(ref buffer);

        data.Axes = new int[axesCount];
        buffer = axesPtr;
        for (int i = 0; i < axesCount; i++)
        {
            data.Axes[i] = DXMarshal.ReadInt32(ref buffer);
        }

        data.Direction = new int[axesCount];
        buffer = directionPtr;
        for (int i = 0; i < axesCount; i++)
        {
            data.Direction[i] = DXMarshal.ReadInt32(ref buffer);
        }

        if (envelopePtr != 0)
        {
            DIENVELOPE diEnvelope = DXMarshal.ReadStructure<DIENVELOPE>(envelopePtr);
            data.Envelope = new DirectInputEffectEnvelope(diEnvelope);
        }

        if (specificParamsPtr != 0)
        {
            if (effectType.HasFlag(DirectInputEffectTypes.Condition))
            {
                int itemSize = DXMarshal.SizeOf<DICONDITION>();
                int count = specificParamsSize / itemSize;
                data.TypeSpecificParams = new DirectInputEffectDataCondition[count];

                for (int i = 0; i < count; i++)
                {
                    DICONDITION di = DXMarshal.ReadStructure<DICONDITION>(specificParamsPtr + i * itemSize);
                    data.TypeSpecificParams[i] = new DirectInputEffectDataCondition(di);
                }
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.CustomForce))
            {
                data.TypeSpecificParams = new DirectInputEffectDataCustomForce[1];
                DICUSTOMFORCE di = DXMarshal.ReadStructure<DICUSTOMFORCE>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataCustomForce(di);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.Periodic))
            {
                data.TypeSpecificParams = new DirectInputEffectDataPeriodic[1];
                DIPERIODIC di = DXMarshal.ReadStructure<DIPERIODIC>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataPeriodic(di);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.ConstantForce))
            {
                data.TypeSpecificParams = new DirectInputEffectDataConstantForce[1];
                DICONSTANTFORCE di = DXMarshal.ReadStructure<DICONSTANTFORCE>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataConstantForce(di);
            }
            else if (effectType.HasFlag(DirectInputEffectTypes.RampForce))
            {
                data.TypeSpecificParams = new DirectInputEffectDataRampForce[1];
                DIRAMPFORCE di = DXMarshal.ReadStructure<DIRAMPFORCE>(specificParamsPtr);
                data.TypeSpecificParams[0] = new DirectInputEffectDataRampForce(di);
            }
        }

        return data;
    }

    internal static void FreeRawData(nint ptr)
    {
        if (ptr == 0)
        {
            return;
        }

        Marshal.FreeHGlobal(ptr);
    }
}
