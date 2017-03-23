using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface for page status.
    /// </summary>
    public interface IPageStatus : IId, IDescription, IPrefix
    {
        /// <summary>
        /// Collection of pages.
        /// </summary>
        ICollection<IPage> Pages { get; }
    }
}
