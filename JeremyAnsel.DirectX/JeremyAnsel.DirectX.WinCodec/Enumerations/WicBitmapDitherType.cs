// <copyright file="WicBitmapDitherType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public enum WicBitmapDitherType : uint
{
    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeNone = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeSolid = 0x00000000,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeOrdered4x4 = 0x00000001,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeOrdered8x8 = 0x00000002,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeOrdered16x16 = 0x00000003,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeSpiral4x4 = 0x00000004,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeSpiral8x8 = 0x00000005,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeDualSpiral4x4 = 0x00000006,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeDualSpiral8x8 = 0x00000007,

    /// <summary>
    /// 
    /// </summary>
    WICBitmapDitherTypeErrorDiffusion = 0x00000008,
}
