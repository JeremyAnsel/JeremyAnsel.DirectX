// <copyright file="XMColor.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The color functions provided by DirectXMath.
    /// </summary>
    public static class XMColor
    {
        /// <summary>
        /// Tests for the equality of two colors.
        /// </summary>
        /// <param name="c1">The first color to compare.</param>
        /// <param name="c2">The second color to compare.</param>
        /// <returns>Returns true if each of the components of the two colors are equal, or false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(XMVector c1, XMVector c2)
        {
            return XMVector4.Equal(c1, c2);
        }

        /// <summary>
        /// Tests to see whether two colors are unequal.
        /// </summary>
        /// <param name="c1">The first color to compare.</param>
        /// <param name="c2">The second color to compare.</param>
        /// <returns>Returns true if any component of C1 is different from the corresponding component of C2. Returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(XMVector c1, XMVector c2)
        {
            return XMVector4.NotEqual(c1, c2);
        }

        /// <summary>
        /// Tests whether all the components of the first color are greater than the corresponding components in the second color.
        /// </summary>
        /// <param name="c1">The first color to compare.</param>
        /// <param name="c2">The second color to compare.</param>
        /// <returns>Returns true if every component of C1 is greater than the corresponding component in C2. Returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Greater(XMVector c1, XMVector c2)
        {
            return XMVector4.Greater(c1, c2);
        }

        /// <summary>
        /// Tests whether all the components of the first color are greater than or equal to the corresponding components of the second color.
        /// </summary>
        /// <param name="c1">The first color to compare.</param>
        /// <param name="c2">The second color to compare.</param>
        /// <returns>Returns true if every component of C1 is greater than or equal to the corresponding component in C2. Returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterOrEqual(XMVector c1, XMVector c2)
        {
            return XMVector4.GreaterOrEqual(c1, c2);
        }

        /// <summary>
        /// Tests whether all the components of the first color are less than the corresponding components of the second color.
        /// </summary>
        /// <param name="c1">The first color to compare.</param>
        /// <param name="c2">The second color to compare.</param>
        /// <returns>Returns true if every component of C1 is less than the corresponding component in C2. Returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Less(XMVector c1, XMVector c2)
        {
            return XMVector4.Less(c1, c2);
        }

        /// <summary>
        /// Tests whether all the components of the first color are less than or equal to the corresponding components of the second color.
        /// </summary>
        /// <param name="c1">The first color to compare.</param>
        /// <param name="c2">The second color to compare.</param>
        /// <returns>Returns true if every component of C1 is less than or equal to the corresponding component in C2. Returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessOrEqual(XMVector c1, XMVector c2)
        {
            return XMVector4.LessOrEqual(c1, c2);
        }

        /// <summary>
        /// Tests to see whether any component of a color is not a number (NaN).
        /// </summary>
        /// <param name="c">The color.</param>
        /// <returns>Returns true if any components of C are NaN, or false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "c", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(XMVector c)
        {
            return XMVector4.IsNaN(c);
        }

        /// <summary>
        /// Tests to see whether any of the components of a color are either positive or negative infinity.
        /// </summary>
        /// <param name="c">The color.</param>
        /// <returns>Returns true if any components of C are either positive or negative infinity. Returns false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "c", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinite(XMVector c)
        {
            return XMVector4.IsInfinite(c);
        }

        /// <summary>
        /// Determines the negative RGB color value of a color.
        /// </summary>
        /// <param name="c">The color. Each of the components of C should be in the range 0.0f to 1.0f.</param>
        /// <returns>The negative color. The w-component (alpha) is copied unmodified from the input vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "c", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Negative(XMVector c)
        {
            return new XMVector(
                1.0f - c.X,
                1.0f - c.Y,
                1.0f - c.Z,
                c.W);
        }

        /// <summary>
        /// Blends two colors by multiplying corresponding components together.
        /// </summary>
        /// <param name="c1">The first color.</param>
        /// <param name="c2">The second color.</param>
        /// <returns>The color resulting from the modulation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Modulate(XMVector c1, XMVector c2)
        {
            return XMVector.Multiply(c1, c2);
        }

        /// <summary>
        /// Adjusts the saturation value of a color.
        /// </summary>
        /// <param name="color">The color. Each of the components of C should be in the range 0.0f to 1.0f.</param>
        /// <param name="saturation">Saturation value. This parameter linearly interpolates between the color converted to gray-scale and the original color, C. If Saturation is 0.0f, the function returns the gray-scale color. If Saturation is 1.0f, the function returns the original color.</param>
        /// <returns>The color resulting from the saturation adjustment.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AdjustSaturation(XMVector color, float saturation)
        {
            //// Luminance = 0.2125f * C[0] + 0.7154f * C[1] + 0.0721f * C[2];
            //// Result = (C - Luminance) * Saturation + Luminance;

            XMVector luminanceV = new XMVector(0.2125f, 0.7154f, 0.0721f, 0.0f);

            float luminance = (color.X * luminanceV.X) + (color.Y * luminanceV.Y) + (color.Z * luminanceV.Z);

            return new XMVector(
                ((color.X - luminance) * saturation) + luminance,
                ((color.Y - luminance) * saturation) + luminance,
                ((color.Z - luminance) * saturation) + luminance,
                color.W);
        }

        /// <summary>
        /// Adjusts the contrast value of a color.
        /// </summary>
        /// <param name="color">The color. Each of the components of C should be in the range 0.0f to 1.0f.</param>
        /// <param name="contrast">Contrast value. This parameter linearly interpolates between 50 percent gray and the color C. If this parameter is 0.0f, the returned color is 50 percent gray. If this parameter is 1.0f, the returned color is the original color.</param>
        /// <returns>The color resulting from the contrast adjustment.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AdjustContrast(XMVector color, float contrast)
        {
            //// Result = (vColor - 0.5f) * fContrast + 0.5f;

            return new XMVector(
                ((color.X - 0.5f) * contrast) + 0.5f,
                ((color.Y - 0.5f) * contrast) + 0.5f,
                ((color.Z - 0.5f) * contrast) + 0.5f,
                color.W);
        }

        /// <summary>
        /// Converts RGB color values to HSL color values.
        /// </summary>
        /// <param name="rgb">Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value. The X element is Hue (H), the Y element is Saturation (S), the Z element is Luminance (L), and the W element is Alpha (a copy of the input's Alpha value). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RgbToHsl(XMVector rgb)
        {
            XMVector r = XMVector.SplatX(rgb);
            XMVector g = XMVector.SplatY(rgb);
            XMVector b = XMVector.SplatZ(rgb);

            XMVector min = XMVector.Min(r, XMVector.Min(g, b));
            XMVector max = XMVector.Max(r, XMVector.Max(g, b));

            XMVector l = XMVector.Multiply(XMVector.Add(min, max), XMGlobalConstants.OneHalf);
            XMVector d = XMVector.Subtract(max, min);
            XMVector la = XMVector.Select(rgb, l, XMGlobalConstants.Select1110);

            if (XMVector3.Less(d, XMGlobalConstants.Epsilon))
            {
                // Achromatic, assume H and S of 0
                return XMVector.Select(la, XMGlobalConstants.Zero, XMGlobalConstants.Select1100);
            }
            else
            {
                XMVector s;
                XMVector h;

                XMVector d2 = XMVector.Add(min, max);

                if (XMVector3.Greater(l, XMGlobalConstants.OneHalf))
                {
                    // d / (2-max-min)
                    s = XMVector.Divide(d, XMVector.Subtract(XMGlobalConstants.Two, d2));
                }
                else
                {
                    // d / (max+min)
                    s = XMVector.Divide(d, d2);
                }

                if (XMVector3.Equal(r, max))
                {
                    // Red is max
                    h = XMVector.Divide(XMVector.Subtract(g, b), d);
                }
                else if (XMVector3.Equal(g, max))
                {
                    // Green is max
                    h = XMVector.Divide(XMVector.Subtract(b, r), d);
                    h = XMVector.Add(h, XMGlobalConstants.Two);
                }
                else
                {
                    // Blue is max
                    h = XMVector.Divide(XMVector.Subtract(r, g), d);
                    h = XMVector.Add(h, XMGlobalConstants.Four);
                }

                h = XMVector.Divide(h, XMGlobalConstants.Six);

                if (XMVector3.Less(h, XMGlobalConstants.Zero))
                {
                    h = XMVector.Add(h, XMGlobalConstants.One);
                }

                XMVector lha = XMVector.Select(la, h, XMGlobalConstants.Select1100);
                return XMVector.Select(s, lha, XMGlobalConstants.Select1011);
            }
        }

        /// <summary>
        /// Converts HSL color values to RGB color values.
        /// </summary>
        /// <param name="hsl">Color value to convert. The X element is Hue (H), the Y element is Saturation (S), the Z element is Luminance (L), and the W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of <c>hsl.w</c>) . Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector HslToRgb(XMVector hsl)
        {
            XMVector oneThird = XMVector.FromFloat(1.0f / 3.0f, 1.0f / 3.0f, 1.0f / 3.0f, 1.0f / 3.0f);

            XMVector s = XMVector.SplatY(hsl);
            XMVector l = XMVector.SplatZ(hsl);

            if (XMVector3.NearEqual(s, XMGlobalConstants.Zero, XMGlobalConstants.Epsilon))
            {
                // Achromatic
                return XMVector.Select(hsl, l, XMGlobalConstants.Select1110);
            }
            else
            {
                XMVector h = XMVector.SplatX(hsl);

                XMVector q;

                if (XMVector3.Less(l, XMGlobalConstants.OneHalf))
                {
                    q = XMVector.Multiply(l, XMVector.Add(XMGlobalConstants.One, s));
                }
                else
                {
                    q = XMVector.Subtract(XMVector.Add(l, s), XMVector.Multiply(l, s));
                }

                XMVector p = XMVector.Subtract(XMVector.Multiply(XMGlobalConstants.Two, l), q);

                XMVector r = XMColor.HueToClr(p, q, XMVector.Add(h, oneThird));
                XMVector g = XMColor.HueToClr(p, q, h);
                XMVector b = XMColor.HueToClr(p, q, XMVector.Subtract(h, oneThird));

                XMVector rg = XMVector.Select(g, r, XMGlobalConstants.Select1000);
                XMVector ba = XMVector.Select(hsl, b, XMGlobalConstants.Select1110);

                return XMVector.Select(ba, rg, XMGlobalConstants.Select1100);
            }
        }

        /// <summary>
        /// Converts RGB color values to HSV color values.
        /// </summary>
        /// <param name="rgb">Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value. The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is Alpha (a copy of <c>rgb.w</c>). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RgbToHsv(XMVector rgb)
        {
            XMVector r = XMVector.SplatX(rgb);
            XMVector g = XMVector.SplatY(rgb);
            XMVector b = XMVector.SplatZ(rgb);

            XMVector min = XMVector.Min(r, XMVector.Min(g, b));
            XMVector v = XMVector.Max(r, XMVector.Max(g, b));

            XMVector d = XMVector.Subtract(v, min);
            XMVector s = XMVector3.NearEqual(v, XMGlobalConstants.Zero, XMGlobalConstants.Epsilon) ?
                XMGlobalConstants.Zero :
                XMVector.Divide(d, v);

            if (XMVector3.Less(d, XMGlobalConstants.Epsilon))
            {
                // Achromatic, assume H of 0
                XMVector hv = XMVector.Select(v, XMGlobalConstants.Zero, XMGlobalConstants.Select1000);
                XMVector hva = XMVector.Select(rgb, hv, XMGlobalConstants.Select1110);
                return XMVector.Select(s, hva, XMGlobalConstants.Select1011);
            }
            else
            {
                XMVector h;

                if (XMVector3.Equal(r, v))
                {
                    // Red is max
                    h = XMVector.Divide(XMVector.Subtract(g, b), d);

                    if (XMVector3.Less(g, b))
                    {
                        h = XMVector.Add(h, XMGlobalConstants.Six);
                    }
                }
                else if (XMVector3.Equal(g, v))
                {
                    // Green is max
                    h = XMVector.Divide(XMVector.Subtract(b, r), d);
                    h = XMVector.Add(h, XMGlobalConstants.Two);
                }
                else
                {
                    // Blue is max
                    h = XMVector.Divide(XMVector.Subtract(r, g), d);
                    h = XMVector.Add(h, XMGlobalConstants.Four);
                }

                h = XMVector.Divide(h, XMGlobalConstants.Six);

                XMVector hv = XMVector.Select(v, h, XMGlobalConstants.Select1000);
                XMVector hva = XMVector.Select(rgb, hv, XMGlobalConstants.Select1110);
                return XMVector.Select(s, hva, XMGlobalConstants.Select1011);
            }
        }

        /// <summary>
        /// Converts HSV color values to RGB color values.
        /// </summary>
        /// <param name="hsv">Color value to convert. The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of <c>hsv.w</c>) . Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector HsvToRgb(XMVector hsv)
        {
            XMVector h = XMVector.SplatX(hsv);
            XMVector s = XMVector.SplatY(hsv);
            XMVector v = XMVector.SplatY(hsv);

            XMVector h6 = XMVector.Multiply(h, XMGlobalConstants.Six);
            XMVector i = h6.Floor();
            XMVector f = XMVector.Subtract(h6, i);

            // p = v* (1-s)
            XMVector p = XMVector.Multiply(v, XMVector.Subtract(XMGlobalConstants.One, s));

            // q = v*(1-f*s)
            XMVector q = XMVector.Multiply(v, XMVector.Subtract(XMGlobalConstants.One, XMVector.Multiply(f, s)));

            // t = v*(1 - (1-f)*s)
            XMVector t = XMVector.Multiply(v, XMVector.Subtract(XMGlobalConstants.One, XMVector.Multiply(XMVector.Subtract(XMGlobalConstants.One, f), s)));

            int ii = (int)XMVector.Mod(i, XMGlobalConstants.Six).X;

            XMVector rgb;

            switch (ii)
            {
                case 0:
                    // rgb = vtp
                    XMVector vt = XMVector.Select(t, v, XMGlobalConstants.Select1000);
                    rgb = XMVector.Select(p, vt, XMGlobalConstants.Select1100);
                    break;

                case 1:
                    // rgb = qvp
                    XMVector qv = XMVector.Select(v, q, XMGlobalConstants.Select1000);
                    rgb = XMVector.Select(p, qv, XMGlobalConstants.Select1100);
                    break;

                case 2:
                    // rgb = pvt
                    XMVector pv = XMVector.Select(v, p, XMGlobalConstants.Select1000);
                    rgb = XMVector.Select(t, pv, XMGlobalConstants.Select1100);
                    break;

                case 3:
                    // rgb = pqv
                    XMVector pq = XMVector.Select(q, p, XMGlobalConstants.Select1000);
                    rgb = XMVector.Select(v, pq, XMGlobalConstants.Select1100);
                    break;

                case 4:
                    // rgb = tpv
                    XMVector tp = XMVector.Select(p, t, XMGlobalConstants.Select1000);
                    rgb = XMVector.Select(v, tp, XMGlobalConstants.Select1100);
                    break;

                default:
                    // rgb = vpq
                    XMVector vp = XMVector.Select(p, v, XMGlobalConstants.Select1000);
                    rgb = XMVector.Select(q, vp, XMGlobalConstants.Select1100);
                    break;
            }

            return XMVector.Select(hsv, rgb, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts RGB color values to YUV color values.
        /// </summary>
        /// <param name="rgb">Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (-0.5 to 0.5), the Z element contains the Red-difference chroma (-0.5 to 0.5), and the W element contains the Alpha (a copy of <c>rgb.w</c>).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RgbToYuv(XMVector rgb)
        {
            XMVector scale0 = XMVector.FromFloat(0.299f, -0.147f, 0.615f, 0.0f);
            XMVector scale1 = XMVector.FromFloat(0.587f, -0.289f, -0.515f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(0.114f, 0.436f, -0.100f, 0.0f);

            XMMatrix m = new XMMatrix(scale0, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector3.Transform(rgb, m);

            return XMVector.Select(rgb, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts YUV color values to RGB color values.
        /// </summary>
        /// <param name="yuv">Color value to convert in Luma-Chrominance (YUV) aka <c>YCbCr</c>. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element contains the Alpha (0.0 to 1.0).</param>
        /// <returns>The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of <c>yuv.w</c>). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector YuvToRgb(XMVector yuv)
        {
            XMVector scale1 = XMVector.FromFloat(0.0f, -0.395f, 2.032f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(1.140f, -0.581f, 0.0f, 0.0f);

            XMMatrix m = new XMMatrix(XMGlobalConstants.One, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector3.Transform(yuv, m);

            return XMVector.Select(yuv, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts RGB color values to YUV HD color values.
        /// </summary>
        /// <param name="rgb">Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (-0.5 to 0.5), the Z element contains the Red-difference chroma (-0.5 to 0.5), and the W element contains the Alpha (a copy of <c>rgb.w</c>).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RgbToYuvHD(XMVector rgb)
        {
            XMVector scale0 = XMVector.FromFloat(0.2126f, -0.0997f, 0.6150f, 0.0f);
            XMVector scale1 = XMVector.FromFloat(0.7152f, -0.3354f, -0.5586f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(0.0722f, 0.4351f, -0.0564f, 0.0f);

            XMMatrix m = new XMMatrix(scale0, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector3.Transform(rgb, m);

            return XMVector.Select(rgb, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts YUV color values to RGB HD color values.
        /// </summary>
        /// <param name="yuv">Color value to convert in Luma-Chrominance (YUV) aka <c>YCbCr</c>. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element contains the Alpha (0.0 to 1.0).</param>
        /// <returns>The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of <c>yuv.w</c>). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector YuvToRgbHD(XMVector yuv)
        {
            XMVector scale1 = XMVector.FromFloat(0.0f, -0.2153f, 2.1324f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(1.2803f, -0.3806f, 0.0f, 0.0f);

            XMMatrix m = new XMMatrix(XMGlobalConstants.One, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector3.Transform(yuv, m);

            return XMVector.Select(yuv, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts RGB color values to XYZ color values.
        /// </summary>
        /// <param name="rgb">Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value with the trisimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha (a copy of <c>rgb.w</c>). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RgbToXyz(XMVector rgb)
        {
            XMVector scale0 = XMVector.FromFloat(0.4887180f, 0.1762044f, 0.0000000f, 0.0f);
            XMVector scale1 = XMVector.FromFloat(0.3106803f, 0.8129847f, 0.0102048f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(0.2006017f, 0.0108109f, 0.9897952f, 0.0f);
            XMVector scale = XMVector.FromFloat(1.0f / 0.17697f, 1.0f / 0.17697f, 1.0f / 0.17697f, 0.0f);

            XMMatrix m = new XMMatrix(scale0, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector.Multiply(XMVector3.Transform(rgb, m), scale);

            return XMVector.Select(rgb, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts XYZ color values to RGB color values.
        /// </summary>
        /// <param name="xyz">Color value to convert with the trisimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of <c>xyz.w</c>). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector XyzToRgb(XMVector xyz)
        {
            XMVector scale0 = XMVector.FromFloat(2.3706743f, -0.5138850f, 0.0052982f, 0.0f);
            XMVector scale1 = XMVector.FromFloat(-0.9000405f, 1.4253036f, -0.0146949f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(-0.4706338f, 0.0885814f, 1.0093968f, 0.0f);
            XMVector scale = XMVector.FromFloat(0.17697f, 0.17697f, 0.17697f, 0.0f);

            XMMatrix m = new XMMatrix(scale0, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector3.Transform(XMVector.Multiply(xyz, scale), m);

            return XMVector.Select(xyz, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts XYZ color values to SRGB color values.
        /// </summary>
        /// <param name="xyz">Color value to convert with the trisimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha. Each has a range of 0.0 to 1.0.</param>
        /// <returns>The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of <c>xyz.w</c>). Each has a range of 0.0 to 1.0 in the linear sRGB colorspace.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector XyzToSrgb(XMVector xyz)
        {
            XMVector scale0 = XMVector.FromFloat(3.2406f, -0.9689f, 0.0557f, 0.0f);
            XMVector scale1 = XMVector.FromFloat(-1.5372f, 1.8758f, -0.2040f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(-0.4986f, 0.0415f, 1.0570f, 0.0f);
            XMVector cutoff = XMVector.FromFloat(0.0031308f, 0.0031308f, 0.0031308f, 0.0f);
            XMVector exp = XMVector.FromFloat(1.0f / 2.4f, 1.0f / 2.4f, 1.0f / 2.4f, 1.0f);

            XMMatrix m = new XMMatrix(scale0, scale1, scale2, XMGlobalConstants.Zero);
            XMVector lclr = XMVector3.Transform(xyz, m);
            XMVector sel = XMVector.Greater(lclr, cutoff);

            // clr = 12.92 * lclr for lclr <= 0.0031308f
            XMVector smallC = XMVector.Multiply(lclr, XMGlobalConstants.MsrgbScale);

            // clr = (1+a)*pow(lclr, 1/2.4) - a for lclr > 0.0031308 (where a = 0.055)
            XMVector largeC = XMVector.Subtract(XMVector.Multiply(XMGlobalConstants.MsrgbA1, XMVector.Pow(lclr, exp)), XMGlobalConstants.MsrgbA);

            XMVector clr = XMVector.Select(smallC, largeC, sel);
            return XMVector.Select(xyz, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts SRGB color values to XYZ color values.
        /// </summary>
        /// <param name="srgb">Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0 and is in the linear sRGB colorspace.</param>
        /// <returns>The converted color value with the trisimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha (a copy of <c>rgb.w</c>). Each has a range of 0.0 to 1.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SrgbToXyz(XMVector srgb)
        {
            XMVector scale0 = XMVector.FromFloat(0.4124f, 0.2126f, 0.0193f, 0.0f);
            XMVector scale1 = XMVector.FromFloat(0.3576f, 0.7152f, 0.1192f, 0.0f);
            XMVector scale2 = XMVector.FromFloat(0.1805f, 0.0722f, 0.9505f, 0.0f);
            XMVector cutoff = XMVector.FromFloat(0.04045f, 0.04045f, 0.04045f, 0.0f);
            XMVector exp = XMVector.FromFloat(2.4f, 2.4f, 2.4f, 1.0f);

            XMVector sel = XMVector.Greater(srgb, cutoff);

            // lclr = clr / 12.92
            XMVector smallC = XMVector.Divide(srgb, XMGlobalConstants.MsrgbScale);

            // lclr = pow( (clr + a) / (1+a), 2.4 )
            XMVector largeC = XMVector.Pow(XMVector.Divide(XMVector.Add(srgb, XMGlobalConstants.MsrgbA), XMGlobalConstants.MsrgbA1), exp);

            XMVector lclr = XMVector.Select(smallC, largeC, sel);

            XMMatrix m = new XMMatrix(scale0, scale1, scale2, XMGlobalConstants.Zero);
            XMVector clr = XMVector3.Transform(lclr, m);

            return XMVector.Select(srgb, clr, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts an RGB color vector to sRGB.
        /// </summary>
        /// <param name="rgb">The original RGB color vector.</param>
        /// <returns>The converted sRGBA color vector. The x element is red, the y element is green, the z element is blue, and the w element is the alpha value (which is a copy of <c>rgb.w</c>). Each element value has a range of 0.0 to 1.0 in the sRGB colorspace.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RgbToSrgb(XMVector rgb)
        {
            XMVector cutoff = XMVector.FromFloat(0.0031308f, 0.0031308f, 0.0031308f, 1.0f);
            XMVector linear = XMVector.FromFloat(12.92f, 12.92f, 12.92f, 1.0f);
            XMVector scale = XMVector.FromFloat(1.055f, 1.055f, 1.055f, 1.0f);
            XMVector bias = XMVector.FromFloat(0.055f, 0.055f, 0.055f, 0.0f);
            XMVector invGamma = XMVector.FromFloat(1.0f / 2.4f, 1.0f / 2.4f, 1.0f / 2.4f, 1.0f);

            XMVector v = rgb.Saturate();
            XMVector v0 = XMVector.Multiply(v, linear);
            XMVector v1 = XMVector.Subtract(XMVector.Multiply(scale, XMVector.Pow(v, invGamma)), bias);

            XMVector select = XMVector.Less(v, cutoff);
            v = XMVector.Select(v1, v0, select);
            return XMVector.Select(rgb, v, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts an sRGB color vector to RGB.
        /// </summary>
        /// <param name="srgb">An sRGB color vector.</param>
        /// <returns>The converted RGBA color vector. The x element is red, the y element is green, the z element is blue, and the w element is the alpha value (which is a copy of <c>srgb.w</c>). Each element value has a range of 0.0 to 1.0 in the RGB colorspace.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SrgbToRgb(XMVector srgb)
        {
            XMVector cutoff = XMVector.FromFloat(0.04045f, 0.04045f, 0.04045f, 1.0f);
            XMVector invLinear = XMVector.FromFloat(1.0f / 12.92f, 1.0f / 12.92f, 1.0f / 12.92f, 1.0f);
            XMVector scale = XMVector.FromFloat(1.0f / 1.055f, 1.0f / 1.055f, 1.0f / 1.055f, 1.0f);
            XMVector bias = XMVector.FromFloat(0.055f, 0.055f, 0.055f, 0.0f);
            XMVector gamma = XMVector.FromFloat(2.4f, 2.4f, 2.4f, 1.0f);

            XMVector v = srgb.Saturate();
            XMVector v0 = XMVector.Multiply(v, invLinear);
            XMVector v1 = XMVector.Pow(XMVector.Multiply(XMVector.Add(v, bias), scale), gamma);

            XMVector select = XMVector.Greater(v, cutoff);
            v = XMVector.Select(v0, v1, select);
            return XMVector.Select(srgb, v, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Converts hue to clr.
        /// </summary>
        /// <param name="p">The p parameter.</param>
        /// <param name="q">The q parameter.</param>
        /// <param name="h">The h parameter.</param>
        /// <returns>The clr.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static XMVector HueToClr(XMVector p, XMVector q, XMVector h)
        {
            XMVector oneSixth = XMVector.FromFloat(1.0f / 6.0f, 1.0f / 6.0f, 1.0f / 6.0f, 1.0f / 6.0f);
            XMVector twoThirds = XMVector.FromFloat(2.0f / 3.0f, 2.0f / 3.0f, 2.0f / 3.0f, 2.0f / 3.0f);

            XMVector t = h;

            if (XMVector3.Less(t, XMGlobalConstants.Zero))
            {
                t = XMVector.Add(t, XMGlobalConstants.One);
            }

            if (XMVector3.Greater(t, XMGlobalConstants.One))
            {
                t = XMVector.Subtract(t, XMGlobalConstants.One);
            }

            if (XMVector3.Less(t, oneSixth))
            {
                // p + (q - p) * 6 * t
                XMVector t1 = XMVector.Subtract(q, p);
                XMVector t2 = XMVector.Multiply(XMGlobalConstants.Six, t);
                return XMVector.MultiplyAdd(t1, t2, p);
            }

            if (XMVector3.Less(t, XMGlobalConstants.OneHalf))
            {
                return q;
            }

            if (XMVector3.Less(t, twoThirds))
            {
                // p + (q - p) * 6 * (2/3 - t)
                XMVector t1 = XMVector.Subtract(q, p);
                XMVector t2 = XMVector.Multiply(XMGlobalConstants.Six, XMVector.Subtract(twoThirds, t));
                return XMVector.MultiplyAdd(t1, t2, p);
            }

            return p;
        }
    }
}
