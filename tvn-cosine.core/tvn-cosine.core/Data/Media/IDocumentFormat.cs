using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a document format.
    /// </summary>
    public interface IDocumentFormat : IId, IName, IPrefix
    {
        /// <summary>
        /// Collection of page files.
        /// </summary>
        ICollection<IPageFile> PageFiles { get; }
    }
}
