// <copyright file="DirectInputEffectInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
public unsafe sealed class DirectInputEffectInfo
{
    internal DirectInputEffectInfo(in DIEFFECTINFO di)
    {
        Identifier = di.guid;
        EffectType = (DirectInputEffectTypes)(uint)di.EffType;
        StaticParams = (DirectInputEffectParameterOptions)(uint)di.StaticParams;
        DynamicParams = (DirectInputEffectParameterOptions)(uint)di.DynamicParams;

        fixed (char* name = di.Name.Buffer)
        {
            Name = new string(name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Identifier { get; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectTypes EffectType { get; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectParameterOptions StaticParams { get; }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectParameterOptions DynamicParams { get; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }
}
