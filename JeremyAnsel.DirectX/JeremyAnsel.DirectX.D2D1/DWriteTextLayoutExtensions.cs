using JeremyAnsel.DirectX.DWrite;

namespace JeremyAnsel.DirectX.D2D1;

public static class DWriteTextLayoutExtensions
{
    public static void SetForegroundBrush(this DWriteTextLayout textLayout, D2D1Brush? foregroundBrush, DWriteTextRange textRange)
    {
        textLayout.SetDrawingEffect(foregroundBrush is null ? 0 : foregroundBrush.Handle, textRange);
    }

    public static D2D1Brush? GetForegroundBrush(this DWriteTextLayout textLayout, uint currentPosition, out DWriteTextRange textRange)
    {
        nint ptr = textLayout.GetDrawingEffect(currentPosition, out textRange);
        return ptr == 0 ? null : new D2D1Brush(ptr);
    }
}
