namespace Tvn.Cosine.Data
{
    /// <summary>
    /// Interface to implement a Date Last Updated field.
    /// </summary>
    public interface IDateLastUpdated
    {
        /// <summary>
        /// Date when item was last updated.
        /// </summary>
        System.DateTime DateLastUpdated { get; }
    }
}
