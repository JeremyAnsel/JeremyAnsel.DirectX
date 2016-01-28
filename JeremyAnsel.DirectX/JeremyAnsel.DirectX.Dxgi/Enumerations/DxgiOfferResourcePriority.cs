// <copyright file="DxgiOfferResourcePriority.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Identifies the importance of a resource’s content.
    /// </summary>
    public enum DxgiOfferResourcePriority
    {
        /// <summary>
        /// Unspecified priority.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The resource is low priority. The operating system discards a low priority resource before other offered resources with higher priority. It is a good programming practice to mark a resource as low priority if it has no useful content.
        /// </summary>
        Low,

        /// <summary>
        /// The resource is normal priority. You mark a resource as normal priority if it has content that is easy to regenerate.
        /// </summary>
        Normal,

        /// <summary>
        /// The resource is high priority. The operating system discards other offered resources with lower priority before it discards a high priority resource. You mark a resource as high priority if it has useful content that is difficult to regenerate.
        /// </summary>
        High
    }
}
