using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface for clip status.
    /// </summary>
    public interface IClipStatus : IId, IDescription, IPrefix
    {
        /// <summary>
        /// Collection of clips.
        /// </summary>
        ICollection<IClip> Clips { get; }
    }
}
