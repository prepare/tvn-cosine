using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a clip.
    /// </summary>
    public interface IClip : IId, IDateCreated
    {
        /// <summary>
        /// The issue of this clip.
        /// </summary>
        IIssue Issue { get; }

        /// <summary>
        /// Collection of clip parts for clip.
        /// </summary>
        ICollection<IClipPart> ClipParts { get; }
    }
}
