// <copyright file="XMScalar.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The scalar functions provided by DirectXMath.
    /// </summary>
    public static class XMScalar
    {
        /// <summary>
        /// Determines if two floating-point values are nearly equal.
        /// </summary>
        /// <param name="s1">The first floating-point value to compare.</param>
        /// <param name="s2">The second floating-point value to compare.</param>
        /// <param name="epsilon">The tolerance to use when comparing S1 and S2.</param>
        /// <returns>Returns true if the absolute value of the difference between S1 and S2 is less than or equal to Epsilon. Returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearEqual(float s1, float s2, float epsilon)
        {
            float delta = s1 - s2;

            return Math.Abs(delta) <= epsilon;
        }

        /// <summary>
        /// Computes an angle between -XM_PI and XM_PI.
        /// </summary>
        /// <param name="angle">The radian angle.</param>
        /// <returns>Returns an angle greater than or equal to -XM_PI and less than XM_PI that is congruent to Value modulo 2pi.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ModAngle(float angle)
        {
            // Note: The modulo is performed with unsigned math only to work
            // around a precision error on numbers that are close to PI

            // Normalize the range from 0.0f to XM_2PI
            angle = angle + XMMath.PI;

            // Perform the modulo, unsigned
            float temp = Math.Abs(angle);
            temp = temp - (XMMath.TwoPI * (float)(int)(temp / XMMath.TwoPI));

            // Restore the number to the range of -XM_PI to XM_PI-epsilon
            temp = temp - XMMath.PI;

            // If the modulo'd value was negative, restore negation
            if (angle < 0.0f)
            {
                temp = -temp;
            }

            return temp;
        }

        /// <summary>
        /// Computes the sine of a radian angle.
        /// </summary>
        /// <param name="value">The radian angle.</param>
        /// <returns>Returns the sine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = XMMath.OneDivTwoPI * value;

            if (value >= 0.0f)
            {
                quotient = (float)(int)(quotient + 0.5f);
            }
            else
            {
                quotient = (float)(int)(quotient - 0.5f);
            }

            float y = value - (XMMath.TwoPI * quotient);

            // Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
            if (y > XMMath.PIDivTwo)
            {
                y = XMMath.PI - y;
            }
            else if (y < -XMMath.PIDivTwo)
            {
                y = -XMMath.PI - y;
            }

            // 11-degree minimax approximation
            float y2 = y * y;
            return ((((((((((-2.3889859e-08f * y2) + 2.7525562e-06f) * y2) - 0.00019840874f) * y2) + 0.0083333310f) * y2) - 0.16666667f) * y2) + 1.0f) * y;
        }

        /// <summary>
        /// Estimates the sine of a radian angle.
        /// </summary>
        /// <param name="value">The radian angle.</param>
        /// <returns>Returns an estimate of the sine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SinEst(float value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = XMMath.OneDivTwoPI * value;

            if (value >= 0.0f)
            {
                quotient = (float)(int)(quotient + 0.5f);
            }
            else
            {
                quotient = (float)(int)(quotient - 0.5f);
            }

            float y = value - (XMMath.TwoPI * quotient);

            // Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
            if (y > XMMath.PIDivTwo)
            {
                y = XMMath.PI - y;
            }
            else if (y < -XMMath.PIDivTwo)
            {
                y = -XMMath.PI - y;
            }

            // 7-degree minimax approximation
            float y2 = y * y;
            return ((((((-0.00018524670f * y2) + 0.0083139502f) * y2) - 0.16665852f) * y2) + 1.0f) * y;
        }

        /// <summary>
        /// Computes the cosine of a radian angle.
        /// </summary>
        /// <param name="value">The radian angle.</param>
        /// <returns>Returns the cosine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = XMMath.OneDivTwoPI * value;

            if (value >= 0.0f)
            {
                quotient = (float)(int)(quotient + 0.5f);
            }
            else
            {
                quotient = (float)(int)(quotient - 0.5f);
            }

            float y = value - (XMMath.TwoPI * quotient);

            // Map y to [-pi/2,pi/2] with cos(y) = sign*cos(x).
            float sign;

            if (y > XMMath.PIDivTwo)
            {
                y = XMMath.PI - y;
                sign = -1.0f;
            }
            else if (y < -XMMath.PIDivTwo)
            {
                y = -XMMath.PI - y;
                sign = -1.0f;
            }
            else
            {
                sign = +1.0f;
            }

            // 10-degree minimax approximation
            float y2 = y * y;
            float p = (((((((((-2.6051615e-07f * y2) + 2.4760495e-05f) * y2) - 0.0013888378f) * y2) + 0.041666638f) * y2) - 0.5f) * y2) + 1.0f;
            return sign * p;
        }

        /// <summary>
        /// Estimates the cosine of a radian angle.
        /// </summary>
        /// <param name="value">The radian angle.</param>
        /// <returns>Returns the cosine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CosEst(float value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = XMMath.OneDivTwoPI * value;

            if (value >= 0.0f)
            {
                quotient = (float)(int)(quotient + 0.5f);
            }
            else
            {
                quotient = (float)(int)(quotient - 0.5f);
            }

            float y = value - (XMMath.TwoPI * quotient);

            // Map y to [-pi/2,pi/2] with cos(y) = sign*cos(x).
            float sign;

            if (y > XMMath.PIDivTwo)
            {
                y = XMMath.PI - y;
                sign = -1.0f;
            }
            else if (y < -XMMath.PIDivTwo)
            {
                y = -XMMath.PI - y;
                sign = -1.0f;
            }
            else
            {
                sign = +1.0f;
            }

            // 6-degree minimax approximation
            float y2 = y * y;
            float p = (((((-0.0012712436f * y2) + 0.041493919f) * y2) - 0.49992746f) * y2) + 1.0f;
            return sign * p;
        }

        /// <summary>
        /// Computes both the sine and cosine of a radian angle.
        /// </summary>
        /// <param name="sin">The sine of Value.</param>
        /// <param name="cos">The cosine of Value.</param>
        /// <param name="value">The radian angle.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(out float sin, out float cos, float value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = XMMath.OneDivTwoPI * value;

            if (value >= 0.0f)
            {
                quotient = (float)(int)(quotient + 0.5f);
            }
            else
            {
                quotient = (float)(int)(quotient - 0.5f);
            }

            float y = value - (XMMath.TwoPI * quotient);

            // Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
            float sign;

            if (y > XMMath.PIDivTwo)
            {
                y = XMMath.PI - y;
                sign = -1.0f;
            }
            else if (y < -XMMath.PIDivTwo)
            {
                y = -XMMath.PI - y;
                sign = -1.0f;
            }
            else
            {
                sign = +1.0f;
            }

            float y2 = y * y;

            // 11-degree minimax approximation
            sin = ((((((((((-2.3889859e-08f * y2) + 2.7525562e-06f) * y2) - 0.00019840874f) * y2) + 0.0083333310f) * y2) - 0.16666667f) * y2) + 1.0f) * y;

            // 10-degree minimax approximation
            float p = (((((((((-2.6051615e-07f * y2) + 2.4760495e-05f) * y2) - 0.0013888378f) * y2) + 0.041666638f) * y2) - 0.5f) * y2) + 1.0f;
            cos = sign * p;
        }

        /// <summary>
        /// Estimates both the sine and cosine of a radian angle.
        /// </summary>
        /// <param name="sin">The sine of Value.</param>
        /// <param name="cos">The cosine of Value.</param>
        /// <param name="value">The radian angle.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosEst(out float sin, out float cos, float value)
        {
            // Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
            float quotient = XMMath.OneDivTwoPI * value;

            if (value >= 0.0f)
            {
                quotient = (float)(int)(quotient + 0.5f);
            }
            else
            {
                quotient = (float)(int)(quotient - 0.5f);
            }

            float y = value - (XMMath.TwoPI * quotient);

            // Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
            float sign;

            if (y > XMMath.PIDivTwo)
            {
                y = XMMath.PI - y;
                sign = -1.0f;
            }
            else if (y < -XMMath.PIDivTwo)
            {
                y = -XMMath.PI - y;
                sign = -1.0f;
            }
            else
            {
                sign = +1.0f;
            }

            float y2 = y * y;

            // 7-degree minimax approximation
            sin = ((((((-0.00018524670f * y2) + 0.0083139502f) * y2) - 0.16665852f) * y2) + 1.0f) * y;

            // 6-degree minimax approximation
            float p = (((((-0.0012712436f * y2) + 0.041493919f) * y2) - 0.49992746f) * y2) + 1.0f;
            cos = sign * p;
        }

        /// <summary>
        /// Computes the arcsine of a floating-point number.
        /// </summary>
        /// <param name="value">A value between -1.0f and 1.0f.</param>
        /// <returns>Returns the inverse sine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ASin(float value)
        {
            // Clamp input to [-1,1].
            bool nonnegative = value >= 0.0f;
            float x = Math.Abs(value);
            float omx = 1.0f - x;

            if (omx < 0.0f)
            {
                omx = 0.0f;
            }

            float root = (float)Math.Sqrt(omx);

            // 7-degree minimax approximation
            float result = (((((((((((((-0.0012624911f * x) + 0.0066700901f) * x) - 0.0170881256f) * x) + 0.0308918810f) * x) - 0.0501743046f) * x) + 0.0889789874f) * x) - 0.2145988016f) * x) + 1.5707963050f;

            // acos(|x|)
            result *= root;

            // acos(x) = pi - acos(-x) when x < 0, asin(x) = pi/2 - acos(x)
            return nonnegative ? (XMMath.PIDivTwo - result) : (result - XMMath.PIDivTwo);
        }

        /// <summary>
        /// Estimates the arcsine of a floating-point number.
        /// </summary>
        /// <param name="value">A value between -1.0f and 1.0f.</param>
        /// <returns>Returns the inverse sine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ASinEst(float value)
        {
            // Clamp input to [-1,1].
            bool nonnegative = value >= 0.0f;
            float x = Math.Abs(value);
            float omx = 1.0f - x;

            if (omx < 0.0f)
            {
                omx = 0.0f;
            }

            float root = (float)Math.Sqrt(omx);

            // 3-degree minimax approximation
            float result = (((((-0.0187293f * x) + 0.0742610f) * x) - 0.2121144f) * x) + 1.5707288f;

            // acos(|x|)
            result *= root;

            // acos(x) = pi - acos(-x) when x < 0, asin(x) = pi/2 - acos(x)
            return nonnegative ? (XMMath.PIDivTwo - result) : (result - XMMath.PIDivTwo);
        }

        /// <summary>
        /// Computes the arccosine of a floating-point number.
        /// </summary>
        /// <param name="value">A value between -1.0f and 1.0f.</param>
        /// <returns>Returns the inverse cosine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ACos(float value)
        {
            // Clamp input to [-1,1].
            bool nonnegative = value >= 0.0f;
            float x = Math.Abs(value);
            float omx = 1.0f - x;

            if (omx < 0.0f)
            {
                omx = 0.0f;
            }

            float root = (float)Math.Sqrt(omx);

            // 7-degree minimax approximation
            float result = (((((((((((((-0.0012624911f * x) + 0.0066700901f) * x) - 0.0170881256f) * x) + 0.0308918810f) * x) - 0.0501743046f) * x) + 0.0889789874f) * x) - 0.2145988016f) * x) + 1.5707963050f;
            result *= root;

            // acos(x) = pi - acos(-x) when x < 0
            return nonnegative ? result : (XMMath.PI - result);
        }

        /// <summary>
        /// Estimates the arccosine of a floating-point number.
        /// </summary>
        /// <param name="value">A value between -1.0f and 1.0f.</param>
        /// <returns>Returns the inverse cosine of Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ACosEst(float value)
        {
            // Clamp input to [-1,1].
            bool nonnegative = value >= 0.0f;
            float x = Math.Abs(value);
            float omx = 1.0f - x;

            if (omx < 0.0f)
            {
                omx = 0.0f;
            }

            float root = (float)Math.Sqrt(omx);

            // 3-degree minimax approximation
            float result = (((((-0.0187293f * x) + 0.0742610f) * x) - 0.2121144f) * x) + 1.5707288f;
            result *= root;

            // acos(x) = pi - acos(-x) when x < 0
            return nonnegative ? result : (XMMath.PI - result);
        }
    }
}
