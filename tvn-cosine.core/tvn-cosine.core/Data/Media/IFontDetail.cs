namespace Tvn.Cosine.Data.Media
{
    /// <summary>
    /// Implementation for font detail.
    /// </summary>
    public interface IFontDetail
    {
        /// <summary>
        /// The font name for this zone.
        /// </summary>
        string FontName { get; }

        /// <summary>
        /// The average font size for this zone.
        /// </summary>
        double FontSize { get; }
    }
}
