using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement an issue.
    /// </summary>
    public interface IIssue : IId, IDateCreated
    {
        /// <summary>
        /// The publication this issue belongs to.
        /// </summary>
        IPublication Publication { get; }

        /// <summary>
        /// Collection of clips for this issue.
        /// </summary>
        ICollection<IClip> Clips { get; }
    }
}
