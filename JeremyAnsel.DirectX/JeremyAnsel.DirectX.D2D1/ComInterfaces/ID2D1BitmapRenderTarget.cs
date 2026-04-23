// <copyright file="ID2D1BitmapRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Renders to an intermediate texture created by the <see cref="CreateCompatibleRenderTarget"/> method.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1RenderTarget"/></remarks>
[Guid("2cd90695-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1BitmapRenderTarget
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;
    private readonly nint CreateBitmap;
    private readonly nint CreateBitmapFromWicBitmap;
    private readonly nint CreateSharedBitmap;
    private readonly nint CreateBitmapBrush;
    private readonly nint CreateSolidColorBrush;
    private readonly nint CreateGradientStopCollection;
    private readonly nint CreateLinearGradientBrush;
    private readonly nint CreateRadialGradientBrush;
    private readonly nint CreateCompatibleRenderTarget;
    private readonly nint CreateLayer;
    private readonly nint CreateMesh;
    private readonly nint DrawLine;
    private readonly nint DrawRectangle;
    private readonly nint FillRectangle;
    private readonly nint DrawRoundedRectangle;
    private readonly nint FillRoundedRectangle;
    private readonly nint DrawEllipse;
    private readonly nint FillEllipse;
    private readonly nint DrawGeometry;
    private readonly nint FillGeometry;
    private readonly nint FillMesh;
    private readonly nint FillOpacityMask;
    private readonly nint DrawBitmap;
    private readonly nint DrawText;
    private readonly nint DrawTextLayout;
    private readonly nint DrawGlyphRun;
    private readonly nint SetTransform;
    private readonly nint GetTransform;
    private readonly nint SetAntialiasMode;
    private readonly nint GetAntialiasMode;
    private readonly nint SetTextAntialiasMode;
    private readonly nint GetTextAntialiasMode;
    private readonly nint SetTextRenderingParams;
    private readonly nint GetTextRenderingParams;
    private readonly nint SetTags;
    private readonly nint GetTags;
    private readonly nint PushLayer;
    private readonly nint PopLayer;
    private readonly nint Flush;
    private readonly nint SaveDrawingState;
    private readonly nint RestoreDrawingState;
    private readonly nint PushAxisAlignedClip;
    private readonly nint PopAxisAlignedClip;
    private readonly nint Clear;
    private readonly nint BeginDraw;
    private readonly nint EndDraw;
    private readonly nint GetPixelFormat;
    private readonly nint SetDpi;
    private readonly nint GetDpi;
    private readonly nint GetSize;
    private readonly nint GetPixelSize;
    private readonly nint GetMaximumBitmapSize;
    private readonly nint IsSupported;

    /// <summary>
    /// Retrieves the bitmap for this render target. The returned bitmap can be used for drawing operations.
    /// </summary>
    /// <param name="bitmap">The bitmap for this render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetBitmap;
}
