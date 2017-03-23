using Tvn.Cosine.Geometry;

namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Interface to implement a zone.
    /// </summary>
    public interface IZone : IId, IRectangle, IDateCreated
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

        /// <summary>
        /// The text of the zone.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// The font name for this zone.
        /// </summary>
        string FontName { get; }
        
        /// <summary>
        /// The average font size for this zone.
        /// </summary>
        double AverageFontSize { get; }

        /// <summary>
        /// The order of this zone.
        /// </summary>
        int Order { get; }
    }
}
