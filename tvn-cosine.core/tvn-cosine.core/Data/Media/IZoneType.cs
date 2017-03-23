using System.Collections.Generic;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a zone type.
    /// </summary>
    public interface IZoneType : IId, IDescription, IPrefix
    {
        /// <summary>
        /// Collection of zones.
        /// </summary>
        ICollection<IZone> Zones { get; }
    }
}
