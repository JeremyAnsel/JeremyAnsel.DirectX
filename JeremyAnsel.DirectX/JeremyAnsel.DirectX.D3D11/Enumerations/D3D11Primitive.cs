// <copyright file="D3D11Primitive.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Indicates how the pipeline interprets geometry or hull shader input primitives.
    /// </summary>
    public enum D3D11Primitive
    {
        /// <summary>
        /// The shader has not been initialized with an input primitive type.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Interpret the input primitive as a point.
        /// </summary>
        Point = 1,

        /// <summary>
        /// Interpret the input primitive as a line.
        /// </summary>
        Line = 2,

        /// <summary>
        /// Interpret the input primitive as a triangle.
        /// </summary>
        Triangle = 3,

        /// <summary>
        /// Interpret the input primitive as a line with adjacency data.
        /// </summary>
        LineAdj = 6,

        /// <summary>
        /// Interpret the input primitive as a triangle with adjacency data.
        /// </summary>
        TriangleAdj = 7,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch1ControlPoint = 8,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch2ControlPoint = 9,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch3ControlPoint = 10,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch4ControlPoint = 11,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch5ControlPoint = 12,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch6ControlPoint = 13,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch7ControlPoint = 14,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch8ControlPoint = 15,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch9ControlPoint = 16,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch10ControlPoint = 17,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch11ControlPoint = 18,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch12ControlPoint = 19,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch13ControlPoint = 20,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch14ControlPoint = 21,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch15ControlPoint = 22,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch16ControlPoint = 23,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch17ControlPoint = 24,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch18ControlPoint = 25,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch19ControlPoint = 26,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch20ControlPoint = 28,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch21ControlPoint = 29,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch22ControlPoint = 30,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch23ControlPoint = 31,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch24ControlPoint = 32,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch25ControlPoint = 33,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch26ControlPoint = 34,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch27ControlPoint = 35,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch28ControlPoint = 36,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch29ControlPoint = 37,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch30ControlPoint = 38,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch31ControlPoint = 39,

        /// <summary>
        /// Interpret the input primitive as a control point patch.
        /// </summary>
        Patch32ControlPoint = 40,
    }
}
