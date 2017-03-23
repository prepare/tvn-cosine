using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a Region.
    /// </summary>
    public interface IRegion : IId, IDescription, IParentChild<IRegion>
    {
        /// <summary>
        /// A collection of publications associated with this region.
        /// </summary>
        ICollection<IPublication> Publications { get; }
    }
}
