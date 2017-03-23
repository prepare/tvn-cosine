using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a publication.
    /// </summary>
    public interface IPublication : IId, IName
    {
        /// <summary>
        /// The region of the publication.
        /// </summary>
        IRegion Region { get; } 

        /// <summary>
        /// Collection of issues of this publication.
        /// </summary>
        ICollection<IIssue> Issues { get; }

        /// <summary>
        /// List of languages of this publication.
        /// </summary>
        ICollection<ILanguage> Languages { get; }
    }
}
