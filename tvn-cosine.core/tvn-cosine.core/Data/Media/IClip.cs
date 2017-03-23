using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a clip.
    /// </summary>
    public interface IClip : IId, IDateCreated, IHeadline, ISubHeadline, IBody, IByline
    {
        /// <summary>
        /// The issue of this clip.
        /// </summary>
        IIssue Issue { get; }

        /// <summary>
        /// Collection of clip parts for clip.
        /// </summary>
        ICollection<IClipPart> ClipParts { get; }

        /// <summary>
        /// Status of the clip.
        /// </summary>
        IClipStatus ClipStatus { get; }
    }
}
