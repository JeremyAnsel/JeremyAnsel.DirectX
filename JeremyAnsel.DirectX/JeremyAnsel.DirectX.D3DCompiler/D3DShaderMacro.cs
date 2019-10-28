// <copyright file="D3DShaderMacro.cs" company="Jérémy Ansel">
// Copyright (c) 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a shader macro.
    /// </summary>
    public struct D3DShaderMacro : IEquatable<D3DShaderMacro>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D3DShaderMacro"/> struct.
        /// </summary>
        /// <param name="name">The macro name.</param>
        /// <param name="definition">The macro definition</param>
        public D3DShaderMacro(string name, string definition)
        {
            this.Name = name;
            this.Definition = definition;
        }

        /// <summary>
        /// Gets or sets the macro name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the macro definition.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is D3DShaderMacro macro && Equals(macro);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(D3DShaderMacro other)
        {
            return Name == other.Name &&
                   Definition == other.Definition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1715526538;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Definition);
            return hashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(D3DShaderMacro left, D3DShaderMacro right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(D3DShaderMacro left, D3DShaderMacro right)
        {
            return !(left == right);
        }
    }
}
