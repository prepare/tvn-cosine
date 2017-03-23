using Tvn.Cosine.Geometry;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a zone.
    /// </summary>
    public interface IZone : IId, IRectangle<decimal,decimal>, IDateCreated, IFontDetail, IText, IOrder
    {
        /// <summary>
        /// The page for this zone.
        /// </summary>
        IPage Page { get; }

        /// <summary>
        /// The clip part for this zone.
        /// </summary>
        IClipPart ClipPart { get; }

        /// <summary>
        /// The zone type of this zone
        /// </summary>
        IZoneType ZoneType { get; }

        /// <summary>
        /// The measurement unit used.
        /// </summary>
        IMeasurementUnit MeasurementUnit { get; } 
    }
}
