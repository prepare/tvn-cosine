using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface for publication section.
    /// </summary>
    public interface IPublicationSection : IId, IName, IPrefix 
    {
        /// <summary>
        /// Publication for this section.
        /// </summary>
        IPublication Publication { get; }

        /// <summary>
        /// Collection of pages for this section.
        /// </summary>
        ICollection<IPage> Pages { get; }
    }
}
